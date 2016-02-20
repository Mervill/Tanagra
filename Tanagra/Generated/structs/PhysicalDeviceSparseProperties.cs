using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDeviceSparseProperties
    {
        public Boolean residencyStandard2DBlockShape;
        public Boolean residencyStandard2DMultisampleBlockShape;
        public Boolean residencyStandard3DBlockShape;
        public Boolean residencyAlignedMipSize;
        public Boolean residencyNonResidentStrict;
    }
}
