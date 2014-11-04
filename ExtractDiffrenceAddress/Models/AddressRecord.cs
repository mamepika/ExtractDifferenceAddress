using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDiffrenceAddress.Models
{
    /// <summary>
    /// 住所レコードクラス
    /// </summary>
    public class AddressRecord
    {
        public string IDLocation { get; set; }

        public string Location { get; set; }

        public string layer_code { get; set; }

        public string ADCD { get; set; }

        public string Kanj_Tod { get; set; }

        public string Kanj_Shi { get; set; }

        public string Kanj_Ooa { get; set; }

        public string Kanj_Aza { get; set; }

        public string Address1 { get; set; }

        public string X_tky { get; set; }

        public string Y_tky { get; set; }

        public string MapCode { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public string X_meter { get; set; }

        public string Y_meter { get; set; }

        /// <summary>
        /// インスタンス情報をCSV形式に変換する
        /// </summary>
        /// <returns></returns>
        public string ToCsv()
        {
            var line = new StringBuilder();
            line.Append(IDLocation).Append(",");
            line.Append(Location).Append(",");
            line.Append(layer_code).Append(",");
            line.Append(ADCD).Append(",");
            line.Append(Kanj_Tod).Append(",");
            line.Append(Kanj_Shi).Append(",");
            line.Append(Kanj_Ooa).Append(",");
            line.Append(Kanj_Aza).Append(",");
            line.Append(Address1).Append(",");
            //line.Append(X_tky).Append(",");
            //line.Append(Y_tky).Append(",");
            line.Append(MapCode).Append(",");
            line.Append(X).Append(",");
            line.Append(Y).Append(",");
            line.Append(X_meter).Append(",");
            line.Append(Y_meter);

            return line.ToString();
        }

    }
}
