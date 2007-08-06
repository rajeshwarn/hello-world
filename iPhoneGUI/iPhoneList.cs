using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Manzana;
using System.IO;

namespace iPhoneGUI
{
    public partial class iPhoneList: Form
    {
        internal iPhone myPhone = new iPhone();
        internal Boolean connected = false;
        internal Boolean connecting = false;
        internal String lastSaveFolder = "";

        public iPhoneList() {
            InitializeComponent();
            //myPhone.Connect += new ConnectEventHandler(Connecting);
            //myPhone.Disconnect += new ConnectEventHandler(Connecting);
        }

        public void FillTree() {
            treeFolders.Nodes.Clear();
            treeFolders.Nodes.Add("/var/empty","/var/empty");
            FillTree(treeFolders.TopNode, treeFolders.TopNode.Text);
        }

        public void FillTree(TreeNode thisNode, String path) {
            thisNode.Nodes.Clear();
            AddNodes(thisNode, path);

            //treeFolders.Nodes.Add(AddNodes(path, name, levels));
            treeFolders.Nodes[0].Expand();
            //treeFolders.SelectedNode = treeFolders.Nodes[0];
        }

        public void EmptyTree() {
            treeFolders.Nodes.Clear();
            listFiles.Items.Clear();
        }

        public void AddNodes(TreeNode thisNode, String path) {
            AddNodes(thisNode, path, -1);
        }

