using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceSparseProperties
    {
        internal Interop.PhysicalDeviceSparseProperties* NativeHandle;
        
        public Boolean ResidencyStandard2DBlockShape
        {
            get { return NativeHandle->ResidencyStandard2DBlockShape; }
            set { NativeHandle->ResidencyStandard2DBlockShape = value; }
        }
        
        public Boolean ResidencyStandard2DMultisampleBlockShape
        {
            get { return NativeHandle->ResidencyStandard2DMultisampleBlockShape; }
            set { NativeHandle->ResidencyStandard2DMultisampleBlockShape = value; }
        }
        
        public Boolean ResidencyStandard3DBlockShape
        {
            get { return NativeHandle->ResidencyStandard3DBlockShape; }
            set { NativeHandle->ResidencyStandard3DBlockShape = value; }
        }
        
        public Boolean ResidencyAlignedMipSize
        {
            get { return NativeHandle->ResidencyAlignedMipSize; }
            set { NativeHandle->ResidencyAlignedMipSize = value; }
        }
        
        public Boolean ResidencyNonResidentStrict
        {
            get { return NativeHandle->ResidencyNonResidentStrict; }
            set { NativeHandle->ResidencyNonResidentStrict = value; }
        }
        
        public PhysicalDeviceSparseProperties()
        {
            NativeHandle = (Interop.PhysicalDeviceSparseProperties*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceSparseProperties));
        }
    }
}
