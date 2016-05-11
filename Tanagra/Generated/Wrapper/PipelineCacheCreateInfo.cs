using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineCacheCreateInfo
    {
        internal Interop.PipelineCacheCreateInfo* NativePointer;
        
        public PipelineCacheCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 InitialDataSize
        {
            get { return NativePointer->InitialDataSize; }
            set { NativePointer->InitialDataSize = value; }
        }
        
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
                NativePointer->InitialDataSize = (uint)valueCount;
                NativePointer->InitialData = Marshal.AllocHGlobal((int)(Marshal.SizeOf<IntPtr>() * valueCount));
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
    }
}
