using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ExtractDifferenceAddress.AllocationId
{
    public class MergeCsvService
    {
        private List<string> locationFiles;

        private List<string> locationAnFiles;

        private string _outputPath;

        public MergeCsvService(string targetPath)
        {
            locationFiles = System.IO.Directory.GetFiles(targetPath, "*Location.csv").ToList();
            locationAnFiles = System.IO.Directory.GetFiles(targetPath, "*LocationAN.csv").ToList();

            _outputPath = targetPath + "\\Merge";
            System.IO.Directory.CreateDirectory(_outputPath);
        }

        public void MergeCsv()
        {
            using (var writer = new StreamWriter(_outputPath + "\\Location2014.csv",true,Encoding.GetEncoding("Shift_Jis")))
            {
                locationFiles.ForEach(loc =>
                {
                    using (var reader = new StreamReader(loc, Encoding.GetEncoding("Shift_Jis"),true))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            writer.WriteLine(reader.ReadLine());
                        }
                    }
                });
            }
            using (var writer = new StreamWriter(_outputPath + "\\LocationAN2014.csv", true, Encoding.GetEncoding("Shift_Jis")))
            {
                locationAnFiles.ForEach(loc =>
                {
                    using (var reader = new StreamReader(loc, Encoding.GetEncoding("Shift_Jis"), true))
                    {
                        reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            writer.WriteLine(reader.ReadLine());
                        }
                    }
                });
            }
        }
    }
}
