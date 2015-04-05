using System;
using System.Collections.Generic;
using umbraco.interfaces;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace Herolab.Umbraco
{
    internal class RestAPIBootManager : CoreBootManager
    {
        private readonly IEnumerable<Type> _handlersToAdd;
        private readonly IEnumerable<Type> _handlersToRemove;
        private readonly string _baseDirectory;

        public RestAPIBootManager(UmbracoApplicationBase umbracoApplication, IEnumerable<Type> handlersToAdd, IEnumerable<Type> handlersToRemove, string baseDirectory)
            : base(umbracoApplication)
        {
            _handlersToAdd = handlersToAdd;
            _handlersToRemove = handlersToRemove;
            _baseDirectory = baseDirectory;

            base.InitializeApplicationRootPath(_baseDirectory);

            // this is only here to ensure references to the assemblies needed for
            // the DataTypesResolver otherwise they won't be loaded into the AppDomain.
            var interfacesAssemblyName = typeof(IDataType).Assembly.FullName;
        }

        protected override void InitializeApplicationEventsResolver()
        {
            base.InitializeApplicationEventsResolver();

        }

        protected override void InitializeResolvers()
        {
            base.InitializeResolvers();

            //Mappers are not resolved, which could be because of a known TypeMapper issue
            /*MappingResolver.Reset();
            MappingResolver.Current = new MappingResolver(
                () =>
                new List<Type>
                    {
                        typeof (ContentMapper),
                        typeof (ContentTypeMapper),
                        typeof (MediaMapper),
                        typeof (MediaTypeMapper),
                        typeof (DataTypeDefinitionMapper),
                        typeof (UmbracoEntityMapper)
                    });*/
        }

        public void InitResolvers(DatabaseContext dbContext, ServiceContext serviceContext)
        {
            CreateApplicationCache();
            this.CreateApplicationContext(dbContext, serviceContext);
            this.InitializeApplicationEventsResolver();
            this.InitializeResolvers();
            this.InitializeModelMappers();
        }
    }
}