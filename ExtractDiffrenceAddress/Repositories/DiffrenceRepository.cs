using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using ExtractDifferenceAddress.Models;

namespace ExtractDifferenceAddress.Repositories
{
    public class DiffrenceRepository : IDisposable
    {
        private OleDbConnection dbConnection;

        private string _tableName;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath">処理対象のアクセスファイルのパス</param>
        /// <param name="tableName">テーブル名</param>
        public DiffrenceRepository(string filePath,string tableName)
        {
            dbConnection = new OleDbConnection();
            dbConnection.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';";            
            dbConnection.Open();            
            _tableName = tableName;
        }

        /// <summary>
        /// 差分レコード格納用のテーブルを作成する
        /// </summary>
        /// <param name="tableName">作成するテーブル名</param>
        public void CreateTable(string tableName)
        {
            _tableName = tableName;

            var query = "CREATE TABLE " + tableName +
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
        }

        /// <summary>
        /// 差分を追加する
        /// </summary>
        /// <param name="addressRecord">追加するレコード</param>
        public void Add(AddressRecord addressRecord)
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
                            "Y_meter)" +
                            "VALUES(" +
                            "'" + addressRecord.Location + "'," +
                            "'" + addressRecord.layer_code + "'," +
                            "'" + addressRecord.ADCD + "'," +
                            "'" + addressRecord.Kanj_Tod + "'," +
                            "'" + addressRecord.Kanj_Shi + "'," +
                            "'" + addressRecord.Kanj_Ooa + "'," +
                            "'" + addressRecord.Kanj_Aza + "'," +
                            "'" + addressRecord.Address1 + "'," +
                            "'" + addressRecord.X_tky + "'," +
                            "'" + addressRecord.Y_tky + "'," +
                            "'" + addressRecord.MapCode + "'," +
                            "'" + addressRecord.X + "'," +
                            "'" + addressRecord.Y + "'," +
                            "'" + addressRecord.X_meter + "'," +
                            "'" + addressRecord.Y_meter + "')";
            ExecuteQuery(query);              
        }

        /// <summary>
        /// 差分レコードの全件を取得する
        /// </summary>
        /// <returns>差分レコードの全件</returns>
        public List<AddressRecord> FindAll()
        {
            var query = "SELECT * FROM " + _tableName;

            using (var dbCommand = new OleDbCommand())
            {
                try
                {
                    dbCommand.CommandText = query;
                    dbCommand.Connection = dbConnection;
                    return DataReaderToList(dbCommand.ExecuteReader());
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        /// <summary>
        /// OleDbDataReaderをList形式に変換する
        /// </summary>
        /// <param name="dataReader">処理対象のDataReaderインスタンス</param>
        /// <returns></returns>
        private List<AddressRecord> DataReaderToList(OleDbDataReader dataReader)
        {
            var addressRecords = new List<AddressRecord>();

            while (dataReader.Read())
            {
                var address = new AddressRecord();
                address.IDLocation = dataReader["IDLocation"].ToString();
                address.Location = dataReader["Location"].ToString();
                address.layer_code = dataReader["layer_code"].ToString();
                address.ADCD = dataReader["ADCD"].ToString();
                address.Kanj_Tod = dataReader["Kanj_Tod"].ToString();
                address.Kanj_Shi = dataReader["Kanj_Shi"].ToString();
                address.Kanj_Ooa = dataReader["Kanj_Ooa"].ToString();
                address.Kanj_Aza = dataReader["Kanj_Aza"].ToString();
                address.Address1 = dataReader["Address1"].ToString();
                address.X_tky = dataReader["X_tky"].ToString();
                address.Y_tky = dataReader["Y_tky"].ToString();
                address.MapCode = dataReader["MapCode"].ToString();
                address.X = dataReader["X"].ToString();
                address.Y = dataReader["Y"].ToString();
                address.X_meter = dataReader["X_meter"].ToString();
                address.Y_meter = dataReader["Y_meter"].ToString();

                addressRecords.Add(address);
            }
            return addressRecords;
        }

        /// <summary>
        /// クエリを実行する
        /// </summary>
        /// <param name="query">実行するクエリ</param>
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