        public void AddNodes(TreeNode thisNode, String path, Int32 getLevels) {
            String[] dirNames;
            textStatus.Text = "Adding folder " + thisNode.Text;
            dirNames = myPhone.GetDirectories(path);
            if (dirNames.Length > 0 && getLevels != 0) {
                for (int i = 0; i < dirNames.Length; i++) {
                    TreeNode childNode = new TreeNode(dirNames[i]);
                    childNode.Name = path + "/" + dirNames[i];
                    AddNodes(childNode, path + "/" + dirNames[i], (getLevels - 1));
                    thisNode.Nodes.Add(childNode);
                    Application.DoEvents();
                }
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            if (!connecting && !connected){
                if (myPhone.IsConnected) {
                    connecting = true;
                    //Connecting(myPhone, null);
                    this.treeFolders.Nodes.Clear();
                    FillTree();
                    this.Show();
                    connecting = false;
                    connected = true;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            RefreshFiles();
        }

        private void RefreshFiles() {
            myPhone.GetFiles("/");
            FillTree();
            this.Show();
            connecting = false;
            connected = true;
        }

        private void treeFolders_AfterSelect(object sender, TreeViewEventArgs e) {
            String currentPath = e.Node.FullPath.Replace("\\","/");
            ShowFiles(currentPath);
        }

        private void ShowFiles(String path) {
            String[] files = myPhone.GetFiles(path);
            this.listFiles.Items.Clear();
            Int32 fileSize;
            String fileType;
            foreach (String file in files) {
                ListViewItem thisFile = new ListViewItem(file);
                myPhone.GetFileInfoDetails(path + "/" + file, out fileSize, out fileType);
                thisFile.SubItems.Add(fileSize.ToString());
                if (fileType.Equals("REG")) thisFile.SubItems.Add("---");
                else thisFile.SubItems.Add(fileType);
                listFiles.Items.Add(thisFile);
            }
        }

        private void listFiles_MouseClick(object sender, MouseEventArgs e) {

        }

        private void treeFolders_MouseClick(object sender, MouseEventArgs e) {

        }

        private void listFiles_DragEnter(object sender, DragEventArgs e) {
            if (((e.AllowedEffect & DragDropEffects.Copy) != 0) && (e.Data.GetDataPresent("FilenameW"))) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listFiles_DragDrop(object sender, DragEventArgs e) {
            TreeNode thisNode = treeFolders.SelectedNode;
            String destPath = thisNode.FullPath.Replace("\\", "/");
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);

            for (int i = 0; i < files.Length; i++) {
                CopyToDevice(files[i], destPath);
            }
            // Force a refresh
            FillTree(thisNode, destPath);
            ShowFiles(destPath);
        }

        internal void CopyToDevice(String srcFile, String destPath) {
            FileInfo thisFile = new FileInfo(srcFile);
            Console.WriteLine(thisFile.Attributes.ToString());
            if (thisFile.Attributes == FileAttributes.Directory) {
                String[] files = Directory.GetFiles(thisFile.FullName);
                for (Int32 i = 0; i < files.Length; i++) {
                    String newDirectory = destPath + "/" + thisFile.Name;
                    myPhone.CreateDirectory(newDirectory);
                    CopyToDevice(files[i], newDirectory);
                }
            } else {
                Byte[] fileBuffer = new Byte[1024];
                Int32 length;
                textStatus.Text = "Copying " + thisFile.FullName;
                using (Stream inStream = File.OpenRead(thisFile.FullName)) {
                    using (Stream outStream = 
                        iPhoneFile.OpenWrite(myPhone, destPath + "/" + Path.GetFileName(thisFile.FullName))) {
                        while ((length = inStream.Read(fileBuffer, 0, fileBuffer.Length)) > 0) {
                            outStream.Write(fileBuffer, 0, length);
                        }
                    }
                }
                Application.DoEvents();
            }
        }


        private void treeFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            //foreach (TreeNode childNode in e.Node.Nodes) {
            //    FillTree(childNode, childNode.FullPath.Replace("\\", "/"));
            //}
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            String path = treeFolders.SelectedNode.FullPath.Replace("\\","/");
            TreeNode thisNode = treeFolders.SelectedNode;
            Boolean deletedFolder = false;
            if (listFiles.SelectedItems.Count > 0) {
                foreach (ListViewItem item in listFiles.SelectedItems) {
                    Console.WriteLine(path + ", " + item.Name);
                    if (myPhone.IsDirectory(path + "/" + item.Text))
                        deletedFolder = true;
                    myPhone.DeleteFromDevice(path + "/" + item.Text);
                }
            }
            if (deletedFolder) 
                FillTree(thisNode, path);
            ShowFiles(path);
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e) {
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void CreateFolder() {
            timerMain.Enabled = false;
            TreeNode selectedNode = treeFolders.SelectedNode;
            String inPath = selectedNode.FullPath.Replace("\\", "/");
            using (NewFolderForm frmNew = new NewFolderForm()) {
                frmNew.ActionText = "Folder Name: " + inPath + "/";
                frmNew.ShowDialog();
                if (frmNew.DialogResult == DialogResult.OK) {
                    try {
                        myPhone.CreateDirectory(inPath + "/" + frmNew.FolderName);
                        FillTree(selectedNode, inPath);
                        ShowFiles(inPath);
                    }
                    catch (Exception err) {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void CopyItemsFromDevice() {
            using (FolderBrowserDialog saveTo = new FolderBrowserDialog()) {
                saveTo.SelectedPath = lastSaveFolder;
                DialogResult result = saveTo.ShowDialog();
                if (result == DialogResult.OK) {
                    String savePath = saveTo.SelectedPath;
                    String fromPath = treeFolders.SelectedNode.FullPath.Replace("\\", "/");
                    foreach (ListViewItem item in listFiles.SelectedItems) {
                        CopyItemFromDevice(savePath, fromPath, item.Text);
                    }
                }
            }
        }

        private void CopyItemFromDevice(String savePath, String fromPath, String item){
            String itemPath = fromPath + "/" + item;
            if (myPhone.IsDirectory(itemPath)){
                String newPath = savePath + "\\" + item;
                Directory.CreateDirectory(newPath);
                String[] items = myPhone.GetFiles(itemPath);
                for (Int32 i = 0; i < items.Length; i++){
                    CopyItemFromDevice(newPath, itemPath, items[i]);
                }
            } else {
                Byte[] fileBuffer = new Byte[1024];
                Int32 length;
                using (Stream inStream = iPhoneFile.OpenRead(myPhone, fromPath + "/" + item)){
                    using (Stream outStream = File.OpenWrite(savePath + "\\" + item)) {
                        while ((length = inStream.Read(fileBuffer, 0, fileBuffer.Length)) > 0) {
                            outStream.Write(fileBuffer, 0, length);
                        }
                    }
                }
            }
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            CreateFolder();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            CopyItemsFromDevice();
        }
    }
}