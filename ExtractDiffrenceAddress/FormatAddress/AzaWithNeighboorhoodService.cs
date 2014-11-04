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
    /// 字・大字除去、近傍検索を行ったレコードを抽出登録するサービスクラス
    /// </summary>
    public class AzaWithNeighboorhoodService
    {
        private string _dbFilePath;

        public AzaWithNeighboorhoodService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        /// <summary>
        /// 近傍検索付きレコードを抽出する
        /// </summary>
        public void ExtractAzaWithNeighborhood()
        {
            using (var removeLogRepo = new RemoveComplementLogRepository(_dbFilePath))
            {
                var records = removeLogRepo.FindByFormatLog();

                using (var neighRepo = new AzaWithNeighborhoodRepository(_dbFilePath))
                {
                    neighRepo.Add(records);
                }
            }
        }
    }
}
