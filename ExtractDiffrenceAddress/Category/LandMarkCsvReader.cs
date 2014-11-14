using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using ExtractDifferenceAddress.Category.Entities;


namespace ExtractDifferenceAddress.Category
{
    public class LandMarkCsvReader
    {

        private string _filePath;

        public LandMarkCsvReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<LandMarkData> ReadFile()
        {
            var landMarks = new List<LandMarkData>();

            using (var streamReader = new StreamReader(_filePath,System.Text.Encoding.GetEncoding("Shift_jis")))
            {
                streamReader.ReadLine();
                while (streamReader.Peek() >= 0)
                {
                    var line = streamReader.ReadLine().Split(',').ToList() ;

                    var landMark = new LandMarkData()
                    {
                        classification = new Classification()
                        {
                            BigClassification =  line[0].ToString(),
                            MiddleClassification = line[1].ToString(),
                            SmallClassification = line[2].ToString()
                        },
                        Name = line[3].ToString()
                    };
                    landMarks.Add(landMark);                    
                }
                return landMarks;
            }
        }
    }

}
