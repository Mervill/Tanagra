using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class LayerProperties
    {
        internal Interop.LayerProperties* NativePointer;
        
        public string LayerName
        {
            get { return Marshal.PtrToStringAnsi((IntPtr)NativePointer->LayerName); }
        }
        
        public UInt32 SpecVersion
        {
            get { return NativePointer->SpecVersion; }
        }
        
        public UInt32 ImplementationVersion
        {
            get { return NativePointer->ImplementationVersion; }
        }
        
        public string Description
        {
            get { return Marshal.PtrToStringAnsi((IntPtr)NativePointer->Description); }
        }
        
        internal LayerProperties()
        {
            NativePointer = (Interop.LayerProperties*)Interop.Structure.Allocate(typeof(Interop.LayerProperties));
        }
    }
}
