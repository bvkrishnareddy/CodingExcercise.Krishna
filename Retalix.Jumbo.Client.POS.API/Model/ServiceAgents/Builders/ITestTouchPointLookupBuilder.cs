using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface ITestTouchPointLookupBuilder
    {
        TestTouchPointConfigurationLookupRequestType BuildLookupRequest(string entityType);
    }
}
