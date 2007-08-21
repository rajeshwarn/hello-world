using System;
using System.Collections.Generic;
using System.Text;
using Manzana;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using Tools;
using System.IO;

namespace iPhoneList
{
    public enum TypeIdentifier
    {
        FileName,
        Extension,
        FullPath,
        FileType,
        HeaderBytes,
        HeaderString,
        ExtHeadBytes, // Extension First, then Header
        ExtHeadString
    }

    public enum PreviewTypes { Image, Text, Music, Video, Document, Binary };

    public class ItemProperty
    {
        [XmlAttribute("Name")]
        public String Name;
        [XmlAttribute("Type")]
        public iPhone.FileTypes Type;
        [XmlAttribute("Identifier")]
        public TypeIdentifier Identifier;
        [XmlAttribute("FileInfoText")]
        public String FileInfoText;
        [XmlAttribute("ImageKey")]
        public String ImageKey;
        [XmlAttribute("Tag")]
        public String Tag;
        [XmlAttribute("Header")]
        public Byte[] Header;
        [XmlAttribute("ByteOffset")]
        public Int32 ByteOffset;

        public ItemProperty() {
        }
        public override String ToString() {
            return Name;
        }
    }

    [XmlRoot("ItemProperties")]
    public class ItemProperties
    {
        private ArrayList items;
        private Int32 selectedIndex;
        private Byte[] nullBytes = Hex.ToBytes("");
        private iPhone phone;
        public ItemProperties() {
            items = new ArrayList();
        }
        [XmlIgnore]
        public iPhone Phone {
            set { phone = value; }
        }
        public Boolean AddFileType( // for FileType Adds
            String name,
            iPhone.FileTypes type,
            String imageKey,
            String tag
            ) {
            return Add(name, type, TypeIdentifier.FileType, null, nullBytes, 0, imageKey, tag);
        }
        public Boolean AddFile( // for FileName, Extension, and FullPath
            String name,
            TypeIdentifier typeID,
            String fileInfoText,
            String imageKey,
            String tag
            ) {
            return Add(name, iPhone.FileTypes.File, typeID, fileInfoText, nullBytes, 0, imageKey, tag);
        }
        public Boolean AddFile( // for HeaderString and HeaderBytes
            String name,
            TypeIdentifier typeID,
            String headerString,
            Int32 byteOffset,
            String imageKey,
            String tag
            ) {
            Byte[] headerBytes;
            if (typeID == TypeIdentifier.HeaderString) {
                headerBytes = TextString.ToByte(headerString);
            } else {
                headerBytes = Hex.ToBytes(headerString);
            }
            return Add(name, iPhone.FileTypes.File, typeID, null, headerBytes, byteOffset, imageKey, tag);
        }
        public Boolean AddFile( // for ExtHeadString and ExtHeadBytes
            String name,
            TypeIdentifier typeID,
            String extension,
            String headerString,
            Int32 byteOffset,
            String imageKey,
            String tag
            ) {
            Byte[] headerBytes;
            if (typeID == TypeIdentifier.ExtHeadString) {
                headerBytes = TextString.ToByte(headerString);
            } else {
                headerBytes = Hex.ToBytes(headerString);
            }
            return Add(name, iPhone.FileTypes.File, typeID, extension, headerBytes, byteOffset, imageKey, tag);
        }
        public Boolean AddFolder( // for FileName and Extension
            String name,
            TypeIdentifier typeID,
            String folderInfoText,
            String imageKey,
            String tag
            ) {
            return Add(name, iPhone.FileTypes.Folder, typeID, folderInfoText, nullBytes, 0, imageKey, tag);
        }
        public Boolean AddPath( // for fixed pathname - can be file or folder
            String name,
            iPhone.FileTypes type,
            String folderInfoText,
            String imageKey,
            String tag
            ) {
            return Add(name, type, TypeIdentifier.FullPath, folderInfoText, nullBytes, 0, imageKey, tag);
        }
        public Boolean AddDevice( // for Devices
            String name,
            iPhone.FileTypes type,
            String imageKey,
            String tag
            ) {
            return Add(name, type, TypeIdentifier.FileType, null, nullBytes, 0, imageKey, tag);
        }

