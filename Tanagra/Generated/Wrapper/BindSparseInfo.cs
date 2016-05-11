using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BindSparseInfo
    {
        internal Interop.BindSparseInfo* NativePointer;
        
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
        
        public UInt32 BufferBindCount
        {
            get { return NativePointer->BufferBindCount; }
            set { NativePointer->BufferBindCount = value; }
        }
        
        public SparseBufferMemoryBindInfo[] BufferBinds
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
        
        public UInt32 ImageOpaqueBindCount
        {
            get { return NativePointer->ImageOpaqueBindCount; }
            set { NativePointer->ImageOpaqueBindCount = value; }
        }
        
        public SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds
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
        
        public UInt32 ImageBindCount
        {
            get { return NativePointer->ImageBindCount; }
            set { NativePointer->ImageBindCount = value; }
        }
        
        public SparseImageMemoryBindInfo[] ImageBinds
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
        
        public BindSparseInfo()
        {
            NativePointer = (Interop.BindSparseInfo*)Interop.Structure.Allocate(typeof(Interop.BindSparseInfo));
            NativePointer->SType = StructureType.BindSparseInfo;
        }
    }
}
