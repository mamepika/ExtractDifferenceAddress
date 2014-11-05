using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

using ExtractDifferenceAddress.FormatAddress.Models.Entities;

namespace ExtractDifferenceAddress.FormatAddress.Models
{
    public class FormatedAddressCsvReader
    {
        private string _formatedAddressFilePath;

        public FormatedAddressCsvReader(string filePath)
        {
            _formatedAddressFilePath = filePath;
        }

        /// <summary>
        /// CSVファイルをList形式にして返す
        /// </summary>
        /// <returns></returns>
        public List<FormatedAddressRecord> ReadFile()
        {
            var formateAddressRecords = new List<FormatedAddressRecord>();
            var fieldParser = new TextFieldParser(_formatedAddressFilePath, System.Text.Encoding.GetEncoding("Shift_JIS"))
            {
                TextFieldType = FieldType.Delimited                
            };
            fieldParser.SetDelimiters(",");
            fieldParser.ReadFields();
            while (!fieldParser.EndOfData)
            {
                try
                {
                    formateAddressRecords.Add(Convert(fieldParser.ReadFields()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return formateAddressRecords;
        }


        private FormatedAddressRecord Convert(string[] field)
        {
            var record = new FormatedAddressRecord()
            {
                IDLocation = field[0],
                Location = field[1],
                layer_code = field[2],
                ADCD = field[3],
                Kanj_Tod = field[4],
                Kanj_Shi = field[5],
                Kanj_Ooa = field[6],
                Kanj_Aza = field[7],
                Address1 = field[8],
                MapCode = field[9],
                X = field[10],
                Y = field[11],
                X_meter = field[12],
                Y_meter = field[13],
                AddressCode = field[14],
                PostalCode = field[15],
                AddedPrefectureName = field[16],
                AddedCityName = field[17],
                AddedTownName = field[18],
                AddedChome = field[19],
                AddedBanchi = field[20],
                BuildingName = field[21],
                ReadingPrefecture = field[22],
                ReadingCity = field[23],
                ReadingTown = field[24],
                ReadingChome = field[25],
                BuildingFloor = field[26],
                CantFormat = field[27],
                FormatLog = field[28],
                FormatedAddress = field[29],
            };
            return record;
        }
    }
}
