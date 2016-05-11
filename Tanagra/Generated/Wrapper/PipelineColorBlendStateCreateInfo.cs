using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineColorBlendStateCreateInfo
    {
        internal Interop.PipelineColorBlendStateCreateInfo* NativePointer;
        
        public PipelineColorBlendStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public Bool32 LogicOpEnable
        {
            get { return NativePointer->LogicOpEnable; }
            set { NativePointer->LogicOpEnable = value; }
        }
        
        public LogicOp LogicOp
        {
            get { return NativePointer->LogicOp; }
            set { NativePointer->LogicOp = value; }
        }
        
        public UInt32 AttachmentCount
        {
            get { return NativePointer->AttachmentCount; }
            set { NativePointer->AttachmentCount = value; }
        }
        
        public PipelineColorBlendAttachmentState[] Attachments
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
        
        public Single BlendConstants
        {
            get { return NativePointer->BlendConstants; }
            set { NativePointer->BlendConstants = value; }
        }
        
        public PipelineColorBlendStateCreateInfo()
        {
            NativePointer = (Interop.PipelineColorBlendStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineColorBlendStateCreateInfo));
            NativePointer->SType = StructureType.PipelineColorBlendStateCreateInfo;
        }
    }
}
