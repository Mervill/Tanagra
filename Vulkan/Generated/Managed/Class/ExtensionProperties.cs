using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class ExtensionProperties : IDisposable
    {
        internal Unmanaged.ExtensionProperties* NativePointer;
        
        /// <summary>
        /// Extension name
        /// </summary>
        public String ExtensionName
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
            NativePointer = (Unmanaged.ExtensionProperties*)MemoryUtils.Allocate(typeof(Unmanaged.ExtensionProperties));
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.ExtensionProperties*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~ExtensionProperties()
        {
            if(NativePointer != (Unmanaged.ExtensionProperties*)IntPtr.Zero)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.ExtensionProperties*)IntPtr.Zero;
            }
        }
    }
}
