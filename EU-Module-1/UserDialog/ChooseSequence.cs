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
    public partial class ChooseSequence : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sequences"></param>
        public ChooseSequence(List<String> sequences, String fullpath)
        {
            InitializeComponent();

            this.selectablesequences = new List<pathinfos>();
            this.dirfullpath = fullpath;

            foreach (String dir in sequences)
            {
                selectablesequences.Add(new pathinfos(dir));
            }
        }

        // Private class variables
        private List<pathinfos> selectablesequences;
        private String dirfullpath;
        private String selectedseq;

        public String SelectedSequence { get { return this.selectedseq; } }

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
            if (objectListView.SelectedItem != null)
            {
                this.selectedseq = objectListView.SelectedItem.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ChooseDirectory_Load(object sender, EventArgs e)
        {
            objectListView.SetObjects(selectablesequences);
        }

        private void objectListView_SelectionChanged(object sender, EventArgs e)
        {
            this.btOK.Enabled = true;
        }
    }
}
