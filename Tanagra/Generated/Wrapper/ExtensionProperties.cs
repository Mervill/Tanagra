using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class ExtensionProperties
    {
        internal Interop.ExtensionProperties* NativePointer;
        
        /// <summary>
        /// Extension name
        /// </summary>
        public string ExtensionName
        {
            get { return Marshal.PtrToStringAnsi((IntPtr)NativePointer->ExtensionName); }
        }
        
        /// <summary>
        /// Version of the extension specification implemented
        /// </summary>
        public UInt32 SpecVersion
        {
            get { return NativePointer->SpecVersion; }
        }
        
        internal ExtensionProperties()
        {
            NativePointer = (Interop.ExtensionProperties*)MemoryUtils.Allocate(typeof(Interop.ExtensionProperties));
        }
    }
}
