namespace PyModelToSharp
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cboPythonPath = new ComboBox();
            label2 = new Label();
            txtPackagesPath = new TextBox();
            btnOpenPackagesPath = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label3 = new Label();
            txtModelName = new TextBox();
            btnConvert = new Button();
            btnOpenSavePath = new Button();
            txtSaveFolder = new TextBox();
            label4 = new Label();
            folderBrowserDialog2 = new FolderBrowserDialog();
            txtMessage = new RichTextBox();
            lblNote = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(112, 17);
            label1.TabIndex = 0;
            label1.Text = "Python Intepreter:";
            // 
            // cboPythonPath
            // 
            cboPythonPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboPythonPath.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPythonPath.FormattingEnabled = true;
            cboPythonPath.Location = new Point(156, 17);
            cboPythonPath.Name = "cboPythonPath";
            cboPythonPath.Size = new Size(650, 25);
            cboPythonPath.TabIndex = 1;
            cboPythonPath.SelectedIndexChanged += cboPythonPath_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(137, 17);
            label2.TabIndex = 2;
            label2.Text = "Path of site-packages:";
            // 
            // txtPackagesPath
            // 
            txtPackagesPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPackagesPath.Location = new Point(156, 57);
            txtPackagesPath.Name = "txtPackagesPath";
            txtPackagesPath.Size = new Size(583, 23);
            txtPackagesPath.TabIndex = 3;
            // 
            // btnOpenPackagesPath
            // 
            btnOpenPackagesPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenPackagesPath.Location = new Point(745, 57);
            btnOpenPackagesPath.Name = "btnOpenPackagesPath";
            btnOpenPackagesPath.Size = new Size(61, 23);
            btnOpenPackagesPath.TabIndex = 4;
            btnOpenPackagesPath.Text = "...";
            btnOpenPackagesPath.UseVisualStyleBackColor = true;
            btnOpenPackagesPath.Click += btnOpenPackagesPath_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Multiselect = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(88, 17);
            label3.TabIndex = 5;
            label3.Text = "Model Name:";
            // 
            // txtModelName
            // 
            txtModelName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtModelName.Location = new Point(156, 138);
            txtModelName.Name = "txtModelName";
            txtModelName.PlaceholderText = "for example: facebook/wav2vec2-large-960h";
            txtModelName.Size = new Size(583, 23);
            txtModelName.TabIndex = 6;
            // 
            // btnConvert
            // 
            btnConvert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConvert.Location = new Point(745, 138);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(61, 23);
            btnConvert.TabIndex = 7;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // btnOpenSavePath
            // 
            btnOpenSavePath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenSavePath.Location = new Point(745, 97);
            btnOpenSavePath.Name = "btnOpenSavePath";
            btnOpenSavePath.Size = new Size(61, 23);
            btnOpenSavePath.TabIndex = 10;
            btnOpenSavePath.Text = "...";
            btnOpenSavePath.UseVisualStyleBackColor = true;
            btnOpenSavePath.Click += btnOpenSavePath_Click;
            // 
            // txtSaveFolder
            // 
            txtSaveFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSaveFolder.Location = new Point(156, 96);
            txtSaveFolder.Name = "txtSaveFolder";
            txtSaveFolder.Size = new Size(583, 23);
            txtSaveFolder.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 100);
            label4.Name = "label4";
            label4.Size = new Size(79, 17);
            label4.TabIndex = 8;
            label4.Text = "Save Folder:";
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMessage.Location = new Point(12, 176);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(794, 252);
            txtMessage.TabIndex = 11;
            txtMessage.Text = "";
            // 
            // lblNote
            // 
            lblNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblNote.AutoSize = true;
            lblNote.ForeColor = Color.Blue;
            lblNote.Location = new Point(12, 431);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(40, 17);
            lblNote.TabIndex = 12;
            lblNote.Text = "Note:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(51, 430);
            label5.Name = "label5";
            label5.Size = new Size(409, 17);
            label5.TabIndex = 13;
            label5.Text = "package \"torch\", \"transformers\", \"numpy\" and \"leb128\" are required.";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 450);
            Controls.Add(label5);
            Controls.Add(lblNote);
            Controls.Add(txtMessage);
            Controls.Add(btnOpenSavePath);
            Controls.Add(txtSaveFolder);
            Controls.Add(label4);
            Controls.Add(btnConvert);
            Controls.Add(txtModelName);
            Controls.Add(label3);
            Controls.Add(btnOpenPackagesPath);
            Controls.Add(txtPackagesPath);
            Controls.Add(label2);
            Controls.Add(cboPythonPath);
            Controls.Add(label1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Python Model to dat";
            Load += frmMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboPythonPath;
        private Label label2;
        private TextBox txtPackagesPath;
        private Button btnOpenPackagesPath;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label3;
        private TextBox txtModelName;
        private Button btnConvert;
        private Button btnOpenSavePath;
        private TextBox txtSaveFolder;
        private Label label4;
        private FolderBrowserDialog folderBrowserDialog2;
        private RichTextBox txtMessage;
        private Label lblNote;
        private Label label5;
    }
}
