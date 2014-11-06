using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ExtractDifferenceAddress.FormatAddress.Csv.Models;

namespace ExtractDifferenceAddress.FormatAddress.Csv
{
    /// <summary>
    /// 住所整形済みのレコードをCSVに出力するサービスクラス
    /// </summary>
    public class CreateLocationCsvService
    {
        private string _dbFilePath;

        private string _outputFilePath;

        private Encoding encode = System.Text.Encoding.GetEncoding("Shift_Jis");

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dbFilePath">対象のDBファイルのパス</param>
        public CreateLocationCsvService(string dbFilePath)
        {
            _dbFilePath = dbFilePath;
            _outputFilePath = System.IO.Path.GetDirectoryName(_dbFilePath) + 
                                          "\\Csv\\" +  Path.GetFileNameWithoutExtension(_dbFilePath);
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_dbFilePath) + "\\Csv\\");
        }

        /// <summary>
        /// Location・LocationANのCSVファイルを出力する
        /// </summary>
        public void CreateCsvFile()
        {
            try
            {
                using (var locationCsvRepo = new LocationCsvRepository(_dbFilePath))
                {
                    var locationRecords = locationCsvRepo.FindLocation("output");

                    var locationAnRecords = locationCsvRepo.FindLocationAn("output");

                    if (locationCsvRepo.IsExists("Location"))
                    {
                        locationRecords.Concat(locationCsvRepo.FindLocation("Location"));
                    }

                    if (locationCsvRepo.IsExists("LocationAN"))
                    {
                        locationAnRecords.Concat(locationCsvRepo.FindLocationAn("LocationAN"));
                    }
                    CreateLocationCsvFile(locationRecords);                  
                    CreateLocationAnCsvFile(locationAnRecords);
                }
            }
            catch (Exception)
            {
                //TODO 取り敢えずテーブルなし例外は無視して次に
            }          
        }

        /// <summary>
        /// Location情報をCSVに出力する
        /// </summary>
        /// <param name="records"></param>
        private void CreateLocationCsvFile(List<LocationRecord> records)
        {
            using (var writer = new StreamWriter(_outputFilePath + "_Location.csv", true, encode))
            {
                
                writer.WriteLine("IDLocation,Location,IDCountry,IDTown,PostalCode,MapCode,X_meter,Y_meter,IDLocationManual,X,Y");
                records.ForEach(re => writer.WriteLine(re.ToCsv()));
            }
        }

        /// <summary>
        /// LocationAN情報をCSVに出力する
        /// </summary>
        /// <param name="records"></param>
        private void CreateLocationAnCsvFile(List<LocationAnRecord> anRecords)
        {
            using (var writer = new StreamWriter(_outputFilePath + "_LocationAN.csv", true, encode))
            {
                
                writer.WriteLine("IDLocationAN,IDLocation,Location,IDCountry,Language,Manual");
                anRecords.ForEach(re => writer.WriteLine(re.ToCsv()));
            }
        }
    }
}
