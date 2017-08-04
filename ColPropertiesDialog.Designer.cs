namespace CameraDataDive
{
    partial class ColPropertiesDialog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button btnGetXmlData;
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbVerificationField = new System.Windows.Forms.ComboBox();
            this.lbPassFailVerification = new System.Windows.Forms.Label();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.rbFail = new System.Windows.Forms.RadioButton();
            this.rbAlways = new System.Windows.Forms.RadioButton();
            this.collectionParameters = new System.Windows.Forms.GroupBox();
            this.btnMakeColumn = new System.Windows.Forms.Button();
            this.rbXMLData = new System.Windows.Forms.RadioButton();
            this.rbCamSN = new System.Windows.Forms.RadioButton();
            this.rbInstNum = new System.Windows.Forms.RadioButton();
            this.gbDataSelection = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbXmlElementName = new System.Windows.Forms.ComboBox();
            this.tbFileNameTemplate = new System.Windows.Forms.TextBox();
            this.lblXMLElements = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbXMLFilePath = new System.Windows.Forms.TextBox();
            this.tbDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.gbFileElemInfo = new System.Windows.Forms.GroupBox();
            this.btnCancelChanges = new System.Windows.Forms.Button();
            btnGetXmlData = new System.Windows.Forms.Button();
            this.collectionParameters.SuspendLayout();
            this.gbDataSelection.SuspendLayout();
            this.gbFileElemInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetXmlData
            // 
            btnGetXmlData.BackColor = System.Drawing.Color.White;
            btnGetXmlData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnGetXmlData.Location = new System.Drawing.Point(457, 22);
            btnGetXmlData.Name = "btnGetXmlData";
            btnGetXmlData.Size = new System.Drawing.Size(171, 46);
            btnGetXmlData.TabIndex = 0;
            btnGetXmlData.Text = "Select XML Data File";
            btnGetXmlData.UseVisualStyleBackColor = false;
            btnGetXmlData.Click += new System.EventHandler(this.btnGetXmlData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(217, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Specify Column Data Properties ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cbVerificationField
            // 
            this.cbVerificationField.Enabled = false;
            this.cbVerificationField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVerificationField.FormattingEnabled = true;
            this.cbVerificationField.ItemHeight = 18;
            this.cbVerificationField.Location = new System.Drawing.Point(13, 94);
            this.cbVerificationField.Name = "cbVerificationField";
            this.cbVerificationField.Size = new System.Drawing.Size(485, 26);
            this.cbVerificationField.TabIndex = 3;
            // 
            // lbPassFailVerification
            // 
            this.lbPassFailVerification.AutoSize = true;
            this.lbPassFailVerification.Enabled = false;
            this.lbPassFailVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassFailVerification.Location = new System.Drawing.Point(12, 72);
            this.lbPassFailVerification.Name = "lbPassFailVerification";
            this.lbPassFailVerification.Size = new System.Drawing.Size(216, 17);
            this.lbPassFailVerification.TabIndex = 12;
            this.lbPassFailVerification.Text = "Select Pass/Fail Verification Field";
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPass.Location = new System.Drawing.Point(216, 30);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(126, 21);
            this.rbPass.TabIndex = 1;
            this.rbPass.Text = "Collect On Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            this.rbPass.CheckedChanged += new System.EventHandler(this.rbPass_CheckedChanged);
            // 
            // rbFail
            // 
            this.rbFail.AutoSize = true;
            this.rbFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFail.Location = new System.Drawing.Point(393, 30);
            this.rbFail.Name = "rbFail";
            this.rbFail.Size = new System.Drawing.Size(117, 21);
            this.rbFail.TabIndex = 2;
            this.rbFail.Text = "Collect On Fail";
            this.rbFail.UseVisualStyleBackColor = true;
            this.rbFail.CheckedChanged += new System.EventHandler(this.rbFail_CheckedChanged);
            // 
            // rbAlways
            // 
            this.rbAlways.AutoSize = true;
            this.rbAlways.Checked = true;
            this.rbAlways.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAlways.Location = new System.Drawing.Point(47, 30);
            this.rbAlways.Name = "rbAlways";
            this.rbAlways.Size = new System.Drawing.Size(115, 21);
            this.rbAlways.TabIndex = 0;
            this.rbAlways.TabStop = true;
            this.rbAlways.Text = "Collect Always";
            this.rbAlways.UseVisualStyleBackColor = true;
            this.rbAlways.CheckedChanged += new System.EventHandler(this.rbAlways_CheckedChanged);
            // 
            // collectionParameters
            // 
            this.collectionParameters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.collectionParameters.Controls.Add(this.rbAlways);
            this.collectionParameters.Controls.Add(this.rbFail);
            this.collectionParameters.Controls.Add(this.rbPass);
            this.collectionParameters.Controls.Add(this.lbPassFailVerification);
            this.collectionParameters.Controls.Add(this.cbVerificationField);
            this.collectionParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectionParameters.Location = new System.Drawing.Point(18, 375);
            this.collectionParameters.Name = "collectionParameters";
            this.collectionParameters.Size = new System.Drawing.Size(639, 135);
            this.collectionParameters.TabIndex = 8;
            this.collectionParameters.TabStop = false;
            this.collectionParameters.Text = "Data Collection Options";
            // 
            // btnMakeColumn
            // 
            this.btnMakeColumn.BackColor = System.Drawing.Color.White;
            this.btnMakeColumn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMakeColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeColumn.Location = new System.Drawing.Point(135, 525);
            this.btnMakeColumn.Name = "btnMakeColumn";
            this.btnMakeColumn.Size = new System.Drawing.Size(164, 46);
            this.btnMakeColumn.TabIndex = 0;
            this.btnMakeColumn.Text = "Save Column Info";
            this.btnMakeColumn.UseVisualStyleBackColor = false;
            this.btnMakeColumn.Click += new System.EventHandler(this.btnMakeColumn_Click);
            // 
            // rbXMLData
            // 
            this.rbXMLData.AutoSize = true;
            this.rbXMLData.Checked = true;
            this.rbXMLData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbXMLData.Location = new System.Drawing.Point(37, 29);
            this.rbXMLData.Name = "rbXMLData";
            this.rbXMLData.Size = new System.Drawing.Size(143, 21);
            this.rbXMLData.TabIndex = 0;
            this.rbXMLData.TabStop = true;
            this.rbXMLData.Text = "XML Data Element";
            this.rbXMLData.UseVisualStyleBackColor = true;
            this.rbXMLData.CheckedChanged += new System.EventHandler(this.rbXMLData_CheckedChanged);
            // 
            // rbCamSN
            // 
            this.rbCamSN.AutoSize = true;
            this.rbCamSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCamSN.Location = new System.Drawing.Point(216, 29);
            this.rbCamSN.Name = "rbCamSN";
            this.rbCamSN.Size = new System.Drawing.Size(169, 21);
            this.rbCamSN.TabIndex = 1;
            this.rbCamSN.TabStop = true;
            this.rbCamSN.Text = "Camera Serial Number";
            this.rbCamSN.UseVisualStyleBackColor = true;
            this.rbCamSN.CheckedChanged += new System.EventHandler(this.rbCamSN_CheckedChanged);
            // 
            // rbInstNum
            // 
            this.rbInstNum.AutoSize = true;
            this.rbInstNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInstNum.Location = new System.Drawing.Point(421, 29);
            this.rbInstNum.Name = "rbInstNum";
            this.rbInstNum.Size = new System.Drawing.Size(186, 21);
            this.rbInstNum.TabIndex = 2;
            this.rbInstNum.TabStop = true;
            this.rbInstNum.Text = "Instrument Serial Number";
            this.rbInstNum.UseVisualStyleBackColor = true;
            this.rbInstNum.CheckedChanged += new System.EventHandler(this.rbInstNum_CheckedChanged);
            // 
            // gbDataSelection
            // 
            this.gbDataSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbDataSelection.Controls.Add(this.rbInstNum);
            this.gbDataSelection.Controls.Add(this.rbCamSN);
            this.gbDataSelection.Controls.Add(this.rbXMLData);
            this.gbDataSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDataSelection.Location = new System.Drawing.Point(18, 55);
            this.gbDataSelection.Name = "gbDataSelection";
            this.gbDataSelection.Size = new System.Drawing.Size(639, 79);
            this.gbDataSelection.TabIndex = 10;
            this.gbDataSelection.TabStop = false;
            this.gbDataSelection.Text = "Data Type Selection";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "File Name Template";
            // 
            // cbXmlElementName
            // 
            this.cbXmlElementName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXmlElementName.FormattingEnabled = true;
            this.cbXmlElementName.Location = new System.Drawing.Point(145, 159);
            this.cbXmlElementName.Name = "cbXmlElementName";
            this.cbXmlElementName.Size = new System.Drawing.Size(483, 26);
            this.cbXmlElementName.TabIndex = 1;
            this.cbXmlElementName.SelectedIndexChanged += new System.EventHandler(this.fileContents_SelectedIndexChanged);
            // 
            // tbFileNameTemplate
            // 
            this.tbFileNameTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileNameTemplate.Location = new System.Drawing.Point(145, 119);
            this.tbFileNameTemplate.Name = "tbFileNameTemplate";
            this.tbFileNameTemplate.Size = new System.Drawing.Size(483, 24);
            this.tbFileNameTemplate.TabIndex = 7;
            // 
            // lblXMLElements
            // 
            this.lblXMLElements.AutoSize = true;
            this.lblXMLElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXMLElements.Location = new System.Drawing.Point(5, 158);
            this.lblXMLElements.Name = "lblXMLElements";
            this.lblXMLElements.Size = new System.Drawing.Size(134, 34);
            this.lblXMLElements.TabIndex = 4;
            this.lblXMLElements.Text = "Select XML Element\r\nFrom File";
            this.lblXMLElements.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 34);
            this.label2.TabIndex = 8;
            this.label2.Text = "Folder Name\r\nTemplate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbXMLFilePath
            // 
            this.tbXMLFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbXMLFilePath.Location = new System.Drawing.Point(145, 79);
            this.tbXMLFilePath.Name = "tbXMLFilePath";
            this.tbXMLFilePath.ReadOnly = true;
            this.tbXMLFilePath.Size = new System.Drawing.Size(483, 24);
            this.tbXMLFilePath.TabIndex = 9;
            // 
            // tbDisplayName
            // 
            this.tbDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDisplayName.Location = new System.Drawing.Point(145, 39);
            this.tbDisplayName.Name = "tbDisplayName";
            this.tbDisplayName.Size = new System.Drawing.Size(300, 24);
            this.tbDisplayName.TabIndex = 10;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.Location = new System.Drawing.Point(44, 44);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(95, 17);
            this.lblDisplayName.TabIndex = 11;
            this.lblDisplayName.Text = "Display Name";
            // 
            // gbFileElemInfo
            // 
            this.gbFileElemInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbFileElemInfo.Controls.Add(this.lblDisplayName);
            this.gbFileElemInfo.Controls.Add(this.tbDisplayName);
            this.gbFileElemInfo.Controls.Add(this.tbXMLFilePath);
            this.gbFileElemInfo.Controls.Add(btnGetXmlData);
            this.gbFileElemInfo.Controls.Add(this.label2);
            this.gbFileElemInfo.Controls.Add(this.lblXMLElements);
            this.gbFileElemInfo.Controls.Add(this.tbFileNameTemplate);
            this.gbFileElemInfo.Controls.Add(this.cbXmlElementName);
            this.gbFileElemInfo.Controls.Add(this.label1);
            this.gbFileElemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFileElemInfo.Location = new System.Drawing.Point(18, 152);
            this.gbFileElemInfo.Name = "gbFileElemInfo";
            this.gbFileElemInfo.Size = new System.Drawing.Size(639, 207);
            this.gbFileElemInfo.TabIndex = 11;
            this.gbFileElemInfo.TabStop = false;
            this.gbFileElemInfo.Text = "XML Data Item Selection";
            // 
            // btnCancelChanges
            // 
            this.btnCancelChanges.BackColor = System.Drawing.Color.White;
            this.btnCancelChanges.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelChanges.Location = new System.Drawing.Point(373, 525);
            this.btnCancelChanges.Name = "btnCancelChanges";
            this.btnCancelChanges.Size = new System.Drawing.Size(164, 46);
            this.btnCancelChanges.TabIndex = 1;
            this.btnCancelChanges.Text = "Cancel";
            this.btnCancelChanges.UseVisualStyleBackColor = false;
            // 
            // ColPropertiesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(676, 584);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelChanges);
            this.Controls.Add(this.gbFileElemInfo);
            this.Controls.Add(this.gbDataSelection);
            this.Controls.Add(this.btnMakeColumn);
            this.Controls.Add(this.collectionParameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ColPropertiesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Column Properties - Data Selection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XMLExt_FormClosing);
            this.Load += new System.EventHandler(this.ColPropertiesDialog_Load);
            this.collectionParameters.ResumeLayout(false);
            this.collectionParameters.PerformLayout();
            this.gbDataSelection.ResumeLayout(false);
            this.gbDataSelection.PerformLayout();
            this.gbFileElemInfo.ResumeLayout(false);
            this.gbFileElemInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cbVerificationField;
        private System.Windows.Forms.Label lbPassFailVerification;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.RadioButton rbFail;
        private System.Windows.Forms.RadioButton rbAlways;
        private System.Windows.Forms.GroupBox collectionParameters;
        private System.Windows.Forms.Button btnMakeColumn;
        private System.Windows.Forms.RadioButton rbXMLData;
        private System.Windows.Forms.RadioButton rbCamSN;
        private System.Windows.Forms.RadioButton rbInstNum;
        private System.Windows.Forms.GroupBox gbDataSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbXmlElementName;
        private System.Windows.Forms.TextBox tbFileNameTemplate;
        private System.Windows.Forms.Label lblXMLElements;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbXMLFilePath;
        private System.Windows.Forms.TextBox tbDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.GroupBox gbFileElemInfo;
        private System.Windows.Forms.Button btnCancelChanges;
    }
}

