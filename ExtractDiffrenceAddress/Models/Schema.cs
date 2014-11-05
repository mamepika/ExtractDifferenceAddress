using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDifferenceAddress.Models
{
    /// <summary>
    /// テーブル構造を保持するクラス
    /// </summary>
    public class Schema
    {
        public string PastFiscalYearTableName { get; set; }

        public string ThisFiscalYearTableName { get; set; }

        public string DifferenceTableName
        {
            get
            {
                return "03_" + PastFiscalYearTableName.Substring(3);
            }
        }

        public void AddTableName(string tableName)
        {
            if(tableName.StartsWith("00_")){
                PastFiscalYearTableName = tableName;
            }else if(tableName.StartsWith("02_")){
                ThisFiscalYearTableName = tableName;
            }
        }
    }
}
