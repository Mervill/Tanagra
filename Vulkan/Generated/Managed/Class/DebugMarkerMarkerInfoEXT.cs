using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DebugMarkerMarkerInfoEXT : IDisposable
    {
        internal Unmanaged.DebugMarkerMarkerInfoEXT* NativePointer;
        
        /// <summary>
        /// Name of the debug marker
        /// </summary>
        public String MarkerName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->MarkerName); }
            set { NativePointer->MarkerName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        /// <summary>
        /// Optional color for debug marker (Optional)
        /// </summary>
        public Single[] Color
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
            set
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public DebugMarkerMarkerInfoEXT()
        {
            NativePointer = (Unmanaged.DebugMarkerMarkerInfoEXT*)MemoryUtils.Allocate(typeof(Unmanaged.DebugMarkerMarkerInfoEXT));
            NativePointer->SType = StructureType.DebugMarkerMarkerInfoEXT;
        }
        
        public DebugMarkerMarkerInfoEXT(String MarkerName) : this()
        {
            this.MarkerName = MarkerName;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->MarkerName);
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.DebugMarkerMarkerInfoEXT*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~DebugMarkerMarkerInfoEXT()
        {
            if(NativePointer != (Unmanaged.DebugMarkerMarkerInfoEXT*)IntPtr.Zero)
            {
                Marshal.FreeHGlobal(NativePointer->MarkerName);
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.DebugMarkerMarkerInfoEXT*)IntPtr.Zero;
            }
        }
    }
}
