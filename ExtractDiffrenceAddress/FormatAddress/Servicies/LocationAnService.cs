using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtractDiffrenceAddress.FormatAddress.Models;
using ExtractDiffrenceAddress.FormatAddress.Repositories;

namespace ExtractDiffrenceAddress.FormatAddress.Servicies
{
    public class LocationAnService
    {
        private string _dbFilePath;

        public LocationAnService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        public void ExportLocationAn()
        {
            using (var exportRepo = new ExportAddressRepository(_dbFilePath))
            {
                var records = exportRepo.FindAll();

                using (var locationRepo = new LocationAnRepository(_dbFilePath))
                {
                    locationRepo.Add(records);
                }
            }
        }
    }
}
