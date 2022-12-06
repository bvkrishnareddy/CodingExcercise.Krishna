using Retalix.Client.Common.ServiceAgents;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents
{
    public interface ITestTouchPointLookupServiceAgent : IServiceAgent
    {
        TestTouchPointConfigurationLookupResponseType Execute(string entityType);
    }
}
