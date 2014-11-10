using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExtractDifferenceAddress.AllocationId
{
    public class AllocationIdService
    {
        private List<string> locationFiles;

        private List<string> locationAnFiles;

        private string _outputPath;

        public AllocationIdService(string targetPath)
        {
            locationFiles = System.IO.Directory.GetFiles(targetPath, "*Location.csv").ToList();
            locationAnFiles = System.IO.Directory.GetFiles(targetPath, "*LocationAN.csv").ToList();

            _outputPath = targetPath + "\\csv";
            System.IO.Directory.CreateDirectory(_outputPath);
        }

        public void AllocationId(int startId)
        {
            AllocationIdToLocationCsv(startId);
            AllocationIdToLocationAnCsv(startId);

        }

        private void AllocationIdToLocationCsv(int startId)
        {
            var id = startId;
            locationFiles.ForEach(loc =>
            {
                var locationCsvReader = new LocationCsvReader(loc);
                var records = locationCsvReader.ReadFile();
                using (var writer = new StreamWriter(_outputPath + "\\" + Path.GetFileNameWithoutExtension(loc) + ".csv", true, Encoding.GetEncoding("Shift_jis")))
                {
                    writer.WriteLine("IDLocation,Location,IDCountry,IDTown,PostalCode,MapCode,X_meter,Y_meter,IDLocationManual,X,Y");
                    records.ForEach(re =>
                    {
                        writer.WriteLine(re.ToCsv(id));
                        id += 1;
                    });
                }
            });
        }

        private void AllocationIdToLocationAnCsv(int startId)
        {
            var locationId = startId;

            locationAnFiles.ForEach(locAn =>
            {
                var locationAnCsvReader = new LocationAnCsvReader(locAn);
                var records = locationAnCsvReader.ReadFile();
                using (var writer = new StreamWriter(_outputPath + "\\" + Path.GetFileNameWithoutExtension(locAn) + ".csv", true, Encoding.GetEncoding("Shift_jis")))
                {
                    writer.WriteLine("IDLocationAN,IDLocation,Location,IDCountry,Language,Manual");
                    records.ForEach(re =>
                    {
                        writer.WriteLine(re.ToCsv(locationId));
                        locationId += 1;
                    });
                }
            });
        }

    }
}
