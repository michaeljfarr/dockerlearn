using System.Reflection;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.UnitOfWork;
using Umbraco.Core.Services;

namespace Herolab.Umbraco
{
    /// <summary>
    /// Represents a Unit of Work Provider for creating a <see cref="PetaPocoUnitOfWork"/>
    /// </summary>
    public class PetaPocoUnitOfWorkProvider : IDatabaseUnitOfWorkProvider
    {
        private readonly IDatabaseFactory _dbFactory;

        /// <summary>
        /// Constructor accepting an IDatabaseFactory instance
        /// </summary>
        /// <param name="dbFactory"></param>
        internal PetaPocoUnitOfWorkProvider(IDatabaseFactory dbFactory)
        {
            Mandate.ParameterNotNull(dbFactory, "dbFactory");
            _dbFactory = dbFactory;
        }

        #region Implementation of IUnitOfWorkProvider

        /// <summary>
        /// Creates a Unit of work with a new UmbracoDatabase instance for the work item/transaction.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Each PetaPoco UOW uses it's own Database object, not the shared Database object that comes from
        /// the ApplicationContext.Current.DatabaseContext.Database. This is because each transaction should use it's own Database
        /// and we Dispose of this Database object when the UOW is disposed.
        /// </remarks>
        public IDatabaseUnitOfWork GetUnitOfWork()
        {
            //return new PetaPocoUnitOfWork(_dbFactory.CreateDatabase());
            Assembly sysData = typeof(ServiceContext).Assembly;
            var petaPocoUnitOfWorkType = sysData.GetType("Umbraco.Core.Persistence.UnitOfWork.PetaPocoUnitOfWork");
            var item = ContentServer.Create<IDatabaseUnitOfWork>(petaPocoUnitOfWorkType, _dbFactory.CreateDatabase());
            return item;
        }

        #endregion
    }
}