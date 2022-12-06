using Retalix.Client.Common.Handlers;
using Retalix.Client.POS.BusinessObjects.Factory;
using Retalix.Client.Presentation.Core.ViewModels;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.CommandHandlers
{
    [Export(typeof(IExtendedCommand))]
    public class TestTouchPointExtendedCommandHandler : IExtendedCommand
    {
        private const string TouchPointCommandName = "AddKrishna_Command";

        [Import]
        private ICommandHandlerFactory _commandHandlerFactory;
        public string CommandName { get { return TouchPointCommandName; } }

        public ICommandHandler GetCommandHandler(ViewModelBase viewModel)
        {
            var commandHandler = _commandHandlerFactory.Create<ITestTouchPointInputCommandHandler>();
            return commandHandler;
        }
    }
}
