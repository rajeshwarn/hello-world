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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iPhoneList));
            this.panelList = new System.Windows.Forms.SplitContainer();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.imageFolders = new System.Windows.Forms.ImageList(this.components);
            this.splitFilesViewer = new System.Windows.Forms.SplitContainer();
            this.listFiles = new System.Windows.Forms.ListView();
            this.colFile = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colFileIcon = new System.Windows.Forms.ColumnHeader();
            this.imageFilesLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageFilesSmall = new System.Windows.Forms.ImageList(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainFileNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.popupTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.popupFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolsFileView = new System.Windows.Forms.ToolStrip();
            this.menuMainTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.previewTextBox = new System.Windows.Forms.TextBox();
            this.popupTreeRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.popupTreeCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.popupFilesGetFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.popupFilesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.previewImageBox = new System.Windows.Forms.PictureBox();
            this.toolsFileViewSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolItemViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItemViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItemViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItemViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolItemRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolItemGetFiles = new System.Windows.Forms.ToolStripButton();
            this.toolItemDelete = new System.Windows.Forms.ToolStripButton();
            this.toolItemCancel = new System.Windows.Forms.ToolStripButton();
            this.panelList.Panel1.SuspendLayout();
            this.panelList.Panel2.SuspendLayout();
            this.panelList.SuspendLayout();
            this.splitFilesViewer.Panel1.SuspendLayout();
            this.splitFilesViewer.Panel2.SuspendLayout();
            this.splitFilesViewer.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.popupTree.SuspendLayout();
            this.popupFiles.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolsMain.SuspendLayout();
            this.toolsFileView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelList
            // 
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
            this.panelList.Size = new System.Drawing.Size(626, 438);
            this.panelList.SplitterDistance = 229;
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
            this.treeFolders.SelectedImageIndex = 0;
            this.treeFolders.Size = new System.Drawing.Size(225, 434);
            this.treeFolders.TabIndex = 0;
            this.treeFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFolders_BeforeExpand);
            this.treeFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterSelect);
            // 
            // imageFolders
            // 
            this.imageFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageFolders.ImageStream")));
            this.imageFolders.TransparentColor = System.Drawing.Color.Transparent;
            this.imageFolders.Images.SetKeyName(0, "Computer.ico");
            this.imageFolders.Images.SetKeyName(1, "Folder.ico");
            this.imageFolders.Images.SetKeyName(2, "Developer Folder.ico");
            this.imageFolders.Images.SetKeyName(3, "Documents Folder.ico");
            this.imageFolders.Images.SetKeyName(4, "Movies Folder.ico");
            this.imageFolders.Images.SetKeyName(5, "Music Folder.ico");
            this.imageFolders.Images.SetKeyName(6, "Pictures Folder.ico");
            // 
            // splitFilesViewer
            // 
            this.splitFilesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitFilesViewer.Location = new System.Drawing.Point(0, 0);
            this.splitFilesViewer.Name = "splitFilesViewer";
            this.splitFilesViewer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitFilesViewer.Panel1
            // 
            this.splitFilesViewer.Panel1.Controls.Add(this.listFiles);
            // 
            // splitFilesViewer.Panel2
            // 
            this.splitFilesViewer.Panel2.Controls.Add(this.previewImageBox);
            this.splitFilesViewer.Panel2.Controls.Add(this.previewTextBox);
            this.splitFilesViewer.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitFilesViewer.Size = new System.Drawing.Size(389, 434);
            this.splitFilesViewer.SplitterDistance = 283;
            this.splitFilesViewer.TabIndex = 1;
            // 
            // listFiles
            // 
            this.listFiles.AllowDrop = true;
            this.listFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFile,
            this.colSize,
            this.colType,
            this.colFileIcon});
            this.listFiles.ContextMenuStrip = this.popupFiles;
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.LargeImageList = this.imageFilesLarge;
            this.listFiles.Location = new System.Drawing.Point(0, 0);
            this.listFiles.Name = "listFiles";
            this.listFiles.ShowItemToolTips = true;
            this.listFiles.Size = new System.Drawing.Size(389, 283);
            this.listFiles.SmallImageList = this.imageFilesSmall;
            this.listFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            this.listFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listFiles_DragEnter);
            this.listFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listFiles_DragDrop);
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
            this.colType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colType.Width = 115;
            // 
            // colFileIcon
            // 
            this.colFileIcon.Width = 18;
            // 
            // imageFilesLarge
            // 
            this.imageFilesLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageFilesLarge.ImageStream")));
            this.imageFilesLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageFilesLarge.Images.SetKeyName(0, "ASX.ico");
            this.imageFilesLarge.Images.SetKeyName(1, "CDA.ico");
            this.imageFilesLarge.Images.SetKeyName(2, "M3U.ico");
            this.imageFilesLarge.Images.SetKeyName(3, "MP3.ico");
            this.imageFilesLarge.Images.SetKeyName(4, "OGG.ico");
            this.imageFilesLarge.Images.SetKeyName(5, "WAV.ico");
            this.imageFilesLarge.Images.SetKeyName(6, "WMA.ico");
            this.imageFilesLarge.Images.SetKeyName(7, "WMV.ico");
            this.imageFilesLarge.Images.SetKeyName(8, "ACE.ico");
            this.imageFilesLarge.Images.SetKeyName(9, "RAR.ico");
            this.imageFilesLarge.Images.SetKeyName(10, "SIT.ico");
            this.imageFilesLarge.Images.SetKeyName(11, "ZIP.ico");
            this.imageFilesLarge.Images.SetKeyName(12, "PSD.ico");
            this.imageFilesLarge.Images.SetKeyName(13, "BMP.ico");
            this.imageFilesLarge.Images.SetKeyName(14, "GIF.ico");
            this.imageFilesLarge.Images.SetKeyName(15, "JPG.ico");
            this.imageFilesLarge.Images.SetKeyName(16, "PNG.ico");
            this.imageFilesLarge.Images.SetKeyName(17, "Blank.ico");
            this.imageFilesLarge.Images.SetKeyName(18, "Document.ico");
            this.imageFilesLarge.Images.SetKeyName(19, "HTM.ico");
            this.imageFilesLarge.Images.SetKeyName(20, "HTML.ico");
            this.imageFilesLarge.Images.SetKeyName(21, "TXT.ico");
            this.imageFilesLarge.Images.SetKeyName(22, "TXT2.ico");
            this.imageFilesLarge.Images.SetKeyName(23, "AVI.ico");
            this.imageFilesLarge.Images.SetKeyName(24, "DivX.ico");
            this.imageFilesLarge.Images.SetKeyName(25, "MPG.ico");
            this.imageFilesLarge.Images.SetKeyName(26, "MOV.ico");
            this.imageFilesLarge.Images.SetKeyName(27, "Open Folder yellow.ico");
            this.imageFilesLarge.Images.SetKeyName(28, "Closed Folder yellow.ico");
            this.imageFilesLarge.Images.SetKeyName(29, "Program Files Folder.ico");
            this.imageFilesLarge.Images.SetKeyName(30, "Control Panel2.ico");
            this.imageFilesLarge.Images.SetKeyName(31, "My Documents.ico");
            this.imageFilesLarge.Images.SetKeyName(32, "My Music2.ico");
            this.imageFilesLarge.Images.SetKeyName(33, "My Pictures4.ico");
            // 
            // imageFilesSmall
            // 
            this.imageFilesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageFilesSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageFilesSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 500;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // statusMain
            // 
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus,
            this.toolStripProgressBar1});
            this.statusMain.Location = new System.Drawing.Point(0, 487);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(626, 22);
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
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainFile,
            this.menuMainTools,
            this.menuMainHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(626, 24);
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
            // popupTree
            // 
            this.popupTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popupTreeRefresh,
            this.popupTreeCreateFolder});
            this.popupTree.Name = "popupTree";
            this.popupTree.Size = new System.Drawing.Size(152, 48);
            this.popupTree.Text = "Folder Operations";
            // 
            // popupFiles
            // 
            this.popupFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popupFilesGetFiles,
            this.popupFilesDelete});
            this.popupFiles.Name = "popupFiles";
            this.popupFiles.Size = new System.Drawing.Size(124, 48);
            this.popupFiles.Text = "File Operations";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelList);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(626, 438);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(626, 463);
            this.toolStripContainer1.TabIndex = 10;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolsFileView);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolsMain);
            // 
            // toolsMain
            // 
            this.toolsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolItemRefresh,
            this.toolItemGetFiles,
            this.toolItemDelete,
            this.toolItemCancel});
            this.toolsMain.Location = new System.Drawing.Point(57, 0);
            this.toolsMain.Name = "toolsMain";
            this.toolsMain.Size = new System.Drawing.Size(200, 25);
            this.toolsMain.TabIndex = 0;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolsFileView
            // 
            this.toolsFileView.Dock = System.Windows.Forms.DockStyle.None;
            this.toolsFileView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsFileViewSelect});
            this.toolsFileView.Location = new System.Drawing.Point(3, 0);
            this.toolsFileView.Name = "toolsFileView";
            this.toolsFileView.Size = new System.Drawing.Size(54, 25);
            this.toolsFileView.TabIndex = 1;
            // 
            // menuMainTools
            // 
            this.menuMainTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainOptions});
            this.menuMainTools.Name = "menuMainTools";
            this.menuMainTools.Size = new System.Drawing.Size(44, 20);
            this.menuMainTools.Text = "&Tools";
            // 
            // menuMainOptions
            // 
            this.menuMainOptions.Name = "menuMainOptions";
            this.menuMainOptions.Size = new System.Drawing.Size(122, 22);
            this.menuMainOptions.Text = "&Options";
            // 
            // previewTextBox
            // 
            this.previewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewTextBox.Location = new System.Drawing.Point(2, 2);
            this.previewTextBox.Multiline = true;
            this.previewTextBox.Name = "previewTextBox";
            this.previewTextBox.Size = new System.Drawing.Size(385, 143);
            this.previewTextBox.TabIndex = 0;
            // 
            // popupTreeRefresh
            // 
            this.popupTreeRefresh.Image = global::iPhoneGUI.Properties.Resources.Retry;
            this.popupTreeRefresh.Name = "popupTreeRefresh";
            this.popupTreeRefresh.Size = new System.Drawing.Size(151, 22);
            this.popupTreeRefresh.Text = "&Refresh";
            this.popupTreeRefresh.Click += new System.EventHandler(this.popupTreeRefresh_Click);
            // 
            // popupTreeCreateFolder
            // 
            this.popupTreeCreateFolder.Image = global::iPhoneGUI.Properties.Resources.NewFolderHS;
            this.popupTreeCreateFolder.Name = "popupTreeCreateFolder";
            this.popupTreeCreateFolder.Size = new System.Drawing.Size(151, 22);
            this.popupTreeCreateFolder.Text = "Create &Folder";
            this.popupTreeCreateFolder.Click += new System.EventHandler(this.popupTreeCreateFolder_Click);
            // 
            // popupFilesGetFiles
            // 
            this.popupFilesGetFiles.Image = global::iPhoneGUI.Properties.Resources.CopyHS;
            this.popupFilesGetFiles.Name = "popupFilesGetFiles";
            this.popupFilesGetFiles.Size = new System.Drawing.Size(123, 22);
            this.popupFilesGetFiles.Text = "GetFiles";
            this.popupFilesGetFiles.Click += new System.EventHandler(this.popupFilesGetFiles_Click);
            // 
            // popupFilesDelete
            // 
            this.popupFilesDelete.Image = global::iPhoneGUI.Properties.Resources.DeleteHS;
            this.popupFilesDelete.Name = "popupFilesDelete";
            this.popupFilesDelete.Size = new System.Drawing.Size(123, 22);
            this.popupFilesDelete.Text = "Delete";
            this.popupFilesDelete.ToolTipText = "Delete files from iPhone";
            this.popupFilesDelete.Click += new System.EventHandler(this.popupFilesDelete_Click);
            // 
            // previewImageBox
            // 
            this.previewImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImageBox.Location = new System.Drawing.Point(2, 2);
            this.previewImageBox.Name = "previewImageBox";
            this.previewImageBox.Size = new System.Drawing.Size(385, 143);
            this.previewImageBox.TabIndex = 1;
            this.previewImageBox.TabStop = false;
            this.previewImageBox.Visible = false;
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
            // 
            // toolItemViewLargeIcons
            // 
            this.toolItemViewLargeIcons.Name = "toolItemViewLargeIcons";
            this.toolItemViewLargeIcons.Size = new System.Drawing.Size(141, 22);
            this.toolItemViewLargeIcons.Text = "Large Icons";
            // 
            // toolItemViewList
            // 
            this.toolItemViewList.Name = "toolItemViewList";
            this.toolItemViewList.Size = new System.Drawing.Size(141, 22);
            this.toolItemViewList.Text = "List";
            // 
            // toolItemViewDetails
            // 
            this.toolItemViewDetails.Name = "toolItemViewDetails";
            this.toolItemViewDetails.Size = new System.Drawing.Size(141, 22);
            this.toolItemViewDetails.Text = "Details";
            // 
            // toolItemRefresh
            // 
            this.toolItemRefresh.Image = global::iPhoneGUI.Properties.Resources.Retry;
            this.toolItemRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemRefresh.Name = "toolItemRefresh";
            this.toolItemRefresh.Size = new System.Drawing.Size(65, 22);
            this.toolItemRefresh.Text = "Refresh";
            this.toolItemRefresh.Click += new System.EventHandler(this.toolItemRefresh_Click);
            // 
            // toolItemGetFiles
            // 
            this.toolItemGetFiles.Image = global::iPhoneGUI.Properties.Resources.CopyHS;
            this.toolItemGetFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemGetFiles.Name = "toolItemGetFiles";
            this.toolItemGetFiles.Size = new System.Drawing.Size(65, 22);
            this.toolItemGetFiles.Text = "GetFiles";
            this.toolItemGetFiles.Click += new System.EventHandler(this.popupFilesGetFiles_Click);
            // 
            // toolItemDelete
            // 
            this.toolItemDelete.Image = global::iPhoneGUI.Properties.Resources.DeleteHS;
            this.toolItemDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemDelete.Name = "toolItemDelete";
            this.toolItemDelete.Size = new System.Drawing.Size(58, 22);
            this.toolItemDelete.Text = "Delete";
            this.toolItemDelete.Click += new System.EventHandler(this.popupFilesDelete_Click);
            // 
            // toolItemCancel
            // 
            this.toolItemCancel.Image = global::iPhoneGUI.Properties.Resources.StopHS;
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
            this.ClientSize = new System.Drawing.Size(626, 509);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "iPhoneList";
            this.Text = " ";
            this.Resize += new System.EventHandler(this.iPhoneList_Resize);
            this.panelList.Panel1.ResumeLayout(false);
            this.panelList.Panel2.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.splitFilesViewer.Panel1.ResumeLayout(false);
            this.splitFilesViewer.Panel2.ResumeLayout(false);
            this.splitFilesViewer.Panel2.PerformLayout();
            this.splitFilesViewer.ResumeLayout(false);
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.popupTree.ResumeLayout(false);
            this.popupFiles.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolsMain.ResumeLayout(false);
            this.toolsMain.PerformLayout();
            this.toolsFileView.ResumeLayout(false);
            this.toolsFileView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).EndInit();
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
        private System.Windows.Forms.ColumnHeader colFileIcon;
        private System.Windows.Forms.SplitContainer splitFilesViewer;
        private System.Windows.Forms.ImageList imageFolders;
        private System.Windows.Forms.ImageList imageFilesLarge;
        private System.Windows.Forms.ImageList imageFilesSmall;
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
        private System.Windows.Forms.ToolStrip toolsFileView;
        private System.Windows.Forms.ToolStripDropDownButton toolsFileViewSelect;
        private System.Windows.Forms.ToolStripMenuItem toolItemViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem toolItemViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem toolItemViewList;
        private System.Windows.Forms.ToolStripMenuItem toolItemViewDetails;
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
    }
}

