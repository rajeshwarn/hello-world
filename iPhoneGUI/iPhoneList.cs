// iPhoneList - an iPhone File Explorer for Windows
//
// Copyright (C) 2007  James C. Baker
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Manzana;
using System.IO;
using System.Collections;
using Tools;
//using ToolBarRender;
using System.Xml;
using System.Xml.Serialization;
using iPhoneList;
using CoreFoundation;

namespace iPhoneGUI
{
    public partial class iPhoneList: Form
    {
        internal iPhone myPhone = new iPhone();
        //internal CFPropertyList core = new CoreFoundation();
        internal Boolean connected = false;
        internal Boolean connecting = false;
        internal String lastSaveFolder = "";
        internal Boolean cancelCopy = false;
        internal Boolean showDotFolders = false;
        internal Int32 previewHeight = 200;
        internal Boolean overWriteExistingFile = false;
        internal Boolean dontAskAboutOverWrite = false;

        internal iPhoneApps localApps = null;

        public ItemProperties ipItems;
        public UserPrefs prefs;
        public LinkNodes links;

        public iPhoneList() {
            /// TODO: Add ability to Edit and Delete Links
            InitializeComponent();
            SetObjectSizes();
            SetStatus();
            toolsMain.Location = new Point(0, 0);
            toolsFileView.Location = new Point(203, 0);
            //ToolStripManager.Renderer = new Office2007Renderer();
            //myPhone.Connect += new ConnectEventHandler(Connecting);
            //myPhone.Disconnect += new ConnectEventHandler(Connecting);
            prefs = new UserPrefs();
            links = new LinkNodes();
            ipItems = new ItemProperties();
            ipItems.Phone = myPhone;
            try {
                LoadUserPreferences();
                LoadConfig();
            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
            }
            ipItems.Phone = myPhone;
            splitFilesViewer.Panel2Collapsed = true;
            if (prefs.Preview.TabSpaces == null ||
                prefs.Preview.TabSpaces == 0) {
                prefs.Preview.TabSpaces = 4;
            }
            previewTextBox.Tag = "empty";
            timerMain.Enabled = true;
        }

        private void LoadConfig() {
            try {
                ipItems = ipItems.LoadConfig();
            }
            catch ( Exception err ) {
                Console.WriteLine(err.Message);
            }
            try {
                links = links.LoadConfig();
                for ( Int32 i = 0; i < links.Nodes.Length; i++) {
                    LinkNode link = (LinkNode)links.Nodes[i];
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = "link" + link.Name;
                    menuItem.Text = link.Name;
                    menuItem.ToolTipText = link.Description;
                    menuItem.Tag = link.Location;
                    menuItem.Click += new System.EventHandler(this.toolsLinksSelect);
                    this.toolsFileFavorites.DropDownItems.Add(menuItem);
                }
            }
            catch ( Exception err ) {
                Console.WriteLine(err.Message);
            }
        }

        private void SaveConfig() {
            ipItems.SaveConfig();
            links.SaveConfig();
        }

        private void LoadUserPreferences() {
            String fullPath = Application.UserAppDataPath + "iPhoneList.config";
            if (File.Exists(fullPath)) {
                XmlSerializer xmlConfig = new XmlSerializer(typeof(UserPrefs));
                using (TextReader prefsFile = new StreamReader(fullPath)) {
                    prefs = (UserPrefs)xmlConfig.Deserialize(prefsFile);
                }
                splitFilesViewer.Panel2Collapsed = !prefs.Window.previewOn;
                SetItemLocation(this, prefs.Window.Main);
                SetItemLocation(toolsMain, prefs.Window.MainToolBar);
                SetItemLocation(toolsFileView, prefs.Window.FileToolBar);
            }
        }

        private void SaveUserPreferences() {
            prefs.Window.previewOn = !splitFilesViewer.Panel2Collapsed;
            prefs.Window.Main = GetLocationParms(this);
            prefs.Window.MainToolBar = GetLocationParms(toolsMain);
            prefs.Window.FileToolBar = GetLocationParms(toolsFileView);
            XmlSerializer xmlConfig = new XmlSerializer(typeof(UserPrefs));
            String fullPath = Application.UserAppDataPath + "iPhoneList.config";
            using (TextWriter prefsFile = new StreamWriter(fullPath)) {
                xmlConfig.Serialize(prefsFile, prefs);
            }
        }

