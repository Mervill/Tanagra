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
        
        public Viewport[] Viewports
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public UInt32 ScissorCount
        {
            get { return NativePointer->ScissorCount; }
            set { NativePointer->ScissorCount = value; }
        }
        
        public Rect2D[] Scissors
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public PipelineViewportStateCreateInfo()
        {
            NativePointer = (Interop.PipelineViewportStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineViewportStateCreateInfo));
            NativePointer->SType = StructureType.PipelineViewportStateCreateInfo;
        }
    }
}
