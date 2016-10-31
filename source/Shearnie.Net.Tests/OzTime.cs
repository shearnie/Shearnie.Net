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
            Assert.AreEqual(
                new DateTime(2015, 10, 03, 08, 0, 0), 
                Shearnie.Net.OzTime.ConvertUTC_To_AEST(new DateTime(2015, 10, 02, 22, 0, 0)));

            DateTime? dt = new DateTime(2015, 10, 02, 22, 0, 0);
            Assert.AreEqual(
                new DateTime(2015, 10, 03, 08, 0, 0), Shearnie.Net.OzTime.ConvertUTC_To_AEST(dt));
        }

        [TestMethod]
        public void ConvertAEST_To_UTC()
        {
            Assert.AreEqual(
                new DateTime(2015, 10, 02, 12, 0, 0),
                Shearnie.Net.OzTime.ConvertAEST_To_UTC(new DateTime(2015, 10, 02, 22, 0, 0)));

            DateTime? dt = new DateTime(2015, 10, 02, 22, 0, 0);
            Assert.AreEqual(
                new DateTime(2015, 10, 02, 12, 0, 0), Shearnie.Net.OzTime.ConvertAEST_To_UTC(dt));
        }

        [TestMethod]
        public void Now()
        {
            var now = DateTime.UtcNow;
            Assert.AreEqual(now.AddHours(10), Shearnie.Net.OzTime.ConvertUTC_To_AEST(now));
        }

        [TestMethod]
        public void ToString_UTC_To_AEST()
        {
            var rs = Shearnie.Net.OzTime.ToString_UTC_To_AEST(DateTime.Now, "dd MMM yyyy hh:mm tt");
        }
    }
}
