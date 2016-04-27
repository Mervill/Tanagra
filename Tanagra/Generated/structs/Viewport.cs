using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Viewport
    {
        internal Interop.Viewport* NativeHandle;
        
        public Single X
        {
            get { return NativeHandle->X; }
            set { NativeHandle->X = value; }
        }
        
        public Single Y
        {
            get { return NativeHandle->Y; }
            set { NativeHandle->Y = value; }
        }
        
        public Single Width
        {
            get { return NativeHandle->Width; }
            set { NativeHandle->Width = value; }
        }
        
        public Single Height
        {
            get { return NativeHandle->Height; }
            set { NativeHandle->Height = value; }
        }
        
        public Single MinDepth
        {
            get { return NativeHandle->MinDepth; }
            set { NativeHandle->MinDepth = value; }
        }
        
        public Single MaxDepth
        {
            get { return NativeHandle->MaxDepth; }
            set { NativeHandle->MaxDepth = value; }
        }
        
        public Viewport()
        {
            NativeHandle = (Interop.Viewport*)Interop.Structure.Allocate(typeof(Interop.Viewport));
        }
    }
}
