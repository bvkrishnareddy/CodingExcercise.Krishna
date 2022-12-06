using Retalix.Client.Common.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.Model.CommanHandler
{
    public interface ITestTouchPointLookupCommandHandler : ICommandHandler
    {
        void Init(string entityType);
    }
}
