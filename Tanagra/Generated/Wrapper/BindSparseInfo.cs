using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BindSparseInfo
    {
        internal Interop.BindSparseInfo* NativeHandle;
        
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
        
        public UInt32 BufferBindCount
        {
            get { return NativeHandle->BufferBindCount; }
            set { NativeHandle->BufferBindCount = value; }
        }
        
        SparseBufferMemoryBindInfo _BufferBinds;
        public SparseBufferMemoryBindInfo BufferBinds
        {
            get { return _BufferBinds; }
            set { _BufferBinds = value; NativeHandle->BufferBinds = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 ImageOpaqueBindCount
        {
            get { return NativeHandle->ImageOpaqueBindCount; }
            set { NativeHandle->ImageOpaqueBindCount = value; }
        }
        
        SparseImageOpaqueMemoryBindInfo _ImageOpaqueBinds;
        public SparseImageOpaqueMemoryBindInfo ImageOpaqueBinds
        {
            get { return _ImageOpaqueBinds; }
            set { _ImageOpaqueBinds = value; NativeHandle->ImageOpaqueBinds = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 ImageBindCount
        {
            get { return NativeHandle->ImageBindCount; }
            set { NativeHandle->ImageBindCount = value; }
        }
        
        SparseImageMemoryBindInfo _ImageBinds;
        public SparseImageMemoryBindInfo ImageBinds
        {
            get { return _ImageBinds; }
            set { _ImageBinds = value; NativeHandle->ImageBinds = (IntPtr)value.NativeHandle; }
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
        
        public BindSparseInfo()
        {
            NativeHandle = (Interop.BindSparseInfo*)Interop.Structure.Allocate(typeof(Interop.BindSparseInfo));
            //NativeHandle->SType = StructureType.BindSparseInfo;
        }
    }
}
