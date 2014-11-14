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
    public class CategoryRepository : IDisposable
    {
        private SQLiteConnection sqlConnection;

        public CategoryRepository(string dbFilePath)
        {
            sqlConnection = DbConnectionUtil.GetDbConnection(dbFilePath);
            sqlConnection.Open();
            CreateTable();
        }

        private void CreateTable()
        {
            var query = "CREATE TABLE IF NOT EXISTS CATEGORY (" +
                               "BigClassification TEXT(20)," +
                               "MiddleClassification TEXT(20)," +
                               "SmallClassification TEXT(20)," +
                               "BigClassificationName TEXT(20)," +
                               "MiddleClassificationName TEXT(20)," +
                               "SmallClassificationName TEXT(20))";

            ExecuteQuery(query);
        }

        public void Add(List<CategoryInfo> categories)
        {
            using (var transaction = sqlConnection.BeginTransaction())
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    categories.ForEach(ca =>
                    {
                        sqlCommand.CommandText = CreateInsertQuery(ca);
                        sqlCommand.ExecuteNonQuery();
                    });
                    transaction.Commit();
                }
            }
        }


        public List<CategoryInfo> FindAll()
        {
            var query = "SELECT * FROM CATEGORY;";

            using (var sqlCommand = new SQLiteCommand())
            {
                sqlCommand.CommandText = query;
                sqlCommand.Connection = sqlConnection;
                return Convert(sqlCommand.ExecuteReader());
            }
        }

        private List<CategoryInfo> Convert(SQLiteDataReader dataReader)
        {
            var categories = new List<CategoryInfo>();
            while (dataReader.Read())
            {
                var cate = new CategoryInfo()
                {
                    classification = new Classification()
                    {
                        BigClassification = dataReader["BigClassification"].ToString(),
                        MiddleClassification = dataReader["MiddleClassification"].ToString(),
                        SmallClassification = dataReader["SmallClassification"].ToString(),
                    },
                    BigClassificationName = dataReader["BigClassificationName"].ToString(),
                    MiddleClassificationName = dataReader["MiddleClassificationName"].ToString(),
                    SmallClassificationName = dataReader["SmallClassificationName"].ToString()
                };                
                categories.Add(cate);
            }
            return categories;
        }

        private string CreateInsertQuery(CategoryInfo category)
        {
            var query = "INSERT INTO CATEGORY (" +
                               "[BigClassification]," +
                               "[MiddleClassification]," +
                               "[SmallClassification]," +
                               "[BigClassificationName]," +
                               "[MiddleClassificationName]," +
                               "[SmallClassificationName] ) VALUES (" +
                               "'" + category.classification.BigClassification + "'," +
                               "'" + category.classification.MiddleClassification + "'," +
                               "'" + category.classification.SmallClassification + "'," +
                               "'" + category.BigClassificationName + "'," +
                               "'" + category.MiddleClassificationName + "'," +
                               "'" + category.SmallClassificationName + "')";
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
