using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DescriptorPoolCreateInfo : IDisposable
    {
        internal Unmanaged.DescriptorPoolCreateInfo* NativePointer;
        
        public DescriptorPoolCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 MaxSets
        {
            get { return NativePointer->MaxSets; }
            set { NativePointer->MaxSets = value; }
        }
        
        public DescriptorPoolSize[] PoolSizes
        {
            get
            {
                if(NativePointer->PoolSizes == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->PoolSizeCount;
                var valueArray = new DescriptorPoolSize[valueCount];
                var ptr = (DescriptorPoolSize*)NativePointer->PoolSizes;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(DescriptorPoolSize)) * valueCount;
                    if(NativePointer->PoolSizes != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->PoolSizes, (IntPtr)typeSize);
                    
                    if(NativePointer->PoolSizes == IntPtr.Zero)
                        NativePointer->PoolSizes = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->PoolSizeCount = (UInt32)valueCount;
                    var ptr = (DescriptorPoolSize*)NativePointer->PoolSizes;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->PoolSizes != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->PoolSizes);
                    
                    NativePointer->PoolSizes = IntPtr.Zero;
                    NativePointer->PoolSizeCount = 0;
                }
            }
        }
        
        public DescriptorPoolCreateInfo()
        {
            NativePointer = (Unmanaged.DescriptorPoolCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.DescriptorPoolCreateInfo));
            NativePointer->SType = StructureType.DescriptorPoolCreateInfo;
        }
        
        public DescriptorPoolCreateInfo(UInt32 MaxSets, DescriptorPoolSize[] PoolSizes) : this()
        {
            this.MaxSets = MaxSets;
            this.PoolSizes = PoolSizes;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->PoolSizes);
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DescriptorPoolCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->PoolSizes);
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
