using System;
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
    public partial class GenerateFolderListDialog : Form
    {
        private bool usingCameraData; // true if we are using camera data
        private bool usingInstrumentData; // true if we are using instrument data
        public GenerateFolderListDialog()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            usingCameraData = false;
            usingInstrumentData = false;
            this.CenterToParent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!rbCamData.Checked && !rbInstTest.Checked)
            {
                MessageBox.Show("You must select if you are doing a camera or instrument test!");
            }
            else this.Close(); // close the form
        }

        private void rbCamData_CheckedChanged(object sender, EventArgs e)
        {
            usingCameraData = true;
            usingInstrumentData = false;
        }

        private void rbInstTest_CheckedChanged(object sender, EventArgs e)
        {
            usingCameraData = false;
            usingInstrumentData = true;
        }

        public bool UsingCameraData { get => usingCameraData; set => usingCameraData = value; }
        public bool UsingInstrumentData { get => usingInstrumentData; set => usingInstrumentData = value; }

    }
}
