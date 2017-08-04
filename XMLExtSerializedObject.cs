using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraDataDive
{
    [Serializable()]
    class CDTXMLSession : ISerializable
    {
        private List<ColumnProperties> colPropList; // list of column property obj
        private string m_camBaseFolderPath; // base folder for camera serial number
        private string m_instBaseFolderPath; // base folder for instrument serial number
        private string m_outPutCSVFilePath; // file where the results should be saved
        private string m_camSerialNumLow; // low end of cam serial number spectrum
        private string m_camSerialNumHigh; // high end of cam serial number spectrum
        private string m_instSerialNumLow; // low end of instrument serial number spectrum
        private string m_instSerialNumHigh; // high end of instrument serial number spectrum
        private string m_dateTimeStart; // saves the start date in DateTime form
        private string m_dateTimeEnd; // saves the end date in DateTime form
        private bool m_isCameraTest; // saves if instrument test or camera test, true if camera test

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("colPropList", colPropList);
            info.AddValue("m_camBaseFolderPath", m_camBaseFolderPath);
            info.AddValue("m_instBaseFolderPath", m_instBaseFolderPath);
            info.AddValue("m_outPutCSVFilePath", m_outPutCSVFilePath);
            info.AddValue("m_camSerialNumLow", m_camSerialNumLow);
            info.AddValue("m_camSerialNumHigh", m_camSerialNumHigh);
            info.AddValue("m_instSerialNumLow", m_instSerialNumLow);
            info.AddValue("m_instSerialNumHigh", m_instSerialNumHigh);
            info.AddValue("m_dateTimeStart", m_dateTimeStart);
            info.AddValue("m_dateTimeEnd", m_dateTimeEnd);
            info.AddValue("m_isCameraTest", m_isCameraTest);
        }

        public CDTXMLSession() { }

        protected CDTXMLSession(SerializationInfo info, StreamingContext context)
        {
            colPropList = (List<ColumnProperties>)info.GetValue("colPropList", typeof(List<ColumnProperties>));
            m_camBaseFolderPath = (string)info.GetValue("m_camBaseFolderPath", typeof(string));
            m_instBaseFolderPath = (string)info.GetValue("m_instBaseFolderPath", typeof(string));
            m_outPutCSVFilePath = (string)info.GetValue("m_outPutCSVFilePath", typeof(string));
            m_camSerialNumLow = (string)info.GetValue("m_camSerialNumLow", typeof(string));
            m_camSerialNumHigh = (string)info.GetValue("m_camSerialNumHigh", typeof(string));
            m_instSerialNumHigh = (string)info.GetValue("m_instSerialNumHigh", typeof(string));
            m_instSerialNumLow = (string)info.GetValue("m_instSerialNumLow", typeof(string));
            m_dateTimeStart = (string)info.GetValue("m_dateTimeStart", typeof(string)); // I don't think I am grabbing this value correctly
            m_dateTimeEnd = (string)info.GetValue("m_dateTimeEnd", typeof(string));
            m_isCameraTest = (bool)info.GetValue("m_isCameraTest", typeof(bool));
        }

        public List<ColumnProperties> ColPropList { get => colPropList; set => colPropList = value; }
        public string CamBaseFolderPath { get => m_camBaseFolderPath; set => m_camBaseFolderPath = value; }
        public string InstBaseFolderPath { get => m_instBaseFolderPath; set => m_instBaseFolderPath = value; }
        public string OutPutCSVFilePath { get => m_outPutCSVFilePath; set => m_outPutCSVFilePath = value; }
        public string CamSerialNumLow { get => m_camSerialNumLow; set => m_camSerialNumLow = value; }
        public string CamSerialNumHigh { get => m_camSerialNumHigh; set => m_camSerialNumHigh = value; }
        public string InstSerialNumLow { get => m_instSerialNumLow; set => m_instSerialNumLow = value; }
        public string InstSerialNumHigh { get => m_instSerialNumHigh; set => m_instSerialNumHigh = value; }
        public string DateTimeStart { get => m_dateTimeStart; set => m_dateTimeStart = value; }
        public string DateTimeEnd { get => m_dateTimeEnd; set => m_dateTimeEnd = value; }
        public bool IsCameraTest { get => m_isCameraTest; set => m_isCameraTest = value; }
    }
}
