using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubmitInfo
    {
        internal Interop.SubmitInfo* NativeHandle;
        
        public UInt32 WaitSemaphoreCount
        {
            get { return NativeHandle->WaitSemaphoreCount; }
            set { NativeHandle->WaitSemaphoreCount = value; }
        }
        
        Semaphore _WaitSemaphores;
        public Semaphore WaitSemaphores
        {
            get { return _WaitSemaphores; }
            set { _WaitSemaphores = value; NativeHandle->WaitSemaphores = (IntPtr)value.NativeHandle; }
        }
        
        public PipelineStageFlags WaitDstStageMask
        {
            get { return NativeHandle->WaitDstStageMask; }
            set { NativeHandle->WaitDstStageMask = value; }
        }
        
        public UInt32 CommandBufferCount
        {
            get { return NativeHandle->CommandBufferCount; }
            set { NativeHandle->CommandBufferCount = value; }
        }
        
        CommandBuffer _CommandBuffers;
        public CommandBuffer CommandBuffers
        {
            get { return _CommandBuffers; }
            set { _CommandBuffers = value; NativeHandle->CommandBuffers = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 SignalSemaphoreCount
        {
            get { return NativeHandle->SignalSemaphoreCount; }
            set { NativeHandle->SignalSemaphoreCount = value; }
        }
        
        Semaphore _SignalSemaphores;
        public Semaphore SignalSemaphores
        {
            get { return _SignalSemaphores; }
            set { _SignalSemaphores = value; NativeHandle->SignalSemaphores = (IntPtr)value.NativeHandle; }
        }
        
        public SubmitInfo()
        {
            NativeHandle = (Interop.SubmitInfo*)Interop.Structure.Allocate(typeof(Interop.SubmitInfo));
            //NativeHandle->SType = StructureType.SubmitInfo;
        }
    }
}
