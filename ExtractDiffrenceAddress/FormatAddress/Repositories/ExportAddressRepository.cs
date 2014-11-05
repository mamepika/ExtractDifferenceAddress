using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ExtractDifferenceAddress.FormatAddress.Models.Entities;

namespace ExtractDifferenceAddress.FormatAddress.Repositories
{

    public class ExportAddressRepository : IDisposable
    {
        private SQLiteConnection sqlConnection;

        private string _tableName = "EXportAddress";

        public ExportAddressRepository(string filePath)
        {
            sqlConnection = new SQLiteConnection("Data Source=" + filePath);
            sqlConnection.Open();
            CreateTable();
        }

        private void CreateTable()
        {
            var query = "CREATE TABLE " + _tableName + "(" +
                              "IDLocation TEXT(255)," +
                              "Location TEXT(255)," +
                              "ADCD TEXT(255)," +
                              "PostalCode TEXT(255)," +
                              "MapCode TEXT(255)," +
                              "X TEXT(255)," +
                              "Y TEXT(255)," +
                              "X_meter TEXT(255)," +
                              "Y_meter TEXT(255)," +
                              "FormatedAddress TEXT(255)," +
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
        private string CreateInsertQuery(PrepareAddress address)
        {
            var query = "INSERT INTO " + _tableName + "(" +
                               "[IDLocation]," +
                               "[Location]," +
                               "[ADCD]," +
                               "[PostalCode] ," +
                               "[MapCode] ," +
                               "[X] ," +
                               "[Y] ," +
                               "[X_meter] ," +
                               "[Y_meter] ," +
                               "[FormatedAddress] ," +
                               "[ReadingCity] ," +
                               "[ReadingTown] ," +
                               "[ReadingChome] )VALUES(" +
                               "'" + address.IDLocation + "'," +
                               "'" + address.Location + "'," +
                               "'" + address.AddressCode + "'," +
                               "'" + address.PostalCode + "'," +
                               "'" + address.MapCode + "'," +
                               "'" + address.X + "'," +
                               "'" + address.Y + "'," +
                               "'" + address.X_meter + "'," +
                               "'" + address.Y_meter + "'," +
                               "'" + address.FormatedAddress + "'," +
                               "'" + address.ReadingCity + "'," +
                               "'" + address.ReadingTown + "'," +
                               "'" + address.ReadingChome + "')";
            return query;
        }

        public List<PrepareAddress> FindAll()
        {
            var query = "SELECT * FROM " + _tableName;

            using (var dbCommand = new SQLiteCommand())
            {
                dbCommand.CommandText = query;
                dbCommand.Connection = sqlConnection;
                return Convert(dbCommand.ExecuteReader());
            }
        }


        private List<PrepareAddress> Convert(SQLiteDataReader dataReader)
        {
            var records = new List<PrepareAddress>();

            while (dataReader.Read())
            {
                var record = new PrepareAddress();
                record.IDLocation = dataReader["IDLocation"].ToString();
                record.Location = dataReader["Location"].ToString();
                record.MapCode = dataReader["MapCode"].ToString();
                record.PostalCode = dataReader["PostalCode"].ToString(); 
                record.X = dataReader["X"].ToString();
                record.Y = dataReader["Y"].ToString();
                record.X_meter = dataReader["X_meter"].ToString();
                record.Y_meter = dataReader["Y_meter"].ToString();
                record.ReadingCity = dataReader["ReadingCity"].ToString();
                record.ReadingTown = dataReader["ReadingTown"].ToString();
                record.ReadingChome = dataReader["ReadingChome"].ToString();
                record.AddressCode = dataReader["ADCD"].ToString();
                record.FormatedAddress = dataReader["FormatedAddress"].ToString();
                records.Add(record);
            }
            return records;
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
