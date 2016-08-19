using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace eCTD_indexer.UserDialogue
{
    public partial class CreateDossier : Form
    {
        public CreateDossier()
        {
            InitializeComponent();
        }

        // Private variables
        private String path = "";

        // Public Attribute
        public String SequencePath { get { return this.path; } }

        private void btOK_Click(object sender, EventArgs e)
        {
            // Pattern
            String pat = @"[0-9]{4}";

            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);

            // Match the regular expression pattern against a text string.
            Match m = r.Match(this.tbSequencePath.Text);

            // If the user enter a correct sequence path.
            if(m.Success)
            {
                //  Deposite the sequence path
                this.path = this.tbSequencePath.Text;

                // Make it clear that this result is verified.
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                // Close this Dialog
                this.Close();
            } else
            {
                // Tell the user what is wrong
                MessageBox.Show("The sequence path is incorrect. The path has to consist of four digits.", "Wrong sequence path...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            // Close this Dialog without a verified result.
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
