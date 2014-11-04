using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtractDiffrenceAddress.Repositories;
using System.Diagnostics; 


namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class PastFiscalYearRepositoryTest
    {
        private string filePath = @"C:\work\millea\06_住所比較Accessファイル\01_Hokkaido.accdb";
        [TestMethod]
        public void CountByAddressTest()
        {
            var pastRepo = new PastFiscalYearRepository(filePath,"00_hokkaido");

            Assert.AreEqual(1, pastRepo.CountByAddress("川上郡標茶町開運８丁目３２"));
        }
    }
}
