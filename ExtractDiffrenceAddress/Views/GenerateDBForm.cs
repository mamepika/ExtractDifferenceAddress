using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExtractDifferenceAddress.GenrateDB;
using ExtractDifferenceAddress.GenrateDB.Models;

namespace ExtractDifferenceAddress.Views
{
    public partial class GenerateDBForm : Form
    {
        public GenerateDBForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = OpenFileDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = OpenFileDialog();        

        }
        private void button3_Click(object sender, EventArgs e)
        {
            var generateDbService = new GenerateDbFileService(GetInfo());
            generateDbService.ReadPastYearFile();
            generateDbService.ReadThisYearFile();
            MessageBox.Show("処理終了");

        }

        private string OpenFileDialog()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                return null;
            }
        }
        private ProcessInfo GetInfo()
        {
            var info = new ProcessInfo();
            info.PastYearFilePath = textBox1.Text;
            info.ThisYearFilePath = textBox2.Text;
            info.OutPutFoloderPath = textBox3.Text;
            return info;

        }
    }
}
