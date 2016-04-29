using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ShaderModuleCreateInfo
    {
        internal Interop.ShaderModuleCreateInfo* NativePointer;
        
        public ShaderModuleCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UIntPtr CodeSize
        {
            get { return NativePointer->CodeSize; }
            set { NativePointer->CodeSize = value; }
        }
        
        public UInt32 Code
        {
            get { return NativePointer->Code; }
            set { NativePointer->Code = value; }
        }
        
        public ShaderModuleCreateInfo()
        {
            NativePointer = (Interop.ShaderModuleCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ShaderModuleCreateInfo));
            NativePointer->SType = StructureType.ShaderModuleCreateInfo;
        }
    }
}
