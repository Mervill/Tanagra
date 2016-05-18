using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class RenderPassBeginInfo
    {
        internal Interop.RenderPassBeginInfo* NativePointer;
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativePointer->RenderPass = value.NativePointer; }
        }
        
        Framebuffer _Framebuffer;
        public Framebuffer Framebuffer
        {
            get { return _Framebuffer; }
            set { _Framebuffer = value; NativePointer->Framebuffer = value.NativePointer; }
        }
        
        public Rect2D RenderArea
        {
            get { return NativePointer->RenderArea; }
            set { NativePointer->RenderArea = value; }
        }
        
        public ClearValue[] ClearValues
        {
            get
            {
                if(NativePointer->ClearValues == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->ClearValueCount;
                var valueArray = new ClearValue[valueCount];
                var ptr = (ClearValue*)NativePointer->ClearValues;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<ClearValue>() * valueCount;
                    if(NativePointer->ClearValues != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ClearValues, (IntPtr)typeSize);
                    
                    if(NativePointer->ClearValues == IntPtr.Zero)
                        NativePointer->ClearValues = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->ClearValueCount = (UInt32)valueCount;
                    var ptr = (ClearValue*)NativePointer->ClearValues;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->ClearValues != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->ClearValues);
                    
                    NativePointer->ClearValues = IntPtr.Zero;
                    NativePointer->ClearValueCount = 0;
                }
            }
        }
        
        public RenderPassBeginInfo()
        {
            NativePointer = (Interop.RenderPassBeginInfo*)MemoryUtils.Allocate(typeof(Interop.RenderPassBeginInfo));
            NativePointer->SType = StructureType.RenderPassBeginInfo;
        }
        
        public RenderPassBeginInfo(RenderPass RenderPass, Framebuffer Framebuffer, Rect2D RenderArea, ClearValue[] ClearValues) : this()
        {
            this.RenderPass = RenderPass;
            this.Framebuffer = Framebuffer;
            this.RenderArea = RenderArea;
            this.ClearValues = ClearValues;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.RenderPassBeginInfo*)IntPtr.Zero;
        }
    }
}
