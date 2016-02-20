using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ShaderModuleCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public ShaderModuleCreateFlags flags;
        public Int64 codeSize;
        public UInt32 pCode;
    }
}
