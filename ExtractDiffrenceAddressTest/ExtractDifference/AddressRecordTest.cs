using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ExtractDiffrenceAddress.Models;

namespace ExtractDiffrenceAddressTest.ExtractDifference
{
    [TestClass]
    public class AddressRecordTest
    {
        [TestMethod]
        public void ToCSVTest()
        {
            var record = new AddressRecord()
            {
                IDLocation = "12345",
                Location = "東京都文京区",
                layer_code = "13",
                ADCD = "03123456789",
                Kanj_Tod = "東京都",
                Kanj_Shi = "文京区",
                Kanj_Ooa = "",
                Kanj_Aza = "",
                Address1 = "",
                X_tky = "123.4567890",
                Y_tky = "123.4567890",
                MapCode = "1234567890*12",
                X = "123.4567890",
                Y = "123.4567890",
                X_meter = "123.4567890",
                Y_meter = "123.4567890"
            };
            var value = "12345,東京都文京区,13,03123456789,東京都,文京区,,,,1234567890*12,123.4567890,123.4567890,123.4567890,123.4567890";
            Assert.AreEqual(value, record.ToCsv());
        }
    }
}
