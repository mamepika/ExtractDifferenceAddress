using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExtractDifferenceAddress.Repositories;
using ExtractDifferenceAddress.Models;
using System.Windows.Forms;

namespace ExtractDifferenceAddress.Servicies
{
    public class ExtractDifferenceService
    {
        private string _filePath;

        private Schema _schema;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath">対象アクセスファイルのファイルパス</param>
        public ExtractDifferenceService(string filePath)
        {
            _filePath = filePath;
            using (var masterRepo = new MasterRepository(filePath))
            {
                _schema = masterRepo.GetTableNames();
            }            
        }

        /// <summary>
        /// 差分を抽出する
        /// </summary>
        public void ExtractDifference()
        {
            using (var thisRepo = new ThisFiscalYearRepository(_filePath))
            {
                var thisYearRecords = thisRepo.FindAll(_schema.ThisFiscalYearTableName);

                using (var pastRepo = new PastFiscalYearRepository(_filePath,_schema.PastFiscalYearTableName))
                using (var diffRepo = new DiffrenceRepository(_filePath,_schema.DifferenceTableName))
                {
                    diffRepo.CreateTable(_schema.DifferenceTableName);
                    Parallel.ForEach(thisYearRecords, re =>
                    {
                        if (pastRepo.CountByAddress(re.Location) == 0)
                        {
                            try
                            {
                                diffRepo.Add(re);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    });
                }
            }
        }

    }
}
