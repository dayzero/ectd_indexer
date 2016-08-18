using System.Windows.Forms;
using System.IO;

namespace eCTD_indexer
{
    partial class FileExplorerUserControl
    {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
       
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileExplorerUserControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FolderView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList();
            this.FileListView = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuFileListView = new System.Windows.Forms.ContextMenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFolderView = new System.Windows.Forms.ContextMenuStrip();
            this.tsmiCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuFileListView.SuspendLayout();
            this.contextMenuFolderView.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.splitContainer1.Panel1.Controls.Add(this.FolderView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FileListView);
            this.splitContainer1.Size = new System.Drawing.Size(800, 500);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // FolderView
            // 
            this.FolderView.AllowDrop = true;
            this.FolderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderView.ImageIndex = 0;
            this.FolderView.ImageList = this.imageList;
            this.FolderView.Location = new System.Drawing.Point(0, 0);
            this.FolderView.Margin = new System.Windows.Forms.Padding(2);
            this.FolderView.Name = "FolderView";
            this.FolderView.SelectedImageIndex = 0;
            this.FolderView.Size = new System.Drawing.Size(248, 500);
            this.FolderView.TabIndex = 1;
            this.FolderView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FolderView_DragDrop);
            this.FolderView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FolderView_DragEnter);
            this.FolderView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FolderView_MouseClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Document");
            this.imageList.Images.SetKeyName(1, "Folder");
            // 
            // FileListView
            // 
            this.FileListView.AllowDrop = true;
            this.FileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Type,
            this.LastModified});
            this.FileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileListView.Location = new System.Drawing.Point(0, 0);
            this.FileListView.Margin = new System.Windows.Forms.Padding(2);
            this.FileListView.Name = "FileListView";
            this.FileListView.Size = new System.Drawing.Size(549, 500);
            this.FileListView.SmallImageList = this.imageList;
            this.FileListView.TabIndex = 1;
            this.FileListView.UseCompatibleStateImageBehavior = false;
            this.FileListView.View = System.Windows.Forms.View.Details;
            this.FileListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.FileListView_ItemDrag);
            this.FileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileListView_DragDrop);
            this.FileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileListView_DragEnter);
            this.FileListView.DoubleClick += new System.EventHandler(this.FileListView_DoubleClick);
            this.FileListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileListView_MouseClick);
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 160;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 88;
            // 
            // LastModified
            // 
            this.LastModified.Text = "Last Modified";
            this.LastModified.Width = 98;
            // 
            // contextMenuFileListView
            // 
            this.contextMenuFileListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem4});
            this.contextMenuFileListView.Name = "contextMenuStrip";
            this.contextMenuFileListView.Size = new System.Drawing.Size(117, 70);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem3.Text = "Open...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem1.Text = "Delete...";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(116, 22);
            this.toolStripMenuItem4.Text = "Info...";
            // 
            // contextMenuFolderView
            // 
            this.contextMenuFolderView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateFolder});
            this.contextMenuFolderView.Name = "contextMenuFolderView";
            this.contextMenuFolderView.Size = new System.Drawing.Size(153, 48);
            // 
            // tsmiCreateFolder
            // 
            this.tsmiCreateFolder.Name = "tsmiCreateFolder";
            this.tsmiCreateFolder.Size = new System.Drawing.Size(152, 22);
            this.tsmiCreateFolder.Text = "Create Folder";
            this.tsmiCreateFolder.Click += new System.EventHandler(this.tsmiCreateFolder_Click);
            // 
            // FileExplorerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(800, 500);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuFileListView.ResumeLayout(false);
            this.contextMenuFolderView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView FileListView;
        private new System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader LastModified;
        private TreeView FolderView;
        private ContextMenuStrip contextMenuFileListView;
        private ToolStripMenuItem toolStripMenuItem1;
        private ContextMenuStrip contextMenuFolderView;
        private ToolStripMenuItem tsmiCreateFolder;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
    }
}

