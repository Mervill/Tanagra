using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PushConstantRange
    {
        /// <summary>
        /// Which stages use the range
        /// </summary>
        public ShaderStageFlags StageFlags;
        /// <summary>
        /// Start of the range, in bytes
        /// </summary>
        public UInt32 Offset;
        /// <summary>
        /// Size of the range, in bytes
        /// </summary>
        public UInt32 Size;
        
        /// <param name="StageFlags">Which stages use the range</param>
        /// <param name="Offset">Start of the range, in bytes</param>
        /// <param name="Size">Size of the range, in bytes</param>
        public PushConstantRange(ShaderStageFlags StageFlags, UInt32 Offset, UInt32 Size)
        {
            this.StageFlags = StageFlags;
            this.Offset = Offset;
            this.Size = Size;
        }
    }
}
