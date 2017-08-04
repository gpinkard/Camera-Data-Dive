using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraDataDive
{
    class SerialNbrInfo
    {
        private DateTime m_creationDate; // creation date, saving as a string for now because of custom format we are using
        private string m_folderNameTemplate; // the folder name template (PSV, ZA, etc.)
        private string m_fileNameTemplate; // the file name template (finaltestreport.xml etc.)

        public SerialNbrInfo(DateTime creationDate, string folderNameTemplate, string fileNameTemplate)
        {
            m_creationDate = creationDate;
            m_folderNameTemplate = folderNameTemplate;
            m_fileNameTemplate = fileNameTemplate;
        }

        public DateTime CreationDate { get => m_creationDate; set => m_creationDate = value; }
        public string FolderNameTemplate { get => m_folderNameTemplate; set => m_folderNameTemplate = value; }
        public string FileNameTemplate { get => m_fileNameTemplate; set => m_fileNameTemplate = value; }
    }
}
