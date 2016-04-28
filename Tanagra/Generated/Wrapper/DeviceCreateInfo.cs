using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DeviceCreateInfo
    {
        internal Interop.DeviceCreateInfo* NativePointer;
        
        public DeviceCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 QueueCreateInfoCount
        {
            get { return NativePointer->QueueCreateInfoCount; }
            set { NativePointer->QueueCreateInfoCount = value; }
        }
        
        DeviceQueueCreateInfo _QueueCreateInfos;
        public DeviceQueueCreateInfo QueueCreateInfos
        {
            get { return _QueueCreateInfos; }
            set { _QueueCreateInfos = value; NativePointer->QueueCreateInfos = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 EnabledLayerCount
        {
            get { return NativePointer->EnabledLayerCount; }
            set { NativePointer->EnabledLayerCount = value; }
        }
        
        public string[] EnabledLayerNames
        {
            get
            {
                var strings = new String[NativePointer->EnabledLayerCount];
                void** ptr = (void**)NativePointer->EnabledLayerNames;
                for(int x = 0; x < NativePointer->EnabledLayerCount; x++)
                    strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return strings;
            }
            set
            {
                NativePointer->EnabledLayerCount = (uint)value.Length;
                NativePointer->EnabledLayerNames = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*NativePointer->EnabledLayerCount));
                void** ptr = (void**)NativePointer->EnabledLayerNames;
                for(int x = 0; x < NativePointer->EnabledLayerCount; x++)
                    ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
            }
        }
        
        public UInt32 EnabledExtensionCount
        {
            get { return NativePointer->EnabledExtensionCount; }
            set { NativePointer->EnabledExtensionCount = value; }
        }
        
        public string[] EnabledExtensionNames
        {
            get
            {
                var strings = new String[NativePointer->EnabledExtensionCount];
                void** ptr = (void**)NativePointer->EnabledExtensionNames;
                for(int x = 0; x < NativePointer->EnabledExtensionCount; x++)
                    strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return strings;
            }
            set
            {
                NativePointer->EnabledExtensionCount = (uint)value.Length;
                NativePointer->EnabledExtensionNames = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*NativePointer->EnabledExtensionCount));
                void** ptr = (void**)NativePointer->EnabledExtensionNames;
                for(int x = 0; x < NativePointer->EnabledExtensionCount; x++)
                    ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
            }
        }
        
        PhysicalDeviceFeatures _EnabledFeatures;
        public PhysicalDeviceFeatures EnabledFeatures
        {
            get { return _EnabledFeatures; }
            set { _EnabledFeatures = value; NativePointer->EnabledFeatures = (IntPtr)value.NativePointer; }
        }
        
        public DeviceCreateInfo()
        {
            NativePointer = (Interop.DeviceCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DeviceCreateInfo));
            //NativePointer->SType = StructureType.DeviceCreateInfo;
        }
    }
}
