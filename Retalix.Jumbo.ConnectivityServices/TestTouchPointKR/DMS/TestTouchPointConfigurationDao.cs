using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Common.Logging;
using Retalix.StoreServices.Model.Infrastructure.DataAccess;
using NHibernate;
using NHibernate.Criterion;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Infrastructure.Cache;
using Retalix.Jumbo.Common.Utils;
using NHibernate.Linq;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.DeleteAllProviders;
using System.Runtime.Caching;

namespace Retalix.Jumbo.ConnectivityServices.TestTouchPointKR.DMS
{
    [RegisterAddition]
    public class TestTouchPointConfigurationDao : ITestTouchPointConfigurationDao
    {
        protected static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private const string TestTouchPointConfigurationKey = "TestTouchPointConfiguration";

        private readonly ISessionProvider _sessionProvider;

        public TestTouchPointConfigurationDao(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        private ISession Session
        {
            get { return _sessionProvider.GetDefaultSession<ISession>(); }
        }

        public void SaveOrUpdate(ITestTouchPointConfiguration testTouchPointConfiguration)
        {
            Session.SaveOrUpdate(testTouchPointConfiguration);
            CleanCache();
        }

        public void Delete(ITestTouchPointConfiguration testTouchPointConfiguration)
        {
            CleanCache();
            var configuration = GetByCriteria(new TestTouchPointConfigurationCriteria
            {
                BusinessUnitId = testTouchPointConfiguration.BusinessUnitId,
                BusinessService = testTouchPointConfiguration.BusinessService,
                EntityParameter = testTouchPointConfiguration.EntityParameter,
                EntityType = testTouchPointConfiguration.EntityType
            });

            if (configuration != null)
            {
                foreach (var item in configuration)
                {
                    Session.Delete(item);
                }
            }
        }

        public IEnumerable<ITestTouchPointConfiguration> GetByCriteria(TestTouchPointConfigurationCriteria searchingCriteria)
        {
            if (searchingCriteria == null)
                return new ITestTouchPointConfiguration[] { };

            var businessService = searchingCriteria.BusinessService;
            var businessUnitId = searchingCriteria.BusinessUnitId;
            var entityParameter = searchingCriteria.EntityParameter;
            var entityType = searchingCriteria.EntityType;

            string cacheKey = string.Format("{0}|{1}|{2}|{3}|{4}", TestTouchPointConfigurationKey, (businessService ?? ""), (businessUnitId ?? ""), (entityParameter ?? ""), (entityType ?? ""));
            return CacheProvider.GetCache().AddOrGetNullable(cacheKey, () => GetByCriteria(businessService, businessUnitId, entityParameter, entityType), new CacheItemPolicy());

        }

        private IEnumerable<ITestTouchPointConfiguration> GetByCriteria(string businessService, string businessUnitId, string entityParameter, string entityType)
        {
            var criteria = Session.CreateCriteria<ITestTouchPointConfiguration>();

            if (!string.IsNullOrEmpty(businessService))
                criteria.Add(Restrictions.Eq("BusinessService", businessService));

            if (!string.IsNullOrEmpty(businessUnitId))
                criteria.Add(Restrictions.Eq("BusinessUnitId", businessUnitId));

            if (!string.IsNullOrEmpty(entityParameter))
                criteria.Add(Restrictions.Eq("EntityParameter", entityParameter));

            if (!string.IsNullOrEmpty(entityType))
                criteria.Add(Restrictions.Eq("EntityType", entityType));

            return criteria.List<ITestTouchPointConfiguration>();
        }

        public List<ITestTouchPointConfiguration> GetAllBusinessServiceForAllBusinessUnitId(TestTouchPointConfigurationCriteria searchingCriteria)
        {
            if (searchingCriteria == null)
                return new List<ITestTouchPointConfiguration>();

            return Session.Query<ITestTouchPointConfiguration>().AsQueryable().ToList();
        }
        public void Add(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("TestTouchPointConfigurationDao.Add enter"));
            try
            {
                foreach (var movable in movables.OfType<ITestTouchPointConfiguration>())
                {
                    SaveOrUpdate(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("TestTouchPointConfigurationDao:Add ", e);
                throw;
            }
        }

        public void Delete(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("TestTouchPointConfigurationDao.Delete enter"));
            try
            {
                foreach (var movable in movables.OfType<ITestTouchPointConfiguration>())
                {
                    Delete(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("TestTouchPointConfigurationDao:Delete ", e);
                throw;
            }

        }

        public void DeleteAll(ITruncateHelperDao truncateHelperDao)
        {
            Log.Info(message => message("TestTouchPointConfigurationDao.DeleteAll enter"));

            try
            {
                truncateHelperDao.TruncateTable("BusinessTouchPointConfiguration");
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("TestTouchPointConfigurationDao:DeleteAll ", e);
                throw;
            }
        }

        public IList<string> GetTableNamesInDependencyOrder()
        {
            return new List<string>
                    {
                        "BusinessTouchPointConfiguration",
                    };
        }

        public IEnumerable<IMovable> GetAll(IMovable startingPosition)
        {
            Log.Info(message => message("TestTouchPointConfigurationDao.GetAll startingPosition enter"));
            var startingAccount = (ITestTouchPointConfiguration)startingPosition;
            var accounts = GetAll().OfType<ITestTouchPointConfiguration>().ToList();
            var filteredAccounts = new List<ITestTouchPointConfiguration>();
            var foundStartingAccount = false;
            for (var i = 0; i < accounts.Count(); i++)
            {
                if (foundStartingAccount)
                {
                    filteredAccounts.Add(accounts[i]);
                }
                else if (accounts[i].BusinessUnitId.Equals(startingAccount.BusinessUnitId) &&
                         accounts[i].EntityType.Equals(startingAccount.EntityType) &&
                         accounts[i].EntityParameter.Equals(startingAccount.EntityParameter)
                    )
                {
                    foundStartingAccount = true;
                }
            }

            return filteredAccounts;
        }

        public IEnumerable<IMovable> GetAll()
        {
            Log.Info(message => message("TestTouchPointConfigurationDao.GetAll enter"));
            return Session.QueryOver<ITestTouchPointConfiguration>().List();
        }

        public void Update(IEnumerable<IMovable> movables)
        {
            Log.Info(message => message("Entering PromotionalPriceDao: Executing SaveOrUpdateWithPriceStatusCalculation"));
            try
            {
                foreach (var movable in movables.OfType<ITestTouchPointConfiguration>())
                {
                    SaveOrUpdate(movable);
                }
                CleanCache();
            }
            catch (Exception e)
            {
                Log.Error("TestTouchPointConfigurationDao:Update ", e);
                throw;
            }
        }

        private static void CleanCache()
        {
            CacheProvider.GetCache().CleanCache(TestTouchPointConfigurationKey);
        }
    }
}
