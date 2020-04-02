namespace JPEGtoPDF
{
    partial class FormImageToPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageToPDF));
            this.removeSelected = new System.Windows.Forms.Button();
            this.addFiles = new System.Windows.Forms.Button();
            this.savePDF = new System.Windows.Forms.Button();
            this.panelSelection = new System.Windows.Forms.Panel();
            this.removeAll_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.listBoxImageFile = new System.Windows.Forms.ListBox();
            this.labelImageFiles = new System.Windows.Forms.Label();
            this.panelPageSizeSettings = new System.Windows.Forms.Panel();
            this.checkBoxAppearance = new System.Windows.Forms.CheckBox();
            this.infoButton = new System.Windows.Forms.Button();
            this.comboBoxAppearance = new System.Windows.Forms.ComboBox();
            this.comboBoxPages = new System.Windows.Forms.ComboBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.labelPageFormat = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOutputPath = new System.Windows.Forms.Button();
            this.textBoxOutputPath = new System.Windows.Forms.TextBox();
            this.labelOtuputPath = new System.Windows.Forms.Label();
            this.labelPDFName = new System.Windows.Forms.Label();
            this.textBoxPDFName = new System.Windows.Forms.TextBox();
            this.labelPDFOutput = new System.Windows.Forms.Label();
            this.labelPageSize = new System.Windows.Forms.Label();
            this.labelFullPages = new System.Windows.Forms.Label();
            this.labelNrImages = new System.Windows.Forms.Label();
            this.panelSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panelPageSizeSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // removeSelected
            // 
            this.removeSelected.Location = new System.Drawing.Point(3, 449);
            this.removeSelected.Name = "removeSelected";
            this.removeSelected.Size = new System.Drawing.Size(141, 41);
            this.removeSelected.TabIndex = 2;
            this.removeSelected.Text = "Remove Selected";
            this.removeSelected.UseVisualStyleBackColor = true;
            this.removeSelected.Click += new System.EventHandler(this.removeSelected_Click);
            // 
            // addFiles
            // 
            this.addFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFiles.Location = new System.Drawing.Point(3, 496);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(285, 41);
            this.addFiles.TabIndex = 3;
            this.addFiles.Text = "Add Files";
            this.addFiles.UseVisualStyleBackColor = true;
            this.addFiles.Click += new System.EventHandler(this.addFiles_Click);
            // 
            // savePDF
            // 
            this.savePDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePDF.Location = new System.Drawing.Point(496, 527);
            this.savePDF.Name = "savePDF";
            this.savePDF.Size = new System.Drawing.Size(169, 70);
            this.savePDF.TabIndex = 4;
            this.savePDF.Text = "Save ";
            this.savePDF.UseVisualStyleBackColor = true;
            this.savePDF.Click += new System.EventHandler(this.SavePDF_Click);
            // 
            // panelSelection
            // 
            this.panelSelection.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSelection.Controls.Add(this.removeAll_btn);
            this.panelSelection.Controls.Add(this.label1);
            this.panelSelection.Controls.Add(this.pictureBoxPreview);
            this.panelSelection.Controls.Add(this.listBoxImageFile);
            this.panelSelection.Controls.Add(this.removeSelected);
            this.panelSelection.Controls.Add(this.addFiles);
            this.panelSelection.Location = new System.Drawing.Point(12, 35);
            this.panelSelection.Name = "panelSelection";
            this.panelSelection.Size = new System.Drawing.Size(304, 543);
            this.panelSelection.TabIndex = 9;
            // 
            // removeAll_btn
            // 
            this.removeAll_btn.Location = new System.Drawing.Point(150, 449);
            this.removeAll_btn.Name = "removeAll_btn";
            this.removeAll_btn.Size = new System.Drawing.Size(138, 41);
            this.removeAll_btn.TabIndex = 20;
            this.removeAll_btn.Text = "Remove All";
            this.removeAll_btn.UseVisualStyleBackColor = true;
            this.removeAll_btn.Click += new System.EventHandler(this.removeAll_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Preview";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPreview.Location = new System.Drawing.Point(-2, 202);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(304, 241);
            this.pictureBoxPreview.TabIndex = 18;
            this.pictureBoxPreview.TabStop = false;
            // 
            // listBoxImageFile
            // 
            this.listBoxImageFile.FormattingEnabled = true;
            this.listBoxImageFile.ItemHeight = 16;
            this.listBoxImageFile.Location = new System.Drawing.Point(-2, 0);
            this.listBoxImageFile.Name = "listBoxImageFile";
            this.listBoxImageFile.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxImageFile.Size = new System.Drawing.Size(301, 164);
            this.listBoxImageFile.TabIndex = 4;
            this.listBoxImageFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxImageFile_MouseClick);
            // 
            // labelImageFiles
            // 
            this.labelImageFiles.AutoSize = true;
            this.labelImageFiles.Location = new System.Drawing.Point(12, 15);
            this.labelImageFiles.Name = "labelImageFiles";
            this.labelImageFiles.Size = new System.Drawing.Size(79, 17);
            this.labelImageFiles.TabIndex = 12;
            this.labelImageFiles.Text = "Image Files";
            // 
            // panelPageSizeSettings
            // 
            this.panelPageSizeSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPageSizeSettings.Controls.Add(this.checkBoxAppearance);
            this.panelPageSizeSettings.Controls.Add(this.infoButton);
            this.panelPageSizeSettings.Controls.Add(this.comboBoxAppearance);
            this.panelPageSizeSettings.Controls.Add(this.comboBoxPages);
            this.panelPageSizeSettings.Controls.Add(this.comboBoxFormat);
            this.panelPageSizeSettings.Controls.Add(this.labelPageFormat);
            this.panelPageSizeSettings.Location = new System.Drawing.Point(341, 178);
            this.panelPageSizeSettings.Name = "panelPageSizeSettings";
            this.panelPageSizeSettings.Size = new System.Drawing.Size(324, 250);
            this.panelPageSizeSettings.TabIndex = 13;
            // 
            // checkBoxAppearance
            // 
            this.checkBoxAppearance.AutoSize = true;
            this.checkBoxAppearance.Location = new System.Drawing.Point(6, 160);
            this.checkBoxAppearance.Name = "checkBoxAppearance";
            this.checkBoxAppearance.Size = new System.Drawing.Size(155, 21);
            this.checkBoxAppearance.TabIndex = 27;
            this.checkBoxAppearance.Text = "Format Appearance";
            this.checkBoxAppearance.UseVisualStyleBackColor = true;
            this.checkBoxAppearance.Visible = false;
            this.checkBoxAppearance.CheckedChanged += new System.EventHandler(this.checkBoxAppearance_CheckedChanged);
            // 
            // infoButton
            // 
            this.infoButton.Location = new System.Drawing.Point(222, 220);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(95, 23);
            this.infoButton.TabIndex = 25;
            this.infoButton.Text = "Format info.";
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxAppearance
            // 
            this.comboBoxAppearance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAppearance.FormattingEnabled = true;
            this.comboBoxAppearance.Items.AddRange(new object[] {
            "Landscape",
            "Portrait"});
            this.comboBoxAppearance.Location = new System.Drawing.Point(167, 157);
            this.comboBoxAppearance.Name = "comboBoxAppearance";
            this.comboBoxAppearance.Size = new System.Drawing.Size(107, 24);
            this.comboBoxAppearance.TabIndex = 24;
            this.comboBoxAppearance.Visible = false;
            // 
            // comboBoxPages
            // 
            this.comboBoxPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPages.FormattingEnabled = true;
            this.comboBoxPages.Location = new System.Drawing.Point(11, 81);
            this.comboBoxPages.Name = "comboBoxPages";
            this.comboBoxPages.Size = new System.Drawing.Size(264, 24);
            this.comboBoxPages.TabIndex = 22;
            this.comboBoxPages.SelectedIndexChanged += new System.EventHandler(this.comboBoxPages_SelectedIndexChanged);
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Location = new System.Drawing.Point(11, 39);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(264, 24);
            this.comboBoxFormat.TabIndex = 21;
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormat_SelectedIndexChanged);
            // 
            // labelPageFormat
            // 
            this.labelPageFormat.AutoSize = true;
            this.labelPageFormat.Location = new System.Drawing.Point(6, 10);
            this.labelPageFormat.Name = "labelPageFormat";
            this.labelPageFormat.Size = new System.Drawing.Size(97, 17);
            this.labelPageFormat.TabIndex = 18;
            this.labelPageFormat.Text = "Page Format :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonOutputPath);
            this.panel1.Controls.Add(this.textBoxOutputPath);
            this.panel1.Controls.Add(this.labelOtuputPath);
            this.panel1.Controls.Add(this.labelPDFName);
            this.panel1.Controls.Add(this.textBoxPDFName);
            this.panel1.Location = new System.Drawing.Point(341, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 120);
            this.panel1.TabIndex = 14;
            // 
            // buttonOutputPath
            // 
            this.buttonOutputPath.Location = new System.Drawing.Point(280, 33);
            this.buttonOutputPath.Name = "buttonOutputPath";
            this.buttonOutputPath.Size = new System.Drawing.Size(35, 23);
            this.buttonOutputPath.TabIndex = 19;
            this.buttonOutputPath.Text = "...";
            this.buttonOutputPath.UseVisualStyleBackColor = true;
            this.buttonOutputPath.Click += new System.EventHandler(this.ButtonOutputPath_Click);
            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.Enabled = false;
            this.textBoxOutputPath.Location = new System.Drawing.Point(9, 33);
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.Size = new System.Drawing.Size(265, 22);
            this.textBoxOutputPath.TabIndex = 18;
            // 
            // labelOtuputPath
            // 
            this.labelOtuputPath.AutoSize = true;
            this.labelOtuputPath.Location = new System.Drawing.Point(6, 13);
            this.labelOtuputPath.Name = "labelOtuputPath";
            this.labelOtuputPath.Size = new System.Drawing.Size(88, 17);
            this.labelOtuputPath.TabIndex = 17;
            this.labelOtuputPath.Text = "Output Path:";
            // 
            // labelPDFName
            // 
            this.labelPDFName.AutoSize = true;
            this.labelPDFName.Location = new System.Drawing.Point(6, 71);
            this.labelPDFName.Name = "labelPDFName";
            this.labelPDFName.Size = new System.Drawing.Size(84, 17);
            this.labelPDFName.TabIndex = 16;
            this.labelPDFName.Text = "PDF Name: ";
            // 
            // textBoxPDFName
            // 
            this.textBoxPDFName.Location = new System.Drawing.Point(9, 91);
            this.textBoxPDFName.Name = "textBoxPDFName";
            this.textBoxPDFName.Size = new System.Drawing.Size(265, 22);
            this.textBoxPDFName.TabIndex = 0;
            // 
            // labelPDFOutput
            // 
            this.labelPDFOutput.AutoSize = true;
            this.labelPDFOutput.Location = new System.Drawing.Point(338, 15);
            this.labelPDFOutput.Name = "labelPDFOutput";
            this.labelPDFOutput.Size = new System.Drawing.Size(166, 17);
            this.labelPDFOutput.TabIndex = 15;
            this.labelPDFOutput.Text = "PDF File Output Location";
            // 
            // labelPageSize
            // 
            this.labelPageSize.AutoSize = true;
            this.labelPageSize.Location = new System.Drawing.Point(338, 158);
            this.labelPageSize.Name = "labelPageSize";
            this.labelPageSize.Size = new System.Drawing.Size(96, 17);
            this.labelPageSize.TabIndex = 16;
            this.labelPageSize.Text = "Page Settings";
            // 
            // labelFullPages
            // 
            this.labelFullPages.AutoSize = true;
            this.labelFullPages.Location = new System.Drawing.Point(338, 453);
            this.labelFullPages.Name = "labelFullPages";
            this.labelFullPages.Size = new System.Drawing.Size(82, 17);
            this.labelFullPages.TabIndex = 17;
            this.labelFullPages.Text = "Full Pages :";
            // 
            // labelNrImages
            // 
            this.labelNrImages.AutoSize = true;
            this.labelNrImages.Location = new System.Drawing.Point(338, 431);
            this.labelNrImages.Name = "labelNrImages";
            this.labelNrImages.Size = new System.Drawing.Size(85, 17);
            this.labelNrImages.TabIndex = 18;
            this.labelNrImages.Text = "Images :      ";
            // 
            // FormImageToPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 609);
            this.Controls.Add(this.labelNrImages);
            this.Controls.Add(this.labelFullPages);
            this.Controls.Add(this.labelPageSize);
            this.Controls.Add(this.labelPDFOutput);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPageSizeSettings);
            this.Controls.Add(this.labelImageFiles);
            this.Controls.Add(this.panelSelection);
            this.Controls.Add(this.savePDF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormImageToPDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Expert Photo";
            this.TopMost = true;
            this.panelSelection.ResumeLayout(false);
            this.panelSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panelPageSizeSettings.ResumeLayout(false);
            this.panelPageSizeSettings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button removeSelected;
        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.Button savePDF;
        private System.Windows.Forms.Panel panelSelection;
        private System.Windows.Forms.Label labelImageFiles;
        private System.Windows.Forms.Panel panelPageSizeSettings;
        private System.Windows.Forms.Label labelPageFormat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelOtuputPath;
        private System.Windows.Forms.Label labelPDFName;
        private System.Windows.Forms.TextBox textBoxPDFName;
        private System.Windows.Forms.Label labelPDFOutput;
        private System.Windows.Forms.Label labelPageSize;
        private System.Windows.Forms.ListBox listBoxImageFile;
        private System.Windows.Forms.TextBox textBoxOutputPath;
        private System.Windows.Forms.Button buttonOutputPath;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.ComboBox comboBoxPages;
        private System.Windows.Forms.ComboBox comboBoxAppearance;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Label labelFullPages;
        private System.Windows.Forms.Label labelNrImages;
        private System.Windows.Forms.Button removeAll_btn;
        private System.Windows.Forms.CheckBox checkBoxAppearance;
    }
}

