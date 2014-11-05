using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtractDiffrenceAddress.FormatAddress.Servicies;

namespace ExtractDiffrenceAddress.FormatAddress
{
    public class ExportAddressServiceFacade
    {
        private string _dbFilePath;

        public ExportAddressServiceFacade(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        public void ExportAddress()
        {
            var formatService = new RemoveFormatAddressLogService(_dbFilePath);
            formatService.RemoveLog();

            var neighService = new AzaWithNeighboorhoodService(_dbFilePath);
            neighService.ExtractAzaWithNeighborhood();

            var extractService = new ExtractAzaRemoveService(_dbFilePath);
            extractService.ExtractAzaRemove();

            var neighborService = new ExtractNeighborhoodService(_dbFilePath);
            neighborService.ExtractNeighborhood();

            var banchiService = new ExtractBanchiService(_dbFilePath);
            banchiService.ExtractBanchi();

            var prepareService = new PrepareAddressService(_dbFilePath);
            prepareService.PrepareAddress();

            var exportService = new ExportAddressService(_dbFilePath);
            exportService.ExportAddress();

            var locationService = new LocationAnService(_dbFilePath);
            locationService.ExportLocationAn();
        }
    }
}
