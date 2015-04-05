using System;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using NUnit.Framework;

namespace Herolab.WebAPI.Config
{
    [TestFixture]
    public class TestWindsorServiceScope
    {
        [Test]
        public void Test1()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<Root1>().ImplementedBy<Root1>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<Root2>().ImplementedBy<Root2>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<SharedLevel1>().ImplementedBy<SharedLevel1>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<SharedLevel2>().ImplementedBy<SharedLevel2>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<UnSharedLevel1>().ImplementedBy<UnSharedLevel1>().LifestyleScoped<PerAsp5RequestThreadScopeAccessor>());
            container.Register(Component.For<UnSharedLevel2>().ImplementedBy<UnSharedLevel2>().LifestyleTransient());

            var serviceScopeFactory = new WindsorServiceScopeFactory(container);
            var scope1 = serviceScopeFactory.CreateScope();
            var scope2 = serviceScopeFactory.CreateScope();
            var root1_1_1 = scope1.ServiceProvider.GetService(typeof(Root1));
            var root1_1_2 = scope1.ServiceProvider.GetService(typeof(Root1));
            Assert.That(root1_1_1, Is.SameAs(root1_1_2));
            var root1_2_1 = scope2.ServiceProvider.GetService(typeof(Root1));
            var root1_2_2 = scope2.ServiceProvider.GetService(typeof(Root1));
            Assert.That(root1_2_1, Is.SameAs(root1_2_2));
            Assert.That(root1_2_1, Is.Not.SameAs(root1_1_2));

            var root2_1_1 = scope1.ServiceProvider.GetService(typeof(Root2));
            var root2_1_2 = scope1.ServiceProvider.GetService(typeof(Root2));
            Assert.That(root2_1_1, Is.SameAs(root2_1_2));
            Assert.That(root2_1_1, Is.Not.SameAs(root1_1_1));
            var root2_2_1 = scope2.ServiceProvider.GetService(typeof(Root2));
            var root2_2_2 = scope2.ServiceProvider.GetService(typeof(Root2));
            Assert.That(root2_2_1, Is.SameAs(root2_2_2));
            Assert.That(root2_2_1, Is.Not.SameAs(root2_1_2));
        }

        public class Root1
        {
            public UnSharedLevel1 UnSharedLevel1 { get; set; }

            public Root1(UnSharedLevel1 unSharedLevel1)
            {
                UnSharedLevel1 = unSharedLevel1;
            }
        }
        public class Root2
        {
            public Root2(SharedLevel1 sharedLevel1)
            {
                SharedLevel1 = sharedLevel1;
            }

            public SharedLevel1 SharedLevel1 { get; set; }
        }

        public class SharedLevel1
        {
            public SharedLevel2 SharedLevel2 { get; set; }
            public UnSharedLevel2 UnSharedLevel2 { get; set; }

            public SharedLevel1(SharedLevel2 sharedLevel2, UnSharedLevel2 unSharedLevel2)
            {
                SharedLevel2 = sharedLevel2;
                UnSharedLevel2 = unSharedLevel2;
            }
        }
        public class SharedLevel2
        {

        }
        public class UnSharedLevel2
        {

        }
        public class UnSharedLevel1
        {
            public SharedLevel2 SharedLevel2 { get; set; }
            public UnSharedLevel2 UnSharedLevel2 { get; set; }

            public UnSharedLevel1(SharedLevel2 sharedLevel2, UnSharedLevel2 unSharedLevel2)
            {
                SharedLevel2 = sharedLevel2;
                UnSharedLevel2 = unSharedLevel2;
            }
        }

    }


}
