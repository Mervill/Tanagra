using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ShaderModuleCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public ShaderModuleCreateFlags Flags;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public IntPtr CodeSize;
        /// <summary>
        /// Binary code of size codeSize
        /// </summary>
        public IntPtr Code;
    }
}
