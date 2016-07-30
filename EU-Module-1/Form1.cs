// eCTD indexer (EU Module 1)
// Copyright 2007-2016 Ymir Vesteinsson, ymir@ectd.is

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
using System.Xml;

namespace eCTD_indexer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int FileCounter(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);

            //file counter
            //int numberOfFiles = di.GetFiles().Length;
            int numberOfFiles = 0;

            if (dirs.Length > 0)
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    numberOfFiles = numberOfFiles + dirs[i].GetFiles().Length;
                }
            }
            return numberOfFiles;
        }

        /// <summary>
        /// Counts the number of directory in the given path
        /// </summary>
        /// <param name="path">root directory from where to start counting</param>
        /// <returns>number of directories</returns>
        public int DirCounter(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] dirs = di.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);

            int numberOfDirectories = di.GetDirectories().Length;
            if (dirs.Length > 0)
            {
                for (int j = 0; j < dirs.Length; j++)
                {
                    numberOfDirectories = numberOfDirectories + dirs[j].GetDirectories().Length;
                }
            }

            numberOfDirectories++;
                        
            return numberOfDirectories;       
        }

        #region enables/disables applicant and product name text boxes in line with country checkboxes
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

        /// <summary>
        /// Generates the eu-regional.xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreateEURegionalXML_Click(object sender, EventArgs e)
        {
			//string variables for EU envelope
			string submissionIdentifier = this.lSubmissionIdentifier.Text;
			string trackingNumber = textBoxTrackNo.Text;            
            string applicant = "";
            string agency = "";            
            string inventedName = "";
            string INN = textBoxINN.Text;
            string submDescr = textBoxSubmDescr.Text;
            string relSeq = textBoxRelSeq.Text;
            string procType = comboBoxProcType.Text;
            string submType = comboBoxSubmType.Text;                     
            string m1euPath = textBoxSeqDir.Text + Path.DirectorySeparatorChar+"m1"+Path.DirectorySeparatorChar+"eu";
            string country = "Common";
            string language = "";
            string m131identifier = "combined";
            int m1euPathIndex = m1euPath.IndexOf(Path.DirectorySeparatorChar+"m1"+Path.DirectorySeparatorChar);
            string sequence = m1euPath.Substring(m1euPathIndex - 4, 4);            
            string envelopeCountry;
            string appCountry; //used to determine country in 12-form
            string sequencePath = textBoxSeqDir.Text;
            string applicationMode = comboBoxMode.Text;
            string appHighLevelNo = textBoxNumber.Text;

			//generate new uuid if no uuid has been copied from a previous sequence (using the copy envelope button)
			if (submissionIdentifier == ""){
				submissionIdentifier = Guid.NewGuid ().ToString();
				this.lSubmissionIdentifier.Text = submissionIdentifier;
			}

            //path to save output eu-regional.xml file
            string xmlOutput = m1euPath + Path.DirectorySeparatorChar+ "eu-regional.xml"; 

            //variables for handling multiple child elements
            bool m10open = false;
            bool m12open = false;
            bool m13open = false;
            bool m131spcopen = false;
            bool m132open = false;
            bool m133open = false;
            bool m134open = false;
            bool m135open = false;
            bool m14open = false;
            bool m15open = false;
            bool m16open = false;
            bool m17open = false;
            bool m18open = false;
			bool m181open = false;
            bool m1responsesopen = false;
            bool m1additionalopen = false;

            //integer counter for id values
            int idcounter = 0;

            //title of elements under Module 1.2, changes to use the path between "form-" and ".pdf" of path if the path contains "form-"
            string formTitle = "Application form";

            //count files in m1 folder
            int m1FileNumber = FileCounter(m1euPath);

            //count directories under m1/eu to determine size of dirListArrayM1
            int arraySize = DirCounter(m1euPath);

            string[] dirListArrayM1; //array filled with directory and file names
            dirListArrayM1 = new string[arraySize];
            
            //initialise the array "initialArrayM1"
            for (int i = 0; i < dirListArrayM1.Length; i++)
            {
                dirListArrayM1[i] = "0";
            }

            //pass root directory to dirLister
            directories dir = new directories();
            dirListArrayM1 = dir.dirLister(m1euPath, 0, dirListArrayM1);

            //create a filename array for sorting - workaround for sorting multidimensional array filenameListArray
            //filenameListArray holds filenames, relative path to files, md5s, operation attributes and modified file id information
            string[] filenameSortArray;
            filenameSortArray = new string[m1FileNumber];

            int counterY = 0;
            for (int q = 1; q < dirListArrayM1.Length; q++)
            {
                DirectoryInfo allDirs = new DirectoryInfo(dirListArrayM1[q]);
                foreach (FileInfo f in allDirs.GetFiles())
                {                    
                    filenameSortArray[counterY] = f.FullName;
                    counterY++;
                }
            }
            Array.Sort(filenameSortArray);

            string[,] filenameListArray;
            filenameListArray = new string[m1FileNumber, 5];

            int counterX = 0;

            for (int p = 0; p < m1FileNumber; p++)
            {
                FileInfo f = new FileInfo(filenameSortArray[p]);
                string name = f.FullName;
                int index = name.IndexOf("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar);
                string shortname = name.Substring(index + 6);                
                shortname = shortname.Replace("\\", "/");                
                MD5Calculator checksum = new MD5Calculator();
                string sum = checksum.ComputeMD5Checksum(f.FullName);
                string modifiedFileID = "";
                string operation = "new";

                //Lifecycle operations, replace, append and delete
                if (name.Contains("replace("))
                {
                    string prevSequence = sequencePath.Substring(0, sequencePath.Length - 4) + name.Substring(name.IndexOf("(") + 1, 4) + Path.DirectorySeparatorChar+"m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"eu-regional.xml";
                    string prevLeafPath = shortname.Substring(0, shortname.IndexOf("replace")) + shortname.Substring(shortname.IndexOf(")") + 1, shortname.Length - (shortname.IndexOf(")") + 1));
                    XMLsort repDelID = new XMLsort();
                    modifiedFileID = "../../../" + name.Substring(name.IndexOf("(") + 1, 4) + "/m1/eu/eu-regional.xml#" + repDelID.modifiedFile(prevSequence, prevLeafPath);
                    operation = "replace";

                    //rename file to remove the replace pointer
                    string newFileName = f.FullName.Substring(0, f.FullName.IndexOf("replace")) + f.FullName.Substring(f.FullName.IndexOf(")") + 1, f.FullName.Length - (f.FullName.IndexOf(")") + 1));
                    File.Move(f.FullName, newFileName);
                    name = newFileName;
                    index = name.IndexOf(sequence);
                    shortname = name.Substring(index + 11);
                    shortname = shortname.Replace("\\", "/");
                }
				if (name.Contains("append("))
                {
                    string prevSequence = sequencePath.Substring(0, sequencePath.Length - 4) + name.Substring(name.IndexOf("(") + 1, 4) + Path.DirectorySeparatorChar+"m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"eu-regional.xml";
                    string prevLeafPath = shortname.Substring(0, shortname.IndexOf("append")) + shortname.Substring(shortname.IndexOf(")") + 1, shortname.Length - (shortname.IndexOf(")") + 1));
                    XMLsort repDelID = new XMLsort();
                    modifiedFileID = "../../../" + name.Substring(name.IndexOf("(") + 1, 4) + "/m1/eu/eu-regional.xml#" + repDelID.modifiedFile(prevSequence, prevLeafPath);
                    operation = "append";

                    //rename file to remove the replace pointer
                    string newFileName = f.FullName.Substring(0, f.FullName.IndexOf("append")) + f.FullName.Substring(f.FullName.IndexOf(")") + 1, f.FullName.Length - (f.FullName.IndexOf(")") + 1));
                    File.Move(f.FullName, newFileName);
                    name = newFileName;
                    index = name.IndexOf(sequence);
                    shortname = name.Substring(index + 11);
                    shortname = shortname.Replace("\\", "/");
                }
                if (name.Contains("delete("))
                {
                    string prevSequence = sequencePath.Substring(0, sequencePath.Length - 4) + name.Substring(name.IndexOf("(") + 1, 4) + Path.DirectorySeparatorChar + "m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "eu-regional.xml";
                    string prevLeafPath = shortname.Substring(0, shortname.IndexOf("delete")) + shortname.Substring(shortname.IndexOf(")") + 1, shortname.Length - (shortname.IndexOf(")") + 1));
                    XMLsort repDelID = new XMLsort();
                    //string newFileName = f.FullName.Substring(0, f.FullName.IndexOf("delete")) + f.FullName.Substring(f.FullName.IndexOf(")") + 1, f.FullName.Length - (f.FullName.IndexOf(")") + 1));
                    //name = newFileName;
                    modifiedFileID = "../../../" + name.Substring(name.IndexOf("(") + 1, 4) + "/m1/eu/eu-regional.xml#" + repDelID.modifiedFile(prevSequence, prevLeafPath);
                    operation = "delete";
                    shortname = "";
                    sum = "";
                    File.Delete(f.FullName);
                }
                filenameListArray[counterX, 0] = name;
                filenameListArray[counterX, 1] = shortname;
                filenameListArray[counterX, 2] = sum;
                filenameListArray[counterX, 3] = operation;
                filenameListArray[counterX, 4] = modifiedFileID;
                counterX++;
            }

            try
            {
                StreamWriter sr = File.CreateText(xmlOutput);
                DateTime dt = DateTime.Now;                
                //start of XML file - EU envelope                
                sr.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sr.WriteLine("<!DOCTYPE eu:eu-backbone SYSTEM \"../../util/dtd/eu-regional.dtd\">");
                sr.WriteLine("<?xml-stylesheet type=\"text/xsl\" href=\"../../util/style/eu-regional.xsl\"?>");
                sr.WriteLine("<!-- Generated {0} using eCTD indexer - http://ectd.is -->", dt.ToString());
                sr.WriteLine("<eu:eu-backbone xmlns:eu=\"http://europa.eu.int\"");
                sr.WriteLine("      xmlns:xlink=\"http://www.w3c.org/1999/xlink\"");
                sr.WriteLine("      xml:lang=\"en\" dtd-version=\"3.0.1\">");
                sr.WriteLine("  <eu-envelope>");

                foreach (Control control in this.Controls)
                {
                    if (control is CheckBox)
                    {
                        if (((CheckBox)control).Checked == true)
                        {
                            if (((CheckBox)control).Tag.ToString() == "EMA")
                            {
                                envelopeCountry = "EMA";
                            }
							if (((CheckBox)control).Tag.ToString() == "EDQM")
							{
								envelopeCountry = "EDQM";
							}
                            else
                            {
                                envelopeCountry = (((CheckBox)control).Tag.ToString().Substring(0, 2));
                            }
                            agency = (((CheckBox)control).Text.ToString());                            

                            foreach (Control control2 in this.Controls)
                            {
                                if ((control2 is TextBox) && ((((TextBox)control2).Tag) == (((CheckBox)control).Tag)))
                                {
                                    if ((((TextBox)control2).Name) == ("textBox" + (((TextBox)control2).Tag) + "App"))
                                    {
                                        applicant = (((TextBox)control2).Text);
                                    }
                                    else 
                                    {
                                        inventedName = (((TextBox)control2).Text);
                                    }
                                }
                            }

                            sr.WriteLine("      <envelope country=\"{0}\">", envelopeCountry.ToLower());
							sr.WriteLine("        <identifier>{0}</identifier>", submissionIdentifier);
                            if (comboBoxMode.Enabled == true)
                            {
                                sr.WriteLine("          <submission type=\"{0}\" mode=\"{1}\">", submType, applicationMode);
                            }
                            else
                            {
                                sr.WriteLine("          <submission type=\"{0}\">", submType);
                            }
                            if (appHighLevelNo != null && textBoxNumber.Enabled == true)
                            {
                                sr.WriteLine("              <number>{0}</number>", appHighLevelNo);
                            }
                            sr.WriteLine("              <procedure-tracking>");
                            sr.WriteLine("                  <number>{0}</number>", trackingNumber);
                            sr.WriteLine("              </procedure-tracking>");
                            sr.WriteLine("          </submission>");
							sr.WriteLine("          <submission-unit type=\"{0}\"/>", comboBoxSubmUnit.Text);
                            sr.WriteLine("          <applicant>{0}</applicant>", applicant);
                            sr.WriteLine("          <agency code=\"{0}\"/>", agency);                            
                            sr.WriteLine("          <procedure type=\"{0}\"/>", procType);
                            sr.WriteLine("          <invented-name>{0}</invented-name>", inventedName);
                            sr.WriteLine("          <inn>{0}</inn>", INN);
                            sr.WriteLine("          <sequence>{0}</sequence>", sequence);
                            sr.WriteLine("          <related-sequence>{0}</related-sequence>", relSeq);
                            sr.WriteLine("          <submission-description>{0}</submission-description>", submDescr);
                            sr.WriteLine("      </envelope>");
                        }
                    }
                }

                sr.WriteLine("  </eu-envelope>");

                // start of EU Module 1
                sr.WriteLine("  <m1-eu>");
                //leaf generator
                for (int p = 0; p < m1FileNumber; p++)
                {
                    List<string> filePathList = new List<string>(filenameListArray[p, 0].Split(Path.DirectorySeparatorChar));
                            if (filenameListArray[p,0].Contains("10-cover") && m10open == false)
                            {
                                sr.WriteLine("      <m1-0-cover>");
                                m10open = true;
                            }
                            if (filenameListArray[p,0].Contains("10-cover"))
                            {
                                if (filenameListArray[p, 0].Contains("common")) country = "common";
                                else country = filePathList[filePathList.IndexOf("10-cover")+1];

                                sr.WriteLine("          <specific country=\"{0}\">", country);
                                sr.WriteLine("              <leaf ID=\"m10-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
								if (filenameListArray[p,0].Contains("-tracking"))
						    	{
                                	sr.WriteLine("                  <title>Tracking table</title>");
								}
								else
								{
									sr.WriteLine("                  <title>Cover Letter</title>");
								}
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </specific>");
                                idcounter++;
                            }
                            if (filenameListArray[p,0].Contains("10-cover") == false && m10open == true)
                            {
                                sr.WriteLine("      </m1-0-cover>");
                                m10open = false;
                                idcounter = 0;
                            }
                            if (filenameListArray[p,0].Contains("12-form") && m12open == false)
                            {
                                sr.WriteLine("      <m1-2-form>");
                                m12open = true;
                            }
                            if (filenameListArray[p,0].Contains("12-form"))
                            {
                                if (filenameListArray[p,0].Contains("common")) appCountry = "common";
                                else appCountry = filePathList[filePathList.IndexOf("12-form")+1];
                                if (filenameListArray[p,0].Contains("form-"))
                                {
                                    int formNameStart = filenameListArray[p,0].IndexOf("form-") + 5;
                                    int formNameLength = (filenameListArray[p,0].IndexOf(".") - formNameStart);
                                    formTitle = ("Application - " + filenameListArray[p,0].Substring(formNameStart, formNameLength));
                                }
                                else formTitle = "Application form";
                                sr.WriteLine("          <specific country=\"{0}\">", appCountry);
                                sr.WriteLine("              <leaf ID=\"m12-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>{0}</title>", formTitle);
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </specific>");
                                idcounter++;
                            }
                            if (filenameListArray[p,0].Contains("12-form") == false && m12open == true)
                            {
                                sr.WriteLine("      </m1-2-form>");
                                m12open = false;
                                idcounter = 0;
                            }
                            if (filenameListArray[p,0].Contains("13-pi") && m13open == false)
                            {
                                sr.WriteLine("      <m1-3-pi>");
                                m13open = true;
                            }
                            if (filenameListArray[p,0].Contains("131-spclabelpl") && m131spcopen == false)
                            {
                                sr.WriteLine("          <m1-3-1-spc-label-pl>");
                                m131spcopen = true;
                            }
                            if (filenameListArray[p,0].Contains("131-spclabelpl"))
                            {   
                                country = filePathList[filePathList.IndexOf("131-spclabelpl") + 1];
                                language = filePathList[filePathList.IndexOf("131-spclabelpl") + 2];
                                
                                if (filenameListArray[p,0].Contains("-spc.") || filenameListArray[p,0].Contains("-spc-")) m131identifier = "spc";
                                if (filenameListArray[p,0].Contains("-annex2")) m131identifier = "annex2";
                                if (filenameListArray[p,0].Contains("-outer")) m131identifier = "outer";
                                if (filenameListArray[p,0].Contains("-interpack")) m131identifier = "interpack";
                                if (filenameListArray[p,0].Contains("-impack")) m131identifier = "impack";
                                if (filenameListArray[p,0].Contains("-other")) m131identifier = "other";
                                if (filenameListArray[p,0].Contains("-pl")) m131identifier = "pl";
                                sr.WriteLine("              <pi-doc type=\"{0}\" xml:lang=\"{1}\" country=\"{2}\">", m131identifier, language, country);
                                sr.WriteLine("                  <leaf ID=\"m131-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                      checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                      modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                      xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                      <title>{0}</title>", m131identifier);
                                sr.WriteLine("                  </leaf>");
                                sr.WriteLine("              </pi-doc>");
								idcounter++;
								m131identifier = "";
                            }
                            if (filenameListArray[p,0].Contains("131-spclabelpl") == false && m131spcopen == true)
                            {
                                sr.WriteLine("          </m1-3-1-spc-label-pl>");
                                m131spcopen = false;
                                idcounter = 0;
                            }
                            if (filenameListArray[p,0].Contains("132-mockup") && m132open == false)
                            {
                                sr.WriteLine("          <m1-3-2-mockup>");
                                m132open = true;
                            }
                            if (filenameListArray[p,0].Contains("132-mockup"))
                            {
                                int mockupNameFinder = filenameListArray[p,0].IndexOf("mockup-") + 7;
                                int mockupNameLength = (filenameListArray[p,0].Length - mockupNameFinder) -4;
                                string mockupTitle = filenameListArray[p,0].Substring(mockupNameFinder, mockupNameLength);
                                country = filePathList[filePathList.IndexOf("132-mockup")+1];

                                sr.WriteLine("              <specific country=\"{0}\">", country);
                                sr.WriteLine("                  <leaf ID=\"m132-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                      checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                      modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                      xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                      <title>Mock-up {0}</title>", mockupTitle);
                                sr.WriteLine("                  </leaf>");
                                sr.WriteLine("              </specific>");
                                idcounter++;
                            }
                            if (filenameListArray[p,0].Contains("132-mockup") == false && m132open == true)
                            {
                                sr.WriteLine("          </m1-3-2-mockup>");
                                m132open = false;
                                idcounter = 0;
                            }

                            if (filenameListArray[p,0].Contains("133-specimen") && m133open == false)
                            {
                                sr.WriteLine("          <m1-3-3-specimen>");
                                m133open = true;
                            }
                            if (filenameListArray[p,0].Contains("133-specimen"))
                            {
                                country = filePathList[filePathList.IndexOf("133-specimen") + 1];

                                sr.WriteLine("            <specific country=\"{0}\">", country);
                                sr.WriteLine("                  <leaf ID=\"m133-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                      checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                      modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                      xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                      <title>Specimen</title>");
                                sr.WriteLine("                  </leaf>");
                                sr.WriteLine("              </specific>");
                                idcounter++;
                            }
                            if (filenameListArray[p,0].Contains("133-specimen") == false && m133open == true)
                            {
                                sr.WriteLine("          </m1-3-3-specimen>");
                                m133open = false;
                                idcounter = 0;
                            }
                            if (filenameListArray[p,0].Contains("134-consultation") && m134open == false)
                            {
                                sr.WriteLine("          <m1-3-4-consultation>");
                                m134open = true;
                            }
                            if (filenameListArray[p,0].Contains("134-consultation"))
                            {
                                country = filePathList[filePathList.IndexOf("134-consultation") + 1];

                                sr.WriteLine("            <specific country=\"{0}\">", country);
                                sr.WriteLine("                <leaf ID=\"m134-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                    <title>Consultation with Target Patient Groups</title>");
                                sr.WriteLine("                </leaf>");
                                sr.WriteLine("            </specific>");
                                idcounter++;
                            }
                            if (filenameListArray[p,0].Contains("134-consultation") == false && m134open == true)
                            {
                                sr.WriteLine("          </m1-3-4-consultation>");
                                m134open = false;
                                idcounter = 0;
                            }
                            if (filenameListArray[p,0].Contains("135-approved") && m135open == false)
                            {
                                sr.WriteLine("          <m1-3-5-approved>");
                                m135open = true;
                            }
                            if (filenameListArray[p,0].Contains("135-approved"))
                            {
                                country = filePathList[filePathList.IndexOf("135-approved") + 1];

                                sr.WriteLine("            <specific country=\"{0}\">", country);
                                sr.WriteLine("                  <leaf ID=\"m135-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                      checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                      modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                      xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                      <title>Product Information already approved in the Member States</title>");
                                sr.WriteLine("                  </leaf>");
                                sr.WriteLine("              </specific>");
                                idcounter++;
                            }
                            if (filenameListArray[p,0].Contains("135-approved") == false && m135open == true)
                            {
                                sr.WriteLine("          </m1-3-5-approved>");
                                m135open = false;
                                idcounter = 0;
                            }
                            if (filenameListArray[p,0].Contains("136-braille"))
                            {
                                sr.WriteLine("          <m1-3-6-braille>");
                                sr.WriteLine("              <leaf ID=\"m136\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Braille</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-3-6-braille>");
                            }
                            if (filenameListArray[p,0].Contains("13-pi") == false && m13open == true)
                            {
                                sr.WriteLine("      </m1-3-pi>");
                                m13open = false;
                            }
                            if (filenameListArray[p,0].Contains("14-expert") && m14open == false)
                            {
                                sr.WriteLine("      <m1-4-expert>");
                                m14open = true;
                            }

                            if (filenameListArray[p,0].Contains("141-quality"))
                            {
                                sr.WriteLine("          <m1-4-1-quality>");
                                sr.WriteLine("              <leaf ID=\"m141\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Quality</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-4-1-quality>");
                            }
                            if (filenameListArray[p,0].Contains("142-nonclinical"))
                            {
                                sr.WriteLine("          <m1-4-2-non-clinical>");
                                sr.WriteLine("              <leaf ID=\"m142\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Non-Clinical</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-4-2-non-clinical>");
                            }
                            if (filenameListArray[p,0].Contains("143-clinical"))
                            {
                                sr.WriteLine("          <m1-4-3-clinical>");
                                sr.WriteLine("              <leaf ID=\"m143\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Clinical</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-4-3-clinical>");
                            }
                            if (filenameListArray[p,0].Contains("14-expert") == false && m14open == true)
                            {
                                sr.WriteLine("      </m1-4-expert>");
                                m14open = false;
                            }


                            if (filenameListArray[p,0].Contains("15-specific") && m15open == false)
                            {
                                sr.WriteLine("      <m1-5-specific>");
                                m15open = true;
                            }
                            if (filenameListArray[p,0].Contains("151-bibliographic"))
                            {
                                sr.WriteLine("          <m1-5-1-bibliographic>");
                                sr.WriteLine("              <leaf ID=\"m151\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Information for Bibliographical Applications</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-5-1-bibliographic>");
                            }
                            if (filenameListArray[p,0].Contains("152-generic-hybrid-bio-similar"))
                            {
                                sr.WriteLine("          <m1-5-2-generic-hybrid-bio-similar>");
                                sr.WriteLine("              <leaf ID=\"m152\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Information for Generic, �Hybrid� or Bio-similar Applications</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-5-2-generic-hybrid-bio-similar>");
                            }
                            if (filenameListArray[p,0].Contains("153-data-market-exclusivity"))
                            {
                                sr.WriteLine("          <m1-5-3-data-market-exclusivity>");
                                sr.WriteLine("              <leaf ID=\"m153\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>(Extended) Data/Market Exclusivity</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-5-3-data-market-exclusivity>");
                            }
                            if (filenameListArray[p,0].Contains("154-exceptional"))
                            {
                                sr.WriteLine("          <m1-5-4-exceptional-circumstances>");
                                sr.WriteLine("              <leaf ID=\"m154\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Exceptional Circumstances</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-5-4-exceptional-circumstances>");
                            }
                            if (filenameListArray[p,0].Contains("155-conditional-ma"))
                            {
                                sr.WriteLine("          <m1-5-5-conditional-ma>");
                                sr.WriteLine("              <leaf ID=\"m155\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Conditional Marketing Authorisation</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-5-5-conditional-ma>");
                            }
                            if (filenameListArray[p,0].Contains("15-specific") == false && m15open == true)
                            {
                                sr.WriteLine("      </m1-5-specific>");
                                m15open = false;
                            }


                            if (filenameListArray[p,0].Contains("16-environrisk") && m16open == false)
                            {
                                sr.WriteLine("      <m1-6-environrisk>");
                                m16open = true;
                            }
                            if (filenameListArray[p,0].Contains("161-nongmo"))
                            {
                                sr.WriteLine("          <m1-6-1-non-gmo>");
                                sr.WriteLine("              <leaf ID=\"m161nongmo\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Non-GMO</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-6-1-non-gmo>");
                            }
                            if (filenameListArray[p,0].Contains("162-gmo"))
                            {
                                sr.WriteLine("          <m1-6-2-gmo>");
                                sr.WriteLine("              <leaf ID=\"m161gmo\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>GMO</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-6-2-gmo>");
                            }
                            if (filenameListArray[p,0].Contains("16-environrisk") == false && m16open == true)
                            {
                                sr.WriteLine("      </m1-6-environrisk>");
                                m16open = false;
                            }


                            if (filenameListArray[p,0].Contains("17-orphan") && m17open == false)
                            {
                                sr.WriteLine("      <m1-7-orphan>");
                                m17open = true;
                            }
                            if (filenameListArray[p,0].Contains("171-similarity"))
                            {
                                sr.WriteLine("          <m1-7-1-similarity>");
                                sr.WriteLine("              <leaf ID=\"m171\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Similarity</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-7-1-similarity>");
                            }
                            if (filenameListArray[p,0].Contains("172-market-exclusivity"))
                            {
                                sr.WriteLine("          <m1-7-2-market-exclusivity>");
                                sr.WriteLine("              <leaf ID=\"m172\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Market Exclusivity</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-7-2-market-exclusivity>");
                            }
                            if (filenameListArray[p,0].Contains("17-orphan") == false && m17open == true)
                            {
                                sr.WriteLine("      </m1-7-orphan>");
                                m17open = false;
                            }

                            if (filenameListArray[p,0].Contains("18-pharmacovigilance") && m18open == false)
                            {
                                sr.WriteLine("      <m1-8-pharmacovigilance>");
                                m18open = true;
                            }
							if (filenameListArray[p,0].Contains("181-phvig-system") && m181open == false)
							{
								sr.WriteLine("          <m1-8-1-pharmacovigilance-system>");
								m181open = true;
							}
                            if (filenameListArray[p,0].Contains("181-phvig-system"))
                            {                                
								sr.WriteLine("              <leaf ID=\"m18-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Pharmacovigilance System</title>");
                                sr.WriteLine("              </leaf>");    
								idcounter++;
                            }
							if (filenameListArray[p,0].Contains("181-phvig-system") == false && m181open == true)
							{
								sr.WriteLine("          </m1-8-1-pharmacovigilance-system>");
								m181open = false;
							}
                            if (filenameListArray[p,0].Contains("182-riskmgt-system"))
                            {
                                sr.WriteLine("          <m1-8-2-risk-management-system>");
								sr.WriteLine("              <leaf ID=\"m18-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Risk-management System</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </m1-8-2-risk-management-system>");
								idcounter++;
                            }
                            if (filenameListArray[p,0].Contains("18-pharmacovigilance") == false && m18open == true)
                            {
                                sr.WriteLine("      </m1-8-pharmacovigilance>");
                                m18open = false;
								idcounter = 0;
                            }
                            if (filenameListArray[p,0].Contains("19-clinical-trials"))
                            {
                                sr.WriteLine("      <m1-9-clinical-trials>");
                                sr.WriteLine("          <leaf ID=\"m19\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("              checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("              modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("              xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("              <title>Information relating to Clinical Trials</title>");
                                sr.WriteLine("          </leaf>");
                                sr.WriteLine("      </m1-9-clinical-trials>");
                            }
                            if (filenameListArray[p,0].Contains("110-paediatrics"))
                            {
                                sr.WriteLine("      <m1-10-paediatrics>");
                                sr.WriteLine("          <leaf ID=\"m110\" operation=\"{0}\" checksum-type=\"md5\"", filenameListArray[p,3]);
                                sr.WriteLine("              checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("              modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("              xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("              <title>Information relating to Paediatrics</title>");
                                sr.WriteLine("          </leaf>");
                                sr.WriteLine("      </m1-10-paediatrics>");
                            }
                            if (filenameListArray[p,0].Contains("additional-data") && m1additionalopen == false)
                            {
                                sr.WriteLine("      <m1-additional-data>");
                                m1additionalopen = true;
                            }
                            if (filenameListArray[p,0].Contains("additional-data"))
                            {
                                country = filePathList[filePathList.IndexOf("additional-data") + 1];

                                sr.WriteLine("          <specific country=\"{0}\">", country);
                                sr.WriteLine("              <leaf ID=\"m1add-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Additional Data</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </specific>");
                                idcounter++;
                            }
                            if (filenameListArray[p,0].Contains("additional-data") == false && m1additionalopen == true)
                            {
                                sr.WriteLine("      </m1-additional-data>");
                                m1additionalopen = false;
                                idcounter = 0;
                            }
                            if (filenameListArray[p,0].Contains("eu"+Path.DirectorySeparatorChar+"responses") && m1responsesopen == false)
                            {
                                sr.WriteLine("      <m1-responses>");
                                m1responsesopen = true;
                            }
                            if (filenameListArray[p, 0].Contains("eu" + Path.DirectorySeparatorChar + "responses"))
                            {
                                country = filePathList[filePathList.IndexOf("responses") + 1];

                                sr.WriteLine("          <specific country=\"{0}\">", country);
                                sr.WriteLine("              <leaf ID=\"m1res-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p,3]);
                                sr.WriteLine("                  checksum=\"{0}\"", filenameListArray[p,2]);
                                sr.WriteLine("                  modified-file=\"{0}\"", filenameListArray[p,4]);
                                sr.WriteLine("                  xlink:href=\"{0}\">", filenameListArray[p,1]);
                                sr.WriteLine("                  <title>Responses to Questions</title>");
                                sr.WriteLine("              </leaf>");
                                sr.WriteLine("          </specific>");
                                idcounter++;
                            }
                            if (filenameListArray[p, 0].Contains("eu" + Path.DirectorySeparatorChar + "responses") == false && m1responsesopen == true)
                            {
                                sr.WriteLine("      </m1-responses>");
                                m1responsesopen = false;
                                idcounter = 0;
                    }
                }
                //end of XML file
                if (m10open == true) sr.WriteLine("      </m1-0-cover>");
                if (m12open == true) sr.WriteLine("      </m1-2-form>");
                if (m131spcopen == true) sr.WriteLine("          </m1-3-1-spc-label-pl>");
                if (m132open == true) sr.WriteLine("          </m1-3-2-mockup>");
                if (m133open == true) sr.WriteLine("          </m1-3-3-specimen>");
                if (m134open == true) sr.WriteLine("          </m1-3-4-consultation>");
                if (m135open == true) sr.WriteLine("          </m1-3-5-approved>");
                if (m13open == true) sr.WriteLine("      </m1-3-pi>");
                if (m14open == true) sr.WriteLine("      </m1-4-expert>");
                if (m15open == true) sr.WriteLine("      </m1-5-specific>");
                if (m16open == true) sr.WriteLine("      </m1-6-environrisk>");
                if (m17open == true) sr.WriteLine("      </m1-7-orphan>");
                if (m181open == true) sr.WriteLine("          </m1-8-1-pharmacovigilance-system>");
                if (m18open == true) sr.WriteLine("      </m1-8-pharmacovigilance>");
                if (m1additionalopen == true) sr.WriteLine("      </m1-additional-data>");
                if (m1responsesopen == true) sr.WriteLine("      </m1-responses>");                
                sr.WriteLine("  </m1-eu>");
                sr.WriteLine("</eu:eu-backbone>");
                sr.Close();
                textBoxMD5.Text = xmlOutput;
				
				//call m1sort method in XMLsort class to put Module 1.10 paediatrics in its right place                
                XMLsort sortingHat = new XMLsort();
                sortingHat.m1sort(xmlOutput);
				
                DialogResult resultm1;
                resultm1 = MessageBox.Show(xmlOutput + "\n Open file?", "Module 1 indexing completed", MessageBoxButtons.YesNo);
                if (resultm1 == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(xmlOutput);
                }
            }

            catch (Exception f)
            {
                MessageBox.Show(f.ToString(), "The indexing process failed");                
            }
        }

        private void btCalculateMD5_Click(object sender, EventArgs e) //calculates MD5 for single file
        {
            string singleMD5 = textBoxMD5.Text;
            MD5Calculator checksum = new MD5Calculator();
            string sum = checksum.ComputeMD5Checksum(singleMD5);
            textBoxNewMD5.Text = sum;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string indexmd5output = textBoxMD5.Text.Substring(0, textBoxMD5.Text.LastIndexOf(Path.DirectorySeparatorChar)) + Path.DirectorySeparatorChar + "index-md5.txt";
                StreamWriter indexmd5 = File.CreateText(indexmd5output);                
                indexmd5.WriteLine(textBoxNewMD5.Text);
                indexmd5.Close();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString(), "Saving index-md5.txt failed");
            }
        }

        private void btGenerateIndexXML_Click(object sender, EventArgs e) //generates index.xml
        {
            if (textBoxSeqDir.Text.CompareTo("") != 0)
            {
                string sequencePath = textBoxSeqDir.Text;
                //path to save output index.xml file
                string xmlIndexOutput = sequencePath + Path.DirectorySeparatorChar + "index.xml";
                int sequencePathIndex = sequencePath.LastIndexOf(Path.DirectorySeparatorChar);
                string sequence = sequencePath.Substring(sequencePathIndex + 1, 4);

                //variables for handling multiple child elements where these are allowed in the DTD            
                //module 2
                bool m2open = false;
                bool m22open = false;
                bool m23open = false;
                bool m23popen = false;
                bool m24open = false;
                bool m25open = false;
                bool m26open = false;
                bool m27open = false;

                //module 3
                bool m3open = false;
                bool m32open = false;
                bool m32sopen = false;
                bool m32s1open = false;
                bool m32s11open = false;
                bool m32s12open = false;
                bool m32s13open = false;
                bool m32s2open = false;
                bool m32s21open = false;
                bool m32s22open = false;
                bool m32s23open = false;
                bool m32s24open = false;
                bool m32s25open = false;
                bool m32s26open = false;
                bool m32s3open = false;
                bool m32s31open = false;
                bool m32s32open = false;
                bool m32s4open = false;
                bool m32s41open = false;
                bool m32s42open = false;
                bool m32s43open = false;
                bool m32s44open = false;
                bool m32s45open = false;
                bool m32s5open = false;
                bool m32s6open = false;
                bool m32s7open = false;
                bool m32s71open = false;
                bool m32s72open = false;
                bool m32s73open = false;
                bool m32popen = false;
                bool m32p1open = false;
                bool m32p2open = false;
                bool m32p3open = false;
                bool m32p35open = false;
                bool m32p4open = false;
                bool m32p5open = false;
                bool m32p51open = false;
                bool m32p52open = false;
                bool m32p53open = false;
                bool m32p54open = false;
                bool m32p55open = false;
                bool m32p56open = false;
                bool m32p6open = false;
                bool m32p7open = false;
                bool m32p8open = false;
                bool m32p81open = false;
                bool m32p82open = false;
                bool m32p83open = false;
                bool m32aopen = false;
                bool m32a1open = false;
                bool m32a2open = false;
                bool m32a3open = false;
                bool m32ropen = false;
                bool m33open = false;
                string substance = "0"; //used for multiple 3.2.S
                string substance1 = "0"; //used for multiple 3.2.S
                string product = ""; //used for multiple 3.2.P
                string product1 = ""; //used for multiple 3.2.P
                string excipient = ""; //used for multiple 3.2.P.4
                string excipient1 = ""; //used for multiple 3.2.P.4
                int charindex; //used for multiple 3.2.S, 3.2.P, 3.2.P.4, also used for module 5.3.5
                int startposition; //used for multiple 3.2.S, 3.2.P, 3.2.P.4, also used for module 5.3.5
                int endposition; //used for multiple 3.2.S, 3.2.P, 3.2.P.4, also used for module 5.3.5
                string api = ""; //used to assign "substance" attribute in 3.2.S 
                int apiIndex = 0; //used to assign "substance" attribute in 3.2.S 
                string manufacturer = ""; //used to assign "manufacturer" attribute in 3.2.S
                int manufacturerIndex = 0; //used to assign "manufacturer" attribute in 3.2.S

                //module 4
                bool m4open = false;
                bool m42open = false;
                bool m421open = false;
                bool m4211open = false;
                bool m4212open = false;
                bool m4213open = false;
                bool m4214open = false;
                bool m422open = false;
                bool m4221open = false;
                bool m4222open = false;
                bool m4223open = false;
                bool m4224open = false;
                bool m4225open = false;
                bool m4226open = false;
                bool m4227open = false;
                bool m423open = false;
                bool m4231open = false;
                bool m4232open = false;
                bool m4233open = false;
                bool m42331open = false;
                bool m42332open = false;
                bool m4234open = false;
                bool m42341open = false;
                bool m42342open = false;
                bool m42343open = false;
                bool m4235open = false;
                bool m42351open = false;
                bool m42352open = false;
                bool m42353open = false;
                bool m42354open = false;
                bool m4236open = false;
                bool m4237open = false;
                bool m42371open = false;
                bool m42372open = false;
                bool m42373open = false;
                bool m42374open = false;
                bool m42375open = false;
                bool m42376open = false;
                bool m42377open = false;
                bool m43open = false;


                //module 5
                bool m5open = false;
                bool m52open = false;
                bool m53open = false;
                bool m531open = false;
                bool m5311open = false;
                bool m5312open = false;
                bool m5313open = false;
                bool m5314open = false;
                bool m532open = false;
                bool m5321open = false;
                bool m5322open = false;
                bool m5323open = false;
                bool m533open = false;
                bool m5331open = false;
                bool m5332open = false;
                bool m5333open = false;
                bool m5334open = false;
                bool m5335open = false;
                bool m534open = false;
                bool m5341open = false;
                bool m5342open = false;
                bool m535open = false;
                bool m5351open = false;
                bool m5352open = false;
                bool m5353open = false;
                bool m5354open = false;
                bool m536open = false;
                bool m537open = false;
                bool m54open = false;
                string indication = "";
                string indication1 = "";

                //integer counter for id values
                int idcounter = 0;

                //count files in sequence to determine max. number of unindexed files
                int totalFileNumber = FileCounter(sequencePath);

                //count directories in sequence to determine array size for dirListArray
                int arraySize = DirCounter(sequencePath);

                //system to list unindexed files
                bool indexed = false;
                string[] unIndexed; //array of unindexed files
                unIndexed = new string[totalFileNumber];
                //unindexed counter
                int n = 0;
                //initialise unIndexed Array
                for (int i = 0; i < unIndexed.Length; i++)
                {
                    unIndexed[i] = "";
                }

                string[] dirListArray; //array receiving from dirLister
                dirListArray = new string[arraySize];

                //initialise dirListArray
                for (int i = 0; i < dirListArray.Length; i++)
                {
                    dirListArray[i] = "0";
                }

                //pass root directory to dirLister
                directories dir = new directories();
                dirListArray = dir.dirLister(sequencePath, 0, dirListArray);

                //create a filename array for sorting - workaround for sorting multidimensional array filenameListArray
                //populate this array with all filenames in sequence, except any files directly under sequence directory (i.e. not files on same level as m1, m2... directories)
                //filenameListArray holds filenames, relative path to files, md5s, operation attributes and modified file id information
                string[] filenameSortArray;
                filenameSortArray = new string[totalFileNumber];

                int counterY = 0;
                for (int q = 1; q < dirListArray.Length; q++)
                {
                    DirectoryInfo allDirs = new DirectoryInfo(dirListArray[q]);
                    foreach (FileInfo f in allDirs.GetFiles())
                    {
                        filenameSortArray[counterY] = f.FullName;
                        counterY++;
                    }
                }
                Array.Sort(filenameSortArray);

                string[,] filenameListArray;
                filenameListArray = new string[totalFileNumber, 5];

                int counterX = 0;

                for (int p = 0; p < totalFileNumber; p++)
                {
                    FileInfo f = new FileInfo(filenameSortArray[p]);
                    string name = f.FullName;
                    int index = name.IndexOf(sequence);
                    string shortname = name.Substring(index + 5);
                    shortname = shortname.Replace("\\", "/");
                    MD5Calculator checksum = new MD5Calculator();
                    string sum = checksum.ComputeMD5Checksum(f.FullName);
                    string modifiedFileID = "";
                    string operation = "new";

                    //Lifecycle operations, replace, append and delete
                    if (name.Contains("replace("))
                    {
                        string prevSequence = sequencePath.Substring(0, sequencePath.Length - 4) + name.Substring(name.IndexOf("(") + 1, 4) + Path.DirectorySeparatorChar + "index.xml";
                        string prevLeafPath = shortname.Substring(0, shortname.IndexOf("replace")) + shortname.Substring(shortname.IndexOf(")") + 1, shortname.Length - (shortname.IndexOf(")") + 1));
                        XMLsort repDelID = new XMLsort();
                        modifiedFileID = "../" + name.Substring(name.IndexOf("(") + 1, 4) + "/index.xml#" + repDelID.modifiedFile(prevSequence, prevLeafPath);
                        operation = "replace";

                        //rename file to remove the replace pointer
                        string newFileName = f.FullName.Substring(0, f.FullName.IndexOf("replace")) + f.FullName.Substring(f.FullName.IndexOf(")") + 1, f.FullName.Length - (f.FullName.IndexOf(")") + 1));
                        File.Move(f.FullName, newFileName);
                        name = newFileName;
                        index = name.IndexOf(sequence);
                        shortname = name.Substring(index + 5);
                        shortname = shortname.Replace("\\", "/");
                    }
                    if (name.Contains("append("))
                    {
                        string prevSequence = sequencePath.Substring(0, sequencePath.Length - 4) + name.Substring(name.IndexOf("(") + 1, 4) + Path.DirectorySeparatorChar + "index.xml";
                        string prevLeafPath = shortname.Substring(0, shortname.IndexOf("append")) + shortname.Substring(shortname.IndexOf(")") + 1, shortname.Length - (shortname.IndexOf(")") + 1));
                        XMLsort repDelID = new XMLsort();
                        modifiedFileID = "../" + name.Substring(name.IndexOf("(") + 1, 4) + "/index.xml#" + repDelID.modifiedFile(prevSequence, prevLeafPath);
                        operation = "append";

                        //rename file to remove the replace pointer
                        string newFileName = f.FullName.Substring(0, f.FullName.IndexOf("append")) + f.FullName.Substring(f.FullName.IndexOf(")") + 1, f.FullName.Length - (f.FullName.IndexOf(")") + 1));
                        File.Move(f.FullName, newFileName);
                        name = newFileName;
                        index = name.IndexOf(sequence);
                        shortname = name.Substring(index + 5);
                        shortname = shortname.Replace("\\", "/");
                    }
                    if (name.Contains("delete("))
                    {
                        string prevSequence = sequencePath.Substring(0, sequencePath.Length - 4) + name.Substring(name.IndexOf("(") + 1, 4) + Path.DirectorySeparatorChar + "index.xml";
                        string prevLeafPath = shortname.Substring(0, shortname.IndexOf("delete")) + shortname.Substring(shortname.IndexOf(")") + 1, shortname.Length - (shortname.IndexOf(")") + 1));
                        XMLsort repDelID = new XMLsort();
                        //string newFileName = f.FullName.Substring(0, f.FullName.IndexOf("delete")) + f.FullName.Substring(f.FullName.IndexOf(")") + 1, f.FullName.Length - (f.FullName.IndexOf(")") + 1));
                        //name = newFileName;
                        modifiedFileID = "../" + name.Substring(name.IndexOf("(") + 1, 4) + "/index.xml#" + repDelID.modifiedFile(prevSequence, prevLeafPath);
                        operation = "delete";
                        shortname = "";
                        sum = "";
                        File.Delete(f.FullName);
                    }
                    filenameListArray[counterX, 0] = name;
                    filenameListArray[counterX, 1] = shortname;
                    filenameListArray[counterX, 2] = sum;
                    filenameListArray[counterX, 3] = operation;
                    filenameListArray[counterX, 4] = modifiedFileID;
                    counterX++;
                }

                try
                {
                    StreamWriter swr = File.CreateText(xmlIndexOutput);
                    DateTime dt = DateTime.Now;
                    //start of XML file - index.xml                
                    swr.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    swr.WriteLine("<!DOCTYPE ectd:ectd SYSTEM \"util/dtd/ich-ectd-3-2.dtd\">");
                    swr.WriteLine("<?xml-stylesheet type=\"text/xsl\" href=\"util/style/ectd-2-0.xsl\"?>");
                    swr.WriteLine("<!-- Generated {0} using eCTD indexer - http://ectd.is -->", dt.ToString());
                    swr.WriteLine("<ectd:ectd dtd-version=\"3.2\" xml:lang=\"en\" xmlns:ectd=\"http://www.ich.org/ectd\" xmlns:xlink=\"http://www.w3c.org/1999/xlink\">");
                    //leaf generator
                    for (int p = 0; p < totalFileNumber; p++)
                    {
                        //Module 1
                        if (filenameListArray[p, 0].Contains("eu-regional.xml"))
                        {
                            swr.WriteLine("    <m1-administrative-information-and-prescribing-information>");
                            swr.WriteLine("        <leaf ID=\"m1-{0}\" operation=\"new\" checksum-type=\"md5\"", idcounter);
                            swr.WriteLine("            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("            modified-file=\"{0}\"", filenameListArray[p, 4]); ;
                            swr.WriteLine("            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("            <title>EU Regional Module 1</title>");
                            swr.WriteLine("        </leaf>");
                            swr.WriteLine("    </m1-administrative-information-and-prescribing-information>");
                            indexed = true;
                        }

                        //Module 2
                        if (filenameListArray[p, 0].Contains("m2" + Path.DirectorySeparatorChar) && m2open == false)
                        {
                            swr.WriteLine("    <m2-common-technical-document-summaries>");
                            m2open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m2" + Path.DirectorySeparatorChar) && filenameListArray[p, 0].Contains("m2" + Path.DirectorySeparatorChar + "2") == false)
                        {
                            swr.WriteLine("        <leaf ID=\"m2-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("            modified-file=\"{0}\"", filenameListArray[p, 4]); ;
                            swr.WriteLine("            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("            <title>Cover Letter</title>");
                            swr.WriteLine("        </leaf>");
                            idcounter++;
                            indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "22-intro") && m22open == false)
                        {
                            swr.WriteLine("        <m2-2-introduction>");
                            m22open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "22-intro"))
                        {
                            swr.WriteLine("            <leaf ID=\"m22-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                <title>Introduction</title>");
                            swr.WriteLine("            </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "22-intro") == false && m22open == true)
                        {
                            swr.WriteLine("        </m2-2-introduction>");
                            m22open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos") && m23open == false)
                        {
                            swr.WriteLine("        <m2-3-quality-overall-summary>");
                            m23open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos")
                            && filenameListArray[p, 0].Contains("introduction") == false
                            && filenameListArray[p, 0].Contains("drug-substance") == false
                            && filenameListArray[p, 0].Contains("drug-product") == false
                            && filenameListArray[p, 0].Contains("appendices") == false
                            && filenameListArray[p, 0].Contains("regional-information") == false)
                        {
                            swr.WriteLine("            <leaf ID=\"m23-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                <title>Quality Overall Summary</title>");
                            swr.WriteLine("            </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos") && filenameListArray[p, 0].Contains("appendices"))
                        {
                            swr.WriteLine("            <m2-3-a-appendices>");
                            swr.WriteLine("                <leaf ID=\"m23a-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>Appendices</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-3-a-appendices>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos" + Path.DirectorySeparatorChar + "drug-product") && m23popen == false)
                        {
                            swr.WriteLine("            <m2-3-p-drug-product>");
                            m23popen = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos" + Path.DirectorySeparatorChar + "drug-product"))
                        {
                            swr.WriteLine("                <leaf ID=\"m23p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>Drug Product</title>");
                            swr.WriteLine("                 </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos" + Path.DirectorySeparatorChar + "drug-product") == false && m23popen == true)
                        {
                            swr.WriteLine("            </m2-3-p-drug-product>");
                            m23popen = false;
                        }

                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos" + Path.DirectorySeparatorChar + "drug-substance"))
                        {
                            if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos" + Path.DirectorySeparatorChar + "drug-substance.pdf") == false && filenameListArray[p, 0].Contains("-manufacturer-"))
                            {
                                apiIndex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "23-qos" + Path.DirectorySeparatorChar + "drug-substance-");
                                manufacturerIndex = filenameListArray[p, 0].IndexOf("-manufacturer-");
                                api = filenameListArray[p, 0].Substring(apiIndex + 23, (manufacturerIndex - (apiIndex + 23)));
                                manufacturer = filenameListArray[p, 0].Substring(manufacturerIndex + 14, filenameListArray[p, 0].Length - (manufacturerIndex + 14 + 4));
                            }
                            else
                            {
                                api = "";
                                manufacturer = "";
                            }

                            swr.WriteLine("            <m2-3-s-drug-substance substance=\"{0}\" manufacturer=\"{1}\">", api, manufacturer);
                            swr.WriteLine("                <leaf ID=\"m23s-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>Drug Substance</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-3-s-drug-substance>");
                            idcounter++; indexed = true;
                        }

                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos") && filenameListArray[p, 0].Contains("introduction"))
                        {
                            swr.WriteLine("            <m2-3-introduction>");
                            swr.WriteLine("                <leaf ID=\"m23i-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>Introduction</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-3-introduction>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos") && filenameListArray[p, 0].Contains("regional-information"))
                        {
                            swr.WriteLine("            <m2-3-r-regional-information>");
                            swr.WriteLine("                <leaf ID=\"m23r-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>Regional information</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-3-r-regional-information>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "23-qos") == false && m23open == true)
                        {
                            swr.WriteLine("        </m2-3-quality-overall-summary>");
                            m23open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "24-nonclin-over") && m24open == false)
                        {
                            swr.WriteLine("        <m2-4-nonclinical-overview>");
                            m24open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "24-nonclin-over"))
                        {
                            swr.WriteLine("            <leaf ID=\"m24-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                <title>2.4 Nonclinical Overview</title>");
                            swr.WriteLine("            </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "24-nonclin-over") == false && m24open == true)
                        {
                            swr.WriteLine("        </m2-4-nonclinical-overview>");
                            m24open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "25-clin-over") && m25open == false)
                        {
                            swr.WriteLine("        <m2-5-clinical-overview>");
                            m25open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "25-clin-over"))
                        {
                            swr.WriteLine("            <leaf ID=\"m25-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                <title>2.5 Clinical Overview</title>");
                            swr.WriteLine("            </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "25-clin-over") == false && m25open == true)
                        {
                            swr.WriteLine("        </m2-5-clinical-overview>");
                            m25open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum") == true && m26open == false)
                        {
                            swr.WriteLine("        <m2-6-nonclinical-written-and-tabulated-summaries>");
                            m26open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum") == true
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "introduction") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "pharmacol-written-summary") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "pharmacol-tabulated-summary") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "pharmkin-written-summary") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "pharmkin-tabulated-summary") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "toxicology-written-summary") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "toxicology-tabulated-summary") == false)
                        {
                            swr.WriteLine("            <leaf ID=\"m26-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                <title>2.6 Nonclinical Written and Tabulated Summaries</title>");
                            swr.WriteLine("            </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "introduction") == true)
                        {
                            swr.WriteLine("            <m2-6-1-introduction>");
                            swr.WriteLine("                <leaf ID=\"m26-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.6.1 Introduction</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-6-1-introduction>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "pharmacol-written-summary") == true)
                        {
                            swr.WriteLine("            <m2-6-2-pharmacology-written-summary>");
                            swr.WriteLine("                <leaf ID=\"m26-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.6.2 Pharmacology Written Summary</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-6-2-pharmacology-written-summary>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "pharmacol-tabulated-summary") == true)
                        {
                            swr.WriteLine("            <m2-6-3-pharmacology-tabulated-summary>");
                            swr.WriteLine("                <leaf ID=\"m26-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.6.3 Pharmacology Tabulated Summary</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-6-3-pharmacology-tabulated-summary>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "pharmkin-written-summary") == true)
                        {
                            swr.WriteLine("            <m2-6-4-pharmacokinetics-written-summary>");
                            swr.WriteLine("                <leaf ID=\"m26-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.6.4 Pharmacokinetics Written Summary</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-6-4-pharmacokinetics-written-summary>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "pharmkin-tabulated-summary") == true)
                        {
                            swr.WriteLine("            <m2-6-5-pharmacokinetics-tabulated-summary>");
                            swr.WriteLine("                <leaf ID=\"m26-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.6.5 Pharmacokinetics Tabulated Summary</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-6-5-pharmacokinetics-tabulated-summary>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "toxicology-written-summary") == true)
                        {
                            swr.WriteLine("            <m2-6-6-toxicology-written-summary>");
                            swr.WriteLine("                <leaf ID=\"m26-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.6.6 Toxicology Written Summary</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-6-6-toxicology-written-summary>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum" + Path.DirectorySeparatorChar + "toxicology-tabulated-summary") == true)
                        {
                            swr.WriteLine("            <m2-6-7-toxicology-tabulated-summary>");
                            swr.WriteLine("                <leaf ID=\"m26-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.6.7 Toxicology Tabulated Summary</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-6-7-toxicology-tabulated-summary>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "26-nonclin-sum") == false && m26open == true)
                        {
                            swr.WriteLine("        </m2-6-nonclinical-written-and-tabulated-summaries>");
                            m26open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum") == true && m27open == false)
                        {
                            swr.WriteLine("        <m2-7-clinical-summary>");
                            m27open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum") == true
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "summary-biopharm") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "summary-clin-pharm") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "summary-clin-efficacy") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "summary-clin-safety") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "literature-references") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "synopses-indiv-studies") == false)
                        {
                            swr.WriteLine("                <leaf ID=\"m27-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.7 Clinical Summary</title>");
                            swr.WriteLine("                </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "summary-biopharm") == true)
                        {
                            swr.WriteLine("            <m2-7-1-summary-of-biopharmaceutic-studies-and-associated-analytical-methods>");
                            swr.WriteLine("                <leaf ID=\"m27-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.7.1 Summary of Biopharmaceutic Studies and Associated Analytical Methods</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-7-1-summary-of-biopharmaceutic-studies-and-associated-analytical-methods>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "summary-clin-pharm") == true)
                        {
                            swr.WriteLine("            <m2-7-2-summary-of-clinical-pharmacology-studies>");
                            swr.WriteLine("                <leaf ID=\"m27-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.7.2 Summary of Clinical Pharmacology Studies</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-7-2-summary-of-clinical-pharmacology-studies>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "summary-clin-efficacy") == true)
                        {
                            indication = filenameListArray[p, 0].Substring((filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "summary-clin-efficacy-") + 23), (filenameListArray[p, 0].IndexOf(".") - (filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "summary-clin-efficacy-") + 23)));
                            swr.WriteLine("            <m2-7-3-summary-of-clinical-efficacy indication=\"{0}\">", indication);
                            swr.WriteLine("                <leaf ID=\"m27-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.7.3 Summary of Clinical Efficacy - {0}</title>", indication);
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-7-3-summary-of-clinical-efficacy>");
                            indication = "";
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "summary-clin-safety") == true)
                        {
                            swr.WriteLine("            <m2-7-4-summary-of-clinical-safety>");
                            swr.WriteLine("                <leaf ID=\"m27-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.7.4 Summary of Clinical Safety</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-7-4-summary-of-clinical-safety>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "literature-references") == true)
                        {
                            swr.WriteLine("            <m2-7-5-literature-references>");
                            swr.WriteLine("                <leaf ID=\"m27-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.7.5 Literature References</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-7-5-literature-references>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum" + Path.DirectorySeparatorChar + "synopses-indiv-studies") == true)
                        {
                            swr.WriteLine("            <m2-7-6-synopses-of-individual-studies>");
                            swr.WriteLine("                <leaf ID=\"m27-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>2.7.6 Synopses of Individual Studies</title>");
                            swr.WriteLine("                </leaf>");
                            swr.WriteLine("            </m2-7-6-synopses-of-individual-studies>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "27-clin-sum") == false && m27open == true)
                        {
                            swr.WriteLine("        </m2-7-clinical-summary>");
                            m27open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m2" + Path.DirectorySeparatorChar) == false && m2open == true)
                        {
                            swr.WriteLine("    </m2-common-technical-document-summaries>");
                            m2open = false;
                            idcounter = 0;
                        }

                        //Module 3
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar) == true && m3open == false)
                        {
                            swr.WriteLine("    <m3-quality>");
                            m3open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data") == true && m32open == false)
                        {
                            swr.WriteLine("        <m3-2-body-of-data>");
                            m32open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app") == true && m32aopen == false)
                        {
                            swr.WriteLine("            <m3-2-a-appendices>");
                            m32aopen = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app") == true
                            && filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a1-fac-equip") == false
                            && filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a2-advent-agent") == false
                            && filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a3-excip") == false)
                        {
                            swr.WriteLine("                <leaf ID=\"m32a-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>3.2.A Appendices</title>");
                            swr.WriteLine("                </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a1-fac-equip") == true && m32a1open == false)
                        {
                            swr.WriteLine("                <m3-2-a-1-facilities-and-equipment>");
                            m32a1open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a1-fac-equip") == true)
                        {
                            swr.WriteLine("                    <leaf ID=\"m32a-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.A.1 Facilities and Equipment</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a1-fac-equip") == false && m32a1open == true)
                        {
                            swr.WriteLine("                </m3-2-a-1-facilities-and-equipment>");
                            m32a1open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a2-advent-agent") == true && m32a2open == false)
                        {
                            swr.WriteLine("                <m3-2-a-2-adventitious-agents-safety-evaluation>");
                            m32a2open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a2-advent-agent") == true)
                        {
                            swr.WriteLine("                    <leaf ID=\"m32a-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.A.2 Adventitious Agents Safety Evaluation</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a2-advent-agent") == false && m32a2open == true)
                        {
                            swr.WriteLine("                </m3-2-a-2-adventitious-agents-safety-evaluation>");
                            m32a2open = false;
                        }

                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a3-excip") == true && m32a3open == false)
                        {
                            swr.WriteLine("                <m3-2-a-3-excipients>");
                            m32a3open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a3-excip"))
                        {
                            swr.WriteLine("                    <leaf ID=\"m32a-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.A.3 Excipients</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app" + Path.DirectorySeparatorChar + "32a3-excip") == false && m32a3open == true)
                        {
                            swr.WriteLine("                </m3-2-a-3-excipients>");
                            m32a3open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32a-app") == false && m32aopen == true)
                        {
                            swr.WriteLine("            </m3-2-a-appendices>");
                            m32aopen = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod") && m32popen == false)
                        {
                            charindex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "32p-drug-prod");
                            startposition = charindex + 15;
                            endposition = filenameListArray[p, 0].Length - startposition;
                            product = filenameListArray[p, 0].Substring(startposition, endposition);
                            charindex = product.IndexOf(Path.DirectorySeparatorChar);
                            product = product.Substring(0, charindex);
                            swr.WriteLine("            <m3-2-p-drug-product product-name=\"{0}\">", product);
                            m32popen = true;
                            idcounter = 0;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod") && m32popen == true)
                        {
                            charindex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "32p-drug-prod");
                            startposition = charindex + 15;
                            endposition = filenameListArray[p, 0].Length - startposition;
                            product1 = filenameListArray[p, 0].Substring(startposition, endposition);
                            charindex = product1.IndexOf(Path.DirectorySeparatorChar);
                            product1 = product1.Substring(0, charindex);
                            if (string.Equals(product, product1) == false)
                            {
                                if (m32p1open)
                                {
                                    swr.WriteLine("                </m3-2-p-1-description-and-composition-of-the-drug-product>");
                                    m32p1open = false;
                                }
                                if (m32p2open)
                                {
                                    swr.WriteLine("                </m3-2-p-2-pharmaceutical-development>");
                                    m32p2open = false;
                                }
                                if (m32p35open)
                                {
                                    swr.WriteLine("                    </m3-2-p-3-5-process-validation-and-or-evaluation>");
                                    m32p35open = false;
                                }
                                if (m32p3open)
                                {
                                    swr.WriteLine("                </m3-2-p-3-manufacture>");
                                    m32p3open = false;
                                }
                                if (m32p4open)
                                {
                                    swr.WriteLine("                </m3-2-p-4-control-of-excipients>");
                                    m32p4open = false;
                                }
                                if (m32p51open)
                                {
                                    swr.WriteLine("                    </m3-2-p-5-1-specifications>");
                                    m32p51open = false;
                                }
                                if (m32p52open)
                                {
                                    swr.WriteLine("                    </m3-2-p-5-2-analytical-procedures>");
                                    m32p52open = false;
                                }
                                if (m32p53open)
                                {
                                    swr.WriteLine("                    </m3-2-p-5-3-validation-of-analytical-procedures>");
                                    m32p53open = false;
                                }
                                if (m32p54open)
                                {
                                    swr.WriteLine("                    </m3-2-p-5-4-batch-analyses>");
                                    m32p54open = false;
                                }
                                if (m32p55open)
                                {
                                    swr.WriteLine("                    </m3-2-p-5-5-characterisation-of-impurities>");
                                    m32p55open = false;
                                }
                                if (m32p56open)
                                {
                                    swr.WriteLine("                    </m3-2-p-5-6-justification-of-specifications>");
                                    m32p56open = false;
                                }
                                if (m32p5open)
                                {
                                    swr.WriteLine("                </m3-2-p-5-control-of-drug-product>");
                                    m32p5open = false;
                                }
                                if (m32p6open)
                                {
                                    swr.WriteLine("                </m3-2-p-6-reference-standards-or-materials>");
                                    m32p6open = false;
                                }
                                if (m32p7open)
                                {
                                    swr.WriteLine("                </m3-2-p-7-container-closure-system>");
                                    m32p7open = false;
                                }
                                if (m32p82open)
                                {
                                    swr.WriteLine("                    </m3-2-p-8-2-post-approval-stability-protocol-and-stability-commitment>");
                                    m32p82open = false;
                                }
                                if (m32p83open)
                                {
                                    swr.WriteLine("                    </m3-2-p-8-3-stability-data>");
                                    m32p83open = false;
                                }
                                if (m32p81open)
                                {
                                    swr.WriteLine("                    </m3-2-p-8-1-stability-summary-and-conclusion>");
                                    m32p81open = false;
                                }
                                if (m32p8open)
                                {
                                    swr.WriteLine("                </m3-2-p-8-stability>");
                                    m32p8open = false;
                                }
                                swr.WriteLine("            </m3-2-p-drug-product>");
                                swr.WriteLine("            <m3-2-p-drug-product product-name=\"{0}\">", product1);
                                product = product1;
                            }
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p1-desc-comp") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p2-pharm-dev") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p6-ref-stand") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p7-cont-closure-sys") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab") == false)
                        {
                            swr.WriteLine("                <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>3.2.P Drug Product</title>");
                            swr.WriteLine("                </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p1-desc-comp") && m32p1open == false)
                        {
                            swr.WriteLine("                <m3-2-p-1-description-and-composition-of-the-drug-product>");
                            m32p1open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p1-desc-comp"))
                        {
                            swr.WriteLine("                    <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.P.1 Description and Composition of the Drug Product</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p1-desc-comp") == false && m32p1open == true)
                        {
                            swr.WriteLine("                </m3-2-p-1-description-and-composition-of-the-drug-product>");
                            m32p1open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p2-pharm-dev") && m32p2open == false)
                        {
                            swr.WriteLine("                <m3-2-p-2-pharmaceutical-development>");
                            m32p2open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p2-pharm-dev"))
                        {
                            swr.WriteLine("                    <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.P.2 Pharmaceutical Development</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p2-pharm-dev") == false && m32p2open == true)
                        {
                            swr.WriteLine("                </m3-2-p-2-pharmaceutical-development>");
                            m32p2open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf") && m32p3open == false)
                        {
                            swr.WriteLine("                <m3-2-p-3-manufacture>");
                            m32p3open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "manufacturers") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "batch-formula") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "manuf-process-and-controls") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "control-critical-steps") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "process-validation") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.P.3 Manufacture</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf" + Path.DirectorySeparatorChar + "manufacturers"))
                        {
                            swr.WriteLine("                    <m3-2-p-3-1-manufacturers>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.3.1 Manufacturer(s)</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-3-1-manufacturers>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf" + Path.DirectorySeparatorChar + "batch-formula"))
                        {
                            swr.WriteLine("                    <m3-2-p-3-2-batch-formula>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.3.2 Batch Formula</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-3-2-batch-formula>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf" + Path.DirectorySeparatorChar + "manuf-process-and-controls"))
                        {
                            swr.WriteLine("                    <m3-2-p-3-3-description-of-manufacturing-process-and-process-controls>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.3.3 Description of Manufacturing Process and Process Controls</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-3-3-description-of-manufacturing-process-and-process-controls>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf" + Path.DirectorySeparatorChar + "control-critical-steps"))
                        {
                            swr.WriteLine("                    <m3-2-p-3-4-controls-of-critical-steps-and-intermediates>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.3.4 Controls of Critical Steps and Intermediates</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-3-4-controls-of-critical-steps-and-intermediates>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf" + Path.DirectorySeparatorChar + "process-validation") && m32p35open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-3-5-process-validation-and-or-evaluation>");
                            m32p35open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf" + Path.DirectorySeparatorChar + "process-validation"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.3.5 Process Validation and/or Evaluation</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf" + Path.DirectorySeparatorChar + "process-validation") == false && m32p35open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-3-5-process-validation-and-or-evaluation>");
                            m32p35open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p3-manuf") == false && m32p3open == true)
                        {
                            swr.WriteLine("                </m3-2-p-3-manufacture>");
                            m32p3open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar) && m32p4open == false)
                        {
                            charindex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "32p4-contr-excip");
                            startposition = charindex + 18;
                            endposition = filenameListArray[p, 0].Length - startposition;
                            excipient = filenameListArray[p, 0].Substring(startposition, endposition);
                            charindex = excipient.IndexOf(Path.DirectorySeparatorChar);
                            if (charindex > 0)
                            {
                                excipient = excipient.Substring(0, charindex);
                            }
                            else excipient = "";
                            swr.WriteLine("                <m3-2-p-4-control-of-excipients excipient=\"{0}\">", excipient);
                            m32p4open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar) && m32p4open == true)
                        {
                            charindex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "32p4-contr-excip");
                            startposition = charindex + 18;
                            endposition = filenameListArray[p, 0].Length - startposition;
                            excipient1 = filenameListArray[p, 0].Substring(startposition, endposition);
                            charindex = excipient1.IndexOf(Path.DirectorySeparatorChar);
                            if (charindex > 0)
                            {
                                excipient1 = excipient1.Substring(0, charindex);
                            }
                            else excipient1 = "";
                            if (string.Equals(excipient, excipient1) == false)
                            {
                                swr.WriteLine("                </m3-2-p-4-control-of-excipients>");
                                swr.WriteLine("                <m3-2-p-4-control-of-excipients excipient=\"{0}\">", excipient1);
                                excipient = excipient1;
                            }
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar)
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "specifications") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "analytical-procedures") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "validation-analyt-procedures") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "justification-of-specifications") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "excipients-human-animal") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "novel-excipients") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.P.4 Excipients</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar) && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "specifications"))
                        {
                            swr.WriteLine("                    <m3-2-p-4-1-specifications>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.4.1 Specifications</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-4-1-specifications>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar) && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "analytical-procedures"))
                        {
                            swr.WriteLine("                    <m3-2-p-4-2-analytical-procedures>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.4.2 Analytical Procedures</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-4-2-analytical-procedures>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar) && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "validation-analyt-procedures"))
                        {
                            swr.WriteLine("                    <m3-2-p-4-3-validation-of-analytical-procedures>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.4.3 Validation of Analytical Procedures</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-4-3-validation-of-analytical-procedures>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar) && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "justification-of-specifications"))
                        {
                            swr.WriteLine("                    <m3-2-p-4-4-justification-of-specifications>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.4.4 Justification of Specifications</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-4-4-justification-of-specifications>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar) && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "excipients-human-animal"))
                        {
                            swr.WriteLine("                    <m3-2-p-4-5-excipients-of-human-or-animal-origin>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.4.5 Excipients of Human or Animal Origin</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-4-5-excipients-of-human-or-animal-origin>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar + "novel-excipients"))
                        {
                            swr.WriteLine("                    <m3-2-p-4-6-novel-excipients>");
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.4.6 Novel Excipients</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-p-4-6-novel-excipients>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p4-contr-excip" + Path.DirectorySeparatorChar) == false && m32p4open == true)
                        {
                            swr.WriteLine("                </m3-2-p-4-control-of-excipients>");
                            m32p4open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod") && m32p5open == false)
                        {
                            swr.WriteLine("                <m3-2-p-5-control-of-drug-product>");
                            m32p5open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p51-spec") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p52-analyt-proc") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p53-val-analyt-proc") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p54-batch-analys") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p55-charac-imp") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p56-justif-spec") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.P.5 Control of Drug Product</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }


                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p51-spec") && m32p51open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-5-1-specifications>");
                            m32p51open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p51-spec"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.5.1 Specification(s)</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p51-spec") == false && m32p51open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-5-1-specifications>");
                            m32p51open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p52-analyt-proc") && m32p52open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-5-2-analytical-procedures>");
                            m32p52open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p52-analyt-proc"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.5.2 Analytical Procedures</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p52-analyt-proc") == false && m32p52open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-5-2-analytical-procedures>");
                            m32p52open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p53-val-analyt-proc") && m32p53open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-5-3-validation-of-analytical-procedures>");
                            m32p53open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p53-val-analyt-proc"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.5.3 Validation of Analytical Procedures</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p53-val-analyt-proc") == false && m32p53open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-5-3-validation-of-analytical-procedures>");
                            m32p53open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p54-batch-analys") && m32p54open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-5-4-batch-analyses>");
                            m32p54open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p54-batch-analys"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.5.4 Batch Analyses</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p54-batch-analys") == false && m32p54open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-5-4-batch-analyses>");
                            m32p54open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p55-charac-imp") && m32p55open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-5-5-characterisation-of-impurities>");
                            m32p55open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p55-charac-imp"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.5.5 Characterisation of Impurities</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p55-charac-imp") == false && m32p55open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-5-5-characterisation-of-impurities>");
                            m32p55open = false;
                        }

                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p56-justif-spec") && m32p56open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-5-6-justification-of-specifications>");
                            m32p56open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p56-justif-spec"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.5.6 Justification of Specifications</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod" + Path.DirectorySeparatorChar + "32p56-justif-spec") == false && m32p56open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-5-6-justification-of-specifications>");
                            m32p56open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p5-contr-drug-prod") == false && m32p5open == true)
                        {
                            swr.WriteLine("                </m3-2-p-5-control-of-drug-product>");
                            m32p5open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p6-ref-stand") && m32p6open == false)
                        {
                            swr.WriteLine("                <m3-2-p-6-reference-standards-or-materials>");
                            m32p6open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p6-ref-stand"))
                        {
                            swr.WriteLine("                    <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.P.6 Reference Standards or Materials</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p6-ref-stand") == false && m32p6open == true)
                        {
                            swr.WriteLine("                </m3-2-p-6-reference-standards-or-materials>");
                            m32p6open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p7-cont-closure-sys") && m32p7open == false)
                        {
                            swr.WriteLine("                <m3-2-p-7-container-closure-system>");
                            m32p7open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p7-cont-closure-sys"))
                        {
                            swr.WriteLine("                    <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.P.7 Container Closure System</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p7-cont-closure-sys") == false && m32p7open == true)
                        {
                            swr.WriteLine("                </m3-2-p-7-container-closure-system>");
                            m32p7open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab") && m32p8open == false)
                        {
                            swr.WriteLine("                <m3-2-p-8-stability>");
                            m32p8open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "stability-summary") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "postapproval-stability") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "stability-data") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.P.8 Stability</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "postapproval-stability") && m32p82open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-8-2-post-approval-stability-protocol-and-stability-commitment>");
                            m32p82open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "postapproval-stability"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.8.2 Post-approval Stability Protocol and Stability Commitment</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "postapproval-stability") == false && m32p82open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-8-2-post-approval-stability-protocol-and-stability-commitment>");
                            m32p82open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "stability-data") && m32p83open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-8-3-stability-data>");
                            m32p83open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "stability-data"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.8.3 Stability Data</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "stability-data") == false && m32p83open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-8-3-stability-data>");
                            m32p83open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "stability-summary") && m32p81open == false)
                        {
                            swr.WriteLine("                    <m3-2-p-8-1-stability-summary-and-conclusion>");
                            m32p81open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "stability-summary"))
                        {

                            swr.WriteLine("                        <leaf ID=\"m32p-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.P.8.1 Stability Summary and Conclusion</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab" + Path.DirectorySeparatorChar + "stability-summary") == false && m32p81open == true)
                        {
                            swr.WriteLine("                    </m3-2-p-8-1-stability-summary-and-conclusion>");
                            m32p81open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32p8-stab") == false && m32p8open == true)
                        {
                            swr.WriteLine("                </m3-2-p-8-stability>");
                            m32p8open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32p-drug-prod") == false && m32popen == true)
                        {
                            swr.WriteLine("            </m3-2-p-drug-product>");
                            m32popen = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32r-reg-info") == true && m32ropen == false)
                        {
                            swr.WriteLine("            <m3-2-r-regional-information>");
                            m32ropen = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32r-reg-info"))
                        {
                            swr.WriteLine("                <leaf ID=\"m32r-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                    checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                    modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                    xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                    <title>3.2.R Regional Information</title>");
                            swr.WriteLine("                </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32r-reg-info") == false && m32ropen == true)
                        {
                            swr.WriteLine("            </m3-2-r-regional-information>");
                            m32ropen = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub") && m32sopen == false)
                        {
                            charindex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "32s-drug-sub");
                            startposition = charindex + 14;
                            endposition = filenameListArray[p, 0].Length - startposition;
                            substance = filenameListArray[p, 0].Substring(startposition, endposition);
                            charindex = substance.IndexOf(Path.DirectorySeparatorChar);
                            substance = substance.Substring(0, charindex);
                            if (filenameListArray[p, 0].Contains("-manufacturer-") && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-"))
                            {
                                apiIndex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-");
                                manufacturerIndex = filenameListArray[p, 0].IndexOf("-manufacturer-");
                                api = filenameListArray[p, 0].Substring(apiIndex + 24, (manufacturerIndex - (apiIndex + 24)));
                                manufacturer = filenameListArray[p, 0].Substring(manufacturerIndex + 14);
                                manufacturer = manufacturer.Substring(0, manufacturer.IndexOf(Path.DirectorySeparatorChar));
                            }
                            else
                            {
                                api = "";
                                manufacturer = "";
                            }
                            swr.WriteLine("            <m3-2-s-drug-substance substance=\"{0}\" manufacturer=\"{1}\">", api, manufacturer);
                            m32sopen = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub") && m32sopen == true)
                        {
                            charindex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "32s-drug-sub");
                            startposition = charindex + 14;
                            endposition = filenameListArray[p, 0].Length - startposition;
                            substance1 = filenameListArray[p, 0].Substring(startposition, endposition);
                            charindex = substance1.IndexOf(Path.DirectorySeparatorChar);
                            substance1 = substance1.Substring(0, charindex);
                            if (string.Equals(substance, substance1) == false)
                            {
                                if (m32s11open)
                                {
                                    swr.WriteLine("                    </m3-2-s-1-1-nomenclature>");
                                    m32s11open = false;
                                }
                                if (m32s12open)
                                {
                                    swr.WriteLine("                    </m3-2-s-1-2-structure>");
                                    m32s12open = false;
                                }
                                if (m32s13open)
                                {
                                    swr.WriteLine("                    </m3-2-s-1-3-general-properties>");
                                    m32s13open = false;
                                }
                                if (m32s1open)
                                {
                                    swr.WriteLine("                </m3-2-s-1-general-information>");
                                    m32s1open = false;
                                }
                                if (m32s21open)
                                {
                                    swr.WriteLine("                    </m3-2-s-2-1-manufacturer>");
                                    m32s21open = false;
                                }
                                if (m32s22open)
                                {
                                    swr.WriteLine("                    </m3-2-s-2-2-description-of-manufacturing-process-and-process-controls>");
                                    m32s22open = false;
                                }
                                if (m32s23open)
                                {
                                    swr.WriteLine("                    </m3-2-s-2-3-control-of-materials>");
                                    m32s23open = false;
                                }
                                if (m32s24open)
                                {
                                    swr.WriteLine("                    </m3-2-s-2-4-controls-of-critical-steps-and-intermediates>");
                                    m32s24open = false;
                                }
                                if (m32s25open)
                                {
                                    swr.WriteLine("                    </m3-2-s-2-5-process-validation-and-or-evaluation>");
                                    m32s25open = false;
                                }
                                if (m32s26open)
                                {
                                    swr.WriteLine("                    </m3-2-s-2-6-manufacturing-process-development>");
                                    m32s26open = false;
                                }
                                if (m32s2open)
                                {
                                    swr.WriteLine("                </m3-2-s-2-manufacture>");
                                    m32s2open = false;
                                }
                                if (m32s31open)
                                {
                                    swr.WriteLine("                    </m3-2-s-3-1-elucidation-of-structure-and-other-characteristics>");
                                    m32s31open = false;
                                }
                                if (m32s32open)
                                {
                                    swr.WriteLine("                    </m3-2-s-3-2-impurities>");
                                    m32s32open = false;
                                }
                                if (m32s3open)
                                {
                                    swr.WriteLine("                </m3-2-s-3-characterisation>");
                                    m32s3open = false;
                                }
                                if (m32s41open)
                                {
                                    swr.WriteLine("                    </m3-2-s-4-1-specification>");
                                    m32s41open = false;
                                }
                                if (m32s42open)
                                {
                                    swr.WriteLine("                    </m3-2-s-4-2-analytical-procedures>");
                                    m32s42open = false;
                                }
                                if (m32s43open)
                                {
                                    swr.WriteLine("                    </m3-2-s-4-3-validation-of-analytical-procedures>");
                                    m32s43open = false;
                                }
                                if (m32s44open)
                                {
                                    swr.WriteLine("                    </m3-2-s-4-4-batch-analyses>");
                                    m32s44open = false;
                                }
                                if (m32s45open)
                                {
                                    swr.WriteLine("                    </m3-2-s-4-5-justification-of-specification>");
                                    m32s45open = false;
                                }
                                if (m32s4open)
                                {
                                    swr.WriteLine("                </m3-2-s-4-control-of-drug-substance>");
                                    m32s4open = false;
                                }
                                if (m32s5open)
                                {
                                    swr.WriteLine("                </m3-2-s-5-reference-standards-or-materials>");
                                    m32s5open = false;
                                }
                                if (m32s6open)
                                {
                                    swr.WriteLine("                </m3-2-s-6-container-closure-system>");
                                    m32s6open = false;
                                }
                                if (m32s71open)
                                {
                                    swr.WriteLine("                    </m3-2-s-7-1-stability-summary-and-conclusions>");
                                    m32s71open = false;
                                }
                                if (m32s72open)
                                {
                                    swr.WriteLine("                    </m3-2-s-7-2-post-approval-stability-protocol-and-stability-commitment>");
                                    m32s72open = false;
                                }
                                if (m32s73open)
                                {
                                    swr.WriteLine("                    </m3-2-s-7-3-stability-data>");
                                    m32s73open = false;
                                }
                                if (m32s7open)
                                {
                                    swr.WriteLine("                </m3-2-s-7-stability>");
                                    m32s7open = false;
                                }
                                swr.WriteLine("            </m3-2-s-drug-substance>");

                                if (filenameListArray[p, 0].Contains("-manufacturer-") && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-"))
                                {
                                    apiIndex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "32s-drug-sub" + Path.DirectorySeparatorChar + "substance-");
                                    manufacturerIndex = filenameListArray[p, 0].IndexOf("-manufacturer-");
                                    api = filenameListArray[p, 0].Substring(apiIndex + 24, (manufacturerIndex - (apiIndex + 24)));
                                    manufacturer = filenameListArray[p, 0].Substring(manufacturerIndex + 14);
                                    manufacturer = manufacturer.Substring(0, manufacturer.IndexOf(Path.DirectorySeparatorChar));
                                }
                                else
                                {
                                    api = "";
                                    manufacturer = "";
                                }
                                swr.WriteLine("            <m3-2-s-drug-substance substance=\"{0}\" manufacturer=\"{1}\">", api, manufacturer);
                                substance = substance1;
                            }
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info") && m32s1open == false)
                        {
                            swr.WriteLine("                <m3-2-s-1-general-information>");
                            m32s1open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info" + Path.DirectorySeparatorChar + "nomenclature") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info" + Path.DirectorySeparatorChar + "structure") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info" + Path.DirectorySeparatorChar + "general-properties") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.S.1 General Information</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info" + Path.DirectorySeparatorChar + "nomenclature"))
                        {
                            swr.WriteLine("                    <m3-2-s-1-1-nomenclature>");
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.1.1 Nomenclature</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-s-1-1-nomenclature>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info" + Path.DirectorySeparatorChar + "structure"))
                        {
                            swr.WriteLine("                    <m3-2-s-1-2-structure>");
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.1.2 Structure</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-s-1-2-structure>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info" + Path.DirectorySeparatorChar + "general-properties"))
                        {
                            swr.WriteLine("                    <m3-2-s-1-3-general-properties>");
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.1.3 General Properties</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-s-1-3-general-properties>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s1-gen-info") == false && m32s1open == true)
                        {
                            swr.WriteLine("                </m3-2-s-1-general-information>");
                            m32s1open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf") && m32s2open == false)
                        {
                            swr.WriteLine("                <m3-2-s-2-manufacture>");
                            m32s2open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manufacturer") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manuf-process-and-controls") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "control-of-materials") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "control-critical-steps") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "process-validation") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manuf-process-development") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.S.2 Manufacture</title>");
                            swr.WriteLine("                    </leaf>");
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "control-critical-steps") && m32s24open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-2-4-controls-of-critical-steps-and-intermediates>");
                            m32s24open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "control-critical-steps"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.2.4 Controls of Critical Steps and Intermediates</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "control-critical-steps") == false && m32s24open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-2-4-controls-of-critical-steps-and-intermediates>");
                            m32s24open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "control-of-materials") && m32s23open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-2-3-control-of-materials>");
                            m32s23open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "control-of-materials"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.2.3 Control of Materials</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "control-of-materials") == false && m32s23open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-2-3-control-of-materials>");
                            m32s23open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manufacturer") && m32s21open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-2-1-manufacturer>");
                            m32s21open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manufacturer"))
                        {

                            swr.WriteLine("                         <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                             <title>3.2.S.2.1 Manufacturer(s)</title>");
                            swr.WriteLine("                         </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manufacturer") == false && m32s21open == true)
                        {
                            swr.WriteLine("                     </m3-2-s-2-1-manufacturer>");
                            m32s21open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manuf-process-and-controls") && m32s22open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-2-2-description-of-manufacturing-process-and-process-controls>");
                            m32s22open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manuf-process-and-controls"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.2.2 Description of Manufacturing Process and Process Controls</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manuf-process-and-controls") == false && m32s22open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-2-2-description-of-manufacturing-process-and-process-controls>");
                            m32s22open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manuf-process-development") && m32s26open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-2-6-manufacturing-process-development>");
                            m32s26open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manuf-process-development"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.2.6 Manufacturing Process Development</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }

                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "manuf-process-development") == false && m32s26open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-2-6-manufacturing-process-development>");
                            m32s26open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "process-validation") && m32s25open == false)
                        {
                            swr.WriteLine("                     <m3-2-s-2-5-process-validation-and-or-evaluation>");
                            m32s25open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "process-validation"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.2.5 Process Validation and/or Evaluation</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf" + Path.DirectorySeparatorChar + "process-validation") == false && m32s25open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-2-5-process-validation-and-or-evaluation>");
                            m32s25open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s2-manuf") == false && m32s2open == true)
                        {
                            swr.WriteLine("                </m3-2-s-2-manufacture>");
                            m32s2open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s3-charac") && m32s3open == false)
                        {
                            swr.WriteLine("                <m3-2-s-3-characterisation>");
                            m32s3open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s3-charac")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s3-charac" + Path.DirectorySeparatorChar + "elucidation-of-structure") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s3-charac" + Path.DirectorySeparatorChar + "impurities") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.S.3 Characterisation</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s3-charac" + Path.DirectorySeparatorChar + "elucidation-of-structure"))
                        {
                            swr.WriteLine("                    <m3-2-s-3-1-elucidation-of-structure-and-other-characteristics>");
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.3.1 Elucidation of Structure and Other Characteristics</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-s-3-1-elucidation-of-structure-and-other-characteristics>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s3-charac" + Path.DirectorySeparatorChar + "impurities"))
                        {
                            swr.WriteLine("                    <m3-2-s-3-2-impurities>");
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.3.2 Impurities</title>");
                            swr.WriteLine("                        </leaf>");
                            swr.WriteLine("                    </m3-2-s-3-2-impurities>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s3-charac") == false && m32s3open == true)
                        {
                            swr.WriteLine("                </m3-2-s-3-characterisation>");
                            m32s3open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub") && m32s4open == false)
                        {
                            swr.WriteLine("                <m3-2-s-4-control-of-drug-substance>");
                            m32s4open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s41-spec") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s42-analyt-proc") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s43-val-analyt-proc") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s44-batch-analys") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s45-justif-spec") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.S.4 Control of Drug Substance</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s41-spec") && m32s41open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-4-1-specification>");
                            m32s41open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s41-spec"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.4.1 Specifications</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s41-spec") == false && m32s41open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-4-1-specification>");
                            m32s41open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s42-analyt-proc") && m32s42open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-4-2-analytical-procedures>");
                            m32s42open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s42-analyt-proc"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.4.2 Analytical Procedures</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s42-analyt-proc") == false && m32s42open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-4-2-analytical-procedures>");
                            m32s42open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s43-val-analyt-proc") && m32s43open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-4-3-validation-of-analytical-procedures>");
                            m32s43open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s43-val-analyt-proc"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.4.3 Validation of Analytical Procedures</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s43-val-analyt-proc") == false && m32s43open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-4-3-validation-of-analytical-procedures>");
                            m32s43open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s44-batch-analys") && m32s44open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-4-4-batch-analyses>");
                            m32s44open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s44-batch-analys"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.4.4 Batch Analyses</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s44-batch-analys") == false && m32s44open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-4-4-batch-analyses>");
                            m32s44open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s45-justif-spec") && m32s45open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-4-5-justification-of-specification>");
                            m32s45open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s45-justif-spec"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.4.5 Justification of Specification</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub" + Path.DirectorySeparatorChar + "32s45-justif-spec") == false && m32s45open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-4-5-justification-of-specification>");
                            m32s45open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s4-contr-drug-sub") == false && m32s4open == true)
                        {
                            swr.WriteLine("                </m3-2-s-4-control-of-drug-substance>");
                            m32s4open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s5-ref-stand") && m32s5open == false)
                        {
                            swr.WriteLine("                <m3-2-s-5-reference-standards-or-materials>");
                            m32s5open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s5-ref-stand"))
                        {
                            swr.WriteLine("                    <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.S.5 Reference Standards or Materials</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s5-ref-stand") == false && m32s5open == true)
                        {
                            swr.WriteLine("                </m3-2-s-5-reference-standards-or-materials>");
                            m32s5open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s6-cont-closure-sys") && m32s6open == false)
                        {
                            swr.WriteLine("                <m3-2-s-6-container-closure-system>");
                            m32s6open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s6-cont-closure-sys"))
                        {
                            swr.WriteLine("                    <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.S.6 Container Closure System</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s6-cont-closure-sys") == false && m32s6open == true)
                        {
                            swr.WriteLine("                </m3-2-s-6-container-closure-system>");
                            m32s6open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab") && m32s7open == false)
                        {
                            swr.WriteLine("                <m3-2-s-7-stability>");
                            m32s7open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "stability-summary") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "postapproval-stability") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "stability-data") == false)
                        {
                            swr.WriteLine("                    <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                        checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                        modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                        xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                        <title>3.2.S.7 Stability</title>");
                            swr.WriteLine("                    </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "postapproval-stability") && m32s72open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-7-2-post-approval-stability-protocol-and-stability-commitment>");
                            m32s72open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "postapproval-stability"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.7.2 Post-approval Stability Protocol and Stability Commitment</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "postapproval-stability") == false && m32s72open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-7-2-post-approval-stability-protocol-and-stability-commitment>");
                            m32s72open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "stability-data") && m32s73open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-7-3-stability-data>");
                            m32s73open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "stability-data"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.7.3 Stability Data</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "stability-data") == false && m32s73open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-7-3-stability-data>");
                            m32s73open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "stability-summary") && m32s71open == false)
                        {
                            swr.WriteLine("                    <m3-2-s-7-1-stability-summary-and-conclusions>");
                            m32s71open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "stability-summary"))
                        {
                            swr.WriteLine("                        <leaf ID=\"m3-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                            checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                            modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                            xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                            <title>3.2.S.7.1 Stability Summary and Conclusions</title>");
                            swr.WriteLine("                        </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab" + Path.DirectorySeparatorChar + "stability-summary") == false && m32s71open == true)
                        {
                            swr.WriteLine("                    </m3-2-s-7-1-stability-summary-and-conclusions>");
                            m32s71open = false;
                        }


                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "32s7-stab") == false && m32s7open == true)
                        {
                            swr.WriteLine("                </m3-2-s-7-stability>");
                            m32s7open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data" + Path.DirectorySeparatorChar + "32s-drug-sub") == false && m32sopen == true)
                        {
                            swr.WriteLine("            </m3-2-s-drug-substance>");
                            m32sopen = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "32-body-data") == false && m32open == true)
                        {
                            swr.WriteLine("        </m3-2-body-of-data>");
                            m32open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "33-lit-ref") && m33open == false)
                        {
                            swr.WriteLine("        <m3-3-literature-references>");
                            m33open = true;
                            idcounter = 1;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "33-lit-ref"))
                        {
                            swr.WriteLine("            <leaf ID=\"m33-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("                checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("                modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("                xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("                <title>3.3 Literature Reference - {0}</title>", idcounter.ToString());
                            swr.WriteLine("            </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar + "33-lit-ref") == false && m33open == true)
                        {
                            swr.WriteLine("        </m3-3-literature-references>");
                            m33open = false;
                        }

                        if (filenameListArray[p, 0].Contains("m3" + Path.DirectorySeparatorChar) == false && m3open == true)
                        {
                            swr.WriteLine("    </m3-quality>");
                            m3open = false;
                            idcounter = 0;
                        }

                        //Module 4
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar) == true && m4open == false)
                        {
                            swr.WriteLine(" <m4-nonclinical-study-reports>");
                            m4open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar) == true
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "43-lit-ref") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4 Nonclinical Study Reports</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep") && m42open == false)
                        {
                            swr.WriteLine("     <m4-2-study-reports>");
                            m42open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep")
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2 Study Reports</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol") && m421open == false)
                        {
                            swr.WriteLine("         <m4-2-1-pharmacology>");
                            m421open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol")
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4211-prim-pd") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4212-sec-pd") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4213-safety-pharmacol") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4214-pd-drug-interact") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.1 Pharmacology</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4211-prim-pd") && m4211open == false)
                        {
                            swr.WriteLine("             <m4-2-1-1-primary-pharmacodynamics>");
                            m4211open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4211-prim-pd"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.1.1 Primary Pharmacodynamics</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4211-prim-pd") == false && m4211open == true)
                        {
                            swr.WriteLine("             </m4-2-1-1-primary-pharmacodynamics>");
                            m4211open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4212-sec-pd") && m4212open == false)
                        {
                            swr.WriteLine("             <m4-2-1-2-secondary-pharmacodynamics>");
                            m4212open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4212-sec-pd"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.1.2 Secondary Pharmacodynamics</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4212-sec-pd") == false && m4212open == true)
                        {
                            swr.WriteLine("             </m4-2-1-2-secondary-pharmacodynamics>");
                            m4212open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4213-safety-pharmacol") && m4213open == false)
                        {
                            swr.WriteLine("             <m4-2-1-3-safety-pharmacology>");
                            m4213open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4213-safety-pharmacol"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.1.3 Safety Pharmacology</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4213-safety-pharmacol") == false && m4213open == true)
                        {
                            swr.WriteLine("             </m4-2-1-3-safety-pharmacology>");
                            m4213open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4214-pd-drug-interact") && m4214open == false)
                        {
                            swr.WriteLine("             <m4-2-1-4-pharmacodynamic-drug-interactions>");
                            m4214open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4214-pd-drug-interact"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.1.4 Pharmacodynamic Drug Interactions</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol" + Path.DirectorySeparatorChar + "4214-pd-drug-interact") == false && m4214open == true)
                        {
                            swr.WriteLine("             </m4-2-1-4-pharmacodynamic-drug-interactions>");
                            m4214open = false;
                        }

                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "421-pharmacol") == false && m421open == true)
                        {
                            swr.WriteLine("         </m4-2-1-pharmacology>");
                            m421open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk") && m422open == false)
                        {
                            swr.WriteLine("         <m4-2-2-pharmacokinetics>");
                            m422open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk")
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4221-analyt-met-val") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4222-absorp") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4223-distrib") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4224-metab") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4225-excr") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4226-pk-drug-interact") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4227-other-pk-stud") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.2 Pharmacokinetics</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4221-analyt-met-val") && m4221open == false)
                        {
                            swr.WriteLine("         <m4-2-2-1-analytical-methods-and-validation-reports>");
                            m4221open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4221-analyt-met-val"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.2.1 Analytical Methods and Validation Reports</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4221-analyt-met-val") == false && m4221open == true)
                        {
                            swr.WriteLine("         </m4-2-2-1-analytical-methods-and-validation-reports>");
                            m4221open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4222-absorp") && m4222open == false)
                        {
                            swr.WriteLine("         <m4-2-2-2-absorption>");
                            m4222open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4222-absorp"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.2.2 Absorption</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4222-absorp") == false && m4222open == true)
                        {
                            swr.WriteLine("         </m4-2-2-2-absorption>");
                            m4222open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4223-distrib") && m4223open == false)
                        {
                            swr.WriteLine("         <m4-2-2-3-distribution>");
                            m4223open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4223-distrib"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.2.3 Distribution</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4223-distrib") == false && m4223open == true)
                        {
                            swr.WriteLine("         </m4-2-2-3-distribution>");
                            m4223open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4224-metab") && m4224open == false)
                        {
                            swr.WriteLine("         <m4-2-2-4-metabolism>");
                            m4224open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4224-metab"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.2.4 Metabolism</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4224-metab") == false && m4224open == true)
                        {
                            swr.WriteLine("         </m4-2-2-4-metabolism>");
                            m4224open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4225-excr") && m4225open == false)
                        {
                            swr.WriteLine("         <m4-2-2-5-excretion>");
                            m4225open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4225-excr"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.2.5 Excretion</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4225-excr") == false && m4225open == true)
                        {
                            swr.WriteLine("         </m4-2-2-5-excretion>");
                            m4225open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4226-pk-drug-interact") && m4226open == false)
                        {
                            swr.WriteLine("         <m4-2-2-6-pharmacokinetic-drug-interactions>");
                            m4226open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4226-pk-drug-interact"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.2.6 Pharmacokinetic Drug Interactions</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4226-pk-drug-interact") == false && m4226open == true)
                        {
                            swr.WriteLine("         </m4-2-2-6-pharmacokinetic-drug-interactions>");
                            m4226open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4227-other-pk-stud") && m4227open == false)
                        {
                            swr.WriteLine("         <m4-2-2-7-other-pharmacokinetic-studies>");
                            m4227open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4227-other-pk-stud"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.2.7 Other Pharmacokinetic Studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk" + Path.DirectorySeparatorChar + "4227-other-pk-stud") == false && m4227open == true)
                        {
                            swr.WriteLine("         </m4-2-2-7-other-pharmacokinetic-studies>");
                            m4227open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "422-pk") == false && m422open == true)
                        {
                            swr.WriteLine("         </m4-2-2-pharmacokinetics>");
                            m422open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox") && m423open == false)
                        {
                            swr.WriteLine("         <m4-2-3-toxicology>");
                            m423open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox")
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4231-single-dose-tox") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4232-repeat-dose-tox") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4236-loc-tol") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3 Toxicology</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4231-single-dose-tox") && m4231open == false)
                        {
                            swr.WriteLine("         <m4-2-3-1-single-dose-toxicity>");
                            m4231open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4231-single-dose-tox"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.1 Single-Dose Toxicity</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4231-single-dose-tox") == false && m4231open == true)
                        {
                            swr.WriteLine("         </m4-2-3-1-single-dose-toxicity>");
                            m4231open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4232-repeat-dose-tox") && m4232open == false)
                        {
                            swr.WriteLine("         <m4-2-3-2-repeat-dose-toxicity>");
                            m4232open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4232-repeat-dose-tox"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.2 Repeat-Dose Toxicity</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4232-repeat-dose-tox") == false && m4232open == true)
                        {
                            swr.WriteLine("         </m4-2-3-2-repeat-dose-toxicity>");
                            m4232open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox") && m4233open == false)
                        {
                            swr.WriteLine("         <m4-2-3-3-genotoxicity>");
                            m4233open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox")
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42331-in-vitro") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42332-in-vivo") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.3 Genotoxicity</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42331-in-vitro") && m42331open == false)
                        {
                            swr.WriteLine("         <m4-2-3-3-1-in-vitro>");
                            m42331open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42331-in-vitro"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.3.1 In vitro</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42331-in-vitro") == false && m42331open == true)
                        {
                            swr.WriteLine("         </m4-2-3-3-1-in-vitro>");
                            m42331open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42332-in-vivo") && m42332open == false)
                        {
                            swr.WriteLine("         <m4-2-3-3-2-in-vivo>");
                            m42332open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42332-in-vivo"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.3.2 In vivo</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox" + Path.DirectorySeparatorChar + "42332-in-vivo") == false && m42332open == true)
                        {
                            swr.WriteLine("         </m4-2-3-3-2-in-vivo>");
                            m42332open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4233-genotox") == false && m4233open == true)
                        {
                            swr.WriteLine("         </m4-2-3-3-genotoxicity>");
                            m4233open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen") && m4234open == false)
                        {
                            swr.WriteLine("			<m4-2-3-4-carcinogenicity>");
                            m4234open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen")
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42341-lt-stud") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42342-smt-stud") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42343-other-stud") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.4 Carcinogenicity</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42341-lt-stud") && m42341open == false)
                        {
                            swr.WriteLine("         <m4-2-3-4-1-long-term-studies>");
                            m42341open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42341-lt-stud"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.4.1 Long-term studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42341-lt-stud") == false && m42341open == true)
                        {
                            swr.WriteLine("         </m4-2-3-4-1-long-term-studies>");
                            m42341open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42342-smt-stud") && m42342open == false)
                        {
                            swr.WriteLine("         <m4-2-3-4-2-short-or-medium-term-studies>");
                            m42342open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42342-smt-stud"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.4.2 Short- or medium-term studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42342-smt-stud") == false && m42342open == true)
                        {
                            swr.WriteLine("         </m4-2-3-4-2-short-or-medium-term-studies>");
                            m42342open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42343-other-stud") && m42343open == false)
                        {
                            swr.WriteLine("         <m4-2-3-4-3-other-studies>");
                            m42343open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42343-other-stud"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.4.3 Other studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen" + Path.DirectorySeparatorChar + "42343-other-stud") == false && m42343open == true)
                        {
                            swr.WriteLine("         </m4-2-3-4-3-other-studies>");
                            m42343open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4234-carcigen") == false && m4234open == true)
                        {
                            swr.WriteLine("			</m4-2-3-4-carcinogenicity>");
                            m4234open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox") && m4235open == false)
                        {
                            swr.WriteLine("			<m4-2-3-5-reproductive-and-developmental-toxicity>");
                            m4235open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox")
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42351-fert-embryo-dev") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42352-embryo-fetal-dev") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42353-pre-postnatal-dev") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42354-juv") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.5 Reproductive and Developmental Toxicity</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42351-fert-embryo-dev") && m42351open == false)
                        {
                            swr.WriteLine("         <m4-2-3-5-1-fertility-and-early-embryonic-development>");
                            m42351open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42351-fert-embryo-dev"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.5.1 Fertility and early embryonic development</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42351-fert-embryo-dev") == false && m42351open == true)
                        {
                            swr.WriteLine("         </m4-2-3-5-1-fertility-and-early-embryonic-development>");
                            m42351open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42352-embryo-fetal-dev") && m42352open == false)
                        {
                            swr.WriteLine("         <m4-2-3-5-2-embryo-fetal-development>");
                            m42352open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42352-embryo-fetal-dev"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.5.2 Embryo-fetal development</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42352-embryo-fetal-dev") == false && m42352open == true)
                        {
                            swr.WriteLine("         </m4-2-3-5-2-embryo-fetal-development>");
                            m42352open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42353-pre-postnatal-dev") && m42353open == false)
                        {
                            swr.WriteLine("         <m4-2-3-5-3-prenatal-and-postnatal-development-including-maternal-function>");
                            m42353open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42353-pre-postnatal-dev"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.5.3 Prenatal and postnatal development, including maternal function</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42353-pre-postnatal-dev") == false && m42353open == true)
                        {
                            swr.WriteLine("         </m4-2-3-5-3-prenatal-and-postnatal-development-including-maternal-function>");
                            m42353open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42354-juv") && m42354open == false)
                        {
                            swr.WriteLine("         <m4-2-3-5-4-studies-in-which-the-offspring-juvenile-animals-are-dosed-and-or-further-evaluated>");
                            m42354open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42354-juv"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.5.4 Studies in which the offspring (juvenile animals) are dosed and/or further evaluated</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox" + Path.DirectorySeparatorChar + "42354-juv") == false && m42354open == true)
                        {
                            swr.WriteLine("         </m4-2-3-5-4-studies-in-which-the-offspring-juvenile-animals-are-dosed-and-or-further-evaluated>");
                            m42354open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4235-repro-dev-tox") == false && m4235open == true)
                        {
                            swr.WriteLine("			</m4-2-3-5-reproductive-and-developmental-toxicity>");
                            m4235open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4236-loc-tol") && m4236open == false)
                        {
                            swr.WriteLine("         <m4-2-3-6-local-tolerance>");
                            m4236open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4236-loc-tol"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.6 Local Tolerance</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4236-loc-tol") == false && m4236open == true)
                        {
                            swr.WriteLine("         </m4-2-3-6-local-tolerance>");
                            m4236open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud") && m4237open == false)
                        {
                            swr.WriteLine("			<m4-2-3-7-other-toxicity-studies>");
                            m4237open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud")
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42371-antigen") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42372-immunotox") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42373-mechan-stud") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42374-dep") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42375-metab") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42376-imp") == false
                            && filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42377-other") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.7 Other Toxicity Studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42371-antigen") && m42371open == false)
                        {
                            swr.WriteLine("         <m4-2-3-7-1-antigenicity>");
                            m42371open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42371-antigen"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.7.1 Antigenicity</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42371-antigen") == false && m42371open == true)
                        {
                            swr.WriteLine("         </m4-2-3-7-1-antigenicity>");
                            m42371open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42372-immunotox") && m42372open == false)
                        {
                            swr.WriteLine("         <m4-2-3-7-2-immunotoxicity>");
                            m42372open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42372-immunotox"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.7.2 Immunotoxicity</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42372-immunotox") == false && m42372open == true)
                        {
                            swr.WriteLine("         </m4-2-3-7-2-immunotoxicity>");
                            m42372open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42373-mechan-stud") && m42373open == false)
                        {
                            swr.WriteLine("         <m4-2-3-7-3-mechanistic-studies>");
                            m42373open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42373-mechan-stud"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.7.3 Mechanistic studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42373-mechan-stud") == false && m42373open == true)
                        {
                            swr.WriteLine("         </m4-2-3-7-3-mechanistic-studies>");
                            m42373open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42374-dep") && m42374open == false)
                        {
                            swr.WriteLine("         <m4-2-3-7-4-dependence>");
                            m42374open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42374-dep"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.7.4 Dependence</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42374-dep") == false && m42374open == true)
                        {
                            swr.WriteLine("         </m4-2-3-7-4-dependence>");
                            m42374open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42375-metab") && m42375open == false)
                        {
                            swr.WriteLine("         <m4-2-3-7-5-metabolites>");
                            m42375open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42375-metab"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.7.5 Metabolites</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42375-metab") == false && m42375open == true)
                        {
                            swr.WriteLine("         </m4-2-3-7-5-metabolites>");
                            m42375open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42376-imp") && m42376open == false)
                        {
                            swr.WriteLine("         <m4-2-3-7-6-impurities>");
                            m42376open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42376-imp"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.7.6 Impurities</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42376-imp") == false && m42376open == true)
                        {
                            swr.WriteLine("         </m4-2-3-7-6-impurities>");
                            m42376open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42377-other") && m42377open == false)
                        {
                            swr.WriteLine("         <m4-2-3-7-7-other>");
                            m42377open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42377-other"))
                        {
                            swr.WriteLine("         <leaf ID=\"m4-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>4.2.3.7.7 Other</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud" + Path.DirectorySeparatorChar + "42377-other") == false && m42377open == true)
                        {
                            swr.WriteLine("         </m4-2-3-7-7-other>");
                            m42377open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox" + Path.DirectorySeparatorChar + "4237-other-tox-stud") == false && m4237open == true)
                        {
                            swr.WriteLine("			</m4-2-3-7-other-toxicity-studies>");
                            m4237open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep" + Path.DirectorySeparatorChar + "423-tox") == false && m423open == true)
                        {
                            swr.WriteLine("         </m4-2-3-toxicology>");
                            m423open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "42-stud-rep") == false && m42open == true)
                        {
                            swr.WriteLine("     </m4-2-study-reports>");
                            m42open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "43-lit-ref") && m43open == false)
                        {
                            swr.WriteLine("     <m4-3-literature-references>");
                            m43open = true;
                            idcounter = 1;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "43-lit-ref"))
                        {
                            swr.WriteLine("     <leaf ID=\"m43-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>4.3 Literature Reference - {0}</title>", filenameListArray[p, 0].Substring(filenameListArray[p, 0].LastIndexOf(Path.DirectorySeparatorChar) + 1, (filenameListArray[p, 0].Length - (filenameListArray[p, 0].LastIndexOf(Path.DirectorySeparatorChar) + 5))));
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar + "43-lit-ref") == false && m43open == true)
                        {
                            swr.WriteLine("     </m4-3-literature-references>");
                            m43open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m4" + Path.DirectorySeparatorChar) == false && m4open == true)
                        {
                            swr.WriteLine(" </m4-nonclinical-study-reports>");
                            m4open = false;
                        }

                        //Module 5
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar) == true && m5open == false)
                        {
                            swr.WriteLine(" <m5-clinical-study-reports>");
                            m5open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "52-tab-list") && m52open == false)
                        {
                            swr.WriteLine("     <m5-2-tabular-listing-of-all-clinical-studies>");
                            m52open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "52-tab-list"))
                        {
                            swr.WriteLine("         <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>5.2 Tabular Listing of all Clinical Studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "52-tab-list") == false && m52open == true)
                        {
                            swr.WriteLine("     </m5-2-tabular-listing-of-all-clinical-studies>");
                            m52open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep") && m53open == false)
                        {
                            swr.WriteLine("     <m5-3-clinical-study-reports>");
                            m53open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "531-rep-biopharm-stud") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "533-rep-human-pk-stud") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "534-rep-human-pd-stud") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "535-rep-effic-safety-stud") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "536-postmark-exp") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "537-crf-ipl") == false)
                        {
                            swr.WriteLine("         <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>5.3 Clinical Study Reports</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud") && m531open == false)
                        {
                            swr.WriteLine("     <m5-3-1-reports-of-biopharmaceutic-studies>");
                            m531open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5311-ba-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5312-compar-ba-be-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5313-in-vitro-in-vivo-corr-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5314-bioanalyt-analyt-met") == false
                            )
                        {
                            swr.WriteLine("         <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>5.3.1 Reports of Biopharmaceutic Studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5311-ba-stud-rep") && m5311open == false)
                        {
                            swr.WriteLine("     <m5-3-1-1-bioavailability-study-reports>");
                            m5311open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5311-ba-stud-rep"))
                        {
                            swr.WriteLine("         <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>5.3.1.1 Bioavailability (BA) Study Reports</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5311-ba-stud-rep") == false && m5311open == true)
                        {
                            swr.WriteLine("     </m5-3-1-1-bioavailability-study-reports>");
                            m5311open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5312-compar-ba-be-stud-rep") && m5312open == false)
                        {
                            swr.WriteLine("     <m5-3-1-2-comparative-ba-and-bioequivalence-study-reports>");
                            m5312open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5312-compar-ba-be-stud-rep"))
                        {
                            swr.WriteLine("         <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>5.3.1.2 Comparative BA and Bioequivalence (BE) Study Reports</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5312-compar-ba-be-stud-rep") == false && m5312open == true)
                        {
                            swr.WriteLine("     </m5-3-1-2-comparative-ba-and-bioequivalence-study-reports>");
                            m5312open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5313-in-vitro-in-vivo-corr-stud-rep") && m5313open == false)
                        {
                            swr.WriteLine("     <m5-3-1-3-in-vitro-in-vivo-correlation-study-reports>");
                            m5313open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5313-in-vitro-in-vivo-corr-stud-rep"))
                        {
                            swr.WriteLine("         <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>5.3.1.3 In vitro - In vivo Correlation Study Reports</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5313-in-vitro-in-vivo-corr-stud-rep") == false && m5313open == true)
                        {
                            swr.WriteLine("     </m5-3-1-3-in-vitro-in-vivo-correlation-study-reports>");
                            m5313open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5314-bioanalyt-analyt-met") && m5314open == false)
                        {
                            swr.WriteLine("     <m5-3-1-4-reports-of-bioanalytical-and-analytical-methods-for-human-studies>");
                            m5314open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5314-bioanalyt-analyt-met"))
                        {
                            swr.WriteLine("         <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("             checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("             modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("             xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("             <title>5.3.1.4 Reports of Bioanalytical and Analytical Methods for Human Studies</title>");
                            swr.WriteLine("          </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud" + Path.DirectorySeparatorChar + "5314-bioanalyt-analyt-met") == false && m5314open == true)
                        {
                            swr.WriteLine("     </m5-3-1-4-reports-of-bioanalytical-and-analytical-methods-for-human-studies>");
                            m5314open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "531-rep-biopharm-stud") == false && m531open == true)
                        {
                            swr.WriteLine("     </m5-3-1-reports-of-biopharmaceutic-studies>");
                            m531open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat") && m532open == false)
                        {
                            swr.WriteLine("     <m5-3-2-reports-of-studies-pertinent-to-pharmacokinetics-using-human-biomaterials>");
                            m532open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5321-plasma-prot-bind-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5322-rep-hep-metab-interact-stud") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5323-stud-other-human-biomat") == false)
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.2 Reports of Studies Pertinent to Pharmacokinetics using Human Biomaterials</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5321-plasma-prot-bind-stud-rep") && m5321open == false)
                        {
                            swr.WriteLine("     <m5-3-2-1-plasma-protein-binding-study-reports>");
                            m5321open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5321-plasma-prot-bind-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.2.1 Plasma Protein Binding Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5321-plasma-prot-bind-stud-rep") == false && m5321open == true)
                        {
                            swr.WriteLine("     </m5-3-2-1-plasma-protein-binding-study-reports>");
                            m5321open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5322-rep-hep-metab-interact-stud") && m5322open == false)
                        {
                            swr.WriteLine("     <m5-3-2-2-reports-of-hepatic-metabolism-and-drug-interaction-studies>");
                            m5322open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5322-rep-hep-metab-interact-stud"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.2.2 Reports of Hepatic Metabolism and Drug Interaction Studies</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5322-rep-hep-metab-interact-stud") == false && m5322open == true)
                        {
                            swr.WriteLine("     </m5-3-2-2-reports-of-hepatic-metabolism-and-drug-interaction-studies>");
                            m5322open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5323-stud-other-human-biomat") && m5323open == false)
                        {
                            swr.WriteLine("     <m5-3-2-3-reports-of-studies-using-other-human-biomaterials>");
                            m5323open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5323-stud-other-human-biomat"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.2.3 Reports of Studies Using Other Human Biomaterials</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat" + Path.DirectorySeparatorChar + "5323-stud-other-human-biomat") == false && m5323open == true)
                        {
                            swr.WriteLine("     </m5-3-2-3-reports-of-studies-using-other-human-biomaterials>");
                            m5323open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "532-rep-stud-pk-human-biomat") == false && m532open == true)
                        {
                            swr.WriteLine("     </m5-3-2-reports-of-studies-pertinent-to-pharmacokinetics-using-human-biomaterials>");
                            m532open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud") && m533open == false)
                        {
                            swr.WriteLine("     <m5-3-3-reports-of-human-pharmacokinetics-pk-studies>");
                            m533open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5331-healthy-subj-pk-init-tol-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5332-patient-pk-init-tol-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5333-intrin-factor-pk-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5334-extrin-factor-pk-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5335-popul-pk-stud-rep") == false)
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.3 Reports of Human Pharmacokinetic (PK) Studies</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5331-healthy-subj-pk-init-tol-stud-rep") && m5331open == false)
                        {
                            swr.WriteLine("     <m5-3-3-1-healthy-subject-pk-and-initial-tolerability-study-reports>");
                            m5331open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5331-healthy-subj-pk-init-tol-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.3.1 Healthy Subject PK and Initial Tolerability Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5331-healthy-subj-pk-init-tol-stud-rep") == false && m5331open == true)
                        {
                            swr.WriteLine("     </m5-3-3-1-healthy-subject-pk-and-initial-tolerability-study-reports>");
                            m5331open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5332-patient-pk-init-tol-stud-rep") && m5332open == false)
                        {
                            swr.WriteLine("     <m5-3-3-2-patient-pk-and-initial-tolerability-study-reports>");
                            m5332open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5332-patient-pk-init-tol-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.3.2 Patient PK and Initial Tolerability Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5332-patient-pk-init-tol-stud-rep") == false && m5332open == true)
                        {
                            swr.WriteLine("     </m5-3-3-2-patient-pk-and-initial-tolerability-study-reports>");
                            m5332open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5333-intrin-factor-pk-stud-rep") && m5333open == false)
                        {
                            swr.WriteLine("     <m5-3-3-3-intrinsic-factor-pk-study-reports>");
                            m5333open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5333-intrin-factor-pk-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.3.3 Intrinsic Factor PK Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5333-intrin-factor-pk-stud-rep") == false && m5333open == true)
                        {
                            swr.WriteLine("     </m5-3-3-3-intrinsic-factor-pk-study-reports>");
                            m5333open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5334-extrin-factor-pk-stud-rep") && m5334open == false)
                        {
                            swr.WriteLine("     <m5-3-3-4-extrinsic-factor-pk-study-reports>");
                            m5334open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5334-extrin-factor-pk-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.3.4 Extrinsic Factor PK Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5334-extrin-factor-pk-stud-rep") == false && m5334open == true)
                        {
                            swr.WriteLine("     </m5-3-3-4-extrinsic-factor-pk-study-reports>");
                            m5334open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5335-popul-pk-stud-rep") && m5335open == false)
                        {
                            swr.WriteLine("     <m5-3-3-5-population-pk-study-reports>");
                            m5335open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5335-popul-pk-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.3.5 Population PK Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud" + Path.DirectorySeparatorChar + "5335-popul-pk-stud-rep") == false && m5335open == true)
                        {
                            swr.WriteLine("     </m5-3-3-5-population-pk-study-reports>");
                            m5335open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "533-rep-human-pk-stud") == false && m533open == true)
                        {
                            swr.WriteLine("     </m5-3-3-reports-of-human-pharmacokinetics-pk-studies>");
                            m533open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud") && m534open == false)
                        {
                            swr.WriteLine("     <m5-3-4-reports-of-human-pharmacodynamics-pd-studies>");
                            m534open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5341-healthy-subj-pd-stud-rep") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5342-patient-pd-stud-rep") == false)
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.4 Reports of Human Pharmacodynamic (PD) Studies</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5341-healthy-subj-pd-stud-rep") && m5341open == false)
                        {
                            swr.WriteLine("     <m5-3-4-1-healthy-subject-pd-and-pk-pd-study-reports>");
                            m5341open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5341-healthy-subj-pd-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.4.1 Healthy Subject PD and PK/PD Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5341-healthy-subj-pd-stud-rep") == false && m5341open == true)
                        {
                            swr.WriteLine("     </m5-3-4-1-healthy-subject-pd-and-pk-pd-study-reports>");
                            m5341open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5342-patient-pd-stud-rep") && m5342open == false)
                        {
                            swr.WriteLine("     <m5-3-4-2-patient-pd-and-pk-pd-study-reports>");
                            m5342open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5342-patient-pd-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.4.2 Patient PD and PK/PD Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud" + Path.DirectorySeparatorChar + "5342-patient-pd-stud-rep") == false && m5342open == true)
                        {
                            swr.WriteLine("     </m5-3-4-2-patient-pd-and-pk-pd-study-reports>");
                            m5342open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "534-rep-human-pd-stud") == false && m534open == true)
                        {
                            swr.WriteLine("     </m5-3-4-reports-of-human-pharmacodynamics-pd-studies>");
                            m534open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud") && m535open == false)
                        {
                            charindex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "535-rep-effic-safety-stud");
                            startposition = charindex + 27;
                            endposition = filenameListArray[p, 0].Length - startposition;
                            indication = filenameListArray[p, 0].Substring(startposition, endposition);
                            charindex = indication.IndexOf(Path.DirectorySeparatorChar);
                            indication = indication.Substring(0, charindex);
                            swr.WriteLine("     <m5-3-5-reports-of-efficacy-and-safety-studies indication=\"{0}\">", indication);
                            m535open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud") && m535open == true)
                        {
                            charindex = filenameListArray[p, 0].IndexOf(Path.DirectorySeparatorChar + "535-rep-effic-safety-stud");
                            startposition = charindex + 27;
                            endposition = filenameListArray[p, 0].Length - startposition;
                            indication1 = filenameListArray[p, 0].Substring(startposition, endposition);
                            charindex = indication1.IndexOf(Path.DirectorySeparatorChar);
                            indication1 = indication1.Substring(0, charindex);
                            if (string.Equals(indication, indication1) == false)
                            {
                                if (m5351open)
                                {
                                    swr.WriteLine("     </m5-3-5-1-study-reports-of-controlled-clinical-studies-pertinent-to-the-claimed-indication>");
                                    m5351open = false;
                                }
                                if (m5352open)
                                {
                                    swr.WriteLine("     </m5-3-5-2-study-reports-of-uncontrolled-clinical-studies>");
                                    m5352open = false;
                                }
                                if (m5353open)
                                {
                                    swr.WriteLine("     </m5-3-5-3-reports-of-analyses-of-data-from-more-than-one-study>");
                                    m5353open = false;
                                }
                                if (m5354open)
                                {
                                    swr.WriteLine("     </m5-3-5-4-other-study-reports>");
                                    m5354open = false;
                                }
                                swr.WriteLine("     </m5-3-5-reports-of-efficacy-and-safety-studies>");
                                swr.WriteLine("     <m5-3-5-reports-of-efficacy-and-safety-studies indication=\"{0}\">", indication1);
                                indication = indication1;
                            }
                        }

                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud")
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5351-stud-rep-contr") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5352-stud-rep-uncontr") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5353-rep-analys-data-more-one-stud") == false
                            && filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5354-other-stud-rep") == false)
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.5 Reports of Efficacy and Safety Studies</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5351-stud-rep-contr") && m5351open == false)
                        {
                            swr.WriteLine("     <m5-3-5-1-study-reports-of-controlled-clinical-studies-pertinent-to-the-claimed-indication>");
                            m5351open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5351-stud-rep-contr"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.5.1 Study Reports of Controlled Clinical Studies Pertinent to the Claimed Indication</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5351-stud-rep-contr") == false && m5351open == true)
                        {
                            swr.WriteLine("     </m5-3-5-1-study-reports-of-controlled-clinical-studies-pertinent-to-the-claimed-indication>");
                            m5351open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5352-stud-rep-uncontr") && m5352open == false)
                        {
                            swr.WriteLine("     <m5-3-5-2-study-reports-of-uncontrolled-clinical-studies>");
                            m5352open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5352-stud-rep-uncontr"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.5.2 Study Reports of Uncontrolled Clinical Studies</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5352-stud-rep-uncontr") == false && m5352open == true)
                        {
                            swr.WriteLine("     </m5-3-5-2-study-reports-of-uncontrolled-clinical-studies>");
                            m5352open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5353-rep-analys-data-more-one-stud") && m5353open == false)
                        {
                            swr.WriteLine("     <m5-3-5-3-reports-of-analyses-of-data-from-more-than-one-study>");
                            m5353open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5353-rep-analys-data-more-one-stud"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.5.3 Reports of Analyses of Data from More than One Study</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5353-rep-analys-data-more-one-stud") == false && m5353open == true)
                        {
                            swr.WriteLine("     </m5-3-5-3-reports-of-analyses-of-data-from-more-than-one-study>");
                            m5353open = false;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5354-other-stud-rep") && m5354open == false)
                        {
                            swr.WriteLine("     <m5-3-5-4-other-study-reports>");
                            m5354open = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5354-other-stud-rep"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.5.4 Other Study Reports</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains(Path.DirectorySeparatorChar + "5354-other-stud-rep") == false && m5354open == true)
                        {
                            swr.WriteLine("     </m5-3-5-4-other-study-reports>");
                            m5354open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "535-rep-effic-safety-stud") == false && m535open == true)
                        {
                            swr.WriteLine("     </m5-3-5-reports-of-efficacy-and-safety-studies>");
                            m535open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "536-postmark-exp") && m536open == false)
                        {
                            swr.WriteLine("     <m5-3-6-reports-of-postmarketing-experience>");
                            m536open = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "536-postmark-exp"))
                        {
                            swr.WriteLine("     <leaf ID=\"m5-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.6 Reports of Postmarketing Experience</title>");
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "536-postmark-exp") == false && m536open == true)
                        {
                            swr.WriteLine("     </m5-3-6-reports-of-postmarketing-experience>");
                            m536open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "537-crf-ipl") && m537open == false)
                        {
                            swr.WriteLine("     <m5-3-7-case-report-forms-and-individual-patient-listings>");
                            m537open = true;
                            idcounter = 1;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "537-crf-ipl"))
                        {
                            swr.WriteLine("     <leaf ID=\"m537-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.3.7 Case Report Forms and Individual Patient Listings - {0}</title>", idcounter.ToString());
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep" + Path.DirectorySeparatorChar + "537-crf-ipl") == false && m537open == true)
                        {
                            swr.WriteLine("     </m5-3-7-case-report-forms-and-individual-patient-listings>");
                            m537open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "53-clin-stud-rep") == false && m53open == true)
                        {
                            swr.WriteLine("     </m5-3-clinical-study-reports>");
                            m53open = false;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "54-lit-ref") && m54open == false)
                        {
                            swr.WriteLine("     <m5-4-literature-references>");
                            m54open = true;
                            idcounter = 1;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "54-lit-ref"))
                        {
                            swr.WriteLine("     <leaf ID=\"m54-{0}\" operation=\"{1}\" checksum-type=\"md5\"", idcounter, filenameListArray[p, 3]);
                            swr.WriteLine("         checksum=\"{0}\"", filenameListArray[p, 2]);
                            swr.WriteLine("         modified-file=\"{0}\"", filenameListArray[p, 4]);
                            swr.WriteLine("         xlink:href=\"{0}\">", filenameListArray[p, 1]);
                            swr.WriteLine("         <title>5.4 Literature Reference - {0}</title>", filenameListArray[p, 0].Substring(filenameListArray[p, 0].LastIndexOf(Path.DirectorySeparatorChar) + 1, (filenameListArray[p, 0].Length - (filenameListArray[p, 0].LastIndexOf(Path.DirectorySeparatorChar) + 5))));
                            swr.WriteLine("     </leaf>");
                            idcounter++; indexed = true;
                        }
                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar + "54-lit-ref") == false && m54open == true)
                        {
                            swr.WriteLine("     </m5-4-literature-references>");
                            m54open = false;
                        }

                        if (filenameListArray[p, 0].Contains("m5" + Path.DirectorySeparatorChar) == false && m5open == true)
                        {
                            swr.WriteLine(" </m5-clinical-study-reports>");
                            m5open = false;
                        }
                        if (indexed == false && filenameListArray[p, 0].Contains("m1" + Path.DirectorySeparatorChar + "eu") == false && filenameListArray[p, 0].Contains("util" + Path.DirectorySeparatorChar) == false)
                        {
                            unIndexed[n] = filenameListArray[p, 1];
                            n++;
                        }
                        indexed = false;
                    }
                    //end of index.xml
                    swr.WriteLine("</ectd:ectd>");
                    swr.Close();
                    textBoxMD5.Text = xmlIndexOutput;

                    //call m2m5sort method in XMLsort class to order elements correctly
                    //i.e. change from alphabetical order to CTD, where these are different
                    XMLsort sortingHat = new XMLsort();
                    sortingHat.m2m5sort(xmlIndexOutput);

                    if (n > 0)
                    {
                        string finishedMessage = "Number of files (outside \"m1/eu\" and \"util\" folders) not indexed: " + n.ToString() + " List files?";
                        DialogResult resultUnindexed;
                        resultUnindexed = MessageBox.Show(xmlIndexOutput + "\n" + "\n" + finishedMessage, "indexing completed", MessageBoxButtons.YesNo);
                        if (resultUnindexed == DialogResult.Yes)
                        {
                            string listOfUnIndexed = "";
                            for (int m = 0; m <= n; m++)
                            {
                                listOfUnIndexed = listOfUnIndexed + unIndexed[m] + "\n";
                            }
                            MessageBox.Show(listOfUnIndexed);
                        }
                    }

                    DialogResult result;
                    result = MessageBox.Show(xmlIndexOutput + "\n Open file?", "Module 2-5 indexing completed", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(xmlIndexOutput);
                    }
                }

                catch (Exception g)
                {
                    MessageBox.Show(g.ToString(), "The process failed");
                }
            }
        }

        private void btDeleteEmptyDirectories_Click(object sender, EventArgs e)
        {            
            string sequencePath = textBoxSeqDir.Text;
            
            DialogResult result;
            result = MessageBox.Show("Press OK to delete all empty directories under " + sequencePath, "Confirm delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {

                int numberOfDirs = DirCounter(sequencePath);

                string[] dirListArray; //list of all directories in sequence
                dirListArray = new string[numberOfDirs];

                //initialise initalArray
                for (int i = 0; i < dirListArray.Length; i++)
                {
                    dirListArray[i] = "0";
                }

                //pass root directory to dirLister
                directories dir = new directories();
                dirListArray = dir.dirLister(sequencePath, 0, dirListArray);

                //order dirListArray alphabetically (to correct for webfolders), then reverse it
                Array.Sort(dirListArray);
                Array.Reverse(dirListArray);

                //pass reversed dirListArray to directoryDeleter
                directoryDeleter dirDel = new directoryDeleter();
                for (int p = 1; p < dirListArray.Length; p++)
                {
                    dirDel.dirDeleter(dirListArray[p]);
				} 
            }
        }

        /// <summary>
        /// User can select the path to sequence directory (e.g. 0000)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxSeqDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxMD5.Text = openFileDialog1.FileName;
        }

        private void btCreateFolderTree_Click(object sender, EventArgs e)
        {
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

            string sourceFile = "";            
            DirectoryInfo rootDirectory = new DirectoryInfo(textBoxSeqDir.Text);
            rootDirectory.CreateSubdirectory("m1");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"10-cover");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"10-cover"+Path.DirectorySeparatorChar+"common");            
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "10-cover" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"12-form");            
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"12-form"+Path.DirectorySeparatorChar+"common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "12-form" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"131-spclabelpl");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"131-spclabelpl"+Path.DirectorySeparatorChar+"common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "131-spclabelpl" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"132-mockup");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"132-mockup"+Path.DirectorySeparatorChar+"common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "132-mockup" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"133-specimen");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"133-specimen"+Path.DirectorySeparatorChar+"common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "133-specimen" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"134-consultation");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"134-consultation"+Path.DirectorySeparatorChar+"common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "134-consultation" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"135-approved");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"135-approved"+Path.DirectorySeparatorChar+"common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "13-pi" + Path.DirectorySeparatorChar + "135-approved" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"13-pi"+Path.DirectorySeparatorChar+"136-braille");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"14-expert");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"14-expert"+Path.DirectorySeparatorChar+"141-quality");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"14-expert"+Path.DirectorySeparatorChar+"142-nonclinical");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"14-expert"+Path.DirectorySeparatorChar+"143-clinical");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"15-specific");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"15-specific"+Path.DirectorySeparatorChar+"151-bibliographic");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"15-specific"+Path.DirectorySeparatorChar+"152-generic-hybrid-bio-similar");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"15-specific"+Path.DirectorySeparatorChar+"153-data-market-exclusivity");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"15-specific"+Path.DirectorySeparatorChar+"154-exceptional");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"15-specific"+Path.DirectorySeparatorChar+"155-conditional-ma");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"16-environrisk");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"16-environrisk"+Path.DirectorySeparatorChar+"161-nongmo");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"16-environrisk"+Path.DirectorySeparatorChar+"162-gmo");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"17-orphan");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"17-orphan"+Path.DirectorySeparatorChar+"171-similarity");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"17-orphan"+Path.DirectorySeparatorChar+"172-market-exclusivity");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"18-pharmacovigilance");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"18-pharmacovigilance"+Path.DirectorySeparatorChar+"181-phvig-system");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"18-pharmacovigilance"+Path.DirectorySeparatorChar+"182-riskmgt-system");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"19-clinical-trials");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"110-paediatrics");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"responses");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"responses"+Path.DirectorySeparatorChar+"common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "responses" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"additional-data");
            rootDirectory.CreateSubdirectory("m1"+Path.DirectorySeparatorChar+"eu"+Path.DirectorySeparatorChar+"additional-data"+Path.DirectorySeparatorChar+"common");
            if (memberStateList.Count > 0)
            {
                foreach (string memberState in memberStateList)
                {
                    rootDirectory.CreateSubdirectory("m1" + Path.DirectorySeparatorChar + "eu" + Path.DirectorySeparatorChar + "additional-data" + Path.DirectorySeparatorChar + memberState);
                }
            }

            rootDirectory.CreateSubdirectory("m2");
            rootDirectory.CreateSubdirectory("m2"+Path.DirectorySeparatorChar+"22-intro");
            rootDirectory.CreateSubdirectory("m2"+Path.DirectorySeparatorChar+"23-qos");
            rootDirectory.CreateSubdirectory("m2"+Path.DirectorySeparatorChar+"24-nonclin-over");
            rootDirectory.CreateSubdirectory("m2"+Path.DirectorySeparatorChar+"25-clin-over");
            rootDirectory.CreateSubdirectory("m2"+Path.DirectorySeparatorChar+"26-nonclin-sum");
            rootDirectory.CreateSubdirectory("m2"+Path.DirectorySeparatorChar+"27-clin-sum");
            rootDirectory.CreateSubdirectory("m3");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s1-gen-info");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s2-manuf");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s3-charac");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s4-contr-drug-sub");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s4-contr-drug-sub"+Path.DirectorySeparatorChar+"32s41-spec");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s4-contr-drug-sub"+Path.DirectorySeparatorChar+"32s42-analyt-proc");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s4-contr-drug-sub"+Path.DirectorySeparatorChar+"32s43-val-analyt-proc");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s4-contr-drug-sub"+Path.DirectorySeparatorChar+"32s44-batch-analys");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s4-contr-drug-sub"+Path.DirectorySeparatorChar+"32s45-justif-spec");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s5-ref-stand");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s6-cont-closure-sys");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32s-drug-sub"+Path.DirectorySeparatorChar+"substance-1-manufacturer-1"+Path.DirectorySeparatorChar+"32s7-stab");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p1-desc-comp");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p2-pharm-dev");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p3-manuf");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p4-contr-excip");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p4-contr-excip"+Path.DirectorySeparatorChar+"excipient-1");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p5-contr-drug-prod");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p5-contr-drug-prod"+Path.DirectorySeparatorChar+"32p51-spec");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p5-contr-drug-prod"+Path.DirectorySeparatorChar+"32p52-analyt-proc");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p5-contr-drug-prod"+Path.DirectorySeparatorChar+"32p53-val-analyt-proc");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p5-contr-drug-prod"+Path.DirectorySeparatorChar+"32p54-batch-analys");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p5-contr-drug-prod"+Path.DirectorySeparatorChar+"32p55-charac-imp");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p5-contr-drug-prod"+Path.DirectorySeparatorChar+"32p56-justif-spec");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p6-ref-stand");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p7-cont-closure-sys");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32p-drug-prod"+Path.DirectorySeparatorChar+"product-1"+Path.DirectorySeparatorChar+"32p8-stab");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32a-app");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32a-app"+Path.DirectorySeparatorChar+"32a1-fac-equip");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32a-app"+Path.DirectorySeparatorChar+"32a2-advent-agent");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32a-app"+Path.DirectorySeparatorChar+"32a3-excip-name-1");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"32-body-data"+Path.DirectorySeparatorChar+"32r-reg-info");
            rootDirectory.CreateSubdirectory("m3"+Path.DirectorySeparatorChar+"33-lit-ref");
            rootDirectory.CreateSubdirectory("m4");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"421-pharmacol");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"421-pharmacol"+Path.DirectorySeparatorChar+"4211-prim-pd");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"421-pharmacol"+Path.DirectorySeparatorChar+"4212-sec-pd");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"421-pharmacol"+Path.DirectorySeparatorChar+"4213-safety-pharmacol");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"421-pharmacol"+Path.DirectorySeparatorChar+"4214-pd-drug-interact");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"422-pk");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"422-pk"+Path.DirectorySeparatorChar+"4221-analyt-met-val");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"422-pk"+Path.DirectorySeparatorChar+"4222-absorp");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"422-pk"+Path.DirectorySeparatorChar+"4223-distrib");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"422-pk"+Path.DirectorySeparatorChar+"4224-metab");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"422-pk"+Path.DirectorySeparatorChar+"4225-excr");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"422-pk"+Path.DirectorySeparatorChar+"4226-pk-drug-interact");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"422-pk"+Path.DirectorySeparatorChar+"4227-other-pk-stud");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4231-single-dose-tox");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4232-repeat-dose-tox");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4233-genotox");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4233-genotox"+Path.DirectorySeparatorChar+"42331-in-vitro");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4233-genotox"+Path.DirectorySeparatorChar+"42332-in-vivo");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4234-carcigen");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4234-carcigen"+Path.DirectorySeparatorChar+"42341-lt-stud");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4234-carcigen"+Path.DirectorySeparatorChar+"42342-smt-stud");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4234-carcigen"+Path.DirectorySeparatorChar+"42343-other-stud");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4235-repro-dev-tox");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4235-repro-dev-tox"+Path.DirectorySeparatorChar+"42351-fert-embryo-dev");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4235-repro-dev-tox"+Path.DirectorySeparatorChar+"42352-embryo-fetal-dev");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4235-repro-dev-tox"+Path.DirectorySeparatorChar+"42353-pre-postnatal-dev");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4235-repro-dev-tox"+Path.DirectorySeparatorChar+"42354-juv");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4236-loc-tol");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4237-other-tox-stud");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4237-other-tox-stud"+Path.DirectorySeparatorChar+"42371-antigen");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4237-other-tox-stud"+Path.DirectorySeparatorChar+"42372-immunotox");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4237-other-tox-stud"+Path.DirectorySeparatorChar+"42373-mechan-stud");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4237-other-tox-stud"+Path.DirectorySeparatorChar+"42374-dep");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4237-other-tox-stud"+Path.DirectorySeparatorChar+"42375-metab");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4237-other-tox-stud"+Path.DirectorySeparatorChar+"42376-imp");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"42-stud-rep"+Path.DirectorySeparatorChar+"423-tox"+Path.DirectorySeparatorChar+"4237-other-tox-stud"+Path.DirectorySeparatorChar+"42377-other");
            rootDirectory.CreateSubdirectory("m4"+Path.DirectorySeparatorChar+"43-lit-ref");
            rootDirectory.CreateSubdirectory("m5");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"52-tab-list");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5311-ba-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5311-ba-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5311-ba-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5311-ba-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5312-compar-ba-be-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5312-compar-ba-be-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5312-compar-ba-be-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5312-compar-ba-be-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5313-in-vitro-in-vivo-corr-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5313-in-vitro-in-vivo-corr-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5313-in-vitro-in-vivo-corr-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5313-in-vitro-in-vivo-corr-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5314-bioanalyt-analyt-met");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5314-bioanalyt-analyt-met"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5314-bioanalyt-analyt-met"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"531-rep-biopharm-stud"+Path.DirectorySeparatorChar+"5314-bioanalyt-analyt-met"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5321-plasma-prot-bind-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5321-plasma-prot-bind-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5321-plasma-prot-bind-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5321-plasma-prot-bind-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5322-rep-hep-metab-interact-stud");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5322-rep-hep-metab-interact-stud"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5322-rep-hep-metab-interact-stud"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5322-rep-hep-metab-interact-stud"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5323-stud-other-human-biomat");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5323-stud-other-human-biomat"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5323-stud-other-human-biomat"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"532-rep-stud-pk-human-biomat"+Path.DirectorySeparatorChar+"5323-stud-other-human-biomat"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5331-healthy-subj-pk-init-tol-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5331-healthy-subj-pk-init-tol-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5331-healthy-subj-pk-init-tol-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5331-healthy-subj-pk-init-tol-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5332-patient-pk-init-tol-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5332-patient-pk-init-tol-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5332-patient-pk-init-tol-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5332-patient-pk-init-tol-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5333-intrin-factor-pk-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5333-intrin-factor-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5333-intrin-factor-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5333-intrin-factor-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5334-extrin-factor-pk-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5334-extrin-factor-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5334-extrin-factor-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5334-extrin-factor-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5335-popul-pk-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5335-popul-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5335-popul-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"533-rep-human-pk-stud"+Path.DirectorySeparatorChar+"5335-popul-pk-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud"+Path.DirectorySeparatorChar+"5341-healthy-subj-pd-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud"+Path.DirectorySeparatorChar+"5341-healthy-subj-pd-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud"+Path.DirectorySeparatorChar+"5341-healthy-subj-pd-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud"+Path.DirectorySeparatorChar+"5341-healthy-subj-pd-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud"+Path.DirectorySeparatorChar+"5342-patient-pd-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud"+Path.DirectorySeparatorChar+"5342-patient-pd-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud"+Path.DirectorySeparatorChar+"5342-patient-pd-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"534-rep-human-pd-stud"+Path.DirectorySeparatorChar+"5342-patient-pd-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5351-stud-rep-contr");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5351-stud-rep-contr"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5351-stud-rep-contr"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5351-stud-rep-contr"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5352-stud-rep-uncontr");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5352-stud-rep-uncontr"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5352-stud-rep-uncontr"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5352-stud-rep-uncontr"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5353-rep-analys-data-more-one-stud");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5353-rep-analys-data-more-one-stud"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5353-rep-analys-data-more-one-stud"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5353-rep-analys-data-more-one-stud"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5354-other-stud-rep");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5354-other-stud-rep"+Path.DirectorySeparatorChar+"study-report-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5354-other-stud-rep"+Path.DirectorySeparatorChar+"study-report-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"535-rep-effic-safety-stud"+Path.DirectorySeparatorChar+"indication-1"+Path.DirectorySeparatorChar+"5354-other-stud-rep"+Path.DirectorySeparatorChar+"study-report-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"536-postmark-exp");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"537-crf-ipl");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"537-crf-ipl"+Path.DirectorySeparatorChar+"study-1");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"537-crf-ipl"+Path.DirectorySeparatorChar+"study-2");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"53-clin-stud-rep"+Path.DirectorySeparatorChar+"537-crf-ipl"+Path.DirectorySeparatorChar+"study-3");
            rootDirectory.CreateSubdirectory("m5"+Path.DirectorySeparatorChar+"54-lit-ref");
            rootDirectory.CreateSubdirectory("util");
            rootDirectory.CreateSubdirectory("util"+Path.DirectorySeparatorChar+"dtd");
            rootDirectory.CreateSubdirectory("util"+Path.DirectorySeparatorChar+"style");
            sourceFile = eCTD_indexer.Properties.Resources.ich_ectd_3_2;
            System.IO.File.WriteAllText(rootDirectory + ""+Path.DirectorySeparatorChar+"util"+Path.DirectorySeparatorChar+"dtd"+Path.DirectorySeparatorChar+"ich-ectd-3-2.dtd", sourceFile);
            sourceFile = eCTD_indexer.Properties.Resources.ectd_2_0;
            System.IO.File.WriteAllText(rootDirectory + ""+Path.DirectorySeparatorChar+"util"+Path.DirectorySeparatorChar+"style"+Path.DirectorySeparatorChar+"ectd-2-0.xsl", sourceFile);
            sourceFile = eCTD_indexer.Properties.Resources.eu_regional;
            System.IO.File.WriteAllText(rootDirectory + ""+Path.DirectorySeparatorChar+"util"+Path.DirectorySeparatorChar+"dtd"+Path.DirectorySeparatorChar+"eu-regional.dtd", sourceFile);
            sourceFile = eCTD_indexer.Properties.Resources.eu_regional1;
            System.IO.File.WriteAllText(rootDirectory + ""+Path.DirectorySeparatorChar+"util"+Path.DirectorySeparatorChar+"style"+Path.DirectorySeparatorChar+"eu-regional.xsl", sourceFile, Encoding.GetEncoding(1252));            
            sourceFile = eCTD_indexer.Properties.Resources.eu_envelope;
            System.IO.File.WriteAllText(rootDirectory + ""+Path.DirectorySeparatorChar+"util"+Path.DirectorySeparatorChar+"dtd"+Path.DirectorySeparatorChar+"eu-envelope.mod", sourceFile);
            sourceFile = eCTD_indexer.Properties.Resources.eu_leaf;
            System.IO.File.WriteAllText(rootDirectory + ""+Path.DirectorySeparatorChar+"util"+Path.DirectorySeparatorChar+"dtd"+Path.DirectorySeparatorChar+"eu-leaf.mod", sourceFile);

            DialogResult result;
            result = MessageBox.Show("Open directory: " + rootDirectory.ToString() +"?", "Directory tree complete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(rootDirectory.ToString());
            }
        }

        private void currentDossierButton_Click(object sender, EventArgs e)
        {
            string topSequenceFolder = textBoxSeqDir.Text.Substring(0, textBoxSeqDir.Text.Length - 5);
            CurrentDossier current = new CurrentDossier();
            current.AssembleCurrentDossier(topSequenceFolder);            
        }

        private void copyEnvelopeButton_Click(object sender, EventArgs e)
        {            
            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Filter = "XML documents (*.xml)|*.xml";
            openFileDialog1.FileName = "eu-regional";

            // Do the next steps only if the user clicks on OK. Otherwise there will be an FileNotFoundException.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlTextReader myReader = new XmlTextReader(openFileDialog1.FileName);
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
                    foreach (Control control in this.Controls)
                    {
                        if (control is CheckBox)
                        {
                            ((CheckBox)control).Checked = false;
                        }
                    }
                    foreach (XmlNode countryEnvelope in envelope)
                    {
                        string tagFinder = countryEnvelope.Attributes["country"].Value.ToUpper();

                        foreach (Control control in this.Controls)
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
                                        if (countryEnvelope.SelectSingleNode("descendant::tracking").SelectSingleNode("descendant::number").InnerText.ToString() != null)
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
        }        
    }

    class MD5Calculator 
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

    public class directories
    {
        /// <summary>
        /// This method writes all names of all Sub-Directories into an Array.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="counter"></param>
        /// <param name="allSubDirs"></param>
        /// <returns></returns>
        public string[] dirLister(string path, int counter, string[] allSubDirs)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                DirectoryInfo[] dirs = di.GetDirectories();

                while (allSubDirs[counter] != "0") //to correct counter after jumping up from leaf directories
                {
                    counter++;
                }

                allSubDirs[counter] = di.FullName;
                counter++;

                if (dirs.Length > 0)
                {
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        dirLister(dirs[i].FullName, counter, allSubDirs);
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "The indexing process failed");
            }

            return allSubDirs;
        }
    }

    public class directoryDeleter
    {
        /// <summary>
        /// Deletes an empty directory. 
        /// Works only if no files or subdirectories exists in 
        /// the given directory.
        /// </summary>
        /// <param name="path"></param>
        public void dirDeleter(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                DirectoryInfo[] dirs = di.GetDirectories();
                FileInfo[] files = di.GetFiles();

                if (dirs.Length == 0 && files.Length == 0)
                {
                    di.Delete(false);                    
                }                
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "The delete process failed");
            }
        }
    }
}
