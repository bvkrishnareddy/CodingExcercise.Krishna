using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration
{
    /// <summary>
    /// Provides the configurations for the given input criteria
    /// </summary>
    public interface ITestTouchPointConfigurationProvider
    {
        /// <summary>
        /// Gets configurations for the given BusinessUnitId, if not found look iteratively from its parents
        /// </summary>
        /// <returns></returns>
        IEnumerable<ITestTouchPointConfiguration> GetTouchpointConfigurations(TestTouchPointConfigurationCriteria criteria);

        /// <summary>
        /// Gets configuration value for the given BusinessUnitId, if not found look iteratively from its parents
        /// </summary>
        /// <returns></returns>
        string GetTouchpointConfiguration(string businessUnitId, string businessServiceType, string entityTypeType, string entityParameterType);
    }
}
