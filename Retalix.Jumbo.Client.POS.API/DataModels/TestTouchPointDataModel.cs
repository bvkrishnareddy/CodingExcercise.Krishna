using Retalix.Client.Common.DataModels;
using Retalix.Jumbo.Client.POS.API.Interfaces;
using Retalix.Jumbo.Contracts.Generated.TestTouchPointKR;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.Jumbo.Client.POS.API.DataModels
{
    [Export(typeof(IDataModel))]
    public class TestTouchPointDataModel : ITestTouchPointDataModel
    {
        public TestTouchPointConfigurationLookupResponseType TouchPointResponseType { get; set; }

        public void Clear()
        {
            TouchPointResponseType = null;
        }
    }
}
