using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineViewportStateCreateInfo
    {
        internal Interop.PipelineViewportStateCreateInfo* NativeHandle;
        
        public PipelineViewportStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 ViewportCount
        {
            get { return NativeHandle->ViewportCount; }
            set { NativeHandle->ViewportCount = value; }
        }
        
        Viewport _Viewports;
        public Viewport Viewports
        {
            get { return _Viewports; }
            set { _Viewports = value; NativeHandle->Viewports = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 ScissorCount
        {
            get { return NativeHandle->ScissorCount; }
            set { NativeHandle->ScissorCount = value; }
        }
        
        Rect2D _Scissors;
        public Rect2D Scissors
        {
            get { return _Scissors; }
            set { _Scissors = value; NativeHandle->Scissors = (IntPtr)value.NativeHandle; }
        }
        
        public PipelineViewportStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineViewportStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineViewportStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineViewportStateCreateInfo;
        }
    }
}
