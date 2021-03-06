﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ExtractDifferenceAddress.FormatAddress.Models.Entities;

namespace ExtractDifferenceAddress.FormatAddress.Repositories
{
    /// <summary>
    /// 住所整形レコードのリポジトリクラス
    /// </summary>
    public class PrepareAddressRepository : IDisposable
    {
        private SQLiteConnection sqlConnection;

        private string _tableName;

        public PrepareAddressRepository(string filePath,string tableName)
        {
            _tableName = tableName;
            sqlConnection = new SQLiteConnection("Data Source=" + filePath);
            sqlConnection.Open();
            CreateTable();
        }
        public PrepareAddressRepository(string filePath)
        {
            _tableName = "output6";
            sqlConnection = new SQLiteConnection("Data Source=" + filePath);
            sqlConnection.Open();
        }

        public void CreateTable()
        {
            var query = "CREATE TABLE  IF NOT EXISTS " + _tableName + "(" +
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
                               "PostalCode TEXT(255)," +
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
        /// <summary>
        /// レコードを追加する
        /// </summary>
        /// <param name="records"></param>
        public void Add(List<FormatedAddressRecord> records)
        {
            using (var transaction = sqlConnection.BeginTransaction())
            {
                using (var sqlCommand = new SQLiteCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    records.ForEach(rec =>
                    {
                        sqlCommand.CommandText = CreateInsertQuery(rec);
                        sqlCommand.ExecuteNonQuery();
                    });
                    transaction.Commit();
                }
            }
        }
        /// <summary>
        /// インサート用のクエリーを作成する
        /// </summary>
        /// <param name="record">インサートするレコード</param>
        /// <returns></returns>
        private string CreateInsertQuery(FormatedAddressRecord record)
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
                               "[PostalCode] ," +
                               "[X] ," +
                               "[Y] ," +
                               "[X_meter] ," +
                               "[Y_meter] ," +
                               "[FormatedAddress] ," +
                               "[ReadingCity] ," +
                               "[ReadingTown] ," +
                               "[ReadingChome])VALUES(" +
                               "'" + record.IDLocation + "'," +
                               "'" + record.AddedCityName + record.AddedTownName + record.ChomokMerge + "'," +
                               "'" + record.layer_code + "'," +
                               "'" + record.ADCD + "'," +
                               "'" + record.Kanj_Tod + "'," +
                               "'" + record.Kanj_Shi + "'," +
                               "'" + record.Kanj_Ooa + "'," +
                               "'" + record.Kanj_Aza + "'," +
                               "'" + record.Address1 + "'," +
                               "'" + record.MapCode + "'," +
                               "'" + record.PostalCode + "'," +
                               "'" + record.X + "'," +
                               "'" + record.Y + "'," +
                               "'" + record.X_meter + "'," +
                               "'" + record.Y_meter + "'," +
                               "'" + record.FormatedAddress + "'," +
                               "'" + record.ReadingCity + "'," +
                               "'" + record.ReadingTown + "'," +
                               "'" + record.ReadingChome + "')";
            return query;
        }
        public List<PrepareAddress> FindByUnion()
        {
            var query = "SELECT * FROM output6 " +
                               "UNION SELECT * FROM output7 ORDER BY IDLocation";
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
                record.FormatedAddress = dataReader["FormatedAddress"].ToString();
                record.AddressCode = dataReader["ADCD"].ToString();
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
