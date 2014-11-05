using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractDifferenceAddress.GenrateDB.Models
{
    public class ProcessInfo
    {
        public string PastYearFilePath { get; set; }

        public string ThisYearFilePath { get; set; }

        public string PastTableName
        {
            get
            {
                return "00_" + System.IO.Path.GetFileNameWithoutExtension(PastYearFilePath);
            }
        }
        public string ThisYearTableName
        {
            get
            {
                return "02_" + System.IO.Path.GetFileNameWithoutExtension(ThisYearFilePath);
            }
        }

        public string OutPutFileName
        {
            get
            {
                return System.IO.Path.GetFileNameWithoutExtension(PastYearFilePath) + ".accdb";
            }
        }

        public string OutPutFoloderPath { get; set; }
    }
}
