using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtractDifferenceAddress.FormatAddress.Models;
using ExtractDifferenceAddress.FormatAddress.Repositories;

namespace ExtractDifferenceAddress.FormatAddress.Servicies
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

                using (var locationAnRepo = new LocationAnRepository(_dbFilePath))
                {
                    locationAnRepo.Add(records);
                }
            }
        }
    }
}
