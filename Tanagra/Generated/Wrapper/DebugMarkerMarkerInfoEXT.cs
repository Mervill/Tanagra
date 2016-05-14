using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugMarkerMarkerInfoEXT
    {
        internal Interop.DebugMarkerMarkerInfoEXT* NativePointer;
        
        public string MarkerName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->MarkerName); }
            set { NativePointer->MarkerName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public Single Color
        {
            get { return NativePointer->Color; }
            set { NativePointer->Color = value; }
        }
        
        public DebugMarkerMarkerInfoEXT()
        {
            NativePointer = (Interop.DebugMarkerMarkerInfoEXT*)Interop.Structure.Allocate(typeof(Interop.DebugMarkerMarkerInfoEXT));
            NativePointer->SType = StructureType.DebugMarkerMarkerInfoEXT;
        }
        
        public DebugMarkerMarkerInfoEXT(String MarkerName) : this()
        {
            this.MarkerName = MarkerName;
        }
    }
}
