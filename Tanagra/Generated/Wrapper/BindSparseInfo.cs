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
        
        Semaphore _WaitSemaphores;
        public Semaphore WaitSemaphores
        {
            get { return _WaitSemaphores; }
            set { _WaitSemaphores = value; NativePointer->WaitSemaphores = value.NativePointer; }
        }
        
        public UInt32 BufferBindCount
        {
            get { return NativePointer->BufferBindCount; }
            set { NativePointer->BufferBindCount = value; }
        }
        
        SparseBufferMemoryBindInfo _BufferBinds;
        public SparseBufferMemoryBindInfo BufferBinds
        {
            get { return _BufferBinds; }
            set { _BufferBinds = value; NativePointer->BufferBinds = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 ImageOpaqueBindCount
        {
            get { return NativePointer->ImageOpaqueBindCount; }
            set { NativePointer->ImageOpaqueBindCount = value; }
        }
        
        SparseImageOpaqueMemoryBindInfo _ImageOpaqueBinds;
        public SparseImageOpaqueMemoryBindInfo ImageOpaqueBinds
        {
            get { return _ImageOpaqueBinds; }
            set { _ImageOpaqueBinds = value; NativePointer->ImageOpaqueBinds = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 ImageBindCount
        {
            get { return NativePointer->ImageBindCount; }
            set { NativePointer->ImageBindCount = value; }
        }
        
        SparseImageMemoryBindInfo _ImageBinds;
        public SparseImageMemoryBindInfo ImageBinds
        {
            get { return _ImageBinds; }
            set { _ImageBinds = value; NativePointer->ImageBinds = (IntPtr)value.NativePointer; }
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
            set { _SignalSemaphores = value; NativePointer->SignalSemaphores = value.NativePointer; }
        }
        
        public BindSparseInfo()
        {
            NativePointer = (Interop.BindSparseInfo*)Interop.Structure.Allocate(typeof(Interop.BindSparseInfo));
            NativePointer->SType = StructureType.BindSparseInfo;
        }
    }
}
