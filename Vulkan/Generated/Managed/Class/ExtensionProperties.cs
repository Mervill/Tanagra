using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class ExtensionProperties : IDisposable
    {
        internal Unmanaged.ExtensionProperties* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.ExtensionProperties*)MemUtil.Alloc(typeof(Unmanaged.ExtensionProperties));
        }
        
        internal ExtensionProperties(Unmanaged.ExtensionProperties* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.ExtensionProperties));
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~ExtensionProperties()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
