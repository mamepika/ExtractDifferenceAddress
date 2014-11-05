using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtractDiffrenceAddress.FormatAddress.Models;
using ExtractDiffrenceAddress.FormatAddress.Repositories;

namespace ExtractDiffrenceAddress.FormatAddress
{
    public class ExtractBanchiService
    {
        private string _dbFilePath;

        public ExtractBanchiService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }


        public void ExtractBanchi()
        {
            using (var neighborRepo = new NeighborhoodRepository(_dbFilePath))
            {
                var records = neighborRepo.FindAll();

                using (var extractBanchiRepo = new ExtractBanchiRepository(_dbFilePath))
                {
                    extractBanchiRepo.Add(records);
                }
            }
        }
    }
}
