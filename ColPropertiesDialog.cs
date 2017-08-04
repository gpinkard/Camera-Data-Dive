using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraDataDive
{

    public partial class ColPropertiesDialog : Form
    {
        private string m_filepath; // this is the filepath in string for to the XML file we want to look at
        private string baseCamFolderPath; // the path to the base camera folder
        private string baseInstFolderPath; // the path to the base instrument folder
        private bool m_isCameraTest; // true if we are doing a camera test
        private ColumnProperties m_activeColumnProperty;
        public delegate void NewColPropEventHandler(object source, EventArgs e);
        public event EventHandler<NewColumnPropertiesEventArgs> NewColumnPropertiesAvailable;
        private bool m_formInitComplete;
        public ColPropertiesDialog(ColumnProperties cp, string baseCamFolderPath, string baseInstFolderPath, bool doCameraTest)
        {
            m_formInitComplete = false;
            InitializeComponent();
            m_activeColumnProperty = cp;
            m_activeColumnProperty.CollectAlways = true;
            m_activeColumnProperty.CollectOnFail = false;
            m_activeColumnProperty.CollectOnPass = false;
            m_isCameraTest = doCameraTest;
            this.baseCamFolderPath = baseCamFolderPath;
            this.baseInstFolderPath = baseInstFolderPath;
            UpdateColPropViewInfo();
            m_formInitComplete = true;
            cbXmlElementName.MouseWheel += new MouseEventHandler(comboBox_MouseWheel);
        }
        void comboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        /////////////////////////////////////
        ///////////// Member Data ///////////
        /////////////////////////////////////


        protected virtual void OnNewColumnPropertiesAvailable()
        {
            // TBD   -   Collect data from GUI and put it into a new col prop record
            ColumnProperties colProps = new ColumnProperties();
            colProps.CollectAlways = rbAlways.Checked;
            colProps.CollectOnFail = rbFail.Checked;
            colProps.CollectOnPass = rbPass.Checked;
            colProps.UseCamSN = rbCamSN.Checked;
            colProps.UseInstSN = rbInstNum.Checked;
            colProps.UseXMLData = rbXMLData.Checked;
            colProps.XMLElemNameProp = cbXmlElementName.GetItemText(cbXmlElementName.SelectedItem);
            colProps.FileNameTemplate = tbFileNameTemplate.Text;
            colProps.PassFailElemName = cbVerificationField.Text;
            colProps.FilePath = m_filepath;
            if (String.IsNullOrEmpty(tbDisplayName.Text))
            { // if the user has not designated a name use a default one
                if (colProps.UseCamSN) colProps.DisplayName = "Camera Serial Nbr.";
                else if (colProps.UseInstSN) colProps.DisplayName = "Inst. Serial Nbr.";
                else colProps.DisplayName = colProps.XMLElemNameProp;
            }
            else
            {
                colProps.DisplayName = tbDisplayName.Text;
            }
            // ???  TBD  -- we need to get folder name for instrument or camera serial nbr
            ///          --  colProps.ParentDirectory = Directory.GetParent(filepath).ToString();

            NewColumnPropertiesEventArgs args = new NewColumnPropertiesEventArgs();
            args.colProps = colProps;
            EventHandler<NewColumnPropertiesEventArgs> handler = NewColumnPropertiesAvailable; // publish new data
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void UpdateColPropViewInfo()  // use cached ColumnProperties from m_activeColumnProperty
        {
            if (m_activeColumnProperty.CollectOnFail)
                rbFail.Checked = true;
            else if (m_activeColumnProperty.CollectOnPass)
                rbPass.Checked = true;
            else
            {
                m_activeColumnProperty.CollectAlways = true;
                rbAlways.Checked = true;
            }
            if (m_activeColumnProperty.UseCamSN)
                rbCamSN.Checked = true;
            else if (m_activeColumnProperty.UseInstSN)
                rbInstNum.Checked = true;
            else
            {
                m_activeColumnProperty.UseXMLData = true;
                rbXMLData.Checked = true;
            }

            tbFileNameTemplate.Text = m_activeColumnProperty.FileNameTemplate;
            cbVerificationField.Text = m_activeColumnProperty.PassFailElemName;
            m_filepath = m_activeColumnProperty.FilePath;
            updateXMLComboBoxes(m_filepath);

            if (!string.IsNullOrEmpty(m_activeColumnProperty.XMLElemNameProp))
            {
                cbXmlElementName.SelectedIndex = cbXmlElementName.FindStringExact(m_activeColumnProperty.XMLElemNameProp);
            }
            if (!string.IsNullOrEmpty(m_activeColumnProperty.PassFailElemName))
            {
                cbVerificationField.SelectedIndex = cbVerificationField.FindStringExact(m_activeColumnProperty.PassFailElemName);
            }
        }

        /*
         * On click, finds all XML files in a specified folder. When the user selects one, it
         * is processed by getXMLElementString. Also filters out based on user specified input,
         * i.e PSV or FST.
         */
        private void btnGetXmlData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (IsCameraTest)
                dialog.InitialDirectory = BaseCamFolderPath;
            else
                dialog.InitialDirectory = BaseInstFolderPath;
            string fileTemplate = tbFileNameTemplate.Text.ToUpper(); // this string holds the contents of the textbox for user spec. file template
            dialog.Filter = "XML Files|*.xml"; // we only want xml files
            if (fileTemplate != "") // if the user specified something for a file template
            { // here
                dialog.Filter = "wantedFiles (" + fileTemplate + "*.xml)| " + fileTemplate + "*.xml"; // filter elements based on that template
            }
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                m_filepath = dialog.FileName;
                if (isXmlFileComplex(m_filepath))
                {
                    MessageBox.Show("Feature not yet implemented: Unable to process complex XML files with nested or repeated elements.");
                    return;
                }
                updateXMLComboBoxes(m_filepath);
                tbFileNameTemplate.Text = getFileNameTemplate(m_filepath);
                tbXMLFilePath.Text = getFolderNameTemplate(m_filepath);
                FileInfo fi = new FileInfo(m_filepath);
                if (fi.Directory.Root.Name.Equals(BaseInstFolderPath))
                    collectionParameters.Enabled = false;
            }
        }

        /*
         * Returns true if the XML file in question has complex elements in it
         */
        private bool isXmlFileComplex(string filepath)
        {
            //bool elemOpen = false;
            //char lastc = '?';
            //int elemCloseCount = 0;
            //string lines = System.IO.File.ReadAllText(filepath);
            //int ix = 0;
            //int lastIx = lines.Length - 1;
            //for (ix = 0; ix <= lastIx; ++ix)
            //{
            //    char c = lines[ix];
            //    if (c == '/' && lastc == '<')
            //    {
            //        elemOpen = false;
            //        ++elemCloseCount;
            //    }
            //    else if (c == '<')
            //    {
            //        //MessageBox.Show("elemCloseCount:" + elemCloseCount.ToString());
            //        if (elemOpen && elemCloseCount > 3)
            //            return true;
            //        elemOpen = true;
            //    }
            //    else if (c == '!' && lastc == '<')
            //    {
            //        elemOpen = false;
            //    }
            //    lastc = c;
            //}
            //return false;
            string[] allLines = System.IO.File.ReadAllLines(filepath);
            string line = "";
            string nextLine = "";
            for (int i = 5; i < allLines.Length; i++) // change the value of i to ignore catching the root element
            {
                line = allLines[i - 2];
                nextLine = allLines[i - 1];
                if (line.Contains("</") || line.Contains("<!")) // if xml element is closed or it is the root
                    continue;
                else if (!line.Contains("</")) // if the line does not contain a closed tag
                {
                    int nameStart = line.IndexOf("<") + 1;
                    int nameEnd = line.IndexOf(">") - 1;
                    string name = line.Substring(nameStart, nameEnd);
                    if (nextLine.Contains(name) && nextLine.Contains("</")) // if the next line contains the elements name and a closing tag
                        continue; // continue
                    else if (i != allLines.Length && allLines[i + 1].Contains(name) && nextLine.Contains("</")) // if the line two lines ahead
                        continue; // contains the elements name and a closing tag continue
                    else // if the above are not true we have a problem
                        return true;
                } 
            }
            return false;
        }

        /*
         * Gets the file name template of the file specified by the user.
         */
        private string getFileNameTemplate(string filePath)
        {
            string result = "";
            DirectoryInfo tdi = new DirectoryInfo(filePath);
            string dirName = tdi.Name;
            char[] separators = new char[] { '-', '_', '.' };
            string[] splitString = dirName.Split(separators);
            result = splitString[0];
            return result;
        }

        /*
         * Gets the folder name template of the folder specified by the user.
         */
        private string getFolderNameTemplate(string filePath)
        {
            string result = "";
            if (filePath.Contains("FSTTest_")) result = "FST";
            else if (filePath.Contains("ZATest_")) result = "ZA";
            else if (filePath.Contains("PSVTest_")) result = "PSV";
            else if (filePath.Contains("BFCTest_")) result = "BFC";
            else if (filePath.Contains("Bias")) result = "Bias";
            else if (filePath.Contains("Dark")) result = "Dark";
            return result;
        }

        /*
        * Returns true if the element passed to it is valid. This method is called to remove unwanted elements
        * from appearing in the combobox.
        */
        private bool validElementString(string candidateString)
        {
            candidateString = candidateString.Trim();
            if (candidateString.StartsWith("<!") || candidateString.StartsWith("--") ||
                candidateString.StartsWith("<?") || candidateString.StartsWith("</"))
            {
                return false;
            }
            return true;
        }

        /*
         * Updates combo boxes in U.I.
         */
        private void updateXMLComboBoxes(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            List<string> passFailElements = getPassFailVerificationElementString(filePath);
            populatePassFailElementComboBox(passFailElements);
            List<string> fileElements = getXMLElementStrings(filePath);
            populateXMLElementsComboBox(fileElements);
        }

        /*
         * Takes a file passed from btnGetXmlData_Click. It then formats the elements of the XML file and
         * puts them into the combobox for the user to select.
         */
        private List<string> getXMLElementStrings(string filePath)
        {
            string[] elements = System.IO.File.ReadAllLines(filePath); // take the file, and put each line into an array
            List<string> fileElements = new List<string>(); // this holds one instance of each element that occurs
            foreach (string elem in elements)
            {
                if (validElementString(elem))
                {
                    string elementString = elem.TrimStart();
                    int lastInd = elementString.IndexOf('>');
                    int startInd = elementString.IndexOf('<');
                    if (startInd >= 0)
                    {
                        string formattedElem = elementString.Substring(startInd, lastInd + 1); // remove </> tags from the elements, makes it cleaner
                        if (!fileElements.Contains(formattedElem)) // makes sure there are no repeated elements
                        {
                            fileElements.Add(formattedElem);
                        }
                    }
                }
            }
            return fileElements;
        }

        private void populateXMLElementsComboBox(List<string> fileElements)
        {
            foreach (string elem in fileElements)
            {
                cbXmlElementName.Items.Add(elem); // finally add elements to combobox
            }
        }
        /*
         * This method takes the filepath of an XML file and then filters out all the elements that have
         * the substring _PassFail, which signifies that the data tied to the element is either "Pass" or
         * "Fail". Additionally the strings are formatted before they are put into cbVerificationField.
         */
        private List<string> getPassFailVerificationElementString(string filepath)
        {
            string[] elements = System.IO.File.ReadAllLines(filepath); // take the file, and put each line into an array
            List<string> passFailElements = new List<string>(); // this holds all the elements that represent Pass/Fail
            foreach (string elem in elements)
            {
                if (elem.Contains("_PassFail")) // add elements that have _PassFail to fileElements
                {
                    passFailElements.Add(elem);
                }
            }
            return passFailElements;
        }

        /*
         * Sets the graphical name of the groupbox that represents the column property in the UI
         */
        private void setDisplayName()
        {
            if (String.IsNullOrEmpty(tbDisplayName.Text))
            { // if the user has not designated a name use a default one
                if (m_activeColumnProperty.UseCamSN) m_activeColumnProperty.DisplayName = "Camera Serial Nbr.";
                else if (m_activeColumnProperty.UseInstSN) m_activeColumnProperty.DisplayName = "Inst. Serial Nbr.";
                else m_activeColumnProperty.DisplayName = m_activeColumnProperty.XMLElemNameProp;
            }
            else
            {
                m_activeColumnProperty.DisplayName = tbDisplayName.Text;
            }
        }

        private void populatePassFailElementComboBox(List<string> passFailElements)
        { 
            foreach (string elem in passFailElements) // format the contents of fileElements before putting them into the text box
            {
                int startInd = elem.IndexOf('<');
                int lastInd = elem.IndexOf('>');
                string formatedString = elem.Substring(startInd + 1, lastInd - 2);
                cbVerificationField.Items.Add(formatedString);
            }
        }

        /*
         * When combobox element is selected, put it into elemName textbox.
         */
        private void fileContents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDisplayName.Text))
            {
                tbDisplayName.Text = cbXmlElementName.Text;
            }
        }

        public void OnNewColProp(object source, ColumnProperties cp)
        {
            // PUT IN XML ELEMENT NAME, HAS NOT BEEN IMPLIMENTED YET
        }

        private void rbPass_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_formInitComplete)
                return;
            if (!rbXMLData.Checked)
            {
                MessageBox.Show("Pass/Fail/Always collection only works when XML element is selected.");
                return;
            }

            if (!string.IsNullOrEmpty(m_filepath))
            {
                getPassFailVerificationElementString(m_filepath);
            }
            else if (rbPass.Checked && string.IsNullOrEmpty(m_activeColumnProperty.XMLElemNameProp))
            {
                MessageBox.Show("You must select an XML element to be collected.");
            }
        }

        private void rbFail_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_formInitComplete)
                return;
            if (!rbXMLData.Checked)
            {
                MessageBox.Show("Pass/Fail/Always collection only works when XML element is selected.");
                return;
            }
            if (!string.IsNullOrEmpty(m_filepath))
            {
                getPassFailVerificationElementString(m_filepath);
            }
            else if (rbFail.Checked && string.IsNullOrEmpty(m_activeColumnProperty.XMLElemNameProp))
            {
                MessageBox.Show("You must select an XML element to be collected.");
            }
        }

        private void rbAlways_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_formInitComplete)
                return;
            if (!rbXMLData.Checked)
            {
                MessageBox.Show("Pass/Fail/Always collection only works when XML element is selected.");
                return;
            }
            if (rbAlways.Checked)
            {
                cbVerificationField.Enabled = false;
                lbPassFailVerification.Enabled = false;
            }
            else
            {
                cbVerificationField.Enabled = true;
                lbPassFailVerification.Enabled = true;
            }
            if (!string.IsNullOrEmpty(m_filepath))
                getPassFailVerificationElementString(m_filepath);
            else if (rbAlways.Checked && string.IsNullOrEmpty(m_activeColumnProperty.XMLElemNameProp))
                MessageBox.Show("You must select an XML element to be collected.");
        }

        private void btnMakeColumn_Click(object sender, EventArgs e)
        {
            setDisplayName();
            OnNewColumnPropertiesAvailable();
            Close();
        }

        private void XMLExt_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public string BaseCamFolderPath { get => baseCamFolderPath; set => baseCamFolderPath = value; }
        public string BaseInstFolderPath { get => baseInstFolderPath; set => baseInstFolderPath = value; }
        public bool IsCameraTest { get => m_isCameraTest; set => m_isCameraTest = value; }

        private void rbCamSN_CheckedChanged(object sender, EventArgs e) // disable XML stuff if we are using camera data
        {
            if (!m_formInitComplete)
                return;
            gbFileElemInfo.Enabled = false;
            collectionParameters.Enabled = false;
        }

        private void rbInstNum_CheckedChanged(object sender, EventArgs e) // disable XML stuff if we are using inst. data
        {
            if (!m_formInitComplete)
                return;
            gbFileElemInfo.Enabled = false;
            collectionParameters.Enabled = false;
        }

        private void rbXMLData_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_formInitComplete)
                return;
            gbFileElemInfo.Enabled = true;
            collectionParameters.Enabled = true;
        }

        private void ColPropertiesDialog_Load(object sender, EventArgs e)
        {

        }
    }

    /////////////////////////////////////////

    public class NewColumnPropertiesEventArgs : EventArgs
    {
        public ColumnProperties colProps { get; set; }
    }
}