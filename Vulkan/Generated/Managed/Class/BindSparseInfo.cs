using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class BindSparseInfo : IDisposable
    {
        internal Unmanaged.BindSparseInfo* NativePointer { get; private set; }
        
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
                    valueArray[x] = new Semaphore(ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt64)) * valueCount;
                    if(NativePointer->WaitSemaphores != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->WaitSemaphores, (IntPtr)typeSize);
                    
                    if(NativePointer->WaitSemaphores == IntPtr.Zero)
                        NativePointer->WaitSemaphores = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->WaitSemaphoreCount = (UInt32)valueCount;
                    var ptr = (UInt64*)NativePointer->WaitSemaphores;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x].NativePointer;
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
        
        public SparseBufferMemoryBindInfo[] BufferBinds
        {
            get
            {
                if(NativePointer->BufferBinds == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->BufferBindCount;
                var valueArray = new SparseBufferMemoryBindInfo[valueCount];
                var ptr = (Unmanaged.SparseBufferMemoryBindInfo*)NativePointer->BufferBinds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseBufferMemoryBindInfo(&ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Unmanaged.SparseBufferMemoryBindInfo)) * valueCount;
                    if(NativePointer->BufferBinds != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->BufferBinds, (IntPtr)typeSize);
                    
                    if(NativePointer->BufferBinds == IntPtr.Zero)
                        NativePointer->BufferBinds = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->BufferBindCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.SparseBufferMemoryBindInfo*)NativePointer->BufferBinds;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->BufferBinds != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->BufferBinds);
                    
                    NativePointer->BufferBinds = IntPtr.Zero;
                    NativePointer->BufferBindCount = 0;
                }
            }
        }
        
        public SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds
        {
            get
            {
                if(NativePointer->ImageOpaqueBinds == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->ImageOpaqueBindCount;
                var valueArray = new SparseImageOpaqueMemoryBindInfo[valueCount];
                var ptr = (Unmanaged.SparseImageOpaqueMemoryBindInfo*)NativePointer->ImageOpaqueBinds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseImageOpaqueMemoryBindInfo(&ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Unmanaged.SparseImageOpaqueMemoryBindInfo)) * valueCount;
                    if(NativePointer->ImageOpaqueBinds != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ImageOpaqueBinds, (IntPtr)typeSize);
                    
                    if(NativePointer->ImageOpaqueBinds == IntPtr.Zero)
                        NativePointer->ImageOpaqueBinds = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->ImageOpaqueBindCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.SparseImageOpaqueMemoryBindInfo*)NativePointer->ImageOpaqueBinds;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->ImageOpaqueBinds != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->ImageOpaqueBinds);
                    
                    NativePointer->ImageOpaqueBinds = IntPtr.Zero;
                    NativePointer->ImageOpaqueBindCount = 0;
                }
            }
        }
        
        public SparseImageMemoryBindInfo[] ImageBinds
        {
            get
            {
                if(NativePointer->ImageBinds == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->ImageBindCount;
                var valueArray = new SparseImageMemoryBindInfo[valueCount];
                var ptr = (Unmanaged.SparseImageMemoryBindInfo*)NativePointer->ImageBinds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseImageMemoryBindInfo(&ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Unmanaged.SparseImageMemoryBindInfo)) * valueCount;
                    if(NativePointer->ImageBinds != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ImageBinds, (IntPtr)typeSize);
                    
                    if(NativePointer->ImageBinds == IntPtr.Zero)
                        NativePointer->ImageBinds = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->ImageBindCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.SparseImageMemoryBindInfo*)NativePointer->ImageBinds;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->ImageBinds != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->ImageBinds);
                    
                    NativePointer->ImageBinds = IntPtr.Zero;
                    NativePointer->ImageBindCount = 0;
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
                    valueArray[x] = new Semaphore(ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt64)) * valueCount;
                    if(NativePointer->SignalSemaphores != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->SignalSemaphores, (IntPtr)typeSize);
                    
                    if(NativePointer->SignalSemaphores == IntPtr.Zero)
                        NativePointer->SignalSemaphores = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->SignalSemaphoreCount = (UInt32)valueCount;
                    var ptr = (UInt64*)NativePointer->SignalSemaphores;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x].NativePointer;
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
        
        public BindSparseInfo()
        {
            NativePointer = (Unmanaged.BindSparseInfo*)MemUtil.Alloc(typeof(Unmanaged.BindSparseInfo));
            NativePointer->SType = StructureType.BindSparseInfo;
        }
        
        internal BindSparseInfo(Unmanaged.BindSparseInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.BindSparseInfo));
        }
        
        public BindSparseInfo(Semaphore[] WaitSemaphores, SparseBufferMemoryBindInfo[] BufferBinds, SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds, SparseImageMemoryBindInfo[] ImageBinds, Semaphore[] SignalSemaphores) : this()
        {
            this.WaitSemaphores = WaitSemaphores;
            this.BufferBinds = BufferBinds;
            this.ImageOpaqueBinds = ImageOpaqueBinds;
            this.ImageBinds = ImageBinds;
            this.SignalSemaphores = SignalSemaphores;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->WaitSemaphores);
            Marshal.FreeHGlobal(NativePointer->BufferBinds);
            Marshal.FreeHGlobal(NativePointer->ImageOpaqueBinds);
            Marshal.FreeHGlobal(NativePointer->ImageBinds);
            Marshal.FreeHGlobal(NativePointer->SignalSemaphores);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~BindSparseInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->WaitSemaphores);
                Marshal.FreeHGlobal(NativePointer->BufferBinds);
                Marshal.FreeHGlobal(NativePointer->ImageOpaqueBinds);
                Marshal.FreeHGlobal(NativePointer->ImageBinds);
                Marshal.FreeHGlobal(NativePointer->SignalSemaphores);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
