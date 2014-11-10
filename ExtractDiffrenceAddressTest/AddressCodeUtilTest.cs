using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExtractDifferenceAddress.Utils;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class AddressCodeUtilTest
    {
        [TestMethod]
        public void 住所コードが01から始まると北海道が返る()
        {
            Assert.AreEqual("北海道", AddressCodeUtil.GetPrefectureName("01223053003"));
        }
        [TestMethod]
        public void 住所コードが02から始まる青森県が返る()
        {
            Assert.AreEqual("青森県", AddressCodeUtil.GetPrefectureName("02223053003"));
        }
        [TestMethod]
        public void 住所コードが03から始まると岩手県が返る()
        {
            Assert.AreEqual("青森県", AddressCodeUtil.GetPrefectureName("03223053003"));
        }
        [TestMethod]
        public void 住所コードが04から始まると宮城県が返る()
        {
            Assert.AreEqual("青森県", AddressCodeUtil.GetPrefectureName("04223053003"));
        }
        [TestMethod]
        public void 住所コードが05から始まる秋田県が返る()
        {
            Assert.AreEqual("青森県", AddressCodeUtil.GetPrefectureName("05223053003"));
        }
        [TestMethod]
        public void 住所コードが06から始まる山形県が返る()
        {
            Assert.AreEqual("青森県", AddressCodeUtil.GetPrefectureName("06223053003"));
        }
        [TestMethod]
        public void 住所コードが07から始まる福島県が返る()
        {
            Assert.AreEqual("福島県", AddressCodeUtil.GetPrefectureName("07223053003"));
        }
    }
}
