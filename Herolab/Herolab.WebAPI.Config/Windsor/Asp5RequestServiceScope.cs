using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Microsoft.Framework.DependencyInjection;

namespace Herolab.WebAPI
{
    public class Asp5RequestServiceScope : IServiceScope
    {
        private readonly IWindsorContainer _container;
        private readonly WindsorServiceProvider _serviceProvider;

        public Asp5RequestServiceScope(IWindsorContainer container)
        {
            _container = container;

            _serviceProvider = new WindsorServiceProvider(_container);
        }

        public object GetService(Type serviceType)
        {
            //this thread can only be used for resolving this 
            //lock (_aspNetRequestMarker)
            {
                _serviceProvider.SetCurrentScope();
                try
                {
                    return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
                }
                finally
                {
                    _serviceProvider.ResetCurrentScope();
                }
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            //_serviceProvider uses threadstatic variable, so cant be called twice at the same time from same thread.
            //lock (_aspNetRequestMarker)
            {
                _serviceProvider.SetCurrentScope();
                try
                {
                    return _container.ResolveAll(serviceType).Cast<object>();
                }
                finally
                {
                    _serviceProvider.ResetCurrentScope();
                }
            }
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }

        public IServiceProvider ServiceProvider => _serviceProvider;
    }
}