using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExtractDifferenceAddress.Servicies;
using ExtractDifferenceAddress.Controllers;

namespace ExtractDifferenceAddress
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォルダ参照ダイアログを開き、選択されたフォルダパスをテキストボックスに設定する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathTextBox.Text = folderDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// テキストボックスに入力されたフォルダ内のアクセスファイルに対して処理を行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (IsNotInputFilePath())
            {
                MessageBox.Show("フォルダを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Stopwatch stopWatch = new Stopwatch();
            var addressFiles = System.IO.Directory.GetFiles(filePathTextBox.Text, "*.accdb").ToList();
            SetProgressBarValues(addressFiles.Count);

            addressFiles.ForEach(addressFile =>
            {
                stopWatch.Start();
                UpdateProcessInfoLabel(addressFile);
                var extract = new ExtractDifferenceService(addressFile);
                extract.ExtractDifference();

                progressBar1.Value += 1;
                stopWatch.Stop();
            });

            MessageBox.Show("処理が完了しました" + System.Environment.NewLine + stopWatch.Elapsed.ToString());
            progressBar1.Value = 0;
        }

        /// <summary>
        /// ファイルパスが入力されているかを返す
        /// </summary>
        /// <returns>ファイルパスが入力されていなければtrue</returns>
        private bool IsNotInputFilePath()
        {
            return (filePathTextBox.Text.Length == 0)　;
        }

        /// <summary>
        /// 差分レコードのCSVファイルを生成する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (IsNotInputFilePath())
            {
                MessageBox.Show("フォルダを選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Stopwatch stopWatch = new Stopwatch();

            var addressFiles = System.IO.Directory.GetFiles(filePathTextBox.Text, "*.accdb").ToList();
            SetProgressBarValues(addressFiles.Count);

            addressFiles.ForEach(addressFile =>
            {
                UpdateProcessInfoLabel(addressFile);
                var csvService = new GenerateCsvFileService(addressFile);
                csvService.GenerateCsvFile();
                progressBar1.Value += 1;
            });
            MessageBox.Show("CSVファイルの生成処理が完了しました");
            progressBar1.Value = 0;
           }

        /// <summary>
        /// プログレスバーの最小値・最大値を設定する
        /// </summary>
        /// <param name="maxValue">プログレスバーに設定する最大値</param>
        private void SetProgressBarValues(int maxValue)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxValue;
        }
        
        /// <summary>
        /// 処理状況を知らせるラベルを更新する
        /// </summary>
        /// <param name="filePath">処理しているファイルのパス</param>
        private void UpdateProcessInfoLabel(string filePath)
        {
            ProcessInfo.Text = filePath + "を処理しています";
            ProcessInfo.Update();
        }

        private void 差分抽出DB作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var genrateDbForm = new Views.GenerateDBForm();
            genrateDbForm.ShowDialog();
        }

        public void SetProgressBarValue(int maximum)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maximum;
        }

        public  void UpdateProgressBar()
        {
            progressBar1.Value += 1;
        }

        private void cSV行数カウントToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var countForm = new Views.CountLineForm();
            countForm.ShowDialog();
        }

        private void 住所整形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formatAddressForm = new Views.FormatAddressForm();
            formatAddressForm.ShowDialog();
        }

        private void 読み仮名修正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var yomiForm = new Views.YomiganaForm();
            yomiForm.ShowDialog();
        }
    }



}
