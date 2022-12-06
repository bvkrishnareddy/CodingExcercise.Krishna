using Retalix.Jumbo.Contracts.Generated.VatSeal;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IVatSealControlTransactionService
    {
        VatSealResponseType GetVatSealsDetails(VatSealRequestType request);
    }
}