using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraDataDive
{
    [Serializable()]
    public class ColumnProperties
    {
        private bool useXMLData; // use XML data for column header
        private bool useInstSN; // use instrument serial number for column header
        private bool useCamSN; // use camera serial number for column header
        private bool collectOnPass; // collect data on pass
        private bool collectOnFail; // collect data on fail
        private bool collectAlways; // collect all data
        private string XMLElemName; // this is the data element name we are getting from file
        private string passFailElemName; // the XML element that determines whether the data element will be used
        private string fileNameTemplate; // the template for the file we are looking for (finalTestReport etc.)
        private string folderNameTemplate; // the template for the folder we are looking for (PSV, ZA, BST etc.)
        private string filePath; // the file we are getting the data from
        private string displayName; // the serial number for the camera or the instrument

        public ColumnProperties()
        {
            useXMLData = true;
            useInstSN = false;
            useCamSN = false;
            collectOnPass = false;
            collectOnFail = false;
            collectAlways = true;
            fileNameTemplate = "";
            folderNameTemplate = "";
            XMLElemNameProp = "";
            PassFailElemName = "";
            filePath = "";
            displayName = "";
        }

        public ColumnProperties (bool _useXMLData, bool _useInstSN, bool _useCamSN, bool _collectOnPass, bool _collectOnFail, bool _collectAlways, string _XMLElemName, string _passFailElemName, string _fileNameTemplate, string _folderNameTemplate, string _filePath, string _serialNum)
        {
            useXMLData = _useXMLData;
            useInstSN = _useInstSN;
            useCamSN = _useCamSN;
            collectOnPass = _collectOnPass;
            collectOnFail = _collectOnFail;
            collectAlways = _collectAlways;
            fileNameTemplate = _fileNameTemplate;
            folderNameTemplate = _folderNameTemplate;
            XMLElemNameProp = _XMLElemName;
            PassFailElemName = _passFailElemName;
            filePath = _filePath;
            displayName = _serialNum;
        }

        public static string getFileNameTemplate(string path)
        {
            string result = "";
            DirectoryInfo tdi = new DirectoryInfo(path);
            string dirName = tdi.Name;
            char[] separators = new char[] { '-', '_', '.' };
            string[] splitString = dirName.Split(separators);
            result = splitString[0];
            return result;
        }
        
        public static string getFolderNameTemplate(bool isCamTest, string filePath)
        {
            if (isCamTest)
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
            else
            {
                string result = "";
                if (filePath.Contains("Bias")) result = "Bias";
                else if (filePath.Contains("Dark")) result = "Dark";
                else if (filePath.Contains("Flat")) result = "Flat";
                else if (filePath.Contains("Focus")) result = "Focus";
                return result;
            } 
        }

        /////////////////////////
        ///////PROPERTIES////////
        /////////////////////////
       
        public string FileNameTemplate { get => fileNameTemplate; set => fileNameTemplate = value; }
        public bool UseXMLData { get => useXMLData; set => useXMLData = value; }
        public bool UseInstSN { get => useInstSN; set => useInstSN = value; }
        public bool UseCamSN { get => useCamSN; set => useCamSN = value; }
        public bool CollectOnPass { get => collectOnPass; set => collectOnPass = value; }
        public bool CollectOnFail { get => collectOnFail; set => collectOnFail = value; }
        public bool CollectAlways { get => collectAlways; set => collectAlways = value; }
        public string PassFailElemName { get => passFailElemName; set => passFailElemName = value; }
        public string XMLElemNameProp { get => XMLElemName; set => XMLElemName = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string FolderNameTemplate { get => folderNameTemplate; set => folderNameTemplate = value; }
    }

}
