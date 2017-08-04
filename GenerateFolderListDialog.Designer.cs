namespace CameraDataDive
{
    partial class GenerateFolderListDialog
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.gbRadioButtons = new System.Windows.Forms.GroupBox();
            this.rbCamData = new System.Windows.Forms.RadioButton();
            this.rbInstTest = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbRadioButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(-1, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(295, 13);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Please specify if this is a camera or instrument test";
            // 
            // gbRadioButtons
            // 
            this.gbRadioButtons.Controls.Add(this.btnOK);
            this.gbRadioButtons.Controls.Add(this.rbInstTest);
            this.gbRadioButtons.Controls.Add(this.rbCamData);
            this.gbRadioButtons.Location = new System.Drawing.Point(2, 25);
            this.gbRadioButtons.Name = "gbRadioButtons";
            this.gbRadioButtons.Size = new System.Drawing.Size(303, 68);
            this.gbRadioButtons.TabIndex = 1;
            this.gbRadioButtons.TabStop = false;
            // 
            // rbCamData
            // 
            this.rbCamData.AutoSize = true;
            this.rbCamData.Location = new System.Drawing.Point(10, 19);
            this.rbCamData.Name = "rbCamData";
            this.rbCamData.Size = new System.Drawing.Size(125, 17);
            this.rbCamData.TabIndex = 0;
            this.rbCamData.TabStop = true;
            this.rbCamData.Text = "This is a camera test.";
            this.rbCamData.UseVisualStyleBackColor = true;
            this.rbCamData.CheckedChanged += new System.EventHandler(this.rbCamData_CheckedChanged);
            // 
            // rbInstTest
            // 
            this.rbInstTest.AutoSize = true;
            this.rbInstTest.Location = new System.Drawing.Point(10, 42);
            this.rbInstTest.Name = "rbInstTest";
            this.rbInstTest.Size = new System.Drawing.Size(144, 17);
            this.rbInstTest.TabIndex = 1;
            this.rbInstTest.TabStop = true;
            this.rbInstTest.Text = "This is an instrument test.";
            this.rbInstTest.UseVisualStyleBackColor = true;
            this.rbInstTest.CheckedChanged += new System.EventHandler(this.rbInstTest_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(217, 36);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // GenerateFolderListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 95);
            this.Controls.Add(this.gbRadioButtons);
            this.Controls.Add(this.lbTitle);
            this.Name = "GenerateFolderListDialog";
            this.Text = "Select Test";
            this.gbRadioButtons.ResumeLayout(false);
            this.gbRadioButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox gbRadioButtons;
        private System.Windows.Forms.RadioButton rbCamData;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbInstTest;
    }
}