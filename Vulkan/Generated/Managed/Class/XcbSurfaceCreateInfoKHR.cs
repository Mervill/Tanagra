using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class XcbSurfaceCreateInfoKHR : IDisposable
    {
        internal Unmanaged.XcbSurfaceCreateInfoKHR* NativePointer { get; private set; }
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public XcbSurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public IntPtr Connection
        {
            get { return NativePointer->Connection; }
            set { NativePointer->Connection = value; }
        }
        
        public IntPtr Window
        {
            get { return NativePointer->Window; }
            set { NativePointer->Window = value; }
        }
        
        public XcbSurfaceCreateInfoKHR()
        {
            NativePointer = (Unmanaged.XcbSurfaceCreateInfoKHR*)MemUtil.Alloc(typeof(Unmanaged.XcbSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.XcbSurfaceCreateInfoKHR;
        }
        
        internal XcbSurfaceCreateInfoKHR(Unmanaged.XcbSurfaceCreateInfoKHR* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.XcbSurfaceCreateInfoKHR));
        }
        
        public XcbSurfaceCreateInfoKHR(IntPtr Connection, IntPtr Window) : this()
        {
            this.Connection = Connection;
            this.Window = Window;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~XcbSurfaceCreateInfoKHR()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
