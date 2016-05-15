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
        
        public Byte[] Code
        {
            get
            {
                var valueCount = NativePointer->CodeSize;
                var valueArray = new Byte[valueCount];
                var ptr = (Byte*)NativePointer->Code;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->CodeSize = (UInt32)valueCount;
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
        
        public ShaderModuleCreateInfo(Byte[] Code) : this()
        {
            this.Code = Code;
        }
    }
}
