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

namespace iPhoneGUI
{
    public partial class iPhoneList: Form
    {
        public enum TypeIdentifier {
            FileName,
            Extension,
            FileType,
            HeaderBytes,
            HeaderString, 
            ExtHeadBytes, // Extension First, then Header
            ExtHeadString
        }
        internal enum PreviewTypes { Image, Text, Music, Video, Document, Binary };
        private class ItemProperty
        {
            public String Name;
            public iPhone.FileTypes Type;
            public TypeIdentifier Identifier;
            public String FileName;
            public String Extension;
            public String ImageKey;
            public String Tag;
            public Byte[] Header;
            public Int32 ByteOffset;

            public ItemProperty(String inName){
                Name = inName;
            }
            public override String ToString() {
                return Name;
            }
        }

        private class ItemProperties {
            private ArrayList items;
            private Int32 selectedIndex;

            public ItemProperties(){
                items = new ArrayList();
            }
            public Boolean Add( // for FileName and Extension
                String name,
                iPhone.FileTypes type,
                TypeIdentifier typeID,
                String fileNameOrExt,
                String imageKey,
                String tag
                ) {
                if ( typeID == TypeIdentifier.FileName ) {
                    return Add(name, type, typeID, fileNameOrExt, "", Hex.ToBytes(""), 0, imageKey, tag);
                } else {
                    return Add(name, type, typeID, "", fileNameOrExt, Hex.ToBytes(""), 0, imageKey, tag);
                }
            }
            public Boolean Add( // for HeaderString and HeaderBytes
                String name,
                iPhone.FileTypes type,
                TypeIdentifier typeID,
                String headerString,
                Int32 byteOffset,
                String key,
                String tag
                ) {
                if (typeID == TypeIdentifier.HeaderString) {
                    Byte[] dummyBytes = TextString.ToByte(headerString);
                } else {
                    Byte[] dummyBytes = Hex.ToBytes(headerString);
                }
                return Add(name, type, typeID, "", "", dummyBytes, byteOffset, imageKey, tag);
            }

            public Boolean Add(
                String name,
                iPhone.FileTypes type,
                TypeIdentifier typeID,
                String fileName,
                String extension,
                Byte[] headerBytes,
                Int32 byteOffset,
                String imageKey,
                String tag
                ) {
                ItemProperty newItem = new ItemProperty(name);
                newItem.Type = type;
                newItem.Identifier = typeID;
                newItem.FileName = fileName;
                newItem.Extension = extension;
                newItem.Header = headerBytes;
                newItem.ByteOffset = byteOffset;
                newItem.ImageKey = imageKey;
                newItem.Tag = tag;
                items.Add(newItem);
                selectedIndex = items.Count - 1;
                return true;
            }
            public ItemProperty[] Items {
                get {
                    ItemProperty[] outItems = new ItemProperty[items.Count];
                    for ( Int32 i = 0; i < items.Count; i++ ) {
                        outItems[i] = (ItemProperty)items[i];
                    }
                    return outItems;
                }
            }
            public ItemProperty Item(String inName) {
                for ( Int32 i = 0; i < items.Count; i++ ) {
                    if ( ((ItemProperty)items[i]).Name.Equals(inName) ) {
                        selectedIndex = i;
                        return (ItemProperty)items[i];
                    }
                }
                return null;
            }
            public Int32 ItemIndex(String inName) {
                for ( Int32 i = 0; i < items.Count; i++ ) {
                    if ( ((ItemProperty)items[i]).Name.Equals(inName) ) {
                        selectedIndex = i;
                        return i;
                    }
                }
                return -1;
            }
            public ItemProperty SelectedItem {
                get { return (ItemProperty)items[selectedIndex]; }
            }
            public Int32 SelectedIndex {
                get { return selectedIndex; }
                set { 
                    if (value >= 0 && value < items.Count)
                        selectedIndex = value; 
                }
            }
        }

        internal iPhone myPhone = new iPhone();
        internal Boolean connected = false;
        internal Boolean connecting = false;
        internal String lastSaveFolder = "";
        internal Boolean cancelCopy = false;

