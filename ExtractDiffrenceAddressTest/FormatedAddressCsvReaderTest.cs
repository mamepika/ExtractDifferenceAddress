using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExtractDifferenceAddress.FormatAddress;
using ExtractDifferenceAddress.FormatAddress.Models;
using ExtractDifferenceAddress.FormatAddress.Repositories;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class FormatedAddressCsvReaderTest
    {
        [TestMethod]
        public void ReadFileTest()
        {
            var csvReader = new FormatedAddressCsvReader(@"C:\Users\ta-satoh\Documents\08_住所正規化済CSVファイル\01_Hokkaido_output.csv");

            var records = csvReader.ReadFile();

            Assert.AreEqual(194, records.Count);

        }

    }
}
