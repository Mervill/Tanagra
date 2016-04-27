using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineColorBlendStateCreateInfo
    {
        internal Interop.PipelineColorBlendStateCreateInfo* NativeHandle;
        
        public PipelineColorBlendStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public Boolean LogicOpEnable
        {
            get { return NativeHandle->LogicOpEnable; }
            set { NativeHandle->LogicOpEnable = value; }
        }
        
        public LogicOp LogicOp
        {
            get { return NativeHandle->LogicOp; }
            set { NativeHandle->LogicOp = value; }
        }
        
        public UInt32 AttachmentCount
        {
            get { return NativeHandle->AttachmentCount; }
            set { NativeHandle->AttachmentCount = value; }
        }
        
        PipelineColorBlendAttachmentState _Attachments;
        public PipelineColorBlendAttachmentState Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; NativeHandle->Attachments = (IntPtr)value.NativeHandle; }
        }
        
        public Single BlendConstants
        {
            get { return NativeHandle->BlendConstants; }
            set { NativeHandle->BlendConstants = value; }
        }
        
        public PipelineColorBlendStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineColorBlendStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineColorBlendStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineColorBlendStateCreateInfo;
        }
    }
}
