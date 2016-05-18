using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class PhysicalDeviceProperties
    {
        internal Interop.PhysicalDeviceProperties* NativePointer;
        
        public UInt32 ApiVersion
        {
            get { return NativePointer->ApiVersion; }
        }
        
        public UInt32 DriverVersion
        {
            get { return NativePointer->DriverVersion; }
        }
        
        public UInt32 VendorID
        {
            get { return NativePointer->VendorID; }
        }
        
        public UInt32 DeviceID
        {
            get { return NativePointer->DeviceID; }
        }
        
        public PhysicalDeviceType DeviceType
        {
            get { return NativePointer->DeviceType; }
        }
        
        public string DeviceName
        {
            get { return Marshal.PtrToStringAnsi((IntPtr)NativePointer->DeviceName); }
        }
        
        public Byte[] PipelineCacheUUID
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public PhysicalDeviceLimits Limits
        {
            get { return new PhysicalDeviceLimits { NativePointer = &NativePointer->Limits }; }
        }
        
        public PhysicalDeviceSparseProperties SparseProperties
        {
            get { return NativePointer->SparseProperties; }
        }
        
        internal PhysicalDeviceProperties()
        {
            NativePointer = (Interop.PhysicalDeviceProperties*)MemoryUtils.Allocate(typeof(Interop.PhysicalDeviceProperties));
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.PhysicalDeviceProperties*)IntPtr.Zero;
        }
    }
}
