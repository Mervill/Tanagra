using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineVertexInputStateCreateInfo
    {
        internal Interop.PipelineVertexInputStateCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved
        /// </summary>
        public PipelineVertexInputStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public VertexInputBindingDescription[] VertexBindingDescriptions
        {
            get
            {
                var valueCount = NativePointer->VertexBindingDescriptionCount;
                var valueArray = new VertexInputBindingDescription[valueCount];
                var ptr = (VertexInputBindingDescription*)NativePointer->VertexBindingDescriptions;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->VertexBindingDescriptionCount = (UInt32)valueCount;
                NativePointer->VertexBindingDescriptions = Marshal.AllocHGlobal(Marshal.SizeOf<VertexInputBindingDescription>() * valueCount);
                var ptr = (VertexInputBindingDescription*)NativePointer->VertexBindingDescriptions;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public VertexInputAttributeDescription[] VertexAttributeDescriptions
        {
            get
            {
                var valueCount = NativePointer->VertexAttributeDescriptionCount;
                var valueArray = new VertexInputAttributeDescription[valueCount];
                var ptr = (VertexInputAttributeDescription*)NativePointer->VertexAttributeDescriptions;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->VertexAttributeDescriptionCount = (UInt32)valueCount;
                NativePointer->VertexAttributeDescriptions = Marshal.AllocHGlobal(Marshal.SizeOf<VertexInputAttributeDescription>() * valueCount);
                var ptr = (VertexInputAttributeDescription*)NativePointer->VertexAttributeDescriptions;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public PipelineVertexInputStateCreateInfo()
        {
            NativePointer = (Interop.PipelineVertexInputStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineVertexInputStateCreateInfo));
            NativePointer->SType = StructureType.PipelineVertexInputStateCreateInfo;
        }
        
        public PipelineVertexInputStateCreateInfo(VertexInputBindingDescription[] VertexBindingDescriptions, VertexInputAttributeDescription[] VertexAttributeDescriptions) : this()
        {
            this.VertexBindingDescriptions = VertexBindingDescriptions;
            this.VertexAttributeDescriptions = VertexAttributeDescriptions;
        }
    }
}
