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
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public DescriptorPoolCreateInfo()
        {
            NativePointer = (Interop.DescriptorPoolCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorPoolCreateInfo));
            NativePointer->SType = StructureType.DescriptorPoolCreateInfo;
        }
    }
}
