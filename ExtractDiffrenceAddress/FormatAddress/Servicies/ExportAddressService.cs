using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ExtractDiffrenceAddress.FormatAddress.Models;
using ExtractDiffrenceAddress.FormatAddress.Repositories;

namespace ExtractDiffrenceAddress.FormatAddress.Servicies
{
    public class ExportAddressService
    {

        private string _dbFilePath;

        public ExportAddressService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        public void ExportAddress()
        {
            using (var prepareRepo = new PrepareAddressRepository(_dbFilePath))
            {
                var records = prepareRepo.FindByUnion();

                using (var exportRepo = new ExportAddressRepository(_dbFilePath))
                {
                    exportRepo.Add(records);
                }
            }
        }
    }
}
