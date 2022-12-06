using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Retalix.Jumbo.ConnectivityServices.TestTouchPointKR.DMS
{
    public class TestTouchPointConfigurationMovableFormatter : ITestTouchPointConfigurationMovableFormatter
    {
        public IEnumerable<IMovable> Deserialize(IEnumerable<XmlDocument> contracts)
        {
            return contracts.Select(contract => contract.InnerXml.Deserialize<TestTouchPointConfiguration>()).ToList();
        }

        public IEnumerable<XmlDocument> Serialize(IEnumerable<IMovable> movables)
        {
            return movables.Select(movable => movable.ToXmlDocument());
        }
    }
}
