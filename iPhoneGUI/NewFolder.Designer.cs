namespace iPhoneGUI
{
    partial class NewFolderForm
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
            this.labelAction = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textActionEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelAction.Location = new System.Drawing.Point(5, 5);
            this.labelAction.Name = "labelAction";
            this.labelAction.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelAction.Size = new System.Drawing.Size(98, 18);
            this.labelAction.TabIndex = 0;
            this.labelAction.Text = "New Folder Name: ";
            // 
            // buttonOK
            // 
            this.buttonOK.AutoSize = true;
            this.buttonOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonOK.Location = new System.Drawing.Point(330, 5);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(32, 22);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // textActionEntry
            // 
            this.textActionEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textActionEntry.Location = new System.Drawing.Point(103, 5);
            this.textActionEntry.Name = "textActionEntry";
            this.textActionEntry.Size = new System.Drawing.Size(227, 20);
            this.textActionEntry.TabIndex = 2;
            // 
            // NewFolderForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 32);
            this.Controls.Add(this.textActionEntry);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NewFolderForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewFolder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textActionEntry;
    }
}