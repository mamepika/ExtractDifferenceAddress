using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using ExtractDifferenceAddress.Models;

namespace ExtractDifferenceAddress.GenrateDB.Models
{
    public class ThisYearCsvReader
    {
        private string _filePath;

        public ThisYearCsvReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<AddressRecord> ReadFile()
        {
            var addressRecords = new List<AddressRecord>();
            var fieldParser = new TextFieldParser(_filePath);
            fieldParser.TextFieldType = FieldType.Delimited;
            fieldParser.SetDelimiters(",");
            fieldParser.ReadFields();

            while (!fieldParser.EndOfData)
            {
                var record = new AddressRecord();
                var field = fieldParser.ReadFields();
                record.IDLocation = field[0];
                record.Location = field[1];
                record.layer_code = field[2];
                record.ADCD = field[3];
                record.Kanj_Tod = field[4];
                record.Kanj_Shi = field[5];
                record.Kanj_Ooa = field[6];
                record.Kanj_Aza = field[7];
                record.Address1 = field[8];
                record.X_tky = field[9];
                record.Y_tky = field[10];
                record.MapCode = field[11];
                record.X = field[12];
                record.Y = field[13];
                record.X_meter = field[14];
                record.Y_meter = field[15];
                addressRecords.Add(record);
            }
            return addressRecords;
        }
    }
}
