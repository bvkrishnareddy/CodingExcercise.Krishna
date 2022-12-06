using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;

namespace Retalix.Jumbo.Model.TestTouchPointKR.TestTouchPointConfiguration
{
    public interface ITestTouchPointConfigurationDao : IMovableDao
    {
        /// <summary>
        /// To Add new item or update the existing item
        /// </summary>
        /// <param name="testTouchPointConfiguration"></param>
        void SaveOrUpdate(ITestTouchPointConfiguration testTouchPointConfiguration);
        /// <summary>
        /// To delete an existing item
        /// </summary>
        /// <param name="testTouchPointConfiguration"></param>
        void Delete(ITestTouchPointConfiguration testTouchPointConfiguration);

        /// <summary>
        /// To get all items by criteria
        /// </summary>
        /// <param name="testTouchPointConfiguration"></param>
        /// <returns></returns>
        IEnumerable<ITestTouchPointConfiguration> GetByCriteria(TestTouchPointConfigurationCriteria testTouchPointConfiguration);

        List<ITestTouchPointConfiguration> GetAllBusinessServiceForAllBusinessUnitId(TestTouchPointConfigurationCriteria searchingCriteria);


    }
}
