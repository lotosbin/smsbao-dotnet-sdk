using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsbao.test {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            var client = new SmsBaoClient();
            var mobile = ConfigurationManager.AppSettings["mobile"];
            client.SendSms(mobile, "sldkfslkdjl");
        }
    }
}