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
        
        public SpecializationMapEntry[] MapEntries
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public UIntPtr DataSize
        {
            get { return NativePointer->DataSize; }
            set { NativePointer->DataSize = value; }
        }
        
        public IntPtr[] Data
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public SpecializationInfo()
        {
            NativePointer = (Interop.SpecializationInfo*)Interop.Structure.Allocate(typeof(Interop.SpecializationInfo));
        }
    }
}
