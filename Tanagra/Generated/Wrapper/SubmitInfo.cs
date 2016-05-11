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
        
        public Semaphore[] WaitSemaphores
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
        
        public PipelineStageFlags[] WaitDstStageMask
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
        
        public UInt32 CommandBufferCount
        {
            get { return NativePointer->CommandBufferCount; }
            set { NativePointer->CommandBufferCount = value; }
        }
        
        public CommandBuffer[] CommandBuffers
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
        
        public UInt32 SignalSemaphoreCount
        {
            get { return NativePointer->SignalSemaphoreCount; }
            set { NativePointer->SignalSemaphoreCount = value; }
        }
        
        public Semaphore[] SignalSemaphores
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
        
        public SubmitInfo()
        {
            NativePointer = (Interop.SubmitInfo*)Interop.Structure.Allocate(typeof(Interop.SubmitInfo));
            NativePointer->SType = StructureType.SubmitInfo;
        }
    }
}
