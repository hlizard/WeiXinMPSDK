using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Senparc.Weixin;

namespace Senparc.WeixinTests
{
    [TestClass()]
    public class ConfigTests
    {
        [TestMethod()]
        public void GetConfigTest()
        {
            Assert.IsNotNull(Config.GetConfig<bool>("Senparc.Weixin:RetryIfFaild"));
            Assert.IsTrue(Config.GetConfig<bool>("Senparc.Weixin:RetryIfFaild").Value);

            Assert.IsFalse(Config.GetConfig<bool>("a").Value);

            Assert.AreEqual(100, Config.GetConfig<int>("b").Value);
            Assert.AreEqual(100.0, Config.GetConfig<double>("b").Value);

            Assert.AreEqual(new DateTime(2016,2,15), Config.GetConfig<DateTime>("c").Value);

            Assert.AreEqual("2016/2/15", Config.GetConfig("c"));

            Assert.IsNull(Config.GetConfig<int>("x"));
        }
    }
}
