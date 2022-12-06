using Retalix.Jumbo.Contracts.Generated.VatSeal;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface IVatSealBuilder
    {
        VatSealRequestType Build(string touchPointId, string businessUnitId);
    }
}
