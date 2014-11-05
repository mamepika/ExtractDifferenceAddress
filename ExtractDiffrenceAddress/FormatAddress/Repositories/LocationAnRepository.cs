using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ExtractDifferenceAddress.FormatAddress.Models.Entities;

namespace ExtractDifferenceAddress.FormatAddress.Repositories
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
            var query = "CREATE TABLE  IF NOT EXISTS " + _tableName + "(" +
                               "IDLocationAN TEXT(255)," +
                               "IDLocation TEXT(255)," +
                               "Location TEXT(255)," +
                               "IDCountry TEXT(255)," +
                               "Language TEXT(255)," +
                               "Manual TEXT(255))";
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
                               "[Manual])VALUES(" +
                               "'" + record.IDLocation + "'," +
                               "'" + record.IDLocation + "'," +
                               "'" + record.HiraCity + record.HiraTown + record.HiraChome + "'," +
                               "'1111'," +
                               "'JPN'," +
                               "'0')" ;
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
