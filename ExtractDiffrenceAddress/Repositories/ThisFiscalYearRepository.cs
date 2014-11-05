using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using ExtractDifferenceAddress.Models;

namespace ExtractDifferenceAddress.Repositories
{
    /// <summary>
    /// 今年度の住所レコード用リポジトリクラス
    /// </summary>
    public class ThisFiscalYearRepository : IDisposable
    {
        private OleDbConnection dbConnection;

        //private string _tableName;

        public ThisFiscalYearRepository(string filePath)
        {
            dbConnection = new OleDbConnection();
            dbConnection.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';";
        }
        
        /// <summary>
        /// 今年度のレコードを全件返す
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<AddressRecord> FindAll(string tableName)
        {
            var query = "SELECT * FROM " + tableName;

            using (var dbCommand = new OleDbCommand())
            {
                try
                {
                    dbConnection.Open();
                    dbCommand.CommandText = query;
                    dbCommand.Connection = dbConnection;
                    return DataReaderUtil.DataReaderToList(dbCommand.ExecuteReader());
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        public void Dispose()
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
    }
}
