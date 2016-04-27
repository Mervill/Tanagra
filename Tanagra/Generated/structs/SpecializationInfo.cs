using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SpecializationInfo
    {
        internal Interop.SpecializationInfo* NativeHandle;
        
        public UInt32 MapEntryCount
        {
            get { return NativeHandle->MapEntryCount; }
            set { NativeHandle->MapEntryCount = value; }
        }
        
        SpecializationMapEntry _MapEntries;
        public SpecializationMapEntry MapEntries
        {
            get { return _MapEntries; }
            set { _MapEntries = value; NativeHandle->MapEntries = (IntPtr)value.NativeHandle; }
        }
        
        public UIntPtr DataSize
        {
            get { return NativeHandle->DataSize; }
            set { NativeHandle->DataSize = value; }
        }
        
        public IntPtr Data
        {
            get { return NativeHandle->Data; }
            set { NativeHandle->Data = value; }
        }
        
        public SpecializationInfo()
        {
            NativeHandle = (Interop.SpecializationInfo*)Interop.Structure.Allocate(typeof(Interop.SpecializationInfo));
        }
    }
}
