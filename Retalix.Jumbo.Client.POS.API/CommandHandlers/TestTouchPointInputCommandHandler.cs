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
    [Export(typeof(ITestTouchPointInputCommandHandler))]
    public class TestTouchPointInputCommandHandler : PosCommandHandlerBase, ITestTouchPointInputCommandHandler
    {
        private const string TouchPointInputOutcome = "TouchPointInputOutcome";

        protected override string ExecuteLogic()
        {
            return TouchPointInputOutcome;
        }
    }
}
