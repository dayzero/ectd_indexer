using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace eCTD_indexer.UserDialog
{
    public partial class CreateDirectory : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directories"></param>
        public CreateDirectory(List<String> directories, String fullpath)
        {
            InitializeComponent();

            this.selectablefolder = new List<pathinfos>();
            this.dirfullpath = fullpath;

            foreach (String dir in directories)
            {
                selectablefolder.Add(new pathinfos(dir));
            }
        }

        // Private class variables
        private List<pathinfos> selectablefolder;
        private String dirfullpath;

        /// <summary>
        /// Fill the directory list after loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateFolder_Load(object sender, EventArgs e)
        {
            objectListView.SetObjects(selectablefolder);
        }

        /// <summary>
        /// Cancel this dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Create the directories choosen by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOK_Click(object sender, EventArgs e)
        {
            System.Collections.ArrayList checkedbyuser = (System.Collections.ArrayList)objectListView.CheckedObjects;

            foreach(pathinfos pi in checkedbyuser)
            {
                Directory.CreateDirectory(this.dirfullpath + @"\" + pi.Path);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    /// <summary>
    /// Class which stores the item informations of the list.
    /// </summary>
    class pathinfos
    {
        public pathinfos(String Directory)
        {
            this.pathname = Directory;
        }

        private bool is_checked;
        private String pathname;

        public bool getChecked { get { return this.is_checked; } set { this.is_checked = value; } }
        public String Path { get { return this.pathname; } }
    }
}
