using System;
using Herolab.WebAPI.Config;
using Castle.Windsor;
using NUnit.Framework;
using Castle.MicroKernel.Registration;
using Herolab.Umbraco;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Reflection;

namespace Herolab.WebAPI.CommandLine
{
    public class Program
    {
        public void Main(string[] args)
        {
            var mysqlFactoryTypeName = typeof(MySql.Data.MySqlClient.MySqlClientFactory).AssemblyQualifiedName;
            RegisterDbProvider("MySql.Data.MySqlClient", ".Net Framework Data Provider for MySQL",
                "MySQL Data Provider",
                mysqlFactoryTypeName);//"MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, PublicKeyToken=c5687fc88969c44d");  
            var factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");

            var workingDir = Environment.GetEnvironmentVariable("HerolabWorkingDirectory");
            if (String.IsNullOrWhiteSpace(workingDir))
            {
                throw new ApplicationException("workingDir is null");
            }
            if (workingDir != null && Directory.Exists(workingDir))
            {
                System.Console.WriteLine("workingDir=" + workingDir);
                var pluginDir = System.IO.Path.Combine(workingDir, "App_Data/TEMP/PluginCache");
                if (!Directory.Exists(pluginDir))
                    Directory.CreateDirectory(pluginDir);
                System.Console.WriteLine("PluginCacheDir=" + pluginDir);
                pluginDir = System.IO.Path.Combine(workingDir, "App_Plugins");
                if (!Directory.Exists(pluginDir))
                    Directory.CreateDirectory(pluginDir);
                System.Console.WriteLine("pluginDir=" + pluginDir);
            }


            ContentServer contentServer = new ContentServer();
            contentServer.Init(workingDir);
            Console.WriteLine("Found content: {0}!", contentServer.GetObject());
        }


        public bool RegisterDbProvider(string invariant, string description, string name, string type)
        {
            DataSet ds = System.Configuration.ConfigurationManager.GetSection("system.data") as DataSet;
            ds.Tables[0].Rows.Add(name, description, invariant, type);
            //mono implementation
            var providerTableField = typeof (DbProviderFactories).GetField("configEntries",
                BindingFlags.Static | BindingFlags.NonPublic);
            providerTableField?.SetValue(null, ds);

            return true;
        }

        public void Test()
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
