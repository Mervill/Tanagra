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
        
        PFN_vkDebugReportCallbackEXT _PfnCallback;
        public PFN_vkDebugReportCallbackEXT PfnCallback
        {
            get { return _PfnCallback; }
            set { _PfnCallback = value; NativePointer->PfnCallback = IntPtr.Zero; }
        }
        
        public IntPtr UserData
        {
            get { return NativePointer->UserData; }
            set { NativePointer->UserData = value; }
        }
        
        public DebugReportCallbackCreateInfoEXT()
        {
            NativePointer = (Interop.DebugReportCallbackCreateInfoEXT*)Interop.Structure.Allocate(typeof(Interop.DebugReportCallbackCreateInfoEXT));
            //NativePointer->SType = StructureType.DebugReportCallbackCreateInfoEXT;
        }
    }
}
