using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SubpassDependency
    {
        public UInt32 SrcSubpass;
        public UInt32 DstSubpass;
        public PipelineStageFlags SrcStageMask;
        public PipelineStageFlags DstStageMask;
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask;
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags DstAccessMask;
        public DependencyFlags DependencyFlags;
        
        public SubpassDependency(UInt32 SrcSubpass, UInt32 DstSubpass, PipelineStageFlags SrcStageMask, PipelineStageFlags DstStageMask)
        {
            this.SrcSubpass = SrcSubpass;
            this.DstSubpass = DstSubpass;
            this.SrcStageMask = SrcStageMask;
            this.DstStageMask = DstStageMask;
            SrcAccessMask = default(AccessFlags);
            DstAccessMask = default(AccessFlags);
            DependencyFlags = default(DependencyFlags);
        }
    }
}