        private ItemLocation GetLocationParms(System.Windows.Forms.Control control) {
            ItemLocation thisItem = new ItemLocation();
            thisItem.Top = control.Top;
            thisItem.Left = control.Left;
            thisItem.Width = control.Width;
            thisItem.Height = control.Height;
            return thisItem;
        }

        private void SetItemLocation(System.Windows.Forms.Control control, ItemLocation thisItem) {
            control.Top = thisItem.Top;
            control.Left = thisItem.Left;
            control.Width = thisItem.Width;
            control.Height = thisItem.Height;
        }

        private void SetObjectSizes() {
            labelStatus.Width = statusMain.Width - 120;
        }

        private void SetStatus() {
            if (myPhone.IsConnected) {
                labelStatus.Text = "iPhone is connected.";
            } else {
                labelStatus.Text = "iPhone is not connected.";
            }
        }

        private void timerMain_Tick(object sender, EventArgs e) {
            if (!connecting && !connected) {
                if (myPhone.IsConnected) {
                    connecting = true;
                    //Connecting(myPhone, null);
                    FillTree();
                    this.Show();
                    connecting = false;
                    connected = true;
                    SetStatus();
                } else {
                    if (connected) {
                        MessageBox.Show("iPhone Disconnected.");
                        this.treeFolders.Nodes.Clear();
                        this.listFiles.Clear();
                        SetStatus();
                    }
                }
            }
        }

        private void RefreshView() {
            FillTree();
            ShowFiles();
            SetStatus();
        }

        public void FillTree() {
            treeFolders.Nodes["/"].Nodes.Clear();
            treeFolders.SelectedNode = treeFolders.Nodes["/"];
            FillTree(treeFolders.TopNode, treeFolders.TopNode.Text);
        }

        public void FillTree(TreeNode thisNode, String path) {
            thisNode.Nodes.Clear();
            if (!thisNode.Name.Substring(0, 1).Equals("_")) {
                AddNodes(thisNode, path);
                //treeFolders.Nodes.Add(AddNodes(path, name, levels));
                treeFolders.Nodes[0].Expand();
            }
            treeFolders.SelectedNode = thisNode;
            SetStatus();
        }

        public void EmptyTree() {
            treeFolders.Nodes.Clear();
            listFiles.Items.Clear();
        }

        public void AddNodes(TreeNode thisNode, String path) {
            AddNodes(thisNode, path, 1);
        }

