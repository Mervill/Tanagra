using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineLayoutCreateInfo
    {
        internal Interop.PipelineLayoutCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
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
                if(NativePointer->SetLayouts == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->SetLayoutCount;
                var valueArray = new DescriptorSetLayout[valueCount];
                var ptr = (UInt64*)NativePointer->SetLayouts;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorSetLayout { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->SetLayouts != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->SetLayouts, (IntPtr)typeSize);
                    
                    if(NativePointer->SetLayouts == IntPtr.Zero)
                        NativePointer->SetLayouts = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->SetLayoutCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->SetLayouts;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->SetLayouts != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->SetLayouts);
                    
                    NativePointer->SetLayouts = IntPtr.Zero;
                    NativePointer->SetLayoutCount = 0;
                }
            }
        }
        
        /// <summary>
        /// Array of pushConstantRangeCount number of ranges used by various shader stages
        /// </summary>
        public PushConstantRange[] PushConstantRanges
        {
            get
            {
                if(NativePointer->PushConstantRanges == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->PushConstantRangeCount;
                var valueArray = new PushConstantRange[valueCount];
                var ptr = (PushConstantRange*)NativePointer->PushConstantRanges;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<PushConstantRange>() * valueCount;
                    if(NativePointer->PushConstantRanges != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->PushConstantRanges, (IntPtr)typeSize);
                    
                    if(NativePointer->PushConstantRanges == IntPtr.Zero)
                        NativePointer->PushConstantRanges = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->PushConstantRangeCount = (UInt32)valueCount;
                    var ptr = (PushConstantRange*)NativePointer->PushConstantRanges;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->PushConstantRanges != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->PushConstantRanges);
                    
                    NativePointer->PushConstantRanges = IntPtr.Zero;
                    NativePointer->PushConstantRangeCount = 0;
                }
            }
        }
        
        public PipelineLayoutCreateInfo()
        {
            NativePointer = (Interop.PipelineLayoutCreateInfo*)MemoryUtils.Allocate(typeof(Interop.PipelineLayoutCreateInfo));
            NativePointer->SType = StructureType.PipelineLayoutCreateInfo;
        }
        
        public PipelineLayoutCreateInfo(DescriptorSetLayout[] SetLayouts, PushConstantRange[] PushConstantRanges) : this()
        {
            this.SetLayouts = SetLayouts;
            this.PushConstantRanges = PushConstantRanges;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.PipelineLayoutCreateInfo*)IntPtr.Zero;
        }
    }
}
