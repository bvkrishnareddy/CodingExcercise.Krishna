using Retalix.Jumbo.Contracts.Generated.Stamp;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IVoidBuyingStampsRedemptionBuilder
    {
        VoidBuyingStampsRedemptionRequestType BuildRequest(PosTransactionKey posTransactionKey);
    }
}
