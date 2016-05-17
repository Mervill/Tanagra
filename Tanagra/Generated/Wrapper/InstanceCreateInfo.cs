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
        
        /// <summary>
        /// Extension names to be enabled
        /// </summary>
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
