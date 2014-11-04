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
    public class MasterRepository : IDisposable
    {
        private OleDbConnection dbConnection;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath">処理対象のアクセスファイルのパス</param>
        public MasterRepository(string filePath)
        {
            dbConnection = new OleDbConnection();
            dbConnection.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';";            
        }

        /// <summary>
        /// アクセスファイル内のテーブル名を取得する
        /// </summary>
        /// <returns>"00_" or "02_"で始まるテーブル名</returns>
        public Schema GetTableNames()
        {
            var tableNames = new Schema();
            try
            {
                dbConnection.Open();
                DataTable dataTable = new DataTable();
                dataTable = dbConnection.GetSchema("Tables",new string[4]{null,null,null,"TABLE"});

                foreach (DataRow row in dataTable.Rows)
                {
                    tableNames.AddTableName(row["TABLE_NAME"].ToString());
                }

                return tableNames;
            }
            finally
            {
                dbConnection.Close();
            }

        }

        public void Dispose()
        {
            dbConnection.Close();
            dbConnection.Dispose();
        }
    }
}
