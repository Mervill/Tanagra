using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugReportCallbackCreateInfoEXT
    {
        internal Interop.DebugReportCallbackCreateInfoEXT* NativeHandle;
        
        VkDebugReportFlagsEXT _Flags;
        public VkDebugReportFlagsEXT Flags
        {
            get { return _Flags; }
            set { _Flags = value; NativeHandle->Flags = (IntPtr)value.NativeHandle; }
        }
        
        PFN_vkDebugReportCallbackEXT _PfnCallback;
        public PFN_vkDebugReportCallbackEXT PfnCallback
        {
            get { return _PfnCallback; }
            set { _PfnCallback = value; NativeHandle->PfnCallback = (IntPtr)value.NativeHandle; }
        }
        
        public IntPtr UserData
        {
            get { return NativeHandle->UserData; }
            set { NativeHandle->UserData = value; }
        }
        
        public DebugReportCallbackCreateInfoEXT()
        {
            NativeHandle = (Interop.DebugReportCallbackCreateInfoEXT*)Interop.Structure.Allocate(typeof(Interop.DebugReportCallbackCreateInfoEXT));
            //NativeHandle->SType = StructureType.DebugReportCallbackCreateInfoEXT;
        }
    }
}
