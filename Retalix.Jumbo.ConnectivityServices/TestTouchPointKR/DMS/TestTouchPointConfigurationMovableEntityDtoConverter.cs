using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.TestTouchPointKR.DMS
{
    public class TestTouchPointConfigurationMovableEntityDtoConverter : ITestTouchPointConfigurationMovableEntityDtoConverter
    {
        public IMovable[] MapBackFromDto(IEnumerable<INamedObject> dtos, DataChangeType changeType)
        {
            if (dtos == null)
                return Enumerable.Empty<IMovable>() as IMovable[];

            return dtos.Cast<TestTouchPointConfiguration>().Select(ToMovable).ToArray();
        }

        public INamedObject[] MapToDto(IEnumerable<IMovable> movables, DataChangeType changeType)
        {
            if (movables == null)
                return Enumerable.Empty<INamedObject>() as INamedObject[];

            return movables.Select(ToDTO).ToArray();
        }

        protected IMovable ToMovable(TestTouchPointConfiguration dto)
        {
            return dto;
        }

        protected TestTouchPointConfiguration ToDTO(IMovable movable)
        {
            var dto = movable as TestTouchPointConfiguration;
            return dto;
        }

        public Type DtoType()
        {
            return typeof(TestTouchPointConfiguration);
        }
    }
}
