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
                var valueCount = NativePointer->ViewportCount;
                var valueArray = new Viewport[valueCount];
                var ptr = (Viewport*)NativePointer->Viewports;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->ViewportCount = (uint)valueCount;
                NativePointer->Viewports = Marshal.AllocHGlobal((int)(Marshal.SizeOf<Viewport>() * valueCount));
                var ptr = (Viewport*)NativePointer->Viewports;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
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
                var valueCount = NativePointer->ScissorCount;
                var valueArray = new Rect2D[valueCount];
                var ptr = (Rect2D*)NativePointer->Scissors;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->ScissorCount = (uint)valueCount;
                NativePointer->Scissors = Marshal.AllocHGlobal((int)(Marshal.SizeOf<Rect2D>() * valueCount));
                var ptr = (Rect2D*)NativePointer->Scissors;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public PipelineViewportStateCreateInfo()
        {
            NativePointer = (Interop.PipelineViewportStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineViewportStateCreateInfo));
            NativePointer->SType = StructureType.PipelineViewportStateCreateInfo;
        }
    }
}
