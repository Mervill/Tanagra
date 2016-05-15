using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BindSparseInfo
    {
        internal Interop.BindSparseInfo* NativePointer;
        
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
                NativePointer->WaitSemaphoreCount = (UInt32)valueCount;
                NativePointer->WaitSemaphores = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->WaitSemaphores;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
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
                NativePointer->BufferBindCount = (UInt32)valueCount;
                NativePointer->BufferBinds = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SparseBufferMemoryBindInfo>() * valueCount);
                var ptr = (Interop.SparseBufferMemoryBindInfo*)NativePointer->BufferBinds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
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
                NativePointer->ImageOpaqueBindCount = (UInt32)valueCount;
                NativePointer->ImageOpaqueBinds = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SparseImageOpaqueMemoryBindInfo>() * valueCount);
                var ptr = (Interop.SparseImageOpaqueMemoryBindInfo*)NativePointer->ImageOpaqueBinds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
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
                NativePointer->ImageBindCount = (UInt32)valueCount;
                NativePointer->ImageBinds = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SparseImageMemoryBindInfo>() * valueCount);
                var ptr = (Interop.SparseImageMemoryBindInfo*)NativePointer->ImageBinds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
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
                NativePointer->SignalSemaphoreCount = (UInt32)valueCount;
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
        
        public BindSparseInfo(Semaphore[] WaitSemaphores, SparseBufferMemoryBindInfo[] BufferBinds, SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds, SparseImageMemoryBindInfo[] ImageBinds, Semaphore[] SignalSemaphores) : this()
        {
            this.WaitSemaphores = WaitSemaphores;
            this.BufferBinds = BufferBinds;
            this.ImageOpaqueBinds = ImageOpaqueBinds;
            this.ImageBinds = ImageBinds;
            this.SignalSemaphores = SignalSemaphores;
        }
    }
}
