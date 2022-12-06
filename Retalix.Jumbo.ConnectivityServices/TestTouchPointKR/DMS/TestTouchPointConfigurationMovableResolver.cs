using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Jumbo.Model.DMS;
using Retalix.Jumbo.Model.Infrastructure.DataMovement;
using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using Retalix.Jumbo.ModuleInstaller.Model.RegistrationAttributes;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;

namespace Retalix.Jumbo.ConnectivityServices.TestTouchPointKR.DMS
{
    [RegisterAddition(Id = "TestTouchPointConfiguration")]
    public class TestTouchPointConfigurationMovableResolver : ICompatibilityMovableServicesResolver
    {
        private readonly ITestTouchPointConfigurationDao _movableDao;
        private readonly IEntityToDtoMapper _entityToDtoMapper;
        private readonly IResolver _resolver;

        public TestTouchPointConfigurationMovableResolver(ITestTouchPointConfigurationDao movableDao, IResolver resolver)
        {
            _movableDao = movableDao;
            _resolver = resolver;
            _entityToDtoMapper = new TestTouchPointConfigurationEntityToDtoMapper();
        }

        public string ComponentName
        {
            get
            {
                return _resolver.CanResolve<IMovableComponentProvider>() ? _resolver.Resolve<IMovableComponentProvider>().GetComponent() : "JumboRetail";
            }
        }

        public IEntityToDtoMapper EntityToDtoMapper
        {
            get { return _entityToDtoMapper; }
        }

        public IMovableFormatter Formatter
        {
            get { return new MovableFormatterEmpty(); }
        }

        public IMovableDao MovableDao
        {
            get { return _movableDao as IMovableDao; }
        }
    }
}
