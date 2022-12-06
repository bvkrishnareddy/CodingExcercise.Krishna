using Retalix.Client.POS.BusinessObjects.ServiceAgents.Validations;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Validators;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents.Validators
{
    [Export(typeof(ITestTouchPointLookupValidator))]
    public class TestTouchPointLookupValidator : RetalixValidatorBase, ITestTouchPointLookupValidator
    {
        public void Validate(TestTouchPointConfigurationLookupRequestType request, TestTouchPointConfigurationLookupResponseType response)
        {
            ValidateResponseError(response.Header);
        }
    }
}
