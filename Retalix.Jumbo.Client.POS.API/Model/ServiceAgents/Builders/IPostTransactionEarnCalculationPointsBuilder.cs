using Retalix.Jumbo.Contracts.Generated.PostTransactionEarnCalculationPoints;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IPostTransactionEarnCalculationPointsBuilder
    {
        PostTransactionEarnCalculationPointsRequest BuildRequest(string transactionId, string cardId);
    }
}
