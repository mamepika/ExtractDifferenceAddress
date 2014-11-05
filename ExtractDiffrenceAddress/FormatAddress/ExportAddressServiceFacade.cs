using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtractDifferenceAddress.FormatAddress.Servicies;

namespace ExtractDifferenceAddress.FormatAddress
{
    /// <summary>
    /// 住所整形処理のファサードクラス
    /// </summary>
    public class ExportAddressServiceFacade
    {
        private string _dbFilePath;

        public ExportAddressServiceFacade(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }
        /// <summary>
        /// 整形した住所を出力する
        /// </summary>
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

            var locationService = new LocationService(_dbFilePath);
            locationService.ExportLocation();

            var locationAnService = new LocationAnService(_dbFilePath);
            locationAnService.ExportLocationAn();
        }
    }
}
