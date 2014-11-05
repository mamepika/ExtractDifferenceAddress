using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExtractDifferenceAddress.Repositories;
using ExtractDifferenceAddress.Models;

namespace ExtractDifferenceAddress.Servicies
{
    public class GenerateCsvFileService
    {
        private string _dBFilePath;
        private string _dBFileName;
        private string _csvFolderPath;
        private Schema _schema;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dbFilePath">処理対象のアクセスファイルのパス</param>
        public GenerateCsvFileService(string dbFilePath)
        {
            _dBFilePath = dbFilePath;
            _dBFileName = Path.GetFileNameWithoutExtension(_dBFilePath);

            using (var masterRepo = new MasterRepository(dbFilePath))
            {
                _schema = masterRepo.GetTableNames();
            }
            _csvFolderPath = Path.GetDirectoryName(dbFilePath) + "\\CSV";
            Directory.CreateDirectory(_csvFolderPath);
        }

        /// <summary>
        /// CSVファイルを作成する
        /// </summary>
        public void GenerateCsvFile()
        {
            using (var diffRepo = new DiffrenceRepository(_dBFilePath, _schema.DifferenceTableName))
            {
                var diffrenceRecords = diffRepo.FindAll();
                using (var streamWriter = new StreamWriter(_csvFolderPath + "\\" +_dBFileName + ".csv"))
                {
                    //CSVのヘッダーを出力
                    streamWriter.WriteLine("IDLocation,Location,layer_code,ADCD,Kanj_Tod,Kanj_Shi,Kanj_Ooa,Kanj_Aza,Address1,MapCode,X,Y,X_meter,Y_meter");
                    diffrenceRecords.ForEach(x =>
                    {
                        streamWriter.WriteLine(x.ToCsv());
                    });
                }
            }
        }
    }
}
