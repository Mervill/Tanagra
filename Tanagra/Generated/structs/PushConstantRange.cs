using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PushConstantRange
    {
        internal Interop.PushConstantRange* NativeHandle;
        
        public ShaderStageFlags StageFlags
        {
            get { return NativeHandle->StageFlags; }
            set { NativeHandle->StageFlags = value; }
        }
        
        public UInt32 Offset
        {
            get { return NativeHandle->Offset; }
            set { NativeHandle->Offset = value; }
        }
        
        public UInt32 Size
        {
            get { return NativeHandle->Size; }
            set { NativeHandle->Size = value; }
        }
        
        public PushConstantRange()
        {
            NativeHandle = (Interop.PushConstantRange*)Interop.Structure.Allocate(typeof(Interop.PushConstantRange));
        }
    }
}
