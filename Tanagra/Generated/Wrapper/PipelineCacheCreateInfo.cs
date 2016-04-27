using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineCacheCreateInfo
    {
        internal Interop.PipelineCacheCreateInfo* NativeHandle;
        
        public PipelineCacheCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UIntPtr InitialDataSize
        {
            get { return NativeHandle->InitialDataSize; }
            set { NativeHandle->InitialDataSize = value; }
        }
        
        public IntPtr InitialData
        {
            get { return NativeHandle->InitialData; }
            set { NativeHandle->InitialData = value; }
        }
        
        public PipelineCacheCreateInfo()
        {
            NativeHandle = (Interop.PipelineCacheCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineCacheCreateInfo));
            //NativeHandle->SType = StructureType.PipelineCacheCreateInfo;
        }
    }
}
