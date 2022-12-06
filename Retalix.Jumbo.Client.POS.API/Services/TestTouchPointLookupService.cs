using Retalix.Jumbo.Client.POS.API.Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Retalix.Client.POS.API.Infrastructure.Service;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;

namespace Retalix.Jumbo.Client.POS.API.Services
{
    [Export(typeof(ITestTouchPointLookupService))]
    public class TestTouchPointLookupService : ServiceBase, ITestTouchPointLookupService
    {
        private const string ServiceName = "TestTouchPointConfigurationLookup";
        public TestTouchPointConfigurationLookupResponseType Execute(TestTouchPointConfigurationLookupRequestType request)
        {
            return Execute<TestTouchPointConfigurationLookupRequestType, TestTouchPointConfigurationLookupResponseType>(request, ServiceName);
        }
    }
}
