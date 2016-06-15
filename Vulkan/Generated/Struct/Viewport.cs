using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Viewport
    {
        public Single X;
        public Single Y;
        public Single Width;
        public Single Height;
        public Single MinDepth;
        public Single MaxDepth;
        
        public Viewport(Single X, Single Y, Single Width, Single Height, Single MinDepth, Single MaxDepth)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.MinDepth = MinDepth;
            this.MaxDepth = MaxDepth;
        }
    }
}
