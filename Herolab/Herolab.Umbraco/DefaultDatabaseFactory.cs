using System;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace Herolab.Umbraco
{
    internal class DefaultDatabaseFactory : DisposableObject, IDatabaseFactory
    {
        private readonly string _connectionStringName;
        public string ConnectionString { get; private set; }
        public string ProviderName { get; private set; }

        //very important to have ThreadStatic:
        // see: http://issues.umbraco.org/issue/U4-2172
        [ThreadStatic]
        private static volatile UmbracoDatabase _nonHttpInstance;

        private static readonly object Locker = new object();


        /// <summary>
        /// Constructor accepting custom connection string
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string in web.config</param>
        public DefaultDatabaseFactory(string connectionStringName)
        {
            Mandate.ParameterNotNullOrEmpty(connectionStringName, "connectionStringName");
            _connectionStringName = connectionStringName;
        }

        /// <summary>
        /// Constructor accepting custom connectino string and provider name
        /// </summary>
        /// <param name="connectionString">Connection String to use with Database</param>
        /// <param name="providerName">Database Provider for the Connection String</param>
        public DefaultDatabaseFactory(string connectionString, string providerName)
        {
            Mandate.ParameterNotNullOrEmpty(connectionString, "connectionString");
            Mandate.ParameterNotNullOrEmpty(providerName, "providerName");
            ConnectionString = connectionString;
            ProviderName = providerName;
        }

        public UmbracoDatabase CreateDatabase()
        {
            if (_nonHttpInstance == null)
            {
                lock (Locker)
                {
                    //double check
                    if (_nonHttpInstance == null)
                    {
                        _nonHttpInstance = string.IsNullOrEmpty(ConnectionString) == false &&
                                           string.IsNullOrEmpty(ProviderName) == false
                            ? new UmbracoDatabase(ConnectionString, ProviderName)
                            : new UmbracoDatabase(_connectionStringName);
                    }
                }
            }
            return _nonHttpInstance;
        }

        protected override void DisposeResources()
        {
            if (_nonHttpInstance != null)
            {
                _nonHttpInstance.Dispose();
                _nonHttpInstance = null;
            }
        }
    }
}