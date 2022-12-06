using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Retalix.Client.POS.BusinessObjects.ServiceAgents;
using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
using Retalix.Contracts.Generated.Common;
using Retalix.Jumbo.Client.POS.API.Model.ServiceAgents;
using Retalix.Jumbo.Client.POS.API.Model.Services;
using Retalix.Jumbo.Contracts.Generated.Infrastructure;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents
{
    [Export(typeof(ITouchPointSystemParameterServiceAgent))]
    public class TouchPointSystemParameterServiceAgent :ServiceAgentBase, ITouchPointSystemParameterServiceAgent
    {
        [Import] private ITouchPointSystemParameterService _service;

        private SystemParameterClientTypeRequestType BuildRequest()
        {
            return new SystemParameterClientTypeRequestType
            {
                Header = CreateHeader(),
                ClientType = "TouchPoint"
            };
        }

        private RetalixCommonHeaderType CreateHeader()
        {
            return new RetalixCommonHeaderType
            {
                MessageId = new RequestIDCommonData()
            };
        }

        public IDictionary<string, string> GetAll()
        {
            return Execute().ToDictionary(systemParameterInfo => systemParameterInfo.ParameterKey, systemParameterInfo => systemParameterInfo.ParameterValue);
        }

        private SystemParameterInfo[] Execute()
        {
            return _service.GetAll(BuildRequest()).SystemParameters;
        }
    }
}