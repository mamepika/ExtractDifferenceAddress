using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtractDifferenceAddress.Models;


namespace ExtractDiffrenceAddressTest.ExtractDifference
{
    [TestClass]
    public class SchemaTest
    {
        [TestMethod]
        public void 過年度テーブル名は00_で始まる()
        {
            var schema = new Schema();
            schema.AddTableName("00_過年度テーブル");

            Assert.AreEqual("00_過年度テーブル", schema.PastFiscalYearTableName);
        }

        [TestMethod]
        public void 今年度テーブル名は02_で始まる()
        {
            var schema = new Schema();
            schema.AddTableName("02_今年度テーブル");

            Assert.AreEqual("02_今年度テーブル", schema.ThisFiscalYearTableName);
        }

        [TestMethod]
        public void 差分用テーブル名は過年度テーブル名と03_で始まる()
        {
            var schema = new Schema();
            schema.AddTableName("00_過年度テーブル");

            Assert.AreEqual("03_過年度テーブル", schema.DifferenceTableName);
        }
    }
}
