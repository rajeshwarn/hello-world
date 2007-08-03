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
        internal iPhone phone = new iPhone();
        internal Boolean connected = false;
        internal Boolean connecting = false;

        public iPhoneList() {
            InitializeComponent();
            phone.Connect += new ConnectEventHandler(Connecting);
            phone.Disconnect += new ConnectEventHandler(Connecting);
        }

        public void FillTree() {
            treeFolders.Nodes.Clear();
            FillTree("/","/",-1);
        }

        public void FillTree(String path, String name, Int32 levels) {
            treeFolders.Nodes.Add(AddNodes(path, name, levels));
            treeFolders.Nodes[0].Expand();
            treeFolders.SelectedNode = treeFolders.Nodes[0];
        }

        public void EmptyTree() {
            treeFolders.Nodes.Clear();
            listFiles.Items.Clear();
        }

        public TreeNode AddNodes(string path, string name) {
            return AddNodes(path, name, -1);
        }

        public TreeNode AddNodes(string path, string name, Int32 getLevels) {
            string[] dirs;
            TreeNode node;
            TreeNode[] children;

            dirs = phone.GetDirectories(path);
            if (dirs.Length > 0 && getLevels != 0) {
                children = new TreeNode[dirs.Length];
                for (int i = 0; i < dirs.Length; i++) {
                    children[i] = AddNodes(path + "/" + dirs[i], dirs[i], (getLevels-1));
                }
                node = new TreeNode(name, children);
            } else {
                node = new TreeNode(name);
            }
            textStatus.Text = "Adding folder " + name;
            Application.DoEvents();

            return node;
        }

        public void Connecting(object sender, ConnectEventArgs args) {
            // Check what's in root
            try {

                phone.GetFiles("/");

                // Make sure we have the directory before we set it
                if (phone.Exists("/Library/Ringtones")) {
                    string[] listFiles;

                    // Set the dir
                    phone.SetCurrentDirectory("/Library/Ringtones");

                    // Get a file listing
                    Console.WriteLine("Files in {0}:", phone.GetCurrentDirectory());
                    listFiles = phone.GetFiles(".");
                    for (int i = 0; i < listFiles.Length; i++) {
                        Console.WriteLine(listFiles[i]);
                    }

                    // Get a directory listing
                    Console.WriteLine("Directories in {0}/..:", phone.GetCurrentDirectory());
                    listFiles = phone.GetDirectories("..");
                    for (int i = 0; i < listFiles.Length; i++) {
                        Console.WriteLine(listFiles[i]);
                    }

                    iPhoneFile file;
                    // Reading a file on the phone
                    Console.WriteLine("Contents of file /etc/fstab:");
                    file = iPhoneFile.Open(phone, "/etc/fstab", FileAccess.Read);
                    file.Seek(5, SeekOrigin.Begin);
                    Console.WriteLine("Current stream position: {0}", file.Position);
                    using (StreamReader reader = new StreamReader(file)) {
                        Console.WriteLine(reader.ReadLine());
                        Console.WriteLine("Current stream position: {0}", file.Position);
                        Console.WriteLine(reader.ReadToEnd());
                    }

                    // Write a new file to the phone
                    Console.WriteLine("Writing file /testme");
                    file = iPhoneFile.Open(phone, "/testme", FileAccess.Write);
                    using (StreamWriter writer = new StreamWriter(file)) {
                        writer.WriteLine("Hello world!");
                        Console.WriteLine("Position after first line write: {0}", file.Position);
                        writer.WriteLine("Thats all folks.");
                        file.SetLength(10);
                    }

                    Console.WriteLine("Contents of file /testme:");
                    file = iPhoneFile.Open(phone, "/testme", FileAccess.Read);
                    using (StreamReader reader = new StreamReader(file)) {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception err) {
                Console.WriteLine("Not Connected");
            }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            if (!connecting && !connected){
                if (phone.IsConnected) {
                    connecting = true;
                    Connecting(phone, null);
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
            phone.GetFiles("/");
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
            String[] files = phone.GetFiles(path);
            this.listFiles.Items.Clear();
            Int32 fileSize;
            String fileType;
            foreach (String file in files) {
                ListViewItem thisFile = new ListViewItem(file);
                phone.GetFileInfoDetails(path + "/" + file, out fileSize, out fileType);
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
            string target_path;
            int len;
            byte[] buffer;

            target_path = treeFolders.SelectedNode.FullPath.Replace("\\", "/");
            if (target_path == "") {
                target_path = "/";
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


            // FIXME - this won't handle dragged directories
            buffer = new byte[1024];
            for (int i = 0; i < files.Length; i++) {
                using (Stream source = File.OpenRead(files[i])) {
                    using (Stream target = iPhoneFile.OpenWrite(phone, target_path + "/" + Path.GetFileName(files[i]))) {
                        while ((len = source.Read(buffer, 0, buffer.Length)) > 0) {
                            target.Write(buffer, 0, len);
                        }
                    }
                }
            }
            // Force a refresh
            tree_AfterSelect(sender, new TreeViewEventArgs(treeFolders.SelectedNode));
        }

        void tree_AfterSelect(object sender, TreeViewEventArgs e) {
            string path;
            string[] phone_files;
            ListViewItem item;
            bool dir;
            int size;

            path = e.Node.FullPath.Substring(1);

            phone_files = phone.GetFiles(path);
            listFiles.Items.Clear();
            for (int i = 0; i < phone_files.Length; i++) {
                item = new ListViewItem(phone_files[i]);
                phone.GetFileInfo(path + "/" + phone_files[i], out size, out dir);
                item.SubItems.Add(String.Format("{0}", size.ToString("#,##0")));
                listFiles.Items.Add(item);
            }
        }
        protected string[] GetFilenames(DragEventArgs e) {
            string[] ret;

            Array data = ((IDataObject)e.Data).GetData("FileNameW") as Array;
            if (data == null) {
                return null;
            }

            ret = new string[data.Length];

            for (int i = 0; i < data.Length; i++) {
                if ((data.GetValue(i) is String)) {
                    ret[i] = ((string[])data)[i];
                }
            }
            return ret;
        }

        private void treeFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            //AddNodes(e.Node.FullPath.Replace("\\", "/"), e.Node.Name, 2);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            ListView.SelectedListViewItemCollection selectedItems;
            String path = treeFolders.SelectedNode.FullPath.Replace("\\","/");
            selectedItems = listFiles.SelectedItems;
            foreach (ListViewItem item in selectedItems ) {
                Console.WriteLine(path + ", " + item.Name);
            }
        }
    }
}