using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineColorBlendAttachmentState
    {
        internal Interop.PipelineColorBlendAttachmentState* NativeHandle;
        
        public Boolean BlendEnable
        {
            get { return NativeHandle->BlendEnable; }
            set { NativeHandle->BlendEnable = value; }
        }
        
        public BlendFactor SrcColorBlendFactor
        {
            get { return NativeHandle->SrcColorBlendFactor; }
            set { NativeHandle->SrcColorBlendFactor = value; }
        }
        
        public BlendFactor DstColorBlendFactor
        {
            get { return NativeHandle->DstColorBlendFactor; }
            set { NativeHandle->DstColorBlendFactor = value; }
        }
        
        public BlendOp ColorBlendOp
        {
            get { return NativeHandle->ColorBlendOp; }
            set { NativeHandle->ColorBlendOp = value; }
        }
        
        public BlendFactor SrcAlphaBlendFactor
        {
            get { return NativeHandle->SrcAlphaBlendFactor; }
            set { NativeHandle->SrcAlphaBlendFactor = value; }
        }
        
        public BlendFactor DstAlphaBlendFactor
        {
            get { return NativeHandle->DstAlphaBlendFactor; }
            set { NativeHandle->DstAlphaBlendFactor = value; }
        }
        
        public BlendOp AlphaBlendOp
        {
            get { return NativeHandle->AlphaBlendOp; }
            set { NativeHandle->AlphaBlendOp = value; }
        }
        
        public ColorComponentFlags ColorWriteMask
        {
            get { return NativeHandle->ColorWriteMask; }
            set { NativeHandle->ColorWriteMask = value; }
        }
        
        public PipelineColorBlendAttachmentState()
        {
            NativeHandle = (Interop.PipelineColorBlendAttachmentState*)Interop.Structure.Allocate(typeof(Interop.PipelineColorBlendAttachmentState));
        }
    }
}
