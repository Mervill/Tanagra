using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ExtensionProperties
    {
        internal Interop.ExtensionProperties* NativePointer;
        
        public string ExtensionName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->ExtensionName); }
            set { NativePointer->ExtensionName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public UInt32 SpecVersion
        {
            get { return NativePointer->SpecVersion; }
            set { NativePointer->SpecVersion = value; }
        }
        
        internal ExtensionProperties()
        {
            NativePointer = (Interop.ExtensionProperties*)Interop.Structure.Allocate(typeof(Interop.ExtensionProperties));
        }
    }
}
