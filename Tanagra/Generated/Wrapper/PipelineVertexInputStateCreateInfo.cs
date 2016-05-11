using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineVertexInputStateCreateInfo
    {
        internal Interop.PipelineVertexInputStateCreateInfo* NativePointer;
        
        public PipelineVertexInputStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 VertexBindingDescriptionCount
        {
            get { return NativePointer->VertexBindingDescriptionCount; }
            set { NativePointer->VertexBindingDescriptionCount = value; }
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
                NativePointer->VertexBindingDescriptionCount = (uint)valueCount;
                NativePointer->VertexBindingDescriptions = Marshal.AllocHGlobal(Marshal.SizeOf<VertexInputBindingDescription>() * valueCount);
                var ptr = (VertexInputBindingDescription*)NativePointer->VertexBindingDescriptions;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public UInt32 VertexAttributeDescriptionCount
        {
            get { return NativePointer->VertexAttributeDescriptionCount; }
            set { NativePointer->VertexAttributeDescriptionCount = value; }
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
                NativePointer->VertexAttributeDescriptionCount = (uint)valueCount;
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
    }
}
