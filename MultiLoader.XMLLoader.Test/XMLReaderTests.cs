using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiLoader.XMLLoader.Test
{
    [TestClass]
    public class XMLReaderTests
    {
        private XMLReader plugin;

        [TestInitialize]
        public void Init()
        {
            plugin = XMLReader.GetInstance();
        }

        [TestMethod]
        public void LoadDataTest()
        {
            plugin = XMLReader.GetInstance();
            var result = plugin.LoadData("C:\\Projects\\MultiLoader\\Sources\\XMLFile.xml");
            Assert.IsNotNull(result);
        }
    }
}
