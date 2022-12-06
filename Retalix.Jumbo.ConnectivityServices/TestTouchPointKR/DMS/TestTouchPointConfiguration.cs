using ProtoBuf;
using Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.ConnectivityServices.TestTouchPointKR.DMS
{
    [Serializable]
    [ProtoContract]
    public class TestTouchPointConfiguration : ITestTouchPointConfiguration
    {
        [ProtoMember(1)]
        public string BusinessUnitId { get; set; }

        [ProtoMember(2)]
        public string BusinessService { get; set; }

        [ProtoMember(3)]
        public string EntityType { get; set; }

        [ProtoMember(4)]
        public string EntityParameter { get; set; }

        [ProtoMember(5)]
        public string Value { get; set; }

        [ProtoMember(6)]
        public string EntityName
        {
            get { return "TestTouchPointConfiguration"; }
            set { }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(TestTouchPointConfiguration)) return false;
            return Equals((TestTouchPointConfiguration)obj);
        }


        public bool Equals(TestTouchPointConfiguration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.BusinessUnitId, BusinessUnitId) && Equals(other.EntityType, EntityType) && Equals(other.EntityParameter, EntityParameter);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (BusinessUnitId != null ? BusinessUnitId.GetHashCode() : 0);
                result = (result * 397) ^ (EntityType != null ? EntityType.GetHashCode() : 0);
                result = (result * 397) ^ (EntityParameter != null ? EntityParameter.GetHashCode() : 0);
                return result;
            }
        }
    }
}
