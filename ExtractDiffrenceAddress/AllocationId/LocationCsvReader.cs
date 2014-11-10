using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic.FileIO;
using ExtractDifferenceAddress.FormatAddress.Csv.Models;

namespace ExtractDifferenceAddress.AllocationId
{
    public class LocationCsvReader
    {
        private string _filePath;

        public LocationCsvReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<LocationRecord> ReadFile()
        {
            var records = new List<LocationRecord>();
            var fieldParser = new TextFieldParser(_filePath, System.Text.Encoding.GetEncoding("Shift_JIS"));
            fieldParser.TextFieldType = FieldType.Delimited;
            fieldParser.SetDelimiters(",");
            fieldParser.ReadFields();

            while (!fieldParser.EndOfData)
            {
                var field = fieldParser.ReadFields();
                var record = new LocationRecord()
                {
                    IDLocation = field[0],
                    Location = field[1],
                    IDTown = field[3],
                    PostalCode = field[4],
                    MapCode = field[5],
                    X = field[6],
                    Y = field[7],
                    X_meter = field[9],
                    Y_meter = field[10]
                };

                records.Add(record);
            }
            return records;
        }

    }
}
