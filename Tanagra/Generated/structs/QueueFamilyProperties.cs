using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class QueueFamilyProperties
    {
        internal Interop.QueueFamilyProperties* NativeHandle;
        
        public QueueFlags QueueFlags
        {
            get { return NativeHandle->QueueFlags; }
            set { NativeHandle->QueueFlags = value; }
        }
        
        public UInt32 QueueCount
        {
            get { return NativeHandle->QueueCount; }
            set { NativeHandle->QueueCount = value; }
        }
        
        public UInt32 TimestampValidBits
        {
            get { return NativeHandle->TimestampValidBits; }
            set { NativeHandle->TimestampValidBits = value; }
        }
        
        Extent3D _MinImageTransferGranularity;
        public Extent3D MinImageTransferGranularity
        {
            get { return _MinImageTransferGranularity; }
            set { _MinImageTransferGranularity = value; NativeHandle->MinImageTransferGranularity = (IntPtr)value.NativeHandle; }
        }
        
        public QueueFamilyProperties()
        {
            NativeHandle = (Interop.QueueFamilyProperties*)Interop.Structure.Allocate(typeof(Interop.QueueFamilyProperties));
        }
    }
}
