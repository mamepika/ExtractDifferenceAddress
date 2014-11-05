using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtractDifferenceAddress.FormatAddress.Models;
using ExtractDifferenceAddress.FormatAddress.Repositories;

namespace ExtractDifferenceAddress
{
    public class ExtractNeighborhoodService
    {
        private string _dbFilePath;

        public ExtractNeighborhoodService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        public void ExtractNeighborhood()
        {
            using (var azaWithRepo = new AzaWithNeighborhoodRepository(_dbFilePath))
            {
                var records = azaWithRepo.FindByFormatLogFl();
                using (var neighborRepo = new NeighborhoodRepository(_dbFilePath))
                {
                    neighborRepo.Add(records);
                }
            }
        }

    }
}
