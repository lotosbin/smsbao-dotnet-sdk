using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace smsbao.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SmsBaoService.SendSms();
        }
    }
}
