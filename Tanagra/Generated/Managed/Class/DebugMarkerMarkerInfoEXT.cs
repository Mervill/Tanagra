using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugMarkerMarkerInfoEXT
    {
        internal Unmanaged.DebugMarkerMarkerInfoEXT* NativePointer;
        
        /// <summary>
        /// Name of the debug marker
        /// </summary>
        public string MarkerName
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
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.DebugMarkerMarkerInfoEXT*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
