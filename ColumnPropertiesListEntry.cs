using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CameraDataDive
{
    public class ColumnPropertiesListEntry
    {
        private GroupBox m_gBox; // groupbox that contains flow layout panel for column properties display
        private FlowLayoutPanel m_panel; // holds and organizes all the content;
        private Label m_dataSelectionCriteria; // the type of data being used (xml file camera serial num etc)
        private Label m_collectionParameters; // collect on pass, collect on fail, etc
        private Label m_passFailElemName; // the pass/fail element we are collecting
        
        public ColumnPropertiesListEntry(ColumnProperties cp)
        {
            GBox = new GroupBox(); // initializing fields
            configureGroupBox(); // configure groupbox
            Label dataSelectionCriteria = getDataSelectionCriteria(cp); // call method to populate method with correct data
            Label xmlData = getXMLDataLabel(cp);
            Label cpName = getColPropName(cp);
            m_panel = new FlowLayoutPanel();
            m_panel.Controls.Add(cpName);
            m_panel.Controls.Add(dataSelectionCriteria); // add labels to flow layout panel
            m_panel.Controls.Add(xmlData);
            if (cp.UseXMLData) // if we are using xml data include the pass fail criteria in a label
            {
                Label collectionParameters = getCollectionParameters(cp);
                m_panel.Controls.Add(collectionParameters);
                Label passFailElemName = getPassFailElemName(cp);
                passFailElemName.AutoSize = true;
                m_panel.Controls.Add(passFailElemName);
                passFailElemName.Click += PassFailElemName_Click; // subscribe
                collectionParameters.Click += CollectionParameters_Click; // subscribe
            }
            configureFlowLayoutPanel();
            GBox.Controls.Add(m_panel);
            m_panel.Click += M_panel_Click; // subscribe
            GBox.Click += GBox_Click; // subscribe
            dataSelectionCriteria.Click += DataSelectionCriteria_Click; // subscribe
            xmlData.Click += XmlData_Click; // subscribe
            cpName.Click += CpName_Click; // sub
        }

        public delegate void NewColPropSelectedEventHandler(object source, EventArgs e);
        public event EventHandler<PropertyListEntrySelectedArgs> NewColPropGroupBoxCreated;

        protected virtual void OnNewColPropGroupBoxEntered()
        {
            PropertyListEntrySelectedArgs args = new PropertyListEntrySelectedArgs(m_gBox);
            EventHandler<PropertyListEntrySelectedArgs> handler = NewColPropGroupBoxCreated; // publish new data
            if (handler != null) handler(this, args);
            else throw new ArgumentNullException("Unable to signal new column property group box entered. NewColPropGroupBoxCreated is null.");
        }

        /*
         * Configures the group box to be the proper height and width, as well as 
         * forcing it to dock in the correct place
         */
        private void configureGroupBox()
        {
            GBox.Width = 675;
            GBox.Height = 75;
            GBox.Dock = DockStyle.Top;
            //GBox.BringToFront(); 
        }

        private void configureFlowLayoutPanel()
        {
            m_panel.FlowDirection = FlowDirection.LeftToRight;
            m_panel.BackColor = Color.White;
            m_panel.Dock = DockStyle.Fill;
            m_panel.BorderStyle = BorderStyle.Fixed3D;
        } 

        private Label getDataSelectionCriteria(ColumnProperties cp)
        {
            Label dataSelectionCriteria = new Label();
            dataSelectionCriteria.AutoSize = true;
            dataSelectionCriteria.Font = new Font("Arial", 9, FontStyle.Bold);
            if (cp.UseXMLData)
            {
                dataSelectionCriteria.Text = "Using XML Data:";
            }
            else if (cp.UseCamSN) { dataSelectionCriteria.Text = "Using Camera Serial Number"; }
            else if (cp.UseInstSN) { dataSelectionCriteria.Text = "Using Instrument Serial Number"; }
            return dataSelectionCriteria;
        }
   
        private Label getXMLDataLabel(ColumnProperties cp)
        {
            Label xmlDataLabel = new Label();
            xmlDataLabel.AutoSize = true;
            xmlDataLabel.Font = new Font("Arial", 9);
            xmlDataLabel.Text = cp.XMLElemNameProp;
            return xmlDataLabel;
        }

        private Label getColPropName(ColumnProperties cp)
        {
            Label cpName = new Label();
            cpName.AutoSize = true;
            cpName.Font = new Font("Arial", 9, FontStyle.Bold);
            if (string.IsNullOrEmpty(cp.DisplayName)) cpName.Text = "Name: " + cp.XMLElemNameProp;
            else cpName.Text = "Name: " + cp.DisplayName;
            return cpName;
        }

        private Label getCollectionParameters(ColumnProperties cp)
        {
            Label collectionParameters = new Label();
            collectionParameters.AutoSize = true;
            collectionParameters.Font = new Font("Arial", 9, FontStyle.Bold);
            if (cp.CollectAlways) { collectionParameters.Text = "Collecting data always"; }
            else if (cp.CollectOnPass) { collectionParameters.Text = "Collecting data on pass"; }
            else if (cp.CollectOnFail) { collectionParameters.Text = "Collecting data on fail"; }
            return collectionParameters;
        }

        private Label getPassFailElemName(ColumnProperties cp)
        {
            Label passFailElement = new Label();
            passFailElement.AutoSize = true;
            passFailElement.Font = new Font("Arial", 9, FontStyle.Bold);
            passFailElement.Text = "Pass/Fail Element Name: " + cp.PassFailElemName;
            return passFailElement;
        }

        /////////////////////////////////////////////
        /////EVENT HANDLERS FOR ENTERING GROUPBOX////
        /////////////////////////////////////////////
        private void PassFailElemName_Click(object sender, EventArgs e)
        {
            OnNewColPropGroupBoxEntered();
        }

        private void CollectionParameters_Click(object sender, EventArgs e)
        {
            OnNewColPropGroupBoxEntered();
        }

        private void XmlData_Click(object sender, EventArgs e)
        {
            OnNewColPropGroupBoxEntered();
        }

        private void DataSelectionCriteria_Click(object sender, EventArgs e)
        {
            OnNewColPropGroupBoxEntered();
        }

        private void M_panel_Click(object sender, EventArgs e)
        {
            OnNewColPropGroupBoxEntered();
        }

        private void CpName_Click(object sender, EventArgs e)
        {
            OnNewColPropGroupBoxEntered();
        }

        private void GBox_Click(object sender, EventArgs e)
        {
            OnNewColPropGroupBoxEntered();
        }

        public Label DataSelectionCriteria { get => m_dataSelectionCriteria; set => m_dataSelectionCriteria = value; }
        public Label CollectionParameters { get => m_collectionParameters; set => m_collectionParameters = value; }
        public Label PassFailElemName { get => m_passFailElemName; set => m_passFailElemName = value; }
        public GroupBox GBox { get => m_gBox; set => m_gBox = value; }

    }

    /////////////////////////////////////////

    public class PropertyListEntrySelectedArgs : EventArgs
    {
        public PropertyListEntrySelectedArgs(GroupBox cpGroupBox)
        {
            ColPropGroupBox = cpGroupBox;
        }
        public GroupBox ColPropGroupBox { get; set; }
    }
}
