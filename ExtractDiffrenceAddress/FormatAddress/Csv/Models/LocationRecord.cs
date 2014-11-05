using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDifferenceAddress.FormatAddress.Csv.Models
{
    public class LocationRecord
    {
        public string IDLocation { get; set; }

        public string Location { get; set; }

        public string IDCountry
        {
            get
            {
                return "1111";
            }
        }
        public string IDTown { get; set; }
      
        public string PostalCode { get; set; }

        public string MapCode { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

        public string IDLocationManual
        {
            get
            {
                return "";
            }
        }
        public string X_meter { get; set; }

        public string Y_meter { get; set; }

        public string AddressCode { get; set; }


        public string ToCsv()
        {
            var line = new StringBuilder();
            line.Append(IDLocation).Append(",");
            line.Append(Location).Append(",");
            line.Append(IDCountry).Append(",");
            line.Append(IDTown).Append(",");
            line.Append(PostalCode).Append(",");
            line.Append(MapCode).Append(",");
            line.Append(X_meter).Append(",");
            line.Append(Y_meter).Append(",");
            line.Append(IDLocationManual).Append(",");
            line.Append(X).Append(",");
            line.Append(Y);

            return line.ToString();
        }
    }
}
