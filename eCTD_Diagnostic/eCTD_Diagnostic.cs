// eCTD_Diagnostic
// Copyright 2017 Quantentunnel (https://github.com/Quantentunnel)

// This file is part of eCTD_Diagnostic.

// eCTD_Diagnostic is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// eCTD_Diagnostic is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// Find the "EU Region eCTD Validation Criteria Version 6.1" under
// http://esubmission.ema.europa.eu/tiges/docs/eCTD%20EU%20Validation%20Criteria%20v6%201_March%202016-Final.xlsx
// For more information about the EU Module 1 please have a
// look at http://esubmission.ema.europa.eu/eumodule1/
// Links to relevant guidelines:
// eCTD Specification and Related Files: https://github.com/Quantentunnel/ectd_indexer/
// Notice to applicants - current EU Module 1, electronic application form: http://ec.europa.eu/health/documents/eudralex/vol-2/index_en.htm
// EU eSubmission guidelines: http://esubmission.ema.europa.eu/
// Heads of Medicines Agencies - Procedural Guidance for eSubmissions: http://www.hma.eu/277.html

// You should have received a copy of the GNU General Public License
// along with eCTD_Diagnostic.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Security.Cryptography;

namespace eCTD_Diagnostic
{
    public class eCTD_Diagnostics
    {
        public eCTD_Diagnostics(String path2sequence)
        {
            this.Path2Sequence = path2sequence;
        }

        // private Variables
        private String Path2Sequence;

        /// <summary>
        /// Validate the whole dossier.
        /// </summary>
        /// <returns></returns>
        public List<eCTD_Criteria> Validate()
        {
            // Create the criteria list.
            List<eCTD_Criteria> cl = new List<eCTD_Criteria>();

            // Insert Criteria Category ICH DTD
            eCTD_Criteria _01header = new eCTD_Criteria();
            _01header.SubNode = false;
            _01header.Category = eCTD_Category.ICH_DTD;
            cl.Add(_01header);

            // Check every criteria of 1.x
            cl.Add(this._01_1());
            cl.Add(this._01_2());
            cl.Add(this._01_3());
            cl.Add(this._01_4());
            cl.Add(this._01_5());

            // Insert Criteria ICH stylesheet
            eCTD_Criteria _02header = new eCTD_Criteria();
            _02header.SubNode = false;
            _02header.Category = eCTD_Category.ICH_stylesheet;
            cl.Add(_02header);

            // Check every criteria of 2.x
            cl.Add(this._02_1());
            cl.Add(this._02_2());
            cl.Add(this._02_3());

            // Insert Criteria EU M1 DTD
            eCTD_Criteria _03header = new eCTD_Criteria();
            _03header.SubNode = false;
            _03header.Category = eCTD_Category.EU_M1_DTD;
            cl.Add(_03header);

            // Check every criteria of 3.x
            cl.Add(this._03_1());
            cl.Add(this._03_2());
            cl.Add(this._03_3());

            // Insert Criteria EU M1 leaf MOD file
            eCTD_Criteria _04header = new eCTD_Criteria();
            _04header.SubNode = false;
            _04header.Category = eCTD_Category.EU_M1_leaf_MOD_file;
            cl.Add(_04header);

            // Check every criteria of 4.x
            cl.Add(this._04_1());
            cl.Add(this._04_2());
            cl.Add(this._04_3());

            // Insert Criteria EU M1 envelope MOD file
            eCTD_Criteria _05header = new eCTD_Criteria();
            _05header.SubNode = false;
            _05header.Category = eCTD_Category.EU_M1_envelope_MOD_file;
            cl.Add(_05header);

            // Check every criteria of 5.x
            cl.Add(this._05_1());
            cl.Add(this._05_2());
            cl.Add(this._05_3());

            // Insert Criteria EU M1 stylesheet file
            eCTD_Criteria _06header = new eCTD_Criteria();
            _06header.SubNode = false;
            _06header.Category = eCTD_Category.EU_M1_stylesheet;
            cl.Add(_06header);

            // Check every criteria of 6.x
            cl.Add(this._06_1());
            cl.Add(this._06_2());
            cl.Add(this._06_3());

            // Insert Criteria XML file
            eCTD_Criteria _07header = new eCTD_Criteria();
            _07header.SubNode = false;
            _07header.Category = eCTD_Category.Index_XML;
            cl.Add(_07header);

            // Check every criteria of 7.x
            cl.Add(this._07_1());
            cl.Add(this._07_2());
            cl.Add(this._07_3());
            cl.Add(this._07_4());
            cl.Add(this._07_5());
            cl.Add(this._07_6());

            // Insert Criteria of 8.x
            eCTD_Criteria _08header = new eCTD_Criteria();
            _08header.SubNode = false;
            _08header.Category = eCTD_Category.Index_MD5_txt;
            cl.Add(_08header);

            // Check every criteria of 8.x
            cl.Add(this._08_1());
            cl.Add(this._08_2());
            cl.Add(this._08_3());

            // Insert Criteria of 9.x
            eCTD_Criteria _09header = new eCTD_Criteria();
            _09header.SubNode = false;
            _09header.Category = eCTD_Category.EU_regional_XML;
            cl.Add(_09header);

            // Check every criteria of 9.x
            cl.Add(this._09_1());
            cl.Add(this._09_2());
            cl.Add(this._09_3());
            cl.Add(this._09_4());
            cl.Add(this._09_5());
            cl.Add(this._09_6());
            cl.Add(this._09_7());
            cl.Add(this._09_8());
            cl.Add(this._09_9());

            // Insert Criteria of 10.x
            eCTD_Criteria _10header = new eCTD_Criteria();
            _10header.SubNode = false;
            _10header.Category = eCTD_Category.Submission_Structure;
            cl.Add(_10header);

            // Check every criteria of 10.x
            cl.Add(this._10_1());


            // Insert Criteria of 11.x
            eCTD_Criteria _11header = new eCTD_Criteria();
            _11header.SubNode = false;
            _11header.Category = eCTD_Category.leaf_attributes;
            cl.Add(_11header);

            // Check every criteria of 11.x
            cl.Add(this._11_1());
            cl.Add(this._11_2());
            cl.Add(this._11_3());
            cl.Add(this._11_4());

            // Sum-up the status of all sub-nodes
            cl[0].Status = this.SumUpSubItems(cl, 1, 1, 5);
            cl[6].Status = this.SumUpSubItems(cl, 2, 1, 3);
            cl[10].Status = this.SumUpSubItems(cl, 3, 1, 3);
            cl[14].Status = this.SumUpSubItems(cl, 4, 1, 3);
            cl[18].Status = this.SumUpSubItems(cl, 5, 1, 3);
            cl[22].Status = this.SumUpSubItems(cl, 6, 1, 3);
            cl[26].Status = this.SumUpSubItems(cl, 7, 1, 6);
            cl[31].Status = this.SumUpSubItems(cl, 8, 1, 3);
            cl[35].Status = this.SumUpSubItems(cl, 9, 1, 9);
            cl[47].Status = this.SumUpSubItems(cl, 10, 1, 1);
            cl[49].Status = this.SumUpSubItems(cl, 11, 1, 4);

            // Return the list of checked criteria.
            return cl;
        }

