using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class QueueFamilyProperties
    {
        internal Interop.QueueFamilyProperties* NativePointer;
        
        public QueueFlags QueueFlags
        {
            get { return NativePointer->QueueFlags; }
            set { NativePointer->QueueFlags = value; }
        }
        
        public UInt32 QueueCount
        {
            get { return NativePointer->QueueCount; }
            set { NativePointer->QueueCount = value; }
        }
        
        public UInt32 TimestampValidBits
        {
            get { return NativePointer->TimestampValidBits; }
            set { NativePointer->TimestampValidBits = value; }
        }
        
        Extent3D _MinImageTransferGranularity;
        public Extent3D MinImageTransferGranularity
        {
            get { return _MinImageTransferGranularity; }
            set { _MinImageTransferGranularity = value; NativePointer->MinImageTransferGranularity = (IntPtr)value.NativePointer; }
        }
        
        public QueueFamilyProperties()
        {
            NativePointer = (Interop.QueueFamilyProperties*)Interop.Structure.Allocate(typeof(Interop.QueueFamilyProperties));
        }
    }
}
