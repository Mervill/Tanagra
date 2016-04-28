using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SpecializationMapEntry
    {
        internal Interop.SpecializationMapEntry* NativePointer;
        
        public UInt32 ConstantID
        {
            get { return NativePointer->ConstantID; }
            set { NativePointer->ConstantID = value; }
        }
        
        public UInt32 Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        public UIntPtr Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public SpecializationMapEntry()
        {
            NativePointer = (Interop.SpecializationMapEntry*)Interop.Structure.Allocate(typeof(Interop.SpecializationMapEntry));
        }
    }
}
