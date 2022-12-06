using Retalix.Client.POS.BusinessObjects.CommandHandlers;
using Retalix.Jumbo.Client.POS.API.Interfaces;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.CommandHandlers
{
    [Export(typeof(ITestTouchPointLookupCommandHandler))]
    public class TestTouchPointLookupCommandHandler : PosCommandHandlerBase, ITestTouchPointLookupCommandHandler
    {
        private string _entityType;
        private const string TouchPointLookupOutcome = "TouchPointLookupOutcome";

        public void Init(string entityType)
        {
            _entityType = entityType;
        }

        protected override string ExecuteLogic()
        {
            var touchPointLookupResponse = ExecuteCarLookupServiceAgent();
            SetupTouchPointDataModel(touchPointLookupResponse);
            return TouchPointLookupOutcome;
        }

        private void SetupTouchPointDataModel(TestTouchPointConfigurationLookupResponseType touchPointLookupResponse)
        {
            var touchPointDataModel = GetDataModel<ITestTouchPointDataModel>();
            touchPointDataModel.TouchPointResponseType = touchPointLookupResponse;
        }

        private TestTouchPointConfigurationLookupResponseType ExecuteCarLookupServiceAgent()
        {
            var carLookupServiceAgent = GetServiceAgent<ITestTouchPointLookupServiceAgent>();
            return carLookupServiceAgent.Execute(_entityType);
        }
    }
}
