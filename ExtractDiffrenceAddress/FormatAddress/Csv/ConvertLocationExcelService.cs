using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

using ClosedXML.Excel;

namespace ExtractDifferenceAddress.FormatAddress.Csv
{
    public class ConvertLocationExcelService
    {
        private string _filePath;

        private Encoding encode = System.Text.Encoding.GetEncoding("Shift_Jis");

        public ConvertLocationExcelService(string filePath)
        {
            _filePath = filePath;
        }

        public void ConvertCsvToExcel()
        {
            using (var streamReader = new StreamReader(_filePath,encode))
            {
                var lines = streamReader.ReadToEnd();
                using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
                {
                    var workSheet = workbook.Worksheets.Add("Sheet1");
                    workSheet.Column(4).Style.NumberFormat.Format = "000";
                    workSheet.Column(5).Style.NumberFormat.Format = "0000000";

                    int rowCount = 1;
                    while (streamReader.Peek() >= 0)
                    {
                        var line = streamReader.ReadLine().Split(',');
                        using (var row = workSheet.Row(rowCount))
                        {
                            for (int i = 1; i < line.Length + 1; i++)
                            {
                                row.Cell(i).Value = line[i - 1];
                            }
                        }
                        rowCount++;
                        GC.Collect();
                    }
                    workbook.SaveAs(@"C:\work\Stream.xlsx");
                }
                
            }
            

            //using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
            //{
                

            //    int i = 1;
                
            //    while (!fieldParser.EndOfData)
            //    {
            //        var line = fieldParser.ReadFields().ToList();
            //        using (var row = workSheet.Row(i))
            //        {
            //            for (int j = 1; j < line.Count + 1; j++)
            //            {
            //                row.Cell(j).Value = line[j - 1];
            //            }
            //            i++;
            //        }

            //    }
            //    workbook.SaveAs(@"C:\work\text.xlsx");
            //}

        }
    }
}
