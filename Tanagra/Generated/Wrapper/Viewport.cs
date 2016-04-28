using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Viewport
    {
        internal Interop.Viewport* NativePointer;
        
        public Single X
        {
            get { return NativePointer->X; }
            set { NativePointer->X = value; }
        }
        
        public Single Y
        {
            get { return NativePointer->Y; }
            set { NativePointer->Y = value; }
        }
        
        public Single Width
        {
            get { return NativePointer->Width; }
            set { NativePointer->Width = value; }
        }
        
        public Single Height
        {
            get { return NativePointer->Height; }
            set { NativePointer->Height = value; }
        }
        
        public Single MinDepth
        {
            get { return NativePointer->MinDepth; }
            set { NativePointer->MinDepth = value; }
        }
        
        public Single MaxDepth
        {
            get { return NativePointer->MaxDepth; }
            set { NativePointer->MaxDepth = value; }
        }
        
        public Viewport()
        {
            NativePointer = (Interop.Viewport*)Interop.Structure.Allocate(typeof(Interop.Viewport));
        }
    }
}
