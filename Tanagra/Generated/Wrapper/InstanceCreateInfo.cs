using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class InstanceCreateInfo
    {
        internal Interop.InstanceCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved
        /// </summary>
        public InstanceCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        ApplicationInfo _ApplicationInfo;
        public ApplicationInfo ApplicationInfo
        {
            get { return _ApplicationInfo; }
            set { _ApplicationInfo = value; NativePointer->ApplicationInfo = (IntPtr)value.NativePointer; }
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
        
        /// <summary>
        /// Extension names to be enabled
        /// </summary>
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
        
        public InstanceCreateInfo()
        {
            NativePointer = (Interop.InstanceCreateInfo*)Interop.Structure.Allocate(typeof(Interop.InstanceCreateInfo));
            NativePointer->SType = StructureType.InstanceCreateInfo;
        }
        
        public InstanceCreateInfo(String[] EnabledLayerNames, String[] EnabledExtensionNames) : this()
        {
            this.EnabledLayerNames = EnabledLayerNames;
            this.EnabledExtensionNames = EnabledExtensionNames;
        }
    }
}
