using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorPoolCreateInfo
    {
        internal Interop.DescriptorPoolCreateInfo* NativeHandle;
        
        public DescriptorPoolCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 MaxSets
        {
            get { return NativeHandle->MaxSets; }
            set { NativeHandle->MaxSets = value; }
        }
        
        public UInt32 PoolSizeCount
        {
            get { return NativeHandle->PoolSizeCount; }
            set { NativeHandle->PoolSizeCount = value; }
        }
        
        DescriptorPoolSize _PoolSizes;
        public DescriptorPoolSize PoolSizes
        {
            get { return _PoolSizes; }
            set { _PoolSizes = value; NativeHandle->PoolSizes = (IntPtr)value.NativeHandle; }
        }
        
        public DescriptorPoolCreateInfo()
        {
            NativeHandle = (Interop.DescriptorPoolCreateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorPoolCreateInfo));
            //NativeHandle->SType = StructureType.DescriptorPoolCreateInfo;
        }
    }
}
