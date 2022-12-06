using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;
using Retalix.StoreServices.Model.Organization.BusinessUnit;

namespace Retalix.Jumbo.BusinessComponents.TestTouchPointKR.TestTouchPointConfiguration
{
    [RegisterAddition("TestTouchPointConfigurationProvider")]
    public class TestTouchPointConfigurationProvider : ITestTouchPointConfigurationProvider
    {
        private readonly ITestTouchPointConfigurationDao _testTouchPointConfigurationDao;
        private readonly IStoreNetRequest _storeNetRequest;
        private readonly IBusinessUnitDao _businessUnitDao;
        private readonly ILog _logger;

        public TestTouchPointConfigurationProvider(
            ITestTouchPointConfigurationDao testTouchPointConfigurationDao, IStoreNetRequest storeNetRequest,
            IBusinessUnitDao businessUnitDao)
        {
            _testTouchPointConfigurationDao = testTouchPointConfigurationDao;
            _logger = LogManager.GetCurrentClassLogger();
            _businessUnitDao = businessUnitDao;
            _storeNetRequest = storeNetRequest;
        }

        public IEnumerable<ITestTouchPointConfiguration> GetTouchpointConfigurations(TestTouchPointConfigurationCriteria criteria)
        {
            if (criteria.BusinessService == null && criteria.EntityParameter == null && criteria.EntityType == null)
            {
                var businessUnit = GetBusinessUnit(criteria.BusinessUnitId);
                return GetAllTouchpointConfigurationsIncludingFromParents(criteria, businessUnit);
            }
            else
            {
                var businessUnit = GetBusinessUnit(criteria.BusinessUnitId);
                return GetTouchpointConfigurationsFromParent(criteria, businessUnit);
            }
        }

        private IBusinessUnit GetBusinessUnit(string businessUnitId)
        {
            var businessUnit = _storeNetRequest.BusinessUnit; // for POS request
            return businessUnit ?? _businessUnitDao.Get(businessUnitId); // for Office request 
        }

        private IEnumerable<ITestTouchPointConfiguration> GetTouchpointConfigurationsFromParent(
            TestTouchPointConfigurationCriteria criteria, IBusinessUnit businessUnit)
        {
            IEnumerable<ITestTouchPointConfiguration> touchpointConfigurations = new List<ITestTouchPointConfiguration> { };

            while (businessUnit != null)
            {
                criteria.BusinessUnitId = businessUnit.Id;
                touchpointConfigurations = _testTouchPointConfigurationDao.GetByCriteria(criteria);

                if (touchpointConfigurations.Any())
                    return touchpointConfigurations;

                businessUnit = businessUnit.ParentUnit;
            }

            _logger.Debug(string.Format("Business TouchPoint Configuration was not found for criteria - BusinessUnitId: {0}, EntityType: {1}, EntityParameter:{2}; null returned", criteria.BusinessUnitId, criteria.EntityType, criteria.EntityParameter));
            return touchpointConfigurations;
        }

        private IEnumerable<ITestTouchPointConfiguration> GetAllTouchpointConfigurationsIncludingFromParents(TestTouchPointConfigurationCriteria criteria, IBusinessUnit businessUnit)
        {
            TestTouchPointConfigurationCriteria TestTouchPointConfigurationCriteira = new TestTouchPointConfigurationCriteria
            {
                EntityParameter = criteria.EntityParameter,
                EntityType = criteria.EntityType
            };
            List<ITestTouchPointConfiguration> allTouchpointConfigurations = _testTouchPointConfigurationDao.GetAllBusinessServiceForAllBusinessUnitId(TestTouchPointConfigurationCriteira);

            List<ITestTouchPointConfiguration> touchpointConfigurations = new List<ITestTouchPointConfiguration>();

            while (businessUnit != null)
            {
                List<ITestTouchPointConfiguration> businessUnitList = allTouchpointConfigurations.Where(o => o.BusinessUnitId == businessUnit.Id).ToList();

                businessUnitList.ForEach(configuration => AddTouchPointConfigurationToFinalList(touchpointConfigurations, configuration));

                businessUnit = businessUnit.ParentUnit;
            }

            return touchpointConfigurations;
        }

        private static void AddTouchPointConfigurationToFinalList(List<ITestTouchPointConfiguration> touchpointConfigurations,
            ITestTouchPointConfiguration businessTouchPointConfiguration)
        {
            if (touchpointConfigurations.Any(o => o.BusinessService == businessTouchPointConfiguration.BusinessService
                && o.EntityParameter == businessTouchPointConfiguration.EntityParameter && o.EntityType == businessTouchPointConfiguration.EntityType)) return;

            touchpointConfigurations.Add(businessTouchPointConfiguration);
        }

        public string GetTouchpointConfiguration(string businessUnitId, string businessServiceType, string entityTypeType, string entityParameterType)
        {
            TestTouchPointConfigurationCriteria criteria = BuildCriteria(businessUnitId, businessServiceType.ToString(), entityTypeType.ToString(), entityParameterType.ToString());
            return GetTouchpointConfigurationValue(criteria);
        }

        private string GetTouchpointConfigurationValue(TestTouchPointConfigurationCriteria criteria)
        {
            var touchpointConfigurations = GetTouchpointConfigurations(criteria);
            if (touchpointConfigurations == null || !touchpointConfigurations.Any())
            {
                //throw new TouchpointConfigurationNotFoundException(criteria);//"To write Exception related Code"; 
            }

            return touchpointConfigurations.First().Value;
        }

        private TestTouchPointConfigurationCriteria BuildCriteria(string businessUnitId, string businessService, string entityType, string entityParameter)
        {
            TestTouchPointConfigurationCriteria criteria = new TestTouchPointConfigurationCriteria();
            criteria.BusinessUnitId = businessUnitId;
            criteria.BusinessService = businessService;
            criteria.EntityParameter = entityParameter;
            criteria.EntityType = entityType;
            return criteria;
        }
    }
}
