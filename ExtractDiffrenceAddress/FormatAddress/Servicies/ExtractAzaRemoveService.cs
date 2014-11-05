using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtractDifferenceAddress.FormatAddress.Models;
using ExtractDifferenceAddress.FormatAddress.Repositories;


namespace ExtractDifferenceAddress.FormatAddress.Servicies
{
    /// <summary>
    /// 字・大字除去処理済みレコード抽出サービスクラス
    /// </summary>
    public class ExtractAzaRemoveService
    {
        private string _dbFilePath;

        public ExtractAzaRemoveService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        public void ExtractAzaRemove()
        {
            using(var neighborRepo = new AzaWithNeighborhoodRepository(_dbFilePath))
            {
                var records = neighborRepo.FindByFormatLogRm();

                using (var extractRepo = new ExtractAzaRemoveRepository(_dbFilePath))
                {
                    extractRepo.Add(records);
                }
            }
        }
    }
}
