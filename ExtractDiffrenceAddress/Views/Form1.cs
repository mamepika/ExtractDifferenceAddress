using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExtractDifferenceAddress.FormatAddress.Csv;

namespace ExtractDifferenceAddress.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var excelService = new ConvertLocationExcelService(@"C:\work\01_Hokkaido_output_Location - コピー.csv");
            excelService.ConvertCsvToExcel();
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
