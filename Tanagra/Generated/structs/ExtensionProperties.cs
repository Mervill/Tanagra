using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ExtensionProperties
    {
        internal Interop.ExtensionProperties* NativeHandle;
        
        public string ExtensionName
        {
            get { return Marshal.PtrToStringAnsi(NativeHandle->ExtensionName); }
            set { NativeHandle->ExtensionName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public UInt32 SpecVersion
        {
            get { return NativeHandle->SpecVersion; }
            set { NativeHandle->SpecVersion = value; }
        }
        
        public ExtensionProperties()
        {
            NativeHandle = (Interop.ExtensionProperties*)Interop.Structure.Allocate(typeof(Interop.ExtensionProperties));
        }
    }
}
