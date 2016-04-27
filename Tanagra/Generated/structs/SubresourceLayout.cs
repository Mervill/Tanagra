using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubresourceLayout
    {
        internal Interop.SubresourceLayout* NativeHandle;
        
        DeviceSize _Offset;
        public DeviceSize Offset
        {
            get { return _Offset; }
            set { _Offset = value; NativeHandle->Offset = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _Size;
        public DeviceSize Size
        {
            get { return _Size; }
            set { _Size = value; NativeHandle->Size = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _RowPitch;
        public DeviceSize RowPitch
        {
            get { return _RowPitch; }
            set { _RowPitch = value; NativeHandle->RowPitch = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _ArrayPitch;
        public DeviceSize ArrayPitch
        {
            get { return _ArrayPitch; }
            set { _ArrayPitch = value; NativeHandle->ArrayPitch = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _DepthPitch;
        public DeviceSize DepthPitch
        {
            get { return _DepthPitch; }
            set { _DepthPitch = value; NativeHandle->DepthPitch = (IntPtr)value.NativeHandle; }
        }
        
        public SubresourceLayout()
        {
            NativeHandle = (Interop.SubresourceLayout*)Interop.Structure.Allocate(typeof(Interop.SubresourceLayout));
        }
    }
}
