using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtractDiffrenceAddress.Views
{
    public partial class CountLineForm : Form
    {
        public CountLineForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    folderPathTextBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderPathTextBox.Text.Length == 0)
            {
                MessageBox.Show("フォルダを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var csvFiles = System.IO.Directory.GetFiles(folderPathTextBox.Text, "*.csv").ToList();

            var countData = new Dictionary<string, int>();
            csvFiles.ForEach(file =>
            {
                //先頭行は除く
                countData.Add(file, System.IO.File.ReadAllLines(file).Length - 1);
            });

            countData.ToList().ForEach(c => Console.WriteLine(c.ToString()));

            Console.WriteLine();
        }


    }
}
