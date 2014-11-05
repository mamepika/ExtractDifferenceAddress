using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtractDifferenceAddress.FormatAddress.Models;
using ExtractDifferenceAddress.FormatAddress.Repositories;


namespace ExtractDifferenceAddress.FormatAddress.Servicies
{
    public class LocationService
    {
        private string _dbFilePath;

        public LocationService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        public void ExportLocation()
        {
            using (var exportRepo = new ExportAddressRepository(_dbFilePath))
            {
                var records = exportRepo.FindAll();

                using (var locationRepo = new LocationRepository(_dbFilePath))
                {
                    locationRepo.Add(records);
                }
            }
        }

    }
}
