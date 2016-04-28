using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SpecializationInfo
    {
        internal Interop.SpecializationInfo* NativePointer;
        
        public UInt32 MapEntryCount
        {
            get { return NativePointer->MapEntryCount; }
            set { NativePointer->MapEntryCount = value; }
        }
        
        SpecializationMapEntry _MapEntries;
        public SpecializationMapEntry MapEntries
        {
            get { return _MapEntries; }
            set { _MapEntries = value; NativePointer->MapEntries = (IntPtr)value.NativePointer; }
        }
        
        public UIntPtr DataSize
        {
            get { return NativePointer->DataSize; }
            set { NativePointer->DataSize = value; }
        }
        
        public IntPtr Data
        {
            get { return NativePointer->Data; }
            set { NativePointer->Data = value; }
        }
        
        public SpecializationInfo()
        {
            NativePointer = (Interop.SpecializationInfo*)Interop.Structure.Allocate(typeof(Interop.SpecializationInfo));
        }
    }
}
