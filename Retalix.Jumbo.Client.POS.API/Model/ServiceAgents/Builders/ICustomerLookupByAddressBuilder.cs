using Retalix.Jumbo.Contracts.Generated.Customer;

namespace Retalix.Jumbo.Client.POS.API.Model.ServiceAgents.Builders
{
    public interface ICustomerLookupByAddressBuilder
    {
        CustomerLookupByAddressRequestType Build(string postalCode, string streetNum);
    }
}
