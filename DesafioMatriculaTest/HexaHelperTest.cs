using DesafioPuc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioPucTest
{
    [TestClass]
    public class HexaHelperTest
    {
        [TestMethod]
        public void TestarComValorValido()
        {
            string valorUm = "1";
            string valorQuatorze = "E";
            Assert.AreEqual(valorUm, HexaHelper.Base10ToBase16(1));
            Assert.AreEqual(valorQuatorze, HexaHelper.Base10ToBase16(14));
        }        
    }
}
