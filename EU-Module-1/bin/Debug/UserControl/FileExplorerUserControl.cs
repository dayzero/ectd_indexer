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

namespace eCTD_indexer
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

            this.eCTDirs = new eCTD_Directories();
        }

        // private Class Variables
        private String selectedpath;
        private Object selectedpathtag;
        private String rootDirectory;
        private bool privateDragAndDrop;
        private String privateDragSource;
        private eCTD_Directories eCTDirs;

        /// <summary>
        /// Close the Dossier by clearing the folder and file list.
        /// </summary>
        public void CloseDossier()
        {
            this.FileListView.Clear();
            this.FolderView.Nodes.Clear();
        }
        
        public void PopulateTreeView()
        {
            if (this.rootDirectory != null)
            {
                if (this.rootDirectory != "")
                {
                    this.PopulateTreeView(this.rootDirectory + this.FolderView.Nodes[0].Text);
                }
            }
        }

        /// <summary>
        /// Build up the folder at the left TreeView.
        /// </summary>
        /// <param name="rootDirectory"></param>
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

        /// <summary>
        /// Build up the directory tree on the left side.
        /// </summary>
        /// <param name="subDirs"></param>
        /// <param name="rootNode"></param>
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
                aNode.ImageKey = "Folder";
                if (subsubDirs.Length != 0)
                {
                    GetDirectories(subsubDirs, aNode);
                }
                /*else if(subsubFiles.Length !=0)
                {
                    aNode.ImageKey = "Folder";
                }
                else
                {
                    aNode.ImageKey = "Folder"; // Document
                }*/
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
            try
            {
                if (this.selectedpathtag != null)
                {
                    FileListView.Items.Clear();
                    DirectoryInfo nodeDirInfo = (DirectoryInfo)this.selectedpathtag;

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
            }
            catch (DirectoryNotFoundException) { this.PopulateTreeView(); }
        }

        private void FileListView_DragEnter(object sender, DragEventArgs e)
        {
            if (this.privateDragAndDrop)
            { e.Effect = e.AllowedEffect; }
            else
            { e.Effect = DragDropEffects.All; }
        }

        /// <summary>
        /// Copy or move a file to the selected path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileListView_DragDrop(object sender, DragEventArgs e)
        {
            if (!this.privateDragAndDrop)
            {
                String[] filenames = (String[])e.Data.GetData(DataFormats.FileDrop, false);
                String targetfilename = this.selectedpath + "\\" + Path.GetFileName(filenames[0]);
                File.Copy(filenames[0], targetfilename, true);            
            }
            else
            {
                var pos = this.FileListView.PointToClient(new Point(e.X, e.Y));
                var hit = this.FileListView.HitTest(pos);
                if (hit.Item != null)
                {
                    ListViewItem targetfolder = hit.Item;
                    String target = this.selectedpath + @"\" + targetfolder.Text + @"\" + this.FileListView.SelectedItems[0].Text;
                    File.Move(this.privateDragSource, target);
                }
            }

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
                if (this.FileListView.SelectedItems[0].SubItems.Count == 3)
                {
                    if (this.FileListView.SelectedItems[0].SubItems[1].Text == "File")
                    {
                        System.Diagnostics.Process.Start(this.selectedpath + @"\" + FileListView.SelectedItems[0].Text);
                    }
                    else if (this.FileListView.SelectedItems[0].SubItems[1].Text == "Directory")
                    {
                        // TODO
                    }
                }
            }
        }
        
        /// <summary>
        /// Fires if a user starts a FileListView-internal drag&drop action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            privateDragAndDrop = true;
            ListViewItem movingnode = (ListViewItem)e.Item;
            this.privateDragSource = this.selectedpath + @"\" + movingnode.Text;
            DoDragDrop(e.Item, DragDropEffects.Move);

            privateDragAndDrop = false;
            this.privateDragSource = "";
        }

        /// <summary>
        /// Copy or move a file to a folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderView_DragDrop(object sender, DragEventArgs e)
        {
            if (this.FileListView.SelectedItems[0].SubItems[1].Text == "File")
            {
                var pos = this.FolderView.PointToClient(new Point(e.X, e.Y));
                var hit = this.FolderView.HitTest(pos);
                if (hit.Node != null)
                {
                    DirectoryInfo nodeDirInfo = (DirectoryInfo)this.selectedpathtag;
                    TreeNode previousNode = hit.Node.Parent;
                    String path = "";
                    String targetfolder = this.rootDirectory;

                    while (previousNode != null)
                    {
                        path = previousNode.Text + @"\" + path;
                        previousNode = previousNode.Parent;
                    }

                    targetfolder += path;

                    String target = targetfolder + hit.Node.Text + @"\" + this.FileListView.SelectedItems[0].Text;
                    File.Move(this.privateDragSource, target);
                }
            }

            this.FolderView_ShowFolder();
        }

        private void FolderView_DragEnter(object sender, DragEventArgs e)
        {
            if (this.privateDragAndDrop)
            { e.Effect = e.AllowedEffect; }
            else
            { e.Effect = DragDropEffects.All; }
        }

        /// <summary>
        /// Show the context menu of FileListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (FileListView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuFileListView.Show(Cursor.Position);
                }
            } 
        }

        /// <summary>
        /// Show the context menu of FolderView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FolderView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                FolderView.SelectedNode = FolderView.GetNodeAt(e.X, e.Y);

                if (FolderView.SelectedNode != null)
                {
                    contextMenuFolderView.Show(FolderView, e.Location);
                }
            } 
        }

        /// <summary>
        /// Create a folder via context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCreateFolder_Click(object sender, EventArgs e)
        {            
            UserDialog.CreateDirectory cf = new UserDialog.CreateDirectory(this.eCTDirs.getSubDirectories(FolderView.SelectedNode.Text), this.selectedpath);
            if(cf.ShowDialog() == DialogResult.OK)
            {
                // Refresh the view on the folders and files.
                FolderView_ShowFolder();
                PopulateTreeView();
            }            
        }

        /// <summary>
        /// Opens the selected folder in the Windows Explorer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.selectedpath);
        }

        private void cmflOpen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This method has to be implemented!", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmflDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This method has to be implemented!", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmflInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This method has to be implemented!", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
