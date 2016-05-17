using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DeviceCreateInfo
    {
        internal Interop.DeviceCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved
        /// </summary>
        public DeviceCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public DeviceQueueCreateInfo[] QueueCreateInfos
        {
            get
            {
                var valueCount = NativePointer->QueueCreateInfoCount;
                var valueArray = new DeviceQueueCreateInfo[valueCount];
                var ptr = (Interop.DeviceQueueCreateInfo*)NativePointer->QueueCreateInfos;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DeviceQueueCreateInfo { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->QueueCreateInfoCount = (UInt32)valueCount;
                NativePointer->QueueCreateInfos = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.DeviceQueueCreateInfo>() * valueCount);
                var ptr = (Interop.DeviceQueueCreateInfo*)NativePointer->QueueCreateInfos;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
        }
        
        /// <summary>
        /// Ordered list of layer names to be enabled
        /// </summary>
        public String[] EnabledLayerNames
        {
            get
            {
                var valueCount = NativePointer->EnabledLayerCount;
                var valueArray = new String[valueCount];
                var ptr = (void**)NativePointer->EnabledLayerNames;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->EnabledLayerCount = (UInt32)valueCount;
                NativePointer->EnabledLayerNames = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (void**)NativePointer->EnabledLayerNames;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
            }
        }
        
        public String[] EnabledExtensionNames
        {
            get
            {
                var valueCount = NativePointer->EnabledExtensionCount;
                var valueArray = new String[valueCount];
                var ptr = (void**)NativePointer->EnabledExtensionNames;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->EnabledExtensionCount = (UInt32)valueCount;
                NativePointer->EnabledExtensionNames = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (void**)NativePointer->EnabledExtensionNames;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
            }
        }
        
        PhysicalDeviceFeatures _EnabledFeatures;
        public PhysicalDeviceFeatures EnabledFeatures
        {
            get { return _EnabledFeatures; }
            set { _EnabledFeatures = value; NativePointer->EnabledFeatures = (IntPtr)(&value); }
        }
        
        public DeviceCreateInfo()
        {
            NativePointer = (Interop.DeviceCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DeviceCreateInfo));
            NativePointer->SType = StructureType.DeviceCreateInfo;
        }
        
        public DeviceCreateInfo(DeviceQueueCreateInfo[] QueueCreateInfos, String[] EnabledLayerNames, String[] EnabledExtensionNames) : this()
        {
            this.QueueCreateInfos = QueueCreateInfos;
            this.EnabledLayerNames = EnabledLayerNames;
            this.EnabledExtensionNames = EnabledExtensionNames;
        }
    }
}
