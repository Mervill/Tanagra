using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ShaderModuleCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public ShaderModuleCreateFlags flags;
        public UIntPtr codeSize;
        public UInt32[] Code; // len:codeSize/4
    }
}
