using Retalix.Client.POS.Presentation.ViewModels.ViewModels;
using Retalix.Client.Presentation.Core.Command;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Retalix.Jumbo.Client.POS.Presentation.ViewModels.ViewModels
{
    public class TestTouchPointInputViewModel : PosViewModelBase
    {
        public ICommand GetCommand { get; private set; }
        public ICommand BackCommand { get; private set; }


        private string _entityType;
        public string EntityType
        {
            get { return _entityType; }
            set
            {
                _entityType = value;
                NotifyPropertyChanged("EntityType");
            }
        }

        public TestTouchPointInputViewModel()
        {
            Init();
        }
        private void Init()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            GetCommand = new CommandAction<object>(ExecuteGetCommand, CanExecuteGetCommand);
            BackCommand = new CommandAction<object>(ExecuteBackCommand, x => true);


        }

        private bool CanExecuteGetCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(EntityType);
        }

        protected virtual void ExecuteGetCommand(object obj)
        {

            ExecuteCarLookupCommandHandler(_entityType);
        }

        protected virtual void ExecuteBackCommand(object obj)
        {

            ExecuteBackCommandHandler();
        }

        protected virtual void ExecuteCarLookupCommandHandler(string entityType)
        {
            var command = CommandHandlerFactory.Create<ITestTouchPointLookupCommandHandler>();
            command.Init(entityType);
            ExecuteCommandHandlerAndStartFlow(command);
        }

        protected virtual void ExecuteBackCommandHandler()
        {
            var command = CommandHandlerFactory.Create<ITestTouchPointBackCommandHandler>();
            ExecuteCommandHandlerAndStartFlow(command);
        }
    }
}
