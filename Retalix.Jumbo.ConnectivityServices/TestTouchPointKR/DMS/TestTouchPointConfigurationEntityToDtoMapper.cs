using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using Retalix.StoreServices.Model.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.TestTouchPointKR.DMS
{
    public class TestTouchPointConfigurationEntityToDtoMapper : IEntityToDtoMapper
    {
        private const string OldVersion = "2.0.0";

        public DtosForVersions[] Map(IMovable[] movables, MappingMetadata mappingMetadata, DataChangeType changeType)
        {
            var newVersions = mappingMetadata.TargetNodesVersion.Where(o => !o.StartsWith(OldVersion)).ToArray();
            if (newVersions.Any())
                return CreateDtosForVersions(movables.OfType<ITestTouchPointConfiguration>(), newVersions);

            return new DtosForVersions[0];
        }

        private static DtosForVersions[] CreateDtosForVersions(IEnumerable<ITestTouchPointConfiguration> movables, IEnumerable<string> newVersions)
        {
            return new[]
                       {
                           new DtosForVersions
                               {
                                   Dtos = movables.Select(CreateDto).ToArray(),
                                   Versions = newVersions.ToArray(),
                               }
                       };
        }

        private static INamedObject CreateDto(ITestTouchPointConfiguration movable)
        {
            return new TestTouchPointConfiguration
            {
                BusinessService = movable.BusinessService,
                BusinessUnitId = movable.BusinessUnitId,
                Value = movable.Value,
                EntityParameter = movable.EntityParameter,
                EntityType = movable.EntityType
            };
        }

        public IMovable[] MapBack(INamedObject[] dtos, MappingMetadata mappingMetadata, DataChangeType changeType)
        {

            return dtos.Select(CreateMovable).ToArray();
        }

        private static IMovable CreateMovable(INamedObject dtos)
        {
            var item = dtos as TestTouchPointConfiguration;
            if (item != null)
            {
                return new TestTouchPointConfiguration
                {
                    BusinessService = item.BusinessService,
                    BusinessUnitId = item.BusinessUnitId,
                    Value = item.Value,
                    EntityParameter = item.EntityParameter,
                    EntityType = item.EntityType
                };
            }
            return null;
        }

        public string[] GetEntityNamesForVersion(string entityName, MappingMetadata mappingMetadata, DataChangeType changeType)
        {
            return new[] { "TestTouchPointConfiguration" };
        }

        public Type GetNamedObjectType(string entityName, MappingMetadata mappingMetadata)
        {
            return typeof(TestTouchPointConfiguration);
        }
    }
}
