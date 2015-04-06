using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Security;
using Microsoft.AspNet.Mvc;
using System.Security.Claims;
using Castle.Windsor;
using Herolab.WebAPI.Config.Autofac;
using Autofac;
using Herolab.Umbraco;
using Microsoft.IdentityModel.Protocols;
using Umbraco.Core.Services;

namespace Herolab.WebAPI
{
    public class Startup
    {
        private readonly Configuration _configuration = new Configuration();

        public Startup(IHostingEnvironment env)
        {

        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var mysqlFactoryTypeName = typeof(MySql.Data.MySqlClient.MySqlClientFactory).AssemblyQualifiedName;
            RegisterDbProvider("MySql.Data.MySqlClient", ".Net Framework Data Provider for MySQL",
                "MySQL Data Provider",
                mysqlFactoryTypeName);//"MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, PublicKeyToken=c5687fc88969c44d");  
            var factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");

            services.AddMvc();
            services.AddDataProtection();


            //AddAuthorization adds the following IAuthorizationService implementatinons:
            //TryAdd:DefaultAuthorizationService, Add:ClaimsAuthorizationHandler, Add:DenyAnonymousAuthorizationHandler, Add:PassThroughAuthorizationHandler

            services.AddAuthorization(_configuration, a =>
            {
                //Policy during a request is determined by the AuthorizationPolicyBuilder.  It uses the Microsoft.AspNet.Mvc.Authorize attribute to
                //determine the policy name and claim values that should be provided to the IAuthorizationRequirement instances. Each IAuthorizationRequirement
                //must have a corresponding AuthorizationHandler<T> registered, where T is the type of AuthorizationRequirement.  

                //Policies can be combine themselves with another policy set so that both sets of requrements are enforced.  I to handle either/or or inverse
                //policy rules you need to build a IAuthorizationRequirement/AuthorizationHandler pair.
                a.AddPolicy("MasterOrPinAuthCode", b =>
                {
                    //A role is the claim value of a claim with Type=Role.
                    b.AddRequirements(new OneOfManyClaimsAuthorizationRequirement(new Claim("Master", "Master"), new Claim("PinAuthCode", "PinAuthCode")));
                    b.AddRequirements(new NoneOneOfTheseClaimsAuthorizationRequirement(new Claim("LowPriv", "")));
                    b.RequireAuthenticatedUser();
                });

                a.AddPolicy("Master", b =>
                {
                    b.Combine(a.GetPolicy("MasterOrPinAuthCode"));
                    b.RequiresClaim("Master");
                });


                a.AddPolicy("PinAuthCode", b =>
                {
                    b.Combine(a.GetPolicy("MasterOrPinAuthCode"));
                    b.RequiresClaim("PinAuthCode");
                });

                a.AddPolicy("LowPriv", b =>
                {
                    b.RequireAuthenticatedUser();
                });

                a.AddPolicy("Elevated", b =>
                {
                    b.AddRequirements(new NoneOneOfTheseClaimsAuthorizationRequirement(new Claim("LowPriv", "")));
                    b.RequiresClaim("Elevated");
                });

            });

            var containerBuilder = new Autofac.ContainerBuilder();
            //var windsorContainer = new WindsorContainer();
            //WindsorRegistration.Populate(windsorContainer, services);
            //return windsorContainer.Resolve<IServiceProvider>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            var workingDir = Environment.GetEnvironmentVariable("HerolabWorkingDirectory");
            if(String.IsNullOrWhiteSpace(workingDir))
            {
                throw new ApplicationException("workingDir is null");
            }
            if (workingDir != null && Directory.Exists(workingDir))
            {
                System.Console.WriteLine("workingDir="  + workingDir);
                var pluginDir = System.IO.Path.Combine(workingDir, "App_Data/TEMP/PluginCache");
                if(!Directory.Exists(pluginDir))
                    Directory.CreateDirectory(pluginDir);
                System.Console.WriteLine("PluginCacheDir="  + pluginDir);
                pluginDir = System.IO.Path.Combine(workingDir, "App_Plugins");
                if (!Directory.Exists(pluginDir))
                    Directory.CreateDirectory(pluginDir);
                System.Console.WriteLine("pluginDir="  + pluginDir);
                pluginDir = System.IO.Path.Combine(workingDir, "App_Plugins");
                if (!Directory.Exists("~/App_Plugins"))
                    Directory.CreateDirectory("~/App_Plugins");
                System.Console.WriteLine("pluginDir=" + Path.GetFullPath("~/App_Plugins"));

                
            }
            //.Instance
            container.Resolve<IContentServer>().Init(workingDir);
            container.Resolve<IContentServer>().GetObject();
            return container.Resolve<IServiceProvider>();
        }

        public bool RegisterDbProvider(string invariant, string description, string name, string type)
        {
            DataSet ds = System.Configuration.ConfigurationManager.GetSection("system.data") as DataSet;
            if (!ds.Tables[0].Rows.Cast<DataRow>().Select(a => a[0]).Any(a => (String)a == name))
            {
                ds.Tables[0].Rows.Add(name, description, invariant, type);            //mono implementation
                var providerTableField = typeof(DbProviderFactories).GetField("configEntries",
                    BindingFlags.Static | BindingFlags.NonPublic);
                providerTableField?.SetValue(null, ds);
            }

            return true;
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
            //app.ConfigureOAuthBearerAuthentication(a=> a.);
            app.UseOAuthBearerAuthentication(a => 
            {
                a.AuthenticationMode = AuthenticationMode.Active;
                a.Notifications.ApplyChallenge = AuthenticationNotificationHandler.OnApplyChallenge;
                a.Notifications.AuthenticationFailed = AuthenticationNotificationHandler.OnAuthenticationFailed;
                a.Notifications.MessageReceived = AuthenticationNotificationHandler.OnMessageReceived;
                a.Notifications.SecurityTokenReceived = AuthenticationNotificationHandler.OnSecurityTokenReceived;
                a.Notifications.SecurityTokenValidated = AuthenticationNotificationHandler.OnSecurityTokenValidated;

            });
        }
        
    }    
}
