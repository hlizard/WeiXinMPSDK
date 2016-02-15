using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Senparc.Weixin;
using DLib;

namespace Senparc.WeixinTests
{
    [TestClass()]
    public class ConfigTests
    {
        [TestMethod()]
        public void GetConfigTest()
        {
            Assert.IsNotNull(DConfig.GetConfig<bool>("Senparc.Weixin:RetryIfFaild"));
            Assert.IsTrue(DConfig.GetConfig<bool>("Senparc.Weixin:RetryIfFaild").Value);

            Assert.IsFalse(DConfig.GetConfig<bool>("a").Value);

            Assert.AreEqual(100, DConfig.GetConfig<int>("b").Value);
            Assert.AreEqual(100.0, DConfig.GetConfig<double>("b").Value);

            Assert.AreEqual(new DateTime(2016,2,15), DConfig.GetConfig<DateTime>("c").Value);

            Assert.AreEqual("2016/2/15", DConfig.GetConfig("c"));

            Assert.IsNull(DConfig.GetConfig<int>("x"));
        }
    }
}
