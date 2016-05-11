using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DeviceQueueCreateInfo
    {
        internal Interop.DeviceQueueCreateInfo* NativePointer;
        
        public DeviceQueueCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 QueueFamilyIndex
        {
            get { return NativePointer->QueueFamilyIndex; }
            set { NativePointer->QueueFamilyIndex = value; }
        }
        
        public UInt32 QueueCount
        {
            get { return NativePointer->QueueCount; }
            set { NativePointer->QueueCount = value; }
        }
        
        public Single[] QueuePriorities
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public DeviceQueueCreateInfo()
        {
            NativePointer = (Interop.DeviceQueueCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DeviceQueueCreateInfo));
            NativePointer->SType = StructureType.DeviceQueueCreateInfo;
        }
    }
}