        public iPhoneList() {
            InitializeComponent();
            SetObjectSizes();
            SetStatus();
            //myPhone.Connect += new ConnectEventHandler(Connecting);
            //myPhone.Disconnect += new ConnectEventHandler(Connecting);
            // TEMPORARY FileType load until I add a FileType config window
            // Files
            ItemProperties ipItems = new ItemProperties();
            ipItems.Add("Program", iPhone.FileTypes.File, TypeIdentifier.HeaderBytes, "", "Program", "Program", Hex.ToBytes("CEFAEDFE0C00"), 0);
            ipItems.Add("App", iPhone.FileTypes.File, TypeIdentifier.Extension, ".app", "App", "Application");
            ipItems.Add("BinPList", iPhone.FileTypes.File, TypeIdentifier.ExtHead, ".plist", "Settings", "Settings", Hex.ToBytes("62706C6973743030"), 0);
            ipItems.Add("PList", iPhone.FileTypes.File, TypeIdentifier.Extension, ".plist", "Settings", "Settings");
            ipItems.Add("BinStrings", iPhone.FileTypes.File, TypeIdentifier.ExtHead, ".strings", "Settings", "Settings", Hex.ToBytes("62706C6973743030"), 0);
            ipItems.Add("Strings", iPhone.FileTypes.File, TypeIdentifier.Extension, ".strings", "Settings", "Settings");
            ipItems.Add("Thumnail", iPhone.FileTypes.File, TypeIdentifier.Extension, ".thm", "Image", "Image");
            ipItems.Add("Thumb", iPhone.FileTypes.File, TypeIdentifier.Extension, ".ithmb", "Image", "Image");
            ipItems.Add("PNG", iPhone.FileTypes.File, TypeIdentifier.Extension, ".png", "Image", "Image");
            ipItems.Add("JPG", iPhone.FileTypes.File, TypeIdentifier.Extension, ".jpg", "Image", "Image");
            ipItems.Add("GIF", iPhone.FileTypes.File, TypeIdentifier.Extension, ".gif", "Image", "Image");
            ipItems.Add("BMP", iPhone.FileTypes.File, TypeIdentifier.Extension, ".bmp", "Image", "Image");
            ipItems.Add("AAC", iPhone.FileTypes.File, TypeIdentifier.Extension, ".aac", "Audio", "Audio");
            ipItems.Add("MP3", iPhone.FileTypes.File, TypeIdentifier.Extension, ".mp3", "Audio", "Audio");
            ipItems.Add("M4A", iPhone.FileTypes.File, TypeIdentifier.Extension, ".m4a", "Audio", "Audio");
            ipItems.Add("Photo DataBase", iPhone.FileTypes.File, TypeIdentifier.FileName, "", "Database", "Database");
            ipItems.Add("ArtworkDB", iPhone.FileTypes.File, TypeIdentifier.FileName, "", "Database", "Database");
            ipItems.Add("Text", iPhone.FileTypes.File, TypeIdentifier.Extension, ".txt", "Document", "Document");
            ipItems.Add("Script", iPhone.FileTypes.File, TypeIdentifier.Extension, ".script", "Script", "Script");
            ipItems.Add("ShellScript", iPhone.FileTypes.File, TypeIdentifier.Extension, ".sh", "Script", "Script");
            // Folder types
            ipItems.Add("App", iPhone.FileTypes.Folder, TypeIdentifier.Extension, ".app", "Folder-App", "Application");
            ipItems.Add("Photos", iPhone.FileTypes.Folder, TypeIdentifier.FileName, "", "Folder-Image", "Image Folder");
            ipItems.Add("DCIM", iPhone.FileTypes.Folder, TypeIdentifier.FileName, "", "Folder-Image", "Image Folder");
            ipItems.Add("100APPLE", iPhone.FileTypes.Folder, TypeIdentifier.FileName, "", "Folder-Image", "Image Folder");
            ipItems.Add("Artwork", iPhone.FileTypes.Folder, TypeIdentifier.FileName, "", "Folder-Image", "Image Folder");
            ipItems.Add("Thumbs", iPhone.FileTypes.Folder, TypeIdentifier.FileName, "", "Folder-Image", "Image Folder");
            ipItems.Add("Music", iPhone.FileTypes.Folder, TypeIdentifier.FileName, "", "Folder-Audio", "Audio Folder");
            // Other types
            ipItems.Add("CharDevice", iPhone.FileTypes.CharDevice, TypeIdentifier.FileType, "", "Device", "Character Device");
            ipItems.Add("BlockDevice", iPhone.FileTypes.BlockDevice, TypeIdentifier.FileType, "", "Device", "Block Device");
            ipItems.Add("FIFO", iPhone.FileTypes.FIFO, TypeIdentifier.FileType, "", "Device", "FIFO");
        }

