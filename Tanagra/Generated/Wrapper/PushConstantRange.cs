using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PushConstantRange
    {
        internal Interop.PushConstantRange* NativePointer;
        
        public ShaderStageFlags StageFlags
        {
            get { return NativePointer->StageFlags; }
            set { NativePointer->StageFlags = value; }
        }
        
        public UInt32 Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        public UInt32 Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public PushConstantRange()
        {
            NativePointer = (Interop.PushConstantRange*)Interop.Structure.Allocate(typeof(Interop.PushConstantRange));
        }
    }
}
