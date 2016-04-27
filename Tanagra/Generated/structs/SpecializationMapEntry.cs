using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SpecializationMapEntry
    {
        internal Interop.SpecializationMapEntry* NativeHandle;
        
        public UInt32 ConstantID
        {
            get { return NativeHandle->ConstantID; }
            set { NativeHandle->ConstantID = value; }
        }
        
        public UInt32 Offset
        {
            get { return NativeHandle->Offset; }
            set { NativeHandle->Offset = value; }
        }
        
        public UIntPtr Size
        {
            get { return NativeHandle->Size; }
            set { NativeHandle->Size = value; }
        }
        
        public SpecializationMapEntry()
        {
            NativeHandle = (Interop.SpecializationMapEntry*)Interop.Structure.Allocate(typeof(Interop.SpecializationMapEntry));
        }
    }
}
