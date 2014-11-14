using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using ExtractDifferenceAddress.Utils;
using ExtractDifferenceAddress.Category.Entities;

namespace ExtractDifferenceAddress.Category
{
    public class LandMarkRepository : IDisposable
    {
        private SQLiteConnection sqlConnection;

        public LandMarkRepository(string dbFilePath)
        {
            sqlConnection = DbConnectionUtil.GetDbConnection(dbFilePath);
            sqlConnection.Open();
            CreateTable();
        }

        private void CreateTable()
        {
            var query = "CREATE TABLE IF NOT EXISTS LANDMARK (" +
                              "BigClassification TEXT(20)," +
                              "MiddleClassification TEXT(20)," +
                              "SmallClassification TEXT(20)," +
                              "Name TEXT(20))";

            ExecuteQuery(query);

        }
        
        public void Add(List<LandMarkData> landMarks)
        {
            using (var transaction = sqlConnection.BeginTransaction())
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    landMarks.ForEach(land =>
                    {
                        sqlCommand.CommandText = CreateInsertQuery(land);
                        sqlCommand.ExecuteNonQuery();
                    });
                    transaction.Commit();
                }
            }
        }

        public List<LandMarkData> FindClassification()
        {
            var query = "SELECT DISTINCT BigClassification, MiddleClassification, SmallClassification FROM LANDMARK";
            var landMarks = new List<LandMarkData>();
            using (var sqlCommand = new SQLiteCommand())
            {
                sqlCommand.CommandText = query;
                sqlCommand.Connection = sqlConnection;
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var landMark = new LandMarkData() ;
                    landMark.classification.BigClassification = reader["BigClassification"].ToString();
                    landMark.classification.MiddleClassification = reader["MiddleClassification"].ToString();
                    landMark.classification.SmallClassification = reader["SmallClassification"].ToString();
                    landMarks.Add(landMark);
                }
            }
            return landMarks;
        }


        public long CountByClassification(Classification classification)
        {
            var query = "SELECT COUNT(*) FROM LANDMARK WHERE " +
                               "BigClassification = '" + classification.BigClassification + "' AND " +
                               "MiddleClassification = '" + classification.MiddleClassification + "' AND " +
                               "SmallClassification = '" + classification.SmallClassification + "';'";
            using (var sqlCommand = new SQLiteCommand())
            {
                sqlCommand.CommandText = query;
                sqlCommand.Connection = sqlConnection;
                return (long)sqlCommand.ExecuteScalar();
            }

 
        }

        private string CreateInsertQuery(LandMarkData landMark)
        {
            var query = "INSERT INTO LANDMARK (" +
                               "[BigClassification]," +
                               "[MiddleClassification]," +
                               "[SmallClassification]," +
                               "[Name] ) VALUES (" +
                               "'" + landMark.classification.BigClassification + "'," +
                               "'" + landMark.classification.MiddleClassification + "'," +
                               "'" + landMark.classification.SmallClassification + "'," +
                               "'" + landMark.Name + "')";
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
