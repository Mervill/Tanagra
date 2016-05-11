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
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
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
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public PipelineVertexInputStateCreateInfo()
        {
            NativePointer = (Interop.PipelineVertexInputStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineVertexInputStateCreateInfo));
            NativePointer->SType = StructureType.PipelineVertexInputStateCreateInfo;
        }
    }
}
