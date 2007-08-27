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
}
