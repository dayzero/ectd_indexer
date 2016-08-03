/*
 * Here you can find the original project on github: https://github.com/anmolvarshney05/File-Explorer/
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
        private void PopulateTreeView()
        {
            TreeNode rootnode;

            DirectoryInfo info = new DirectoryInfo(@"C:\Users\Fabian\Desktop\eCTD_Tests");
            if (info.Exists)
            {
                rootnode = new TreeNode(info.Name,1,1);
                rootnode.Tag = info;
                GetDirectories(info.GetDirectories(), rootnode);
                treeView1.Nodes.Add(rootnode);
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
        public FileExplorerUserControl()
        {
            InitializeComponent();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            PopulateTreeView();
            treeView1.NodeMouseClick += TreeView1_NodeMouseClick;
         }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
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
                listView1.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),
                     new ListViewItem.ListViewSubItem(item,
                        file.LastAccessTime.ToString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
