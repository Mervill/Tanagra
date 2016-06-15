using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SurfaceFormatKHR
    {
        /// <summary>
        /// Supported pair of rendering format
        /// </summary>
        public Format Format;
        /// <summary>
        /// And colorspace for the surface
        /// </summary>
        public ColorSpaceKHR ColorSpace;
        
        /// <param name="Format">Supported pair of rendering format</param>
        /// <param name="ColorSpace">And colorspace for the surface</param>
        public SurfaceFormatKHR(Format Format, ColorSpaceKHR ColorSpace)
        {
            this.Format = Format;
            this.ColorSpace = ColorSpace;
        }
    }
}
