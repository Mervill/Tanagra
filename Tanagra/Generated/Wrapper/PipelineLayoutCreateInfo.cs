using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineLayoutCreateInfo
    {
        internal Interop.PipelineLayoutCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved
        /// </summary>
        public PipelineLayoutCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Array of setCount number of descriptor set layout objects defining the layout of the
        /// </summary>
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
                NativePointer->SetLayoutCount = (UInt32)valueCount;
                NativePointer->SetLayouts = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->SetLayouts;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
        }
        
        /// <summary>
        /// Array of pushConstantRangeCount number of ranges used by various shader stages
        /// </summary>
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
                NativePointer->PushConstantRangeCount = (UInt32)valueCount;
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
        
        public PipelineLayoutCreateInfo(DescriptorSetLayout[] SetLayouts, PushConstantRange[] PushConstantRanges) : this()
        {
            this.SetLayouts = SetLayouts;
            this.PushConstantRanges = PushConstantRanges;
        }
    }
}
