using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ExtractDiffrenceAddress.FormatAddress.Models.Entities
{
    /// <summary>
    /// 整形後住所
    /// </summary>
    public class PrepareAddress
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

        public string ReadingCity { get; set; }

        public string ReadingTown { get; set; }

        public string ReadingChome { get; set; }

        public string HiraCity
        {
            get
            {
                return Microsoft.VisualBasic.Strings.StrConv(ReadingCity, Microsoft.VisualBasic.VbStrConv.Hiragana);
            }        
        }
        public string HiraTown
        {
            get
            {
                return Microsoft.VisualBasic.Strings.StrConv(ReadingTown, Microsoft.VisualBasic.VbStrConv.Hiragana);
            }
        }
        public string HiraChome
        {
            get
            {
                return Microsoft.VisualBasic.Strings.StrConv(ReadingChome, Microsoft.VisualBasic.VbStrConv.Hiragana);
            }
        }
    }
}
