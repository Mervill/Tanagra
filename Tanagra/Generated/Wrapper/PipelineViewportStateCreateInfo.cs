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
                NativePointer->ViewportCount = (UInt32)valueCount;
                NativePointer->Viewports = Marshal.AllocHGlobal(Marshal.SizeOf<Viewport>() * valueCount);
                var ptr = (Viewport*)NativePointer->Viewports;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
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
                NativePointer->ScissorCount = (UInt32)valueCount;
                NativePointer->Scissors = Marshal.AllocHGlobal(Marshal.SizeOf<Rect2D>() * valueCount);
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
