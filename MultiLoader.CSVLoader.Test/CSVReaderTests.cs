using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiLoader.CSVLoader.Test
{
    [TestClass]
    public class CSVReaderTests
    {
        private CSVReader plugin;

        [TestInitialize]
        public void Init()
        {
            plugin = CSVReader.GetInstance();
        }

        [TestMethod]
        public void LoadDataTest()
        {
            var result = plugin.LoadData("C:\\Projects\\MultiLoader\\Sources\\TextFile.csv");
            Assert.IsNotNull(result);
        }
    }
}
