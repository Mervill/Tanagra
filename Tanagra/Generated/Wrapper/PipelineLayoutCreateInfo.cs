using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineLayoutCreateInfo
    {
        internal Interop.PipelineLayoutCreateInfo* NativePointer;
        
        public PipelineLayoutCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 SetLayoutCount
        {
            get { return NativePointer->SetLayoutCount; }
            set { NativePointer->SetLayoutCount = value; }
        }
        
        public DescriptorSetLayout[] SetLayouts
        {
            get
            {
                var valueCount = NativePointer->SetLayoutCount;
                var valueArray = new DescriptorSetLayout[valueCount];
                var ptr = (UInt64*)NativePointer->SetLayouts;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorSetLayout { NativePointer = ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->SetLayoutCount = (uint)valueCount;
                NativePointer->SetLayouts = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->SetLayouts;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
        }
        
        public UInt32 PushConstantRangeCount
        {
            get { return NativePointer->PushConstantRangeCount; }
            set { NativePointer->PushConstantRangeCount = value; }
        }
        
        public PushConstantRange[] PushConstantRanges
        {
            get
            {
                var valueCount = NativePointer->PushConstantRangeCount;
                var valueArray = new PushConstantRange[valueCount];
                var ptr = (PushConstantRange*)NativePointer->PushConstantRanges;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->PushConstantRangeCount = (uint)valueCount;
                NativePointer->PushConstantRanges = Marshal.AllocHGlobal(Marshal.SizeOf<PushConstantRange>() * valueCount);
                var ptr = (PushConstantRange*)NativePointer->PushConstantRanges;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public PipelineLayoutCreateInfo()
        {
            NativePointer = (Interop.PipelineLayoutCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineLayoutCreateInfo));
            NativePointer->SType = StructureType.PipelineLayoutCreateInfo;
        }
    }
}
