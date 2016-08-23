// eCTD indexer (EU Module 1)
// Copyright 2007-2016 Ymir Vesteinsson, ymir@ectd.is and Copyright 2016 Quantentunnel (https://github.com/Quantentunnel)

// This file is part of eCTD-indexer.

// eCTD-indexer is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// eCTD-indexer is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// For more information about the EU Module 1 please have a
// look at http://esubmission.ema.europa.eu/eumodule1/
// Links to relevant guidelines:
// eCTD Specification and Related Files: http://estri.ich.org/eCTD/index.htm/
// Notice to applicants - current EU Module 1, electronic application form: http://ec.europa.eu/health/documents/eudralex/vol-2/index_en.htm
// EU eSubmission guidelines: http://esubmission.ema.europa.eu/
// Heads of Medicines Agencies - Procedural Guidance for eSubmissions: http://www.hma.eu/277.html

// You should have received a copy of the GNU General Public License
// along with eCTD-indexer.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; 
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml;


namespace eCTD_indexer
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Initialize global variables
            this.dirs = new eCTD_Directories();
            this.files = new eCTD_Files();
            this.XMLCreate = new XML.Create(this.dirs);
            this.DossierOpened = false;
        }

        // Global variables
        private eCTD_Directories dirs;
        private eCTD_Files files;
        private XML.Create XMLCreate;
        private bool DossierOpened;
        private String SeqDir;


        #region Event methods to enables/disables applicant and product name text boxes in line with country checkboxes
        private void checkBoxAT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAT.Checked == true)
            {
                textBoxAT.Enabled = true;
                textBoxATApp.Enabled = true;                
            }
            else
            {
                textBoxAT.Enabled = false;
                textBoxATApp.Enabled = false;
            }
        }

        private void checkBoxBE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBE.Checked == true)
            {
                textBoxBE.Enabled = true;
                textBoxBEApp.Enabled = true;                
            }
            else
            {
                textBoxBE.Enabled = false;
                textBoxBEApp.Enabled = false;
            }
        }

        private void checkBoxBG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBG.Checked == true)
            {
                textBoxBG.Enabled = true;
                textBoxBGApp.Enabled = true;
            }
            else
            {
                textBoxBG.Enabled = false;
                textBoxBGApp.Enabled = false;
            }
        }

        private void checkBoxCY_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCY.Checked == true)
            {
                textBoxCY.Enabled = true;
                textBoxCYApp.Enabled = true;
            }
            else
            {
                textBoxCY.Enabled = false;
                textBoxCYApp.Enabled = false;
            }
        }

        private void checkBoxCZ_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCZ.Checked == true)
            {
                textBoxCZ.Enabled = true;
                textBoxCZApp.Enabled = true;
            }
            else
            {
                textBoxCZ.Enabled = false;
                textBoxCZApp.Enabled = false;
            }
        }

        private void checkBoxDE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDE.Checked == true)
            {                
                textBoxDE.Enabled = true;
                textBoxDEApp.Enabled = true;                
            }
            else
            {
                textBoxDE.Enabled = false;
                textBoxDEApp.Enabled = false;                
            }
        }

        private void checkBoxDE2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDE2.Checked == true)
            {
                textBoxDE2.Enabled = true;
                textBoxDE2App.Enabled = true;
            }
            else
            {
                textBoxDE2.Enabled = false;
                textBoxDE2App.Enabled = false;
            }
        }
                
        private void checkBoxDK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDK.Checked == true)
            {
                textBoxDK.Enabled = true;
                textBoxDKApp.Enabled = true;
            }
            else
            {
                textBoxDK.Enabled = false;
                textBoxDKApp.Enabled = false;
            }
        }

        private void checkBoxEE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEE.Checked == true)
            {
                textBoxEE.Enabled = true;
                textBoxEEApp.Enabled = true;
            }
            else
            {
                textBoxEE.Enabled = false;
                textBoxEEApp.Enabled = false;
            }
        }

        private void checkBoxEL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEL.Checked == true)
            {
                textBoxEL.Enabled = true;
                textBoxELApp.Enabled = true;
            }
            else
            {
                textBoxEL.Enabled = false;
                textBoxELApp.Enabled = false;
            }
        }

        private void checkBoxES_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxES.Checked == true)
            {
                textBoxES.Enabled = true;
                textBoxESApp.Enabled = true;
            }
            else
            {
                textBoxES.Enabled = false;
                textBoxESApp.Enabled = false;
            }
        }

        private void checkBoxFI_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFI.Checked == true)
            {
                textBoxFI.Enabled = true;
                textBoxFIApp.Enabled = true;
            }
            else
            {
                textBoxFI.Enabled = false;
                textBoxFIApp.Enabled = false;
            }
        }

        private void checkBoxFR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFR.Checked == true)
            {
                textBoxFR.Enabled = true;
                textBoxFRApp.Enabled = true;
            }
            else
            {
                textBoxFR.Enabled = false;
                textBoxFRApp.Enabled = false;
            }
        }

        private void checkBoxHR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHR.Checked == true)
            {
                textBoxHR.Enabled = true;
                textBoxHRApp.Enabled = true;
            }
            else
            {
                textBoxHR.Enabled = false;
                textBoxHRApp.Enabled = false;
            }
        }

        private void checkBoxHU_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHU.Checked == true)
            {
                textBoxHU.Enabled = true;
                textBoxHUApp.Enabled = true;
            }
            else
            {
                textBoxHU.Enabled = false;
                textBoxHUApp.Enabled = false;
            }
        }

        private void checkBoxIE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIE.Checked == true)
            {
                textBoxIE.Enabled = true;
                textBoxIEApp.Enabled = true;
            }
            else
            {
                textBoxIE.Enabled = false;
                textBoxIEApp.Enabled = false;
            }
        }

        private void checkBoxIS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIS.Checked == true)
            {
                textBoxIS.Enabled = true;
                textBoxISApp.Enabled = true;
            }
            else
            {
                textBoxIS.Enabled = false;
                textBoxISApp.Enabled = false;
            }
        }

        private void checkBoxIT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIT.Checked == true)
            {
                textBoxIT.Enabled = true;
                textBoxITApp.Enabled = true;
            }
            else
            {
                textBoxIT.Enabled = false;
                textBoxITApp.Enabled = false;
            }
        }

        private void checkBoxLI_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLI.Checked == true)
            {
                textBoxLI.Enabled = true;
                textBoxLIApp.Enabled = true;
            }
            else
            {
                textBoxLI.Enabled = false;
                textBoxLIApp.Enabled = false;
            }
        }

        private void checkBoxLT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLT.Checked == true)
            {
                textBoxLT.Enabled = true;
                textBoxLTApp.Enabled = true;
            }
            else
            {
                textBoxLT.Enabled = false;
                textBoxLTApp.Enabled = false;
            }
        }

        private void checkBoxLU_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLU.Checked == true)
            {
                textBoxLU.Enabled = true;
                textBoxLUApp.Enabled = true;
            }
            else
            {
                textBoxLU.Enabled = false;
                textBoxLUApp.Enabled = false;
            }
        }

        private void checkBoxLV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLV.Checked == true)
            {
                textBoxLV.Enabled = true;
                textBoxLVApp.Enabled = true;
            }
            else
            {
                textBoxLV.Enabled = false;
                textBoxLVApp.Enabled = false;
            }
        }

        private void checkBoxMT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMT.Checked == true)
            {
                textBoxMT.Enabled = true;
                textBoxMTApp.Enabled = true;
            }
            else
            {
                textBoxMT.Enabled = false;
                textBoxMTApp.Enabled = false;
            }
        }

        private void checkBoxNL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNL.Checked == true)
            {
                textBoxNL.Enabled = true;
                textBoxNLApp.Enabled = true;
            }
            else
            {
                textBoxNL.Enabled = false;
                textBoxNLApp.Enabled = false;
            }
        }

        private void checkBoxNO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNO.Checked == true)
            {
                textBoxNO.Enabled = true;
                textBoxNOApp.Enabled = true;
            }
            else
            {
                textBoxNO.Enabled = false;
                textBoxNOApp.Enabled = false;
            }
        }

        private void checkBoxPL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPL.Checked == true)
            {
                textBoxPL.Enabled = true;
                textBoxPLApp.Enabled = true;
            }
            else
            {
                textBoxPL.Enabled = false;
                textBoxPLApp.Enabled = false;
            }
        }

        private void checkBoxPT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPT.Checked == true)
            {
                textBoxPT.Enabled = true;
                textBoxPTApp.Enabled = true;
            }
            else
            {
                textBoxPT.Enabled = false;
                textBoxPTApp.Enabled = false;
            }
        }

        private void checkBoxRO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRO.Checked == true)
            {
                textBoxRO.Enabled = true;
                textBoxROApp.Enabled = true;
            }
            else
            {
                textBoxRO.Enabled = false;
                textBoxROApp.Enabled = false;
            }
        }

        private void checkBoxSE_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSE.Checked == true)
            {
                textBoxSE.Enabled = true;
                textBoxSEApp.Enabled = true;
            }
            else
            {
                textBoxSE.Enabled = false;
                textBoxSEApp.Enabled = false;
            }
        }

        private void checkBoxSI_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSI.Checked == true)
            {
                textBoxSI.Enabled = true;
                textBoxSIApp.Enabled = true;
            }
            else
            {
                textBoxSI.Enabled = false;
                textBoxSIApp.Enabled = false;
            }
        }

        private void checkBoxSK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSK.Checked == true)
            {
                textBoxSK.Enabled = true;
                textBoxSKApp.Enabled = true;
            }
            else
            {
                textBoxSK.Enabled = false;
                textBoxSKApp.Enabled = false;
            }
        }

        private void checkBoxUK_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUK.Checked == true)
            {
                textBoxUK.Enabled = true;
                textBoxUKApp.Enabled = true;
            }
            else
            {
                textBoxUK.Enabled = false;
                textBoxUKApp.Enabled = false;
            }
        }
        
        private void checkBoxEU_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEU.Checked == true)
            {
                textBoxEU.Enabled = true;
                textBoxEUApp.Enabled = true;                
            }
            else
            {
                textBoxEU.Enabled = false;
                textBoxEUApp.Enabled = false;
            }
        }
		private void checkBoxED_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxED.Checked == true)
			{
				textBoxED.Enabled = true;
				textBoxEDApp.Enabled = true;                
			}
			else
			{
				textBoxED.Enabled = false;
				textBoxEDApp.Enabled = false;
			}
		}

        #endregion

        /// <summary>
        /// Enables the Mode and Number textboxes for variations and line extension type submissions
        /// also enables the related sequence textbox if relevant (only for supplemental-info and corrigendum submissions)  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSubmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBoxSubmType.Text == "var-type1a") || 
				(comboBoxSubmType.Text == "var-type1ain") ||
                (comboBoxSubmType.Text == "var-type1b") || 
                (comboBoxSubmType.Text == "var-type2") || 
                (comboBoxSubmType.Text == "var-nat") || 
                (comboBoxSubmType.Text == "extension"))
            {
                comboBoxMode.Enabled = true;
                textBoxNumber.Enabled = true;
            }
            else
            {
                comboBoxMode.Enabled = false;
                textBoxNumber.Enabled = false;
            }
            if ((comboBoxSubmType.Text == "supplemental-info") ||
                (comboBoxSubmType.Text == "corrigendum"))
            {
                textBoxRelSeq.Enabled = true;
            }
            else
            {
                textBoxRelSeq.Enabled = false;
            }
        }

        private void currentDossierButton_Click(object sender, EventArgs e)
        {
            string topSequenceFolder = SeqDir.Substring(0, SeqDir.Length - 5);
            CurrentDossier current = new CurrentDossier();
            current.AssembleCurrentDossier(topSequenceFolder);            
        }

        /// <summary>
        /// Open a dossier by selecting the sequence folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbOpenDossier_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = Properties.Settings.Default.LastDossierLocation;
            fb.Description = "Please select the sequence directory of your dossier.\nFor instance 0000.";
            if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Remember the location of this folder for next time
                Properties.Settings.Default.LastDossierLocation = fb.SelectedPath;
                Properties.Settings.Default.Save();

                // Pattern
                String pat = @"(?<=[0-9]{4})";

                // Instantiate the regular expression object.
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);

                // Match the regular expression pattern against a text string.
                Match m = r.Match(fb.SelectedPath);

                if (m.Success)
                {
                    this.fileExplorerUserControl.PopulateTreeView(fb.SelectedPath);
                    SeqDir = fb.SelectedPath;
                    this.DossierOpened = true;
                    this.loadXMLData();
                } else
                {
                    MessageBox.Show("You selected an incorrect sequence directory.\nA correct sequence folder consists of four digits (e.g. 0001).", "Incorrect sequence directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Load the EU-Regional-xml file and enter the data into the GUI.
        /// </summary>
        private void loadXMLData()
        {
            String file = SeqDir + @"\m1\eu\eu-regional.xml";

            XmlTextReader myReader = new XmlTextReader(file);
            XmlDocument mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            XmlNode uuidNode;
            uuidNode = mySourceDoc.SelectSingleNode("//identifier");
            if (uuidNode != null)
            {
                this.lSubmissionIdentifier.Text = uuidNode.InnerText;
            }

            XmlNodeList envelope;
            envelope = mySourceDoc.SelectNodes("//envelope");
            if (envelope.Count > 0)
            {
                foreach (Control control in this.splitContainer1.Panel2.Controls)
                {
                    if (control is CheckBox)
                    {
                        ((CheckBox)control).Checked = false;
                    }
                }
                foreach (XmlNode countryEnvelope in envelope)
                {
                    string tagFinder = countryEnvelope.Attributes["country"].Value.ToUpper();

                    foreach (Control control in this.splitContainer1.Panel2.Controls)
                    {
                        if (control is CheckBox)
                        {
                            if (((CheckBox)control).Tag.ToString() == tagFinder)
                            {
                                ((CheckBox)control).Checked = true;
                            }
                        }

                        if (control is TextBox)
                        {
                            if (((TextBox)control).Name.ToString() == ("textBox" + tagFinder.ToString()))
                            {
                                ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::invented-name").InnerText.ToString();
                            }

                            if (((TextBox)control).Name.ToString() == ("textBox" + tagFinder.ToString() + "App"))
                            {
                                ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::applicant").InnerText.ToString();
                            }

                            if ((countryEnvelope.ParentNode.ParentNode.Attributes["dtd-version"].InnerText.ToString()) != "1.3")
                            {
                                if (((TextBox)control).Name.ToString() == ("textBoxTrackNo"))
                                {
                                    if (countryEnvelope.SelectSingleNode("descendant::tracking") != null) // .SelectSingleNode("descendant::number").InnerText.ToString()
                                    {
                                        ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::tracking").SelectSingleNode("descendant::number").InnerText.ToString();
                                    }
                                }

                                if (((TextBox)control).Name.ToString() == ("textBoxNumber"))
                                {
                                    ((TextBox)control).Text = countryEnvelope.SelectSingleNode("descendant::number").InnerText.ToString();
                                }
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
                        }

                        if (control is ComboBox)
                        {
                            if (((ComboBox)control).Name.ToString() == ("comboBoxProcType"))
                            {
                                ((ComboBox)control).Text = countryEnvelope.SelectSingleNode("descendant::procedure").Attributes["type"].InnerText.ToString();
                            }

                            if (((ComboBox)control).Name.ToString() == ("comboBoxSubmType"))
                            {
                                ((ComboBox)control).Text = countryEnvelope.SelectSingleNode("descendant::submission").Attributes["type"].InnerText.ToString();
                            }

                            if ((countryEnvelope.ParentNode.ParentNode.Attributes["dtd-version"].InnerText.ToString()) != "1.3")
                            {
                                if (((ComboBox)control).Name.ToString() == ("comboBoxMode") && countryEnvelope.SelectSingleNode("descendant::submission").Attributes["mode"] != null)
                                {
                                    ((ComboBox)control).Text = countryEnvelope.SelectSingleNode("descendant::submission").Attributes["mode"].InnerText.ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Create the eCTD directories
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCreate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.Description = "Please select the root directory where to store all sequences of your dossier.";
            if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // If the user enter a correct sequence path (0000 for instance) then go ahead.
                UserDialogue.CreateDossier cd = new UserDialogue.CreateDossier();
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    SeqDir = fb.SelectedPath;

                    List<string> memberStateList = new List<string>();
                    foreach (Control chkbx in this.Controls)
                    {
                        if (chkbx is CheckBox)
                        {
                            if (((CheckBox)chkbx).Checked == true)
                            {
                                memberStateList.Add(chkbx.Tag.ToString().ToLower());
                            }
                        }
                    }

                    // Create the directories
                    String newfolder = SeqDir + @"\" + cd.SequencePath;
                    this.dirs.Create(newfolder, memberStateList);

                    this.fileExplorerUserControl.PopulateTreeView(newfolder);

                    this.DossierOpened = true;
                }
            }
        }

        private void tsbCreateXMLFiles_Click(object sender, EventArgs e)
        {
            if (this.DossierOpened)
            {
                #region EURegional.xml
                GeneralArchitectureModule1.EU_envelope envelope = new GeneralArchitectureModule1.EU_envelope();
                //string variables for EU envelope
                envelope.UUID = this.lSubmissionIdentifier.Text;
                envelope.trackingNumber = textBoxTrackNo.Text;
                envelope.INN = textBoxINN.Text;
                envelope.submDescr = textBoxSubmDescr.Text;
                envelope.relSeq = textBoxRelSeq.Text;
                envelope.procType = comboBoxProcType.Text;
                envelope.submType = comboBoxSubmType.Text;
                envelope.m1euPath = SeqDir + Path.DirectorySeparatorChar + "m1" + Path.DirectorySeparatorChar + "eu";
                envelope.country = "Common";
                envelope.language = "";
                envelope.m131identifier = "combined";
                envelope.m1euPathIndex = envelope.m1euPath.IndexOf(Path.DirectorySeparatorChar + "m1" + Path.DirectorySeparatorChar);
                envelope.sequence = envelope.m1euPath.Substring(envelope.m1euPathIndex - 4, 4);
                envelope.sequencePath = SeqDir;
                envelope.applicationMode = comboBoxMode.Text;
                envelope.appHighLevelNo = textBoxNumber.Text;
                envelope.comboBoxMode = comboBoxMode.Enabled;
                envelope.comboBoxSubmUnit = comboBoxSubmUnit.Text;
                envelope.NumberEnabled = textBoxNumber.Enabled;

                //generate new uuid if no uuid has been copied from a previous sequence (using the copy envelope button)
                if (envelope.UUID == "")
                {
                    envelope.UUID = Guid.NewGuid().ToString();
                    this.lSubmissionIdentifier.Text = envelope.UUID;
                }

                // collect the name of the countries, agencies, applicants and invented names.
                foreach (Control control in this.splitContainer1.Panel2.Controls)
                {
                    if (control is CheckBox)
                    {
                        if (((CheckBox)control).Checked == true)
                        {
                            if (((CheckBox)control).Tag.ToString() == "EMA")
                            {
                                envelope.envelopeCountry.Add("EMA");
                            }
                            if (((CheckBox)control).Tag.ToString() == "EDQM")
                            {
                                envelope.envelopeCountry.Add("EDQM");
                            }
                            else
                            {
                                envelope.envelopeCountry.Add((((CheckBox)control).Tag.ToString().Substring(0, 2)));
                            }
                            if (envelope.agency == null)
                            {
                                envelope.agency = new List<string>();
                            }
                            envelope.agency.Add((((CheckBox)control).Text.ToString()));

                            foreach (Control control2 in this.splitContainer1.Panel2.Controls)
                            {
                                if ((control2 is TextBox) && ((((TextBox)control2).Tag) == (((CheckBox)control).Tag)))
                                {
                                    if ((((TextBox)control2).Name) == ("textBox" + (((TextBox)control2).Tag) + "App"))
                                    {
                                        if (envelope.applicant == null) { envelope.applicant = new List<String>(); }
                                        envelope.applicant.Add(((TextBox)control2).Text);
                                    }
                                    else
                                    {
                                        if (envelope.inventedName == null) { envelope.inventedName = new List<String>(); }
                                        envelope.inventedName.Add(((TextBox)control2).Text);
                                    }
                                }
                            }
                        }
                    }
                }

                // Try to create the xml files when the eu-path exists. Otherwise abort this method to prevent
                // a inconsistent status of the dossier.
                if (Directory.Exists(envelope.m1euPath))
                {
                    // Create the EURegional.xml file
                    this.XMLCreate.EURegional(envelope, this.dirs, this.files);
                #endregion

                    #region index.xml
                    if (SeqDir.CompareTo("") != 0)
                    {
                        this.XMLCreate.IndexXML(SeqDir, this.dirs, this.files);
                    }
                } else
                {
                    MessageBox.Show("The directory " + envelope.m1euPath + " does not exist.\n\nXML creation aborted.", "Missing directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
        }

        private void tsbRefreshFolderView_Click(object sender, EventArgs e)
        {
            // Refresh the folder view
            this.fileExplorerUserControl.FolderView_ShowFolder();
            this.fileExplorerUserControl.PopulateTreeView();
        }

        private void tsbDeleteEmptyFolder_Click(object sender, EventArgs e)
        {
            if (SeqDir != "")
            {
                DialogResult result = MessageBox.Show("Press OK to delete all empty directories under " + SeqDir, "Confirm delete", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    this.dirs.DeleteEmptyDirectories(SeqDir);
                    this.fileExplorerUserControl.PopulateTreeView();
                }
            }
        }

        /// <summary>
        /// Show the About-Dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        /// <summary>
        /// Close the current dossier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCloseDossier_Click(object sender, EventArgs e)
        {
            if (this.DossierOpened)
            {
                foreach (Control control in this.splitContainer1.Panel2.Controls)
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Text = "";
                    }
                    if (control is ComboBox)
                    {
                        ((ComboBox)control).Text = "";
                    }
                    if (control is CheckBox)
                    {
                        ((CheckBox)control).Checked = false;
                    }
                }

                this.fileExplorerUserControl.CloseDossier();
                this.lSubmissionIdentifier.Text = "";
                this.DossierOpened = false;
            }
        }

        /// <summary>
        /// Close this application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCloseApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// When closing this application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.AskClose)
            {
                String question = "Really close the eCTD-indexer?";
                String caption = "Close Application?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult users_answer = MessageBox.Show(this, question, caption, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (users_answer == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        } 
    }

    internal class MD5Calculator 
    {
        /// <summary>
        /// Returns MD5 checksum for file passed
        /// </summary>
        /// <param name="path"></param>
        /// <returns>MD5 checksum</returns>
        public string ComputeMD5Checksum(string path)
        {
            try
            {
                using (FileStream fs = System.IO.File.OpenRead(path))
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, (int)fs.Length);
                    byte[] checkSum = md5.ComputeHash(fileData);
                    string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                    return result.ToLower();
                }
            }
            catch (Exception ex)
            {
                if (ex is IOException || ex is ArgumentException)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return "ERROR";
            }
        }        
    }
}
