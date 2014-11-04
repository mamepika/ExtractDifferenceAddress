using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Threading.Tasks;

using ExtractDiffrenceAddress.GenrateDB.Models.Entities;

namespace ExtractDiffrenceAddress.GenrateDB.Repositories
{
    public class PastFiscalYearRepository : IDisposable
    {
        private string _filePath;

        private string _tableName;

        private OleDbConnection dbConnection;

        public PastFiscalYearRepository(string filePath,string tableName)
        {
            _filePath = filePath;
            _tableName = tableName;
            dbConnection = new OleDbConnection();
            dbConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';";
            dbConnection.Open();
            CreateTable();
        }


        public void Add(PastFiscalYearAddressRecord record)
        {
            var query = "INSERT INTO " + _tableName + "(" +
                               "Location," +
                               "IDCountry," +
                               "IDTown," +
                               "PostalCode," +
                               "MapCode," +
                               "X_meter," +
                               "Y_meter," +
                               "IDLocationManual," +
                               "X," +
                               "Y) VALUES(" +
                               "'" + record.Location + "'," +
                               "'" + record.IDCountry + "'," +
                               "'" + record.IDTown + "'," +
                               "'" + record.PostalCode + "'," +
                               "'" + record.MapCode + "'," +
                               "'" + record.X_meter + "'," +
                               "'" + record.Y_meter + "'," +
                               "'" + record.IDLocationManual + "'," +
                               "'" + record.X + "'," +
                               "'" + record.Y + "')";
            ExecuteQuery(query);             
        }


        private void CreateTable()
        {
            var query = "CREATE TABLE " + _tableName +
                              "(IDLocation AUTOINCREMENT CONSTRAINT PrimaryKey PRIMARY KEY, " +
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

            ExecuteQuery(query);
            CreateIndex();
               
        }

        private void CreateIndex()
        {
            var query = "CREATE INDEX idxLocation ON " + _tableName + "(Location)";
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
