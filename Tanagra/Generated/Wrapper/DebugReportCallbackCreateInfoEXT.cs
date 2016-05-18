using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugReportCallbackCreateInfoEXT
    {
        internal Interop.DebugReportCallbackCreateInfoEXT* NativePointer;
        
        /// <summary>
        /// Indicates which events call this callback
        /// </summary>
        public DebugReportFlagsEXT Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Function pointer of a callback function
        /// </summary>
        public IntPtr Callback
        {
            get { return NativePointer->Callback; }
            set { NativePointer->Callback = value; }
        }
        
        /// <summary>
        /// User data provided to callback function (Optional)
        /// </summary>
        public IntPtr UserData
        {
            get { return NativePointer->UserData; }
            set { NativePointer->UserData = value; }
        }
        
        public DebugReportCallbackCreateInfoEXT()
        {
            NativePointer = (Interop.DebugReportCallbackCreateInfoEXT*)MemoryUtils.Allocate(typeof(Interop.DebugReportCallbackCreateInfoEXT));
            NativePointer->SType = StructureType.DebugReportCallbackCreateInfoEXT;
        }
        
        public DebugReportCallbackCreateInfoEXT(DebugReportFlagsEXT Flags, IntPtr Callback) : this()
        {
            this.Flags = Flags;
            this.Callback = Callback;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.DebugReportCallbackCreateInfoEXT*)IntPtr.Zero;
        }
    }
}
