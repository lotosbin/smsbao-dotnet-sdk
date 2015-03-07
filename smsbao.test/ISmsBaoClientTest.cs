using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace smsbao.test
{
    [TestClass]
    public class ISmsBaoClientTest
    {
        [TestMethod]
        public void SendSmsTest()
        {
            var client = new SmsBaoClient();
            var mobile = ConfigurationManager.AppSettings["mobile"];
            var result = client.SendSms(mobile, "【神猪】sldkfslkdjl");
            Debug.WriteLine(JsonConvert.SerializeObject(result));
            Assert.IsTrue(result.Success);
        }
    }
}