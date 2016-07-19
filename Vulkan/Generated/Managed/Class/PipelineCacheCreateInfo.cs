using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// IExtensible
    /// </summary>
    unsafe public class PipelineCacheCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineCacheCreateInfo* NativePointer { get; private set; }
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineCacheCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Initial data to populate cache
        /// </summary>
        public Byte[] InitialData
        {
            get
            {
                if(NativePointer->InitialData == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->InitialDataSize;
                var valueArray = new Byte[valueCount];
                var ptr = (Byte*)NativePointer->InitialData;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Byte)) * valueCount;
                    if(NativePointer->InitialData != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->InitialData, (IntPtr)typeSize);
                    
                    if(NativePointer->InitialData == IntPtr.Zero)
                        NativePointer->InitialData = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->InitialDataSize = (UInt32)valueCount;
                    var ptr = (Byte*)NativePointer->InitialData;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->InitialData != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->InitialData);
                    
                    NativePointer->InitialData = IntPtr.Zero;
                    NativePointer->InitialDataSize = 0;
                }
            }
        }
        
        public PipelineCacheCreateInfo()
        {
            NativePointer = (Unmanaged.PipelineCacheCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.PipelineCacheCreateInfo));
            NativePointer->SType = StructureType.PipelineCacheCreateInfo;
        }
        
        internal PipelineCacheCreateInfo(Unmanaged.PipelineCacheCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.PipelineCacheCreateInfo));
        }
        
        /// <param name="InitialData">Initial data to populate cache</param>
        public PipelineCacheCreateInfo(Byte[] InitialData) : this()
        {
            this.InitialData = InitialData;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->InitialData);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineCacheCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->InitialData);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
