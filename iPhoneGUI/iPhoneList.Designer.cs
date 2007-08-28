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
namespace iPhoneGUI
{
    partial class iPhoneList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("/");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Applications (PXL)");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Applications (nullriver)");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Ringtones");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("System Sounds");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Themes");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iPhoneList));
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Folders", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("App Folders", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Audio Folders", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Image Folders", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Application Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup19 = new System.Windows.Forms.ListViewGroup("Programs", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup20 = new System.Windows.Forms.ListViewGroup("Documents", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup21 = new System.Windows.Forms.ListViewGroup("Image Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup22 = new System.Windows.Forms.ListViewGroup("Audio Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup23 = new System.Windows.Forms.ListViewGroup("Settings Files", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup24 = new System.Windows.Forms.ListViewGroup("Devices", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup25 = new System.Windows.Forms.ListViewGroup("Links", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup26 = new System.Windows.Forms.ListViewGroup("Other files", System.Windows.Forms.HorizontalAlignment.Left);
            this.panelList = new System.Windows.Forms.SplitContainer();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.popupTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.popupTreeRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.popupTreeCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.popupTreeCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.popupTreeCopyFolderName = new System.Windows.Forms.ToolStripMenuItem();
            this.popupTreeCopyFullPath = new System.Windows.Forms.ToolStripMenuItem();
            this.imageFolders = new System.Windows.Forms.ImageList(this.components);
            this.splitFilesViewer = new System.Windows.Forms.SplitContainer();
            this.listApps = new System.Windows.Forms.ListView();
            this.colAppTitle = new System.Windows.Forms.ColumnHeader();
            this.colAppVersion = new System.Windows.Forms.ColumnHeader();
            this.colAppDescription = new System.Windows.Forms.ColumnHeader();
            this.colAppPublisher = new System.Windows.Forms.ColumnHeader();
            this.listFiles = new System.Windows.Forms.ListView();
            this.colFile = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.popupFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.popFilesCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.popupFilesGetFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.popupFilesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageFilesLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageFilesSmall = new System.Windows.Forms.ImageList(this.components);
            this.previewImageBox = new System.Windows.Forms.PictureBox();
            this.previewTextBox = new System.Windows.Forms.TextBox();
            this.panelPreviewOptions = new System.Windows.Forms.Panel();
            this.checkShowAll = new System.Windows.Forms.CheckBox();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainFileNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMainOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolsFileView = new System.Windows.Forms.ToolStrip();
            this.toolsFileViewSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolItemViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItemViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItemViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItemViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsFileViewPreview = new System.Windows.Forms.ToolStripButton();
            this.toolsFileFavorites = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolsFileNewLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsMain = new System.Windows.Forms.ToolStrip();
            this.toolItemRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolItemGetFiles = new System.Windows.Forms.ToolStripButton();
            this.toolItemDelete = new System.Windows.Forms.ToolStripButton();
            this.toolItemCancel = new System.Windows.Forms.ToolStripButton();
            this.panelList.Panel1.SuspendLayout();
            this.panelList.Panel2.SuspendLayout();
            this.panelList.SuspendLayout();
            this.popupTree.SuspendLayout();
            this.splitFilesViewer.Panel1.SuspendLayout();
            this.splitFilesViewer.Panel2.SuspendLayout();
            this.splitFilesViewer.SuspendLayout();
            this.popupFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).BeginInit();
            this.panelPreviewOptions.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolsFileView.SuspendLayout();
            this.toolsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelList
            // 
            this.panelList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            // 
            // panelList.Panel1
            // 
            this.panelList.Panel1.Controls.Add(this.treeFolders);
            // 
            // panelList.Panel2
            // 
            this.panelList.Panel2.Controls.Add(this.splitFilesViewer);
            this.panelList.Size = new System.Drawing.Size(659, 386);
            this.panelList.SplitterDistance = 241;
            this.panelList.TabIndex = 5;
            // 
            // treeFolders
            // 
            this.treeFolders.ContextMenuStrip = this.popupTree;
            this.treeFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFolders.ImageIndex = 0;
            this.treeFolders.ImageList = this.imageFolders;
            this.treeFolders.Location = new System.Drawing.Point(0, 0);
            this.treeFolders.Name = "treeFolders";
            treeNode7.Name = "/";
            treeNode7.Tag = "/";
            treeNode7.Text = "/";
            treeNode8.ImageKey = "Folder-App";
            treeNode8.Name = "_ApplicationsPXL";
            treeNode8.SelectedImageKey = "Folder-App";
            treeNode8.Tag = "//Applications";
            treeNode8.Text = "Applications (PXL)";
            treeNode9.ImageKey = "Folder-App";
            treeNode9.Name = "_ApplicationsNull";
            treeNode9.SelectedImageKey = "Folder-App";
            treeNode9.Tag = "//private/var/root/Library/Installer";
            treeNode9.Text = "Applications (nullriver)";
            treeNode10.ImageKey = "Folder-Audio";
            treeNode10.Name = "_Ringtones";
            treeNode10.SelectedImageKey = "Folder-Audio";
            treeNode10.Tag = "//var/root/Library/Ringtones";
            treeNode10.Text = "Ringtones";
            treeNode11.Name = "_SystemSounds";
            treeNode11.Text = "System Sounds";
            treeNode12.ImageKey = "Folder-Image";
            treeNode12.Name = "_Themes";
            treeNode12.SelectedImageKey = "Folder-Image";
            treeNode12.Tag = "//var/root/Media/Themes";
            treeNode12.Text = "Themes";
            this.treeFolders.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            this.treeFolders.PathSeparator = "/";
            this.treeFolders.SelectedImageIndex = 0;
            this.treeFolders.ShowRootLines = false;
            this.treeFolders.Size = new System.Drawing.Size(237, 382);
            this.treeFolders.TabIndex = 0;
            this.treeFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFolders_BeforeExpand);
            this.treeFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterSelect);
            // 
            // popupTree
            // 
            this.popupTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popupTreeRefresh,
            this.popupTreeCreateFolder,
            this.popupTreeCopy});
            this.popupTree.Name = "popupTree";
            this.popupTree.Size = new System.Drawing.Size(152, 70);
            this.popupTree.Text = "Folder Operations";
            // 
            // popupTreeRefresh
            // 
            this.popupTreeRefresh.Image = global::iPhoneList.Properties.Resources.Retry;
            this.popupTreeRefresh.Name = "popupTreeRefresh";
            this.popupTreeRefresh.Size = new System.Drawing.Size(151, 22);
            this.popupTreeRefresh.Text = "&Refresh";
            this.popupTreeRefresh.Click += new System.EventHandler(this.popupTreeRefresh_Click);
            // 
            // popupTreeCreateFolder
            // 
            this.popupTreeCreateFolder.Image = global::iPhoneList.Properties.Resources.NewFolderHS;
            this.popupTreeCreateFolder.Name = "popupTreeCreateFolder";
            this.popupTreeCreateFolder.Size = new System.Drawing.Size(151, 22);
            this.popupTreeCreateFolder.Text = "Create &Folder";
            this.popupTreeCreateFolder.Click += new System.EventHandler(this.popupTreeCreateFolder_Click);
            // 
            // popupTreeCopy
            // 
            this.popupTreeCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popupTreeCopyFolderName,
            this.popupTreeCopyFullPath});
            this.popupTreeCopy.Name = "popupTreeCopy";
            this.popupTreeCopy.Size = new System.Drawing.Size(151, 22);
            this.popupTreeCopy.Text = "&Copy";
            // 
            // popupTreeCopyFolderName
            // 
            this.popupTreeCopyFolderName.Name = "popupTreeCopyFolderName";
            this.popupTreeCopyFolderName.Size = new System.Drawing.Size(145, 22);
            this.popupTreeCopyFolderName.Tag = "FolderName";
            this.popupTreeCopyFolderName.Text = "&Folder Name";
            this.popupTreeCopyFolderName.Click += new System.EventHandler(this.popupTreeCopyMenu_Click);
            // 
            // popupTreeCopyFullPath
            // 
            this.popupTreeCopyFullPath.Name = "popupTreeCopyFullPath";
            this.popupTreeCopyFullPath.Size = new System.Drawing.Size(145, 22);
            this.popupTreeCopyFullPath.Tag = "FullPath";
            this.popupTreeCopyFullPath.Text = "Full &Path";
            this.popupTreeCopyFullPath.Click += new System.EventHandler(this.popupTreeCopyMenu_Click);
            // 
            // imageFolders
            // 
            this.imageFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageFolders.ImageStream")));
            this.imageFolders.TransparentColor = System.Drawing.Color.Transparent;
            this.imageFolders.Images.SetKeyName(0, "Folder");
            this.imageFolders.Images.SetKeyName(1, "Folder-App");
            this.imageFolders.Images.SetKeyName(2, "Folder-Audio");
            this.imageFolders.Images.SetKeyName(3, "Folder-Empty");
            this.imageFolders.Images.SetKeyName(4, "Folder-Files");
            this.imageFolders.Images.SetKeyName(5, "Folder-Image");
            this.imageFolders.Images.SetKeyName(6, "Folder-New");
            this.imageFolders.Images.SetKeyName(7, "Folder-Settings");
            this.imageFolders.Images.SetKeyName(8, "Folder-Video");
            // 
            // splitFilesViewer
            // 
            this.splitFilesViewer.BackColor = System.Drawing.SystemColors.Control;
            this.splitFilesViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitFilesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitFilesViewer.Location = new System.Drawing.Point(0, 0);
            this.splitFilesViewer.Name = "splitFilesViewer";
            this.splitFilesViewer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitFilesViewer.Panel1
            // 
            this.splitFilesViewer.Panel1.Controls.Add(this.listApps);
            this.splitFilesViewer.Panel1.Controls.Add(this.listFiles);
            // 
            // splitFilesViewer.Panel2
            // 
            this.splitFilesViewer.Panel2.Controls.Add(this.previewImageBox);
            this.splitFilesViewer.Panel2.Controls.Add(this.previewTextBox);
            this.splitFilesViewer.Panel2.Controls.Add(this.panelPreviewOptions);
            this.splitFilesViewer.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitFilesViewer.Size = new System.Drawing.Size(414, 386);
            this.splitFilesViewer.SplitterDistance = 199;
            this.splitFilesViewer.TabIndex = 1;
            this.splitFilesViewer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitFilesViewer_SplitterMoved);
            // 
            // listApps
            // 
            this.listApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAppTitle,
            this.colAppVersion,
            this.colAppDescription,
            this.colAppPublisher});
            this.listApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listApps.Location = new System.Drawing.Point(0, 0);
            this.listApps.Name = "listApps";
            this.listApps.Size = new System.Drawing.Size(410, 195);
            this.listApps.TabIndex = 1;
            this.listApps.UseCompatibleStateImageBehavior = false;
            this.listApps.View = System.Windows.Forms.View.Details;
            this.listApps.Visible = false;
            // 
            // colAppTitle
            // 
            this.colAppTitle.Tag = "AppTitle";
            this.colAppTitle.Text = "Title";
            // 
            // colAppVersion
            // 
            this.colAppVersion.Tag = "AppVersion";
            this.colAppVersion.Text = "Version";
            this.colAppVersion.Width = 32;
            // 
            // colAppDescription
            // 
            this.colAppDescription.Tag = "AppDescription";
            this.colAppDescription.Text = "Description";
            // 
            // colAppPublisher
            // 
            this.colAppPublisher.Tag = "AppPublisher";
            this.colAppPublisher.Text = "Publisher";
            // 
            // listFiles
            // 
            this.listFiles.AllowDrop = true;
            this.listFiles.AutoArrange = false;
            this.listFiles.BackColor = System.Drawing.SystemColors.Window;
            this.listFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFile,
            this.colSize,
            this.colType});
            this.listFiles.ContextMenuStrip = this.popupFiles;
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup14.Header = "Folders";
            listViewGroup14.Name = "listFilesFolderGroup";
            listViewGroup14.Tag = "Folder";
            listViewGroup15.Header = "App Folders";
            listViewGroup15.Name = "listFilesAppFolderGroup";
            listViewGroup15.Tag = "App Folder";
            listViewGroup16.Header = "Audio Folders";
            listViewGroup16.Name = "listFilesAudioFolderGroup";
            listViewGroup16.Tag = "Audio Folder";
            listViewGroup17.Header = "Image Folders";
            listViewGroup17.Name = "listFilesImgFolderGroup";
            listViewGroup17.Tag = "Image Folder";
            listViewGroup18.Header = "Application Files";
            listViewGroup18.Name = "listFilesAppGroup";
            listViewGroup18.Tag = "Application";
            listViewGroup19.Header = "Programs";
            listViewGroup19.Name = "listFilesProgramGroup";
            listViewGroup19.Tag = "Program";
            listViewGroup20.Header = "Documents";
            listViewGroup20.Name = "listFilesDocumentGroup";
            listViewGroup20.Tag = "Document";
            listViewGroup21.Header = "Image Files";
            listViewGroup21.Name = "listFilesImageGroup";
            listViewGroup21.Tag = "Image";
            listViewGroup22.Header = "Audio Files";
            listViewGroup22.Name = "listFilesAudioGroup";
            listViewGroup22.Tag = "Audio";
            listViewGroup23.Header = "Settings Files";
            listViewGroup23.Name = "listFilesSettingsGroup";
            listViewGroup23.Tag = "Settings";
            listViewGroup24.Header = "Devices";
            listViewGroup24.Name = "listFilesDeviceGroup";
            listViewGroup24.Tag = "Device";
            listViewGroup25.Header = "Links";
            listViewGroup25.Name = "listFilesLinkGroup";
            listViewGroup25.Tag = "Link";
            listViewGroup26.Header = "Other files";
            listViewGroup26.Name = "listFilesOtherGroup";
            listViewGroup26.Tag = "Other";
            this.listFiles.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup14,
            listViewGroup15,
            listViewGroup16,
            listViewGroup17,
            listViewGroup18,
            listViewGroup19,
            listViewGroup20,
            listViewGroup21,
            listViewGroup22,
            listViewGroup23,
            listViewGroup24,
            listViewGroup25,
            listViewGroup26});
            this.listFiles.LargeImageList = this.imageFilesLarge;
            this.listFiles.Location = new System.Drawing.Point(0, 0);
            this.listFiles.Name = "listFiles";
            this.listFiles.ShowItemToolTips = true;
            this.listFiles.Size = new System.Drawing.Size(410, 195);
            this.listFiles.SmallImageList = this.imageFilesSmall;
            this.listFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            this.listFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listFiles_DragEnter);
            this.listFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listFiles_DragDrop);
            this.listFiles.DoubleClick += new System.EventHandler(this.listFiles_DoubleClick);
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listFiles_SelectedIndexChanged);
            // 
            // colFile
            // 
            this.colFile.Text = "FileName";
            this.colFile.Width = 120;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSize.Width = 72;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 115;
            // 
            // popupFiles
            // 
            this.popupFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popFilesCreateFolder,
            this.popupFilesGetFiles,
            this.popupFilesDelete});
            this.popupFiles.Name = "popupFiles";
            this.popupFiles.Size = new System.Drawing.Size(152, 70);
            this.popupFiles.Text = "File Operations";
            // 
            // popFilesCreateFolder
            // 
            this.popFilesCreateFolder.Image = global::iPhoneList.Properties.Resources.NewFolderHS;
            this.popFilesCreateFolder.Name = "popFilesCreateFolder";
            this.popFilesCreateFolder.Size = new System.Drawing.Size(151, 22);
            this.popFilesCreateFolder.Text = "Create &Folder";
            this.popFilesCreateFolder.ToolTipText = "Create new folder here";
            this.popFilesCreateFolder.Click += new System.EventHandler(this.popupTreeCreateFolder_Click);
            // 
            // popupFilesGetFiles
            // 
            this.popupFilesGetFiles.Image = global::iPhoneList.Properties.Resources.CopyHS;
            this.popupFilesGetFiles.Name = "popupFilesGetFiles";
            this.popupFilesGetFiles.Size = new System.Drawing.Size(151, 22);
            this.popupFilesGetFiles.Text = "GetFiles";
            this.popupFilesGetFiles.Click += new System.EventHandler(this.popupFilesGetFiles_Click);
            // 
            // popupFilesDelete
            // 
            this.popupFilesDelete.Image = global::iPhoneList.Properties.Resources.DeleteHS;
            this.popupFilesDelete.Name = "popupFilesDelete";
            this.popupFilesDelete.Size = new System.Drawing.Size(151, 22);
            this.popupFilesDelete.Text = "Delete";
            this.popupFilesDelete.ToolTipText = "Delete files from iPhone";
            this.popupFilesDelete.Click += new System.EventHandler(this.popupFilesDelete_Click);
            // 
            // imageFilesLarge
            // 
            this.imageFilesLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageFilesLarge.ImageStream")));
            this.imageFilesLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageFilesLarge.Images.SetKeyName(0, "App");
            this.imageFilesLarge.Images.SetKeyName(1, "Audio");
            this.imageFilesLarge.Images.SetKeyName(2, "Device");
            this.imageFilesLarge.Images.SetKeyName(3, "Document");
            this.imageFilesLarge.Images.SetKeyName(4, "Folder");
            this.imageFilesLarge.Images.SetKeyName(5, "Folder-App");
            this.imageFilesLarge.Images.SetKeyName(6, "Folder-Audio");
            this.imageFilesLarge.Images.SetKeyName(7, "Folder-Empty");
            this.imageFilesLarge.Images.SetKeyName(8, "Folder-Files");
            this.imageFilesLarge.Images.SetKeyName(9, "Folder-Image");
            this.imageFilesLarge.Images.SetKeyName(10, "Folder-New");
            this.imageFilesLarge.Images.SetKeyName(11, "Folder-Settings");
            this.imageFilesLarge.Images.SetKeyName(12, "Folder-Video");
            this.imageFilesLarge.Images.SetKeyName(13, "Image");
            this.imageFilesLarge.Images.SetKeyName(14, "Other");
            this.imageFilesLarge.Images.SetKeyName(15, "Settings");
            this.imageFilesLarge.Images.SetKeyName(16, "Video");
            // 
            // imageFilesSmall
            // 
            this.imageFilesSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageFilesSmall.ImageStream")));
            this.imageFilesSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageFilesSmall.Images.SetKeyName(0, "App");
            this.imageFilesSmall.Images.SetKeyName(1, "Audio");
            this.imageFilesSmall.Images.SetKeyName(2, "Device");
            this.imageFilesSmall.Images.SetKeyName(3, "Document");
            this.imageFilesSmall.Images.SetKeyName(4, "Folder");
            this.imageFilesSmall.Images.SetKeyName(5, "Folder-App");
            this.imageFilesSmall.Images.SetKeyName(6, "Folder-Audio");
            this.imageFilesSmall.Images.SetKeyName(7, "Folder-Empty");
            this.imageFilesSmall.Images.SetKeyName(8, "Folder-Files");
            this.imageFilesSmall.Images.SetKeyName(9, "Folder-Image");
            this.imageFilesSmall.Images.SetKeyName(10, "Folder-New");
            this.imageFilesSmall.Images.SetKeyName(11, "Folder-Settings");
            this.imageFilesSmall.Images.SetKeyName(12, "Folder-Video");
            this.imageFilesSmall.Images.SetKeyName(13, "Image");
            this.imageFilesSmall.Images.SetKeyName(14, "Other");
            this.imageFilesSmall.Images.SetKeyName(15, "Settings");
            this.imageFilesSmall.Images.SetKeyName(16, "Video");
            // 
            // previewImageBox
            // 
            this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImageBox.Location = new System.Drawing.Point(2, 25);
            this.previewImageBox.Name = "previewImageBox";
            this.previewImageBox.Size = new System.Drawing.Size(406, 152);
            this.previewImageBox.TabIndex = 1;
            this.previewImageBox.TabStop = false;
            this.previewImageBox.Visible = false;
            // 
            // previewTextBox
            // 
            this.previewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewTextBox.Location = new System.Drawing.Point(2, 25);
            this.previewTextBox.Multiline = true;
            this.previewTextBox.Name = "previewTextBox";
            this.previewTextBox.ReadOnly = true;
            this.previewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.previewTextBox.Size = new System.Drawing.Size(406, 152);
            this.previewTextBox.TabIndex = 0;
            this.previewTextBox.Tag = "-";
            this.previewTextBox.WordWrap = false;
            // 
            // panelPreviewOptions
            // 
            this.panelPreviewOptions.Controls.Add(this.checkShowAll);
            this.panelPreviewOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPreviewOptions.Location = new System.Drawing.Point(2, 2);
            this.panelPreviewOptions.Name = "panelPreviewOptions";
            this.panelPreviewOptions.Size = new System.Drawing.Size(406, 23);
            this.panelPreviewOptions.TabIndex = 2;
            // 
            // checkShowAll
            // 
            this.checkShowAll.AutoSize = true;
            this.checkShowAll.Location = new System.Drawing.Point(8, 4);
            this.checkShowAll.Name = "checkShowAll";
            this.checkShowAll.Size = new System.Drawing.Size(67, 17);
            this.checkShowAll.TabIndex = 0;
            this.checkShowAll.Text = "Show All";
            this.checkShowAll.UseVisualStyleBackColor = true;
            this.checkShowAll.CheckedChanged += new System.EventHandler(this.checkShowAll_CheckedChanged);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 500;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // statusMain
            // 
            this.statusMain.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus,
            this.toolStripProgressBar1});
            this.statusMain.Location = new System.Drawing.Point(0, 460);
            this.statusMain.Name = "statusMain";
            this.statusMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusMain.Size = new System.Drawing.Size(659, 22);
            this.statusMain.TabIndex = 6;
            this.statusMain.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = false;
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(300, 17);
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolStripProgressBar1.Visible = false;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFile,
            this.menuMainTools,
            this.menuMainHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(659, 24);
            this.menuMain.TabIndex = 7;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuMainFile
            // 
            this.menuMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFileNew,
            this.menuMainFileExit});
            this.menuMainFile.Name = "menuMainFile";
            this.menuMainFile.Size = new System.Drawing.Size(35, 20);
            this.menuMainFile.Text = "&File";
            // 
            // menuMainFileNew
            // 
            this.menuMainFileNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFileNewFolder});
            this.menuMainFileNew.Name = "menuMainFileNew";
            this.menuMainFileNew.Size = new System.Drawing.Size(106, 22);
            this.menuMainFileNew.Text = "New";
            // 
            // menuMainFileNewFolder
            // 
            this.menuMainFileNewFolder.Name = "menuMainFileNewFolder";
            this.menuMainFileNewFolder.Size = new System.Drawing.Size(115, 22);
            this.menuMainFileNewFolder.Text = "Folder";
            // 
            // menuMainFileExit
            // 
            this.menuMainFileExit.Name = "menuMainFileExit";
            this.menuMainFileExit.Size = new System.Drawing.Size(106, 22);
            this.menuMainFileExit.Text = "Exit";
            this.menuMainFileExit.Click += new System.EventHandler(this.menuMainFileExit_Click);
            // 
            // menuMainTools
            // 
            this.menuMainTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainBackup,
            this.toolStripSeparator2,
            this.menuMainOptions});
            this.menuMainTools.Name = "menuMainTools";
            this.menuMainTools.Size = new System.Drawing.Size(44, 20);
            this.menuMainTools.Text = "&Tools";
            // 
            // menuMainBackup
            // 
            this.menuMainBackup.Name = "menuMainBackup";
            this.menuMainBackup.Size = new System.Drawing.Size(154, 22);
            this.menuMainBackup.Text = "Backup iPhone";
            this.menuMainBackup.Click += new System.EventHandler(this.menuMainBackup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // menuMainOptions
            // 
            this.menuMainOptions.Name = "menuMainOptions";
            this.menuMainOptions.Size = new System.Drawing.Size(154, 22);
            this.menuMainOptions.Text = "&Options";
            this.menuMainOptions.Click += new System.EventHandler(this.menuMainOptions_Click);
            // 
            // menuMainHelp
            // 
            this.menuMainHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainHelpAbout});
            this.menuMainHelp.Name = "menuMainHelp";
            this.menuMainHelp.Size = new System.Drawing.Size(40, 20);
            this.menuMainHelp.Text = "&Help";
            // 
            // menuMainHelpAbout
            // 
            this.menuMainHelpAbout.Name = "menuMainHelpAbout";
            this.menuMainHelpAbout.Size = new System.Drawing.Size(114, 22);
            this.menuMainHelpAbout.Text = "About";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelList);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(659, 386);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(659, 436);
            this.toolStripContainer1.TabIndex = 10;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolsFileView);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolsMain);
            // 
            // toolsFileView
            // 
            this.toolsFileView.Dock = System.Windows.Forms.DockStyle.None;
            this.toolsFileView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsFileViewSelect,
            this.toolsFileViewPreview,
            this.toolsFileFavorites});
            this.toolsFileView.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolsFileView.Location = new System.Drawing.Point(3, 0);
            this.toolsFileView.Name = "toolsFileView";
            this.toolsFileView.Size = new System.Drawing.Size(194, 25);
            this.toolsFileView.TabIndex = 1;
            // 
            // toolsFileViewSelect
            // 
            this.toolsFileViewSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsFileViewSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolItemViewSmallIcons,
            this.toolItemViewLargeIcons,
            this.toolItemViewList,
            this.toolItemViewDetails});
            this.toolsFileViewSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolsFileViewSelect.Image")));
            this.toolsFileViewSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsFileViewSelect.Name = "toolsFileViewSelect";
            this.toolsFileViewSelect.Size = new System.Drawing.Size(42, 22);
            this.toolsFileViewSelect.Text = "View";
            // 
            // toolItemViewSmallIcons
            // 
            this.toolItemViewSmallIcons.Name = "toolItemViewSmallIcons";
            this.toolItemViewSmallIcons.Size = new System.Drawing.Size(141, 22);
            this.toolItemViewSmallIcons.Text = "Small Icons";
            this.toolItemViewSmallIcons.Click += new System.EventHandler(this.toolItemViewSmallIcons_Click);
            // 
            // toolItemViewLargeIcons
            // 
            this.toolItemViewLargeIcons.Name = "toolItemViewLargeIcons";
            this.toolItemViewLargeIcons.Size = new System.Drawing.Size(141, 22);
            this.toolItemViewLargeIcons.Text = "Large Icons";
            this.toolItemViewLargeIcons.Click += new System.EventHandler(this.toolItemViewSmallIcons_Click);
            // 
            // toolItemViewList
            // 
            this.toolItemViewList.Name = "toolItemViewList";
            this.toolItemViewList.Size = new System.Drawing.Size(141, 22);
            this.toolItemViewList.Text = "List";
            this.toolItemViewList.Click += new System.EventHandler(this.toolItemViewSmallIcons_Click);
            // 
            // toolItemViewDetails
            // 
            this.toolItemViewDetails.Name = "toolItemViewDetails";
            this.toolItemViewDetails.Size = new System.Drawing.Size(141, 22);
            this.toolItemViewDetails.Text = "Details";
            this.toolItemViewDetails.Click += new System.EventHandler(this.toolItemViewSmallIcons_Click);
            // 
            // toolsFileViewPreview
            // 
            this.toolsFileViewPreview.Image = global::iPhoneList.Properties.Resources.ThumbnailLoadingHS;
            this.toolsFileViewPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsFileViewPreview.Name = "toolsFileViewPreview";
            this.toolsFileViewPreview.Size = new System.Drawing.Size(65, 22);
            this.toolsFileViewPreview.Text = "Preview";
            this.toolsFileViewPreview.ToolTipText = "Toggle Preview window on / off";
            this.toolsFileViewPreview.Click += new System.EventHandler(this.toolsFileViewPreview_Click);
            // 
            // toolsFileFavorites
            // 
            this.toolsFileFavorites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsFileFavorites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsFileNewLocation,
            this.toolStripSeparator1});
            this.toolsFileFavorites.Image = ((System.Drawing.Image)(resources.GetObject("toolsFileFavorites.Image")));
            this.toolsFileFavorites.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsFileFavorites.Name = "toolsFileFavorites";
            this.toolsFileFavorites.Size = new System.Drawing.Size(75, 22);
            this.toolsFileFavorites.Text = "iPhoneLinks";
            this.toolsFileFavorites.ToolTipText = "Favorites";
            // 
            // toolsFileNewLocation
            // 
            this.toolsFileNewLocation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsFileNewLocation.Name = "toolsFileNewLocation";
            this.toolsFileNewLocation.Size = new System.Drawing.Size(165, 22);
            this.toolsFileNewLocation.Text = "AddNewLocation";
            this.toolsFileNewLocation.Click += new System.EventHandler(this.toolsFileNewLocation_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // toolsMain
            // 
            this.toolsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolItemRefresh,
            this.toolItemGetFiles,
            this.toolItemDelete,
            this.toolItemCancel});
            this.toolsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolsMain.Location = new System.Drawing.Point(3, 25);
            this.toolsMain.Name = "toolsMain";
            this.toolsMain.Size = new System.Drawing.Size(200, 25);
            this.toolsMain.TabIndex = 0;
            // 
            // toolItemRefresh
            // 
            this.toolItemRefresh.Image = global::iPhoneList.Properties.Resources.Retry;
            this.toolItemRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemRefresh.Name = "toolItemRefresh";
            this.toolItemRefresh.Size = new System.Drawing.Size(65, 22);
            this.toolItemRefresh.Text = "Refresh";
            this.toolItemRefresh.Click += new System.EventHandler(this.toolItemRefresh_Click);
            // 
            // toolItemGetFiles
            // 
            this.toolItemGetFiles.Image = global::iPhoneList.Properties.Resources.CopyHS;
            this.toolItemGetFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemGetFiles.Name = "toolItemGetFiles";
            this.toolItemGetFiles.Size = new System.Drawing.Size(65, 22);
            this.toolItemGetFiles.Text = "GetFiles";
            this.toolItemGetFiles.Click += new System.EventHandler(this.popupFilesGetFiles_Click);
            // 
            // toolItemDelete
            // 
            this.toolItemDelete.Image = global::iPhoneList.Properties.Resources.DeleteHS;
            this.toolItemDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemDelete.Name = "toolItemDelete";
            this.toolItemDelete.Size = new System.Drawing.Size(58, 22);
            this.toolItemDelete.Text = "Delete";
            this.toolItemDelete.Click += new System.EventHandler(this.popupFilesDelete_Click);
            // 
            // toolItemCancel
            // 
            this.toolItemCancel.Image = global::iPhoneList.Properties.Resources.StopHS;
            this.toolItemCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemCancel.Name = "toolItemCancel";
            this.toolItemCancel.Size = new System.Drawing.Size(87, 22);
            this.toolItemCancel.Text = "Cancel Copy";
            this.toolItemCancel.Visible = false;
            this.toolItemCancel.Click += new System.EventHandler(this.toolItemCancel_Click);
            // 
            // iPhoneList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 482);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "iPhoneList";
            this.Text = " iPhoneList";
            this.Resize += new System.EventHandler(this.iPhoneList_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.iPhoneList_FormClosing);
            this.panelList.Panel1.ResumeLayout(false);
            this.panelList.Panel2.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.popupTree.ResumeLayout(false);
            this.splitFilesViewer.Panel1.ResumeLayout(false);
            this.splitFilesViewer.Panel2.ResumeLayout(false);
            this.splitFilesViewer.Panel2.PerformLayout();
            this.splitFilesViewer.ResumeLayout(false);
            this.popupFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).EndInit();
            this.panelPreviewOptions.ResumeLayout(false);
            this.panelPreviewOptions.PerformLayout();
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolsFileView.ResumeLayout(false);
            this.toolsFileView.PerformLayout();
            this.toolsMain.ResumeLayout(false);
            this.toolsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer panelList;
        private System.Windows.Forms.TreeView treeFolders;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ColumnHeader colFile;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.SplitContainer splitFilesViewer;
        private System.Windows.Forms.ImageList imageFolders;
        private System.Windows.Forms.ImageList imageFilesLarge;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ContextMenuStrip popupTree;
        private System.Windows.Forms.ContextMenuStrip popupFiles;
        private System.Windows.Forms.ToolStripMenuItem menuMainFile;
        private System.Windows.Forms.ToolStripMenuItem menuMainFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuMainFileNewFolder;
        private System.Windows.Forms.ToolStripMenuItem menuMainFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuMainHelp;
        private System.Windows.Forms.ToolStripMenuItem menuMainHelpAbout;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStrip toolsMain;
        private System.Windows.Forms.ToolStripButton toolItemRefresh;
        private System.Windows.Forms.ToolStripButton toolItemGetFiles;
        private System.Windows.Forms.ToolStripButton toolItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuMainTools;
        private System.Windows.Forms.ToolStripMenuItem popupFilesGetFiles;
        private System.Windows.Forms.ToolStripMenuItem popupFilesDelete;
        private System.Windows.Forms.ToolStripMenuItem menuMainOptions;
        private System.Windows.Forms.TextBox previewTextBox;
        private System.Windows.Forms.PictureBox previewImageBox;
        private System.Windows.Forms.ToolStripMenuItem popupTreeRefresh;
        private System.Windows.Forms.ToolStripMenuItem popupTreeCreateFolder;
        private System.Windows.Forms.ToolStripButton toolItemCancel;
        private System.Windows.Forms.ImageList imageFilesSmall;
        private System.Windows.Forms.ToolStripMenuItem popFilesCreateFolder;
        private System.Windows.Forms.ToolStrip toolsFileView;
        private System.Windows.Forms.ToolStripDropDownButton toolsFileViewSelect;
        private System.Windows.Forms.ToolStripMenuItem toolItemViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem toolItemViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem toolItemViewList;
        private System.Windows.Forms.ToolStripMenuItem toolItemViewDetails;
        private System.Windows.Forms.ToolStripButton toolsFileViewPreview;
        private System.Windows.Forms.ToolStripMenuItem menuMainBackup;
        private System.Windows.Forms.ToolStripDropDownButton toolsFileFavorites;
        private System.Windows.Forms.ToolStripMenuItem toolsFileNewLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panelPreviewOptions;
        private System.Windows.Forms.CheckBox checkShowAll;
        private System.Windows.Forms.ListView listApps;
        private System.Windows.Forms.ColumnHeader colAppTitle;
        private System.Windows.Forms.ColumnHeader colAppVersion;
        private System.Windows.Forms.ColumnHeader colAppDescription;
        private System.Windows.Forms.ColumnHeader colAppPublisher;
        private System.Windows.Forms.ToolStripMenuItem popupTreeCopy;
        private System.Windows.Forms.ToolStripMenuItem popupTreeCopyFolderName;
        private System.Windows.Forms.ToolStripMenuItem popupTreeCopyFullPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

