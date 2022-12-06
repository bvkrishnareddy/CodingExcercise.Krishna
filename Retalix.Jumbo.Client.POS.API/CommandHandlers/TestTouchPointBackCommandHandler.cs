using Retalix.Client.POS.BusinessObjects.CommandHandlers;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.CommandHandlers
{
    [Export(typeof(ITestTouchPointBackCommandHandler))]
    public class TestTouchPointBackCommandHandler : PosCommandHandlerBase, ITestTouchPointBackCommandHandler
    {
        private const string TouchPointBackOutcome = "TouchPointBackOutcome";

        protected override string ExecuteLogic()
        {
            return TouchPointBackOutcome;
        }
    }
}
