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
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace eCTD_Diagnostic
{
    public class eCTD_TreeViewItem : TreeViewItem
    {
        public eCTD_TreeViewItem() { }
        
        public eCTD_TreeViewItem(String Nodetype, String Number, String CriteriaDescription, String Comment)
        {
            // Create a grid
            Grid treeviewgrid = new Grid();

            // Create the grid columns
            ColumnDefinition gridCol1 = new ColumnDefinition(); // Image
            ColumnDefinition gridCol2 = new ColumnDefinition(); // Number
            ColumnDefinition gridCol3 = new ColumnDefinition(); // Validation Criterion
            ColumnDefinition gridCol4 = new ColumnDefinition(); // Comment
            gridCol1.MinWidth = 32;
            gridCol2.MinWidth = 100;
            gridCol3.MinWidth = 550;
            gridCol4.MinWidth = 400;
            treeviewgrid.ColumnDefinitions.Add(gridCol1);
            treeviewgrid.ColumnDefinitions.Add(gridCol2);
            treeviewgrid.ColumnDefinitions.Add(gridCol3);
            treeviewgrid.ColumnDefinitions.Add(gridCol4);

            // Create Image
            Image image = new Image();

            if (Nodetype == NodeType.OK)
            {
                image.Source = new BitmapImage (new Uri(@"pack://siteoforigin:,,,/Resources/Actions-dialog-ok-apply-icon.png", UriKind.Absolute));
            }
            else if (Nodetype == NodeType.Failed)
            {
                image.Source = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Actions-edit-delete-icon.png", UriKind.Absolute));
            }
            else if (Nodetype == NodeType.Warning)
            {
                image.Source = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/warning-icon.png", UriKind.Absolute));
            }

            image.Width = 32;
            image.Height = 32;

            // Node Identifier
            Label lbl = new Label();
            lbl.Content = Number;
            lbl.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            // Node Criteria Description
            Label cd = new Label();
            cd.Content = CriteriaDescription;
            if (Number == "")
            {
                cd.FontWeight = System.Windows.FontWeights.Bold;
            }
            cd.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            // Node Criteria Description
            Label co = new Label();
            co.Content = Comment;
            co.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            // Set the components to the columns.
            Grid.SetColumn(image, 0);
            Grid.SetColumn(lbl, 1);
            Grid.SetColumn(cd, 2);
            Grid.SetColumn(co, 3);

            // Add into grid
            treeviewgrid.Children.Add(image);
            treeviewgrid.Children.Add(lbl);
            treeviewgrid.Children.Add(cd);
            treeviewgrid.Children.Add(co);

            // Assign grid to header
            this.Header = treeviewgrid;            
        }
    }

    public static class NodeType {
        public static string OK { get { return "OK"; } }
        public static string Failed { get { return "Failed"; } }
        public static string Warning { get { return "Warning"; } }
    }
}
