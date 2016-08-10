/*
 * Here you can find the original project on github: https://github.com/anmolvarshney05/File-Explorer/
 * This is a fork of this project.
 * 
 * eCTD-indexer and FileExplorer are free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * eCTD-indexer and FileExplorer is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace File_Explorer
{
    public partial class FileExplorerUserControl : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FileExplorerUserControl()
        {
            InitializeComponent();
            FileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            FolderView.NodeMouseClick += FolderView_NodeMouseClick;
        }

        // Class Variables
        private String selectedpath;
        private Object selectedpathtag;
        private String rootDirectory;

        public void PopulateTreeView(String rootDirectory)
        {
            this.rootDirectory = rootDirectory;
            this.rootDirectory = this.rootDirectory.Substring(0, this.rootDirectory.Length - 4);

            TreeNode rootnode;

            DirectoryInfo info = new DirectoryInfo(rootDirectory);
            if (info.Exists)
            {
                rootnode = new TreeNode(info.Name,1,1);
                rootnode.Tag = info;
                GetDirectories(info.GetDirectories(), rootnode);
                FolderView.Nodes.Clear();
                FolderView.Nodes.Add(rootnode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode rootNode)
        {
            TreeNode aNode;
            DirectoryInfo[] subsubDirs;
            FileInfo[] subsubFiles;
            foreach (DirectoryInfo item in subDirs)
            {
                aNode = new TreeNode(item.Name, 1, 1);
                aNode.Tag = item;
                subsubDirs = item.GetDirectories();
                subsubFiles = item.GetFiles();
                if (subsubDirs.Length != 0)
                {
                    aNode.ImageKey = "Folder";
                    GetDirectories(subsubDirs, aNode);
                }
                else if(subsubFiles.Length !=0)
                {
                    aNode.ImageKey = "Folder";
                }
                else
                {
                    aNode.ImageKey = "Document";
                }
                rootNode.Nodes.Add(aNode);
            }
        }
        
        /// <summary>
        /// Triggers when a user clicks on a node of the FolderView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            this.selectedpathtag = newSelected.Tag;

            if (newSelected.Parent == null)
            {
                DirectoryInfo nodeDirInfo = (DirectoryInfo)this.selectedpathtag;
                this.selectedpath = nodeDirInfo.ToString();
            } 
            // If there are parent nodes the path has to be build up.
            else
            {
                DirectoryInfo nodeDirInfo = (DirectoryInfo)this.selectedpathtag;
                TreeNode previousNode = newSelected.Parent;
                String path = nodeDirInfo.ToString();
                this.selectedpath = this.rootDirectory;

                while (previousNode != null)
                {
                    path = previousNode.Text + @"\" + path;
                    previousNode = previousNode.Parent;
                }

                this.selectedpath += path;
            }

            // Show the content of the folder in the right list.
            this.FolderView_ShowFolder();
        }

        /// <summary>
        /// Refresh the view of the folder.
        /// </summary>
        public void FolderView_ShowFolder()
        {
            FileListView.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)this.selectedpathtag;
            //this.selectedpath = nodeDirInfo.ToString(); // Store the selected path for drag&drop

            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"),
                     new ListViewItem.ListViewSubItem(item,
                        dir.LastAccessTime.ToString())};
                item.SubItems.AddRange(subItems);
                FileListView.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
                     new ListViewItem.ListViewSubItem(item,
                        file.LastAccessTime.ToString())};
                item.SubItems.AddRange(subItems);
                FileListView.Items.Add(item);
            }

            FileListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void FileListView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
          
        }

        /// <summary>
        /// Copy file to the selected path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileListView_DragDrop(object sender, DragEventArgs e)
        {
            String [] filenames = (String [])e.Data.GetData(DataFormats.FileDrop, false);
            String targetfilename = this.selectedpath + "\\" + Path.GetFileName(filenames[0]);
            File.Copy(filenames[0], targetfilename, true);
            this.FolderView_ShowFolder();
        }

        /// <summary>
        /// Open the file on which the user has doubleclicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileListView_DoubleClick(object sender, EventArgs e)
        {
            if(this.FileListView.SelectedItems.Count == 1)
            {
                System.Diagnostics.Process.Start(this.selectedpath + @"\" + FileListView.SelectedItems[0].Text);
            }
        }
    }
}
