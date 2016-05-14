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
        
        public IntPtr CodeSize
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
            set
            {
                var valueCount = value.Length;
                NativePointer->CodeSize = new IntPtr(valueCount);
                NativePointer->Code = Marshal.AllocHGlobal(Marshal.SizeOf<Byte>() * valueCount);
                var ptr = (Byte*)NativePointer->Code;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public ShaderModuleCreateInfo()
        {
            NativePointer = (Interop.ShaderModuleCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ShaderModuleCreateInfo));
            NativePointer->SType = StructureType.ShaderModuleCreateInfo;
        }
        
        public ShaderModuleCreateInfo(IntPtr CodeSize, Byte[] Code) : this()
        {
            this.CodeSize = CodeSize;
            this.Code = Code;
        }
    }
}
