using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DebugMarkerObjectNameInfoEXT : IDisposable
    {
        internal Unmanaged.DebugMarkerObjectNameInfoEXT* NativePointer;
        
        /// <summary>
        /// The type of the object
        /// </summary>
        public DebugReportObjectTypeEXT ObjectType
        {
            get { return NativePointer->ObjectType; }
            set { NativePointer->ObjectType = value; }
        }
        
        /// <summary>
        /// The handle of the object, cast to uint64_t
        /// </summary>
        public UInt64 Object
        {
            get { return NativePointer->Object; }
            set { NativePointer->Object = value; }
        }
        
        /// <summary>
        /// Name to apply to the object
        /// </summary>
        public string ObjectName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->ObjectName); }
            set { NativePointer->ObjectName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public DebugMarkerObjectNameInfoEXT()
        {
            NativePointer = (Unmanaged.DebugMarkerObjectNameInfoEXT*)MemoryUtils.Allocate(typeof(Unmanaged.DebugMarkerObjectNameInfoEXT));
            NativePointer->SType = StructureType.DebugMarkerObjectNameInfoEXT;
        }
        
        public DebugMarkerObjectNameInfoEXT(DebugReportObjectTypeEXT ObjectType, UInt64 Object, String ObjectName) : this()
        {
            this.ObjectType = ObjectType;
            this.Object = Object;
            this.ObjectName = ObjectName;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->ObjectName);
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.DebugMarkerObjectNameInfoEXT*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~DebugMarkerObjectNameInfoEXT()
        {
            if(NativePointer != (Unmanaged.DebugMarkerObjectNameInfoEXT*)IntPtr.Zero)
            {
                Marshal.FreeHGlobal(NativePointer->ObjectName);
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.DebugMarkerObjectNameInfoEXT*)IntPtr.Zero;
            }
        }
    }
}