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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace eCTD_Diagnostic
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public String Path2Sequence;

        private void eCTD_Diagnostic_MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Validate the whole dossier
            List<eCTD_Criteria> cl = new eCTD_Diagnostics(this.Path2Sequence).Validate();

            // Store the current TreeViewItem
            eCTD_TreeViewItem current = null;
            eCTD_TreeViewItem _1stlevel = new eCTD_TreeViewItem();
            eCTD_TreeViewItem _2stlevel;

            for(int i=0;i<cl.Count;i++)
            {
                if (cl[i].SubNode)
                {
                    _2stlevel = new eCTD_TreeViewItem(cl[i].Status, cl[i].Number.value, cl[i].ValidationCriterion, cl[i].Comments);
                    current.Items.Add(_2stlevel);
                    current = _1stlevel;
                }
                else
                {
                    _1stlevel = new eCTD_TreeViewItem(cl[i].Status, "", cl[i].Category, "");
                    this.tvResult.Items.Add(_1stlevel);
                    current = _1stlevel;
                }
            }

            // Expand all items
            for (int n = 0; n < this.tvResult.Items.Count; n++)
            {
                _1stlevel = (eCTD_TreeViewItem)this.tvResult.Items[n];
                _1stlevel.ExpandSubtree();
            }
        }
    }
}
