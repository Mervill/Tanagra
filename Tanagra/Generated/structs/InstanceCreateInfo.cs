using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class InstanceCreateInfo
    {
        internal Interop.InstanceCreateInfo* NativeHandle;
        
        public InstanceCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        ApplicationInfo _ApplicationInfo;
        public ApplicationInfo ApplicationInfo
        {
            get { return _ApplicationInfo; }
            set { _ApplicationInfo = value; NativeHandle->ApplicationInfo = (IntPtr)value.NativeHandle; }
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
        
        public InstanceCreateInfo()
        {
            NativeHandle = (Interop.InstanceCreateInfo*)Interop.Structure.Allocate(typeof(Interop.InstanceCreateInfo));
            //NativeHandle->SType = StructureType.InstanceCreateInfo;
        }
    }
}
