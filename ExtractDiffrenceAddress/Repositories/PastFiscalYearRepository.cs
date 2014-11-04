using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ExtractDiffrenceAddress.Models;



namespace ExtractDiffrenceAddress.Repositories
{
    /// <summary>
    /// 過年度の住所レコード用リポジトリクラス
    /// </summary>
    public class PastFiscalYearRepository : IDisposable
    {
        
        private OleDbConnection dbConnection;
        
        private string _tableName;

        public PastFiscalYearRepository(string filePath,string tableName)
        {
            dbConnection = new OleDbConnection();
            dbConnection.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';";            
            dbConnection.Open();

            _tableName = tableName;
        }

        /// <summary>
        /// 対象の住所にマッチするレコードの件数を返す
        /// </summary>
        /// <param name="address">マッチする住所文字列</param>
        /// <returns>マッチしたレコード件数</returns>
        public int CountByAddress(string address)
        {
            var query = "SELECT count(ID) FROM " + _tableName + " WHERE Location = '" + address + "'";

            using (var command = new OleDbCommand())
            {
                command.CommandText = query;
                command.Connection = dbConnection;

                var count = (int)command.ExecuteScalar();

                return count;
            }
        }

        private void CreateIndex()
        {
            var query = "CREATE INDEX idxLocation ON " + _tableName + "(Location)";
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
