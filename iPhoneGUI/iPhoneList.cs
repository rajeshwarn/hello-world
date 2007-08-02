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
            //			tree.BeginUpdate();
            treeFolders.Nodes.Clear();
            treeFolders.Nodes.Add(AddNodes("/", "/", -1));
            //			tree.EndUpdate();
            treeFolders.Nodes[0].Expand();
            treeFolders.SelectedNode = treeFolders.Nodes[0];
            textStatus.Text = "Connected to iPhone";
        }

        public void EmptyTree() {
            treeFolders.Nodes.Clear();
            listFiles.Items.Clear();
            textStatus.Text = "No iPhone connected";
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
    }
}