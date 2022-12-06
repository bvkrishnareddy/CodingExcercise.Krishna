using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.BusinessServices.Common;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Customer.Legacy.Exceptions;

namespace Retalix.Jumbo.BusinessServices.TestTouchPointKR
{
    [RegisterAddition("TestTouchPointConfigurationMaintenanceService")]
    public class TestTouchPointConfigurationMaintenanceService : BusinessService<TestTouchPointConfigurationMaintenanceRequestType, TestTouchPointConfigurationMaintenanceResponseType>
    {
        private readonly ITestTouchPointConfigurationDao _testTouchPointConfigurationDao;
        private readonly ITestTouchPointConfigurationFactory _testTouchPointConfigurationFactory;
        public TestTouchPointConfigurationMaintenanceService(ITestTouchPointConfigurationDao testTouchPointConfigurationDao, ITestTouchPointConfigurationFactory testTouchPointConfigurationFactory)
        {
            _testTouchPointConfigurationDao = testTouchPointConfigurationDao;
            _testTouchPointConfigurationFactory = testTouchPointConfigurationFactory;
        }

        public override TestTouchPointConfigurationMaintenanceResponseType ExecuteService(TestTouchPointConfigurationMaintenanceRequestType request)
        {
            HandleTestTouchPointConfigurationMaintenanceAction(request);

            return new TestTouchPointConfigurationMaintenanceResponseType();
        }

        #region Private Methods
        private void HandleTestTouchPointConfigurationMaintenanceAction(TestTouchPointConfigurationMaintenanceRequestType testTouchPointConfigurationRequest)
        {
            switch (testTouchPointConfigurationRequest.Action)
            {
                case ActionTypeCodes.Add:
                case ActionTypeCodes.Update:
                case ActionTypeCodes.AddUpdate:
                case ActionTypeCodes.AddOrUpdate:
                    ExecuteAddOrUpdateAction(testTouchPointConfigurationRequest);
                    break;
                case ActionTypeCodes.Delete:
                    ExecuteDeleteAction(testTouchPointConfigurationRequest);
                    break;
            }
        }
        private void ExecuteAddOrUpdateAction(TestTouchPointConfigurationMaintenanceRequestType testTouchPointConfigurationRequest)
        {
            foreach (var configuration in testTouchPointConfigurationRequest.TestTouchPointConfiguration)
            {
                ValidateRequest(configuration);
                var configurationModel = ConvertContractToModel(configuration);
                _testTouchPointConfigurationDao.SaveOrUpdate(configurationModel);
            }
        }

        private void ValidateRequest(TestTouchPointConfigurationType testTouchPointConfigurationType)
        {
            if (testTouchPointConfigurationType == null) throw new ArgumentNullException("testTouchPointConfigurationType");

            if (string.IsNullOrEmpty(testTouchPointConfigurationType.BusinessUnitId))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<TestTouchPointConfigurationType>(u => u.BusinessUnitId));

            if (string.IsNullOrEmpty(testTouchPointConfigurationType.EntityParameter))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<TestTouchPointConfigurationType>(u => u.EntityParameter));

            if (string.IsNullOrEmpty(testTouchPointConfigurationType.EntityType))
                throw new MissingMandatoryFieldException(PropertyResolver.GetName<TestTouchPointConfigurationType>(u => u.EntityType));
        }

        private ITestTouchPointConfiguration ConvertContractToModel(TestTouchPointConfigurationType testTouchPointConfigurationType)
        {
            return _testTouchPointConfigurationFactory.Create(testTouchPointConfigurationType.BusinessService,
                testTouchPointConfigurationType.EntityParameter, testTouchPointConfigurationType.BusinessUnitId,
                testTouchPointConfigurationType.Value, testTouchPointConfigurationType.EntityType);

        }

        private void ExecuteDeleteAction(TestTouchPointConfigurationMaintenanceRequestType testTouchPointConfiguratioRequest)
        {
            foreach (var configuration in testTouchPointConfiguratioRequest.TestTouchPointConfiguration)
            {
                ValidateRequest(configuration);
                var configurationModel = ConvertContractToModel(configuration);
                _testTouchPointConfigurationDao.Delete(configurationModel);
            }
        }
        #endregion
    }
}
