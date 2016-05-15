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
        
        public UInt32 CodeSize
        {
            get { return NativePointer->CodeSize; }
            set { NativePointer->CodeSize = value; }
        }
        
        public Byte[] Code
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
        
        public ShaderModuleCreateInfo()
        {
            NativePointer = (Interop.ShaderModuleCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ShaderModuleCreateInfo));
            NativePointer->SType = StructureType.ShaderModuleCreateInfo;
        }
        
        public ShaderModuleCreateInfo(UInt32 CodeSize, Byte[] Code) : this()
        {
            this.CodeSize = CodeSize;
            this.Code = Code;
        }
    }
}
