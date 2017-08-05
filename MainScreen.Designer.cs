namespace CameraDataDive
{
    partial class MainScreen
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbColPropListControls = new System.Windows.Forms.GroupBox();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.btnMoveElemDown = new System.Windows.Forms.Button();
            this.btnMoveElemUp = new System.Windows.Forms.Button();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.generateColumn = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panelColPropList = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseInstrSerNbrHigh = new System.Windows.Forms.Button();
            this.btnBrowseInstrSerNbrLow = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbInstrumentSerialNbrRangeLow = new System.Windows.Forms.TextBox();
            this.tbInstrumentSerialNbrRangeHigh = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseCamSerNbrHigh = new System.Windows.Forms.Button();
            this.btnBrowseCamSerNbrLow = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCameraSerialNbrRangeLow = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCameraSerialNbrRangeHigh = new System.Windows.Forms.TextBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeNewSerNbrMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSessionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDataSelectionFilters = new System.Windows.Forms.GroupBox();
            this.gbDateTimePickers = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.gbBaseFolderPaths = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbOutPutCSVFile = new System.Windows.Forms.TextBox();
            this.btnBrowseOutputCSVFile = new System.Windows.Forms.Button();
            this.btnBrowseCameraBaseFolder = new System.Windows.Forms.Button();
            this.tbCameraDataRootFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbInstrumentDataRootFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseInstrumentBaseFolder = new System.Windows.Forms.Button();
            this.gbColPropListControls.SuspendLayout();
            this.gbButtons.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbDataSelectionFilters.SuspendLayout();
            this.gbDateTimePickers.SuspendLayout();
            this.gbBaseFolderPaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // gbColPropListControls
            // 
            this.gbColPropListControls.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gbColPropListControls.Controls.Add(this.gbButtons);
            this.gbColPropListControls.Controls.Add(this.panelColPropList);
            this.gbColPropListControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbColPropListControls.Location = new System.Drawing.Point(6, 316);
            this.gbColPropListControls.Name = "gbColPropListControls";
            this.gbColPropListControls.Size = new System.Drawing.Size(793, 435);
            this.gbColPropListControls.TabIndex = 8;
            this.gbColPropListControls.TabStop = false;
            this.gbColPropListControls.Text = "Columns - Ordered List Of Column Properties";
            // 
            // gbButtons
            // 
            this.gbButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbButtons.Controls.Add(this.btnMoveElemDown);
            this.gbButtons.Controls.Add(this.btnMoveElemUp);
            this.gbButtons.Controls.Add(this.btnDeleteEntry);
            this.gbButtons.Controls.Add(this.button4);
            this.gbButtons.Controls.Add(this.generateColumn);
            this.gbButtons.Controls.Add(this.btnEdit);
            this.gbButtons.Location = new System.Drawing.Point(9, 22);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(116, 313);
            this.gbButtons.TabIndex = 9;
            this.gbButtons.TabStop = false;
            // 
            // btnMoveElemDown
            // 
            this.btnMoveElemDown.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMoveElemDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveElemDown.Location = new System.Drawing.Point(9, 255);
            this.btnMoveElemDown.Name = "btnMoveElemDown";
            this.btnMoveElemDown.Size = new System.Drawing.Size(97, 45);
            this.btnMoveElemDown.TabIndex = 7;
            this.btnMoveElemDown.Text = "Move Down";
            this.btnMoveElemDown.UseVisualStyleBackColor = false;
            this.btnMoveElemDown.Click += new System.EventHandler(this.btnMoveElemDown_Click);
            // 
            // btnMoveElemUp
            // 
            this.btnMoveElemUp.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMoveElemUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveElemUp.Location = new System.Drawing.Point(9, 195);
            this.btnMoveElemUp.Name = "btnMoveElemUp";
            this.btnMoveElemUp.Size = new System.Drawing.Size(97, 45);
            this.btnMoveElemUp.TabIndex = 6;
            this.btnMoveElemUp.Text = "Move Up";
            this.btnMoveElemUp.UseVisualStyleBackColor = false;
            this.btnMoveElemUp.Click += new System.EventHandler(this.btnMoveElemUp_Click);
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnDeleteEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEntry.Location = new System.Drawing.Point(9, 133);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(97, 45);
            this.btnDeleteEntry.TabIndex = 5;
            this.btnDeleteEntry.Text = "Delete Entry";
            this.btnDeleteEntry.UseVisualStyleBackColor = false;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(9, 15);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 45);
            this.button4.TabIndex = 0;
            this.button4.Text = "Add New\r\nColumn";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.generateColumn_Click);
            // 
            // generateColumn
            // 
            this.generateColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateColumn.Location = new System.Drawing.Point(9, 15);
            this.generateColumn.Margin = new System.Windows.Forms.Padding(0);
            this.generateColumn.Name = "generateColumn";
            this.generateColumn.Size = new System.Drawing.Size(97, 45);
            this.generateColumn.TabIndex = 0;
            this.generateColumn.Text = "Add New\r\nColumn";
            this.generateColumn.UseVisualStyleBackColor = true;
            this.generateColumn.Click += new System.EventHandler(this.generateColumn_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(9, 72);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(97, 45);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit Entry";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panelColPropList
            // 
            this.panelColPropList.AutoScroll = true;
            this.panelColPropList.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelColPropList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColPropList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelColPropList.Location = new System.Drawing.Point(130, 23);
            this.panelColPropList.Name = "panelColPropList";
            this.panelColPropList.Size = new System.Drawing.Size(652, 399);
            this.panelColPropList.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.btnBrowseInstrSerNbrHigh);
            this.groupBox2.Controls.Add(this.btnBrowseInstrSerNbrLow);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbInstrumentSerialNbrRangeLow);
            this.groupBox2.Controls.Add(this.tbInstrumentSerialNbrRangeHigh);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(398, 217);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(381, 61);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instrument Serial Number Range";
            // 
            // btnBrowseInstrSerNbrHigh
            // 
            this.btnBrowseInstrSerNbrHigh.BackgroundImage = global::CameraDataDive.Properties.Resources.folderIcon;
            this.btnBrowseInstrSerNbrHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseInstrSerNbrHigh.Location = new System.Drawing.Point(336, 26);
            this.btnBrowseInstrSerNbrHigh.Name = "btnBrowseInstrSerNbrHigh";
            this.btnBrowseInstrSerNbrHigh.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseInstrSerNbrHigh.TabIndex = 39;
            this.btnBrowseInstrSerNbrHigh.UseVisualStyleBackColor = true;
            this.btnBrowseInstrSerNbrHigh.Click += new System.EventHandler(this.btnBrowseInstrSerNbrHigh_Click);
            // 
            // btnBrowseInstrSerNbrLow
            // 
            this.btnBrowseInstrSerNbrLow.BackgroundImage = global::CameraDataDive.Properties.Resources.folderIcon;
            this.btnBrowseInstrSerNbrLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseInstrSerNbrLow.Location = new System.Drawing.Point(153, 24);
            this.btnBrowseInstrSerNbrLow.Name = "btnBrowseInstrSerNbrLow";
            this.btnBrowseInstrSerNbrLow.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseInstrSerNbrLow.TabIndex = 38;
            this.btnBrowseInstrSerNbrLow.UseVisualStyleBackColor = true;
            this.btnBrowseInstrSerNbrLow.Click += new System.EventHandler(this.btnBrowseInstrSerNbrLow_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(194, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 29;
            this.label7.Text = "End";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Start";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbInstrumentSerialNbrRangeLow
            // 
            this.tbInstrumentSerialNbrRangeLow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbInstrumentSerialNbrRangeLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInstrumentSerialNbrRangeLow.Location = new System.Drawing.Point(43, 26);
            this.tbInstrumentSerialNbrRangeLow.Name = "tbInstrumentSerialNbrRangeLow";
            this.tbInstrumentSerialNbrRangeLow.ReadOnly = true;
            this.tbInstrumentSerialNbrRangeLow.Size = new System.Drawing.Size(102, 23);
            this.tbInstrumentSerialNbrRangeLow.TabIndex = 14;
            this.tbInstrumentSerialNbrRangeLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbInstrumentSerialNbrRangeLow.WordWrap = false;
            this.tbInstrumentSerialNbrRangeLow.TextChanged += new System.EventHandler(this.tbInstrumentSerialNbrRangeLow_TextChanged);
            // 
            // tbInstrumentSerialNbrRangeHigh
            // 
            this.tbInstrumentSerialNbrRangeHigh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbInstrumentSerialNbrRangeHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInstrumentSerialNbrRangeHigh.Location = new System.Drawing.Point(229, 26);
            this.tbInstrumentSerialNbrRangeHigh.Name = "tbInstrumentSerialNbrRangeHigh";
            this.tbInstrumentSerialNbrRangeHigh.ReadOnly = true;
            this.tbInstrumentSerialNbrRangeHigh.Size = new System.Drawing.Size(101, 23);
            this.tbInstrumentSerialNbrRangeHigh.TabIndex = 15;
            this.tbInstrumentSerialNbrRangeHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbInstrumentSerialNbrRangeHigh.WordWrap = false;
            this.tbInstrumentSerialNbrRangeHigh.TextChanged += new System.EventHandler(this.tbInstrumentSerialNbrRangeHigh_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.btnBrowseCamSerNbrHigh);
            this.groupBox1.Controls.Add(this.btnBrowseCamSerNbrLow);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbCameraSerialNbrRangeLow);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCameraSerialNbrRangeHigh);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(395, 152);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(384, 61);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Serial Number Range";
            // 
            // btnBrowseCamSerNbrHigh
            // 
            this.btnBrowseCamSerNbrHigh.BackgroundImage = global::CameraDataDive.Properties.Resources.folderIcon;
            this.btnBrowseCamSerNbrHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseCamSerNbrHigh.Location = new System.Drawing.Point(339, 25);
            this.btnBrowseCamSerNbrHigh.Name = "btnBrowseCamSerNbrHigh";
            this.btnBrowseCamSerNbrHigh.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseCamSerNbrHigh.TabIndex = 38;
            this.btnBrowseCamSerNbrHigh.UseVisualStyleBackColor = true;
            this.btnBrowseCamSerNbrHigh.Click += new System.EventHandler(this.btnBrowseCamSerNbrHigh_Click);
            // 
            // btnBrowseCamSerNbrLow
            // 
            this.btnBrowseCamSerNbrLow.BackgroundImage = global::CameraDataDive.Properties.Resources.folderIcon;
            this.btnBrowseCamSerNbrLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseCamSerNbrLow.Location = new System.Drawing.Point(154, 25);
            this.btnBrowseCamSerNbrLow.Name = "btnBrowseCamSerNbrLow";
            this.btnBrowseCamSerNbrLow.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseCamSerNbrLow.TabIndex = 37;
            this.btnBrowseCamSerNbrLow.UseVisualStyleBackColor = true;
            this.btnBrowseCamSerNbrLow.Click += new System.EventHandler(this.btnBrowseCamSerNbrLow_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(197, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 15);
            this.label6.TabIndex = 29;
            this.label6.Text = "End";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCameraSerialNbrRangeLow
            // 
            this.tbCameraSerialNbrRangeLow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCameraSerialNbrRangeLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCameraSerialNbrRangeLow.Location = new System.Drawing.Point(47, 26);
            this.tbCameraSerialNbrRangeLow.Name = "tbCameraSerialNbrRangeLow";
            this.tbCameraSerialNbrRangeLow.ReadOnly = true;
            this.tbCameraSerialNbrRangeLow.Size = new System.Drawing.Size(101, 23);
            this.tbCameraSerialNbrRangeLow.TabIndex = 12;
            this.tbCameraSerialNbrRangeLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCameraSerialNbrRangeLow.WordWrap = false;
            this.tbCameraSerialNbrRangeLow.TextChanged += new System.EventHandler(this.tbCameraSerialNbrRangeLow_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Start";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCameraSerialNbrRangeHigh
            // 
            this.tbCameraSerialNbrRangeHigh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbCameraSerialNbrRangeHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCameraSerialNbrRangeHigh.Location = new System.Drawing.Point(232, 26);
            this.tbCameraSerialNbrRangeHigh.Name = "tbCameraSerialNbrRangeHigh";
            this.tbCameraSerialNbrRangeHigh.ReadOnly = true;
            this.tbCameraSerialNbrRangeHigh.Size = new System.Drawing.Size(101, 23);
            this.tbCameraSerialNbrRangeHigh.TabIndex = 13;
            this.tbCameraSerialNbrRangeHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCameraSerialNbrRangeHigh.WordWrap = false;
            this.tbCameraSerialNbrRangeHigh.TextChanged += new System.EventHandler(this.tbCameraSerialNbrRangeHigh_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSessionToolStripMenuItem,
            this.startNewSessionToolStripMenuItem,
            this.makeNewSerNbrMapToolStripMenuItem,
            this.saveSessionToolStripMenuItem1,
            this.saveSessionAsToolStripMenuItem,
            this.loadSessionToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveSessionToolStripMenuItem.Text = "Collect Data";
            this.saveSessionToolStripMenuItem.Click += new System.EventHandler(this.saveSessionToolStripMenuItem_Click);
            // 
            // startNewSessionToolStripMenuItem
            // 
            this.startNewSessionToolStripMenuItem.Name = "startNewSessionToolStripMenuItem";
            this.startNewSessionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.startNewSessionToolStripMenuItem.Text = "Start New Session";
            this.startNewSessionToolStripMenuItem.Click += new System.EventHandler(this.startNewSessionToolStripMenuItem_Click);
            // 
            // makeNewSerNbrMapToolStripMenuItem
            // 
            this.makeNewSerNbrMapToolStripMenuItem.Name = "makeNewSerNbrMapToolStripMenuItem";
            this.makeNewSerNbrMapToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.makeNewSerNbrMapToolStripMenuItem.Text = "Make New Ser. Nbr Map";
            this.makeNewSerNbrMapToolStripMenuItem.Click += new System.EventHandler(this.makeNewSerNbrMapToolStripMenuItem_Click);
            // 
            // saveSessionToolStripMenuItem1
            // 
            this.saveSessionToolStripMenuItem1.Name = "saveSessionToolStripMenuItem1";
            this.saveSessionToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.saveSessionToolStripMenuItem1.Text = "Save Session";
            this.saveSessionToolStripMenuItem1.Click += new System.EventHandler(this.saveSessionToolStripMenuItem1_Click);
            // 
            // saveSessionAsToolStripMenuItem
            // 
            this.saveSessionAsToolStripMenuItem.Name = "saveSessionAsToolStripMenuItem";
            this.saveSessionAsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saveSessionAsToolStripMenuItem.Text = "Save Session As";
            this.saveSessionAsToolStripMenuItem.Click += new System.EventHandler(this.saveSessionAsToolStripMenuItem_Click);
            // 
            // loadSessionToolStripMenuItem1
            // 
            this.loadSessionToolStripMenuItem1.Name = "loadSessionToolStripMenuItem1";
            this.loadSessionToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.loadSessionToolStripMenuItem1.Text = "Load Session";
            this.loadSessionToolStripMenuItem1.Click += new System.EventHandler(this.loadSessionToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // gbDataSelectionFilters
            // 
            this.gbDataSelectionFilters.BackColor = System.Drawing.Color.Gainsboro;
            this.gbDataSelectionFilters.Controls.Add(this.gbDateTimePickers);
            this.gbDataSelectionFilters.Controls.Add(this.gbBaseFolderPaths);
            this.gbDataSelectionFilters.Controls.Add(this.groupBox2);
            this.gbDataSelectionFilters.Controls.Add(this.groupBox1);
            this.gbDataSelectionFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDataSelectionFilters.Location = new System.Drawing.Point(9, 31);
            this.gbDataSelectionFilters.Margin = new System.Windows.Forms.Padding(2);
            this.gbDataSelectionFilters.Name = "gbDataSelectionFilters";
            this.gbDataSelectionFilters.Padding = new System.Windows.Forms.Padding(2);
            this.gbDataSelectionFilters.Size = new System.Drawing.Size(790, 280);
            this.gbDataSelectionFilters.TabIndex = 30;
            this.gbDataSelectionFilters.TabStop = false;
            this.gbDataSelectionFilters.Text = "Data Selection Filters";
            // 
            // gbDateTimePickers
            // 
            this.gbDateTimePickers.Controls.Add(this.dtpEndDate);
            this.gbDateTimePickers.Controls.Add(this.label1);
            this.gbDateTimePickers.Controls.Add(this.label3);
            this.gbDateTimePickers.Controls.Add(this.dtpStartDate);
            this.gbDateTimePickers.Location = new System.Drawing.Point(44, 163);
            this.gbDateTimePickers.Name = "gbDateTimePickers";
            this.gbDateTimePickers.Size = new System.Drawing.Size(277, 104);
            this.gbDateTimePickers.TabIndex = 38;
            this.gbDateTimePickers.TabStop = false;
            this.gbDateTimePickers.Text = "Time Selection";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(80, 66);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(197, 21);
            this.dtpEndDate.TabIndex = 22;
            this.dtpEndDate.Value = new System.DateTime(2017, 6, 20, 10, 25, 14, 0);
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "Start Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "End Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(80, 33);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.RightToLeftLayout = true;
            this.dtpStartDate.Size = new System.Drawing.Size(197, 21);
            this.dtpStartDate.TabIndex = 21;
            this.dtpStartDate.Value = new System.DateTime(2017, 6, 20, 10, 25, 9, 0);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // gbBaseFolderPaths
            // 
            this.gbBaseFolderPaths.Controls.Add(this.label9);
            this.gbBaseFolderPaths.Controls.Add(this.tbOutPutCSVFile);
            this.gbBaseFolderPaths.Controls.Add(this.btnBrowseOutputCSVFile);
            this.gbBaseFolderPaths.Controls.Add(this.btnBrowseCameraBaseFolder);
            this.gbBaseFolderPaths.Controls.Add(this.tbCameraDataRootFolder);
            this.gbBaseFolderPaths.Controls.Add(this.label5);
            this.gbBaseFolderPaths.Controls.Add(this.label4);
            this.gbBaseFolderPaths.Controls.Add(this.tbInstrumentDataRootFolder);
            this.gbBaseFolderPaths.Controls.Add(this.btnBrowseInstrumentBaseFolder);
            this.gbBaseFolderPaths.Location = new System.Drawing.Point(9, 29);
            this.gbBaseFolderPaths.Name = "gbBaseFolderPaths";
            this.gbBaseFolderPaths.Size = new System.Drawing.Size(767, 118);
            this.gbBaseFolderPaths.TabIndex = 37;
            this.gbBaseFolderPaths.TabStop = false;
            this.gbBaseFolderPaths.Text = "Base Folder Paths";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(43, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 17);
            this.label9.TabIndex = 30;
            this.label9.Text = "Select Output CSV File";
            // 
            // tbOutPutCSVFile
            // 
            this.tbOutPutCSVFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutPutCSVFile.Location = new System.Drawing.Point(200, 80);
            this.tbOutPutCSVFile.Name = "tbOutPutCSVFile";
            this.tbOutPutCSVFile.ReadOnly = true;
            this.tbOutPutCSVFile.Size = new System.Drawing.Size(516, 24);
            this.tbOutPutCSVFile.TabIndex = 31;
            // 
            // btnBrowseOutputCSVFile
            // 
            this.btnBrowseOutputCSVFile.BackgroundImage = global::CameraDataDive.Properties.Resources.folderIcon;
            this.btnBrowseOutputCSVFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseOutputCSVFile.Location = new System.Drawing.Point(726, 80);
            this.btnBrowseOutputCSVFile.Name = "btnBrowseOutputCSVFile";
            this.btnBrowseOutputCSVFile.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseOutputCSVFile.TabIndex = 36;
            this.btnBrowseOutputCSVFile.UseVisualStyleBackColor = true;
            this.btnBrowseOutputCSVFile.Click += new System.EventHandler(this.btnBrowseOutputCSVFile_Click);
            // 
            // btnBrowseCameraBaseFolder
            // 
            this.btnBrowseCameraBaseFolder.BackgroundImage = global::CameraDataDive.Properties.Resources.folderIcon;
            this.btnBrowseCameraBaseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseCameraBaseFolder.Location = new System.Drawing.Point(726, 20);
            this.btnBrowseCameraBaseFolder.Name = "btnBrowseCameraBaseFolder";
            this.btnBrowseCameraBaseFolder.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseCameraBaseFolder.TabIndex = 28;
            this.btnBrowseCameraBaseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseCameraBaseFolder.Click += new System.EventHandler(this.btnBrowseCameraBaseFolder_Click);
            // 
            // tbCameraDataRootFolder
            // 
            this.tbCameraDataRootFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCameraDataRootFolder.Location = new System.Drawing.Point(200, 21);
            this.tbCameraDataRootFolder.Name = "tbCameraDataRootFolder";
            this.tbCameraDataRootFolder.ReadOnly = true;
            this.tbCameraDataRootFolder.Size = new System.Drawing.Size(516, 24);
            this.tbCameraDataRootFolder.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Camera Data Base Folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Instrument Data Base Folder";
            // 
            // tbInstrumentDataRootFolder
            // 
            this.tbInstrumentDataRootFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInstrumentDataRootFolder.Location = new System.Drawing.Point(200, 50);
            this.tbInstrumentDataRootFolder.Name = "tbInstrumentDataRootFolder";
            this.tbInstrumentDataRootFolder.ReadOnly = true;
            this.tbInstrumentDataRootFolder.Size = new System.Drawing.Size(516, 24);
            this.tbInstrumentDataRootFolder.TabIndex = 27;
            // 
            // btnBrowseInstrumentBaseFolder
            // 
            this.btnBrowseInstrumentBaseFolder.BackgroundImage = global::CameraDataDive.Properties.Resources.folderIcon;
            this.btnBrowseInstrumentBaseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseInstrumentBaseFolder.Location = new System.Drawing.Point(726, 50);
            this.btnBrowseInstrumentBaseFolder.Name = "btnBrowseInstrumentBaseFolder";
            this.btnBrowseInstrumentBaseFolder.Size = new System.Drawing.Size(35, 24);
            this.btnBrowseInstrumentBaseFolder.TabIndex = 35;
            this.btnBrowseInstrumentBaseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseInstrumentBaseFolder.Click += new System.EventHandler(this.btnBrowseInstrumentBaseFolder_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(808, 759);
            this.Controls.Add(this.gbDataSelectionFilters);
            this.Controls.Add(this.gbColPropListControls);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainScreen";
            this.Text = "CDT Camera and Instrument Data Mining Session";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.gbColPropListControls.ResumeLayout(false);
            this.gbButtons.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbDataSelectionFilters.ResumeLayout(false);
            this.gbDateTimePickers.ResumeLayout(false);
            this.gbDateTimePickers.PerformLayout();
            this.gbBaseFolderPaths.ResumeLayout(false);
            this.gbBaseFolderPaths.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbColPropListControls;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button generateColumn;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panelColPropList;
        private System.Windows.Forms.TextBox tbInstrumentSerialNbrRangeHigh;
        private System.Windows.Forms.TextBox tbInstrumentSerialNbrRangeLow;
        private System.Windows.Forms.TextBox tbCameraSerialNbrRangeHigh;
        private System.Windows.Forms.TextBox tbCameraSerialNbrRangeLow;
        private System.Windows.Forms.Button btnMoveElemDown;
        private System.Windows.Forms.Button btnMoveElemUp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Button btnBrowseCamSerNbrLow;
        private System.Windows.Forms.Button btnBrowseInstrSerNbrHigh;
        private System.Windows.Forms.Button btnBrowseInstrSerNbrLow;
        private System.Windows.Forms.Button btnBrowseCamSerNbrHigh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveSessionAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSessionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewSessionToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbDataSelectionFilters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseOutputCSVFile;
        private System.Windows.Forms.Button btnBrowseInstrumentBaseFolder;
        private System.Windows.Forms.TextBox tbOutPutCSVFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnBrowseCameraBaseFolder;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox tbInstrumentDataRootFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCameraDataRootFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbDateTimePickers;
        private System.Windows.Forms.GroupBox gbBaseFolderPaths;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeNewSerNbrMapToolStripMenuItem;
    }
}