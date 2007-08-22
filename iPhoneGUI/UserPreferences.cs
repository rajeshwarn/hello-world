// UserPreferences.cs - User Preferences class for:
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
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace iPhoneList
{
    [XmlRoot("UserPrefs")]
    public class UserPrefs
    {
        [XmlElement("Application")]
        public ApplicationPrefs Application = new ApplicationPrefs();
        [XmlElement("File")]
        public FilePrefs File = new FilePrefs();
        [XmlElement("Window")]
        public WindowPrefs Window = new WindowPrefs();
        public UserPrefs() { }
    }

    public class ApplicationPrefs
    {
        [XmlElement("BackupFolder")]
        public String BackupFolder;
        public ApplicationPrefs() { }
    }
    public class FilePrefs
    {
        [XmlElement("OverWriteExistingFiles")]
        public Boolean OverWriteExistingFiles;
        [XmlElement("DontAskAboutOverwrite")]
        public Boolean DontAskAboutOverWrite;
        public FilePrefs() { }
    }

    public class WindowPrefs
    {
        [XmlElement("PreviewOn")]
        public Boolean previewOn = false;
        [XmlElement("Main")]
        public ItemLocation Main = new ItemLocation();
        [XmlElement("MainToolBar")]
        public ItemLocation MainToolBar = new ItemLocation();
        [XmlElement("FileToolBar")]
        public ItemLocation FileToolBar = new ItemLocation();
        [XmlElement("SplitterDistance")]
        public Int32 SplitterDistance;
        [XmlElement("PreviewShowing")]
        public Int32 PreviewShowing;
        public WindowPrefs() { }
    }

    public class ItemLocation
    {
        [XmlAttribute("Top")]
        public Int32 Top;
        [XmlAttribute("Left")]
        public Int32 Left;
        [XmlAttribute("Height")]
        public Int32 Height;
        [XmlAttribute("Width")]
        public Int32 Width;
        public ItemLocation() { }
    }
}
