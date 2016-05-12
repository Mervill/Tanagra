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
                var valueCount = NativePointer->WaitSemaphoreCount;
                var valueArray = new Semaphore[valueCount];
                var ptr = (UInt64*)NativePointer->WaitSemaphores;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new Semaphore { NativePointer = ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->WaitSemaphoreCount = (uint)valueCount;
                NativePointer->WaitSemaphores = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->WaitSemaphores;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
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
                var valueCount = NativePointer->BufferBindCount;
                var valueArray = new SparseBufferMemoryBindInfo[valueCount];
                var ptr = (Interop.SparseBufferMemoryBindInfo*)NativePointer->BufferBinds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseBufferMemoryBindInfo { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->BufferBindCount = (uint)valueCount;
                NativePointer->BufferBinds = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SparseBufferMemoryBindInfo>() * valueCount);
                var ptr = (Interop.SparseBufferMemoryBindInfo*)NativePointer->BufferBinds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
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
                var valueCount = NativePointer->ImageOpaqueBindCount;
                var valueArray = new SparseImageOpaqueMemoryBindInfo[valueCount];
                var ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)NativePointer->ImageOpaqueBinds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseImageOpaqueMemoryBindInfo { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->ImageOpaqueBindCount = (uint)valueCount;
                NativePointer->ImageOpaqueBinds = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SparseImageOpaqueMemoryBindInfo>() * valueCount);
                var ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)NativePointer->ImageOpaqueBinds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
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
                var valueCount = NativePointer->ImageBindCount;
                var valueArray = new SparseImageMemoryBindInfo[valueCount];
                var ptr = (Interop.SparseImageMemoryBindInfo*)NativePointer->ImageBinds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseImageMemoryBindInfo { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->ImageBindCount = (uint)valueCount;
                NativePointer->ImageBinds = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SparseImageMemoryBindInfo>() * valueCount);
                var ptr = (Interop.SparseImageMemoryBindInfo*)NativePointer->ImageBinds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
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
                var valueCount = NativePointer->SignalSemaphoreCount;
                var valueArray = new Semaphore[valueCount];
                var ptr = (UInt64*)NativePointer->SignalSemaphores;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new Semaphore { NativePointer = ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->SignalSemaphoreCount = (uint)valueCount;
                NativePointer->SignalSemaphores = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->SignalSemaphores;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
        }
        
        public BindSparseInfo()
        {
            NativePointer = (Interop.BindSparseInfo*)Interop.Structure.Allocate(typeof(Interop.BindSparseInfo));
            NativePointer->SType = StructureType.BindSparseInfo;
        }
    }
}
