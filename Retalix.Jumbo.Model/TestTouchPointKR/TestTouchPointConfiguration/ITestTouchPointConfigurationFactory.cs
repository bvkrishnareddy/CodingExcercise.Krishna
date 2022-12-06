using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration
{
    public interface ITestTouchPointConfigurationFactory
    {
        ITestTouchPointConfiguration Create(string businessService, string entityParameter, string businessUnitId, string value, string entityType);
    }
}
