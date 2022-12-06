using Retalix.Client.Common.ServiceAgents;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Validators;
using Retalix.Jumbo.Client.POS.API.Model.Services;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents
{
    [Export(typeof(IServiceAgent))]
    public class TestTouchPointLookupServiceAgent : ITestTouchPointLookupServiceAgent
    {
        [Import] private ITestTouchPointLookupService _touchPointLookupService;

        [Import] private ITestTouchPointLookupValidator _touchPointLookupValidator;

        [Import] private ITestTouchPointLookupBuilder _touchPointLookupRequestBuilder;


        public TestTouchPointConfigurationLookupResponseType Execute(string entityType)
        {
            var carLookupRequest = _touchPointLookupRequestBuilder.BuildLookupRequest(entityType);
            var carLookupResponse = _touchPointLookupService.Execute(carLookupRequest);
            _touchPointLookupValidator.Validate(carLookupRequest, carLookupResponse);
            return carLookupResponse;
        }
    }
}
