using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class LayerProperties
    {
        internal Interop.LayerProperties* NativeHandle;
        
        public string LayerName
        {
            get { return Marshal.PtrToStringAnsi(NativeHandle->LayerName); }
            set { NativeHandle->LayerName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public UInt32 SpecVersion
        {
            get { return NativeHandle->SpecVersion; }
            set { NativeHandle->SpecVersion = value; }
        }
        
        public UInt32 ImplementationVersion
        {
            get { return NativeHandle->ImplementationVersion; }
            set { NativeHandle->ImplementationVersion = value; }
        }
        
        public string Description
        {
            get { return Marshal.PtrToStringAnsi(NativeHandle->Description); }
            set { NativeHandle->Description = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public LayerProperties()
        {
            NativeHandle = (Interop.LayerProperties*)Interop.Structure.Allocate(typeof(Interop.LayerProperties));
        }
    }
}
