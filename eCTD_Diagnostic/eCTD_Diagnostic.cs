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

            // Insert Criteria Category
            eCTD_Criteria _01header = new eCTD_Criteria();
            _01header.SubNode = false;
            _01header.Category = eCTD_Category.ICH_DTD;
            cl.Add(_01header);

            // Check every criteria.
            cl.Add(this._01_1());
            cl.Add(this._01_2());

            // Sum-up the status of all sub-nodes
            cl[0].Status = this.SumUpSubItems(cl, 1, 1, 2);

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
        /// </summary>
        /// <returns></returns>
        public eCTD_Criteria _01_1() 
        {
            eCTD_Criteria c = new eCTD_Criteria();
            c.Number = new eCTD_Number(eCTD_Number._01_1);
            c.Category =  eCTD_Category.ICH_DTD;
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
