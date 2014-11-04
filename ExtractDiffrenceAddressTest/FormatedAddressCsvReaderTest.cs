using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExtractDiffrenceAddress.FormatAddress;
using ExtractDiffrenceAddress.FormatAddress.Models;
using ExtractDiffrenceAddress.FormatAddress.Repositories;

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

        [TestMethod]
        public void ファイル読込と登録()
        {
            var service = new FormatAddressRegisterService(@"C:\01_Hokkaido.accdb");

            //service.ReadFile(@"C:\Users\ta-satoh\Documents\08_住所正規化済CSVファイル\01_Hokkaido_output.csv");
        }
    }
}