        /// <summary>
        /// Checks the status of all sub-nodes. If one status is FAILED then the sum up state is also failed.
        /// Otherwiese if all status data is OK, then the sum up status is also OK.
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="CategoryNo"></param>
        /// <param name="sub_start"></param>
        /// <param name="sub_end"></param>
        /// <returns></returns>
        private String SumUpSubItems(List<eCTD_Criteria> cl, int CategoryNo, int sub_start, int sub_end)
        {
            int diff = sub_end - sub_start;

            if (diff >= 0)
            {
                int pointer = 0;

                for (int i = 0; i < cl.Count && pointer <= diff; i++)
                {
                    int subno = sub_start + pointer;
                    if (cl[i].Number != null)
                    {
                        if (cl[i].Number.value == CategoryNo.ToString() + "." + subno.ToString())
                        {
                            if (cl[i].Status == NodeType.Failed)
                            { return NodeType.Failed; }
                            else
                            {
                                pointer++;
                            }
                        }
                    }
                }
            }

            return NodeType.OK;
        }

        /// <summary>
        /// Validate eCTD criteria 1.1
        /// Does the ich-ectd-3-2.dtd file exist 
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _01_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._01_1);
            c.Category = eCTD_Category.ICH_DTD;
            c.ValidationCriterion = "The specified filename is used";
            c.Comments = "File is named ich-ectd-3-2.dtd";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\ich-ectd-3-2.dtd"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the dtd file in the /XXXX/util/dtd-directory?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _01_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._01_2);
            c.Category = eCTD_Category.ICH_DTD;
            c.ValidationCriterion = "The file is placed in the correct folder";
            c.Comments = "In the folder /XXXX/util/dtd";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\ich-ectd-3-2.dtd"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the MD5 hash value of the ich-ectd-3-2.dtd file correct?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _01_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._01_3);
            c.Category = eCTD_Category.ICH_DTD;
            c.ValidationCriterion = "A currently acceptable version of the DTD is used (checksum matches the published value)";
            c.Comments = "The checksum for the DTD in eCTD v3.2 (ich-ectd-3-2.dtd) is\n1d6f631cc6b6357f0f4fe378e5f79a27";
            c.TypeOfCheck = "P/F";

            String DTD = this.Path2Sequence + @"\util\dtd\ich-ectd-3-2.dtd";

