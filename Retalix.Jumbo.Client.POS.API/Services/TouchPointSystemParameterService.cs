using System.ComponentModel.Composition;
using Retalix.Client.Net;
using Retalix.Jumbo.Client.POS.API.Model.Services;
using Retalix.Jumbo.Contracts.Generated.Infrastructure;

namespace Retalix.Jumbo.Client.POS.API.Services
{
    [Export(typeof(ITouchPointSystemParameterService))]
    public class TouchPointSystemParameterService : ServiceBase, ITouchPointSystemParameterService
    {
        public SystemParameterClientTypeResponseType GetAll(SystemParameterClientTypeRequestType request)
        {
            return Execute<SystemParameterClientTypeRequestType, SystemParameterClientTypeResponseType>(request, "SystemParameterClientType");
        }
    }
}