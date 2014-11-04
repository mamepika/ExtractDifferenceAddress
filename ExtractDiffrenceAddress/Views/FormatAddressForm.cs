using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExtractDiffrenceAddress.FormatAddress;

namespace ExtractDiffrenceAddress.Views
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
            var formatService = new RemoveFormatAddressLogService(@"C:\work\03_Iwate_output.db");
            formatService.RemoveLog();

            var neighService = new AzaWithNeighboorhoodService(@"C:\work\03_Iwate_output.db");

            neighService.ExtractAzaWithNeighborhood();

            var extractService = new ExtractAzaRemoveService(@"C:\work\03_Iwate_output.db");

            extractService.ExtractAzaRemove();

            var neighborService = new ExtractNeighborhoodService(@"C:\work\03_Iwate_output.db");

            neighborService.ExtractNeighborhood();
        }


    }
}
