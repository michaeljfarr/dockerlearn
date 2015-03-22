using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel;
using Castle.Windsor;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.OptionsModel;
using NUnit.Framework;

namespace Herolab.WebAPI
{

    public class WindsorServiceProvider : IServiceProvider, IDisposable
    {
        private readonly IKernelInternal kernel;
        private List<Type> _nullSingletons = new List<Type>();
        private ManualLifetimeScope _manualWindsorScope;
        public WindsorServiceProvider(IWindsorContainer container)
        {
            _manualWindsorScope = new ManualLifetimeScope(container);
            kernel = container.Kernel as IKernelInternal;
            if (kernel == null)
            {
                throw new ArgumentException(string.Format("The kernel must implement {0}", typeof (IKernelInternal)));
            }
        }

        public IKernel Kernel
        {
            get { return kernel; }
        }

        public void RegisterNullType(Type serviceType)
        {
            _nullSingletons.Add(serviceType);
        }

        public object GetService(Type serviceType)
        {
            
            if (_nullSingletons.Any(a=>a == serviceType))
            {
                return null;
            }
            if (kernel.LoadHandlerByType(null, serviceType, null) != null)
            {
                SetCurrentScope();
                try
                {
                    return kernel.Resolve(serviceType);
                }
                finally
                {
                    ResetCurrentScope();
                }
                
            }
            return null;
        }

        public T GetService<T>() where T : class
        {
            return (T) GetService(typeof (T));
        }

        public void SetCurrentScope()
        {
            ManualLifetimeScope.SetCurrentScope(_manualWindsorScope);
        }
        public void ResetCurrentScope()
        {
            ManualLifetimeScope.SetCurrentScope(null);
        }


        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            if (_manualWindsorScope!=null)
            {
                _manualWindsorScope.Dispose();
                _manualWindsorScope = null;
            }
        }
    }
}