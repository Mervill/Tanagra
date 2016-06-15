using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClearRect
    {
        public Rect2D Rect;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
        
        public ClearRect(Rect2D Rect, UInt32 BaseArrayLayer, UInt32 LayerCount)
        {
            this.Rect = Rect;
            this.BaseArrayLayer = BaseArrayLayer;
            this.LayerCount = LayerCount;
        }
    }
}
