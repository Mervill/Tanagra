using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineColorBlendStateCreateInfo
    {
        public struct BlendConstantsInfo
        {
            public Single R;
            public Single G;
            public Single B;
            public Single A;
        }
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineColorBlendStateCreateFlags Flags;
        public Bool32 LogicOpEnable;
        public LogicOp LogicOp;
        /// <summary>
        /// # of pAttachments (Optional)
        /// </summary>
        public UInt32 AttachmentCount;
        public IntPtr Attachments;
        public BlendConstantsInfo BlendConstants;
    }
}
