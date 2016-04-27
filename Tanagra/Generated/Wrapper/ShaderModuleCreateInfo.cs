using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ShaderModuleCreateInfo
    {
        internal Interop.ShaderModuleCreateInfo* NativeHandle;
        
        public ShaderModuleCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UIntPtr CodeSize
        {
            get { return NativeHandle->CodeSize; }
            set { NativeHandle->CodeSize = value; }
        }
        
        public UInt32 Code
        {
            get { return NativeHandle->Code; }
            set { NativeHandle->Code = value; }
        }
        
        public ShaderModuleCreateInfo()
        {
            NativeHandle = (Interop.ShaderModuleCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ShaderModuleCreateInfo));
            //NativeHandle->SType = StructureType.ShaderModuleCreateInfo;
        }
    }
}
