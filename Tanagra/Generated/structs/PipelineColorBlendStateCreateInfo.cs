using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineColorBlendStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineColorBlendStateCreateFlags flags;
        public Boolean logicOpEnable;
        public LogicOp logicOp;
        public UInt32 attachmentCount;
        public PipelineColorBlendAttachmentState pAttachments;
        public Single blendConstants;
    }
}
