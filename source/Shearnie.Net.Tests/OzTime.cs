using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shearnie.Net.Tests
{
    [TestClass]
    public class OzTime
    {
        [TestMethod]
        public void ConvertUTC_To_AEST()
        {
            var rs = Shearnie.Net.OzTime.ConvertUTC_To_AEST(DateTime.Today);
            rs = Shearnie.Net.OzTime.ConvertUTC_To_AEST(DateTime.Now);
        }
    }
}