        private void SetObjectSizes() {
            labelStatus.Width = statusMain.Width - 120;
        }

        private void SetStatus() {
            if ( myPhone.IsConnected ) {
                labelStatus.Text = "iPhone is connected.";
            } else {
                labelStatus.Text = "iPhone is not connected.";
            }
        }

        private void timerMain_Tick(object sender, EventArgs e) {
            if ( !connecting && !connected ) {
                if ( myPhone.IsConnected ) {
                    connecting = true;
                    //Connecting(myPhone, null);
                    this.treeFolders.Nodes.Clear();
                    FillTree();
                    ShowFiles("/");
                    this.Show();
                    connecting = false;
                    connected = true;
                    SetStatus();
                } else {
                    if ( connected ) {
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
            ShowFiles("/");
            SetStatus();
        }

        public void FillTree() {
            treeFolders.Nodes.Clear();
            treeFolders.Nodes.Add("/", "/");
            FillTree(treeFolders.TopNode, treeFolders.TopNode.Text);
        }

        public void FillTree(TreeNode thisNode, String path) {
            thisNode.Nodes.Clear();
            AddNodes(thisNode, path);

            //treeFolders.Nodes.Add(AddNodes(path, name, levels));
            treeFolders.Nodes[0].Expand();
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
            if ( dirNames.Length > 0 ) {
                if ( getLevels != 0 ) {
                    for ( int i = 0; i < dirNames.Length; i++ ) {
                        TreeNode childNode = new TreeNode(dirNames[i]);
                        childNode.ImageKey = "Folder";
                        childNode.Name = path + "/" + dirNames[i];
                        if ( GetFileExt(dirNames[i]) == ".app" ) {
                            childNode.ImageKey = "Folder-App";
                        } else {
                            switch ( dirNames[i] ) {
                                case "Photos":
                                case "DCIM":
                                case "100APPLE":
                                case "Artwork":
                                case "Thumbs":
                                    childNode.ImageKey = "Folder-Image";
                                    break;
                                case "Music":
                                    childNode.ImageKey = "Folder-Audio";
                                    break;
                                default:
                                    childNode.ImageKey = "Folder";
                                    break;
                            }
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
                    if ( thisNode.ImageKey == "Folder" )
                        thisNode.ImageKey = "Folder-Files";
                    thisNode.Tag = "notloaded";
                    Application.DoEvents();
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
            String currentPath = e.Node.FullPath.Replace("\\", "/");
            ShowFiles(currentPath);
            SetStatus();
        }

        private void ShowFiles(String path) {
            String[] files = myPhone.GetFiles(path);
            this.listFiles.Items.Clear();
            Int32 fileSize;
            iPhone.FileTypes fileType;
            foreach ( String file in files ) {
                ListViewItem thisFile = new ListViewItem(file);
                thisFile.ImageKey = "Other";
                myPhone.GetFileInfoDetails(path + "/" + file, out fileSize, out fileType);
                thisFile.SubItems.Add(fileSize.ToString());
                if ( fileType == iPhone.FileTypes.File)  {
                    String fileExt = GetFileExt(file);
                    switch ( fileExt ) {
                        case ".plist":
                            thisFile.SubItems.Add("Property list");
                            thisFile.Tag = "Settings";
                            break;
                        case ".strings":
                            thisFile.SubItems.Add("Localization file");
                            thisFile.Tag = "Settings";
                            break;
                        case ".m4a":
                        case ".mp3":
                        case ".aac":
                        case ".mid":
                            thisFile.SubItems.Add("Audio File");
                            thisFile.Tag = "Audio";
                            break;
                        case "txt":
                            thisFile.SubItems.Add("Text File");
                            thisFile.Tag = "Document";
                            break;
                        case ".png":
                        case ".jpg":
                        case ".gif":
                        case ".bmp":
                            thisFile.SubItems.Add("Image file");
                            thisFile.Tag = "Image";
                            break;
                        default:
                            thisFile.SubItems.Add("File");
                            thisFile.Tag = "Other";
                            break;
                    }
                    thisFile.ImageKey = thisFile.Tag.ToString();
                } else {
                    switch ( fileType ) {
                        case iPhone.FileTypes.Folder:
                            thisFile.ImageKey = "Folder";
                            thisFile.SubItems.Add("Folder");
                            thisFile.Tag = "Folder";
                            break;
                        case iPhone.FileTypes.Link:
                            thisFile.ImageKey = "Device";
                            thisFile.SubItems.Add("File Link");
                            thisFile.Tag = "Link";
                            break;
                        case iPhone.FileTypes.BlockDevice:
                            thisFile.ImageKey = "Device";
                            thisFile.SubItems.Add("Block Device");
                            thisFile.Tag = "Device";
                            break;
                        case iPhone.FileTypes.CharDevice:
                            thisFile.ImageKey = "Device";
                            thisFile.SubItems.Add("Character Device");
                            thisFile.Tag = "Device";
                            break;
                        case iPhone.FileTypes.FIFO:
                            thisFile.ImageKey = "Other";
                            thisFile.SubItems.Add("FIFO");
                            thisFile.Tag = "Device";
                            break;
                        case iPhone.FileTypes.FileMask:
                            thisFile.ImageKey = "Other";
                            thisFile.SubItems.Add("File type binary mask");
                            thisFile.Tag = "Other";
                            break;
                        case iPhone.FileTypes.Socket:
                            thisFile.ImageKey = "Device";
                            thisFile.SubItems.Add("Socket");
                            thisFile.Tag = "Device";
                            break;
                        default:
                            thisFile.ImageKey = "Other";
                            thisFile.SubItems.Add("Unknown");
                            thisFile.Tag = "Other";
                            break;
                    }
                }
                thisFile.Group = listFiles.Groups[listFiles.Groups.Count - 1]; // Other Group
                for ( Int32 i = 0; i < listFiles.Groups.Count; i++ ) {
                    if ( thisFile.Tag == listFiles.Groups[i].Tag ) {
                        thisFile.Group = listFiles.Groups[i];
                        break;
                    }
                }
                listFiles.Items.Add(thisFile );
            }
        }

        private String GetFileExt(String fileName) {
            Int32 period = fileName.LastIndexOf(".");
            String retVal;
            if ( period > 0 ) {
                retVal = fileName.Substring(period);
            } else {
                retVal = "";
            }
            return retVal;
        }

        private void listFiles_DragEnter(object sender, DragEventArgs e) {
            if ( ((e.AllowedEffect & DragDropEffects.Copy) != 0) && (e.Data.GetDataPresent("FilenameW")) ) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listFiles_DragDrop(object sender, DragEventArgs e) {
            TreeNode thisNode = treeFolders.SelectedNode;
            String destPath = thisNode.FullPath.Replace("\\", "/");
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);

            for ( int i = 0; i < files.Length; i++ ) {
                CopyToDevice(files[i], destPath);
            }
            // Force a refresh
            FillTree(thisNode, destPath);
            ShowFiles(destPath);
        }

        internal void CopyToDevice(String srcFile, String destPath) {
            FileInfo thisFile = new FileInfo(srcFile);
            Console.WriteLine(thisFile.Attributes.ToString());
            if ( thisFile.Attributes == FileAttributes.Directory ) {
                String[] files = Directory.GetFiles(thisFile.FullName);
                for ( Int32 i = 0; i < files.Length; i++ ) {
                    String newDirectory = destPath + "/" + thisFile.Name;
                    myPhone.CreateDirectory(newDirectory);
                    CopyToDevice(files[i], newDirectory);
                }
            } else {
                Byte[] fileBuffer = new Byte[1024];
                Int32 length;
                labelStatus.Text = "Copying " + thisFile.FullName;
                using ( Stream inStream = File.OpenRead(thisFile.FullName) ) {
                    using ( Stream outStream =
                        iPhoneFile.OpenWrite(myPhone, destPath + "/" + Path.GetFileName(thisFile.FullName)) ) {
                        while ( (length = inStream.Read(fileBuffer, 0, fileBuffer.Length)) > 0 ) {
                            outStream.Write(fileBuffer, 0, length);
                        }
                    }
                }
                Application.DoEvents();
            }
        }


        private void treeFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            if ( e.Node.Tag.ToString() == "notloaded" ) {
                FillTree(e.Node, e.Node.FullPath.Replace("\\", "/"));
            }
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e) {
            Console.WriteLine(e.ToString());

        }

        private void DeleteSelectedItems() {
            String path = treeFolders.SelectedNode.FullPath.Replace("\\", "/");
            TreeNode thisNode = treeFolders.SelectedNode;
            Boolean deletedFolder = false;
            if ( listFiles.SelectedItems.Count > 0 ) {
                foreach ( ListViewItem item in listFiles.SelectedItems ) {
                    if ( !item.Name.Equals(".") && !item.Name.Equals("..") ) {
                        Console.WriteLine(path + ", " + item.Name);
                        if ( myPhone.IsDirectory(path + "/" + item.Text) )
                            deletedFolder = true;
                        myPhone.DeleteFromDevice(path + "/" + item.Text);
                    }
                }
            }
            if ( deletedFolder )
                FillTree(thisNode, path);
            ShowFiles(path);
        }

        private void CreateFolder() {
            timerMain.Enabled = false;
            TreeNode selectedNode = treeFolders.SelectedNode;
            String inPath = selectedNode.FullPath.Replace("\\", "/");
            using ( NewFolderForm frmNew = new NewFolderForm() ) {
                frmNew.ActionText = "Folder Name: " + inPath + "/";
                frmNew.ShowDialog();
                if ( frmNew.DialogResult == DialogResult.OK ) {
                    try {
                        myPhone.CreateDirectory(inPath + "/" + frmNew.FolderName);
                        FillTree(selectedNode, inPath);
                        ShowFiles(inPath);
                    }
                    catch ( Exception err ) {
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void CopyItemsFromDevice() {
            toolItemCancel.Visible = true;
            Boolean okToCopy = true;
            Boolean copyAll = false;
            String fromPath = "/";
            if ( listFiles.SelectedItems.Count == 0 ) {
                if ( treeFolders.SelectedNode == null ) {
                    MessageBox.Show("Nothing Selected to Copy", "iPhoneList Message:");
                    okToCopy = false;
                } else {
                    copyAll = true;
                }
            } else {
                if ( treeFolders.SelectedNode != null ) {
                    fromPath = treeFolders.SelectedNode.FullPath.Replace("\\", "/");
                }
            }
            if ( okToCopy ) {
                using ( FolderBrowserDialog saveTo = new FolderBrowserDialog() ) {
                    saveTo.SelectedPath = lastSaveFolder;
                    DialogResult result = saveTo.ShowDialog();
                    if ( result == DialogResult.OK ) {
                        String savePath = saveTo.SelectedPath;
                        lastSaveFolder = savePath;
                        if ( copyAll ) {
                            foreach ( ListViewItem item in listFiles.Items ) {
                                CopyItemFromDevice(savePath, fromPath, item.Text);
                            }
                        } else {
                            foreach ( ListViewItem item in listFiles.SelectedItems ) {
                                CopyItemFromDevice(savePath, fromPath, item.Text);
                            }
                        }
                    }
                }
            }
            toolItemCancel.Visible = false;
        }

        private Boolean CopyItemFromDevice(String savePath, String fromPath, String item) {
            Boolean continueCopy = true;
            String itemPath = fromPath + "/" + item;
            if ( !item.Equals(".") && !item.Equals("..") ) {
                if ( myPhone.IsDirectory(itemPath) ) {
                    String newPath = savePath + "\\" + item;
                    Directory.CreateDirectory(newPath);
                    String[] items = myPhone.GetFiles(itemPath);
                    for ( Int32 i = 0; i < items.Length; i++ ) {
                        continueCopy = CopyItemFromDevice(newPath, itemPath, items[i]);
                        if ( !continueCopy ) break;
                    }
                } else {
                    String sourcePath = fromPath + "/" + item;
                    String destPath = savePath + "\\" + item;
                    iPhone.FileTypes fileType = myPhone.FileType(sourcePath);
                    if ( fileType == iPhone.FileTypes.Folder ||
                        fileType == iPhone.FileTypes.File ) {
                        labelStatus.Text = "Copying: " + sourcePath;
                        if ( item.Contains(".plist") ) {
                            DecodePListStream(sourcePath, destPath);
                        }
                        Byte[] fileBuffer = new Byte[1024];
                        Int32 length;
                        Int32 bytesSoFar = 0;
                        toolStripProgressBar1.Minimum = 0;
                        using ( Stream inStream = iPhoneFile.OpenRead(myPhone, sourcePath) ) {
                            toolStripProgressBar1.Maximum = (Int32)inStream.Length;
                            using ( Stream outStream = File.OpenWrite(destPath) ) {
                                try {
                                    while ( (length = inStream.Read(fileBuffer, 0, fileBuffer.Length)) > 0 && !cancelCopy) {
                                        bytesSoFar += length;
                                        toolStripProgressBar1.Value = bytesSoFar;
                                        Application.DoEvents();
                                        if ( cancelCopy ) {
                                            if ( MessageBox.Show("Cancel Copying?", "iPhoneList Message", MessageBoxButtons.YesNo) == DialogResult.No ) {
                                                cancelCopy = false;
                                            }
                                        }
                                        if ( !cancelCopy ) {
                                            outStream.Write(fileBuffer, 0, length);
                                        }
                                    }
                                }
                                catch ( IOException err ) {
                                    DialogResult retVal = MessageBox.Show("iPhone stopped responding on file: " + sourcePath + ".\n Attempt to Continue?", err.Message, MessageBoxButtons.YesNo);
                                    if ( retVal == DialogResult.No ) {
                                        continueCopy = false;
                                    }
                                }
                            }
                        }
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
            using ( Stream inStream = iPhoneFile.OpenRead(myPhone, inFile) ) {
                using ( Stream outStream = File.OpenWrite(outFile) ) {
                    while ( (length = inStream.Read(fileBuffer, 0, fileBuffer.Length)) > 0 ) {
                        outStream.Write(fileBuffer, 0, length);
                    }
                }
            }
        }

        private String DecodePListFile(String inFile){
            return ReadFile(inFile, 1024);
        }

        private String ReadFile(String inFile, Int32 length) {
            StringBuilder text = new StringBuilder();
            Byte[] fileBuffer = new Byte[1024];
            Int32 maxBytes, bytesRead = 0;
            Int32 bufferSize;
            if (length == -1){
                maxBytes = myPhone.FileSize(inFile);
            } else {
                maxBytes = length;
            }
            using ( Stream inStream = iPhoneFile.OpenRead(myPhone, inFile) ) {
                while ( (bufferSize = inStream.Read(fileBuffer, 0, fileBuffer.Length)) > 0 &&
                    bytesRead <= maxBytes) {
                    bytesRead += bufferSize;
                    text.Append(System.Text.Encoding.ASCII.GetString(fileBuffer));
                }
            }
            return String.Join(Environment.NewLine,  text.ToString().Split('\n'));
        }

        private void PreviewSelectedItem(TreeNode thisNode, ListViewItem item) {
                if (thisNode == null){
                    thisNode = treeFolders.TopNode;
                }
                String fullName = thisNode.FullPath.Replace("\\", "/") + "/" + item.Text;

            iPhone.FileTypes fileType = myPhone.FileType(fullName);
            String previewText = null;
            Image previewImage = null;
            PreviewTypes previewType = PreviewTypes.Binary;
            switch ( fileType ) {
                case iPhone.FileTypes.File:
                    switch ( GetFileExt(item.Text) ) {
                        case ".plist":
                            previewText = DecodePListFile(fullName);
                            previewType = PreviewTypes.Text;
                            break;
                        case ".mp3":
                            previewImage = imageFilesLarge.Images["MP3.ico"];
                            previewType = PreviewTypes.Music;
                            break;
                        case ".m4a":
                            previewImage = imageFilesLarge.Images["M3U.ico"];
                            previewType = PreviewTypes.Music;
                            break;
                        case ".aac":
                            previewImage = imageFilesLarge.Images["ASX.ico"];
                            previewType = PreviewTypes.Music;
                            break;
                        default:
                            previewText = ReadFile(fullName, 1024);
                            previewType = PreviewTypes.Text;
                            break;
                    }
                    break;
                default:
                    previewImage = imageFilesLarge.Images["document.ico"];
                    previewType = PreviewTypes.Binary;
                    break;
            }
            switch ( previewType ) {
                case PreviewTypes.Text:
                    previewTextBox.Text = previewText;
                    previewTextBox.Visible = true;
                    previewImageBox.Visible = false;
                    break;
                default:
                    previewTextBox.Visible = false;
                    previewImageBox.Visible = true;
                    previewImageBox.Image = previewImage;
                    break;
            }
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
            if ( listFiles.SelectedItems.Count == 1 ) {
                PreviewSelectedItem(treeFolders.SelectedNode, listFiles.SelectedItems[0]);
            } else {
                previewTextBox.Text = "";
                previewTextBox.Visible = true;
                previewImageBox.Visible = false;
            }
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
    }
}