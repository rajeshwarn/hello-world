using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iPhoneList
{
    public partial class LinkProperties: Form
    {
        public LinkProperties() {
            InitializeComponent();
        }

        public String Title {
            set { this.Text = value; }
        }

        public String LinkName {
            get { return textLinkName.Text; }
            set { textLinkName.Text = value; }
        }
        public String LinkLocation {
            get { return textLinkLocation.Text; }
            set { textLinkLocation.Text = value; }
        }
        public String LinkDescription {
            get { return textLinkDescription.Text; }
            set { textLinkDescription.Text = value; }
        }

    }
}