        public Boolean Add( // The Generic ADD
        String name,
        iPhone.FileTypes type,
        TypeIdentifier typeID,
        String fileInfoText,
        Byte[] headerBytes,
        Int32 byteOffset,
        String imageKey,
        String tag
        ) {
            ItemProperty newItem = new ItemProperty();
            newItem.Name = name;
            newItem.Type = type;
            newItem.Identifier = typeID;
            newItem.FileInfoText = fileInfoText;
            newItem.Header = headerBytes;
            newItem.ByteOffset = byteOffset;
            newItem.ImageKey = imageKey;
            newItem.Tag = tag;
            items.Add(newItem);
            selectedIndex = items.Count - 1;
            return true;
        }
        [XmlElement("Items")]
        public ItemProperty[] Items {
            get {
                ItemProperty[] outItems = new ItemProperty[items.Count];
                for (Int32 i = 0; i < items.Count; i++) {
                    outItems[i] = (ItemProperty)items[i];
                }
                return outItems;
            }
            set {
                if (value != null) {
                    ItemProperty[] inItems = (ItemProperty[])value;
                    items.Clear();
                    foreach (ItemProperty item in inItems) {
                        items.Add(item);
                    }
                }
            }
        }
        public Int32 ItemIndex(String PropertyName) {
            for (Int32 i = 0; i < items.Count; i++) {
                if (((ItemProperty)items[i]).Name.Equals(PropertyName)) {
                    selectedIndex = i;
                    return i;
                }
            }
            return -1;
        }
        public ItemProperty Item(String PropertyName) {
            for (Int32 i = 0; i < items.Count; i++) {
                if (((ItemProperty)items[i]).Name.Equals(PropertyName)) {
                    selectedIndex = i;
                    return (ItemProperty)items[i];
                }
            }
            return null;
        }
        public ItemProperty FindItem(String fullPath) {
            /*Have to account for these: 
             * FileName,    
             * Extension,
             * FullPath,    
             * FileType,
             * HeaderBytes, 
             * HeaderString,
             * ExtHeadBytes, // Extension First, then Header
             * ExtHeadString
             */
            /* I need to lay out the approach here...
             * When we read a folder, we get back a list of all the folder entries,
             * including the current / parent folder pointers.
             * 
             * I could break them up into FindFile / Folder / Device, but
             * I may use the same criteria to locate them
             * What's interesting with this particular approach is that the FIND
             * function doesn't specify what to look for. We literally scan the rules
             * and stop with the first MATCH.
             * 
             * Now since we store the FileType of each ItemProperty entry, we need to
             * perform the first match on that attribute of the passed file.
             * So FileType is the first piece of information we need.
             */
            // Set variables to store whether we've already gathered a particular piece of info 
            String fileName = null;
            Boolean _fileName = false;
            String extension = null;
            Boolean _extension = false;

            ItemProperty returnItem = null;
            iPhone.FileTypes fileType = phone.FileType(fullPath);
            foreach (ItemProperty item in items) {
                if (fileType == item.Type) {
                    switch (item.Identifier) {
                        case TypeIdentifier.FileType:
                            returnItem = item;
                            break;
                        case TypeIdentifier.FullPath:
                            if (item.FileInfoText.Equals(fullPath.ToLower())) {
                                returnItem = item;
                            }
                            break;
                        case TypeIdentifier.FileName:
                            if (!_fileName) {
                                fileName = fullPath.Substring(fullPath.LastIndexOf("/") + 1).ToLower();
                                _fileName = true;
                            }
                            if (item.FileInfoText.Equals(fileName)) {
                                returnItem = item;
                            }
                            break;
                        case TypeIdentifier.Extension:
                            if (!_extension) {
                                extension = TextString.GetFileExtension(fullPath);
                                _extension = true;
                            }
                            if (extension == item.FileInfoText) {
                                returnItem = item;
                            }
                            break;
                        case TypeIdentifier.ExtHeadString:
                        case TypeIdentifier.ExtHeadBytes:
                            if (!_extension) {
                                extension = TextString.GetFileExtension(fullPath);
                                _extension = true;
                            }
                            if (extension == item.FileInfoText) {
                                Byte[] buffer = GetHeaderBytes(fullPath, item.ByteOffset, item.Header.Length);
                                if (buffer == item.Header) {
                                    returnItem = item;
                                }
                            }
                            break;
                        case TypeIdentifier.HeaderBytes:
                        case TypeIdentifier.HeaderString:
                            Byte[] fileBuffer = GetHeaderBytes(fullPath, item.ByteOffset, item.Header.Length);
                            if (fileBuffer == item.Header) {
                                returnItem = item;
                            }
                            break;
                    }
                }
                if (returnItem != null) {
                    break;
                }
            }
            return returnItem;
        }
        public ItemProperty SelectedItem {
            get { return (ItemProperty)items[selectedIndex]; }
        }
        public Int32 SelectedIndex {
            get { return selectedIndex; }
            set {
                if (value >= 0 && value < items.Count)
                    selectedIndex = value;
            }
        }
        private Byte[] GetHeaderBytes(String fileName, Int32 offset, Int32 length) {
            Byte[] retval = null;
            using (Stream fileStream = iPhoneFile.OpenRead(phone, fileName)) {
                Byte[] buffer = new Byte[length];
                Int32 bytesRead;
                if ((offset + length) <= phone.FileSize(fileName)) {
                    bytesRead = fileStream.Read(buffer, offset, length);
                    retval = buffer;
                }
            }
            return retval;
        }
    }
}
