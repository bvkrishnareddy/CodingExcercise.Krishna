using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Validators
{
    public interface ITestTouchPointLookupValidator
    {
        void Validate(TestTouchPointConfigurationLookupRequestType request, TestTouchPointConfigurationLookupResponseType response);
    }
}
