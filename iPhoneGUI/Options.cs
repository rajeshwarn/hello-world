using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iPhoneList
{
    public partial class Options: Form
    {
        public Options() {
            InitializeComponent();
        }

        private void treeOptions_AfterSelect(object sender, TreeViewEventArgs e) {
            SplitterPanel optionPanel = splitMain.Panel2;
            for ( Int32 i=0; i < optionPanel.Controls.Count; i++ ) {
                if ( optionPanel.Controls[i].Name.ToString() == e.Node.Tag.ToString() ) {
                    optionPanel.Controls[i].Visible = true;
                } else {
                    optionPanel.Controls[i].Visible = false;
                }
            }
        }
    }
}