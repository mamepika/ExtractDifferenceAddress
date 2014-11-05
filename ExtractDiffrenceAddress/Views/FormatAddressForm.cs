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
using ExtractDiffrenceAddress.FormatAddress.Servicies;

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
            var dbFiles = System.IO.Directory.GetFiles(folederPathText.Text, "*.db").ToList();

            dbFiles.ForEach(db =>
            {
                var facade = new ExportAddressServiceFacade(db);
                facade.ExportAddress();
            });
        }


    }
}