            if (File.Exists(DTD))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(DTD))
                    {
                        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        byte[] fileData = new byte[fs.Length];
                        fs.Read(fileData, 0, (int)fs.Length);
                        byte[] checkSum = md5.ComputeHash(fileData);
                        String result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                        if (result.ToLower() == "1d6f631cc6b6357f0f4fe378e5f79a27")
                        {
                            c.Status = NodeType.OK;
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                            c.ErrorReason = "The ich-ectd-3-2.dtd file is invalid because an incorrect MD5 hash been calculated for the ich-ectd-3-2.dtd file in your dossier.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    c.Status = NodeType.Failed;

                    if (ex is IOException || ex is ArgumentException)
                    {
                        c.ErrorReason = "File not found";
                    }
                    else
                    {
                        c.ErrorReason = "Exception has been thrown when valdating no. 1.3";
                    }
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Previous sequences has correct sequence number?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _01_4()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._01_4);
            c.Category = eCTD_Category.ICH_DTD;
            c.ValidationCriterion = "DTD version used >= the DTD version of previous sequences";
            c.Comments = "With reference to any transition guidance, going back to an earlier version is\nnot allowed when a newer version has already been used for that eCTD. ";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\ich-ectd-3-2.dtd"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    // IF 0000 everything is ok
                    if (this.Path2Sequence.EndsWith("0000"))
                    {
                        c.Status = NodeType.OK;
                        return c;
                    }
                    else
                    {
                        // See which sequence number the current dossier has.
                        String seqno = this.Path2Sequence.Substring(this.Path2Sequence.Length - 4, 4);
                        String pathwithseq = this.Path2Sequence.Substring(0, this.Path2Sequence.Length - 4);
                        seqno = seqno.Replace("0", "");
                        int seq;
                        if (seqno != "0000")
                        {
                            seqno = seqno.Replace("0", "");
                            seq = Convert.ToInt32(seqno); ;
                        }
                        else { seq = 0; }

                        // Have a look at every previous sequence
                        while (seq >= 0)
                        {
                            if (Directory.Exists(pathwithseq + seq.ToString()))
                            {
                                // check if there is an previous sequence and that there is same or a previous DTD version used.
                                if (!File.Exists(pathwithseq + seq.ToString() + @"\util\dtd\ich-ectd-3-2.dtd"))
                                {
                                    c.Status = NodeType.Failed;
                                    return c;
                                }
                            }
                            else
                            {
                                // If one seq number is not found, give a warning to the user and tell him that only one seqence number is missing and that the rest might be ok.
                                c.Status = NodeType.Warning;
                                c.ErrorReason = "Missing sequence directories to check this criteria.";
                            }
                            seq--;
                        }
                    }

                    c.Status = NodeType.OK;
                    return c;
                }
            }

            // If nothing matched then this criteria failed.
            c.Status = NodeType.Failed;
            return c;
        }

        /// <summary>
        /// Following sequences has correct sequence number?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _01_5()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._01_5);
            c.Category = eCTD_Category.ICH_DTD;
            c.ValidationCriterion = "DTD version used <= the DTD version of further sequences";
            c.Comments = "This rule specifically tests in situations where sequences have been submitted out of order. ";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\ich-ectd-3-2.dtd"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {

                    // See which sequence number the current dossier has.
                    String seqno = this.Path2Sequence.Substring(this.Path2Sequence.Length - 4, 4);
                    String pathwithseq = this.Path2Sequence.Substring(0, this.Path2Sequence.Length - 4);
                    int seq;
                    if (seqno != "0000")
                    {
                        seqno = seqno.Replace("0", "");
                        seq = Convert.ToInt32(seqno); ;
                    }
                    else { seq = 0; }

                    // Have a look at every possible further sequence
                    while (seq <= 9999)
                    {
                        // It is only possible to check a dossier if the directory exists.
                        if (Directory.Exists(pathwithseq + seq.ToString()))
                        {
                            // check if there is an previous sequence and that there is same or a previous DTD version used.
                            if (!File.Exists(pathwithseq + seq.ToString() + @"\util\dtd\ich-ectd-3-2.dtd"))
                            {
                                c.Status = NodeType.Failed;
                                return c;
                            }
                        }
                        seq++;
                    }

                    c.Status = NodeType.OK;
                    return c;
                }
            }

            // If nothing matched then this criteria failed.
            c.Status = NodeType.Failed;
            return c;
        }

        /// <summary>
        /// Validate eCTD criteria 2.1
        /// Does the ectd-2-0.xsl file exist 
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _02_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._02_1);
            c.Category = eCTD_Category.ICH_stylesheet;
            c.ValidationCriterion = "The specified filename is used";
            c.Comments = "File is named ectd-2-0.xsl";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\style\ectd-2-0.xsl"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the dtd file in the /XXXX/util/dtd-directory?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _02_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._02_2);
            c.Category = eCTD_Category.ICH_stylesheet;
            c.ValidationCriterion = "The file is placed in the correct folder";
            c.Comments = "In the folder /XXXX/util/style";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\style\ectd-2-0.xsl"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found in /XXXX/util/style.";
            }
            return c;
        }

        /// <summary>
        /// Is the MD5 hash value of the ectd-2-0.xsl file correct?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _02_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._02_3);
            c.Category = eCTD_Category.ICH_stylesheet;
            c.ValidationCriterion = "The checksum for the stylesheet used must match the published checksum\nfor the stylesheet associated with the DTD used for the sequence";
            c.Comments = "checksum corresponding to the stylesheet from eCTD specification v3.2 (ectd-2-0.xsl)\nis 3a07a202455e954a2eb203c5bb443f77";
            c.TypeOfCheck = "P/F";

            String DTD = this.Path2Sequence + @"\util\style\ectd-2-0.xsl";

            if (File.Exists(DTD))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(DTD))
                    {
                        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        byte[] fileData = new byte[fs.Length];
                        fs.Read(fileData, 0, (int)fs.Length);
                        byte[] checkSum = md5.ComputeHash(fileData);
                        String result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                        if (result.ToLower() == "3a07a202455e954a2eb203c5bb443f77")
                        {
                            c.Status = NodeType.OK;
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                            c.ErrorReason = "The ectd-2-0.xsl file is invalid because an incorrect MD5 hash been calculated for the ectd-2-0.xsl file in your dossier.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    c.Status = NodeType.Failed;

                    if (ex is IOException || ex is ArgumentException)
                    {
                        c.ErrorReason = "File not found";
                    }
                    else
                    {
                        c.ErrorReason = "Exception has been thrown when valdating no. 2.3";
                    }
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Validate eCTD criteria 3.1
        /// Does the eu-regional.dtd file exist?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _03_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._03_1);
            c.Category = eCTD_Category.EU_M1_DTD;
            c.ValidationCriterion = "The specified filename is used";
            c.Comments = "File is named eu-regional.dtd";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\eu-regional.dtd"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the dtd file in the /XXXX/util/dtd-directory?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _03_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._03_2);
            c.Category = eCTD_Category.EU_M1_DTD;
            c.ValidationCriterion = "The file is placed in the correct folder";
            c.Comments = "In the folder /XXXX/util/dtd";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\eu-regional.dtd"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the MD5 hash value of the eu-regional.dtd file correct?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _03_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._03_3);
            c.Category = eCTD_Category.EU_M1_DTD;
            c.ValidationCriterion = "A currently acceptable version of the DTD is used (checksum matches the published value)";
            c.Comments = "checksum corresponding to the EU-Regional-DTD-file from eCTD specification v3.0.2 \nis 290503BF171E7E2E80EF90F0BDE5D91E";
            c.TypeOfCheck = "P/F";

            String DTD = this.Path2Sequence + @"\util\dtd\eu-regional.dtd";

            if (File.Exists(DTD))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(DTD))
                    {
                        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        byte[] fileData = new byte[fs.Length];
                        fs.Read(fileData, 0, (int)fs.Length);
                        byte[] checkSum = md5.ComputeHash(fileData);
                        String result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                        if (result == "290503BF171E7E2E80EF90F0BDE5D91E")
                        {
                            c.Status = NodeType.OK;
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                            c.ErrorReason = "The eu-regional.dtd file is invalid because an incorrect MD5 hash been calculated for the eu-regional.dtd file in your dossier.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    c.Status = NodeType.Failed;

                    if (ex is IOException || ex is ArgumentException)
                    {
                        c.ErrorReason = "File not found";
                    }
                    else
                    {
                        c.ErrorReason = "Exception has been thrown when valdating no. 3.3";
                    }
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        // TODO: 3.4 and 3.5

        /// <summary>
        /// Validate eCTD criteria 4.1
        /// Does the eu-leaf.mod file exist?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _04_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._04_1);
            c.Category = eCTD_Category.EU_M1_leaf_MOD_file;
            c.ValidationCriterion = "The specified filename is used";
            c.Comments = "File is named eu-leaf.mod";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\eu-leaf.mod"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the dtd file in the /XXXX/util/dtd-directory?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _04_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._04_2);
            c.Category = eCTD_Category.EU_M1_leaf_MOD_file;
            c.ValidationCriterion = "The file is placed in the correct folder";
            c.Comments = "In the folder /XXXX/util/dtd";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\eu-leaf.mod"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the MD5 hash value of the eu-leaf.mod file correct?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _04_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._04_3);
            c.Category = eCTD_Category.EU_M1_leaf_MOD_file;
            c.ValidationCriterion = "A currently acceptable version of the DTD is used (checksum matches the published value)";
            c.Comments = "checksum corresponding to the eu-leaf.mod from eCTD specification v3.0.2 \nis 23B854174E61C68044B9F53C0009AF95";
            c.TypeOfCheck = "P/F";

            String DTD = this.Path2Sequence + @"\util\dtd\eu-leaf.mod";

            if (File.Exists(DTD))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(DTD))
                    {
                        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        byte[] fileData = new byte[fs.Length];
                        fs.Read(fileData, 0, (int)fs.Length);
                        byte[] checkSum = md5.ComputeHash(fileData);
                        String result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                        if (result == "23B854174E61C68044B9F53C0009AF95")
                        {
                            c.Status = NodeType.OK;
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                            c.ErrorReason = "The eu-leaf.mod file is invalid because an incorrect MD5 hash been calculated for the eu-leaf.mod file in your dossier.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    c.Status = NodeType.Failed;

                    if (ex is IOException || ex is ArgumentException)
                    {
                        c.ErrorReason = "File not found";
                    }
                    else
                    {
                        c.ErrorReason = "Exception has been thrown when valdating no. 4.3";
                    }
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Validate eCTD criteria 5.1
        /// Does the eu-envelope.mod file exist?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _05_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._05_1);
            c.Category = eCTD_Category.EU_M1_envelope_MOD_file;
            c.ValidationCriterion = "The specified filename is used";
            c.Comments = "File is named eu-envelope.mod";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\eu-envelope.mod"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the dtd file in the /XXXX/util/dtd-directory?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _05_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._05_2);
            c.Category = eCTD_Category.EU_M1_envelope_MOD_file;
            c.ValidationCriterion = "The file is placed in the correct folder";
            c.Comments = "In the folder /XXXX/util/dtd";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\dtd\eu-envelope.mod"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the MD5 hash value of the eu-envelope.mod file correct?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _05_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._05_3);
            c.Category = eCTD_Category.EU_M1_envelope_MOD_file;
            c.ValidationCriterion = "A currently acceptable version of the DTD is used (checksum matches the published value)";
            c.Comments = "checksum corresponding to the eu-envelope.mod from eCTD specification v3.0.2 \nis D0727AE0FB68B19EDAE49AB9E2E22A4A";
            c.TypeOfCheck = "P/F";

            String DTD = this.Path2Sequence + @"\util\dtd\eu-envelope.mod";

            if (File.Exists(DTD))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(DTD))
                    {
                        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        byte[] fileData = new byte[fs.Length];
                        fs.Read(fileData, 0, (int)fs.Length);
                        byte[] checkSum = md5.ComputeHash(fileData);
                        String result = BitConverter.ToString(checkSum).Replace("-", String.Empty);

                        // Caution: The hash value in the EU Region eCTD Validation Criteria excel file is not the
                        // same as specified here: http://esubmission.ema.europa.eu/eumodule1/ for version 3.0.2
                        if (result == "D0727AE0FB68B19EDAE49AB9E2E22A4A")
                        {
                            c.Status = NodeType.OK;
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                            c.ErrorReason = "The eu-envelope.mod file is invalid because an incorrect MD5 hash been calculated for the eu-envelope.mod file in your dossier.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    c.Status = NodeType.Failed;

                    if (ex is IOException || ex is ArgumentException)
                    {
                        c.ErrorReason = "File not found";
                    }
                    else
                    {
                        c.ErrorReason = "Exception has been thrown when valdating no. 5.3";
                    }
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Validate eCTD criteria 6.1
        /// Does the eu-regional.xsl file exist?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _06_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._06_1);
            c.Category = eCTD_Category.EU_M1_envelope_MOD_file;
            c.ValidationCriterion = "The specified filename is used";
            c.Comments = "File is named eu-regional.xsl";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\style\eu-regional.xsl"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the dtd file in the /XXXX/util/dtd-directory?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _06_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._06_2);
            c.Category = eCTD_Category.EU_M1_stylesheet;
            c.ValidationCriterion = "The file is placed in the correct folder";
            c.Comments = "In the folder /XXXX/style/dtd";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\util\style\eu-regional.xsl"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Is the MD5 hash value of the eu-envelope.mod file correct?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _06_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._06_3);
            c.Category = eCTD_Category.EU_M1_stylesheet;
            c.ValidationCriterion = "A currently acceptable version of the DTD is used (checksum matches the published value)";
            c.Comments = "checksum corresponding to the eu-regional.xsl from eCTD specification v3.0.2 \nis 0107179C3739EBBD6B00CE492FE6E1E7";
            c.TypeOfCheck = "P/F";

            String DTD = this.Path2Sequence + @"\util\style\eu-regional.xsl";

            if (File.Exists(DTD))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(DTD))
                    {
                        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        byte[] fileData = new byte[fs.Length];
                        fs.Read(fileData, 0, (int)fs.Length);
                        byte[] checkSum = md5.ComputeHash(fileData);
                        String result = BitConverter.ToString(checkSum).Replace("-", String.Empty);

                        // Caution: The hash value in the EU Region eCTD Validation Criteria excel file is not the
                        // same as specified here: http://esubmission.ema.europa.eu/eumodule1/ for version 3.0.2
                        if (result == "0107179C3739EBBD6B00CE492FE6E1E7")
                        {
                            c.Status = NodeType.OK;
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                            c.ErrorReason = "The eu-regional.xsl file is invalid because an incorrect MD5 hash been calculated for the eu-regional.xsl file in your dossier.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    c.Status = NodeType.Failed;

                    if (ex is IOException || ex is ArgumentException)
                    {
                        c.ErrorReason = "File not found";
                    }
                    else
                    {
                        c.ErrorReason = "Exception has been thrown when valdating no. 6.3";
                    }
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }


        /// <summary>
        /// Validate eCTD criteria 7.1
        /// The XML file is placed in the correct folder?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _07_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._07_1);
            c.Category = eCTD_Category.Index_XML;
            c.ValidationCriterion = "The XML file is placed in the correct folder";
            c.Comments = "The root folder /XXXX";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\index.xml"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// The file is named correctly?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _07_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._07_2);
            c.Category = eCTD_Category.Index_XML;
            c.ValidationCriterion = "The file is named correctly";
            c.Comments = "File is named index.xml";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\index.xml"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Well formed with respect to the rules of the XML specification?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _07_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._07_3);
            c.Category = eCTD_Category.Index_XML;
            c.ValidationCriterion = "The file is well formed";
            c.Comments = "Well formed with respect to the rules of the XML specification";
            c.TypeOfCheck = "P/F";

            try
            {
                String xmlfile = this.Path2Sequence + @"\index.xml";

                // Check we actually have the file
                if (File.Exists(xmlfile))
                {
                    // Try to load and parse the XML document.
                    XDocument oXML = XDocument.Load(xmlfile);
                    XDocument.Parse(oXML.Document.ToString());

                    // If we managed with no exception then this is valid XML!
                    c.Status = NodeType.OK;
                }
                else
                {
                    // A blank value is not valid xml
                    c.Status = NodeType.Failed;
                    c.ErrorReason = "File not found";
                }
            }
            catch (Exception)
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "The file is not well formed with respect to the rules of the XML specification.";
            }
            return c;
        }

        /// <summary>
        /// Valid with respect to the ICH eCTD DTD file included in the util/dtd folder ?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _07_4()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._07_4);
            c.Category = eCTD_Category.Index_XML;
            c.ValidationCriterion = "The file is valid";
            c.Comments = "Valid with respect to the ICH eCTD DTD file included in the util/dtd folder";
            c.TypeOfCheck = "P/F";

            try
            {
                String xmlfile = this.Path2Sequence + @"\index.xml";

                // Check we actually have the file
                if (File.Exists(xmlfile) && File.Exists(this.Path2Sequence + @"\util\dtd\ich-ectd-3-2.dtd"))
                {
                    // Have a look at https://msdn.microsoft.com/de-de/library/system.xml.xmlreadersettings.dtdprocessing(v=vs.110).aspx
                    // Set the validation settings.
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.DtdProcessing = DtdProcessing.Parse;
                    settings.ValidationType = ValidationType.DTD;

                    // Create the XmlReader object.
                    XmlReader reader = XmlReader.Create(xmlfile, settings);

                    // Parse the file.  
                    while (reader.Read()) ;

                    c.Status = NodeType.OK;
                }
                else
                {
                    // A blank value is not valid xml
                    c.Status = NodeType.Failed;
                    c.ErrorReason = "File not found";
                }
            }
            catch (Exception)
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "The file is not well formed with respect to the rules of the XML specification.";
            }
            return c;
        }

        /// <summary>
        /// This is the ICH DTD in /XXXX/util/dtd, and tested for validity by rules 1.1 - 1.5.  
        /// A valid reference means a URI - see http://www.w3.org/TR/xml/ and http://www.ietf.org/rfc/rfc3986.txt (version 2005 page 22, section 3.3).
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _07_5()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._07_5);
            c.Category = eCTD_Category.Index_XML;
            c.ValidationCriterion = "The reference to the DTD in index.xml is directed to the DTD provided in the util folder.";
            c.Comments = "This is the ICH DTD in /XXXX/util/dtd, and tested for validity by rules 1.1 - 1.5.";
            c.TypeOfCheck = "P/F";

            String condition1 = _01_1().Status;
            String condition2 = _01_2().Status;
            String condition3 = _01_3().Status;
            String condition4 = _01_4().Status;
            String condition5 = _01_5().Status;

            if (condition1 == NodeType.OK &&
                condition2 == NodeType.OK &&
                condition3 == NodeType.OK &&
                condition4 == NodeType.OK &&
                condition5 == NodeType.OK)
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
            }

            return c;
        }

        /// <summary>
        /// This is the ICH stylesheet in /XXXX/util/style and tested for validity by rules 2.1 - 2.3.  
        /// A valid reference means a URI - 
        /// see http://www.w3.org/TR/xml/ and http://www.ietf.org/rfc/rfc3986.txt (version 2005 page 22, section 3.3).
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _07_6()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._07_6);
            c.Category = eCTD_Category.Index_XML;
            c.ValidationCriterion = "The reference to the stylesheet in index.xml is directed to the stylesheet provided in the util folder.";
            c.Comments = "This is the ICH stylesheet in /XXXX/util/style and tested for validity by rules 2.1 - 2.3. ";
            c.TypeOfCheck = "P/F";

            String condition1 = _02_1().Status;
            String condition2 = _02_2().Status;
            String condition3 = _02_3().Status;

            if (condition1 == NodeType.OK &&
                condition2 == NodeType.OK &&
                condition3 == NodeType.OK)
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
            }

            return c;
        }


        /// <summary>
        /// Validate eCTD criteria 8.1
        /// The XML file is placed in the correct folder?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _08_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._08_1);
            c.Category = eCTD_Category.Index_MD5_txt;
            c.ValidationCriterion = "The MD5 hash file is placed in the correct folder";
            c.Comments = "The root folder /XXXX";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\index-md5.txt"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// The file is named correctly?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _08_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._08_2);
            c.Category = eCTD_Category.Index_MD5_txt;
            c.ValidationCriterion = "The file is named correctly";
            c.Comments = "The file is named index-md5.txt";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\index-md5.txt"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }


        /// <summary>
        /// The file is named correctly?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _08_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._08_3);
            c.Category = eCTD_Category.Index_MD5_txt;
            c.ValidationCriterion = "The regenerated checksum for the index.xml matches the value in the file index-md5.txt.";
            c.Comments = "The checkum is correct.";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\index-md5.txt") && File.Exists(this.Path2Sequence + @"\index.xml"))
            {
                try
                {
                    String indexXML = this.Path2Sequence + @"\index.xml";
                    String indexmd5TXT_content = "";

                    using (FileStream fs = File.OpenRead(indexXML))
                    {
                        // Calculate Hash Value
                        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        byte[] fileData = new byte[fs.Length];
                        fs.Read(fileData, 0, (int)fs.Length);
                        byte[] checkSum = md5.ComputeHash(fileData);
                        String result = BitConverter.ToString(checkSum).Replace("-", String.Empty);

                        // Read the hash value written down in the text file
                        // Open the text file using a stream reader.
                        using (StreamReader sr = new StreamReader(this.Path2Sequence + @"\index-md5.txt"))
                        {
                            // Read the stream to a string, and write the string to the console.
                            indexmd5TXT_content = sr.ReadLine();
                        }

                        // Caution: The hash value in the EU Region eCTD Validation Criteria excel file is not the
                        // same as specified here: http://esubmission.ema.europa.eu/eumodule1/ for version 3.0.2
                        if (result.ToLower() == indexmd5TXT_content)
                        {
                            c.Status = NodeType.OK;
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                            c.ErrorReason = "The hash value in index-md5.txt is incorrect.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    c.Status = NodeType.Failed;

                    if (ex is IOException || ex is ArgumentException)
                    {
                        c.ErrorReason = "File not found";
                    }
                    else
                    {
                        c.ErrorReason = "Exception has been thrown when valdating no. 6.3";
                    }
                }

                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Validate eCTD criteria 9.1
        /// The XML file is placed in the correct folder?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _09_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_1);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The XML file is placed in the correct folder";
            c.Comments = "The folder /XXXX/m1/eu";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\m1\eu\eu-regional.xml"))
            {
                Regex r = new Regex(@"$(?<=\\[0-9]{4})", RegexOptions.IgnoreCase);

                // Match the regular expression pattern against the SearchTerm;
                // Change column name to ID if the user searches for a ID.
                if (r.Match(this.Path2Sequence).Success)
                {
                    c.Status = NodeType.OK;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// The file is named correctly?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _09_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_2);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The file is named correctly";
            c.Comments = "File is named eu-regional.xml";
            c.TypeOfCheck = "P/F";

            if (File.Exists(this.Path2Sequence + @"\m1\eu\eu-regional.xml"))
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "File not found";
            }
            return c;
        }

        /// <summary>
        /// Well formed with respect to the rules of the XML specification?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _09_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_3);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The file is well formed";
            c.Comments = "Well formed with respect to the rules of the XML specification";
            c.TypeOfCheck = "P/F";

            try
            {
                String xmlfile = this.Path2Sequence + @"\m1\eu\eu-regional.xml";

                // Check we actually have the file
                if (File.Exists(xmlfile))
                {
                    // Try to load and parse the XML document.
                    XDocument oXML = XDocument.Load(xmlfile);
                    XDocument.Parse(oXML.Document.ToString());

                    // If we managed with no exception then this is valid XML!
                    c.Status = NodeType.OK;
                }
                else
                {
                    // A blank value is not valid xml
                    c.Status = NodeType.Failed;
                    c.ErrorReason = "File not found";
                }
            }
            catch (Exception)
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "The file is not well formed with respect to the rules of the XML specification.";
            }
            return c;
        }

        /// <summary>
        /// Valid with respect to the ICH eCTD DTD file included in the util/dtd folder ?
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _09_4()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_4);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The file is valid";
            c.Comments = "Valid with respect to the EU Module 1 DTD file included in the util/dtd folder.";
            c.TypeOfCheck = "P/F";

            try
            {
                String xmlfile = this.Path2Sequence + @"\m1\eu\eu-regional.xml";

                // Check we actually have the file
                if (File.Exists(xmlfile) && File.Exists(this.Path2Sequence + @"\util\dtd\eu-regional.dtd"))
                {
                    // Have a look at https://msdn.microsoft.com/de-de/library/system.xml.xmlreadersettings.dtdprocessing(v=vs.110).aspx
                    // Set the validation settings.
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.DtdProcessing = DtdProcessing.Parse;
                    settings.ValidationType = ValidationType.DTD;

                    // Create the XmlReader object.
                    XmlReader reader = XmlReader.Create(xmlfile, settings);

                    // Parse the file.  
                    while (reader.Read()) {; }

                    c.Status = NodeType.OK;
                }
                else
                {
                    // A blank value is not valid xml
                    c.Status = NodeType.Failed;
                    c.ErrorReason = "File not found";
                }
            }
            catch (Exception)
            {
                c.Status = NodeType.Failed;
                c.ErrorReason = "The file is not well formed with respect to the rules of the XML specification.";
            }
            return c;
        }

        /// <summary>
        /// This is the EU Regional DTD in /XXXX/util/dtd, and tested for validity by rules 3.1-3.5.  
        /// A valid reference means a URI 
        /// - see http://www.w3.org/TR/xml/ and http://www.ietf.org/rfc/rfc3986.txt (version 2005 page 22, section 3.3)
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _09_5()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_5);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The reference to the DTD in eu-regional.xml is directed to the DTD provided in the util folder.";
            c.Comments = "This is the EU Regional DTD in /XXXX/util/dtd, and tested for validity by rules 3.1-3.5.";
            c.TypeOfCheck = "P/F";

            String condition1 = _03_1().Status;
            String condition2 = _03_2().Status;
            String condition3 = _03_3().Status;

            if (condition1 == NodeType.OK &&
                condition2 == NodeType.OK &&
                condition3 == NodeType.OK)
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
            }

            return c;
        }

        /// <summary>
        /// This is the stylesheet in /XXXX/util/style, and tested for validity by rules 6.1-6.3. 
        /// A valid reference means a URI 
        /// - see http://www.w3.org/TR/xml/ and http://www.ietf.org/rfc/rfc3986.txt (version 2005 page 22, section 3.3).
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _09_6()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_6);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The reference to the stylesheet in eu-regional.xml is directed to the stylesheet provided in the util folder.";
            c.Comments = "This is the stylesheet in /XXXX/util/style, and tested for validity by rules 6.1-6.3.";
            c.TypeOfCheck = "P/F";

            String condition1 = _06_1().Status;
            String condition2 = _06_2().Status;
            String condition3 = _06_3().Status;

            if (condition1 == NodeType.OK &&
                condition2 == NodeType.OK &&
                condition3 == NodeType.OK)
            {
                c.Status = NodeType.OK;
            }
            else
            {
                c.Status = NodeType.Failed;
            }

            return c;
        }

        /// <summary>
        /// This criterion will test whether the UUID is well formed.
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _09_7()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_7);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The UUID is well formed according to ISO/IEC 11578:1996 and ITU-T Rec X.667 | ISO/IEC 9834-8:2005";
            c.Comments = "This criterion will test whether the UUID is well formed.";
            c.TypeOfCheck = "P/F";

            String EURegionalXML = this.Path2Sequence + @"\m1\eu\eu-regional.xml";

            if (File.Exists(EURegionalXML))
            {
                XmlTextReader myReader = new XmlTextReader(EURegionalXML);
                XmlDocument mySourceDoc = new XmlDocument();
                mySourceDoc.Load(myReader);
                myReader.Close();

                XmlNode uuidNode;
                uuidNode = mySourceDoc.SelectSingleNode("//identifier");
                String UUID = uuidNode.InnerText;

                Guid guidOutput;

                // Have a look at https://stackoverflow.com/a/6211032
                // and at https://msdn.microsoft.com/en-us/library/system.guid.tryparse.aspx
                if (Guid.TryParse(UUID, out guidOutput))
                {
                    Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
                    if (isGuid.IsMatch(UUID))
                    {
                        c.Status = NodeType.OK;
                    }
                    else
                    {
                        c.Status = NodeType.Failed;
                    }
                }
                else
                {
                    c.Status = NodeType.Failed;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
            }

            return c;
        }

        /// <summary>
        /// If the sequence already submitted numerically preceding the incoming sequence in the eCTD lifecycle contains a UUID 
        /// (i.e. was submitted using v3.0 of the EU m1 Specification or higher), then the UUID in this incoming sequence must be 
        /// identical to the one in the previous sequence. 
        /// This method checks the previous sequence.
        /// Give a warning when the previous sequence does not exist.
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _09_8()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_8);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The UUID in this incoming sequence must be identical to the one in the previous sequence";
            c.Comments = "This rule checks that the UUID is correct.";
            c.TypeOfCheck = "P/F";

            String EURegionalXML = this.Path2Sequence + @"\m1\eu\eu-regional.xml";

            if (File.Exists(EURegionalXML))
            {
                // Read the actual xml file
                XmlTextReader myReader = new XmlTextReader(EURegionalXML);
                XmlDocument mySourceDoc = new XmlDocument();
                mySourceDoc.Load(myReader);
                myReader.Close();

                // Get the actual uuid
                XmlNode uuidNode;
                uuidNode = mySourceDoc.SelectSingleNode("//identifier");
                String UUID = uuidNode.InnerText;

                // Create previous path string
                int previousseq = Convert.ToInt32(this.Path2Sequence.Substring(this.Path2Sequence.Length - 4, 4)) - 1;
                string previousseqstr = previousseq.ToString();
                if (previousseqstr.Length == 1)
                {
                    previousseqstr = "000" + previousseqstr;
                }
                else if (previousseqstr.Length == 2)
                {
                    previousseqstr = "00" + previousseqstr;
                }
                else if (previousseqstr.Length == 3)
                {
                    previousseqstr = "0" + previousseqstr;
                }

                String Path2PreviousSequence = this.Path2Sequence.Substring(0, this.Path2Sequence.Length - 4) + previousseqstr;
                String EURegionalPreviousXML = Path2PreviousSequence + @"\m1\eu\eu-regional.xml";

                if (File.Exists(EURegionalPreviousXML))
                {
                    // Load the previous xml file
                    XmlTextReader myReaderPrevious = new XmlTextReader(EURegionalPreviousXML);
                    XmlDocument mySourceDocPrevious = new XmlDocument();
                    mySourceDocPrevious.Load(myReaderPrevious);
                    myReaderPrevious.Close();

                    // Get the previous uuid
                    XmlNode uuidNodePrevious;
                    uuidNodePrevious = mySourceDocPrevious.SelectSingleNode("//identifier");
                    String UUIDPrevious = uuidNodePrevious.InnerText;

                    // Are both uuids valid?
                    Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
                    if (isGuid.IsMatch(UUID) && isGuid.IsMatch(UUIDPrevious))
                    {
                        // Are they the same?
                        if (UUID == UUIDPrevious)
                        {
                            c.Status = NodeType.OK;
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                        }
                    }
                    else
                    {
                        c.Status = NodeType.Failed;
                    }
                }
                else
                {
                    c.Status = NodeType.Warning;
                }
            }
            else
            {
                c.Status = NodeType.Failed;
            }

            return c;
        }

        public eCTD_Criteria _09_9()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._09_9);
            c.Category = eCTD_Category.EU_regional_XML;
            c.ValidationCriterion = "The UUID must be identical in all envelopes.";
            c.Comments = "";
            c.TypeOfCheck = "P/F";
            c.Status = NodeType.OK;

            String EURegionalXML = this.Path2Sequence + @"\m1\eu\eu-regional.xml";

            if (File.Exists(EURegionalXML))
            {
                // Read the actual xml file
                XmlTextReader myReader = new XmlTextReader(EURegionalXML);
                XmlDocument mySourceDoc = new XmlDocument();
                mySourceDoc.Load(myReader);
                myReader.Close();

                // Get the actual uuid
                XmlNode uuidNode;
                uuidNode = mySourceDoc.SelectSingleNode("//identifier");
                String UUID = uuidNode.InnerText;

                // Create previous path string
                int previousseq = Convert.ToInt32(this.Path2Sequence.Substring(this.Path2Sequence.Length - 4, 4)) - 1;

                while (previousseq > 0 && c.Status != NodeType.Warning && c.Status != NodeType.Failed)
                {
                    string previousseqstr = previousseq.ToString();
                    if (previousseqstr.Length == 1)
                    {
                        previousseqstr = "000" + previousseqstr;
                    }
                    else if (previousseqstr.Length == 2)
                    {
                        previousseqstr = "00" + previousseqstr;
                    }
                    else if (previousseqstr.Length == 3)
                    {
                        previousseqstr = "0" + previousseqstr;
                    }

                    String Path2PreviousSequence = this.Path2Sequence.Substring(0, this.Path2Sequence.Length - 4) + previousseqstr;
                    String EURegionalPreviousXML = Path2PreviousSequence + @"\m1\eu\eu-regional.xml";

                    if (File.Exists(EURegionalPreviousXML))
                    {

                        // Load the previous xml file
                        XmlTextReader myReaderPrevious = new XmlTextReader(EURegionalPreviousXML);
                        XmlDocument mySourceDocPrevious = new XmlDocument();
                        mySourceDocPrevious.Load(myReaderPrevious);
                        myReaderPrevious.Close();

                        // Get the previous uuid
                        XmlNode uuidNodePrevious;
                        uuidNodePrevious = mySourceDocPrevious.SelectSingleNode("//identifier");
                        String UUIDPrevious = uuidNodePrevious.InnerText;

                        // Are both uuids valid?
                        Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
                        if (isGuid.IsMatch(UUID) && isGuid.IsMatch(UUIDPrevious))
                        {
                            // Are they the same?
                            if (UUID == UUIDPrevious)
                            {
                                c.Status = NodeType.OK;
                            }
                            else
                            {
                                c.Status = NodeType.Failed;
                            }
                        }
                        else
                        {
                            c.Status = NodeType.Failed;
                        }
                    }
                    else
                    {
                        c.Status = NodeType.Warning;
                    }

                    previousseq--;
                }
                // end of while
            }
            else
            {
                c.Status = NodeType.Failed;
            }

            return c;
        }


        public eCTD_Criteria _10_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._10_1);
            c.Category = eCTD_Category.Submission_Structure;
            c.ValidationCriterion = "All the lowest level heading elements in the XML.";
            c.Comments = "";
            c.TypeOfCheck = "P/F";
            c.Status = NodeType.OK;

            String EURegionalXML = this.Path2Sequence + @"\m1\eu\eu-regional.xml";
            String IndexXML = this.Path2Sequence + @"\index.xml";

            // Check the EU-Regional.xml file
            var docEURegional = XDocument.Load(EURegionalXML);
            var docIndexXML = XDocument.Load(IndexXML);

            if (!XMLToolbox.TreeHasSingleChildNodes(docEURegional.Root.Elements().ElementAt(1)) ||
                !XMLToolbox.TreeHasSingleChildNodes(docIndexXML.Root))
            {
                c.Status = NodeType.Failed;
            }

            return c;
        }

        public eCTD_Criteria _11_1()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._11_1);
            c.Category = eCTD_Category.leaf_attributes;
            c.ValidationCriterion = "The leaf attribute 'checksum-type' has a value of md5 or MD5.";
            c.Comments = "";
            c.TypeOfCheck = "P/F";
            c.Status = NodeType.OK;

            String EURegionalXML = this.Path2Sequence + @"\m1\eu\eu-regional.xml";
            String IndexXML = this.Path2Sequence + @"\index.xml";

            #region Check the EU-Regional.xml file
            XmlTextReader myReader = new XmlTextReader(EURegionalXML);
            XmlDocument mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            XmlNodeList xnl = mySourceDoc.SelectNodes("//leaf/@checksum-type");

            for (int i = 0; i < xnl.Count; i++)
            {
                if (xnl[i].Value != "md5" && xnl[i].Value != "MD5")
                {
                    c.Status = NodeType.Failed;
                }
            }
            #endregion

            #region Check the index.xml file
            myReader = new XmlTextReader(IndexXML);
            mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            xnl = mySourceDoc.SelectNodes("//leaf/@checksum-type");

            for (int i = 0; i < xnl.Count; i++)
            {
                if (xnl[i].Value != "md5" && xnl[i].Value != "MD5")
                {
                    c.Status = NodeType.Failed;
                }
            }
            #endregion

            return c;
        }

        public eCTD_Criteria _11_2()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._11_2);
            c.Category = eCTD_Category.leaf_attributes;
            c.ValidationCriterion = "The regenerated checksum for each file matches the value in the leaf attribute 'checksum'";
            c.Comments = "Compare the MD5 value in the xml file and the calculated MD5 value.";
            c.TypeOfCheck = "P/F";
            c.Status = NodeType.OK;

            String EURegionalXML = this.Path2Sequence + @"\m1\eu\eu-regional.xml";
            String IndexXML = this.Path2Sequence + @"\index.xml";

            #region Check the EU-Regional.xml file
            // Read file
            XmlTextReader myReader = new XmlTextReader(EURegionalXML);
            XmlDocument mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            // Get the checksum information
            XmlNodeList xnl1 = mySourceDoc.SelectNodes("//leaf/@checksum");

            // Add the xml namespace for xlink
            XmlNamespaceManager namespaces = new XmlNamespaceManager(mySourceDoc.NameTable);
            namespaces.AddNamespace("xlink", "http://www.w3c.org/1999/xlink");

            // Get the file links
            XmlNodeList xnl2 = mySourceDoc.SelectNodes("//leaf/@xlink:href",namespaces);

            // Create MD5 hashsum for every file
            for(int i=0;i<xnl1.Count;i++)
            {
                String filepath = this.Path2Sequence + @"\m1\eu\" + xnl2[i].Value;
                filepath = filepath.Replace("/", @"\");
                String md5 = MD5Calculator.ComputeMD5Checksum(filepath);

                // Compare the md5 hashsum in the file and the calculated one
                if(md5 != xnl1[i].Value)
                {
                    c.Status = NodeType.Failed;
                }

            }
            #endregion

            #region Check the index.xml file
            // Read file
            myReader = new XmlTextReader(IndexXML);
            mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            // Get the checksum information
            xnl1 = mySourceDoc.SelectNodes("//leaf/@checksum");

            // Get the file links
            xnl2 = mySourceDoc.SelectNodes("//leaf/@xlink:href", namespaces);

            // Create MD5 hashsum for every file
            for (int i = 0; i < xnl1.Count; i++)
            {
                String filepath = this.Path2Sequence + @"\"+ xnl2[i].Value;
                filepath = filepath.Replace("/", @"\");
                String md5 = MD5Calculator.ComputeMD5Checksum(filepath);

                // Compare the md5 hashsum in the file and the calculated one
                if (md5 != xnl1[i].Value)
                {
                    c.Status = NodeType.Failed;
                }

            }
            #endregion

            return c;
        }

        public eCTD_Criteria _11_3()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._11_3);
            c.Category = eCTD_Category.leaf_attributes;
            c.ValidationCriterion = "For every leaf the 'title' attribute is not empty";
            c.Comments = "";
            c.TypeOfCheck = "P/F";
            c.Status = NodeType.OK;

            String EURegionalXML = this.Path2Sequence + @"\m1\eu\eu-regional.xml";
            String IndexXML = this.Path2Sequence + @"\index.xml";

            #region Check the EU-Regional.xml file
            XmlTextReader myReader = new XmlTextReader(EURegionalXML);
            XmlDocument mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            XmlNodeList xnl = mySourceDoc.SelectNodes("//title");

            for (int i = 0; i < xnl.Count; i++)
            {
                if (xnl[i].InnerText == "")
                {
                    c.Status = NodeType.Failed;
                }
            }
            #endregion

            #region Check the index.xml file
            myReader = new XmlTextReader(IndexXML);
            mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            xnl = mySourceDoc.SelectNodes("//title");

            for (int i = 0; i < xnl.Count; i++)
            {
                if (xnl[i].InnerText == "" )
                {
                    c.Status = NodeType.Failed;
                }
            }
            #endregion

            return c;
        }


        public eCTD_Criteria _11_4()
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._11_4);
            c.Category = eCTD_Category.leaf_attributes;
            c.ValidationCriterion = "All leaves with an operation attribute value must have a value for the cross reference (xlink:href).";
            c.Comments = "";
            c.TypeOfCheck = "P/F";
            c.Status = NodeType.OK;

            String EURegionalXML = this.Path2Sequence + @"\m1\eu\eu-regional.xml";
            String IndexXML = this.Path2Sequence + @"\index.xml";

            #region Check the EU-Regional.xml file
            XmlTextReader myReader = new XmlTextReader(EURegionalXML);
            XmlDocument mySourceDoc = new XmlDocument();
            mySourceDoc.Load(myReader);
            myReader.Close();

            // Get the xml nodes with attribute operation
            XmlNodeList xnl = mySourceDoc.SelectNodes("//leaf/@operation");

            // Have a look on each "operation" node 
           foreach(XmlNode n in xnl)
            {
                // Go on if the value is new, replace or append
                if (n.Value == "new" || n.Value == "replace" || n.Value == "append")
                {
                    // Get the complete node with all information as xlink:href
                    XmlNode OwnerElement = ((XmlAttribute)n).OwnerElement;
                    String OwnerElementValue = OwnerElement.Attributes["xlink:href"].Value;
                    
                    // When we get information, go on
                    if(OwnerElementValue != "")
                    {
                        // Build up the complete path to the file and check if it exists.
                        String filepath = this.Path2Sequence + @"\m1\eu\" + OwnerElementValue;
                        filepath = filepath.Replace("/", @"\");
                        if (!File.Exists(filepath))
                        {
                            c.Status = NodeType.Failed;
                        }
                    }
                    else
                    {
                        c.Status = NodeType.Failed;
                    }
                }
                else if(n.Value != "delete")
                {
                    c.Status = NodeType.Failed;
                }
            }
            #endregion

            #region Check the index.xml file
            if (c.Status == NodeType.OK)
            {
                myReader = new XmlTextReader(IndexXML);
                mySourceDoc = new XmlDocument();
                mySourceDoc.Load(myReader);
                myReader.Close();

                // Get the xml nodes with attribute operation
                xnl = mySourceDoc.SelectNodes("//leaf/@operation");

                // Have a look on each "operation" node 
                foreach (XmlNode n in xnl)
                {
                    // Go on if the value is new, replace or append
                    if (n.Value == "new" || n.Value == "replace" || n.Value == "append")
                    {
                        // Get the complete node with all information as xlink:href
                        XmlNode OwnerElement = ((XmlAttribute)n).OwnerElement;
                        String OwnerElementValue = OwnerElement.Attributes["xlink:href"].Value;

                        // When we get information, go on
                        if (OwnerElementValue != "")
                        {
                            // Build up the complete path to the file and check if it exists.
                            String filepath = this.Path2Sequence + @"\" + OwnerElementValue;
                            filepath = filepath.Replace("/", @"\");
                            if (!File.Exists(filepath))
                            {
                                c.Status = NodeType.Failed;
                            }
                        }
                        else if (n.Value != "delete")
                        {
                            c.Status = NodeType.Failed;
                        }
                    }
                    else
                    {
                        c.Status = NodeType.Failed;
                    }
                }
            }
            #endregion

            return c;
        }
    }


    internal static class MD5Calculator
    {
        /// <summary>
        /// Returns MD5 checksum for file passed
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static String ComputeMD5Checksum(string path)
        {
            try
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, (int)fs.Length);
                    byte[] checkSum = md5.ComputeHash(fileData);
                    string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                    return result.ToLower();
                }
            }
            catch (Exception)
            {    return "ERROR";
            }
        }
    }

    public class eCTD_Criteria
    {
        public eCTD_Number Number { get; set; }
        public String Category { get; set; }
        public String ValidationCriterion { get; set; }
        public String TypeOfCheck { get; set; }
        public String Comments { get; set; }
        public String Status { get; set; }
        public String ErrorReason { get; set; }
        public bool SubNode { get { return this.sn; } set { this.sn = value; } }
        private bool sn = true;
    }

    public static class eCTD_Category
    {
        public static string ICH_DTD { get { return "ICH DTD"; } }
        public static string ICH_stylesheet { get { return "ICH stylesheet"; } }
        public static string EU_M1_DTD { get { return "EU M1 DTD"; } }
        public static string EU_M1_leaf_MOD_file { get { return "EU M1 leaf MOD file"; } }
        public static string EU_M1_envelope_MOD_file { get { return "EU M1 envelope MOD file"; } }
        public static string EU_M1_stylesheet { get { return "EU M1 stylesheet"; } }
        public static string Index_XML { get { return "Index XML"; } }
        public static string Index_MD5_txt { get { return "Index MD5 txt"; } }
        public static string EU_regional_XML { get { return "EU_regional_XML"; } }
        public static string Submission_Structure { get { return "Submission Structure"; } }
        public static string leaf_attributes { get { return "leaf attributes"; } }
        public static string Node_extensions { get { return "Node extensions"; } }
        public static string Sequence_number { get { return "Sequence number"; } }
        public static string Envelope_Attributes { get { return "Envelope Attributes"; } }
        public static string Files_Folders { get { return "Files/Folders"; } }
        public static string PDF_Files { get { return "PDF Files"; } }
    }

    public class eCTD_Number
    {
        // Number 1.1 - 1.5
        public static string _01_1 { get { return "1.1"; } }
        public static string _01_2 { get { return "1.2"; } }
        public static string _01_3 { get { return "1.3"; } }
        public static string _01_4 { get { return "1.4"; } }
        public static string _01_5 { get { return "1.5"; } }

        // Number 2.1 - 2.3
        public static string _02_1 { get { return "2.1"; } }
        public static string _02_2 { get { return "2.2"; } }
        public static string _02_3 { get { return "2.3"; } }

        // Number 3.1 - 3.5
        public static string _03_1 { get { return "3.1"; } }
        public static string _03_2 { get { return "3.2"; } }
        public static string _03_3 { get { return "3.3"; } }
        public static string _03_4 { get { return "3.4"; } }
        public static string _03_5 { get { return "3.5"; } }

        // Number 4.1 - 4.3
        public static string _04_1 { get { return "4.1"; } }
        public static string _04_2 { get { return "4.2"; } }
        public static string _04_3 { get { return "4.3"; } }

        // Number 5.1 - 5.3
        public static string _05_1 { get { return "5.1"; } }
        public static string _05_2 { get { return "5.2"; } }
        public static string _05_3 { get { return "5.3"; } }

        // Number 6.1 - 6.3
        public static string _06_1 { get { return "6.1"; } }
        public static string _06_2 { get { return "6.2"; } }
        public static string _06_3 { get { return "6.3"; } }

        // Number 7.1 - 7.6
        public static string _07_1 { get { return "7.1"; } }
        public static string _07_2 { get { return "7.2"; } }
        public static string _07_3 { get { return "7.3"; } }
        public static string _07_4 { get { return "7.4"; } }
        public static string _07_5 { get { return "7.5"; } }
        public static string _07_6 { get { return "7.6"; } }

        // Number 8.1 - 8.3
        public static string _08_1 { get { return "8.1"; } }
        public static string _08_2 { get { return "8.2"; } }
        public static string _08_3 { get { return "8.3"; } }

        // Number 9.1 - 9.9
        public static string _09_1 { get { return "9.1"; } }
        public static string _09_2 { get { return "9.2"; } }
        public static string _09_3 { get { return "9.3"; } }
        public static string _09_4 { get { return "9.4"; } }
        public static string _09_5 { get { return "9.5"; } }
        public static string _09_6 { get { return "9.6"; } }
        public static string _09_7 { get { return "9.7"; } }
        public static string _09_8 { get { return "9.8"; } }
        public static string _09_9 { get { return "9.9"; } }

        // Number 10
        public static string _10_1 { get { return "10.1"; } }

        // Number 11
        public static string _11_1 { get { return "11.1"; } }
        public static string _11_2 { get { return "11.2"; } }
        public static string _11_3 { get { return "11.3"; } }
        public static string _11_4 { get { return "11.4"; } }
        public static string _11_5 { get { return "11.5"; } }
        public static string _11_6 { get { return "11.6"; } }
        public static string _11_7 { get { return "11.7"; } }
        public static string _11_8 { get { return "11.8"; } }
        public static string _11_9 { get { return "11.9"; } }
        public static string _11_10 { get { return "11.10"; } }

        // Number 11 Best Practise
        public static string _11_BP1 { get { return "11.BP1"; } }
        public static string _11_BP2 { get { return "11.BP2"; } }

        // Number 12
        public static string _12_1 { get { return "12.1"; } }

        // Number 13
        public static string _13_1 { get { return "13.1"; } }
        public static string _13_2 { get { return "13.2"; } }
        public static string _13_3 { get { return "13.3"; } }

        // Number 14
        public static string _14_1 { get { return "14.1"; } }
        public static string _14_2 { get { return "14.2"; } }
        public static string _14_3 { get { return "14.3"; } }
        public static string _14_4 { get { return "14.4"; } }
        public static string _14_5 { get { return "14.5"; } }

        // Number 14 Best Practise
        public static string _14_BP1 { get { return "14.BP1"; } }
        public static string _14_BP2 { get { return "14.BP2"; } }
        public static string _14_BP3 { get { return "14.BP3"; } }
        public static string _14_BP4 { get { return "14.BP4"; } }
        public static string _14_BP5 { get { return "14.BP5"; } }

        // Number 15
        public static string _15_1 { get { return "15.1"; } }
        public static string _15_2 { get { return "15.2"; } }
        public static string _15_3 { get { return "15.3"; } }
        public static string _15_4 { get { return "15.4"; } }
        public static string _15_5 { get { return "15.5"; } }
        public static string _15_6 { get { return "15.6"; } }
        public static string _15_7 { get { return "15.7"; } }
        public static string _15_8 { get { return "15.8"; } }
        public static string _15_9 { get { return "15.9"; } }
        public static string _15_10 { get { return "15.10"; } }
        public static string _15_11 { get { return "15.11"; } }
        public static string _15_12 { get { return "15.12"; } }

        public eCTD_Number(String no)
        {
            this.no_intern = no;
        }

        // public get method
        public String value { get { return this.no_intern; } }

        // private
        private String no_intern;
    }
}
