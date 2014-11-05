using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ExtractDifferenceAddress.Models;

namespace ExtractDifferenceAddress.GenrateDB.Repositories
{
    public class ThisFiscalYearRepository : IDisposable
    {
        private string _filePath;

        private string _tableName;

        private OleDbConnection dbConnection;

        public ThisFiscalYearRepository(string filePath, string tableName)
        {
            _filePath = filePath;
            _tableName = tableName;
            dbConnection = new OleDbConnection();
            dbConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';";
            dbConnection.Open();
            CreateTable();
        }


        private void CreateTable()
        {
            var query = "CREATE TABLE " + _tableName +
                              "(IDLocation AUTOINCREMENT CONSTRAINT PrimaryKey PRIMARY KEY, " +
                              "Location TEXT(255)," +
                              "layer_code TEXT(255)," +
                              "ADCD TEXT(255)," +
                              "Kanj_Tod TEXT(255)," +
                              "Kanj_Shi TEXT(255)," +
                              "Kanj_Ooa TEXT(255)," +
                              "Kanj_Aza TEXT(255)," +
                              "Address1 TEXT(255)," +
                              "X_tky TEXT(255)," +
                              "Y_tky TEXT(255)," +
                              "MapCode TEXT(255)," +
                              "X TEXT(255)," +
                              "Y TEXT(255)," +
                              "X_meter TEXT(255)," +
                              "Y_meter TEXT(255))";

            ExecuteQuery(query);

            CreateIndex();

        }

        private void CreateIndex()
        {
            var query = "CREATE INDEX idxLocation ON " + _tableName + "(Location)";
            ExecuteQuery(query);
        }

        public void Add(AddressRecord record)
        {
            var query = "INSERT INTO " + _tableName + "(" +
                               "Location," +
                               "layer_code," +
                               "ADCD," +
                               "Kanj_Tod," +
                               "Kanj_Shi," +
                               "Kanj_Ooa," +
                               "Kanj_Aza," +
                               "Address1," +
                               "X_tky," +
                               "Y_tky," +
                               "MapCode," +
                               "X," +
                               "Y," +
                               "X_meter," +
                               "Y_meter) VALUES(" +
                               "'" + record.Location + "'," +
                               "'" + record.layer_code + "'," +
                               "'" + record.ADCD + "'," +
                               "'" + record.Kanj_Tod + "'," +
                               "'" + record.Kanj_Shi + "'," +
                               "'" + record.Kanj_Ooa + "'," +
                               "'" + record.Kanj_Aza + "'," +
                               "'" + record.Address1 + "'," +
                               "'" + record.X_tky + "'," +
                               "'" + record.Y_tky + "'," +
                               "'" + record.MapCode + "'," +
                               "'" + record.X + "'," +
                               "'" + record.Y + "'," +
                               "'" + record.X_meter + "'," +
                               "'" + record.Y_meter + "')";
            ExecuteQuery(query);
        }

        private void ExecuteQuery(string query)
        {
            using (var dbCommand = new OleDbCommand())
            {
                dbCommand.CommandText = query;
                dbCommand.Connection = dbConnection;
                dbCommand.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
    }
}
