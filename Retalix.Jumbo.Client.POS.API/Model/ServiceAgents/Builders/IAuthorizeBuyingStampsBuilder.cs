using Retalix.Jumbo.Contracts.Generated.Stamp;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IAuthorizeBuyingStampsBuilder
    {
        AuthorizeBuyingStampsRequestType BuildRequest(string token, string savingStampsCardNumber, decimal transactionAmountDue, PosTransactionKey posTransactionKey);
    }
}
