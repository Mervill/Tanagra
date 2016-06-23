using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PipelineLayoutCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineLayoutCreateInfo* NativePointer { get; private set; }
        
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
                    valueArray[x] = new DescriptorSetLayout(ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt64)) * valueCount;
                    if(NativePointer->SetLayouts != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->SetLayouts, (IntPtr)typeSize);
                    
                    if(NativePointer->SetLayouts == IntPtr.Zero)
                        NativePointer->SetLayouts = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->SetLayoutCount = (UInt32)valueCount;
                    var ptr = (UInt64*)NativePointer->SetLayouts;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x].NativePointer;
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
                    var typeSize = Marshal.SizeOf(typeof(PushConstantRange)) * valueCount;
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
            NativePointer = (Unmanaged.PipelineLayoutCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.PipelineLayoutCreateInfo));
            NativePointer->SType = StructureType.PipelineLayoutCreateInfo;
        }
        
        internal PipelineLayoutCreateInfo(Unmanaged.PipelineLayoutCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.PipelineLayoutCreateInfo));
        }
        
        /// <param name="SetLayouts">Array of setCount number of descriptor set layout objects defining the layout of the</param>
        /// <param name="PushConstantRanges">Array of pushConstantRangeCount number of ranges used by various shader stages</param>
        public PipelineLayoutCreateInfo(DescriptorSetLayout[] SetLayouts, PushConstantRange[] PushConstantRanges) : this()
        {
            this.SetLayouts = SetLayouts;
            this.PushConstantRanges = PushConstantRanges;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->SetLayouts);
            Marshal.FreeHGlobal(NativePointer->PushConstantRanges);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineLayoutCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->SetLayouts);
                Marshal.FreeHGlobal(NativePointer->PushConstantRanges);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
