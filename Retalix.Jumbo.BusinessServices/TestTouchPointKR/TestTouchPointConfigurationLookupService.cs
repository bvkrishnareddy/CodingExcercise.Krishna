using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Jumbo.BusinessServices.Common;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;

namespace Retalix.Jumbo.BusinessServices.TestTouchPointKR
{
    [RegisterAddition("TestTouchPointConfigurationLookupService")]
    public class TestTouchPointConfigurationLookupService : BusinessService<TestTouchPointConfigurationLookupRequestType, TestTouchPointConfigurationLookupResponseType>
    {
        private readonly ITestTouchPointConfigurationProvider _testTouchPointConfigurationProvider;
        public TestTouchPointConfigurationLookupService(ITestTouchPointConfigurationProvider testTouchPointConfigurationProvider)
        {
            _testTouchPointConfigurationProvider = testTouchPointConfigurationProvider;
        }
        public override TestTouchPointConfigurationLookupResponseType ExecuteService(TestTouchPointConfigurationLookupRequestType request)
        {
            var response = new TestTouchPointConfigurationLookupResponseType();

            var criteria = CreateCriteria(request);
            IEnumerable<ITestTouchPointConfiguration> touchpointConfigurations;
            if (criteria != null && string.IsNullOrEmpty(criteria.BusinessService) && criteria.EntityType != null && criteria.EntityType == TestTouchPointConfigurationConstants.EntityType.TouchPointGroup)
            {
                var entityParamter = criteria.EntityParameter;
                criteria.BusinessService = null;
                criteria.EntityType = null;
                criteria.EntityParameter = null;

                var touchpointConfigurationsForAll = _testTouchPointConfigurationProvider.GetTouchpointConfigurations(criteria);
                touchpointConfigurations = touchpointConfigurationsForAll.Where(tpc => FilterTouchPointGroupId(tpc, entityParamter));
            }
            else
            {
                touchpointConfigurations = _testTouchPointConfigurationProvider.GetTouchpointConfigurations(criteria);
            }

            if (touchpointConfigurations != null)
            {
                var contractTouchPointConfigurations =
                    touchpointConfigurations.ToList().ConvertAll(ConvertModelToContract).ToArray();
                response.TestTouchPointConfigurations = contractTouchPointConfigurations;
            }
            return response;
        }

        #region Private Methods
        private TestTouchPointConfigurationCriteria CreateCriteria(TestTouchPointConfigurationLookupRequestType request)
        {
            TestTouchPointConfigurationCriteria criteria = null;

            if (request.SearchCriteria != null)
            {
                criteria = CreateCriteriaFromRequest(request);
            }

            return criteria;
        }
        private TestTouchPointConfigurationCriteria CreateCriteriaFromRequest(
            TestTouchPointConfigurationLookupRequestType request)
        {
            return new TestTouchPointConfigurationCriteria
            {
                BusinessUnitId = request.SearchCriteria.BusinessUnitId,
                EntityParameter = request.SearchCriteria.EntityParameter,
                EntityType = request.SearchCriteria.EntityType,
            };
        }

        private bool FilterTouchPointGroupId(ITestTouchPointConfiguration testTouchPointConfiguration, string entityParameterTouchPointGroupId)
        {
            if (testTouchPointConfiguration.EntityType != TestTouchPointConfigurationConstants.EntityType.TouchPointGroup) return true;

            return testTouchPointConfiguration.EntityParameter == entityParameterTouchPointGroupId;
        }

        private static TestTouchPointConfigurationType ConvertModelToContract(
            ITestTouchPointConfiguration testTouchPointConfiguration )
        {
            return new TestTouchPointConfigurationType
            {
                BusinessService = testTouchPointConfiguration.BusinessService,
                EntityParameter = testTouchPointConfiguration.EntityParameter,
                BusinessUnitId = testTouchPointConfiguration.BusinessUnitId,
                Value = testTouchPointConfiguration.Value,
                EntityType = testTouchPointConfiguration.EntityType,
            };
        }
        #endregion
    }
}
