using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

using ExtractDifferenceAddress.GenrateDB.Models.Entities;

namespace ExtractDifferenceAddress.GenrateDB.Models
{
    public class PastYearCsvReader
    {
        private string _filePath;

        public PastYearCsvReader(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// CSVの内容を返す
        /// </summary>
        /// <returns></returns>
        public List<PastFiscalYearAddressRecord> ReadFile()
        {
            var pastRecords = new List<PastFiscalYearAddressRecord>();
            var fieldParser = new TextFieldParser(_filePath, System.Text.Encoding.GetEncoding("Shift_JIS"));
            fieldParser.TextFieldType = FieldType.Delimited;
            fieldParser.SetDelimiters(",");
            fieldParser.ReadFields();
            while (!fieldParser.EndOfData)
            {
                try
                {
                    var record = new PastFiscalYearAddressRecord();
                    var field = fieldParser.ReadFields();
                    record.IDLocation = field[0];
                    record.Location = field[1];
                    record.IDCountry = field[2];
                    record.IDTown = field[3];
                    record.PostalCode = field[4];
                    record.MapCode = field[5];
                    record.X_meter = field[6];
                    record.Y_meter = field[7];
                    record.IDLocationManual = field[8];
                    record.X = field[9];
                    record.Y = field[10];

                    pastRecords.Add(record);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.GetType());
                }
                
            }
            return pastRecords;

        }
    }
}
