using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExtractDifferenceAddress.Category;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class LandMarkCsvReaderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var csvReader = new LandMarkCsvReader(@"C:\work\millea\01_NTT空間情報提供ファイル\02_ランドマークデータ\01.公共（01-09）.csv");

            var landMarks = csvReader.ReadFile();

            Assert.AreEqual(3539, landMarks.Count);
        }

        [TestMethod]
        public void RegisterLandMarkTest()
        {
            var service = new RegisterLandMarkService(@"C:\work\millea\01_NTT空間情報提供ファイル\02_ランドマークデータ\",@"C:\work\LandMark.db");

            service.RegisterLandMark();
        }

        [TestMethod]
        public void CountServiceTest()
        {
            var countService = new CountClassificationService(@"C:\work\LandMark.db");

            countService.Count();
        }

        [TestMethod]
        public void CategoryTest()
        {
            var csvReader = new CategoryCsvReader(@"C:\work\Category.csv");

            var categories = csvReader.ReadFile();

            using (var cateRepo = new CategoryRepository(@"C:\work\LandMark.db"))
            {
                cateRepo.Add(categories);
            }


        }
    }
}
