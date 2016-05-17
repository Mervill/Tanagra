using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugMarkerMarkerInfoEXT
    {
        internal Interop.DebugMarkerMarkerInfoEXT* NativePointer;
        
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
            NativePointer = (Interop.DebugMarkerMarkerInfoEXT*)MemoryUtils.Allocate(typeof(Interop.DebugMarkerMarkerInfoEXT));
            NativePointer->SType = StructureType.DebugMarkerMarkerInfoEXT;
        }
        
        public DebugMarkerMarkerInfoEXT(String MarkerName) : this()
        {
            this.MarkerName = MarkerName;
        }
    }
}
