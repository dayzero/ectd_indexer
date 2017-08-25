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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileExplorerUserControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FolderView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.FileListView = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuFileListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmflOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmflDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmflInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFolderView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
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
            this.splitContainer1.Size = new System.Drawing.Size(799, 544);
            this.splitContainer1.SplitterDistance = 246;
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
            this.FolderView.Size = new System.Drawing.Size(246, 544);
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
            this.FileListView.Scrollable = false;
            this.FileListView.Size = new System.Drawing.Size(550, 544);
            this.FileListView.SmallImageList = this.imageList;
            this.FileListView.TabIndex = 1;
            this.FileListView.UseCompatibleStateImageBehavior = false;
            this.FileListView.View = System.Windows.Forms.View.Details;
            this.FileListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.FileListView_ItemDrag);
            this.FileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileListView_DragDrop);
            this.FileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileListView_DragEnter);
            this.FileListView.DoubleClick += new System.EventHandler(this.FileListView_DoubleClick);
            this.FileListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileListView_MouseClick);
            this.FileListView.Resize += new System.EventHandler(this.FileListView_Resize);
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 163;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 88;
            // 
            // LastModified
            // 
            this.LastModified.Text = "Last Modified";
            this.LastModified.Width = 75;
            // 
            // contextMenuFileListView
            // 
            this.contextMenuFileListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmflOpen,
            this.cmflDelete,
            this.cmflInfo});
            this.contextMenuFileListView.Name = "contextMenuStrip";
            this.contextMenuFileListView.Size = new System.Drawing.Size(117, 70);
            // 
            // cmflOpen
            // 
            this.cmflOpen.Name = "cmflOpen";
            this.cmflOpen.Size = new System.Drawing.Size(116, 22);
            this.cmflOpen.Text = "Open...";
            this.cmflOpen.Click += new System.EventHandler(this.cmflOpen_Click);
            // 
            // cmflDelete
            // 
            this.cmflDelete.Name = "cmflDelete";
            this.cmflDelete.Size = new System.Drawing.Size(116, 22);
            this.cmflDelete.Text = "Delete...";
            this.cmflDelete.Click += new System.EventHandler(this.cmflDelete_Click);
            // 
            // cmflInfo
            // 
            this.cmflInfo.Name = "cmflInfo";
            this.cmflInfo.Size = new System.Drawing.Size(116, 22);
            this.cmflInfo.Text = "Info...";
            this.cmflInfo.Click += new System.EventHandler(this.cmflInfo_Click);
            // 
            // contextMenuFolderView
            // 
            this.contextMenuFolderView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateFolder,
            this.tsmiOpen});
            this.contextMenuFolderView.Name = "contextMenuFolderView";
            this.contextMenuFolderView.Size = new System.Drawing.Size(214, 48);
            // 
            // tsmiCreateFolder
            // 
            this.tsmiCreateFolder.Name = "tsmiCreateFolder";
            this.tsmiCreateFolder.Size = new System.Drawing.Size(213, 22);
            this.tsmiCreateFolder.Text = "Create Folder";
            this.tsmiCreateFolder.Click += new System.EventHandler(this.tsmiCreateFolder_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(213, 22);
            this.tsmiOpen.Text = "Open in Windows Explorer";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // FileExplorerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(799, 544);
            this.Load += new System.EventHandler(this.FileExplorerUserControl_Load);
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
        private ToolStripMenuItem cmflDelete;
        private ContextMenuStrip contextMenuFolderView;
        private ToolStripMenuItem tsmiCreateFolder;
        private ToolStripMenuItem cmflOpen;
        private ToolStripMenuItem cmflInfo;
        private ToolStripMenuItem tsmiOpen;
    }
}

