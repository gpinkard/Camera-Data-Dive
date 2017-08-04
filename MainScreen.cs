using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;


namespace CameraDataDive
{

    public partial class MainScreen : Form
    {
        ColumnProperties m_newColumnPropertiesRecord;
        private Dictionary<GroupBox, ColumnProperties> colPropDict = new Dictionary<GroupBox, ColumnProperties>();
        // maps graphical elements (groupboxes) to the columnProperties they represent
        private Dictionary<string, SerialNbrInfo> serialNbrInfoMapDict = new Dictionary<string, SerialNbrInfo>();
        // maps serial numbers to serial number info objects
        private Dictionary<string, string> instrumentCameraSerialNbrDict = new Dictionary<string, string>();
        // maps instrument serial numbers to camera serial numbers
        private List<DirectoryInfo> m_selectedCamFolderList; // a list of all the camera folders we want
        private List<string> m_discardedFilesDateList; // list of full paths to discarded files
        private List<DirectoryInfo> m_selectedInstFolderList; // a list of all the instrument folders we want
        private List<ColumnProperties> colPropList = new List<ColumnProperties>();
        private bool m_colPropDataRecieved = false; // true if we recieved ColumnProperties data
        private const string SERIAL_NBR_MAP = ".\\";
        private const string LAST_SESSION_BASE_FOLDER_PATHS = ".\\"; // holds the path to the file which holds the base paths from last session
        private string m_camBaseFolderPath; // base folder for camera serial number
        private string m_logFilePath; // the path where the log file is saved
        private string m_instBaseFolderPath; // base folder for instrument serial number
        private string m_outPutCSVFilePath; // file where the results should be saved
        private string m_camSerialNumLow; // low end of cam serial number spectrum
        private string m_camSerialNumHigh; // high end of cam serial number spectrum
        private string m_instSerialNumLow; // low end of instrument serial number spectrum
        private string m_instSerialNumHigh; // high end of instrument serial number spectrum
        private string m_sessionSaveFilePath; // the path to the file that saves session information
        private string m_serialNbrDateMapPath; // the path to where we are reading in the serial number date map to make the dictionary
        private DateTime m_dateTimeStart; // saves the start date in DateTime form
        private DateTime m_dateTimeEnd; // saves the end date in DateTime form
        private DateTime m_sessionStartTime; // saves the date time for when the instance started
        private string m_dateTimeFormatForFileNames;
        private CDTXMLSession m_SessionInfo; // for loading and saving our session
        private static GroupBox s_ActiveGroupBox; // this is the currently selected groupbox
        private bool isCameraTest; // true if we are doing a camera test, false if we are doing an inst. test
        private bool usingDefaultDate; // true if the date time constraints have not been altered by the user
        private int numFoldersChecked; // the number of folders we have checked
        private int numFilesChecked; // the number of files we have checked
        private const string k_DefaultOutputPath = "C:\\Temp";
        public MainScreen()
        {
            InitializeComponent();
            initWorkingSession();
        }

        /*
         * Initializes fields to default values at the beginning of the session
         */
        private void initWorkingSession()
        {
            bool colPropDictEmpty = (colPropDict.Count == 0);
            if (!colPropDictEmpty) // if the colPropDict dictionary is filled from a previous session
                clearPanelAndColProps(); // clear it
            bool serialNbrInfoMapDictEmpty = (serialNbrInfoMapDict.Count == 0);
            if (!serialNbrInfoMapDictEmpty) // if the serialNbrInfoMap dictionary if filled from a prev. session
                clearSerialNbrInfoMapDict(); // clear it
            m_SessionInfo = new CDTXMLSession();
            m_sessionSaveFilePath = k_DefaultOutputPath;
            m_dateTimeStart = new DateTime(2014, 1, 1); // if the user has not entered a dateTime value
            m_dateTimeEnd = DateTime.Now;
            m_sessionStartTime = m_dateTimeEnd; // sessionStartTime is exact same time as initial dateTimeEnd
            getLastSessionBaseFolderPaths(); // gets base instrument and camera folder from last session
            m_camSerialNumLow = "";
            m_camSerialNumHigh = "";
            m_instSerialNumLow = "";
            m_instSerialNumHigh = "";
            tbCameraDataRootFolder.Text = CamBaseFolderPath; // populate UI with data from member vars
            tbInstrumentDataRootFolder.Text = InstBaseFolderPath;
            tbOutPutCSVFile.Text = OutPutCSVFilePath;
            tbCameraSerialNbrRangeLow.Text = CamSerialNumLow;
            tbCameraSerialNbrRangeHigh.Text = CamSerialNumHigh;
            tbInstrumentSerialNbrRangeLow.Text = InstSerialNumLow;
            tbInstrumentSerialNbrRangeHigh.Text = InstSerialNumHigh;
            dtpStartDate.CustomFormat = "MM'/'dd'/'yyyy hh':'mm tt";
            dtpEndDate.CustomFormat = "MM'/'dd'/'yyyy hh':'mm tt";
            dtpStartDate.Value = DateTimeStart;
            dtpEndDate.Value = DateTimeEnd;
            m_dateTimeFormatForFileNames = "yyyy-MM-dd_HH-mm-ss";
            m_selectedCamFolderList = new List<DirectoryInfo>(); // instantiate lists
            m_selectedInstFolderList = new List<DirectoryInfo>();
            LogFilePath = "k_DefaultOutputPath" + DateTime.Now.ToString(m_dateTimeFormatForFileNames);
            DiscardedFilesDateList = new List<string>();
            IsCameraTest = true;
            UsingDefaultDate = true;
            m_outPutCSVFilePath = k_DefaultOutputPath + "\\CamDataMine_" + m_dateTimeEnd.ToString(m_dateTimeFormatForFileNames) + ".csv";
            tbOutPutCSVFile.Text = m_outPutCSVFilePath;
            if (!Directory.Exists(k_DefaultOutputPath))
                Directory.CreateDirectory(k_DefaultOutputPath);
        }

        /*
         * Event that triggers when the Generate Column button is clicked.
         */
        private void generateColumn_Click(object sender, EventArgs e)
        {
            ColPropDataRecieved = false;
            ColumnProperties cp = new ColumnProperties(); // create new column property
            ColPropertiesDialog cpDialog = new ColPropertiesDialog(cp, CamBaseFolderPath, InstBaseFolderPath, IsCameraTest);
            cpDialog.NewColumnPropertiesAvailable += onNewColumnPropertiesAvailable; // subscribe
            var result = cpDialog.ShowDialog(); // show the dialog
            if (result == DialogResult.OK) // if the user clicks OK
            {
                if (ColPropDataRecieved) // and the event data was recieved
                {
                    cp = m_newColumnPropertiesRecord; 
                    GroupBox gb = drawNewColPropGroupBox(cp); // draw the graphical element 
                    colPropDict.Add(gb, cp); // add the item to the dictionary
                    //colPropList.Add(cp); // add the column property to colPropList
                    colPropList.Insert(0, cp);
                }
            }
        }

        // update gui from column properties
        
        public GroupBox drawNewColPropGroupBox(ColumnProperties cp)
        {
            ColumnPropertiesListEntry colPropListEntry = new ColumnPropertiesListEntry(cp);
            colPropListEntry.NewColPropGroupBoxCreated += onNewColPropGroupBoxEntered;
            panelColPropList.Controls.Add(colPropListEntry.GBox);
            panelColPropList.Controls.SetChildIndex(colPropListEntry.GBox, 0);
            //reversePanelElements();
            return colPropListEntry.GBox;
        }

