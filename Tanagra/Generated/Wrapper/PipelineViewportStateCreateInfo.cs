using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineViewportStateCreateInfo
    {
        internal Interop.PipelineViewportStateCreateInfo* NativePointer;
        
        public PipelineViewportStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 ViewportCount
        {
            get { return NativePointer->ViewportCount; }
            set { NativePointer->ViewportCount = value; }
        }
        
        Viewport _Viewports;
        public Viewport Viewports
        {
            get { return _Viewports; }
            set { _Viewports = value; NativePointer->Viewports = (IntPtr)(&value); }
        }
        
        public UInt32 ScissorCount
        {
            get { return NativePointer->ScissorCount; }
            set { NativePointer->ScissorCount = value; }
        }
        
        Rect2D _Scissors;
        public Rect2D Scissors
        {
            get { return _Scissors; }
            set { _Scissors = value; NativePointer->Scissors = (IntPtr)(&value); }
        }
        
        public PipelineViewportStateCreateInfo()
        {
            NativePointer = (Interop.PipelineViewportStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineViewportStateCreateInfo));
            NativePointer->SType = StructureType.PipelineViewportStateCreateInfo;
        }
    }
}
