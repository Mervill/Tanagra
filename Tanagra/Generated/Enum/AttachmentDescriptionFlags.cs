using System;

namespace Vulkan
{
    [Flags]
    public enum AttachmentDescriptionFlags
    {
        /// <summary>
        /// The attachment may alias physical memory of another attachment in the same render pass
        /// </summary>
        MayAlias = 1 << 0,
    }
}
