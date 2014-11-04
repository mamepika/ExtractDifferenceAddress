using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtractDiffrenceAddress.Utils;
using ExtractDiffrenceAddress.FormatAddress.Models;
using ExtractDiffrenceAddress.FormatAddress.Models.Entities;
using ExtractDiffrenceAddress.FormatAddress.Repositories;

namespace ExtractDiffrenceAddress.FormatAddress
{
    /// <summary>
    /// 住所補間ログ除去サービス
    /// </summary>
    public class RemoveFormatAddressLogService
    {
        private string _dbFilePath;

        public RemoveFormatAddressLogService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
        }

        /// <summary>
        /// 都道府県補完ログを削除する
        /// </summary>
        public void RemoveLog()
        {
            using (var formatRepo = new FormatAddressRepository(_dbFilePath,"output"))
            {
                var records = formatRepo.FindAll();

                records.ForEach(rec =>
                {
                    rec.FormatLog = rec.FormatLog.Replace("FL001:都道府県名を補完しました(" + AddressCodeUtil.GetPrefectureName(rec.AddressCode) + ") |", "");
                    rec.FormatLog = rec.FormatLog.Replace("NT001:正規化処理状況が建物名正規化処理の必要条件を満たさないので建物名正規化は行われません |", "");
                });
                using (var removeRepo = new RemoveComplementLogRepository(_dbFilePath))
                {
                    removeRepo.Add(records);
                }
            }            
        }
    }
}
