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
        public Unmanaged.DebugMarkerMarkerInfoEXT.ColorInfo Color
        {
            get { return NativePointer->Color; }
            set { NativePointer->Color = value; }
        }
        
        public DebugMarkerMarkerInfoEXT()
        {
            NativePointer = (Unmanaged.DebugMarkerMarkerInfoEXT*)MemUtil.Alloc(typeof(Unmanaged.DebugMarkerMarkerInfoEXT));
            NativePointer->SType = StructureType.DebugMarkerMarkerInfoEXT;
        }
        
        internal DebugMarkerMarkerInfoEXT(Unmanaged.DebugMarkerMarkerInfoEXT* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.DebugMarkerMarkerInfoEXT));
        }
        
        /// <param name="MarkerName">Name of the debug marker</param>
        public DebugMarkerMarkerInfoEXT(String MarkerName) : this()
        {
            this.MarkerName = MarkerName;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->MarkerName);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DebugMarkerMarkerInfoEXT()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->MarkerName);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
