using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExtractDifferenceAddress.FormatAddress;
using ExtractDifferenceAddress.FormatAddress.Servicies;
using ExtractDifferenceAddress.FormatAddress.Csv;

namespace ExtractDifferenceAddress.Views
{
    public partial class FormatAddressForm : Form
    {
        public FormatAddressForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    folederPathText.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var csvFiles = System.IO.Directory.GetFiles(folederPathText.Text, "*.csv").ToList();

            csvFiles.ForEach(x =>
            {
                var service = new FormatAddressRegisterService(x);
                service.ReadFile();
            });
            MessageBox.Show("処理が完了しました");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dbFiles = System.IO.Directory.GetFiles(folederPathText.Text, "*.db").ToList();

            dbFiles.ForEach(db =>
            {
                var facade = new ExportAddressServiceFacade(db);
                facade.ExportAddress();
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var locationCsvRepo = new LocationCsvRepository(@"C:\work\03_iwate_output.db");

            var records = locationCsvRepo.FindLocation("output");

            using (var writer = new System.IO.StreamWriter(@"C:\work\test.csv", true, System.Text.Encoding.GetEncoding("Shift_Jis")))
            {
                records.ForEach(r=>writer.WriteLine(r.ToCsv()));
            }

            var locations = locationCsvRepo.FindLocation("Location");

            using (var writer = new System.IO.StreamWriter(@"C:\work\test.csv", true,System.Text.Encoding.GetEncoding("Shift_Jis")))
            {
                locations.ForEach(r => writer.WriteLine(r.ToCsv()));
            }

            var anRecords = locationCsvRepo.FindLocationAn("output");

            using (var writer = new System.IO.StreamWriter(@"C:\work\testAN.csv",true, System.Text.Encoding.GetEncoding("Shift_Jis")))
            {
                anRecords.ForEach(r => writer.WriteLine(r.ToCsv()));
            }
            var anLocations = locationCsvRepo.FindLocationAn("LocationAN");

            using (var writer = new System.IO.StreamWriter(@"C:\work\testAN.csv",true, System.Text.Encoding.GetEncoding("Shift_Jis")))
            {
                anLocations.ForEach(r => writer.WriteLine(r.ToCsv()));
            }
        }


    }
}
