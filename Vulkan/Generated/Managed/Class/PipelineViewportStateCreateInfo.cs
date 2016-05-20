using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PipelineViewportStateCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineViewportStateCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineViewportStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public Viewport[] Viewports
        {
            get
            {
                if(NativePointer->Viewports == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->ViewportCount;
                var valueArray = new Viewport[valueCount];
                var ptr = (Viewport*)NativePointer->Viewports;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Viewport)) * valueCount;
                    if(NativePointer->Viewports != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Viewports, (IntPtr)typeSize);
                    
                    if(NativePointer->Viewports == IntPtr.Zero)
                        NativePointer->Viewports = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->ViewportCount = (UInt32)valueCount;
                    var ptr = (Viewport*)NativePointer->Viewports;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->Viewports != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Viewports);
                    
                    NativePointer->Viewports = IntPtr.Zero;
                    NativePointer->ViewportCount = 0;
                }
            }
        }
        
        public Rect2D[] Scissors
        {
            get
            {
                if(NativePointer->Scissors == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->ScissorCount;
                var valueArray = new Rect2D[valueCount];
                var ptr = (Rect2D*)NativePointer->Scissors;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Rect2D)) * valueCount;
                    if(NativePointer->Scissors != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Scissors, (IntPtr)typeSize);
                    
                    if(NativePointer->Scissors == IntPtr.Zero)
                        NativePointer->Scissors = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->ScissorCount = (UInt32)valueCount;
                    var ptr = (Rect2D*)NativePointer->Scissors;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->Scissors != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Scissors);
                    
                    NativePointer->Scissors = IntPtr.Zero;
                    NativePointer->ScissorCount = 0;
                }
            }
        }
        
        public PipelineViewportStateCreateInfo()
        {
            NativePointer = (Unmanaged.PipelineViewportStateCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.PipelineViewportStateCreateInfo));
            NativePointer->SType = StructureType.PipelineViewportStateCreateInfo;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->Viewports);
            Marshal.FreeHGlobal(NativePointer->Scissors);
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.PipelineViewportStateCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineViewportStateCreateInfo()
        {
            if(NativePointer != (Unmanaged.PipelineViewportStateCreateInfo*)IntPtr.Zero)
            {
                Marshal.FreeHGlobal(NativePointer->Viewports);
                Marshal.FreeHGlobal(NativePointer->Scissors);
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.PipelineViewportStateCreateInfo*)IntPtr.Zero;
            }
        }
    }
}
