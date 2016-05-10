using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugMarkerObjectTagInfoEXT
    {
        internal Interop.DebugMarkerObjectTagInfoEXT* NativePointer;
        
        public DebugReportObjectTypeEXT ObjectType
        {
            get { return NativePointer->ObjectType; }
            set { NativePointer->ObjectType = value; }
        }
        
        public UInt64 Object
        {
            get { return NativePointer->Object; }
            set { NativePointer->Object = value; }
        }
        
        public UInt64 TagName
        {
            get { return NativePointer->TagName; }
            set { NativePointer->TagName = value; }
        }
        
        public UIntPtr TagSize
        {
            get { return NativePointer->TagSize; }
            set { NativePointer->TagSize = value; }
        }
        
        public IntPtr Tag
        {
            get { return NativePointer->Tag; }
            set { NativePointer->Tag = value; }
        }
        
        public DebugMarkerObjectTagInfoEXT()
        {
            NativePointer = (Interop.DebugMarkerObjectTagInfoEXT*)Interop.Structure.Allocate(typeof(Interop.DebugMarkerObjectTagInfoEXT));
            //NativePointer->SType = StructureType.DebugMarkerObjectTagInfoEXT;
        }
    }
}
