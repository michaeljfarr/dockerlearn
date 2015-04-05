using Castle.Windsor;
using Microsoft.Framework.DependencyInjection;

namespace Herolab.WebAPI
{
    public class WindsorServiceScopeFactory : IServiceScopeFactory
    {
        private readonly IWindsorContainer _container;

        public WindsorServiceScopeFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public IServiceScope CreateScope()
        {
            return new Asp5RequestServiceScope(_container);
        }
    }
}