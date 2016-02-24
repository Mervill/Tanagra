using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineColorBlendStateCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineColorBlendStateCreateFlags flags;
        public Boolean logicOpEnable;
        public LogicOp logicOp;
        public UInt32 attachmentCount;
        public PipelineColorBlendAttachmentState[] Attachments; // len:attachmentCount
        public Single blendConstants;
    }
}
