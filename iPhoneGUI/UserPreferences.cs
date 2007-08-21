using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace iPhoneList
{
    [XmlRoot("UserPrefs")]
    public class UserPrefs
    {
        [XmlElement("File")]
        public FilePrefs file = new FilePrefs();
        [XmlElement("Window")]
        public WindowPrefs window = new WindowPrefs();
        public UserPrefs() { }
    }

    public class FilePrefs
    {
        [XmlAttribute("OverWriteExistingFiles")]
        public Boolean OverWriteExistingFiles;
        [XmlAttribute("DontAskAboutOverwrite")]
        public Boolean DontAskAboutOverWrite;
        public FilePrefs() { }
    }

    public class WindowPrefs
    {
        [XmlElement("PreviewOn")]
        public Boolean previewOn = false;
        [XmlElement("Main")]
        public ItemLocation main = new ItemLocation();
        [XmlElement("FileToolBar")]
        public ItemLocation fileToolBar = new ItemLocation();
        [XmlElement("MainToolBar")]
        public ItemLocation mainToolBar = new ItemLocation();
        public WindowPrefs() { }
    }

    public class ItemLocation
    {
        [XmlAttribute("Top")]
        public Int32 Top;
        [XmlAttribute("Left")]
        public Int32 Left;
        [XmlAttribute("Right")]
        public Int32 Height;
        [XmlAttribute("Width")]
        public Int32 Width;
        public ItemLocation() { }
    }
}
