using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Umbraco.Core;
using Umbraco.Core.Configuration;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.Mappers;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;
using Umbraco.Core.Persistence.UnitOfWork;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;
using Umbraco.Core.Strings;

namespace Herolab.Umbraco
{
    public class ContentServer : IContentServer
    {
        public static readonly Type ServiceContextType = typeof(ServiceContext);

        public const string UmbracoConnectionString =
            "Server=mysql.local;Port=3306;Database=umbracodb;Uid=umbraco;Pwd=fDP1weZqgdlM;";

        public const string Provider = "MySql.Data.MySqlClient";
        private ServiceContext _serviceContext;
        private ApplicationContext _applicationContext;
        public static T Create<T>(Type type, params object[] args)
        {
            return (T)Activator.CreateInstance(type, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, args, null);
        }

        public void Init(String rootPath)
        {
            if (String.IsNullOrEmpty(rootPath))
            {
                throw new ApplicationException("Root path is null.");
            }
            if (!System.IO.Directory.Exists(rootPath))
            {
                throw new ApplicationException(string.Format("Root path {0} doesn't exist.", rootPath));
            }
            var pluginDir = System.IO.Path.Combine(rootPath, "App_Data/TEMP/PluginCache");
            if (!System.IO.Directory.Exists(pluginDir))
            {
                throw new ApplicationException(string.Format("Plugin path {0} doesn't exist. Root was {1}", pluginDir, rootPath));
            }
            //var cacheHelper = CacheHelper.CreateDisabledCacheHelper().(
            //new ObjectCacheRuntimeCacheProvider(),
            //new StaticCacheProvider(),
            ////we have no request based cache when not running in web-based context
            //new NullCacheProvider());
            var cacheHelper = CacheHelper.CreateDisabledCacheHelper();
            var RepositoryResolverType = ServiceContextType.Assembly.GetType("Umbraco.Core.Persistence.RepositoryResolver");


            //(true, IUmbracoSettingsSection settings)

            //var repositoryResolver = Create<object>(RepositoryResolverType, new UmbracoSettings());
            //RepositoryResolverType.InvokeMember("Current",
            //    BindingFlags.Static | BindingFlags.SetProperty | BindingFlags.NonPublic, null, null,
            //    new object[] {null});

            var dbFactory = new DefaultDatabaseFactory(UmbracoConnectionString, Provider);
            Database.Mapper = new PetaPocoMapper();
            var dbContext = new DatabaseContext(dbFactory);
            typeof(DatabaseContext).InvokeMember("_providerName",
                BindingFlags.SetField | BindingFlags.Instance | BindingFlags.NonPublic, null, dbContext,
                new object[] { Provider });

            SqlSyntaxContext.SqlSyntaxProvider = new MySqlSyntaxProvider();
            var petaPocoUnitOfWorkProvider = new PetaPocoUnitOfWorkProvider(dbFactory);
            _serviceContext = Create<ServiceContext>(ServiceContextType,
                new object[]
                {
                    petaPocoUnitOfWorkProvider,
                    new FileUnitOfWorkProvider(),
                    new PublishingStrategy(),
                    cacheHelper
                });
            var settings = new UmbracoSettings();
            var respositoryFactory = Create<RepositoryFactory>(typeof(RepositoryFactory), true, settings);

            var config = global::Umbraco.Core.Configuration.UmbracoConfig.For;
            var umbracoSettingsProp = typeof(global::Umbraco.Core.Configuration.UmbracoConfig).GetField("_umbracoSettings", BindingFlags.NonPublic | BindingFlags.Instance);
            umbracoSettingsProp.SetValue(config, settings);

            var restAPIApplication = RestAPIApplication.GetApplication(rootPath);
            var bootManager = new RestAPIBootManager(restAPIApplication, new Type[0], new Type[0], rootPath);
            bootManager.InitResolvers(dbContext, _serviceContext);


            var userService = Create<UserService>(typeof(UserService), petaPocoUnitOfWorkProvider, respositoryFactory);
            var db = dbContext.Database;
            //create the ApplicationContext
            _applicationContext = new ApplicationContext(dbContext, _serviceContext, cacheHelper);
            db.CreateDatabaseSchema(false);
            var stringHelper = Create<IShortStringHelper>(GetUmbracoType("Umbraco.Core.Strings.LegacyShortStringHelper"));
            GetUmbracoType("Umbraco.Core.StringExtensions").InvokeMember("_helper", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.SetField, null, null, new[] { stringHelper });

            var resolutionType = GetUmbracoType("Umbraco.Core.ObjectResolution.Resolution");
            resolutionType.InvokeMember("Freeze", BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public, null, null, null);


            var admin = userService.GetUserById(0);
            if (admin == null)
            {
                throw new InvalidOperationException("Could not find the admin user!");
            }
            admin.RawPasswordValue = "Password";//see membership providers in web.config to see that the password format is "Clear"
            userService.Save(admin);
            db.CloseSharedConnection();
            var currentApplicationContextProperty = typeof(ApplicationContext).GetProperties().First(a => a.Name == "Current");
            currentApplicationContextProperty.SetValue(null, _applicationContext);
            var dbc = _applicationContext.DatabaseContext;

            var currentContext = global::Umbraco.Core.ApplicationContext.Current;
            //global::Umbraco.Core.ApplicationContext.Current = new ApplicationContext();

            //var migratonResolverType = GetUmbracoType("Umbraco.Core.Persistence.Migrations.MigrationResolver");
            //var migratonResolverCurrentProperty = migratonResolverType.BaseType.BaseType.BaseType.GetProperties().First(a => a.Name == "Current");


            ////RepositoryResolver.Current = new RepositoryResolver(new RepositoryFactory(cacheHelper));
            //var repositoryResolverType = GetUmbracoType("Umbraco.Core.Persistence.RepositoryResolver");
            //var repositoryResolverCurrentProperty = repositoryResolverType.BaseType.BaseType.GetProperties().First(a => a.Name == "Current");
            //var repositoryResolver = Create<object>(repositoryResolverType, respositoryFactory);
            //repositoryResolverCurrentProperty.SetValue(null, repositoryResolver);

            //AssemblySearcher searcher = (AssemblySearcher)NewAppDomain.CreateInstanceAndUnwrap(typeof (AssemblySearcher).Assembly.GetName().FullName, typeof (AssemblySearcher).Name);
            //var typeNames = searcher.PrintDomain(typeof(ApplicationContext).Assembly.GetName().FullName);
            //var migrationType = typeof(IMigration);
            //var types =
            //    GetTypesLoaded(typeof(ApplicationContext).Assembly).Where(a => migrationType.IsAssignableFrom(a))
            //        .Where(t => IsNonStaticClass(t) && !t.IsNestedPrivate && !t.IsAbstract && ((MemberInfo)t).GetCustomAttribute<HideFromTypeFinderAttribute>() == null).ToArray();

            //var migrationResolver = Create<object>(migratonResolverType, (Func<IEnumerable<Type>>)(() => types));// PluginManager.Current.ResolveTypes<IMigration>()));
            //migratonResolverCurrentProperty.SetValue(null, migrationResolver);


            var runner = new MigrationRunner(UmbracoVersion.Current, UmbracoVersion.Current, "Umbraco");
            var upgraded = runner.Execute(db, true);

            //admin.Email = user.Email.Trim();
            //admin.Name = user.Name.Trim();
            //admin.Username = user.Email.Trim();

            userService.Save(admin);
        }

