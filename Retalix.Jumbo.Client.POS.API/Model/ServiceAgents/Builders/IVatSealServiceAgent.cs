using Retalix.Client.Common.ServiceAgents;
using Retalix.Jumbo.Contracts.Generated.VatSeal;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IVatSealServiceAgent : IServiceAgent
    {
        VatSealResponseType GetVatSealsDetails();
    }
}