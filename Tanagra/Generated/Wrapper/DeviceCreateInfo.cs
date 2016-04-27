using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DeviceCreateInfo
    {
        internal Interop.DeviceCreateInfo* NativeHandle;
        
        public DeviceCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 QueueCreateInfoCount
        {
            get { return NativeHandle->QueueCreateInfoCount; }
            set { NativeHandle->QueueCreateInfoCount = value; }
        }
        
        DeviceQueueCreateInfo _QueueCreateInfos;
        public DeviceQueueCreateInfo QueueCreateInfos
        {
            get { return _QueueCreateInfos; }
            set { _QueueCreateInfos = value; NativeHandle->QueueCreateInfos = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 EnabledLayerCount
        {
            get { return NativeHandle->EnabledLayerCount; }
            set { NativeHandle->EnabledLayerCount = value; }
        }
        
        public string[] EnabledLayerNames
        {
            get
            {
                var strings = new String[NativeHandle->EnabledLayerCount];
                void** ptr = (void**)NativeHandle->EnabledLayerNames;
                for(int x = 0; x < NativeHandle->EnabledLayerCount; x++)
                    strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return strings;
            }
            set
            {
                NativeHandle->EnabledLayerCount = (uint)value.Length;
                NativeHandle->EnabledLayerNames = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*NativeHandle->EnabledLayerCount));
                void** ptr = (void**)NativeHandle->EnabledLayerNames;
                for(int x = 0; x < NativeHandle->EnabledLayerCount; x++)
                    ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
            }
        }
        
        public UInt32 EnabledExtensionCount
        {
            get { return NativeHandle->EnabledExtensionCount; }
            set { NativeHandle->EnabledExtensionCount = value; }
        }
        
        public string[] EnabledExtensionNames
        {
            get
            {
                var strings = new String[NativeHandle->EnabledExtensionCount];
                void** ptr = (void**)NativeHandle->EnabledExtensionNames;
                for(int x = 0; x < NativeHandle->EnabledExtensionCount; x++)
                    strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return strings;
            }
            set
            {
                NativeHandle->EnabledExtensionCount = (uint)value.Length;
                NativeHandle->EnabledExtensionNames = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*NativeHandle->EnabledExtensionCount));
                void** ptr = (void**)NativeHandle->EnabledExtensionNames;
                for(int x = 0; x < NativeHandle->EnabledExtensionCount; x++)
                    ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
            }
        }
        
        PhysicalDeviceFeatures _EnabledFeatures;
        public PhysicalDeviceFeatures EnabledFeatures
        {
            get { return _EnabledFeatures; }
            set { _EnabledFeatures = value; NativeHandle->EnabledFeatures = (IntPtr)value.NativeHandle; }
        }
        
        public DeviceCreateInfo()
        {
            NativeHandle = (Interop.DeviceCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DeviceCreateInfo));
            //NativeHandle->SType = StructureType.DeviceCreateInfo;
        }
    }
}
