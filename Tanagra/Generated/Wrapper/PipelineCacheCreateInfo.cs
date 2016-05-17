using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineCacheCreateInfo
    {
        internal Interop.PipelineCacheCreateInfo* NativePointer;
        
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
        public IntPtr[] InitialData
        {
            get
            {
                if(NativePointer->InitialData == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->InitialDataSize;
                var valueArray = new IntPtr[valueCount];
                var ptr = (IntPtr*)NativePointer->InitialData;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->InitialData != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->InitialData, (IntPtr)typeSize);
                    
                    if(NativePointer->InitialData == IntPtr.Zero)
                        NativePointer->InitialData = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->InitialDataSize = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->InitialData;
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
            NativePointer = (Interop.PipelineCacheCreateInfo*)MemoryUtils.Allocate(typeof(Interop.PipelineCacheCreateInfo));
            NativePointer->SType = StructureType.PipelineCacheCreateInfo;
        }
        
        public PipelineCacheCreateInfo(IntPtr[] InitialData) : this()
        {
            this.InitialData = InitialData;
        }
    }
}
