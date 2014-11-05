using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ExtractDifferenceAddress.FormatAddress.Models.Entities;

namespace ExtractDifferenceAddress.FormatAddress.Repositories
{
    /// <summary>
    /// 字・大字除去、近傍検索抽出レコードリポジトリ
    /// </summary>
    public class AzaWithNeighborhoodRepository : IDisposable
    {
        private SQLiteConnection sqlConnection;

        private string _tableName = "output2";


        public AzaWithNeighborhoodRepository(string filePath)
        {
            sqlConnection = new SQLiteConnection("Data Source=" + filePath);
            sqlConnection.Open();
            CreateTable();
        }

        private void CreateTable()
        {
            var query = "CREATE TABLE IF NOT EXISTS " + _tableName + "(" +
                              "ID TEXT(255) PRIMARY KEY," +
                              "IDLocation TEXT(255)," +
                              "Location TEXT(255)," +
                              "layer_code TEXT(255)," +
                              "ADCD TEXT(255)," +
                              "Kanj_Tod TEXT(255)," +
                              "Kanj_Shi TEXT(255)," +
                              "Kanj_Ooa TEXT(255)," +
                              "Kanj_Aza TEXT(255)," +
                              "Address1 TEXT(255)," +
                              "MapCode TEXT(255)," +
                              "X TEXT(255)," +
                              "Y TEXT(255)," +
                              "X_meter TEXT(255)," +
                              "Y_meter TEXT(255)," +
                              "AddressCode TEXT(255)," +
                              "PostalCode TEXT(255)," +
                              "AddedPrefectureName TEXT(255)," +
                              "AddedCityName TEXT(255)," +
                              "AddedTownName TEXT(255)," +
                              "AddedChome TEXT(255)," +
                              "AddedBanchi TEXT(255)," +
                              "BuildingName TEXT(255)," +
                              "ReadingPrefecture TEXT(255)," +
                              "ReadingCity TEXT(255)," +
                              "ReadingTown TEXT(255)," +
                              "ReadingChome TEXT(255)," +
                              "BuildingFloor TEXT(255)," +
                              "CantFormat TEXT(255)," +
                              "FormatLog TEXT(255)," +
                              "FormatedAddress TEXT(255))";
            try
            {
                ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        /// <summary>
        /// RM002、RM003ログのレコードを取得する
        /// </summary>
        /// <returns></returns>
        public List<FormatedAddressRecord> FindByFormatLogRm()
        {
            var query = "SELECT * FROM " + _tableName +
                               " WHERE [FormatLog] = ' RM002:[大字(字)]の文字を除去しました |' OR [FormatLog] = ' RM003:[小字(字)]の文字を除去しました |'";

            using (var dbCommand = new SQLiteCommand())
            {
                dbCommand.CommandText = query;
                dbCommand.Connection = sqlConnection;
                return Convert(dbCommand.ExecuteReader());
            }
        }
        /// <summary>
        /// FL00のログのレコードを取得する
        /// </summary>
        /// <returns></returns>
        public List<FormatedAddressRecord> FindByFormatLogFl()
        {
            var query = "SELECT * FROM " + _tableName +
                              " WHERE [FormatLog] LIKE '%FL00%'";
            using (var dbCommand = new SQLiteCommand())
            {
                dbCommand.CommandText = query;
                dbCommand.Connection = sqlConnection;
                return Convert(dbCommand.ExecuteReader());
            }
        }

        private List<FormatedAddressRecord> Convert(SQLiteDataReader dataReader)
        {
            var records = new List<FormatedAddressRecord>();

            while (dataReader.Read())
            {
                var record = new FormatedAddressRecord();
                record.IDLocation = dataReader["IDLocation"].ToString();
                record.Location = dataReader["Location"].ToString();
                record.layer_code = dataReader["layer_code"].ToString();
                record.ADCD = dataReader["ADCD"].ToString();
                record.Kanj_Tod = dataReader["Kanj_Tod"].ToString();
                record.Kanj_Shi = dataReader["Kanj_Shi"].ToString();
                record.Kanj_Ooa = dataReader["Kanj_Ooa"].ToString();
                record.Kanj_Aza = dataReader["Kanj_Aza"].ToString();
                record.Address1 = dataReader["Address1"].ToString();
                record.MapCode = dataReader["MapCode"].ToString();
                record.X = dataReader["X"].ToString();
                record.Y = dataReader["Y"].ToString();
                record.X_meter = dataReader["X_meter"].ToString();
                record.Y_meter = dataReader["Y_meter"].ToString();
                record.AddressCode = dataReader["AddressCode"].ToString();
                record.PostalCode = dataReader["PostalCode"].ToString();
                record.AddedPrefectureName = dataReader["AddedPrefectureName"].ToString();
                record.AddedCityName = dataReader["AddedCityName"].ToString();
                record.AddedTownName = dataReader["AddedTownName"].ToString();
                record.AddedChome = dataReader["AddedChome"].ToString();
                record.AddedBanchi = dataReader["AddedBanchi"].ToString();
                record.BuildingName = dataReader["BuildingName"].ToString();
                record.ReadingPrefecture = dataReader["ReadingPrefecture"].ToString();
                record.ReadingCity = dataReader["ReadingCity"].ToString();
                record.ReadingTown = dataReader["ReadingTown"].ToString();
                record.ReadingChome = dataReader["ReadingChome"].ToString();
                record.BuildingFloor = dataReader["BuildingFloor"].ToString();
                record.CantFormat = dataReader["CantFormat"].ToString();
                record.FormatLog = dataReader["FormatLog"].ToString();
                record.FormatedAddress = dataReader["FormatedAddress"].ToString();
                records.Add(record);

            }
            return records;
        }


        /// <summary>
        /// レコードを追加する
        /// </summary>
        /// <param name="records"></param>
        public void Add(List<FormatedAddressRecord> records)
        {
            using (var transaction = sqlConnection.BeginTransaction())
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    records.ForEach(rec =>
                    {
                        sqlCommand.CommandText = CreateInsertQuery(rec);
                        sqlCommand.ExecuteNonQuery();
                    });
                    transaction.Commit();
                }
            }
        }

