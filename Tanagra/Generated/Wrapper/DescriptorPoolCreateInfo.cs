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
        
        DescriptorPoolSize _PoolSizes;
        public DescriptorPoolSize PoolSizes
        {
            get { return _PoolSizes; }
            set { _PoolSizes = value; NativePointer->PoolSizes = (IntPtr)value.NativePointer; }
        }
        
        public DescriptorPoolCreateInfo()
        {
            NativePointer = (Interop.DescriptorPoolCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorPoolCreateInfo));
            //NativePointer->SType = StructureType.DescriptorPoolCreateInfo;
        }
    }
}
