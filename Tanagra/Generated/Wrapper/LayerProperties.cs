using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class LayerProperties
    {
        internal Interop.LayerProperties* NativePointer;
        
        public string LayerName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->LayerName); }
            set { NativePointer->LayerName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public UInt32 SpecVersion
        {
            get { return NativePointer->SpecVersion; }
            set { NativePointer->SpecVersion = value; }
        }
        
        public UInt32 ImplementationVersion
        {
            get { return NativePointer->ImplementationVersion; }
            set { NativePointer->ImplementationVersion = value; }
        }
        
        public string Description
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->Description); }
            set { NativePointer->Description = Marshal.StringToHGlobalAnsi(value); }
        }
        
        internal LayerProperties()
        {
            NativePointer = (Interop.LayerProperties*)Interop.Structure.Allocate(typeof(Interop.LayerProperties));
        }
    }
}
