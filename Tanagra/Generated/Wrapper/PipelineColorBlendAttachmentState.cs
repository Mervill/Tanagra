using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineColorBlendAttachmentState
    {
        internal Interop.PipelineColorBlendAttachmentState* NativePointer;
        
        public Boolean BlendEnable
        {
            get { return NativePointer->BlendEnable; }
            set { NativePointer->BlendEnable = value; }
        }
        
        public BlendFactor SrcColorBlendFactor
        {
            get { return NativePointer->SrcColorBlendFactor; }
            set { NativePointer->SrcColorBlendFactor = value; }
        }
        
        public BlendFactor DstColorBlendFactor
        {
            get { return NativePointer->DstColorBlendFactor; }
            set { NativePointer->DstColorBlendFactor = value; }
        }
        
        public BlendOp ColorBlendOp
        {
            get { return NativePointer->ColorBlendOp; }
            set { NativePointer->ColorBlendOp = value; }
        }
        
        public BlendFactor SrcAlphaBlendFactor
        {
            get { return NativePointer->SrcAlphaBlendFactor; }
            set { NativePointer->SrcAlphaBlendFactor = value; }
        }
        
        public BlendFactor DstAlphaBlendFactor
        {
            get { return NativePointer->DstAlphaBlendFactor; }
            set { NativePointer->DstAlphaBlendFactor = value; }
        }
        
        public BlendOp AlphaBlendOp
        {
            get { return NativePointer->AlphaBlendOp; }
            set { NativePointer->AlphaBlendOp = value; }
        }
        
        public ColorComponentFlags ColorWriteMask
        {
            get { return NativePointer->ColorWriteMask; }
            set { NativePointer->ColorWriteMask = value; }
        }
        
        public PipelineColorBlendAttachmentState()
        {
            NativePointer = (Interop.PipelineColorBlendAttachmentState*)Interop.Structure.Allocate(typeof(Interop.PipelineColorBlendAttachmentState));
        }
    }
}
