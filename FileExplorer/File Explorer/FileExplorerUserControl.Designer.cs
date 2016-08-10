using System.Windows.Forms;
using System.IO;

namespace File_Explorer
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.FileListView = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.FolderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderView.ImageIndex = 0;
            this.FolderView.ImageList = this.imageList1;
            this.FolderView.Location = new System.Drawing.Point(0, 0);
            this.FolderView.Margin = new System.Windows.Forms.Padding(2);
            this.FolderView.Name = "FolderView";
            this.FolderView.SelectedImageIndex = 0;
            this.FolderView.Size = new System.Drawing.Size(248, 500);
            this.FolderView.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Document");
            this.imageList1.Images.SetKeyName(1, "Folder");
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
            this.FileListView.SmallImageList = this.imageList1;
            this.FileListView.TabIndex = 1;
            this.FileListView.UseCompatibleStateImageBehavior = false;
            this.FileListView.View = System.Windows.Forms.View.Details;
            this.FileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileListView_DragDrop);
            this.FileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileListView_DragEnter);
            this.FileListView.DoubleClick += new System.EventHandler(this.FileListView_DoubleClick);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView FileListView;
        private new System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader LastModified;
        private TreeView FolderView;
    }
}

