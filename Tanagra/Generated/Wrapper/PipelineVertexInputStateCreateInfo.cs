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
        
        VertexInputBindingDescription _VertexBindingDescriptions;
        public VertexInputBindingDescription VertexBindingDescriptions
        {
            get { return _VertexBindingDescriptions; }
            set { _VertexBindingDescriptions = value; NativePointer->VertexBindingDescriptions = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 VertexAttributeDescriptionCount
        {
            get { return NativePointer->VertexAttributeDescriptionCount; }
            set { NativePointer->VertexAttributeDescriptionCount = value; }
        }
        
        VertexInputAttributeDescription _VertexAttributeDescriptions;
        public VertexInputAttributeDescription VertexAttributeDescriptions
        {
            get { return _VertexAttributeDescriptions; }
            set { _VertexAttributeDescriptions = value; NativePointer->VertexAttributeDescriptions = (IntPtr)value.NativePointer; }
        }
        
        public PipelineVertexInputStateCreateInfo()
        {
            NativePointer = (Interop.PipelineVertexInputStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineVertexInputStateCreateInfo));
            NativePointer->SType = StructureType.PipelineVertexInputStateCreateInfo;
        }
    }
}
