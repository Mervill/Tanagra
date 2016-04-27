using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DeviceQueueCreateInfo
    {
        internal Interop.DeviceQueueCreateInfo* NativeHandle;
        
        public DeviceQueueCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 QueueFamilyIndex
        {
            get { return NativeHandle->QueueFamilyIndex; }
            set { NativeHandle->QueueFamilyIndex = value; }
        }
        
        public UInt32 QueueCount
        {
            get { return NativeHandle->QueueCount; }
            set { NativeHandle->QueueCount = value; }
        }
        
        public Single QueuePriorities
        {
            get { return NativeHandle->QueuePriorities; }
            set { NativeHandle->QueuePriorities = value; }
        }
        
        public DeviceQueueCreateInfo()
        {
            NativeHandle = (Interop.DeviceQueueCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DeviceQueueCreateInfo));
            //NativeHandle->SType = StructureType.DeviceQueueCreateInfo;
        }
    }
}
