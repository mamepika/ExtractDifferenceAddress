using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ExtractDiffrenceAddress.FormatAddress.Models.Entities;

namespace ExtractDiffrenceAddress.FormatAddress.Repositories
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
        private string CreateInsertQuery(PrepareAddress address)
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
                   "[ReadingCity] ," +
                   "[ReadingTown] ," +
                   "[ReadingChome] )VALUES(" +
                   "'" + address.IDLocation + "'," +
                   "'" + address.Location + "'," +
                   "'" + address.layer_code + "'," +
                   "'" + address.ADCD + "'," +
                   "'" + address.Kanj_Tod + "'," +
                   "'" + address.Kanj_Shi + "'," +
                   "'" + address.Kanj_Ooa + "'," +
                   "'" + address.Kanj_Aza + "'," +
                   "'" + address.Address1 + "'," +
                   "'" + address.MapCode + "'," +
                   "'" + address.X + "'," +
                   "'" + address.Y + "'," +
                   "'" + address.X_meter + "'," +
                   "'" + address.Y_meter + "'," +
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
                record.ReadingCity = dataReader["ReadingCity"].ToString();
                record.ReadingTown = dataReader["ReadingTown"].ToString();
                record.ReadingChome = dataReader["ReadingChome"].ToString();
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
