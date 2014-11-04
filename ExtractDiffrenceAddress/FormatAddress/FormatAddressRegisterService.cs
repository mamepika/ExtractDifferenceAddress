using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtractDiffrenceAddress.FormatAddress.Models;
using ExtractDiffrenceAddress.FormatAddress.Repositories;


namespace ExtractDiffrenceAddress.FormatAddress
{
    /// <summary>
    /// 正規化済の住所レコードを登録するサービスクラス
    /// </summary>
    public class FormatAddressRegisterService
    {
        private string _csvFilePath;

        private string _dbFilePath;

        public FormatAddressRegisterService(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
            _dbFilePath = System.IO.Path.GetDirectoryName(_csvFilePath) + "\\ "+ System.IO.Path.GetFileNameWithoutExtension(_csvFilePath) + ".db";
        }

        public void ReadFile()
        {
            var csvReader = new FormatedAddressCsvReader(_csvFilePath);

            var records = csvReader.ReadFile();
            
            using (var formatAddressRepo = new FormatAddressRepository(_dbFilePath,"output"))
            {
                formatAddressRepo.CreateTable();
                formatAddressRepo.Add(records,"output");           
                
            }
        }
    }
}
