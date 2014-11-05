using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ExtractDifferenceAddress.FormatAddress.Models.Entities;


namespace ExtractDifferenceAddress.FormatAddress.Repositories
{
    public class LocationRepository : IDisposable
    {
        private SQLiteConnection sqlConnection;

        private string _tableName = "Location";

        public LocationRepository(string filePath)
        {
            sqlConnection = new SQLiteConnection("Data Source=" + filePath);
            sqlConnection.Open();
            CreateTable();
        }


        public void CreateTable()
        {
            var query = "CREATE TABLE  IF NOT EXISTS " + _tableName + "(" +
                               "IDLocation TEXT(255)," +
                               "Location TEXT(255)," +
                               "IDCountry TEXT(255)," +
                               "IDTown TEXT(255)," +
                               "PostalCode TEXT(255)," +
                               "MapCode TEXT(255)," +
                               "X_meter TEXT(255)," +
                               "Y_meter TEXT(255)," +
                               "IDLocationManual TEXT(255)," +
                               "X TEXT(255)," +
                               "Y TEXT(255))";
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
        private string CreateInsertQuery(PrepareAddress record)
        {
            var query = "INSERT INTO " + _tableName + "(" +
                                "[IDLocation]," +
                                "[Location]," +
                                "[IDCountry] ," +
                                "[IDTown] ," +
                                "[PostalCode] ," +
                                "[MapCode] ," +
                                "[X_meter] ," +
                                "[Y_meter] ," +
                                "[IDLocationManual] ," +
                                "[X] ," +
                                "[Y] )VALUES(" +
                                "'" + record.IDLocation + "'," +
                                "'" + record.FormatedAddress.Replace(Utils.AddressCodeUtil.GetPrefectureName(record.AddressCode),"") + "'," +
                                "'" + "1111" + "'," +
                                "'" + record.IDTown + "'," +
                                "'" + record.PostalCode + "'," +
                                "'" + record.MapCode + "'," +
                                "'" + record.X_meter + "'," +
                                "'" + record.Y_meter + "'," +
                                "'" + "" + "'," +
                                "'" + record.X + "'," +
                                "'" + record.Y + "');";
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