        public void AddNodes(TreeNode thisNode, String path, Int32 getLevels) {
            String[] dirNames;
            labelStatus.Text = "Adding folder " + thisNode.Text;
            dirNames = myPhone.GetDirectories(path);
            if (thisNode.TreeView != null) {
                thisNode.TreeView.BeginUpdate();
            }

            if (dirNames.Length > 0) {
                if (getLevels != 0) {
                    for (int i = 0; i < dirNames.Length; i++) {
                        TreeNode childNode = new TreeNode(dirNames[i]);
                        childNode.ImageKey = "Folder";
                        childNode.Name = path + "/" + dirNames[i];
                        ItemProperty thisItem = ipItems.FindItem(childNode.Name);
                        if (thisItem != null) {
                            childNode.ImageKey = thisItem.ImageKey;
                            childNode.Tag = thisItem.Tag;
                        } else {
                            childNode.ImageKey = "Other";
                            childNode.Tag = "Unknown";
                        }
                        AddNodes(childNode, path + "/" + dirNames[i], (getLevels - 1));
                        thisNode.Nodes.Add(childNode);
                        thisNode.Tag = "loaded";
                        Application.DoEvents();
                    }
                } else {
                    TreeNode childNode = new TreeNode(".");
                    childNode.Name = path + "/.";
                    thisNode.Nodes.Add(childNode);
                    if (thisNode.ImageKey == "Folder")
                        thisNode.ImageKey = "Folder-Files";
                    thisNode.Tag = "notloaded";
                    Application.DoEvents();
                }
            }
            if (thisNode.TreeView != null) {
                thisNode.TreeView.EndUpdate();
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

        private TreeNode FindNodePath(TreeNode startingNode, String fullPath) {
            String separator = startingNode.TreeView.PathSeparator;
            String searchPath = fullPath + separator;
            TreeNode currentNode = startingNode;
            TreeNode[] nodes;
            Int32 location = 2;
            Int32 oldLocation = 0;
            while ((location = searchPath.IndexOf(separator, location)) > 0) {
                nodes = currentNode.Nodes.Find(searchPath.Substring(0, location), true);
                if (nodes.Length == 0) {
                    currentNode = null;
                    break;
                }
                location++;
                oldLocation = location;
                currentNode = nodes[0];
                if (currentNode.Tag.ToString() == "notloaded") {
                    AddNodes(currentNode, currentNode.FullPath);
                }
            }
            return currentNode;
        }

        private void treeFolders_AfterSelect(object sender, TreeViewEventArgs e) {
            timerMain.Enabled = false;
            switch (e.Node.Name) {
                case "/":
                    String currentPath = e.Node.FullPath;
                    ShowFiles(e.Node, currentPath); // showFiles should get the dirlist, too (unless it's already gotten)
                    break;
                case "_ApplicationsPXL":
                    ShowApplicationsPXL();
                    break;
                case "_ApplicationsNull":
                    ShowApplicationsNull();
                    break;
                case "Ringtones":
                    ShowRingtones();
                    break;
                case "Themes":
                    ShowThemes();
                    break;
                case "SystemSounds":
                    ShowSystemSounds();
                    break;
                default:
                    String path = e.Node.FullPath;
                    ShowFiles(e.Node, path); // showFiles should get the dirlist, too (unless it's already gotten)
                    break;
            }
            SetStatus();
            this.Text = Application.ProductName + " - " + treeFolders.SelectedNode.FullPath;
            timerMain.Enabled = true;
        }

        private void treeFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            if (e.Node.Tag.ToString() == "notloaded") {
                FillTree(e.Node, e.Node.FullPath);
            }
        }

        private void ShowApplicationsNull() {
            this.statusMain.Text = "Loading Application List";
            if (localApps == null) {
                String installedAppPath = "//private/var/root/Library/Installer/LocalPackages.plist";
                if (myPhone.Exists(installedAppPath)) {
                    using (Stream inStream = iPhoneFile.OpenRead(myPhone, installedAppPath)) {
                        localApps = AppList.ReadXmlStream(inStream);
                    }
                }
                listApps.Items.Clear();
                for (Int32 i = 0; i < localApps.Applications.Length; i++) {
                    iPhoneApp app = localApps.Applications[i];
                    ListViewItem item = new ListViewItem();
                    item.Name = app.Name;
                    item.Text = app.Name;
                    item.ToolTipText = app.Name + Environment.NewLine + app.Description;
                    ListViewItem.ListViewSubItem desc = new ListViewItem.ListViewSubItem();
                    desc.Name = "Description";
                    desc.Text = app.Description;
                    item.SubItems.Add(desc);
                    listApps.Items.Add(item);
                }
            }
            listApps.Visible = true;
            listFiles.Visible = false;
            SetStatus();
        }

        private void ShowApplicationsPXL() {

        }

        private void ShowRingtones() {
        }

        private void ShowThemes() {
        }

        private void ShowSystemSounds() {
        }

        private void ShowFiles() {
            ShowFiles(treeFolders.TopNode, "/");
        }

        private void ShowFiles(TreeNode thisNode, String itemPath) {
            Boolean addNodes = false;
            if (thisNode.Tag == null || thisNode.Tag.ToString() == "notloaded") {
                addNodes = true;
                thisNode.Nodes.Clear();
            }
            String[] files = myPhone.GetFiles(itemPath);
            this.listFiles.Items.Clear();
            Int32 fileSize;
            iPhone.FileTypes fileType;
            listFiles.BeginUpdate();
            foreach (String file in files) {
                if (!(file.Equals(".") || file.Equals("..")) || showDotFolders) {
                    String fullPath = itemPath + "/" + file;
                    ListViewItem thisFile = new ListViewItem(file);
                    thisFile.ImageKey = "Other";
                    myPhone.GetFileInfoDetails(fullPath, out fileSize, out fileType);
                    ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem type = new ListViewItem.ListViewSubItem();
                    ListViewItem.ListViewSubItem path = new ListViewItem.ListViewSubItem();
                    size.Name = "Size";
                    type.Name = "Type";
                    path.Name = "Path";
                    size.Text = fileSize.ToString();
                    thisFile.SubItems.Add(size);
                    ItemProperty thisItem;
                    if ((thisItem = ipItems.FindItem(fullPath)) != null) {
                        thisFile.ImageKey = thisItem.ImageKey;
                        thisFile.Tag = thisItem.Tag;
                        thisFile.ToolTipText = thisFile.Text + Environment.NewLine + fileSize.ToString("N") + " bytes" +
                            Environment.NewLine + thisItem.Name.ToString();
                        type.Text = thisItem.Name;
                        thisFile.SubItems.Add(type);
                    } else {
                        thisFile.ImageKey = "Other";
                        thisFile.Tag = "Unknown";
                        thisFile.ToolTipText = thisFile.Text + Environment.NewLine + fileSize.ToString("N") + " bytes" +
                            Environment.NewLine + thisFile.Tag.ToString();
                        type.Text = "File";
                        thisFile.SubItems.Add(type);
                    }
                    path.Text = fullPath;
                    thisFile.SubItems.Add(path);
                    if ((fileType == iPhone.FileTypes.Folder) && addNodes) {
                        TreeNode childNode = new TreeNode(file);
                        childNode.ImageKey = "Folder";
                        childNode.Name = fullPath;
                        AddNodes(childNode, fullPath, 0);
                        thisNode.Nodes.Add(childNode);
                        thisNode.Tag = "loaded";
                        Application.DoEvents();
                    }
                    thisFile.Group = listFiles.Groups[listFiles.Groups.Count - 1]; // Other Group
                    for (Int32 i = 0; i < listFiles.Groups.Count; i++) {
                        if (thisFile.Tag.ToString() == listFiles.Groups[i].Tag.ToString()) {
                            thisFile.Group = listFiles.Groups[i];
                            break;
                        }
                    }
                    listFiles.Items.Add(thisFile);
                }
            }
            listFiles.EndUpdate();
            if (listFiles.Items.Count > 0) {
                listFiles.Items[0].Selected = true;
            }
            if (!listFiles.Visible) {
                listApps.Visible = false;
                listFiles.Visible = true;
            }
        }

        private String GetFileExt(String fileName) {
            Int32 period = fileName.LastIndexOf(".");
            String retVal;
            if (period > 0) {
                retVal = fileName.Substring(period);
            } else {
                retVal = "";
            }
            return retVal;
        }

        private void listFiles_DragEnter(object sender, DragEventArgs e) {
            if (((e.AllowedEffect & DragDropEffects.Copy) != 0) && (e.Data.GetDataPresent("FilenameW"))) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listFiles_DragDrop(object sender, DragEventArgs e) {
            TreeNode thisNode = treeFolders.SelectedNode;
            String destPath = thisNode.FullPath;
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);

            for (int i = 0; i < files.Length; i++) {
                CopyToDevice(files[i], destPath);
            }
            if (!dontAskAboutOverWrite) {
                overWriteExistingFile = false;
            }
            // Force a refresh
            FillTree(thisNode, destPath);
            ShowFiles(thisNode, destPath);
        }

        internal void CopyToDevice(String srcFile, String destPath) {
            FileInfo thisFile = new FileInfo(srcFile);
            Console.WriteLine(thisFile.Attributes.ToString());
            if ((thisFile.Attributes & FileAttributes.Directory) == FileAttributes.Directory) {
                String[] files = Directory.GetFileSystemEntries(thisFile.FullName);
                for (Int32 i = 0; i < files.Length; i++) {
                    String newDirectory = destPath + "/" + thisFile.Name;
                    myPhone.CreateDirectory(newDirectory);
                    CopyToDevice(files[i], newDirectory);
                }
            } else {
                Byte[] fileBuffer = new Byte[1024];
                Int32 length;
                labelStatus.Text = "Copying " + thisFile.FullName;

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

        private void folderToolStripMenuItem_Click(object sender, EventArgs e) {
            Console.WriteLine(e.ToString());
        }

        private void DeleteSelectedItems() {
            String path = treeFolders.SelectedNode.FullPath;
            TreeNode thisNode = treeFolders.SelectedNode;
            Boolean deletedFolder = false;
            if (listFiles.SelectedItems.Count > 0) {
                foreach (ListViewItem item in listFiles.SelectedItems) {
                    if (!item.Name.Equals(".") && !item.Name.Equals("..")) {
                        Console.WriteLine(path + ", " + item.Name);
                        if (myPhone.IsDirectory(path + "/" + item.Text))
                            deletedFolder = true;
                        myPhone.DeleteFromDevice(path + "/" + item.Text);
                    }
                }
            }
            if (deletedFolder) {
                FillTree(thisNode, path);
            }
            ShowFiles(thisNode, path);
        }

        private void CreateFolder() {
            timerMain.Enabled = false;
            TreeNode selectedNode = treeFolders.SelectedNode;
            String inPath = selectedNode.FullPath;
            using (NewFolderForm frmNew = new NewFolderForm()) {
                frmNew.ActionText = "Folder Name: " + inPath + "/";
                frmNew.ShowDialog();
                if (frmNew.DialogResult == DialogResult.OK) {
                    try {
                        myPhone.CreateDirectory(inPath + "/" + frmNew.FolderName);
                        FillTree(selectedNode, inPath);
                        ShowFiles(selectedNode, inPath);
                    }
                    catch (Exception err) {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            timerMain.Enabled = true;
        }

        private void BackupiPhone() {
            String savePath = GetSavePath();
            if (!savePath.Equals("")) {
                CopyItemFromDevice(savePath, "/", "");
            }
        }

        private void CopyItemsFromDevice() {
            toolItemCancel.Visible = true;
            Boolean okToCopy = true;
            Boolean copyAll = false;
            String fromPath = "/";
            if (listFiles.SelectedItems.Count == 0) {
                if (treeFolders.SelectedNode == null) {
                    MessageBox.Show("Nothing Selected to Copy", "iPhoneList Message:");
                    okToCopy = false;
                } else {
                    copyAll = true;
                }
            } else {
                if (treeFolders.SelectedNode != null) {
                    fromPath = treeFolders.SelectedNode.FullPath;
                }
            }
            String savePath = GetSavePath();
            if (okToCopy) {
                if (copyAll) {
                    foreach (ListViewItem item in listFiles.Items) {
                        CopyItemFromDevice(savePath, fromPath, item.Text);
                    }
                } else {
                    foreach (ListViewItem item in listFiles.SelectedItems) {
                        CopyItemFromDevice(savePath, fromPath, item.Text);
                    }
                }
            }
            toolItemCancel.Visible = false;
        }

        private String GetSavePath() {
            using (FolderBrowserDialog saveTo = new FolderBrowserDialog()) {
                saveTo.SelectedPath = lastSaveFolder;
                DialogResult result = saveTo.ShowDialog();
                if (result == DialogResult.OK) {
                    String savePath = saveTo.SelectedPath;
                    lastSaveFolder = savePath;
                    return savePath;
                }
            }
            return "";
        }

        private Boolean CopyItemFromDevice(String savePath, String fromPath, String item) {
            Boolean continueCopy = true;
            Boolean dontCopyMusic = true;
            Boolean dontCopyPhotos = true;
            String itemPath = fromPath + "/" + item;
            if (dontCopyMusic && (
                fromPath.Equals("//private/var/root/Media/iTunes_Control") ||
                fromPath.Equals("//var/root/Media/iTunes_Control"))) {
                return true;
            }
            if (dontCopyPhotos &&
                    fromPath.Equals("//private/var/root/Media/DCIM")) {
                return true;
            }
            if (!item.Equals(".") && !item.Equals("..")) {
                if (myPhone.IsDirectory(itemPath)) {
                    String newPath = savePath + "\\" + item;
                    Directory.CreateDirectory(newPath);
                    String[] items = myPhone.GetFiles(itemPath);
                    for (Int32 i = 0; i < items.Length; i++) {
                        continueCopy = CopyItemFromDevice(newPath, itemPath, items[i]);
                        if (!continueCopy) break;
                    }
                } else {
                    String sourcePath = fromPath + "/" + item;
                    String destPath = savePath + "\\" + item.Replace("*", "^").Replace(":", "!");
                    iPhone.FileTypes fileType = myPhone.FileType(sourcePath);
                    if (fileType == iPhone.FileTypes.Folder ||
                        fileType == iPhone.FileTypes.File) {
                        labelStatus.Text = "Copying: " + sourcePath;
                        if (item.Contains(".plist")) {
                            DecodePListStream(sourcePath, destPath);
                        }
                        Byte[] fileBuffer = new Byte[1024];
                        Int32 length;
                        Int32 bytesSoFar = 0;
                        toolStripProgressBar1.Visible = true;
                        toolStripProgressBar1.Minimum = 0;
                        using (Stream inStream = iPhoneFile.OpenRead(myPhone, sourcePath)) {
                            toolStripProgressBar1.Maximum = (Int32)inStream.Length;
                            using (Stream outStream = File.OpenWrite(destPath)) {
                                try {
                                    while ((length = inStream.Read(fileBuffer, 0, fileBuffer.Length)) > 0 && !cancelCopy) {
                                        bytesSoFar += length;
                                        toolStripProgressBar1.Value = bytesSoFar;
                                        Application.DoEvents();
                                        if (cancelCopy) {
                                            if (MessageBox.Show("Cancel Copying?", "iPhoneList Message", MessageBoxButtons.YesNo) == DialogResult.No) {
                                                cancelCopy = false;
                                            }
                                        }
                                        if (!cancelCopy) {
                                            outStream.Write(fileBuffer, 0, length);
                                        }
                                    }
                                }
                                catch (IOException err) {
                                    DialogResult retVal = MessageBox.Show("iPhone stopped responding on file: " + sourcePath + ".\n Attempt to Continue?", err.Message, MessageBoxButtons.YesNo);
                                    if (retVal == DialogResult.No) {
                                        continueCopy = false;
                                    }
                                }
                            }
                        }
                        toolStripProgressBar1.Visible = false;
                    } else {
                        labelStatus.Text = "Skipping non-File: " + sourcePath;
                    }
                    Application.DoEvents();
                }
            }
            return continueCopy;
        }

        private void DecodePListStream(String inFile, String outFile) {
            Byte[] fileBuffer = new Byte[1024];
            Int32 length;
            using (Stream inStream = iPhoneFile.OpenRead(myPhone, inFile)) {
                using (Stream outStream = File.OpenWrite(outFile)) {
                    while ((length = inStream.Read(fileBuffer, 0, fileBuffer.Length)) > 0) {
                        outStream.Write(fileBuffer, 0, length);
                    }
                }
            }
        }

        private String DecodePListFile(String inFile) {
            String plist = null;
            try {
                plist = CFPropertyList.PropertyListToXML(ReadFile(inFile));
            }
            catch (Exception err) {
                plist = ReadTextFile(inFile, 1024);
            }
            return plist;
        }

        private String DecodePListData(Byte[] inData) {
            String plist = null;
            Boolean decodeFailed = false;
            try {
                plist = CFPropertyList.PropertyListToXML(inData);
                if ( plist == null ) {
                    decodeFailed = true;
                }
            }
            catch (Exception err) {
                decodeFailed = true;
                Console.WriteLine(err.Message);
            }
            if (decodeFailed) {
                plist = System.Text.Encoding.ASCII.GetString(inData);
            }
            return plist;
        }

        private String ReadTextFile(String inFile, Int32 length) {
            Byte[] fileData = ReadFile(inFile, length);
            String text = null;
            // is the a Binary Plist?
            // if (BSubString(fileData,0,6)
            if (System.Text.Encoding.ASCII.GetString(Hex.BSubString(fileData, 0, 6)).Equals("bplist")) {
                text = DecodePListData(fileData);
            } else {
                text = System.Text.Encoding.ASCII.GetString(fileData);
            }
            if (text == null) {
                return null;
            } else {
                return String.Join(Environment.NewLine, text.Split('\n'));
            }
        }

        private Byte[] ReadFile(String inFile) {
            return ReadFile(inFile, -1);
        }

        private Byte[] ReadFile(String inFile, Int32 length) {
            Int32 bufferSize = myPhone.FileSize(inFile);
            Int32 maxBytes = 0;
            if (length == -1) {
                maxBytes = bufferSize;
            } else {
                maxBytes = Math.Min(length, bufferSize);
            }
            Byte[] fileBuffer = new Byte[maxBytes];
            using (Stream inStream = iPhoneFile.OpenRead(myPhone, inFile)) {
                bufferSize = inStream.Read(fileBuffer, 0, fileBuffer.Length);
            }
            return fileBuffer;
        }

        private void PreviewSelectedItem(TreeNode thisNode, ListViewItem item) {
            if (thisNode == null) {
                thisNode = treeFolders.TopNode;
            }
            String fullName = thisNode.FullPath + "/" + item.Text;
            if (myPhone.FileType(fullName) == iPhone.FileTypes.File) {
                Image previewImage = null;
                PreviewTypes previewType = PreviewTypes.Binary;
                switch (item.Tag.ToString()) {
                    case "Audio":
                        previewType = PreviewTypes.Music;
                        break;
                    case "Image":
                        previewType = PreviewTypes.Image;
                        break;
                    case "Settings":
                    case "Document":
                    case "File":
                        previewType = PreviewTypes.Text;
                        break;
                    default:
                        previewType = PreviewTypes.Text;
                        break;
                }
                switch (previewType) {
                    case PreviewTypes.Text:
                        PreviewText(fullName);
                        break;
                    default:
                        previewTextBox.Visible = false;
                        previewImageBox.Visible = true;
                        previewImageBox.Image = previewImage;
                        break;
                }
            }
        }

        private void PreviewText(String fullName) {
            Int32 maxBytes = 1024;
            if (checkShowAll.Checked) {
                maxBytes = -1;
            }
            String previewText = ReadTextFile(fullName, maxBytes);
            if ( previewText != null ) {
                previewTextBox.Text = previewText.Replace("\t", new String(' ', prefs.Preview.TabSpaces));
            }
            previewTextBox.Visible = true;
            previewImageBox.Visible = false;
        }

        private void popupFilesGetFiles_Click(object sender, EventArgs e) {
            CopyItemsFromDevice();
        }

        private void popupFilesDelete_Click(object sender, EventArgs e) {
            DeleteSelectedItems();
        }

        private void toolItemRefresh_Click(object sender, EventArgs e) {
            RefreshView();
        }

        private void popupTreeCreateFolder_Click(object sender, EventArgs e) {
            CreateFolder();
        }

        private void popupTreeRefresh_Click(object sender, EventArgs e) {
            RefreshView();
        }

        private void iPhoneList_Resize(object sender, EventArgs e) {
            SetObjectSizes();
        }

        private void toolItemCancel_Click(object sender, EventArgs e) {
            cancelCopy = true;
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e) {
            timerMain.Enabled = false;
            if (listFiles.SelectedItems.Count > 0 && !splitFilesViewer.Panel2Collapsed) {
                PreviewSelectedItem(treeFolders.SelectedNode, listFiles.SelectedItems[0]);
            } else {
                previewTextBox.Clear();
                previewTextBox.Tag = "empty";
                previewTextBox.Visible = true;
                previewImageBox.Visible = false;
            }
            timerMain.Enabled = true;
        }

        private void toolItemViewSmallIcons_Click(object sender, EventArgs e) {
            if (sender.Equals(toolItemViewSmallIcons))
                listFiles.View = View.SmallIcon;
            else if (sender.Equals(toolItemViewLargeIcons))
                listFiles.View = View.LargeIcon;
            else if (sender.Equals(toolItemViewDetails))
                listFiles.View = View.Details;
            else
                listFiles.View = View.List;
        }

        private void listFiles_DoubleClick(object sender, EventArgs e) {
            if (listFiles.SelectedItems.Count == 1) {
                String thisFile = listFiles.SelectedItems[0].Text;
                String path = treeFolders.SelectedNode.FullPath;
                String fullPath = path + "/" + thisFile;

                iPhone.FileTypes fileType;
                if ((fileType = myPhone.FileType(fullPath)) == iPhone.FileTypes.Folder) {
                    TreeNode[] nodes = treeFolders.SelectedNode.Nodes.Find(fullPath, true);
                    treeFolders.SelectedNode = nodes[0];
                }
            }
        }

        private void toolsFileViewPreview_Click(object sender, EventArgs e) {
            splitFilesViewer.Panel2Collapsed = !splitFilesViewer.Panel2Collapsed;
            if (!splitFilesViewer.Panel2Collapsed && listFiles.SelectedItems.Count > 0) {
                if (previewTextBox.Tag.ToString() != listFiles.SelectedItems[0].SubItems["Path"].Text.ToString()) {
                    PreviewText(listFiles.SelectedItems[0].SubItems["Path"].Text.ToString());
                } else if (previewTextBox.Tag.ToString() == "empty") {
                    PreviewText(previewTextBox.Tag.ToString());
                }
            }
        }

        private void menuMainBackup_Click(object sender, EventArgs e) {
            BackupiPhone();
        }

        private void toolsLinksSelect(object sender, EventArgs e) {
            String fullPath = ((ToolStripMenuItem)sender).Tag.ToString();
            TreeNode node = FindNodePath(treeFolders.Nodes[0], fullPath);
            if (node != null) {
                treeFolders.SelectedNode = node;
            }
        }

        private void splitFilesViewer_SplitterMoved(object sender, SplitterEventArgs e) {
            if (e.SplitX > 0) {
                prefs.Window.SplitterDistance = e.SplitX;
            }
        }

        private void toolsFileNewLocation_Click(object sender, EventArgs e) {
            String location = treeFolders.SelectedNode.FullPath;
            if (location != null) {
                using (LinkProperties form = new LinkProperties()) {
                    form.LinkLocation = location;
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK) {
                        links.Add(treeFolders.SelectedNode.FullPath);
                        links.SelectedNode.Location = treeFolders.SelectedNode.FullPath;
                        ToolStripMenuItem newMenu = new ToolStripMenuItem();
                        newMenu.Name = location;
                        newMenu.Text = form.LinkName;
                        newMenu.Tag = form.LinkLocation;
                        newMenu.ToolTipText = form.LinkDescription;
                        toolsFileFavorites.DropDownItems.Add(newMenu);
                        links.Add(form.LinkName, form.LinkLocation, form.LinkDescription);
                    }
                }
            }
        }

        private void menuMainFileExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void menuMainOptions_Click(object sender, EventArgs e) {
            using (Options options = new Options()) {
                DialogResult result = options.ShowDialog();
            }
        }

        private void checkShowAll_CheckedChanged(object sender, EventArgs e) {
            if (listFiles.SelectedItems.Count > 0) {
                PreviewText(listFiles.SelectedItems[0].SubItems["Path"].Text.ToString());
            }
        }

        private void iPhoneList_FormClosing(object sender, FormClosingEventArgs e) {
            SaveUserPreferences();
            SaveConfig();
        }

        private void popupTreeCopyMenu_Click(object sender, EventArgs e) {
            timerMain.Enabled = false;
            switch (((ToolStripDropDownItem)sender).Tag.ToString()){
                case "FolderName":
                    Clipboard.SetText(treeFolders.SelectedNode.Text);
                    break;
                case "FullPath":
                    Clipboard.SetText(treeFolders.SelectedNode.FullPath);
                    break;
            }
            timerMain.Enabled = true;
        }
    }
}