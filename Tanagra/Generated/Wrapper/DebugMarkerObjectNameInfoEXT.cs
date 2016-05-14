using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugMarkerObjectNameInfoEXT
    {
        internal Interop.DebugMarkerObjectNameInfoEXT* NativePointer;
        
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
        
        public string ObjectName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->ObjectName); }
            set { NativePointer->ObjectName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public DebugMarkerObjectNameInfoEXT()
        {
            NativePointer = (Interop.DebugMarkerObjectNameInfoEXT*)Interop.Structure.Allocate(typeof(Interop.DebugMarkerObjectNameInfoEXT));
            NativePointer->SType = StructureType.DebugMarkerObjectNameInfoEXT;
        }
        
        public DebugMarkerObjectNameInfoEXT(DebugReportObjectTypeEXT ObjectType, UInt64 Object, String ObjectName) : this()
        {
            this.ObjectType = ObjectType;
            this.Object = Object;
            this.ObjectName = ObjectName;
        }
    }
}
