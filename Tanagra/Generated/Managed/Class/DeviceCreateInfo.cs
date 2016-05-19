using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DeviceCreateInfo
    {
        internal Unmanaged.DeviceCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
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
                if(NativePointer->QueueCreateInfos == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->QueueCreateInfoCount;
                var valueArray = new DeviceQueueCreateInfo[valueCount];
                var ptr = (Unmanaged.DeviceQueueCreateInfo*)NativePointer->QueueCreateInfos;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DeviceQueueCreateInfo { NativePointer = &ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Unmanaged.DeviceQueueCreateInfo>() * valueCount;
                    if(NativePointer->QueueCreateInfos != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->QueueCreateInfos, (IntPtr)typeSize);
                    
                    if(NativePointer->QueueCreateInfos == IntPtr.Zero)
                        NativePointer->QueueCreateInfos = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->QueueCreateInfoCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.DeviceQueueCreateInfo*)NativePointer->QueueCreateInfos;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->QueueCreateInfos != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->QueueCreateInfos);
                    
                    NativePointer->QueueCreateInfos = IntPtr.Zero;
                    NativePointer->QueueCreateInfoCount = 0;
                }
            }
        }
        
        /// <summary>
        /// Ordered list of layer names to be enabled
        /// </summary>
        public String[] EnabledLayerNames
        {
            get
            {
                if(NativePointer->EnabledLayerNames == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->EnabledLayerCount;
                var valueArray = new String[valueCount];
                var ptr = (void**)NativePointer->EnabledLayerNames;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->EnabledLayerNames != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->EnabledLayerNames, (IntPtr)typeSize);
                    
                    if(NativePointer->EnabledLayerNames == IntPtr.Zero)
                        NativePointer->EnabledLayerNames = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->EnabledLayerCount = (UInt32)valueCount;
                    var ptr = (void**)NativePointer->EnabledLayerNames;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
                }
                else
                {
                    if(NativePointer->EnabledLayerNames != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->EnabledLayerNames);
                    
                    NativePointer->EnabledLayerNames = IntPtr.Zero;
                    NativePointer->EnabledLayerCount = 0;
                }
            }
        }
        
        public String[] EnabledExtensionNames
        {
            get
            {
                if(NativePointer->EnabledExtensionNames == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->EnabledExtensionCount;
                var valueArray = new String[valueCount];
                var ptr = (void**)NativePointer->EnabledExtensionNames;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->EnabledExtensionNames != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->EnabledExtensionNames, (IntPtr)typeSize);
                    
                    if(NativePointer->EnabledExtensionNames == IntPtr.Zero)
                        NativePointer->EnabledExtensionNames = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->EnabledExtensionCount = (UInt32)valueCount;
                    var ptr = (void**)NativePointer->EnabledExtensionNames;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);
                }
                else
                {
                    if(NativePointer->EnabledExtensionNames != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->EnabledExtensionNames);
                    
                    NativePointer->EnabledExtensionNames = IntPtr.Zero;
                    NativePointer->EnabledExtensionCount = 0;
                }
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
            NativePointer = (Unmanaged.DeviceCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.DeviceCreateInfo));
            NativePointer->SType = StructureType.DeviceCreateInfo;
        }
        
        public DeviceCreateInfo(DeviceQueueCreateInfo[] QueueCreateInfos, String[] EnabledLayerNames, String[] EnabledExtensionNames) : this()
        {
            this.QueueCreateInfos = QueueCreateInfos;
            this.EnabledLayerNames = EnabledLayerNames;
            this.EnabledExtensionNames = EnabledExtensionNames;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.DeviceCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
