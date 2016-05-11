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
                var valueCount = NativePointer->QueueCount;
                var valueArray = new Single[valueCount];
                var ptr = (Single*)NativePointer->QueuePriorities;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->QueueCount = (uint)valueCount;
                NativePointer->QueuePriorities = Marshal.AllocHGlobal((int)(Marshal.SizeOf<Single>() * valueCount));
                var ptr = (Single*)NativePointer->QueuePriorities;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public DeviceQueueCreateInfo()
        {
            NativePointer = (Interop.DeviceQueueCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DeviceQueueCreateInfo));
            NativePointer->SType = StructureType.DeviceQueueCreateInfo;
        }
    }
}
