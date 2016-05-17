using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubmitInfo
    {
        internal Interop.SubmitInfo* NativePointer;
        
        public Semaphore[] WaitSemaphores
        {
            get
            {
                if(NativePointer->WaitSemaphores == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->WaitSemaphoreCount;
                var valueArray = new Semaphore[valueCount];
                var ptr = (UInt64*)NativePointer->WaitSemaphores;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new Semaphore { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->WaitSemaphores != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->WaitSemaphores, (IntPtr)typeSize);
                    
                    if(NativePointer->WaitSemaphores == IntPtr.Zero)
                        NativePointer->WaitSemaphores = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->WaitSemaphoreCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->WaitSemaphores;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->WaitSemaphores != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->WaitSemaphores);
                    
                    NativePointer->WaitSemaphores = IntPtr.Zero;
                    NativePointer->WaitSemaphoreCount = 0;
                }
            }
        }
        
        public PipelineStageFlags[] WaitDstStageMask
        {
            get
            {
                if(NativePointer->WaitDstStageMask == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->WaitSemaphoreCount;
                var valueArray = new PipelineStageFlags[valueCount];
                var ptr = (UInt32*)NativePointer->WaitDstStageMask;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = (PipelineStageFlags)ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<UInt32>() * valueCount;
                    if(NativePointer->WaitDstStageMask != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->WaitDstStageMask, (IntPtr)typeSize);
                    
                    if(NativePointer->WaitDstStageMask == IntPtr.Zero)
                        NativePointer->WaitDstStageMask = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->WaitSemaphoreCount = (UInt32)valueCount;
                    var ptr = (UInt32*)NativePointer->WaitDstStageMask;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (UInt32)value[x];
                }
                else
                {
                    if(NativePointer->WaitDstStageMask != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->WaitDstStageMask);
                    
                    NativePointer->WaitDstStageMask = IntPtr.Zero;
                    NativePointer->WaitSemaphoreCount = 0;
                }
            }
        }
        
        public CommandBuffer[] CommandBuffers
        {
            get
            {
                if(NativePointer->CommandBuffers == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->CommandBufferCount;
                var valueArray = new CommandBuffer[valueCount];
                var ptr = (IntPtr*)NativePointer->CommandBuffers;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new CommandBuffer { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->CommandBuffers != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->CommandBuffers, (IntPtr)typeSize);
                    
                    if(NativePointer->CommandBuffers == IntPtr.Zero)
                        NativePointer->CommandBuffers = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->CommandBufferCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->CommandBuffers;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->CommandBuffers != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->CommandBuffers);
                    
                    NativePointer->CommandBuffers = IntPtr.Zero;
                    NativePointer->CommandBufferCount = 0;
                }
            }
        }
        
        public Semaphore[] SignalSemaphores
        {
            get
            {
                if(NativePointer->SignalSemaphores == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->SignalSemaphoreCount;
                var valueArray = new Semaphore[valueCount];
                var ptr = (UInt64*)NativePointer->SignalSemaphores;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new Semaphore { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->SignalSemaphores != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->SignalSemaphores, (IntPtr)typeSize);
                    
                    if(NativePointer->SignalSemaphores == IntPtr.Zero)
                        NativePointer->SignalSemaphores = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->SignalSemaphoreCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->SignalSemaphores;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->SignalSemaphores != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->SignalSemaphores);
                    
                    NativePointer->SignalSemaphores = IntPtr.Zero;
                    NativePointer->SignalSemaphoreCount = 0;
                }
            }
        }
        
        public SubmitInfo()
        {
            NativePointer = (Interop.SubmitInfo*)MemoryUtils.Allocate(typeof(Interop.SubmitInfo));
            NativePointer->SType = StructureType.SubmitInfo;
        }
        
        public SubmitInfo(Semaphore[] WaitSemaphores, PipelineStageFlags[] WaitDstStageMask, CommandBuffer[] CommandBuffers, Semaphore[] SignalSemaphores) : this()
        {
            this.WaitSemaphores = WaitSemaphores;
            this.WaitDstStageMask = WaitDstStageMask;
            this.CommandBuffers = CommandBuffers;
            this.SignalSemaphores = SignalSemaphores;
        }
    }
}
