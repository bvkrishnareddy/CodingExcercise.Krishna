using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;

namespace Retalix.Jumbo.ConnectivityServices.TestTouchPointKR.DMS
{
    [RegisterAddition]
    public class TestTouchPointConfigurationFactory : ITestTouchPointConfigurationFactory
    {
        public ITestTouchPointConfiguration Create(string businessService, string entityParameter, string businessUnitId, string value, string entityType)
        {
            return new TestTouchPointConfiguration
            {
                BusinessService = businessService,
                EntityParameter = entityParameter,
                BusinessUnitId = businessUnitId,
                Value = value,
                EntityType = entityType
            };
        }
    }
}
