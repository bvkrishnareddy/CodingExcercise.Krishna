using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Filter;
using Retalix.StoreServices.Model.Organization.BusinessUnit;

namespace Retalix.Jumbo.ConnectivityServices.TestTouchPointKR.DMS
{
    [RegisterAddition("TestTouchPointConfigurationDmsFilter", ImplInterfaceType = typeof(IDmsFilter))]
    public class TestTouchPointConfigurationDmsFilter : IDmsFilter
    {
        private readonly IBusinessUnitDao _businessUnitDao;

        public TestTouchPointConfigurationDmsFilter(IBusinessUnitDao businessUnitDao)
        {
            _businessUnitDao = businessUnitDao;
        }

        public IEnumerable<IBusinessUnit> GetRelevantBusinessUnits(IMovable entity)
        {
            var testTouchPointConfiguration = entity as ITestTouchPointConfiguration;
            if (testTouchPointConfiguration != null)
            {
                var businessUnit = _businessUnitDao.Get(testTouchPointConfiguration.BusinessUnitId);
                if (businessUnit != null)
                {
                    return new List<IBusinessUnit> { businessUnit };
                }
            }

            return Enumerable.Empty<IBusinessUnit>();
        }

        public bool IsRelevant(IMovable entity)
        {
            return entity is ITestTouchPointConfiguration;
        }
    }
}
