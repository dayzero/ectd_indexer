using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace eCTD_indexer
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            this.Text = String.Format("Info über {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}-20180105", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = "Released on 2018-01";//AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assemblyattributaccessoren

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        /// <summary>
        /// Show the description.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutBox_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("# eCTD-indexer (EU Module 1)\r\n");
            sb.Append("The project is based on eCTD-indexer of Ymir Vesteinsson (https://github.com/dayzero/ectd_indexer).\r\n");
            sb.Append("With eCTD-indexer you are able to create and modify eCTD dossiers.\r\n\r\n\r\n");

            sb.Append("# Documentation about eCTD\r\n");
            sb.Append("For more information about the EU Module 1 please have a look at http://esubmission.ema.europa.eu/eumodule1/ \r\n");

            sb.Append("Links to relevant guidelines:\r\n");
            sb.Append("* eCTD Specification and Related Files: http://estri.ich.org/eCTD/index.htm/\r\n");
            sb.Append("* Notice to applicants - current EU Module 1, electronic application form: http://ec.europa.eu/health/documents/eudralex/vol-2/index_en.htm \r\n");
            sb.Append("* EU eSubmission guidelines: http://esubmission.ema.europa.eu/ \r\n");
            sb.Append("* eCTD EU Validation Criteria v6 http://esubmission.ema.europa.eu/tiges/docs/eCTD%20EU%20Validation%20Criteria%20v6%201_March%202016-Final.xlsx \r\n");
            sb.Append("* Heads of Medicines Agencies - Procedural Guidance for eSubmissions: http://www.hma.eu/277.html \r\n\r\n\r\n\r\n");

            sb.Append("# Copyright\r\n");
            sb.Append("eCTD-indexer is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by\r\n");
            sb.Append("the Free Software Foundation, either version 3 of the License, or (at your option) any later version.\r\n");

            sb.Append("The free Iconset \"Oxygen\" is used: http://www.iconarchive.com/show/oxygen-icons-by-oxygen-icons.org.html \r\n");
            sb.Append("This Iconset is made under the terms of the GNU Lesser General Public License: https://en.wikipedia.org/wiki/GNU_Lesser_General_Public_License \r\n");

            sb.Append("The free Iconset \"Iconset: 3D Vol.2 Icons by La Glanz Studio\" is also used http://www.iconarchive.com/show/3d-vol2-icons-by-3dlb.html \r\n");
            sb.Append("This set of Icons is Freeware.");

            this.textBoxDescription.Text = sb.ToString();

            this.labelVersion.Text += " - EU M1 v.3.0.1, eCTD v.3.2";
        }
    }
}
