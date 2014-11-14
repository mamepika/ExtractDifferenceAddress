using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDifferenceAddress.Category
{
    /// <summary>
    /// ランドマークデータを登録するサービスクラス
    /// </summary>
    public class RegisterLandMarkService
    {
        private List<string> _csvFilePath;

        private string _dbFilePath;
        
        public RegisterLandMarkService(string folderPath,string dbFilePath)
        {
            _csvFilePath = System.IO.Directory.GetFiles(folderPath,"*.csv").ToList();
            _dbFilePath = dbFilePath;
        }

        public void RegisterLandMark()
        {
            _csvFilePath.ForEach(csv =>
            {
                var csvReader = new LandMarkCsvReader(csv);
                var landMarks = csvReader.ReadFile();
                using (var landMarkRepo = new LandMarkRepository(_dbFilePath))
                {
                    landMarkRepo.Add(landMarks);
                }
            });
        }
    }
}
