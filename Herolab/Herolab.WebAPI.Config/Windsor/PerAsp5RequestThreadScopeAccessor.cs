using System;
using System.Linq;
using Castle.Core.Internal;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle.Scoped;

namespace Herolab.WebAPI
{
    /// <summary>
    /// Each component with the PerAsp5Request lifestyle will get its own instance of PerAsp5RequestScopeAccessor
    /// </summary>
    [Serializable]
    public class PerAsp5RequestThreadScopeAccessor : IScopeAccessor
    {
        private readonly SimpleThreadSafeDictionary<int, ILifetimeScope> items =
            new SimpleThreadSafeDictionary<int, ILifetimeScope>();

        public void Dispose()
        {
            var values = items.EjectAllValues();
            foreach (var item in values.Reverse())
            {
                item.Dispose();
            }
        }

        public ILifetimeScope GetScope(CreationContext context)
        {
            var currentScope = ManualLifetimeScope.ObtainCurrentScope();
            if (currentScope == null)
            {
                //note, this is because the scope was not set by Asp5RequestServiceScope, or an equivalent system that uses a ManualLifetimeScope
            }
            return currentScope;

        }

    }
}