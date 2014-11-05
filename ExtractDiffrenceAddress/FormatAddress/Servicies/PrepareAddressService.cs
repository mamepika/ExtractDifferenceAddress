using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtractDiffrenceAddress.FormatAddress.Models;
using ExtractDiffrenceAddress.FormatAddress.Repositories;

namespace ExtractDiffrenceAddress.FormatAddress.Servicies
{
    public class PrepareAddressService
    {
        private string _dbFilePath;

        public PrepareAddressService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }


        public void PrepareAddress()
        {
            using (var azaRemoveRepo = new ExtractAzaRemoveRepository(_dbFilePath))
            {
                var records = azaRemoveRepo.FindAll();

                using (var prepareAddressRepo = new PrepareAddressRepository(_dbFilePath, "output6"))
                {
                    prepareAddressRepo.Add(records);
                }
            }

            using (var extractBanchiRepo = new ExtractBanchiRepository(_dbFilePath))
            {
                var records = extractBanchiRepo.FindAll();

                using (var prepareAddressRepo = new PrepareAddressRepository(_dbFilePath, "output7"))
                {
                    prepareAddressRepo.Add(records);
                }
            }
        }
    }
}
