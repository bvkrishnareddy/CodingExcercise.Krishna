using Retalix.Client.CommonServices.Utils;
using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents.Builders
{
    [Export(typeof(ITestTouchPointLookupBuilder))]
    public class TestTouchPointLookupBuilder : ITestTouchPointLookupBuilder
    {
        public TestTouchPointConfigurationLookupRequestType BuildLookupRequest(string entityType)
        {
            var touchPointSearchCriteria = new SearchCriteriaType { EntityType = entityType };
            var touchPointLookupRequest = new TestTouchPointConfigurationLookupRequestType()
            {
                Header = new RetalixCommonHeaderType()
                {
                    MessageId = new RequestIDCommonData()
                    {
                        Value = MessageIdGenerator.GetId().ToString()
                    }
                },
                SearchCriteria = touchPointSearchCriteria

            };
            return touchPointLookupRequest;
        }
    }
}
