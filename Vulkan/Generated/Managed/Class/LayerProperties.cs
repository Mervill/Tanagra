using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class LayerProperties : IDisposable
    {
        internal Unmanaged.LayerProperties* NativePointer;
        
        /// <summary>
        /// Layer name
        /// </summary>
        public string LayerName
        {
            get { return Marshal.PtrToStringAnsi((IntPtr)NativePointer->LayerName); }
        }
        
        /// <summary>
        /// Version of the layer specification implemented
        /// </summary>
        public UInt32 SpecVersion
        {
            get { return NativePointer->SpecVersion; }
        }
        
        /// <summary>
        /// Build or release version of the layer's library
        /// </summary>
        public UInt32 ImplementationVersion
        {
            get { return NativePointer->ImplementationVersion; }
        }
        
        /// <summary>
        /// Free-form description of the layer
        /// </summary>
        public string Description
        {
            get { return Marshal.PtrToStringAnsi((IntPtr)NativePointer->Description); }
        }
        
        internal LayerProperties()
        {
            NativePointer = (Unmanaged.LayerProperties*)MemoryUtils.Allocate(typeof(Unmanaged.LayerProperties));
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.LayerProperties*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~LayerProperties()
        {
            if(NativePointer != (Unmanaged.LayerProperties*)IntPtr.Zero)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.LayerProperties*)IntPtr.Zero;
            }
        }
    }
}
