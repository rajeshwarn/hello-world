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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.panelAction = new System.Windows.Forms.Panel();
            this.buttonActionOK = new System.Windows.Forms.Button();
            this.textActionEntry = new System.Windows.Forms.TextBox();
            this.labelAction = new System.Windows.Forms.Label();
            this.buttonActionCancel = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.textStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelList = new System.Windows.Forms.SplitContainer();
            this.treeFolders = new System.Windows.Forms.TreeView();
            this.menuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listFiles = new System.Windows.Forms.ListView();
            this.colFile = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.menuFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFilesCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFilesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageFolders = new System.Windows.Forms.ImageList(this.components);
            this.imageFilesSmall = new System.Windows.Forms.ImageList(this.components);
            this.imageFilesLarge = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.panelList.Panel1.SuspendLayout();
            this.panelList.Panel2.SuspendLayout();
            this.panelList.SuspendLayout();
            this.menuTree.SuspendLayout();
            this.menuFiles.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(619, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem2,
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem2.Text = "Cut";
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Enabled = false;
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Enabled = false;
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(138, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRefresh,
            this.toolStripCopy,
            this.toolStripDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(619, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.Image = global::iPhoneGUI.Properties.Resources.Retry;
            this.toolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.Size = new System.Drawing.Size(65, 22);
            this.toolStripRefresh.Text = "Refresh";
            this.toolStripRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripCopy
            // 
            this.toolStripCopy.Image = global::iPhoneGUI.Properties.Resources.CopyHS;
            this.toolStripCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCopy.Name = "toolStripCopy";
            this.toolStripCopy.Size = new System.Drawing.Size(52, 22);
            this.toolStripCopy.Text = "Copy";
            this.toolStripCopy.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Image = global::iPhoneGUI.Properties.Resources.DeleteHS;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(58, 22);
            this.toolStripDelete.Text = "Delete";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.buttonActionOK);
            this.panelAction.Controls.Add(this.textActionEntry);
            this.panelAction.Controls.Add(this.labelAction);
            this.panelAction.Controls.Add(this.buttonActionCancel);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAction.Location = new System.Drawing.Point(0, 49);
            this.panelAction.Name = "panelAction";
            this.panelAction.Padding = new System.Windows.Forms.Padding(5);
            this.panelAction.Size = new System.Drawing.Size(619, 32);
            this.panelAction.TabIndex = 2;
            this.panelAction.Visible = false;
            // 
            // buttonActionOK
            // 
            this.buttonActionOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonActionOK.Location = new System.Drawing.Point(531, 5);
            this.buttonActionOK.Name = "buttonActionOK";
            this.buttonActionOK.Size = new System.Drawing.Size(33, 22);
            this.buttonActionOK.TabIndex = 3;
            this.buttonActionOK.Text = "OK";
            this.buttonActionOK.UseVisualStyleBackColor = true;
            // 
            // textActionEntry
            // 
            this.textActionEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textActionEntry.Location = new System.Drawing.Point(77, 5);
            this.textActionEntry.Name = "textActionEntry";
            this.textActionEntry.Size = new System.Drawing.Size(487, 20);
            this.textActionEntry.TabIndex = 2;
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAction.Location = new System.Drawing.Point(5, 5);
            this.labelAction.Name = "labelAction";
            this.labelAction.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelAction.Size = new System.Drawing.Size(72, 18);
            this.labelAction.TabIndex = 1;
            this.labelAction.Text = "Action Here...";
            // 
            // buttonActionCancel
            // 
            this.buttonActionCancel.AutoSize = true;
            this.buttonActionCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonActionCancel.Location = new System.Drawing.Point(564, 5);
            this.buttonActionCancel.Name = "buttonActionCancel";
            this.buttonActionCancel.Size = new System.Drawing.Size(50, 22);
            this.buttonActionCancel.TabIndex = 0;
            this.buttonActionCancel.Text = "Cancel";
            this.buttonActionCancel.UseVisualStyleBackColor = true;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 465);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(619, 22);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "statusStrip1";
            // 
            // textStatus
            // 
            this.textStatus.AutoSize = false;
            this.textStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.textStatus.Name = "textStatus";
            this.textStatus.Size = new System.Drawing.Size(300, 17);
            this.textStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelList
            // 
            this.panelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 81);
            this.panelList.Name = "panelList";
            // 
            // panelList.Panel1
            // 
            this.panelList.Panel1.Controls.Add(this.treeFolders);
            // 
            // panelList.Panel2
            // 
            this.panelList.Panel2.Controls.Add(this.splitContainer1);
            this.panelList.Size = new System.Drawing.Size(619, 384);
            this.panelList.SplitterDistance = 227;
            this.panelList.TabIndex = 5;
            // 
            // treeFolders
            // 
            this.treeFolders.ContextMenuStrip = this.menuTree;
            this.treeFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFolders.ImageIndex = 0;
            this.treeFolders.ImageList = this.imageFolders;
            this.treeFolders.Location = new System.Drawing.Point(0, 0);
            this.treeFolders.Name = "treeFolders";
            this.treeFolders.SelectedImageIndex = 0;
            this.treeFolders.Size = new System.Drawing.Size(223, 380);
            this.treeFolders.TabIndex = 0;
            this.treeFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeFolders_MouseClick);
            this.treeFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeFolders_BeforeExpand);
            this.treeFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterSelect);
            // 
            // menuTree
            // 
            this.menuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1,
            this.createFolderToolStripMenuItem});
            this.menuTree.Name = "menuTree";
            this.menuTree.Size = new System.Drawing.Size(152, 48);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.deleteToolStripMenuItem1.Text = "&Delete Folder";
            // 
            // createFolderToolStripMenuItem
            // 
            this.createFolderToolStripMenuItem.Name = "createFolderToolStripMenuItem";
            this.createFolderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.createFolderToolStripMenuItem.Text = "C&reate Folder";
            this.createFolderToolStripMenuItem.Click += new System.EventHandler(this.createFolderToolStripMenuItem_Click);
            // 
            // listFiles
            // 
            this.listFiles.AllowDrop = true;
            this.listFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFile,
            this.colSize,
            this.colType});
            this.listFiles.ContextMenuStrip = this.menuFiles;
            this.listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFiles.Location = new System.Drawing.Point(0, 0);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(384, 251);
            this.listFiles.TabIndex = 0;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            this.listFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listFiles_DragEnter);
            this.listFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listFiles_DragDrop);
            this.listFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listFiles_MouseClick);
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
            // 
            // menuFiles
            // 
            this.menuFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.menuFilesCopy,
            this.pasteToolStripMenuItem,
            this.menuFilesDelete});
            this.menuFiles.Name = "menuFiles";
            this.menuFiles.Size = new System.Drawing.Size(117, 92);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Enabled = false;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.cutToolStripMenuItem.Text = "C&ut";
            // 
            // menuFilesCopy
            // 
            this.menuFilesCopy.Name = "menuFilesCopy";
            this.menuFilesCopy.Size = new System.Drawing.Size(116, 22);
            this.menuFilesCopy.Text = "&Copy";
            this.menuFilesCopy.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Enabled = false;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // menuFilesDelete
            // 
            this.menuFilesDelete.Name = "menuFilesDelete";
            this.menuFilesDelete.Size = new System.Drawing.Size(116, 22);
            this.menuFilesDelete.Text = "&Delete";
            this.menuFilesDelete.Click += new System.EventHandler(this.menuFilesDelete_Click);
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::iPhoneGUI.Properties.Resources.Retry;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listFiles);
            this.splitContainer1.Size = new System.Drawing.Size(384, 380);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 1;
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
            // imageFilesSmall
            // 
            this.imageFilesSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageFilesSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageFilesSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageFilesLarge
            // 
            this.imageFilesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageFilesLarge.ImageSize = new System.Drawing.Size(16, 16);
            this.imageFilesLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // iPhoneList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 487);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "iPhoneList";
            this.Text = "iPhoneList";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.panelList.Panel1.ResumeLayout(false);
            this.panelList.Panel2.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.menuTree.ResumeLayout(false);
            this.menuFiles.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Button buttonActionCancel;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel textStatus;
        private System.Windows.Forms.SplitContainer panelList;
        private System.Windows.Forms.TreeView treeFolders;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ColumnHeader colFile;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ContextMenuStrip menuFiles;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFilesCopy;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFilesDelete;
        private System.Windows.Forms.ContextMenuStrip menuTree;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox textActionEntry;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Button buttonActionOK;
        private System.Windows.Forms.ToolStripButton toolStripRefresh;
        private System.Windows.Forms.ToolStripButton toolStripCopy;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageFolders;
        private System.Windows.Forms.ImageList imageFilesSmall;
        private System.Windows.Forms.ImageList imageFilesLarge;
    }
}

