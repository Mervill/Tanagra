using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayModeParametersKHR
    {
        /// <summary>
        /// Visible scannout region.
        /// </summary>
        public Extent2D VisibleRegion;
        /// <summary>
        /// Number of times per second the display is updated.
        /// </summary>
        public UInt32 RefreshRate;
        
        /// <param name="VisibleRegion">Visible scannout region.</param>
        /// <param name="RefreshRate">Number of times per second the display is updated.</param>
        public DisplayModeParametersKHR(Extent2D VisibleRegion, UInt32 RefreshRate)
        {
            this.VisibleRegion = VisibleRegion;
            this.RefreshRate = RefreshRate;
        }
    }
}
