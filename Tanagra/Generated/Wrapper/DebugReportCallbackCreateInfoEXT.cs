using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugReportCallbackCreateInfoEXT
    {
        internal Interop.DebugReportCallbackCreateInfoEXT* NativePointer;
        
        VkDebugReportFlagsEXT _Flags;
        public VkDebugReportFlagsEXT Flags
        {
            get { return _Flags; }
            set { _Flags = value; NativePointer->Flags = (IntPtr)value.NativePointer; }
        }
        
        PFN_vkDebugReportCallbackEXT _PfnCallback;
        public PFN_vkDebugReportCallbackEXT PfnCallback
        {
            get { return _PfnCallback; }
            set { _PfnCallback = value; NativePointer->PfnCallback = (IntPtr)value.NativePointer; }
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
