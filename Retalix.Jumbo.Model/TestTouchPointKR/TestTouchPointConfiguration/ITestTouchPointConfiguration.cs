using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration
{
    /// <summary>
    /// To hold the generic settings of a touch point
    /// </summary>
    public interface ITestTouchPointConfiguration : IMovable, INamedObject
    {
        /// <summary>
        /// Get/Set Business Unit Unique Identifier
        /// </summary>
        string  BusinessUnitId { get; set; }

        /// <summary>
        /// Get/Set Business Service 
        /// </summary>
        string BusinessService { get; set; }

        /// <summary>
        /// Get/Set Entity Type
        /// </summary>
        string EntityType { get; set; }

        /// <summary>
        /// Get/Set Entity Parameter
        /// </summary>
        string EntityParameter { get; set; }

        /// <summary>
        /// Get/Set Value
        /// </summary>
        string Value { get; set; }
    }
}
