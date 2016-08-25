using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eCTD_indexer.UserDialog
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AskClose = this.cbCloseApp.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            this.cbCloseApp.Checked = Properties.Settings.Default.AskClose;
        }
    }
}
