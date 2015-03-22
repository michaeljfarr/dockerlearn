using System;
using Herolab.WebAPI.Config;
using Castle.Windsor;
using NUnit.Framework;
using Castle.MicroKernel.Registration;


namespace Herolab.WebAPI.CommandLine
{
    public class Program
    {
        public void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<TestWindsorServiceScope.Root1>().ImplementedBy<TestWindsorServiceScope.Root1>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<TestWindsorServiceScope.Root2>().ImplementedBy<TestWindsorServiceScope.Root2>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<TestWindsorServiceScope.SharedLevel1>().ImplementedBy<TestWindsorServiceScope.SharedLevel1>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<TestWindsorServiceScope.SharedLevel2>().ImplementedBy<TestWindsorServiceScope.SharedLevel2>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<TestWindsorServiceScope.UnSharedLevel1>().ImplementedBy<TestWindsorServiceScope.UnSharedLevel1>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<TestWindsorServiceScope.UnSharedLevel2>().ImplementedBy<TestWindsorServiceScope.UnSharedLevel2>().LifestyleTransient());

            var serviceScopeFactory = new WindsorServiceScopeFactory(container);
            var scope1 = serviceScopeFactory.CreateScope();
            var scope2 = serviceScopeFactory.CreateScope();
            var root1_1_1 = scope1.ServiceProvider.GetService(typeof(TestWindsorServiceScope.Root1));
            var root1_1_2 = scope1.ServiceProvider.GetService(typeof(TestWindsorServiceScope.Root1));
            Assert.That(root1_1_1, Is.SameAs(root1_1_2));
            var root1_2_1 = scope2.ServiceProvider.GetService(typeof(TestWindsorServiceScope.Root1));
            var root1_2_2 = scope2.ServiceProvider.GetService(typeof(TestWindsorServiceScope.Root1));
            Assert.That(root1_2_1, Is.SameAs(root1_2_2));
            Assert.That(root1_2_1, Is.Not.SameAs(root1_1_2));


            //now check disposal
        }
    }
}
