using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugReportCallbackCreateInfoEXT
    {
        internal Interop.DebugReportCallbackCreateInfoEXT* NativePointer;
        
        public DebugReportFlagsEXT Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public IntPtr PfnCallback
        {
            get { return NativePointer->PfnCallback; }
            set { NativePointer->PfnCallback = value; }
        }
        
        public IntPtr UserData
        {
            get { return NativePointer->UserData; }
            set { NativePointer->UserData = value; }
        }
        
        public DebugReportCallbackCreateInfoEXT()
        {
            NativePointer = (Interop.DebugReportCallbackCreateInfoEXT*)Interop.Structure.Allocate(typeof(Interop.DebugReportCallbackCreateInfoEXT));
            NativePointer->SType = StructureType.DebugReportCallbackCreateInfoEXT;
        }
        
        public DebugReportCallbackCreateInfoEXT(DebugReportFlagsEXT Flags, IntPtr PfnCallback) : this()
        {
            this.Flags = Flags;
            this.PfnCallback = PfnCallback;
        }
    }
}
