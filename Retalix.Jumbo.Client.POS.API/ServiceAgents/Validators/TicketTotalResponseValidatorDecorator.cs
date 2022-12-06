using System.Collections;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Serialization;
using Retalix.Client.Common.Application;
using Retalix.Client.Common.Exceptions;
using Retalix.Client.POS.BusinessObjects.ServiceAgents.Validations;
using Retalix.Contracts.Generated.Arts.PosLogV4.Source;
using Retalix.Contracts.Generated.Arts.RtiV4;
using Retalix.Contracts.Utils;
using Retalix.Jumbo.Client.POS.API.ServiceAgents.Exceptions;
using Retalix.Jumbo.Contracts.Generated.Stamp;

namespace Retalix.Jumbo.Client.POS.API.ServiceAgents.Validators
{
    public class TicketTotalResponseValidatorDecorator : ITicketTotalResponseValidator
    {
        [Import(AllowDefault = true)]
        [XmlIgnore]
        public IResolver Resolver;

        private const string StampsAmountRequired = "StampsAmountRequired";

        public void Validate(RTSTransactionTotalResponse response)
        {
            try
            {
                var ticketTotalResponseValidator = Resolver.ResolveCoreImplementation<ITicketTotalResponseValidator>();
                ticketTotalResponseValidator.Validate(response);
            }
            catch (BusinessException businessException)
            {
                if(businessException.ErrorCode == StampsAmountRequired)
                    ValidateStampsAmountRequiredError(response.ARTSHeader);
                throw;
            }
        }

        private void ValidateStampsAmountRequiredError(ARTSCommonHeaderType header)
        {
            var errors = header.Response.BusinessError;
            if (errors == null || ((ICollection) errors).Count <= 0) return;

            var firstError = errors.FirstOrDefault();
            if(firstError == null) return;

            var eligibleAmount = firstError.Any.FirstOrDefault(a => a.Name == typeof(TotalEligibleAmountType).Name);
            if (eligibleAmount == null) return;

            var totalEligibleAmountType =
                  new XmlContractSerializer().Deserialize<TotalEligibleAmountType>(eligibleAmount.OuterXml);
            if (totalEligibleAmountType == null) return;

            throw new StampsAmountRequiredException(new object[] {totalEligibleAmountType.Value});
        }
    }
}
