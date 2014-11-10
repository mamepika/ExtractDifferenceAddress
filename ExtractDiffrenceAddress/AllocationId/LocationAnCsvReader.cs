using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic.FileIO;
using ExtractDifferenceAddress.FormatAddress.Csv.Models;

namespace ExtractDifferenceAddress.AllocationId
{
    public class LocationAnCsvReader
    {
        private string _filePath;

        public LocationAnCsvReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<LocationAnRecord> ReadFile()
        {
            var records = new List<LocationAnRecord>();
            var fieldParser = new TextFieldParser(_filePath, System.Text.Encoding.GetEncoding("Shift_JIS"));
            fieldParser.TextFieldType = FieldType.Delimited;
            fieldParser.SetDelimiters(",");
            fieldParser.ReadFields();

            while (!fieldParser.EndOfData)
            {
                var field = fieldParser.ReadFields();
                var record = new LocationAnRecord()
                {
                    IDLocationAN = field[0],
                    IDLocation = field[1],
                    Location = field[2]                    
                };
                records.Add(record);
            }
            return records;
        }
    }
}
