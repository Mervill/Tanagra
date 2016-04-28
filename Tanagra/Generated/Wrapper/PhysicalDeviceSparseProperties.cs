using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceSparseProperties
    {
        internal Interop.PhysicalDeviceSparseProperties* NativePointer;
        
        public Boolean ResidencyStandard2DBlockShape
        {
            get { return NativePointer->ResidencyStandard2DBlockShape; }
            set { NativePointer->ResidencyStandard2DBlockShape = value; }
        }
        
        public Boolean ResidencyStandard2DMultisampleBlockShape
        {
            get { return NativePointer->ResidencyStandard2DMultisampleBlockShape; }
            set { NativePointer->ResidencyStandard2DMultisampleBlockShape = value; }
        }
        
        public Boolean ResidencyStandard3DBlockShape
        {
            get { return NativePointer->ResidencyStandard3DBlockShape; }
            set { NativePointer->ResidencyStandard3DBlockShape = value; }
        }
        
        public Boolean ResidencyAlignedMipSize
        {
            get { return NativePointer->ResidencyAlignedMipSize; }
            set { NativePointer->ResidencyAlignedMipSize = value; }
        }
        
        public Boolean ResidencyNonResidentStrict
        {
            get { return NativePointer->ResidencyNonResidentStrict; }
            set { NativePointer->ResidencyNonResidentStrict = value; }
        }
        
        public PhysicalDeviceSparseProperties()
        {
            NativePointer = (Interop.PhysicalDeviceSparseProperties*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceSparseProperties));
        }
    }
}
