using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.OptionsModel;

namespace Herolab.WebAPI
{
    public static class WindsorRegistration
    {
        public static void Populate(
            this IWindsorContainer builder,
            IEnumerable<IServiceDescriptor> descriptors)
        {
            builder.Register(
                Component.For<IWindsorContainer>().Instance(builder));
            builder.Register(
                Component.For<IServiceProvider>().ImplementedBy<WindsorServiceProvider>().LifestyleSingleton());
            builder.Register(
                Component.For<IServiceScopeFactory>().ImplementedBy<WindsorServiceScopeFactory>().LifestyleSingleton());

            Register(builder, descriptors);
        }

        private static void Register(
            IWindsorContainer builder,
            IEnumerable<IServiceDescriptor> descriptors)
        {
            var windsorServiceProvider = (WindsorServiceProvider) builder.Resolve<IServiceProvider>();
            
            //there seem to be duplicates in the list, so take the last one specified for now until we figure out what is going on
            var backwardDescriptors = descriptors.Reverse().ToList();
            var routeOptions = new List<IConfigureOptions<RouteOptions>>();
            builder.Register(Component.For<IEnumerable<IConfigureOptions<RouteOptions>>>().Instance(routeOptions));
            
            foreach (var descriptor in backwardDescriptors)
            {
                if (!builder.Kernel.HasComponent(descriptor.ServiceType))
                {
                    if (descriptor.ImplementationType != null)
                    {
                        builder.Register(Component.For(descriptor.ServiceType)
                            .ImplementedBy(descriptor.ImplementationType).
                            ConfigureLifecycle(descriptor.Lifecycle));
                    }
                    else if (descriptor.ImplementationFactory != null)
                    {
                        var descriptor1 = descriptor;
                        builder.Register(Component.For(descriptor.ServiceType).UsingFactoryMethod(
                            kernel =>
                            {
                                var serviceProvider = kernel.Resolve<IServiceProvider>();
                                return descriptor1.ImplementationFactory(serviceProvider);
                            }).ConfigureLifecycle(descriptor1.Lifecycle));
                    }
                    else if(descriptor.ImplementationInstance!=null)
                    {
                        builder.Register(
                            Component.For(descriptor.ServiceType)
                                .Instance(descriptor.ImplementationInstance)
                                .ConfigureLifecycle(descriptor.Lifecycle));
                        var test = builder.Resolve(descriptor.ServiceType);
                        if (test != null)
                        {
                            
                        }
                    }
                    else
                    {
                        windsorServiceProvider.RegisterNullType(descriptor.ServiceType);
                        var descriptor1 = descriptor;
                        builder.Register(Component.For(descriptor.ServiceType).UsingFactoryMethod(
                            kernel =>
                            {
                                return (object)null;
                            }).ConfigureLifecycle(descriptor1.Lifecycle));
                    }
                }
            }
        }

        private static ComponentRegistration<object> ConfigureLifecycle(
            this ComponentRegistration<object> registrationBuilder, LifecycleKind lifecycleKind)
        {
            switch (lifecycleKind)
            {
                case LifecycleKind.Singleton:
                    return registrationBuilder.LifestyleSingleton();
                case LifecycleKind.Scoped:
                    return registrationBuilder.LifestyleScoped<PerAsp5RequestThreadScopeAccessor>();
                    //return registrationBuilder.LifestyleScoped();
                case LifecycleKind.Transient:
                    return registrationBuilder.LifestyleTransient();
            }

            throw new NotImplementedException(string.Format("unsupported lifecycle: {0}", lifecycleKind));
        }
}
}