        public System.String GetObject()
        {
            var level0 = _applicationContext.Services.ContentService.GetByLevel(0).ToList();
            var level1 = _applicationContext.Services.ContentService.GetByLevel(1).First();
            var x = level1.Properties[2];
            var id = x.Id;
            var mediaEx = _applicationContext.Services.MediaService.GetById(id);
            return level1.Name;
        }

        public static bool IsNonStaticClass(Type t)
        {
            if (t.IsClass)
                return !IsStaticClass(t);
            return false;
        }

        public static bool IsStaticClass(Type type)
        {
            if (type.IsAbstract)
                return type.IsSealed;
            return false;
        }
        public static Type[] GetTypesLoaded(Assembly assembly)
        {
            Type[] types;
            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null).ToArray();
            }

            return types;
        }

        private Assembly CurrentDomain_TypeResolve1(object sender, ResolveEventArgs args)
        {
            return null;
        }

        public class AssemblySearcher : MarshalByRefObject
        {
            public String[] PrintDomain(String fullname)
            {
                var assembly = Assembly.ReflectionOnlyLoad(fullname);
                var types = assembly.GetExportedTypes();
                return types.Select(a => a.FullName).ToArray();
            }
        }


        private Assembly CurrentDomain_TypeResolve(object sender, ResolveEventArgs args)
        {
            return null;
        }

        static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return System.Reflection.Assembly.ReflectionOnlyLoadFrom(String.Format("file:///C:/Users/Michael/.k/packages/UmbracoCms.Core/7.2.4/lib/{0}.dll", args.Name.Split(',')[0].Trim()));
            //return null;
        }

        private static Type GetUmbracoType(string typeName)
        {
            return typeof(ServiceContext).Assembly.GetType(typeName);
        }

        protected internal static string GenerateSalt()
        {
            var numArray = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(numArray);
            return Convert.ToBase64String(numArray);
        }

    }
}