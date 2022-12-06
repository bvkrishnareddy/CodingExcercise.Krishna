using Retalix.Client.Common.Exceptions;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents.Exceptions
{
    public class StampsAmountRequiredException : BusinessException
    {
        public StampsAmountRequiredException(object[] args)
            : base("StampsAmountRequired", "Stamps Amount Required", args)
        {
        }
    }
}
