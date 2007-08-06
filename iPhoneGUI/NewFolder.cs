using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iPhoneGUI
{
    public partial class NewFolderForm: Form
    {
        public NewFolderForm() {
            InitializeComponent();
            textActionEntry.Focus();
        }
        public String FolderName {
            get { return textActionEntry.Text; }
            set { textActionEntry.Text = value; }
        }
        public String ActionText {
            set { labelAction.Text = value; }
        }
    }
}