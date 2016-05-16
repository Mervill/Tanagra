using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineCacheCreateInfo
    {
        internal Interop.PipelineCacheCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved
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
                var valueCount = NativePointer->InitialDataSize;
                var valueArray = new IntPtr[valueCount];
                var ptr = (IntPtr*)NativePointer->InitialData;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->InitialDataSize = (UInt32)valueCount;
                NativePointer->InitialData = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->InitialData;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public PipelineCacheCreateInfo()
        {
            NativePointer = (Interop.PipelineCacheCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineCacheCreateInfo));
            NativePointer->SType = StructureType.PipelineCacheCreateInfo;
        }
        
        public PipelineCacheCreateInfo(IntPtr[] InitialData) : this()
        {
            this.InitialData = InitialData;
        }
    }
}
