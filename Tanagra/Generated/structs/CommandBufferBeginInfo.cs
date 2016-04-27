using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CommandBufferBeginInfo
    {
        internal Interop.CommandBufferBeginInfo* NativeHandle;
        
        public CommandBufferUsageFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        CommandBufferInheritanceInfo _InheritanceInfo;
        public CommandBufferInheritanceInfo InheritanceInfo
        {
            get { return _InheritanceInfo; }
            set { _InheritanceInfo = value; NativeHandle->InheritanceInfo = (IntPtr)value.NativeHandle; }
        }
        
        public CommandBufferBeginInfo()
        {
            NativeHandle = (Interop.CommandBufferBeginInfo*)Interop.Structure.Allocate(typeof(Interop.CommandBufferBeginInfo));
            //NativeHandle->SType = StructureType.CommandBufferBeginInfo;
        }
    }
}
