using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtractDiffrenceAddress.GenrateDB.Models;
using ExtractDiffrenceAddress.GenrateDB.Repositories;
using ADOX;

namespace ExtractDiffrenceAddress.GenrateDB
{
    public class GenerateDbFileService
    {
        private ProcessInfo _processInfo;

        private string _filePath;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath">生成するアクセスファイルのパス</param>
        public GenerateDbFileService(ProcessInfo info)
        {
            _processInfo = info;
            _filePath = _processInfo.OutPutFoloderPath + "\\" + _processInfo.OutPutFileName;
            ADOX.Catalog catalog = new Catalog();
            catalog.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +  _filePath + ";Jet OLEDB:Engine Type=6");
            catalog = null;
        }


        public void ReadPastYearFile()
        {
            var csvReader = new PastYearCsvReader(_processInfo.PastYearFilePath);

            var pastRecords = csvReader.ReadFile();

            using(var pastRepo =new PastFiscalYearRepository(_filePath,_processInfo.PastTableName))
            {
                pastRecords.ForEach(r =>
                {
                    pastRepo.Add(r);
                });
            }
        }

        public void ReadThisYearFile()
        {
            if (_processInfo.ThisYearFilePath.Length != 0)
            {
                var csvReader = new ThisYearCsvReader(_processInfo.ThisYearFilePath);
                var thisRecords = csvReader.ReadFile();

                using (var thisRepo = new ThisFiscalYearRepository(_filePath, _processInfo.ThisYearTableName))
                {
                    thisRecords.ForEach(r =>
                    {
                        thisRepo.Add(r);
                    });
                }
            }
            
        }
    }
}
