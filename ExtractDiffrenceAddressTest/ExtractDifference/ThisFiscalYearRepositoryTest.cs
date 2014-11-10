using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtractDifferenceAddress.Repositories;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class ThisFiscalYearRepositoryTest
    {
        private string filePath = @"C:\work\millea\06_住所比較Accessファイル\01_Hokkaido.accdb";

        [TestMethod]
        public void FindAllTest()
        {
            using (var thisRepo = new ThisFiscalYearRepository(filePath))
            {
                var addresses = thisRepo.FindAll("02_hokkaido");

                 Assert.AreEqual(363989, addresses.Count);
            }
        }
    }
}
