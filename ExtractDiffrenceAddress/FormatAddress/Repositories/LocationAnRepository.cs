using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ExtractDiffrenceAddress.FormatAddress.Models.Entities;

namespace ExtractDiffrenceAddress.FormatAddress.Repositories
{
    public class LocationAnRepository : IDisposable
    {
        private SQLiteConnection sqlConnection;

        private string _tableName = "LocationAN";

        public LocationAnRepository(string filePath)
        {
            sqlConnection = new SQLiteConnection("Data Source=" + filePath);
            sqlConnection.Open();
            CreateTable();
        }

        public void CreateTable()
        {
            var query = "CREATE TABLE " + _tableName + "(" +
                               "IDLocationAN TEXT(255)," +
                               "IDLocation TEXT(255)," +
                               "Location TEXT(255)," +
                               "IDCountry TEXT(255)," +
                               "Language TEXT(255)," +
                               "Manual TEXT(255)," +
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
                               "ReadingCity TEXT(255)," +
                               "ReadingTown TEXT(255)," +
                               "ReadingChome TEXT(255))";
            try
            {
                ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Add(List<PrepareAddress> addresses)
        {
            using (var transaction = sqlConnection.BeginTransaction())
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    addresses.ForEach(rec =>
                    {
                        sqlCommand.CommandText = CreateInsertQuery(rec);
                        sqlCommand.ExecuteNonQuery();
                    });
                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// インサート用のクエリーを作成する
        /// </summary>
        /// <param name="record">インサートするレコード</param>
        /// <returns></returns>
        private string CreateInsertQuery(PrepareAddress record)
        {
            var query = "INSERT INTO " + _tableName + "(" +
                               "[IDLocationAN]," +
                               "[IDLocation]," +
                               "[Location]," +
                               "[IDCountry]," +
                               "[Language]," +
                               "[Manual]," +
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
                               "[ReadingCity] ," +
                               "[ReadingTown] ," +
                               "[ReadingChome])VALUES(" +
                               "'" + record.IDLocation + "'," +
                               "'" + record.IDLocation + "'," +
                               "'" + record.HiraCity + record.HiraTown + record.HiraTown + "'," +
                               "'1111'," +
                               "'JPN'," +
                               "'0'," +
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
                               "'" + record.ReadingCity + "'," +
                               "'" + record.ReadingTown + "'," +
                               "'" + record.ReadingChome + "')";
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
