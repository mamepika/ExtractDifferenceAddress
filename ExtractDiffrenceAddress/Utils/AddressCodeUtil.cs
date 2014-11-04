using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDiffrenceAddress.Utils
{
    public static class AddressCodeUtil
    {
        /// <summary>
        /// アドレスコードから該当の都道府県名を返す
        /// </summary>
        /// <param name="addressCode"></param>
        /// <returns></returns>
        public static string GetPrefectureName(string addressCode)
        {
            var prefectureCode = addressCode.Substring(0,2);

            switch (prefectureCode)
            {
                case "01":
                    return "北海道";
                case "02":
                    return "青森県";
                case "03":
                    return "岩手県";
                case "04":
                    return "宮城県";
                case "05":
                    return "秋田県";
                case "06":
                    return "山形県";
                case "07":
                    return "福島県";
                case "08":
                    return "茨城県";
                case "09":
                    return "栃木県";
                case "10":
                    return "群馬県";
                case "11":
                    return "埼玉県";
                case "12":
                    return "千葉県";
                case "13":
                    return "東京都";
                case "14":
                    return "神奈川県";
                case "15":
                    return "新潟県";
                case "16":
                    return "富山県";
                case "17":
                    return "石川県";
                case "18":
                    return "福井県";
                case "19":
                    return "山梨県";
                case "20":
                    return "長野県";
                case "21":
                    return "岐阜県";
                case "22":
                    return "静岡県";
                case "23":
                    return "愛知県";
                case "24":
                    return "三重県";
                case "25":
                    return "滋賀県";
                case "26":
                    return "京都府";
                case "27":
                    return "大阪府";
                case "28":
                    return "兵庫県";
                case "29":
                    return "奈良県";
                case "30":
                    return "和歌山県";
                case "31":
                    return "鳥取県";
                case "32":
                    return "島根県";
                case "33":
                    return "広島県";
                case "34":
                    return "岡山県";
                case "35":
                    return "山口県";
                case "36":
                    return "徳島県";
                case "37":
                    return "香川県";
                case "38":
                    return "愛媛県";
                case "39":
                    return "高知県";
                case "40":
                    return "福岡県";
                case "41":
                    return "佐賀県";
                case "42":
                    return "長崎県";
                case "43":
                    return "熊本県";
                case "44":
                    return "大分県";
                case "45":
                    return "宮崎県";
                case "46":
                    return "鹿児島県";
                case "47":
                    return "沖縄県";
                default :
                    return "";
            }
        }
    }
}
