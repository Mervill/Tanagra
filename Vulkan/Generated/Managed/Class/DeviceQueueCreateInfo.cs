using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DeviceQueueCreateInfo : IDisposable
    {
        internal Unmanaged.DeviceQueueCreateInfo* NativePointer { get; private set; }
        
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
                    var typeSize = Marshal.SizeOf(typeof(Single)) * valueCount;
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
            NativePointer = (Unmanaged.DeviceQueueCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.DeviceQueueCreateInfo));
            NativePointer->SType = StructureType.DeviceQueueCreateInfo;
        }
        
        internal DeviceQueueCreateInfo(Unmanaged.DeviceQueueCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.DeviceQueueCreateInfo));
        }
        
        public DeviceQueueCreateInfo(UInt32 QueueFamilyIndex, Single[] QueuePriorities) : this()
        {
            this.QueueFamilyIndex = QueueFamilyIndex;
            this.QueuePriorities = QueuePriorities;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->QueuePriorities);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DeviceQueueCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->QueuePriorities);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
