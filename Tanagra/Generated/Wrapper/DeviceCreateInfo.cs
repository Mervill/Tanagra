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
        public string[] EnabledLayerNames
        {
            get
            {
                var strings = new String[NativePointer->EnabledLayerCount];
                void** ptr = (void**)NativePointer->EnabledLayerNames;
                for(var x = 0; x < NativePointer->EnabledLayerCount; x++)
                    strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return strings;
            }
            set
            {
                NativePointer->EnabledLayerCount = (UInt32)value.Length;
                NativePointer->EnabledLayerNames = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*NativePointer->EnabledLayerCount));
                void** ptr = (void**)NativePointer->EnabledLayerNames;
                for(var x = 0; x < NativePointer->EnabledLayerCount; x++)
                    ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
            }
        }
        
        public string[] EnabledExtensionNames
        {
            get
            {
                var strings = new String[NativePointer->EnabledExtensionCount];
                void** ptr = (void**)NativePointer->EnabledExtensionNames;
                for(var x = 0; x < NativePointer->EnabledExtensionCount; x++)
                    strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return strings;
            }
            set
            {
                NativePointer->EnabledExtensionCount = (UInt32)value.Length;
                NativePointer->EnabledExtensionNames = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*NativePointer->EnabledExtensionCount));
                void** ptr = (void**)NativePointer->EnabledExtensionNames;
                for(var x = 0; x < NativePointer->EnabledExtensionCount; x++)
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
