using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CoreFoundation
{
    using CFTypeRef = IntPtr;
    using CFPropertyListRef = IntPtr;
    using CFDataRef = IntPtr;
    using CFStringRef = IntPtr;
    using CFAllocatorRef = IntPtr;
    using System.Collections;

    enum CFPropertyListMutabilityOptions : uint
    {
        kCFPropertyListImmutable = 0,
        kCFPropertyListMutableContainers = 1,
        kCFPropertyListMutableContainersAndLeaves = 2
    };

    internal class CFPropertyList
    {
        private static IntPtr ptr = IntPtr.Zero;

        internal CFPropertyList() {
        }
        //QTGetCFConstant("kCFAllocatorDefault"))
        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static Byte[] CFPropertyListCreateFromXMLData(IntPtr allocator, String xmlData,
            CFPropertyListMutabilityOptions optionFlags, StringBuilder errorString);

        [DllImport("CoreFoundation.dll", CallingConvention = CallingConvention.Cdecl)]
        private extern static String CFPropertyListCreateXMLData(IntPtr allocator, IntPtr propertyList );

        public static Byte[] PropertyListFromXML(String xmlData) {
            StringBuilder errorString = new StringBuilder(1024);
            Byte[] plist = null;
            try {
                plist = CFPropertyListCreateFromXMLData(ptr, xmlData, CFPropertyListMutabilityOptions.kCFPropertyListImmutable, errorString);
            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
            }
            return plist;
        }
        public static String PropertyListToXML(Byte[] propertyList){
            String xmlData = null;
            try {
                GCHandle gch = GCHandle.Alloc(propertyList);
                IntPtr buffer = GCHandle.ToIntPtr(gch);
                xmlData = CFPropertyListCreateXMLData(ptr, buffer);
            }
            catch (Exception err) {
                Console.WriteLine(err.Message);
            }
            return xmlData;
        }
    }
    public enum PListNodeType
    {
        PLDict = 0,
        PLArray = 1,
        PLBoolean = 2,
        PLString = 3,
        PLValue = 4,
        PLDate = 5,
        PLCDATA = 6
    }

    public class PListNodes
    {
        public ArrayList nodes;
        public PListNodes() {
            nodes = new ArrayList();
        }
        public PListNode[] Nodes {
            get { return (PListNode[])nodes.ToArray(typeof(PListNode)); }
            set {
                nodes.Clear();
                foreach ( PListNode node in value ) {
                    nodes.Add(nodes);
                }
            }
        }

        public void AddDict(String keyName) {
            PListNode dict = new PListNode();
            dict.Name = "dict";
            nodes.Add(dict);
        }
    }

    public class PListNode
    {
        public String Name;
        public PListNode() {
        }
    }

    public class PListKeyNode: PListNode
    {
        public PListNodeType NodeType;
        public PListNode Node;
        public PListKeyNode() {
        }
    }

    public class PListStringNode: PListNode
    {
        public PListStringNode() {
        }
        public String Text;
        public override string ToString() {
            return Text.ToString();
        }
    }

    public class PListIntNode: PListNode
    {
        public PListIntNode() {
        }
        public Int32 Value;
    }

    public class PListBooleanNode: PListNode
    {
        public PListBooleanNode() {
        }
        public Boolean Value;
    }

    public class PListDictNode: PListNode
    {
        public PListNodes Nodes;
        public PListDictNode() {
        }
    }

    public class PListArrayNode: PListNode
    {
        public ArrayList Value;
        public PListArrayNode() {
            Value = new ArrayList();
        }
    }

    public class PList
    {
        public PList() { }

        public static PListNodes PListXMLtoXML(String inData) {
            return null;
        }

        public static PListNodes PlistXMLtoXML(String[] inData) {
            return null;
        }
    }
}
