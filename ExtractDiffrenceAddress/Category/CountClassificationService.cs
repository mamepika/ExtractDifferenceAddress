using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace ExtractDifferenceAddress.Category
{
    /// <summary>
    /// カテゴリ表の各分類のレコード数をカウントするサービスクラス
    /// </summary>
    public class CountClassificationService
    {
        private string _dbFilePath;

        public CountClassificationService(string filePath)
        {
            _dbFilePath = filePath;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Count()
        {
            using (var cateRepo = new CategoryRepository(_dbFilePath))
            {
                var classifications = cateRepo.FindAll();
                using (var writer = new StreamWriter(@"C:\work\count.txt"))
                using(var landMarkRepo = new LandMarkRepository(_dbFilePath))
                {
                    classifications.ForEach(cl =>
                    {
                        var count = landMarkRepo.CountByClassification(cl.classification);
                        writer.WriteLine(cl.classification.BigClassification + "\t" +
                                                cl.classification.MiddleClassification + "\t" +
                                                cl.classification.SmallClassification + "\t" +
                                                cl.BigClassificationName + "\t" +
                                                cl.MiddleClassificationName + "\t" +
                                                cl.SmallClassificationName + "\t" +
                                                count.ToString());
                    });
                }

            }
        }
    }
}
