using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubmitInfo
    {
        internal Interop.SubmitInfo* NativePointer;
        
        public UInt32 WaitSemaphoreCount
        {
            get { return NativePointer->WaitSemaphoreCount; }
            set { NativePointer->WaitSemaphoreCount = value; }
        }
        
        Semaphore _WaitSemaphores;
        public Semaphore WaitSemaphores
        {
            get { return _WaitSemaphores; }
            set { _WaitSemaphores = value; NativePointer->WaitSemaphores = (IntPtr)value.NativePointer; }
        }
        
        public PipelineStageFlags WaitDstStageMask
        {
            get { return NativePointer->WaitDstStageMask; }
            set { NativePointer->WaitDstStageMask = value; }
        }
        
        public UInt32 CommandBufferCount
        {
            get { return NativePointer->CommandBufferCount; }
            set { NativePointer->CommandBufferCount = value; }
        }
        
        CommandBuffer _CommandBuffers;
        public CommandBuffer CommandBuffers
        {
            get { return _CommandBuffers; }
            set { _CommandBuffers = value; NativePointer->CommandBuffers = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 SignalSemaphoreCount
        {
            get { return NativePointer->SignalSemaphoreCount; }
            set { NativePointer->SignalSemaphoreCount = value; }
        }
        
        Semaphore _SignalSemaphores;
        public Semaphore SignalSemaphores
        {
            get { return _SignalSemaphores; }
            set { _SignalSemaphores = value; NativePointer->SignalSemaphores = (IntPtr)value.NativePointer; }
        }
        
        public SubmitInfo()
        {
            NativePointer = (Interop.SubmitInfo*)Interop.Structure.Allocate(typeof(Interop.SubmitInfo));
            NativePointer->SType = StructureType.SubmitInfo;
        }
    }
}
