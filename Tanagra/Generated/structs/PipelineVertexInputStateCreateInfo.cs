using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineVertexInputStateCreateInfo
    {
        internal Interop.PipelineVertexInputStateCreateInfo* NativeHandle;
        
        public PipelineVertexInputStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 VertexBindingDescriptionCount
        {
            get { return NativeHandle->VertexBindingDescriptionCount; }
            set { NativeHandle->VertexBindingDescriptionCount = value; }
        }
        
        VertexInputBindingDescription _VertexBindingDescriptions;
        public VertexInputBindingDescription VertexBindingDescriptions
        {
            get { return _VertexBindingDescriptions; }
            set { _VertexBindingDescriptions = value; NativeHandle->VertexBindingDescriptions = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 VertexAttributeDescriptionCount
        {
            get { return NativeHandle->VertexAttributeDescriptionCount; }
            set { NativeHandle->VertexAttributeDescriptionCount = value; }
        }
        
        VertexInputAttributeDescription _VertexAttributeDescriptions;
        public VertexInputAttributeDescription VertexAttributeDescriptions
        {
            get { return _VertexAttributeDescriptions; }
            set { _VertexAttributeDescriptions = value; NativeHandle->VertexAttributeDescriptions = (IntPtr)value.NativeHandle; }
        }
        
        public PipelineVertexInputStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineVertexInputStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineVertexInputStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineVertexInputStateCreateInfo;
        }
    }
}
