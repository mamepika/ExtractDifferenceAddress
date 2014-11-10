using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtractDifferenceAddress.GenrateDB.Models;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class PastYearCsvReaderTest
    {
        [TestMethod]
        public void ReadFileTest()
        {
            var csvReader = new PastYearCsvReader(@"C:\work\millea\05_2013年度住所データ(比較用)\Fukui.txt");

            Assert.AreEqual(66263, csvReader.ReadFile().Count);
        }
    }
}
