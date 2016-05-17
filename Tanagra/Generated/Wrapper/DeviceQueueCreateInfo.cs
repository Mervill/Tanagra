using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DeviceQueueCreateInfo
    {
        internal Interop.DeviceQueueCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
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
        
        public Single[] QueuePriorities
        {
            get
            {
                if(NativePointer->QueuePriorities == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->QueueCount;
                var valueArray = new Single[valueCount];
                var ptr = (Single*)NativePointer->QueuePriorities;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Single>() * valueCount;
                    if(NativePointer->QueuePriorities != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->QueuePriorities, (IntPtr)typeSize);
                    
                    if(NativePointer->QueuePriorities == IntPtr.Zero)
                        NativePointer->QueuePriorities = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->QueueCount = (UInt32)valueCount;
                    var ptr = (Single*)NativePointer->QueuePriorities;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->QueuePriorities != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->QueuePriorities);
                    
                    NativePointer->QueuePriorities = IntPtr.Zero;
                    NativePointer->QueueCount = 0;
                }
            }
        }
        
        public DeviceQueueCreateInfo()
        {
            NativePointer = (Interop.DeviceQueueCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DeviceQueueCreateInfo));
            NativePointer->SType = StructureType.DeviceQueueCreateInfo;
        }
        
        public DeviceQueueCreateInfo(UInt32 QueueFamilyIndex, Single[] QueuePriorities) : this()
        {
            this.QueueFamilyIndex = QueueFamilyIndex;
            this.QueuePriorities = QueuePriorities;
        }
    }
}
