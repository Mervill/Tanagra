using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferBeginInfo
    {
        internal Interop.CommandBufferBeginInfo* NativePointer;
        
        public CommandBufferUsageFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        CommandBufferInheritanceInfo _InheritanceInfo;
        public CommandBufferInheritanceInfo InheritanceInfo
        {
            get { return _InheritanceInfo; }
            set { _InheritanceInfo = value; NativePointer->InheritanceInfo = (IntPtr)value.NativePointer; }
        }
        
        public CommandBufferBeginInfo()
        {
            NativePointer = (Interop.CommandBufferBeginInfo*)Interop.Structure.Allocate(typeof(Interop.CommandBufferBeginInfo));
            NativePointer->SType = StructureType.CommandBufferBeginInfo;
        }
    }
}
