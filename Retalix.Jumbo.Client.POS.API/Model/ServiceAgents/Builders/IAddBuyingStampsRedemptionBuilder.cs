using Retalix.Jumbo.Contracts.Generated.Stamp;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IAddBuyingStampsRedemptionBuilder
    {
        AddBuyingStampsRedemptionRequestType BuildRequest(decimal amount, PosTransactionKey posTransactionKey);
    }
}
