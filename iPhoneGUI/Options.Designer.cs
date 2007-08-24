namespace iPhoneList
{
    partial class Options
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
            if ( disposing && (components != null) ) {
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Files & Folders");
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.treeOptions = new System.Windows.Forms.TreeView();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.checkOverwriteConfirm = new System.Windows.Forms.CheckBox();
            this.panelFiles = new System.Windows.Forms.Panel();
            this.groupIncludes = new System.Windows.Forms.GroupBox();
            this.checkGallery = new System.Windows.Forms.CheckBox();
            this.checkCameraRoll = new System.Windows.Forms.CheckBox();
            this.checkMusic = new System.Windows.Forms.CheckBox();
            this.buttonBackupFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelFiles = new System.Windows.Forms.Label();
            this.labelBackupFolder = new System.Windows.Forms.Label();
            this.textTabSpaces = new System.Windows.Forms.TextBox();
            this.labelTabSpaces = new System.Windows.Forms.Label();
            this.panelControl.SuspendLayout();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            this.panelFiles.SuspendLayout();
            this.groupIncludes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.buttonCancel);
            this.panelControl.Controls.Add(this.buttonOK);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(0, 231);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(467, 33);
            this.panelControl.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(385, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(313, 5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // splitMain
            // 
            this.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.treeOptions);
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.panelGeneral);
            this.splitMain.Panel2.Controls.Add(this.panelFiles);
            this.splitMain.Size = new System.Drawing.Size(467, 231);
            this.splitMain.SplitterDistance = 106;
            this.splitMain.TabIndex = 1;
            // 
            // treeOptions
            // 
            this.treeOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOptions.Location = new System.Drawing.Point(5, 5);
            this.treeOptions.Name = "treeOptions";
            treeNode3.Name = "General";
            treeNode3.Tag = "panelGeneral";
            treeNode3.Text = "General";
            treeNode4.Name = "Files";
            treeNode4.Tag = "panelFiles";
            treeNode4.Text = "Files & Folders";
            this.treeOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.treeOptions.PathSeparator = "/";
            this.treeOptions.ShowNodeToolTips = true;
            this.treeOptions.ShowRootLines = false;
            this.treeOptions.Size = new System.Drawing.Size(92, 217);
            this.treeOptions.TabIndex = 0;
            this.treeOptions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOptions_AfterSelect);
            // 
            // panelGeneral
            // 
            this.panelGeneral.Controls.Add(this.labelTabSpaces);
            this.panelGeneral.Controls.Add(this.textTabSpaces);
            this.panelGeneral.Controls.Add(this.checkOverwriteConfirm);
            this.panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(353, 227);
            this.panelGeneral.TabIndex = 0;
            // 
            // checkOverwriteConfirm
            // 
            this.checkOverwriteConfirm.AutoSize = true;
            this.checkOverwriteConfirm.Location = new System.Drawing.Point(29, 35);
            this.checkOverwriteConfirm.Name = "checkOverwriteConfirm";
            this.checkOverwriteConfirm.Size = new System.Drawing.Size(206, 17);
            this.checkOverwriteConfirm.TabIndex = 0;
            this.checkOverwriteConfirm.Text = "Confirm when writing over existing files";
            this.checkOverwriteConfirm.UseVisualStyleBackColor = true;
            // 
            // panelFiles
            // 
            this.panelFiles.Controls.Add(this.groupIncludes);
            this.panelFiles.Controls.Add(this.buttonBackupFolder);
            this.panelFiles.Controls.Add(this.textBox1);
            this.panelFiles.Controls.Add(this.labelFiles);
            this.panelFiles.Controls.Add(this.labelBackupFolder);
            this.panelFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFiles.Location = new System.Drawing.Point(0, 0);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.Size = new System.Drawing.Size(353, 227);
            this.panelFiles.TabIndex = 0;
            // 
            // groupIncludes
            // 
            this.groupIncludes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupIncludes.Controls.Add(this.checkGallery);
            this.groupIncludes.Controls.Add(this.checkCameraRoll);
            this.groupIncludes.Controls.Add(this.checkMusic);
            this.groupIncludes.Location = new System.Drawing.Point(9, 64);
            this.groupIncludes.Name = "groupIncludes";
            this.groupIncludes.Size = new System.Drawing.Size(335, 84);
            this.groupIncludes.TabIndex = 4;
            this.groupIncludes.TabStop = false;
            this.groupIncludes.Text = "Include in Backup";
            // 
            // checkGallery
            // 
            this.checkGallery.AutoSize = true;
            this.checkGallery.Location = new System.Drawing.Point(250, 29);
            this.checkGallery.Name = "checkGallery";
            this.checkGallery.Size = new System.Drawing.Size(89, 17);
            this.checkGallery.TabIndex = 2;
            this.checkGallery.Text = "Photo Gallery";
            this.checkGallery.UseVisualStyleBackColor = true;
            // 
            // checkCameraRoll
            // 
            this.checkCameraRoll.AutoSize = true;
            this.checkCameraRoll.Location = new System.Drawing.Point(118, 29);
            this.checkCameraRoll.Name = "checkCameraRoll";
            this.checkCameraRoll.Size = new System.Drawing.Size(83, 17);
            this.checkCameraRoll.TabIndex = 1;
            this.checkCameraRoll.Text = "Camera Roll";
            this.checkCameraRoll.UseVisualStyleBackColor = true;
            // 
            // checkMusic
            // 
            this.checkMusic.AutoSize = true;
            this.checkMusic.Location = new System.Drawing.Point(15, 29);
            this.checkMusic.Name = "checkMusic";
            this.checkMusic.Size = new System.Drawing.Size(54, 17);
            this.checkMusic.TabIndex = 0;
            this.checkMusic.Text = "Music";
            this.checkMusic.UseVisualStyleBackColor = true;
            // 
            // buttonBackupFolder
            // 
            this.buttonBackupFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackupFolder.Location = new System.Drawing.Point(318, 26);
            this.buttonBackupFolder.Name = "buttonBackupFolder";
            this.buttonBackupFolder.Size = new System.Drawing.Size(27, 23);
            this.buttonBackupFolder.TabIndex = 3;
            this.buttonBackupFolder.Text = "...";
            this.buttonBackupFolder.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(90, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 20);
            this.textBox1.TabIndex = 2;
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiles.Location = new System.Drawing.Point(6, 5);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(89, 13);
            this.labelFiles.TabIndex = 1;
            this.labelFiles.Text = "Files && Folders";
            // 
            // labelBackupFolder
            // 
            this.labelBackupFolder.AutoSize = true;
            this.labelBackupFolder.Location = new System.Drawing.Point(6, 31);
            this.labelBackupFolder.Name = "labelBackupFolder";
            this.labelBackupFolder.Size = new System.Drawing.Size(79, 13);
            this.labelBackupFolder.TabIndex = 0;
            this.labelBackupFolder.Text = "Backup Folder:";
            this.labelBackupFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textTabSpaces
            // 
            this.textTabSpaces.Location = new System.Drawing.Point(29, 64);
            this.textTabSpaces.Name = "textTabSpaces";
            this.textTabSpaces.Size = new System.Drawing.Size(21, 20);
            this.textTabSpaces.TabIndex = 1;
            this.textTabSpaces.Text = "4";
            // 
            // labelTabSpaces
            // 
            this.labelTabSpaces.AutoSize = true;
            this.labelTabSpaces.Location = new System.Drawing.Point(60, 67);
            this.labelTabSpaces.Name = "labelTabSpaces";
            this.labelTabSpaces.Size = new System.Drawing.Size(177, 13);
            this.labelTabSpaces.TabIndex = 2;
            this.labelTabSpaces.Text = "Spaces to show for Tabs in Preview";
            // 
            // Options
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(467, 264);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.panelControl);
            this.Name = "Options";
            this.Text = "iPhoneList Options";
            this.panelControl.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            this.panelGeneral.ResumeLayout(false);
            this.panelGeneral.PerformLayout();
            this.panelFiles.ResumeLayout(false);
            this.panelFiles.PerformLayout();
            this.groupIncludes.ResumeLayout(false);
            this.groupIncludes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TreeView treeOptions;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Panel panelFiles;
        private System.Windows.Forms.Label labelBackupFolder;
        private System.Windows.Forms.Button buttonBackupFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.GroupBox groupIncludes;
        private System.Windows.Forms.CheckBox checkGallery;
        private System.Windows.Forms.CheckBox checkCameraRoll;
        private System.Windows.Forms.CheckBox checkMusic;
        private System.Windows.Forms.CheckBox checkOverwriteConfirm;
        private System.Windows.Forms.Label labelTabSpaces;
        private System.Windows.Forms.TextBox textTabSpaces;

    }
}