        private string CreateInsertQuery(FormatedAddressRecord record)
        {
            var query = "INSERT INTO " + _tableName + "(" +
                   "[IDLocation]," +
                   "[Location]," +
                   "[layer_code]," +
                   "[ADCD] ," +
                   "[Kanj_Tod] ," +
                   "[Kanj_Shi] ," +
                   "[Kanj_Ooa] ," +
                   "[Kanj_Aza] ," +
                   "[Address1] ," +
                   "[MapCode] ," +
                   "[X] ," +
                   "[Y] ," +
                   "[X_meter] ," +
                   "[Y_meter] ," +
                   "[AddressCode] ," +
                   "[PostalCode] ," +
                   "[AddedPrefectureName] ," +
                   "[AddedCityName] ," +
                   "[AddedTownName] ," +
                   "[AddedChome] ," +
                   "[AddedBanchi] ," +
                   "[BuildingName] ," +
                   "[ReadingPrefecture] ," +
                   "[ReadingCity] ," +
                   "[ReadingTown] ," +
                   "[ReadingChome] ," +
                   "[BuildingFloor] ," +
                   "[CantFormat] ," +
                   "[FormatLog] ," +
                   "[FormatedAddress] )VALUES(" +
                   "'" + record.IDLocation + "'," +
                   "'" + record.Location + "'," +
                   "'" + record.layer_code + "'," +
                   "'" + record.ADCD + "'," +
                   "'" + record.Kanj_Tod + "'," +
                   "'" + record.Kanj_Shi + "'," +
                   "'" + record.Kanj_Ooa + "'," +
                   "'" + record.Kanj_Aza + "'," +
                   "'" + record.Address1 + "'," +
                   "'" + record.MapCode + "'," +
                   "'" + record.X + "'," +
                   "'" + record.Y + "'," +
                   "'" + record.X_meter + "'," +
                   "'" + record.Y_meter + "'," +
                   "'" + record.AddressCode + "'," +
                   "'" + record.PostalCode + "'," +
                   "'" + record.AddedPrefectureName + "'," +
                   "'" + record.AddedCityName + "'," +
                   "'" + record.AddedTownName + "'," +
                   "'" + record.AddedChome + "'," +
                   "'" + record.AddedBanchi + "'," +
                   "'" + record.BuildingName + "'," +
                   "'" + record.ReadingPrefecture + "'," +
                   "'" + record.ReadingCity + "'," +
                   "'" + record.ReadingTown + "'," +
                   "'" + record.ReadingChome + "'," +
                   "'" + record.BuildingFloor + "'," +
                   "'" + record.CantFormat + "'," +
                   "'" + record.FormatLog + "'," +
                   "'" + record.FormatedAddress + "');";
            return query;
        }

        private void ExecuteQuery(string query)
        {
            using (var dbCommand = new SQLiteCommand())
            {
                dbCommand.CommandText = query;
                dbCommand.Connection = sqlConnection;
                dbCommand.ExecuteNonQuery();
            }
        }
        public void Dispose()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
    }
}
