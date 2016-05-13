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
        
        public UInt32 TagSize
        {
            get { return NativePointer->TagSize; }
            set { NativePointer->TagSize = value; }
        }
        
        public IntPtr[] Tag
        {
            get
            {
                var valueCount = NativePointer->TagSize;
                var valueArray = new IntPtr[valueCount];
                var ptr = (IntPtr*)NativePointer->Tag;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->TagSize = (uint)valueCount;
                NativePointer->Tag = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->Tag;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public DebugMarkerObjectTagInfoEXT()
        {
            NativePointer = (Interop.DebugMarkerObjectTagInfoEXT*)Interop.Structure.Allocate(typeof(Interop.DebugMarkerObjectTagInfoEXT));
            NativePointer->SType = StructureType.DebugMarkerObjectTagInfoEXT;
        }
    }
}
