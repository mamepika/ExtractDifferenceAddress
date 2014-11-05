using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ExtractDifferenceAddress.FormatAddress.Models.Entities
{
    /// <summary>
    /// 整形後住所
    /// </summary>
    public class PrepareAddress
    {
        public string IDLocation { get; set; }

        public string Location { get; set; }

        public string PostalCode { get; set; }

        public string MapCode { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public string X_meter { get; set; }

        public string Y_meter { get; set; }

        public string ReadingCity { get; set; }

        public string ReadingTown { get; set; }

        public string ReadingChome { get; set; }

        public string AddressCode { get; set; }

        public string FormatedAddress { get; set; }

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

        public string IDTown
        {
            get
            {
                return "0" + AddressCode.Substring(0, 2);
            }
        }
    }
}
