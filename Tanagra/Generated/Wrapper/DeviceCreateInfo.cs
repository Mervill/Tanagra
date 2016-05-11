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
        
        public DeviceQueueCreateInfo[] QueueCreateInfos
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
                for(var x = 0; x < NativePointer->EnabledLayerCount; x++)
                    strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return strings;
            }
            set
            {
                NativePointer->EnabledLayerCount = (uint)value.Length;
                NativePointer->EnabledLayerNames = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*NativePointer->EnabledLayerCount));
                void** ptr = (void**)NativePointer->EnabledLayerNames;
                for(var x = 0; x < NativePointer->EnabledLayerCount; x++)
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
                for(var x = 0; x < NativePointer->EnabledExtensionCount; x++)
                    strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return strings;
            }
            set
            {
                NativePointer->EnabledExtensionCount = (uint)value.Length;
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
    }
}
