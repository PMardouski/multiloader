using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiLoader.TXTLoader.Test
{
    [TestClass]
    public class TXTReaderTests
    {
        private TXTReader plugin;

        [TestInitialize]
        public void Init()
        {
            plugin = TXTReader.GetInstance();
        }

        [TestMethod]
        public void LoadDataTest()
        {
            plugin = TXTReader.GetInstance();
            var result = plugin.LoadData("C:\\Projects\\MultiLoader\\Sources\\TextFile.txt");
            Assert.IsNotNull(result);
        }
    }
}
