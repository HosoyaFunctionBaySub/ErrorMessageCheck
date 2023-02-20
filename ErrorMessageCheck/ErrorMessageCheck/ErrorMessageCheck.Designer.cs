namespace ErrorMessageCheck
{
    partial class ErrorMessageCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessageCheck));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog_MSG = new System.Windows.Forms.OpenFileDialog();
            this.label_MSG = new System.Windows.Forms.Label();
            this.button_MSG = new System.Windows.Forms.Button();
            this.button_Run = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox_workaround = new System.Windows.Forms.RichTextBox();
            this.label_Workaround = new System.Windows.Forms.Label();
            this.label_Err = new System.Windows.Forms.Label();
            this.label_Version = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox_err = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Version = new System.Windows.Forms.RichTextBox();
            this.richTextBox_MSG = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem,
            this.バージョン情報ToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // バージョン情報ToolStripMenuItem
            // 
            this.バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            this.バージョン情報ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.バージョン情報ToolStripMenuItem.Text = "バージョン情報";
            this.バージョン情報ToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報ToolStripMenuItem_Click);
            // 
            // openFileDialog_MSG
            // 
            this.openFileDialog_MSG.InitialDirectory = "C:\\";
            // 
            // label_MSG
            // 
            this.label_MSG.AutoSize = true;
            this.label_MSG.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_MSG.Location = new System.Drawing.Point(12, 35);
            this.label_MSG.Name = "label_MSG";
            this.label_MSG.Size = new System.Drawing.Size(121, 12);
            this.label_MSG.TabIndex = 1;
            this.label_MSG.Text = "メッセージファイル(*.msg)";
            // 
            // button_MSG
            // 
            this.button_MSG.Location = new System.Drawing.Point(632, 28);
            this.button_MSG.Name = "button_MSG";
            this.button_MSG.Size = new System.Drawing.Size(75, 23);
            this.button_MSG.TabIndex = 3;
            this.button_MSG.Text = "参照";
            this.button_MSG.UseVisualStyleBackColor = true;
            this.button_MSG.Click += new System.EventHandler(this.button_MSG_Click);
            // 
            // button_Run
            // 
            this.button_Run.Location = new System.Drawing.Point(713, 28);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(75, 23);
            this.button_Run.TabIndex = 4;
            this.button_Run.Text = "実行";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox_Version);
            this.groupBox1.Controls.Add(this.richTextBox_err);
            this.groupBox1.Controls.Add(this.richTextBox_workaround);
            this.groupBox1.Controls.Add(this.label_Workaround);
            this.groupBox1.Controls.Add(this.label_Err);
            this.groupBox1.Controls.Add(this.label_Version);
            this.groupBox1.Location = new System.Drawing.Point(14, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 352);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "エラーメッセージ情報";
            // 
            // richTextBox_workaround
            // 
            this.richTextBox_workaround.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_workaround.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_workaround.Location = new System.Drawing.Point(125, 73);
            this.richTextBox_workaround.Name = "richTextBox_workaround";
            this.richTextBox_workaround.ReadOnly = true;
            this.richTextBox_workaround.Size = new System.Drawing.Size(643, 273);
            this.richTextBox_workaround.TabIndex = 6;
            this.richTextBox_workaround.Text = "";
            this.richTextBox_workaround.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_workaround_LinkClicked);
            // 
            // label_Workaround
            // 
            this.label_Workaround.AutoSize = true;
            this.label_Workaround.Location = new System.Drawing.Point(17, 76);
            this.label_Workaround.Name = "label_Workaround";
            this.label_Workaround.Size = new System.Drawing.Size(29, 12);
            this.label_Workaround.TabIndex = 4;
            this.label_Workaround.Text = "対策";
            // 
            // label_Err
            // 
            this.label_Err.AutoSize = true;
            this.label_Err.Location = new System.Drawing.Point(17, 47);
            this.label_Err.Name = "label_Err";
            this.label_Err.Size = new System.Drawing.Size(77, 12);
            this.label_Err.TabIndex = 2;
            this.label_Err.Text = "エラーメッセージ";
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Location = new System.Drawing.Point(17, 17);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(102, 12);
            this.label_Version.TabIndex = 0;
            this.label_Version.Text = "RecueDynバージョン";
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(713, 415);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 6;
            this.button_Close.Text = "閉じる";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(279, 434);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox_err
            // 
            this.richTextBox_err.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_err.DetectUrls = false;
            this.richTextBox_err.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_err.Location = new System.Drawing.Point(125, 44);
            this.richTextBox_err.Name = "richTextBox_err";
            this.richTextBox_err.ReadOnly = true;
            this.richTextBox_err.Size = new System.Drawing.Size(643, 23);
            this.richTextBox_err.TabIndex = 7;
            this.richTextBox_err.Text = "";
            // 
            // richTextBox_Version
            // 
            this.richTextBox_Version.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_Version.DetectUrls = false;
            this.richTextBox_Version.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_Version.Location = new System.Drawing.Point(125, 14);
            this.richTextBox_Version.Name = "richTextBox_Version";
            this.richTextBox_Version.ReadOnly = true;
            this.richTextBox_Version.Size = new System.Drawing.Size(643, 23);
            this.richTextBox_Version.TabIndex = 8;
            this.richTextBox_Version.Text = "";
            // 
            // richTextBox_MSG
            // 
            this.richTextBox_MSG.DetectUrls = false;
            this.richTextBox_MSG.Location = new System.Drawing.Point(139, 28);
            this.richTextBox_MSG.Name = "richTextBox_MSG";
            this.richTextBox_MSG.Size = new System.Drawing.Size(487, 23);
            this.richTextBox_MSG.TabIndex = 8;
            this.richTextBox_MSG.Text = "";
            // 
            // ErrorMessageCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.richTextBox_MSG);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.button_MSG);
            this.Controls.Add(this.label_MSG);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ErrorMessageCheck";
            this.Text = "ErrorMessageCheck";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報ToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog_MSG;
        private System.Windows.Forms.Label label_MSG;
        private System.Windows.Forms.Button button_MSG;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Label label_Workaround;
        private System.Windows.Forms.Label label_Err;
        private System.Windows.Forms.Label label_Version;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox_workaround;
        private System.Windows.Forms.RichTextBox richTextBox_err;
        private System.Windows.Forms.RichTextBox richTextBox_Version;
        private System.Windows.Forms.RichTextBox richTextBox_MSG;
    }
}