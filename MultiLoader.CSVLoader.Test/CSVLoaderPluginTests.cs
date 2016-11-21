using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MultiLoader.Shared;

namespace MultiLoader.CSVLoader.Test
{
    [TestClass]
    public class CSVLoaderPluginTests
    {
        private CSVLoaderPlugin _plugin;

        [TestInitialize]
        public void Init()
        {
            _plugin = new CSVLoaderPlugin("TestPlugin");
        }

        [TestMethod]
        public void Test()
        {
            var plugin = new Mock<ICommand>();
            plugin.Setup(h => h.ExecuteCommand(It.IsAny<string>()));
            plugin.Object.ExecuteCommand("test_path");

            //assertion
            plugin.Verify(h => h.ExecuteCommand(It.IsAny<string>()), Times.Once);
        }
    }
}
