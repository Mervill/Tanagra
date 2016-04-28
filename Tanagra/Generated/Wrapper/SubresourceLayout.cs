using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubresourceLayout
    {
        internal Interop.SubresourceLayout* NativePointer;
        
        public DeviceSize Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public DeviceSize RowPitch
        {
            get { return NativePointer->RowPitch; }
            set { NativePointer->RowPitch = value; }
        }
        
        public DeviceSize ArrayPitch
        {
            get { return NativePointer->ArrayPitch; }
            set { NativePointer->ArrayPitch = value; }
        }
        
        public DeviceSize DepthPitch
        {
            get { return NativePointer->DepthPitch; }
            set { NativePointer->DepthPitch = value; }
        }
        
        public SubresourceLayout()
        {
            NativePointer = (Interop.SubresourceLayout*)Interop.Structure.Allocate(typeof(Interop.SubresourceLayout));
        }
    }
}
