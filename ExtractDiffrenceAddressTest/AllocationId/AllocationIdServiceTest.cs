using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExtractDifferenceAddress.AllocationId;

namespace ExtractDiffrenceAddressTest.AllocationId
{
    [TestClass]
    public class AllocationIdServiceTest
    {
        [TestMethod]
        public void AllocationIdServiceコンストラクタテスト()
        {
            var idService = new AllocationIdService(@"C:\work\millea\09_正規化後DBファイル\Csv");
        }

        [TestMethod]
        public void CSV作成テスト()
        {
            var idService = new AllocationIdService(@"C:\work\millea\09_正規化後DBファイル\Csv");
            idService.AllocationId(17533755);
        }

        [TestMethod]
        public void CSVマージテスト()
        {
            var mergeService = new MergeCsvService(@"C:\work\millea\09_正規化後DBファイル\Csv\csv");
            mergeService.MergeCsv();
        }
    }
}
