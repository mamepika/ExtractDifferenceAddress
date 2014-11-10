using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtractDifferenceAddress.Repositories;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class MasterRepositoryTest
    {
        [TestMethod]
        public void GetTableNamesTest()
        {
            var masterRepo = new MasterRepository(@"C:\work\millea\06_住所比較Accessファイル\01_Hokkaido.accdb");

            masterRepo.GetTableNames();
        }
    }
}
