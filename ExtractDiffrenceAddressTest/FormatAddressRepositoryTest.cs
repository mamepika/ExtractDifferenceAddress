using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExtractDifferenceAddress.FormatAddress.Repositories;
using ExtractDifferenceAddress.Utils;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class FormatAddressRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repo = new NeighborhoodRepository(@"C:\work\03_Iwate_output.db");

            var records = repo.FindAll();

            //var banchi = AddressCodeUtil.GetBanchi(records[0].FormatLog);


            records.ForEach(x => Console.WriteLine(x.ExtractedBanchi));

            Console.WriteLine("");
        }


    }
}
