using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ExtractDifferenceAddress.Category.Entities;


namespace ExtractDifferenceAddress.Category
{
    public class CategoryCsvReader
    {
        private string _filePath;

        public CategoryCsvReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<Category> ReadFile()
        {
            var categories = new List<Category>();
            using (var streamReader = new StreamReader(_filePath, System.Text.Encoding.GetEncoding("Shift_jis")))
            {
                while (streamReader.Peek() >= 0)
                {
                    var line = streamReader.ReadLine().Split(',').ToList();
                    var category = new Category()
                    {
                        classification = new Classification() 
                        { 
                            BigClassification = line[0],
                            MiddleClassification = line[1],
                            SmallClassification = line[2]
                        },
                        BigClassificationName = line[3],
                        MiddleClassificationName = line[4],
                        SmallClassificationName = line[5],
                    };
                    categories.Add(category);
                }
                return categories;
            }
        }
    }
}
