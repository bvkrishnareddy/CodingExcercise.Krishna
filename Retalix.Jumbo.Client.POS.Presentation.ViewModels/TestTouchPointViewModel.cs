using Retalix.Client.POS.Presentation.ViewModels.ViewModels;
using Retalix.Client.Presentation.Core.Command;
using Retalix.Jumbo.Client.POS.API.Interfaces;
using Retalix.Jumbo.Client.POS.API.Model.CommanHandler;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Retalix.Jumbo.Client.POS.Presentation.ViewModels.ViewModels
{
    public class TestTouchPointViewModel : PosViewModelBase
    {
        private ITestTouchPointDataModel _touchPointDataModel;
        public ICommand BackCommand { get; private set; }

        private List<TestTouchPointConfigurationType> _touchPoint;
        public List<TestTouchPointConfigurationType> TouchPoint
        {
            get { return _touchPoint; }
            set { _touchPoint = value; }
        }

        public TestTouchPointViewModel()
        {
            Init();
            InitCommands();
        }

        private void Init()
        {
            _touchPointDataModel = _dataModelProvider.GetDataModel<ITestTouchPointDataModel>();
            var touchPointList = _touchPointDataModel.TouchPointResponseType.TestTouchPointConfigurations; // new List<CarData>();
            //var touchPoint = _touchPointDataModel.TouchPointResponseType.TestTouchPointConfigurations;
            //touchPointList.Add(touchPoint);
            TouchPoint = touchPointList.ToList();
        }


        private void InitCommands()
        {
            BackCommand = new CommandAction<object>(ExecuteBackCommand, x => true);
        }

        protected virtual void ExecuteBackCommand(object obj)
        {

            ExecuteBackCommandHandler();
        }

        protected virtual void ExecuteBackCommandHandler()
        {
            var command = CommandHandlerFactory.Create<ITestTouchPointBackCommandHandler>();
            ExecuteCommandHandlerAndStartFlow(command);
        }
    }
}
