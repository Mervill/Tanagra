using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorPoolCreateInfo
    {
        internal Interop.DescriptorPoolCreateInfo* NativePointer;
        
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
        
        public UInt32 PoolSizeCount
        {
            get { return NativePointer->PoolSizeCount; }
            set { NativePointer->PoolSizeCount = value; }
        }
        
        public DescriptorPoolSize[] PoolSizes
        {
            get
            {
                var valueCount = NativePointer->PoolSizeCount;
                var valueArray = new DescriptorPoolSize[valueCount];
                var ptr = (DescriptorPoolSize*)NativePointer->PoolSizes;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->PoolSizeCount = (uint)valueCount;
                NativePointer->PoolSizes = Marshal.AllocHGlobal(Marshal.SizeOf<DescriptorPoolSize>() * valueCount);
                var ptr = (DescriptorPoolSize*)NativePointer->PoolSizes;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public DescriptorPoolCreateInfo()
        {
            NativePointer = (Interop.DescriptorPoolCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorPoolCreateInfo));
            NativePointer->SType = StructureType.DescriptorPoolCreateInfo;
        }
        
        public DescriptorPoolCreateInfo(UInt32 MaxSets, UInt32 PoolSizeCount, DescriptorPoolSize[] PoolSizes) : this()
        {
            this.MaxSets = MaxSets;
            this.PoolSizeCount = PoolSizeCount;
            this.PoolSizes = PoolSizes;
        }
    }
}
