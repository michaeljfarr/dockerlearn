using System;
using System.Collections.Concurrent;
using System.Security;
using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle.Scoped;
using Castle.Windsor;

namespace Herolab.WebAPI
{
    public class ManualLifetimeScope : ILifetimeScope, IDisposable
    {
        private static readonly ConcurrentDictionary<Guid, ManualLifetimeScope> InstanceCache =
            new ConcurrentDictionary<Guid, ManualLifetimeScope>();

        [ThreadStatic]
        private static Guid _currentContextId;

        private readonly Lock @lock = Lock.Create();
        private ScopeCache cache = new ScopeCache();
        private readonly Guid _contextId;

        public ManualLifetimeScope(IKernel container)
        {
            this._contextId = Guid.NewGuid();
            InstanceCache.TryAdd(this._contextId, this);
        }

        public ManualLifetimeScope(IWindsorContainer container)
            : this(container.Kernel)
        {
        }

        [SecuritySafeCritical]
        public void Dispose()
        {
            using (var upgradeableLockHolder = this.@lock.ForReadingUpgradeable())
            {
                if (this.cache == null)
                    return;
                upgradeableLockHolder.Upgrade();
                this.cache.Dispose();
                this.cache = null;
            }
            ManualLifetimeScope contextLifetimeScope;
            InstanceCache.TryRemove(this._contextId, out contextLifetimeScope);
        }

        public Burden GetCachedInstance(ComponentModel model, ScopedInstanceActivationCallback createInstance)
        {
            using (var upgradeableLockHolder = this.@lock.ForReadingUpgradeable())
            {
                var burden = this.cache[(object) model];
                if (burden != null) return burden;

                upgradeableLockHolder.Upgrade();
                burden = createInstance(createdBurden => { });
                this.cache[(object) model] = burden;
                return burden;
            }
        }

        [SecuritySafeCritical]
        public static void SetCurrentScope(ManualLifetimeScope lifetimeScope)
        {
            _currentContextId = lifetimeScope?._contextId ?? Guid.Empty;
        }

        [SecuritySafeCritical]
        public static ManualLifetimeScope ObtainCurrentScope()
        {
            if (_currentContextId == Guid.Empty)
                return (ManualLifetimeScope) null;
            ManualLifetimeScope contextLifetimeScope;
            ManualLifetimeScope.InstanceCache.TryGetValue(_currentContextId, out contextLifetimeScope);
            return contextLifetimeScope;
        }
    }
}