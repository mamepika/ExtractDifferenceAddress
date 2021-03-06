﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using ExtractDifferenceAddress.FormatAddress.Models.Entities;
using ExtractDifferenceAddress.FormatAddress.Csv.Models;

namespace ExtractDifferenceAddress.FormatAddress.Csv
{
    /// <summary>
    /// CSV用リポジトリ
    /// </summary>
    public class LocationCsvRepository : IDisposable
    {
        private SQLiteConnection sqlConnection;

        public LocationCsvRepository(string filePath)
        {
            sqlConnection = new SQLiteConnection("Data Source=" + filePath);
            sqlConnection.Open();
        }

        /// <summary>
        /// LocationのリストをDBから取得する
        /// </summary>
        /// <param name="tableName">抽出対象のテーブル名</param>
        /// <returns></returns>
        public List<LocationRecord> FindLocation(string tableName)
        {
            var query = "SELECT * FROM " + tableName;
            using (var dbCommand = new SQLiteCommand())
            {
                dbCommand.CommandText = query;
                dbCommand.Connection = sqlConnection;
                return ConvertLocation(dbCommand.ExecuteReader(),tableName);
            }
        }

        /// <summary>
        /// LocationANのリストをDBから取得する
        /// </summary>
        /// <param name="tableName">抽出対象のテーブル名</param>
        /// <returns></returns>
        public List<LocationAnRecord> FindLocationAn(string tableName)
        {
            var query = "SELECT * FROM " + tableName;
            using (var dbCommand = new SQLiteCommand())
            {
                dbCommand.CommandText = query;
                dbCommand.Connection = sqlConnection;
                return ConvertLocationAn(dbCommand.ExecuteReader(), tableName);
            }
        }

        /// <summary>
        /// LocationANオブジェクトのListへの変換処理
        /// </summary>
        /// <param name="dataReader">変換対象のDB抽出結果</param>
        /// <param name="tableName">抽出したテーブル名</param>
        /// <returns></returns>
        public List<LocationAnRecord> ConvertLocationAn(SQLiteDataReader dataReader, string tableName)
        {
            var records = new List<LocationAnRecord>();
            while (dataReader.Read())
            {
                var record = new LocationAnRecord();
                record.IDLocationAN = dataReader["IDLocation"].ToString();
                record.IDLocation = dataReader["IDLocation"].ToString();
                if (tableName.Equals("output"))
                {
                    record.Location = dataReader["ReadingCity"].ToString() + dataReader["ReadingTown"].ToString() + dataReader["ReadingChome"].ToString();
                }
                else if (tableName.Equals("LocationAN"))
                {
                    record.Location = dataReader["Location"].ToString();
                }
                records.Add(record);
            }
            return records;
        }

        /// <summary>
        /// LocationオブジェクトのListへの変換処理
        /// </summary>
        /// <param name="dataReader">変換対象のDB抽出結果</param>
        /// <param name="tableName">抽出したテーブル名</param>
        /// <returns></returns>
        private List<LocationRecord> ConvertLocation(SQLiteDataReader dataReader,string tableName)
        {
            var records = new List<LocationRecord>();

            while (dataReader.Read())
            {
                var record = new LocationRecord();

                record.IDLocation = dataReader["IDLocation"].ToString();
                record.Location = dataReader["Location"].ToString();
                if (tableName.Equals("output"))
                {
                    record.IDTown = "0" + dataReader["AddressCode"].ToString().Substring(0,2);
                }
                else if (tableName.Equals("Location"))
                {
                    record.IDTown = dataReader["IDTown"].ToString();
                }
                record.PostalCode = dataReader["PostalCode"].ToString();
                record.MapCode = dataReader["MapCode"].ToString();
                record.X_meter = dataReader["X_meter"].ToString();
                record.Y_meter = dataReader["Y_meter"].ToString();
                record.X = dataReader["X"].ToString();
                record.Y = dataReader["Y"].ToString();

                records.Add(record);
            }
            return records;
        }

        /// <summary>
        /// テーブルの有無を取得する
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool IsExists(string tableName)
        {
            var query = "select count() from sqlite_master where type='table' and name='" + tableName +"';";
            using (var sqlCommand = new SQLiteCommand())
            {
                sqlCommand.CommandText = query;
                sqlCommand.Connection = sqlConnection;

                var count = (long)sqlCommand.ExecuteScalar();

                return (count == 1);                
            }
        }
        /// <summary>
        /// クエリーを実行する
        /// </summary>
        /// <param name="query">実行されるSQL文</param>
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
