using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferCopy
    {
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize SrcOffset;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize DstOffset;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        
        /// <param name="SrcOffset">Specified in bytes</param>
        /// <param name="DstOffset">Specified in bytes</param>
        /// <param name="Size">Specified in bytes</param>
        public BufferCopy(DeviceSize SrcOffset, DeviceSize DstOffset, DeviceSize Size)
        {
            this.SrcOffset = SrcOffset;
            this.DstOffset = DstOffset;
            this.Size = Size;
        }
    }
}
