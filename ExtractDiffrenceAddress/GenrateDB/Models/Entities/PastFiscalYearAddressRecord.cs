using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDifferenceAddress.GenrateDB.Models.Entities
{
    public class PastFiscalYearAddressRecord
    {
        
        public string IDLocation { get; set; }

        public string Location { get; set; }

        public string IDCountry { get; set; }

        public string IDTown { get; set; }

        public string PostalCode { get; set; }

        public string MapCode { get; set; }

        public string X_meter { get; set; }

        public string Y_meter { get; set; }

        public string IDLocationManual { get; set; }

        public string X { get; set; }

        public string Y { get; set; }

    }
}