        /*
         * This method does NOT allow the user to edit the contents of an entry, it is a helper
         * function that generates the button on an element that allows for the functionality
         */
        private void onNewColumnPropertiesAvailable(object sender, NewColumnPropertiesEventArgs e)
        {
            m_newColumnPropertiesRecord = e.colProps;
            ColPropDataRecieved = true;
        }

        /*
         * Event that handles when a column property groupbox in the U.I. is entered. Highlights the
         * selected entry with a light blue, the unselected elements are white.
         */
        private void onNewColPropGroupBoxEntered(object sender, PropertyListEntrySelectedArgs e)
        {
            // This is where we check to see if we have a groupbox already highlighted and unhighlight it
            // then we set  e.colPropGroupBox as the active groupbox and highlight it
            if (s_ActiveGroupBox != null)
            {
                s_ActiveGroupBox.Controls[0].BackColor = Color.White;
            }
            s_ActiveGroupBox = e.ColPropGroupBox;
            s_ActiveGroupBox.Controls[0].BackColor = Color.LightSkyBlue;
        }

        /*
         * Event that handles when the user wants to edit the selected column property.
         */
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (s_ActiveGroupBox != null)
            {
                ColPropDataRecieved = false;
                if (colPropDict.ContainsKey(s_ActiveGroupBox))
                {
                    ColumnProperties cp = colPropDict[s_ActiveGroupBox];
                    ColPropertiesDialog cpDialog = new ColPropertiesDialog(cp, m_camBaseFolderPath, m_instBaseFolderPath, IsCameraTest);
                    cpDialog.NewColumnPropertiesAvailable += onNewColumnPropertiesAvailable; // subscribe
                    var result = cpDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (ColPropDataRecieved)
                        {
                            removeEntry(); // remove the old column properties and graphical element
                            cp = m_newColumnPropertiesRecord;
                            GroupBox gb = drawNewColPropGroupBox(cp);
                            colPropDict.Add(gb, cp);
                        }
                    }
                }
                else MessageBox.Show("The group box you are trying to edit no longer exists.");
            }
            else MessageBox.Show("Please select an element to edit.");
        }

        /*
         * Deletes a Column Property and its corresponding graphical element.
         */
        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            if (s_ActiveGroupBox != null) { removeEntry(); } // check to see if the user has selected a groupbox
            else MessageBox.Show("Please select an element to delete.");
        }

        /*
         * Delete the currently selected groupbox. Removes it from the list of column properties,
         * as well as the graphical element from the panel on the mainscreen.
         */
        private void removeEntry()
        {
            ColumnProperties colProp;
            bool success = colPropDict.TryGetValue(S_ActiveGroupBox, out colProp);
            if (success)
                colPropList.Remove(colProp); // remove column property from colPropList
            panelColPropList.Controls.Remove(s_ActiveGroupBox); // remove the groupbox graphically
            colPropDict.Remove(s_ActiveGroupBox); // remove the column properties entry
        }

        /*
         * Event that triggers when the move element up button is clicked. Moves the selected groupbox
         * up one position in the panel, if it is not already at the top.
         */
        private void btnMoveElemUp_Click(object sender, EventArgs e)
        {
            if (panelColPropList.Controls.IndexOf(s_ActiveGroupBox) != panelColPropList.Controls.Count - 1)
            {
                int index = panelColPropList.Controls.IndexOf(s_ActiveGroupBox) + 1; // the index we are moving active group box to
                ColumnProperties tempColProp = colPropList[index]; // here
                colPropList[index] = colPropList[index-1];
                colPropList[index-1] = tempColProp;
                GroupBox temp = (GroupBox)(panelColPropList.Controls[index]); // the group box at position index
                List<GroupBox> controls = new List<GroupBox>(); // we have to make copy list to manipulate the elements in the panels controls
                foreach (Control control in panelColPropList.Controls) // add all the elements from the panels controls to our new list
                {
                    GroupBox gb = (GroupBox)control;
                    controls.Add(gb);
                }
                controls[index] = s_ActiveGroupBox; // do the swapping
                controls[index - 1] = temp;
                panelColPropList.Controls.Clear(); // clear all the elements out of the list
                foreach (GroupBox gb in controls) // repopulate the list with our new control order
                    panelColPropList.Controls.Add(gb);
            }
            else MessageBox.Show("Element is already at the top of the panel.");
        }

        /*
         * Event that triggers when the move element down button is clicked. Moves the selected groupbox 
         * down one position in the panel, if it is not already at the top.
         */
        private void btnMoveElemDown_Click(object sender, EventArgs e)
        {
            if (panelColPropList.Controls.IndexOf(s_ActiveGroupBox) != 0)
            {
                int index = panelColPropList.Controls.IndexOf(s_ActiveGroupBox) - 1; // the index we are moving active group box to
                ColumnProperties tempColProp = colPropList[index];
                colPropList[index] = colPropList[index+1];
                colPropList[index+1] = tempColProp;
                GroupBox temp = (GroupBox)(panelColPropList.Controls[index]); // the group box at position index
                List<GroupBox> controls = new List<GroupBox>(); // we have to make copy list to manipulate the elements in the panels controls
                foreach (Control control in panelColPropList.Controls) // add all the elements from the panels controls to our new list
                {
                    GroupBox gb = (GroupBox)control;
                    controls.Add(gb);
                }
                controls[index] = s_ActiveGroupBox; // do the swapping
                controls[index + 1] = temp;
                panelColPropList.Controls.Clear(); // clear all the elements out of the list
                foreach (GroupBox gb in controls) // repopulate the list with our new control order
                {
                    panelColPropList.Controls.Add(gb);
                }
            }
            else MessageBox.Show("Element is already at the bottom of the panel.");
        }

        /*
         * Event that triggers when the begin collection button is clicked.
         */
        private void btnBeginCollection_Click(object sender, EventArgs e)
        {
            beginCollection(); // call the actual method
        }

        /*
         * This method calls the methods that collect the data and write it to the specified csv file.
         */
        private void beginCollection()
        {
            if (string.IsNullOrEmpty(m_outPutCSVFilePath))
                MessageBox.Show("You must select an output CSV File!");
            else
            {
                setLastSessionBaseFolderPaths(); // writes to the file that holds the base folder paths 
                generateFolderList(); // gets the list of folders we will need for the test
                populateCSVFile(); // goes into those folders to find the xml elements we need, and populates csv file
            }
        }

        /*
         * This method generates the folder lists required by the users specification.
         */
        private void generateFolderList()
        {
            checkTestType();
            if (string.IsNullOrEmpty(tbInstrumentSerialNbrRangeLow.Text) && string.IsNullOrEmpty(tbInstrumentSerialNbrRangeHigh.Text)
                && string.IsNullOrEmpty(tbCameraSerialNbrRangeLow.Text) && string.IsNullOrEmpty(tbCameraSerialNbrRangeHigh.Text)) // if the user has not given any information complain
            { // if everything is empty complain
                MessageBox.Show("Data collection is more efficient if you specify a serial number range for the cameras (or instruments).");
            }
            if (isCameraTest)
            {
                generateCamFolderList();
            }
            else
            {
                generateInstFolderList();
            }
            checkSerialNumberMap(); // check if we need to use serial number map, if so make/find it
        }

        /*
         * This method checks the test type based on the instrument/camera serial number ranges the user specified.
         * Every time the user fills in one of these fields, this method is called, which re-evaluates the whether
         * or not the test is an instrument or camera serial number test.
         */
        public void checkTestType()
        {
            if ((!string.IsNullOrEmpty(tbInstrumentSerialNbrRangeLow.Text) || !string.IsNullOrEmpty(tbInstrumentSerialNbrRangeHigh.Text))
               && (!string.IsNullOrEmpty(tbCameraSerialNbrRangeLow.Text) || !string.IsNullOrEmpty(tbCameraSerialNbrRangeHigh.Text)))
            { // if at least one camera field and one instrument field is filled in query the user as to the kind of test it is
                GenerateFolderListDialog dialog = new GenerateFolderListDialog(); // bring up dialog that queries the user
                dialog.ShowDialog();
                if (dialog.DialogResult == DialogResult.OK && (dialog.UsingCameraData || dialog.UsingInstrumentData))
                {
                    if (dialog.UsingCameraData)
                        IsCameraTest = true;
                    else if (dialog.UsingInstrumentData)
                        IsCameraTest = false;
                }
            }
            else if ((string.IsNullOrEmpty(tbInstrumentSerialNbrRangeLow.Text) && string.IsNullOrEmpty(tbInstrumentSerialNbrRangeHigh.Text))
                && (!string.IsNullOrEmpty(tbCameraSerialNbrRangeLow.Text) || !string.IsNullOrEmpty(tbCameraSerialNbrRangeHigh.Text)))
            { // if both instrument data fields are empty and at least one of the camera fields is not empty it is a camera test
                isCameraTest = true;
            }
            else if ((!string.IsNullOrEmpty(tbInstrumentSerialNbrRangeLow.Text) || !string.IsNullOrEmpty(tbInstrumentSerialNbrRangeHigh.Text))
                && (string.IsNullOrEmpty(tbCameraSerialNbrRangeLow.Text) && string.IsNullOrEmpty(tbCameraSerialNbrRangeHigh.Text)))
            { // if both camera fields are empty and at least one of the instrument fields is not it is an instrument test
                isCameraTest = false;
            }
        }

        /*
         * This method either finds an old serial number map or creates a new one if one is not found
         */

        private void checkSerialNumberMap()
        {
            bool needSerialNbrMap = false; // true if we are using inst serial num or cam serial num in a colprop
            foreach (ColumnProperties colProp in colPropList)
            {
                if (colProp.UseCamSN || colProp.UseInstSN) // check to see if we actually need the map
                    needSerialNbrMap = true;
            }
            if (needSerialNbrMap) // if we need a serial number map do:
            {
                loadSerialNbrMap(SERIAL_NBR_MAP + "SerialNumberMap.txt");
                if (!File.Exists(SERIAL_NBR_MAP + "SerialNumberMap.txt")) // check to see if the file exists
                {
                    if (!string.IsNullOrEmpty(tbCameraDataRootFolder.Text) && !string.IsNullOrEmpty(tbInstrumentDataRootFolder.Text))
                    {
                        bool success = generateSerialNbrMapFile();
                        if (success)
                            MessageBox.Show("Instrument-Camera serial number map has been updated successfully.");
                        else
                            MessageBox.Show("There was an error creating the Instrument-Camera serial number map");
                    }
                    else
                    {
                        MessageBox.Show("For this test, bot the camera data root folder and the instrument data root folder must be" +
                            " specified. Please add those fields now, then start the test again.");
                        return;
                    }
                }
            }
        }

        /*
         * This method generates the list of eligable camera folders based on the serial number
         * range of the users choosing.
         */
        private void generateCamFolderList()
        {
            int start = Int32.Parse(m_camSerialNumLow); // save the range of folders
            int end = Int32.Parse(m_camSerialNumHigh);
            DirectoryInfo di = new DirectoryInfo(m_camBaseFolderPath); // new directory info with camera root folder
            DirectoryInfo[] directories = di.GetDirectories("*", SearchOption.TopDirectoryOnly); // get all directories in root folder. top only
            foreach (DirectoryInfo dir in directories)
            {
                try
                {
                    int cur = Int32.Parse(dir.Name); // save the current elements serial number as an int
                    if (cur >= start && cur <= end) // if it is in the specified range add it to the list
                    {
                        m_selectedCamFolderList.Add(dir);
                    }
                }
                catch (Exception ex) { }
            }
        }

        /*
         * This method generates the list of eligable instrument folders based on the serial 
         * number range of the users choosing.
         */
        private void generateInstFolderList()
        {
            string strippedLowSerNbr = m_instSerialNumLow.Replace("BR", "");
            strippedLowSerNbr = strippedLowSerNbr.Replace("-", "");
            string strippedHighSerNbr = m_instSerialNumLow.Replace("BR", "");
            strippedHighSerNbr = strippedHighSerNbr.Replace("-", "");

            int dashIndex = m_instSerialNumLow.IndexOf('-') + 1; // index of the first number after the dash in the serial number
            try
            {
                int start = Int32.Parse(strippedLowSerNbr);
                int end = Int32.Parse(strippedHighSerNbr);

                // start and end have had "BR-" removed from them as well as being parsed as ints
                DirectoryInfo di = new DirectoryInfo(m_instBaseFolderPath); // new directory info with camera root folder
                DirectoryInfo[] directories = di.GetDirectories("*", SearchOption.TopDirectoryOnly);
                foreach (DirectoryInfo dir in directories)
                {
                    try
                    {
                        string strippedSerNbr = dir.Name.Replace("BR", "");
                        strippedSerNbr = strippedSerNbr.Replace("-", "");
                        int currentDir = Int32.Parse(strippedSerNbr); // current serial number we are examining
                        if (currentDir >= start && currentDir <= end) // if serial number is in directory range
                        {
                            m_selectedInstFolderList.Add(dir); // add it
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex) { }
        }

        /*
         * This method populates the specified csv file with information from the column properties
         * and the folders specified by the user
         */
        public void populateCSVFile()
        {
            var sw = System.Diagnostics.Stopwatch.StartNew(); // records how long execution time takes
            List<FileInfo> viableFiles = new List<FileInfo>(); // list of all viable files
            System.IO.StreamWriter file = new System.IO.StreamWriter(m_outPutCSVFilePath);
            StringBuilder sb = new StringBuilder();
            string header = populateCSVFileHeaders();
            file.WriteLine(header);
            getFileNameTemplates(); // make sure every colProp has a file name template
            getFolderNameTemplates(); // make sure every colProp has a folder name template
            // put if statement here to check if the user has populated dictionary
            List<DirectoryInfo> folderList = new List<DirectoryInfo>();
            if (isCameraTest) folderList = m_selectedCamFolderList;
            else folderList = m_selectedInstFolderList;
            populateCSVFileHeaders();
            using (file)
            {
                foreach (DirectoryInfo di in folderList) // outder serial number directories i.e 61600643
                {
                    sb.Append(di.Name); // for the serial number field
                    foreach (ColumnProperties colProp in colPropList)
                    {
                        if (IsCameraTest)
                        {
                            string entry = getColPropValueCam(di, colProp);
                            if (entry != ",")
                                sb.Append("," + entry);
                        }
                        else if (!IsCameraTest)
                        {
                            string entry = getColPropValueInst(di, colProp);
                            if (entry != ",")
                                sb.Append("," + entry.ToString());
                        }
                    }
                    file.WriteLine(sb.ToString());
                    sb.Clear();
                }
            }
            file.Close();
            sw.Stop();
            generateFinalReportLogFile(sw.ElapsedMilliseconds);
            MessageBox.Show("Data collection complete.");
        }

        /*
         * Method that gets the data for a camera test based on what kind of data we are collecting for a particular 
         * column property.
         */
        private string getColPropValueCam(DirectoryInfo dir, ColumnProperties colProp)
        {
            if (colProp.UseXMLData)
            {
                List<DirectoryInfo> validSubFolders = getSubFolders(dir, colProp); // get all the subfolders and put them in a list
                if (validSubFolders != null)
                {
                    return getSpecifiedFile(validSubFolders, colProp); // method that gets the file we are interested in
                }
                else return ","; // if there are no valid subfolders, just append a comma
            }
            else if (colProp.UseCamSN) // if we are using camera serial number
            {
                return getCamSN(dir); 
            }
            else if (colProp.UseInstSN) // if we are using instrument serial number
            {
                return getInstSN(dir);
            }
            else
            {
                MessageBox.Show("NO COLUMN PROPERTIES COLLECTION DATA SPECIFIED!");
                return ",";
            }
        }

        /*
         * Method that gets the data for an instrument test based on what kind of data we are
         * collecting for a particular column property.
         */
        private string getColPropValueInst(DirectoryInfo dir, ColumnProperties colProp)
        {
            DirectoryInfo[] subDirs = dir.GetDirectories(); // this is the directory whose name is the camera number 
            string camSerNbrInstTest = subDirs[0].Name;
            string flatFolderNameTemplate = "";
            if (colProp.FilePath.Contains("FlatConfig")) flatFolderNameTemplate = "FlatConfig";
            else if (colProp.FilePath.Contains("WesternFlatConfig")) flatFolderNameTemplate = "WesternFlatConfig"; 
            DirectoryInfo wantedDir = subDirs[0]; // there should only be one
            DirectoryInfo[] cameraDirs = wantedDir.GetDirectories(); // sub folders in wantedDir (dark, focus, etc.)
            colProp.FolderNameTemplate.ToLower(); 
            DirectoryInfo wantedSubFolder = getSubFolderInst(cameraDirs, colProp);
            if (colProp.UseXMLData)
            {
                if (wantedSubFolder.Name.ToLower().Contains("flat"))
                {
                    NumFoldersChecked++;
                    DirectoryInfo[] subFolders = wantedSubFolder.GetDirectories();
                    if (subFolders.Length >= 1) // get into the sub sub folder
                    {
                        NumFoldersChecked++;
                        FileInfo wantedFile = getWantedFileFlatFolder(wantedSubFolder, flatFolderNameTemplate);
                        if (wantedFile != null)
                        {
                            string xmlElem = findXMLValue(wantedFile, colProp);
                            if (!string.IsNullOrEmpty(xmlElem)) return xmlElem;
                            else return ",";
                        }
                        else
                        {
                            return ",";
                        }
                    }
                    else MessageBox.Show("Sub folder is null");
                }
                else if (wantedSubFolder.Name.ToLower().Contains("focus") || wantedSubFolder.Name.ToLower().Contains("bias") || wantedSubFolder.Name.ToLower().Contains("dark"))
                {
                    NumFoldersChecked++;
                    FileInfo wantedFile = getWantedFile(wantedSubFolder, camSerNbrInstTest);
                    if (wantedFile != null)
                    {
                        string xmlElem = findXMLValue(wantedFile, colProp);
                        if (!string.IsNullOrEmpty(xmlElem)) return xmlElem;
                        else return ",";
                    }
                    else
                    {
                        return ",";
                    }
                }
                else MessageBox.Show("sub directory '" + colProp.FilePath + "' not found! Did you select the correct folders for the test?");
                return ","; // make this the return condition for not finding the wanted element
            }
            else if (colProp.UseCamSN)
            {
                return getCamSN(dir);
            }
            else if (colProp.UseInstSN)
            {
                return getInstSN(dir);
            }
            return ",";
        }

        /*
         * This method gets the camera serial number associated with a instrument serial number
         * for a column property that is using camera serial number as one of its fields
         */

        private string getCamSN(DirectoryInfo dir)
        {
            string value;
            bool hasValue = InstrumentCameraSerialNbrDict.TryGetValue(dir.Name, out value);
            if (hasValue)
                return value;
            else
                return ",";
        }

        /*
         * This method gets the instrument serial number associated with a camera serial number
         * for a column property that is using instrument serial number as one of its fields
         */

        private string getInstSN(DirectoryInfo dir)
        {
            if (InstrumentCameraSerialNbrDict.ContainsValue(dir.Name))
            {
                string camSN = ",";
                bool keyFound = false;
                foreach (string key in InstrumentCameraSerialNbrDict.Keys)
                {
                    keyFound = InstrumentCameraSerialNbrDict.TryGetValue(key, out camSN);
                    if (keyFound && camSN.Equals(dir.Name)) // if we found the key and its value matches the camera serial
                        return key; // number we are looking for return it
                }
                return ",";
            }
            else
                return ",";
        }

        /*
         * Gets the wanted file for an inst. test from a directory based on a column property
         */
        private FileInfo getWantedFile(DirectoryInfo di, string fileNameTemplate)
        {
            FileInfo[] possibleFiles = di.GetFiles("*.xml");
            foreach (FileInfo fi in possibleFiles)
            {
                NumFilesChecked++;
                if (fi.Name.Contains(fileNameTemplate))
                {
                    if (checkFileCreationDate(fi))
                        return fi;
                    else DiscardedFilesDateList.Add(fi.FullName);
                } 
            } // need to update file name template
            return null; // file name template is not a valid metric to determine if a file is valid
        }

        /*
         * Gets the wanted file in an inst. test where the wanted file is in a flat folder. 
         */
        private FileInfo getWantedFileFlatFolder(DirectoryInfo di, string fileNameTemplate)
        {
            DirectoryInfo[] subdirs = di.GetDirectories();
            if (subdirs.Length > 0)
            {
                FileInfo[] allFiles = subdirs[0].GetFiles();
                foreach (FileInfo fi in allFiles)
                {
                    NumFilesChecked++;
                    if (fi.Name.Contains(fileNameTemplate))
                    {
                        if (checkFileCreationDate(fi))
                            return fi;
                        else DiscardedFilesDateList.Add(fi.FullName);
                    }
                        
                } // index outside of the array
            }
            //MessageBox.Show("getWantedFileFlatFolder returning null");
            return null;
        }


        /*
         * Of the subfolders in the instrument serial number folder (dark, bias, etc.), this picks out the one we are interested in 
         * based on the column properties folder name template.
         */
        private DirectoryInfo getSubFolderInst(DirectoryInfo[] dirs, ColumnProperties colProp)
        {
            foreach (DirectoryInfo di in dirs)
            {
                if (di.Name.ToLower().Contains(colProp.FolderNameTemplate.ToLower()))
                {
                    return di; // return the right directory
                }
            }
            //MessageBox.Show("returning null!");
            return null;
        }

        /*
         * Gets the sub folder(s) that we are interested in for a camera test. Does this by 
         * comparing against the column properties folder name template.
         */
        private List<DirectoryInfo> getSubFolders(DirectoryInfo di, ColumnProperties colProp)
        {
            List<DirectoryInfo> validDirs = new List<DirectoryInfo>(); // list of all subdirectories that match folder name template
            foreach (DirectoryInfo dir in di.GetDirectories()) 
            {
                NumFoldersChecked++;
                if (dir.Name.Contains(colProp.FolderNameTemplate))
                    validDirs.Add(dir); // add it
            }
            if (validDirs.Count == 0) return null; // remember to check for null!
            else if (validDirs.Count >= 1) return validDirs;
            else return null; // this should never trigger
        }

        /*
         * Goes through all of the directories given to it, and out of those directories grabs all valid files (matches filenametemplate
         * and is not empty) then goes through all those files and picks the most valid one (valid being the last modified file whose xml
         * element matches the element and pass/fail criteria we are looking for).
         */
        private string getSpecifiedFile(List<DirectoryInfo> dirs, ColumnProperties colProp)
        {
            List<FileInfo> validFiles = new List<FileInfo>(); // directory that holds potential files
            foreach (DirectoryInfo di in dirs) // this should grab all the files
            {
                foreach (FileInfo fi in di.GetFiles())
                { // go through all the files in out directory
                    NumFilesChecked++;
                    if (fi.Name.Contains(colProp.FileNameTemplate))
                    {
                        if (checkFileCreationDate(fi))
                        {
                            if (fi.Length != 0)
                                validFiles.Add(fi); // add them if they check out
                        }
                        else DiscardedFilesDateList.Add(fi.FullName);
                    }
                }
            }
            foreach (FileInfo fi in validFiles) Console.WriteLine("last write time validFiles: " + fi.LastWriteTime.ToString());
            List<FileInfo> orderedFiles = validFiles.OrderByDescending(f => f.LastWriteTime).ToList();
            foreach (FileInfo fi in orderedFiles) Console.WriteLine("last write time orderedFiles: " + fi.LastWriteTime.ToString());
            foreach (FileInfo fi in orderedFiles)
            if (orderedFiles.Count >= 0)
            { // if there is more than one potential file we need to pick the winner
                int counter = 0;
                string XMLValue = null;
                while(counter < orderedFiles.Count)
                {
                    FileInfo winner = orderedFiles[counter]; 
                    XMLValue = findXMLValue(winner, colProp); // get the XML value we are interested in
                    if (XMLValue != null)
                    {
                        return XMLValue;
                    }  
                    counter++;
                }
                return ",";
            }
            else
                return ",";
            return ",";
        }

        /*
         * This is a helper method that is given a file and a column properties. It finds the xml element we are looking for and 
         * then returns that to getspecifiedfile. If no element was found it returns a comma.
         */
        private string findXMLValue(FileInfo file, ColumnProperties colProp)
        {
            string[] lines = System.IO.File.ReadAllLines(file.FullName);
            string passFailValue = "n/a";
            bool passFailCriteria; // true if pass fail criteria matches passFailValue;
            if (colProp.CollectAlways)
                passFailCriteria = true;
            else
                passFailCriteria = false;
            if (!colProp.CollectAlways)
            {
                foreach (string line in lines)
                {
                    if (line.Contains(colProp.PassFailElemName))
                    {
                        passFailValue = formatXMLValue(line).ToLower();
                        if (passFailValue.ToLower().Contains("pass") && colProp.CollectOnPass)
                        {
                            passFailCriteria = true; // if pass fail criteria checks out set passFailCriteria to true
                            break;
                        }
                        if (passFailValue.ToLower().Contains("fail") && colProp.CollectOnFail)
                        {
                            passFailCriteria = false;
                            break;
                        }
                        break;
                    }
                }
            }
            if (passFailCriteria == false)
                return null;
            foreach (string line in lines)
            {
                if (line.Contains(colProp.XMLElemNameProp))
                {
                    string element = formatXMLValue(line); // we have to pass it the pass fail criteria element name;
                    if (string.IsNullOrEmpty(element))
                        return null;
                    else
                    {
                        //MessageBox.Show("element: " + element);
                        return element;
                    }     
                }
            }
            return null;
        }

        /*
         * This method returns true if the element of an xml value matches the collection criteria (collect
         * on pass, collect on fail, always collect), and returns false if the element does not match the 
         * collection criteria.
         */ 
        private bool checkPassFailCriteria (string element, ColumnProperties colProp)
        {
            if (string.IsNullOrEmpty(element))
            {
               // MessageBox.Show("elem: " + element); // element is always null/empty
                return false;
            }
            element.ToLower(); // put element into all lower case
            if (element.Contains("n/a") || element.Contains("></")) return false;
            else if (colProp.CollectAlways) return true; // return true if we are always collecting
            else if (colProp.CollectOnPass && (element.Contains("pass") || element.Contains("Pass"))) return true; // return true if collection criteria matches element
            else if (colProp.CollectOnFail && (element.Contains("fail") || element.Contains("Fail"))) return true; // same as above
            else return false; // otherwise return false;
        }

        private string formatXMLValue(string elem)
        {
            if (elem.Contains("></"))
                return ","; // catches if an element holds no value
            string[] separators = new string[] { ">", "</" };
            string[] splitString = elem.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string formattedElem = splitString[1];
            Console.WriteLine("original element:"+ elem+ " .formatted element: " + formattedElem.ToLower());
            return formattedElem.ToLower();
        }

        /*
         * This method gets the file name template of all column properties
         */
        private void getFileNameTemplates()
        {
            foreach (ColumnProperties colProp in colPropList) // for all column properties
            {
                if (string.IsNullOrEmpty(colProp.FileNameTemplate) && colProp.UseXMLData) // if they don't have a file name template
                {
                    colProp.FileNameTemplate = ColumnProperties.getFileNameTemplate(colProp.FilePath);
                }
            }
        }

        /*
        * This method assigns a folder name template to all column properties
        */
        private void getFolderNameTemplates()
        {
            foreach (ColumnProperties colProp in colPropList)
            {
                colProp.FolderNameTemplate = ColumnProperties.getFolderNameTemplate(IsCameraTest, colProp.FilePath);
            }
        }

        private bool checkFileCreationDate(FileInfo fi)
        {
            DateTime fiModifiedDate = fi.LastWriteTime;
            if (fiModifiedDate.CompareTo(m_dateTimeStart) >= 0 && fiModifiedDate.CompareTo(m_dateTimeEnd) <= 0)
                return true;
            else return false;
        }

        private string findXMLValueSerialNbrTest(FileInfo file, ColumnProperties colProp)
        {
            string[] lines = System.IO.File.ReadAllLines(file.FullName);
            foreach (string line in lines)
            {
                if (line.Contains(colProp.XMLElemNameProp))
                { 
                    string str = formatXMLValue(line);
                    return str;
                }
            }
            return "";
        }

        private string populateCSVFileHeaders()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("serial number,");
            foreach (ColumnProperties colProp in colPropList)
            {
                builder.Append(colProp.DisplayName + ",");
            }
            return builder.ToString();
        }

        private void readSerialNbrDateMap(string path)
        {
            char[] seperators = new char[] { ',' }; // the characters we are seperating on
            string[] allInfo = System.IO.File.ReadAllLines(path);
            for (int i = 0; i < allInfo.Length; i++)
            {
                string[] splitLine = allInfo[i].Split(seperators);
                SerialNbrInfo sni = new SerialNbrInfo(DateTime.Parse(splitLine[1]), splitLine[2], splitLine[3]);
                SerialNbrInfoMapDict.Add(splitLine[0], sni);
            }
        }

        private void btnBrowseCameraBaseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            string fileNamePath = tbCameraDataRootFolder.Text;
            string filePath = Path.GetDirectoryName(fileNamePath);
            dialog.SelectedPath = filePath;
            DialogResult operAction = dialog.ShowDialog();
            if (operAction == DialogResult.OK)
            {
                CamBaseFolderPath = dialog.SelectedPath; // save the selected path to the member var
                if (CamBaseFolderPath[CamBaseFolderPath.Length - 1] != '\\')
                    CamBaseFolderPath += '\\';

                tbCameraDataRootFolder.Text = CamBaseFolderPath; // display the user's imput
            }
        }

        private void btnBrowseInstrumentBaseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog(); // same as above
            string fileNamePath = tbInstrumentDataRootFolder.Text;
            string filePath = Path.GetDirectoryName(fileNamePath);
            dialog.SelectedPath = filePath;
            DialogResult operAction = dialog.ShowDialog();
            if (operAction == DialogResult.OK)
            {
                InstBaseFolderPath = dialog.SelectedPath;
                if (InstBaseFolderPath[InstBaseFolderPath.Length - 1] != '\\')
                    InstBaseFolderPath += '\\';
                tbInstrumentDataRootFolder.Text = InstBaseFolderPath;
            }
        }

        private void btnBrowseOutputCSVFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            string csvFileNamePath = tbOutPutCSVFile.Text;
            string csvFilePath = Path.GetDirectoryName(csvFileNamePath);
            dialog.InitialDirectory = csvFilePath;
            dialog.FileName = Path.GetFileName(csvFileNamePath);
            dialog.CreatePrompt = true;
            dialog.Filter = "CSV Files|*.csv"; // filter out non csv files
            dialog.DefaultExt = ".csv";
            dialog.AddExtension = true;
            DialogResult operAction = dialog.ShowDialog();
            if (operAction == DialogResult.OK)
            {
                m_outPutCSVFilePath = dialog.FileName;
                tbOutPutCSVFile.Text = m_outPutCSVFilePath;
                File.Create(m_outPutCSVFilePath);
            }
        }

        private void btnBrowseCamSerNbrLow_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(m_camBaseFolderPath)) // make sure the user has selected a base folder
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog(); // new file dialog
                dialog.SelectedPath = m_camBaseFolderPath; // set the starting path the the base path
                DialogResult operAction = dialog.ShowDialog();
                if (operAction == DialogResult.OK)
                {
                    DirectoryInfo di = new DirectoryInfo(dialog.SelectedPath);
                    m_camSerialNumLow = di.Name; ; // save the selected path to the member var
                    tbCameraSerialNbrRangeLow.Text = m_camSerialNumLow; // update the text field
                    checkTestType();
                }
            }
            else MessageBox.Show("You need to select a base folder path first!"); // complain if the user has not selected a base folder
        }

        private void btnBrowseCamSerNbrHigh_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(m_camBaseFolderPath))
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog(); // the rest are the same as above
                dialog.SelectedPath = m_camBaseFolderPath;
                DialogResult operAction = dialog.ShowDialog();
                if (operAction == DialogResult.OK)
                {
                    DirectoryInfo di = new DirectoryInfo(dialog.SelectedPath);
                    m_camSerialNumHigh = di.Name; ; // save the selected path to the member var
                    tbCameraSerialNbrRangeHigh.Text = m_camSerialNumHigh; // update the 
                    checkTestType();
                }
            }
            else MessageBox.Show("You need to select a base folder path first!");
        }

        private void btnBrowseInstrSerNbrLow_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(m_instBaseFolderPath))
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.SelectedPath = m_instBaseFolderPath;
                DialogResult operAction = dialog.ShowDialog();
                if (operAction == DialogResult.OK)
                {
                    DirectoryInfo di = new DirectoryInfo(dialog.SelectedPath);
                    m_instSerialNumLow = di.Name;
                    tbInstrumentSerialNbrRangeLow.Text = m_instSerialNumLow;
                    checkTestType();
                }
            }
            else MessageBox.Show("You need to select a base folder path first!");
        }

        private void btnBrowseInstrSerNbrHigh_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(m_instBaseFolderPath))
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.SelectedPath = m_instBaseFolderPath;
                DialogResult operAction = dialog.ShowDialog();
                if (operAction == DialogResult.OK)
                {
                    DirectoryInfo di = new DirectoryInfo(dialog.SelectedPath);
                    m_instSerialNumHigh = di.Name;
                    tbInstrumentSerialNbrRangeHigh.Text = m_instSerialNumHigh;
                    checkTestType();
                }
            }
            else MessageBox.Show("You need to select a base folder path first!");
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            m_dateTimeStart = dtpStartDate.Value;
            if (m_dateTimeStart.ToString().Equals("1/1/2014 12:00:00 AM") && m_dateTimeEnd.Equals(SessionStartTime))
            {
                UsingDefaultDate = true;
            }
            else UsingDefaultDate = false;
            checkTestType();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (m_dateTimeStart != null) // make sure we have a start date time to work off of
            {
                int dtComparator = dtpStartDate.Value.CompareTo(dtpEndDate.Value); // int holds date comparison result
                if (dtComparator < 0) // end date cannot be before start date
                {
                    m_dateTimeEnd = dtpEndDate.Value; // save value to member variable if everything checks out
                    if (m_dateTimeStart.ToString().Equals("1/1/2014 12:00:00 AM") && m_dateTimeEnd.Equals(SessionStartTime))
                        UsingDefaultDate = true;
                    else
                        UsingDefaultDate = false;
                    checkTestType();
                }
                else
                    MessageBox.Show("End date cannot be before the start date!");
            }
            else
                MessageBox.Show("Please select a start date first.");
        }

        private void makeNewSerNbrMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCameraDataRootFolder.Text) || (!string.IsNullOrEmpty(tbInstrumentDataRootFolder.Text)))
            {
                bool success = generateSerialNbrMapFile();
                if (success)
                {
                    loadSerialNbrMap(SERIAL_NBR_MAP + "SerialNumberMap.txt");
                    MessageBox.Show("Serial map generated.");
                }
                else
                    MessageBox.Show("Serial map was NOT generated!");
            }
            else
                MessageBox.Show("To generate a new serial number map files both instrument and camera serial number folders must hold a path " +
                    "to their respective directories.");
        }

        /*
         * Saves the session by serializing the object
         */
        private void saveSession()
        {
            populateCDTXMLSession(m_SessionInfo);
            if (!string.IsNullOrEmpty(m_sessionSaveFilePath) && m_sessionSaveFilePath.Contains(".bin")) // if we have a file we are saveing to
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(m_sessionSaveFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, m_SessionInfo);
                stream.Close();
            }
            else // otherwise we call the save as method
            {
                saveSessionAs();
            }
            //string path = dialog.FileName; // save file name
        }

        private void saveSessionAs()
        {
            populateCDTXMLSession(m_SessionInfo);
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "BIN Files|*.bin"; // filter out non bin files
            string filePath = Path.GetDirectoryName(m_sessionSaveFilePath);
            dialog.InitialDirectory = filePath;
            dialog.CreatePrompt = true; // allow the user to create the file should the file not exist
            dialog.DefaultExt = ".bin"; // make sure that we save as a bin file
            dialog.AddExtension = true;
            dialog.ShowDialog();
            if (!string.IsNullOrEmpty(dialog.FileName)) // stops programming from crashing if the user cancels
            {
                m_sessionSaveFilePath = dialog.FileName;
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(m_sessionSaveFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, m_SessionInfo);
                stream.Close();
            }
        }

        private void saveSessionAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveSessionAs();
        }

        /*
         * Loads session by de-serializing object and repopulating fields
         */
        private void loadSession()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string initialFolder = Path.GetDirectoryName(m_sessionSaveFilePath);
            dialog.InitialDirectory = initialFolder;
            dialog.Filter = "BIN Files|*.bin"; // filter out non bin files
            DialogResult operAction = dialog.ShowDialog();
            if (operAction != DialogResult.OK)
            {
                return;
            }
            string path = dialog.FileName;
            IFormatter formatter = new BinaryFormatter();
            if (!string.IsNullOrEmpty(path))
            {
                clearPanelAndColProps();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                m_SessionInfo = (CDTXMLSession)formatter.Deserialize(stream); // deserialize the session? Right?
                stream.Close();
                extractCDTXMLSession(m_SessionInfo); // populate the fields in mainscreen with values from serialized object
                colPropDict = generateColPropDict(m_SessionInfo.ColPropList); // make the dictionary
                colPropList = m_SessionInfo.ColPropList;
                m_sessionSaveFilePath = path;
            }
        }

        /*
         * This method makes the log file that summerizes the test.  
         */
        private void generateFinalReportLogFile(long timeElapsed)
        {
            //FileInfo logFile = new FileInfo(m_outPutCSVFilePath);
            StringBuilder sb = new StringBuilder();
            string fileName;
            if (IsCameraTest)
                fileName = "camTestResults_";
            else
                fileName = "instTestResults_";           
            fileName = fileName + DateTime.Now.ToString("yyyy_MM_dd-hh-mm-ss") + ".log";
            string path = getOutPutPath() + "\\" + fileName;
            if (File.Exists(path))
                File.Delete(path);
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    string camDataTest;
                    string discardedFiles;
                    string foldersChecked = NumFoldersChecked.ToString() + " folders were checked during this test";
                    string filesChecked = NumFilesChecked.ToString() + " files were checked during this test";
                    string timeElapsedStr = "The test took " + timeElapsed.ToString() + " milliseconds.";
                    if (isCameraTest)
                        camDataTest = "Camera Test";
                    else
                        camDataTest = "Instrument Test";
                    if (m_discardedFilesDateList.Count == 0)
                        discardedFiles = "No files were discarded due to date constraints";
                    else
                        discardedFiles = m_discardedFilesDateList.Count + " files were discarded due to date constraints";
                    sw.WriteLine(camDataTest + " on " + m_sessionStartTime.ToString());
                    sw.WriteLine(foldersChecked);
                    sw.WriteLine(filesChecked);
                    sw.WriteLine(timeElapsedStr);
                    sw.WriteLine(discardedFiles);
                    if (m_discardedFilesDateList.Count > 0)
                    {
                        sw.WriteLine("Discarded Files:");
                        foreach (string str in m_discardedFilesDateList)
                        {
                            sw.WriteLine(str);
                        }
                    }
                    sw.Close();
                }
            }
        }

        /*
         * This gets the log files path based on the output csv files path. The log file is put
         * in whatever folder the user specified the csv file should be put in.
         */
        private string getOutPutPath()
        {
            FileInfo XMLFile = new FileInfo(m_outPutCSVFilePath);
            return XMLFile.Directory.FullName;
        }

        /*
         * Populates the current mainscreen with elements from a recently serialized
         * CDTXMLSession object, excluding the colPropDict dictionary.
         */
        private void extractCDTXMLSession(CDTXMLSession session)
        {
            CamBaseFolderPath = session.CamBaseFolderPath; // grab elements from session and populate member vars
            InstBaseFolderPath = session.InstBaseFolderPath;
            OutPutCSVFilePath = session.OutPutCSVFilePath;
            CamSerialNumLow = session.CamSerialNumLow;
            CamSerialNumHigh = session.CamSerialNumHigh;
            isCameraTest = session.IsCameraTest;
            InstSerialNumLow = session.InstSerialNumLow;
            InstSerialNumHigh = session.InstSerialNumHigh;
            DateTimeStart = DateTime.Parse(session.DateTimeStart);
            DateTimeEnd = DateTime.Parse(session.DateTimeEnd);
            tbCameraDataRootFolder.Text = CamBaseFolderPath; // populate UI with data from member vars
            tbInstrumentDataRootFolder.Text = InstBaseFolderPath;
            tbOutPutCSVFile.Text = OutPutCSVFilePath;
            tbCameraSerialNbrRangeLow.Text = CamSerialNumLow;
            tbCameraSerialNbrRangeHigh.Text = CamSerialNumHigh;
            tbInstrumentSerialNbrRangeLow.Text = InstSerialNumLow;
            tbInstrumentSerialNbrRangeHigh.Text = InstSerialNumHigh;
            dtpStartDate.Value = DateTimeStart;
            dtpEndDate.Value = DateTimeEnd;
        }

        /*
         * This method populates the CDTXMLSession object with data
         */
        private void populateCDTXMLSession(CDTXMLSession session)
        {
            session.ColPropList = generateColPropList(); // populate column property list
            session.CamBaseFolderPath = CamBaseFolderPath; // populate the rest of the fields
            session.InstBaseFolderPath = InstBaseFolderPath;
            session.OutPutCSVFilePath = OutPutCSVFilePath;
            session.CamSerialNumLow = CamSerialNumLow;
            session.CamSerialNumHigh = CamSerialNumHigh;
            session.InstSerialNumLow = InstSerialNumLow;
            session.InstSerialNumHigh = InstSerialNumHigh;
            session.IsCameraTest = isCameraTest;
            if (DateTimeStart.Equals(null) || DateTimeStart.ToString().Equals("1/1/0001 12:00:00 AM"))
            {
                DateTimeStart = new DateTime(2014, 1, 1);// if the user has not entered a dateTime value
                MessageBox.Show("Using todays date as start date as no start date was entered.");
            }

            if (DateTimeEnd.Equals(null) || DateTimeEnd.ToString().Equals("1/1/0001 12:00:00 AM"))
            {
                DateTimeEnd = DateTime.Now;
                MessageBox.Show("Using todays date as end date as no end date was entered");
            }
            session.DateTimeStart = DateTimeStart.ToString();
            session.DateTimeEnd = DateTimeEnd.ToString();
        }

        /*
         * Takes the dictionary and generates a list of colprop objects
         */
        private List<ColumnProperties> generateColPropList()
        {
            List<ColumnProperties> colPropList = new List<ColumnProperties>();
            colPropList.AddRange(colPropDict.Values);
            return colPropList;
        }

        private Dictionary<GroupBox, ColumnProperties> generateColPropDict(List<ColumnProperties> colPropList)
        {
            colPropDict.Clear(); // remove all old elements just in case
            foreach (ColumnProperties colProp in colPropList) // go through list 
            {
                GroupBox gb = drawNewColPropGroupBox(colProp); // repopulate dictionary
                colPropDict.Add(gb, colProp);
            }
            return colPropDict;
        }

        private void startNewSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initWorkingSession();
        }
        
        /*
         * Generates a new serial number map file as well as a new serial number map. Returns true
         * if serial number map was generated.
         */
        private bool generateSerialNbrMapFile()
        {
            string fileName = "SerialNumberMap.txt";
            string path = SERIAL_NBR_MAP + fileName;
            string instPath = tbInstrumentDataRootFolder.Text;
            if (File.Exists(path)) // delete the old file
                File.Delete(path);
            if (!File.Exists(path))
            {
                if (string.IsNullOrEmpty(InstBaseFolderPath))
                {
                    MessageBox.Show("You must first provide a valid Instrument Data Base Folder to generate the camera-instrument serial number map.");
                    return false;
                }
                DirectoryInfo dir = new DirectoryInfo(InstBaseFolderPath);
                DirectoryInfo[] diInstrList = dir.GetDirectories();
                DirectoryInfo[] subDirs;
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (DirectoryInfo di in diInstrList)
                    {
                        subDirs = di.GetDirectories();
                        string instSerNbr = di.Name;
                        string camSerNbr = subDirs[subDirs.Length - 1].Name;
                        if (checkSerialNumberMapFile(instSerNbr, camSerNbr))
                        {
                            string line = instSerNbr + "," + camSerNbr;
                            sw.WriteLine(line);
                        }
                    }
                    sw.Close();
                    return true;
                }
            }
            else
                return false;
        }
        
        private void loadSerialNbrMap(string path)
        {
            string[] contents = File.ReadAllLines(path);
            foreach (string line in contents)
            {
                string[] keyAndVal = line.Split(',');
                if (InstrumentCameraSerialNbrDict.ContainsKey(keyAndVal[0]))
                    continue;
                InstrumentCameraSerialNbrDict.Add(keyAndVal[0], keyAndVal[1]); // add it to dictionary
            }
        }

        /*
         * This method takes a key and value string pair to check them before they go into
         * the InstrumentCameraSerialNbrDict. Returns true if it is a valid entry
         */
        private bool checkSerialNumberMapFile(string instSerNum, string camSerNum)
        {
            if (camSerNum.StartsWith("CDT") || camSerNum.StartsWith("61") || camSerNum.StartsWith("A1"))
                return true;
            if (instSerNum.StartsWith("73"))
                return true;
            return false;
        }

        /*
         * Sets the instrument and camera base folder paths based on what was used the previous session
         */
        private void getLastSessionBaseFolderPaths()
        {
            if (File.Exists(LAST_SESSION_BASE_FOLDER_PATHS + "lastSessionFolderPaths.txt"))
            {
                string[] lines = File.ReadAllLines(LAST_SESSION_BASE_FOLDER_PATHS + "lastSessionFolderPaths.txt");
                CamBaseFolderPath = lines[0];
                InstBaseFolderPath = lines[1];
                m_sessionSaveFilePath = lines[2];
                if (CamBaseFolderPath[CamBaseFolderPath.Length-1] != '\\')
                    CamBaseFolderPath += '\\';
                if (InstBaseFolderPath[InstBaseFolderPath.Length - 1] != '\\')
                    InstBaseFolderPath += '\\';
            }
            else
            {
                CamBaseFolderPath = "";
                InstBaseFolderPath = "";
                //m_sessionSaveFilePath = ""; // has default in c:\temp
            }
        }

        private void setLastSessionBaseFolderPaths()
        {
            string fullPath = (LAST_SESSION_BASE_FOLDER_PATHS + "lastSessionFolderPaths.txt");
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            if (!File.Exists(fullPath))
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    string camBaseFolderPath = tbCameraDataRootFolder.Text;
                    string instBaseFolderPath = tbInstrumentDataRootFolder.Text;
                    if (camBaseFolderPath[camBaseFolderPath.Length - 1] != '\\')
                        camBaseFolderPath += '\\';
                    if (instBaseFolderPath[instBaseFolderPath.Length - 1] != '\\')
                        instBaseFolderPath += '\\';
                    sw.WriteLine(camBaseFolderPath);
                    sw.WriteLine(instBaseFolderPath);
                    sw.WriteLine(m_sessionSaveFilePath);
                }
            }
        }

        /*
         * This function puts the controls in the U.I. panel in the correct order
         */
        private void reversePanelElements()
        {
            List<Control> controls = new List<Control>();
            foreach (Control ctrl in panelColPropList.Controls)
                controls.Add(ctrl);
            panelColPropList.Controls.Clear();
            controls.Reverse();
            foreach (Control ctrl in controls)
                panelColPropList.Controls.Add(ctrl);
        }

        /*
         * This method removes all entries from the column property dictionary, as well as 
         * removing the graphical elements from the panel on the mainscreen
         */
        private void clearPanelAndColProps()
        {
            colPropDict.Clear();
            panelColPropList.Controls.Clear();
        }

        private void clearSerialNbrInfoMapDict()
        {
            serialNbrInfoMapDict.Clear();
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginCollection(); // this is actually the collect data button on the menu bar...
        }

        private void btnSaveSession_Click(object sender, EventArgs e)
        {
            saveSession();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSession();
        }

        private void btnLoadSession_Click(object sender, EventArgs e)
        {
            loadSession();
        }

        private void saveSessionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveSession();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void tbCameraSerialNbrRangeLow_TextChanged(object sender, EventArgs e)
        {
            checkTestType();
        }

        private void tbCameraSerialNbrRangeHigh_TextChanged(object sender, EventArgs e)
        {
            checkTestType();
        }

        private void tbInstrumentSerialNbrRangeLow_TextChanged(object sender, EventArgs e)
        {
            checkTestType();
        }

        private void tbInstrumentSerialNbrRangeHigh_TextChanged(object sender, EventArgs e)
        {
            checkTestType();
        }

        ////////////PROPERTIES/////////////

        public bool ColPropDataRecieved { get => m_colPropDataRecieved; set => m_colPropDataRecieved = value; }
        public static GroupBox S_ActiveGroupBox { get => s_ActiveGroupBox; set => s_ActiveGroupBox = value; }
        public bool ColPropDataRecieved1 { get => m_colPropDataRecieved; set => m_colPropDataRecieved = value; }
        public string CamBaseFolderPath { get => m_camBaseFolderPath; set => m_camBaseFolderPath = value; }
        public string InstBaseFolderPath { get => m_instBaseFolderPath; set => m_instBaseFolderPath = value; }
        public string OutPutCSVFilePath { get => m_outPutCSVFilePath; set => m_outPutCSVFilePath = value; }
        public string CamSerialNumLow { get => m_camSerialNumLow; set => m_camSerialNumLow = value; }
        public string CamSerialNumHigh { get => m_camSerialNumHigh; set => m_camSerialNumHigh = value; }
        public string InstSerialNumLow { get => m_instSerialNumLow; set => m_instSerialNumLow = value; }
        public string InstSerialNumHigh { get => m_instSerialNumHigh; set => m_instSerialNumHigh = value; }
        public DateTime DateTimeStart { get => m_dateTimeStart; set => m_dateTimeStart = value; }
        public DateTime DateTimeEnd { get => m_dateTimeEnd; set => m_dateTimeEnd = value; }
        internal CDTXMLSession SavedRecord { get => m_SessionInfo; set => m_SessionInfo = value; }
        public bool IsCameraTest { get => isCameraTest; set => isCameraTest = value; }
        public bool UsingDefaultDate { get => usingDefaultDate; set => usingDefaultDate = value; }
        public DateTime SessionStartTime { get => m_sessionStartTime; set => m_sessionStartTime = value; }
        public string SerialNbrDateMapPath { get => m_serialNbrDateMapPath; set => m_serialNbrDateMapPath = value; }
        public string SerialNbrDateMapPath1 { get => m_serialNbrDateMapPath; set => m_serialNbrDateMapPath = value; }
        internal Dictionary<string, SerialNbrInfo> SerialNbrInfoMapDict { get => serialNbrInfoMapDict; set => serialNbrInfoMapDict = value; }
        public Dictionary<string, string> InstrumentCameraSerialNbrDict { get => instrumentCameraSerialNbrDict; set => instrumentCameraSerialNbrDict = value; }
        public List<string> DiscardedFilesDateList { get => m_discardedFilesDateList; set => m_discardedFilesDateList = value; }
        public string LogFilePath { get => m_logFilePath; set => m_logFilePath = value; }
        public int NumFoldersChecked { get => numFoldersChecked; set => numFoldersChecked = value; }
        public int NumFilesChecked { get => numFilesChecked; set => numFilesChecked = value; }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            setLastSessionBaseFolderPaths();
        }
    }
}