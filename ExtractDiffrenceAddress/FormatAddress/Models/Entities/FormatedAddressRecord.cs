using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ExtractDiffrenceAddress.FormatAddress.Models.Entities
{
    /// <summary>
    /// 住所正規化コンバータにより生成されたレコード
    /// </summary>
    public class FormatedAddressRecord
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

        public string MapCode { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public string X_meter { get; set; }

        public string Y_meter { get; set; }

        public string AddressCode { get; set; }

        public string PostalCode { get; set; }

        public string AddedPrefectureName { get; set; }

        public string AddedCityName { get; set; }

        public string AddedTownName { get; set; }

        public string AddedChome { get; set; }

        public string AddedBanchi { get; set; }

        public string BuildingName { get; set; }

        public string ReadingPrefecture { get; set; }

        public string ReadingCity { get; set; }

        public string ReadingTown { get; set; }

        public string ReadingChome { get; set; }

        public string BuildingFloor { get; set; }

        public string CantFormat { get; set; }

        public string FormatLog { get; set; }

        public string FormatedAddress { get; set; }

        public string ChomokMerge
        {
            get
            {
                string merge = null;
                if (Location.IndexOf("丁目") > 0)
                {
                    if (Kanj_Aza.IndexOf("丁目") == 0)
                    {
                        int i = 0;
                        if (int.TryParse(Microsoft.VisualBasic.Strings.StrConv(Kanj_Aza, VbStrConv.Narrow),out i))
                        {
                            merge = Kanj_Aza + "丁目";
                        }
                        else
                        {
                            merge = Kanj_Aza;
                        }
                    }
                    else
                    {
                        merge = Kanj_Aza + Address1 + CantFormat;
                    }
                }
                else
                {
                    merge = Kanj_Aza + Address1 + CantFormat;
                }
                return merge;
            }
        }
        public string ExtractedBanchi
        {
            get
            {
                var logs = FormatLog.Split('|').ToList();
                var work = logs.Find(l => l.IndexOf("FL00") > 0);
                if (work != null)
                {
                    if (work.IndexOf("(地)") > 0)
                    {
                        work = work.Replace("(地)", "");
                    }
                    var banchi = work.Substring(work.IndexOf("("), work.IndexOf(")") - work.IndexOf("("));
                    var splitedBanchi = banchi.Split('，');
                    splitedBanchi[0] = splitedBanchi[0].Replace("(", "");

                    return Microsoft.VisualBasic.Strings.StrConv(splitedBanchi[0], Microsoft.VisualBasic.VbStrConv.Wide, 4);
                }
                return "";
            }
        }
        
        
        
        }
}
