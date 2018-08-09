using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace eCTD_indexer.UserDialog
{
    public partial class AdoptInformation : Form
    {
        public AdoptInformation(List<String> Sequences, int openedSeq, String sequencepath)
        {
            InitializeComponent();

            for(int i=0;i<Sequences.Count;i++)
            {
                if (Convert.ToInt64(Sequences[i]) < openedSeq)
                {
                    this.cbSequence.Items.Add(Sequences[i]);
                }
            }

            this.Path2Sequences = sequencepath.Substring(0, sequencepath.Length - 4);
        }

        // Local variable
        private String Path2Sequences;

        // Get-Methods
        public String Number { get { return this.textBoxNumberCheck.Text; } }
        public String TrackNo { get { return this.textBoxTrackNoCheck.Text; } }
        public String ProcedureType { get { return this.textBoxProcedureTypeCheck.Text; } }
        public String SubmissionType { get { return this.textBoxSubmissiontypeCheck.Text; } }
        public String Mode { get { return this.textBoxModeCheck.Text; } }
        public String INN { get { return this.textBoxINNCheck.Text; } }
        public String Identifier { get { return this.tbIdentifierCheck.Text; } }
        public String RelSeq { get { return this.textBoxRelSeqCheck.Text; } }
        public String SubmissionDescription { get { return this.textBoxSubmDescrCheck.Text; } }
        public String SubmissionUnit { get { return this.textBoxSubmissionUnitCheck.Text; } }

        private void LoadData()
        {
            // Load the xml file / xml data
            String EURegionalXML = this.Path2Sequences + @"\" + this.cbSequence.Text + @"\m1\eu\eu-regional.xml";
            if (File.Exists(EURegionalXML))
            {
                XmlTextReader myReader = new XmlTextReader(EURegionalXML);
                XmlDocument mySourceDoc = new XmlDocument();
                mySourceDoc.Load(myReader);
                myReader.Close();

                XmlNode uuidNode;
                uuidNode = mySourceDoc.SelectSingleNode("//identifier");
                if (uuidNode != null)
                {
                    this.tbIdentifier.Text = uuidNode.InnerText;
                }

                XmlNodeList envelope;
                envelope = mySourceDoc.SelectNodes("//envelope");
                if (envelope.Count > 0)
                {
                    foreach (XmlNode countryEnvelope in envelope)
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control is TextBox)
                            {
                                if (((TextBox)control).Name.ToString() == ("textBoxTrackNo") && (countryEnvelope.SelectSingleNode("descendant::tracking") != null))
                                {
                                    if (countryEnvelope.SelectSingleNode("descendant::tracking").SelectSingleNode("descendant::number").InnerText.ToString() != null)
                                    {
                                        ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::tracking").SelectSingleNode("descendant::number").InnerText.ToString();
                                    }
                                }
                                if (((TextBox)control).Name.ToString() == ("textBoxTrackNo") && (countryEnvelope.SelectSingleNode("descendant::procedure-tracking") != null))
                                {
                                    if (countryEnvelope.SelectSingleNode("descendant::procedure-tracking").SelectSingleNode("descendant::number").InnerText.ToString() != null)
                                    {
                                        ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::procedure-tracking").SelectSingleNode("descendant::number").InnerText.ToString();
                                    }
                                }

                                if (((TextBox)control).Name.ToString() == ("textBoxNumber"))
                                {
                                    ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::number").InnerText.ToString();
                                }

                                if (((TextBox)control).Name.ToString() == ("textBoxINN"))
                                {
                                    ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::inn").InnerText.ToString();
                                }

                                if (((TextBox)control).Name.ToString() == ("textBoxSubmDescr"))
                                {
                                    ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::submission-description").InnerText.ToString();
                                }

                                if (((TextBox)control).Name.ToString() == ("textBoxRelSeq"))
                                {
                                    ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::related-sequence").InnerText.ToString();
                                }

                                if (((TextBox)control).Name.ToString() == ("textBoxProcedureType"))
                                {
                                    ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::procedure").Attributes["type"].InnerText.ToString();
                                }

                                if (((TextBox)control).Name.ToString() == ("textBoxSubmissiontype"))
                                {
                                    ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::submission").Attributes["type"].InnerText.ToString();
                                }

                                if ((countryEnvelope.ParentNode.ParentNode.Attributes["dtd-version"].InnerText.ToString()) != "1.3")
                                {
                                    if (((TextBox)control).Name.ToString() == ("textBoxMode") && countryEnvelope.SelectSingleNode("descendant::submission").Attributes["mode"] != null)
                                    {
                                        ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::submission").Attributes["mode"].InnerText.ToString();
                                    }
                                }

                                // Load the submission unit data.
                                if (((TextBox)control).Name.ToString() == ("textBoxSubmissionUnit"))
                                {
                                    ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::submission-unit").Attributes["type"].InnerText.ToString();
                                }
                            }
                        }
                    }
                }

                this.btConfirm.Enabled = true;
            }
            else
            {
                this.btConfirm.Enabled = false;
            }
        }

        #region Button Click events
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btAdoptAll_Click(object sender, EventArgs e)
        {
            textBoxTrackNoAdopt_Click(sender, e);
            textBoxProcedureTypeAdopt_Click(sender, e);
            textBoxSubmissiontypeAdopt_Click(sender, e);
            textBoxModeAdopt_Click(sender, e);
            textBoxNumberAdopt_Click(sender, e);
            textBoxINNAdopt_Click(sender, e);
            tbIdentifierAdopt_Click(sender, e);
            textBoxRelSeqAdopt_Click(sender, e);
            textBoxSubmDescrAdopt_Click(sender, e);
            textBoxSubmissionUnitAdopt_Click(sender, e);
            AgencyAdopt_Click(sender, e);
        }

        private void textBoxTrackNoAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxTrackNoCheck.Text = textBoxTrackNo.Text;
        }

        private void textBoxProcedureTypeAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxProcedureTypeCheck.Text = textBoxProcedureType.Text;
        }

        private void textBoxSubmissiontypeAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxSubmissiontypeCheck.Text = textBoxSubmissiontype.Text;
        }

        private void textBoxModeAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxModeCheck.Text = textBoxMode.Text;
        }

        private void textBoxNumberAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxNumberCheck.Text = textBoxNumber.Text;
        }

        private void textBoxINNAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxINNCheck.Text = textBoxINN.Text;
        }

        private void tbIdentifierAdopt_Click(object sender, EventArgs e)
        {
            this.tbIdentifierCheck.Text = tbIdentifier.Text;
        }

        private void textBoxRelSeqAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxRelSeqCheck.Text = textBoxRelSeq.Text;
        }

        private void textBoxSubmDescrAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxSubmDescrCheck.Text = textBoxSubmDescr.Text;
        }

        private void textBoxSubmissionUnitAdopt_Click(object sender, EventArgs e)
        {
            this.textBoxSubmissionUnitCheck.Text = textBoxSubmissionUnit.Text;
        }

        private void AgencyAdopt_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void cbSequence_SelectedValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        
    }
}
