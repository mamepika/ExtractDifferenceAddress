using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtractDiffrenceAddress.Repositories;
using ExtractDiffrenceAddress.Models;

namespace ExtractDiffrenceAddressTest
{
    [TestClass]
    public class DiffrenceRepositoryTest
    {

        private string filePath = @"C:\work\millea\06_住所比較Accessファイル\01_Hokkaido.accdb";

        
        public void CreateTableTest()
        {
            var diffrenceRepo = new DiffrenceRepository(filePath,"03_hokkaido");

            diffrenceRepo.CreateTable("03_Test");

        }

        
        public void AddTest()
        {

            var diffenceRepo = new DiffrenceRepository(filePath,"03_Test");

            var address = new AddressRecord();
            address.Location = "練馬区旭町２";

            diffenceRepo.Add(address);
        }
    }
}
