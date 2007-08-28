using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace iPhoneList
{
    public class iPhoneApp
    {
        public String AppName;
        public String Version;
        public String Description;
        public String Identifier;
        public String Category;
        public String Contact;
        public String AppHome;
        public String Maintainer;
    }

    public class iPhoneApps
    {
        private ArrayList apps;
        public iPhoneApps() {
            apps = new ArrayList();
        }
        public iPhoneApp[] Applications {
            get { return (iPhoneApp[])apps.ToArray(typeof(iPhoneApp)); }
            set {
                apps.Clear();
                foreach ( iPhoneApp app in value ) {
                    apps.Add(app);
                }
            }
        }

    }
}
