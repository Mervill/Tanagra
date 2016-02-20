using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Viewport
    {
        public Single x;
        public Single y;
        public Single width;
        public Single height;
        public Single minDepth;
        public Single maxDepth;
    }
}
