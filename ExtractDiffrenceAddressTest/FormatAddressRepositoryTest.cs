using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExtractDiffrenceAddress.FormatAddress.Repositories;

using ExtractDiffrenceAddress.GenrateDB.Repositories;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class FormatAddressRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repo = new ThisFiscalYearRepository(@"C:\01_Hokkaido.accdb","output");
        }
    }
}
