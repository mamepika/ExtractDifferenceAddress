namespace ExtractDifferenceAddress
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ProcessInfo = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ツールToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.差分抽出DB作成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSV行数カウントToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.住所整形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.読み仮名修正ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(12, 71);
            this.filePathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(519, 23);
            this.filePathTextBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "参照";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(280, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "差分抽出開始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "処理対象のアクセスファイルが格納されているフォルダを選択してください";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 212);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(600, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // ProcessInfo
            // 
            this.ProcessInfo.AutoSize = true;
            this.ProcessInfo.Location = new System.Drawing.Point(12, 194);
            this.ProcessInfo.Name = "ProcessInfo";
            this.ProcessInfo.Size = new System.Drawing.Size(0, 15);
            this.ProcessInfo.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(330, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(280, 40);
            this.button3.TabIndex = 6;
            this.button3.Text = "CSV出力";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.ツールToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(622, 26);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // ツールToolStripMenuItem
            // 
            this.ツールToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.差分抽出DB作成ToolStripMenuItem,
            this.cSV行数カウントToolStripMenuItem,
            this.住所整形ToolStripMenuItem,
            this.読み仮名修正ToolStripMenuItem});
            this.ツールToolStripMenuItem.Name = "ツールToolStripMenuItem";
            this.ツールToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.ツールToolStripMenuItem.Text = "ツール";
            // 
            // 差分抽出DB作成ToolStripMenuItem
            // 
            this.差分抽出DB作成ToolStripMenuItem.Name = "差分抽出DB作成ToolStripMenuItem";
            this.差分抽出DB作成ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.差分抽出DB作成ToolStripMenuItem.Text = "差分抽出DB作成";
            this.差分抽出DB作成ToolStripMenuItem.Click += new System.EventHandler(this.差分抽出DB作成ToolStripMenuItem_Click);
            // 
            // cSV行数カウントToolStripMenuItem
            // 
            this.cSV行数カウントToolStripMenuItem.Name = "cSV行数カウントToolStripMenuItem";
            this.cSV行数カウントToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cSV行数カウントToolStripMenuItem.Text = "CSV行数カウント";
            this.cSV行数カウントToolStripMenuItem.Click += new System.EventHandler(this.cSV行数カウントToolStripMenuItem_Click);
            // 
            // 住所整形ToolStripMenuItem
            // 
            this.住所整形ToolStripMenuItem.Name = "住所整形ToolStripMenuItem";
            this.住所整形ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.住所整形ToolStripMenuItem.Text = "住所整形";
            this.住所整形ToolStripMenuItem.Click += new System.EventHandler(this.住所整形ToolStripMenuItem_Click);
            // 
            // 読み仮名修正ToolStripMenuItem
            // 
            this.読み仮名修正ToolStripMenuItem.Name = "読み仮名修正ToolStripMenuItem";
            this.読み仮名修正ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.読み仮名修正ToolStripMenuItem.Text = "読み仮名修正";
            this.読み仮名修正ToolStripMenuItem.Click += new System.EventHandler(this.読み仮名修正ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 286);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ProcessInfo);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "住所データ差分抽出";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ProcessInfo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ツールToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 差分抽出DB作成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSV行数カウントToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 住所整形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 読み仮名修正ToolStripMenuItem;
    }
}

