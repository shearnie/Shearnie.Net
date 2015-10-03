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
            rs = Shearnie.Net.OzTime.ConvertUTC_To_AEST(DateTime.UtcNow);
            rs = Shearnie.Net.OzTime.ConvertUTC_To_AEST(new DateTime(2015, 10, 02, 22, 0, 0));
        }

        [TestMethod]
        public void ToString_UTC_To_AEST()
        {
            var rs = Shearnie.Net.OzTime.ToString_UTC_To_AEST(DateTime.Now, "dd MMM yyyy hh:mm tt");
        }
    }
}
