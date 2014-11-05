using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDifferenceAddress.FormatAddress.Csv.Models
{
    public class LocationAnRecord
    {
        public string IDLocationAN { get; set; }

        public string IDLocation { get; set; }

        private string _location;
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                this._location = Microsoft.VisualBasic.Strings.StrConv(value, Microsoft.VisualBasic.VbStrConv.Hiragana);
            }
        }
        public string IDCountry
        {
            get
            {
                return "1111";
            }
        }
        public string Language
        {
            get
            {
                return "JPN";
            }
        }
        public string Manual
        {
            get
            {
                return "0";
            }
        }

        public string ToCsv()
        {
            var line = new StringBuilder();
            line.Append(IDLocationAN).Append(",");
            line.Append(IDLocation).Append(",");
            line.Append(Location).Append(",");
            line.Append(IDCountry).Append(",");
            line.Append(Language).Append(",");
            line.Append(Manual);

            return line.ToString();
        }
    }
}
