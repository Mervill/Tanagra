using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class PhysicalDeviceProperties : IDisposable
    {
        internal Unmanaged.PhysicalDeviceProperties* NativePointer;
        
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
        
        public String DeviceName
        {
            get { return Marshal.PtrToStringAnsi((IntPtr)NativePointer->DeviceName); }
        }
        
        public Unmanaged.PhysicalDeviceProperties.PipelineCacheUUIDInfo PipelineCacheUUID
        {
            get { return NativePointer->PipelineCacheUUID; }
        }
        
        public PhysicalDeviceLimits Limits
        {
            get { return NativePointer->Limits; }
        }
        
        public PhysicalDeviceSparseProperties SparseProperties
        {
            get { return NativePointer->SparseProperties; }
        }
        
        internal PhysicalDeviceProperties()
        {
            NativePointer = (Unmanaged.PhysicalDeviceProperties*)MemoryUtils.Allocate(typeof(Unmanaged.PhysicalDeviceProperties));
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PhysicalDeviceProperties()
        {
            if(NativePointer != null)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
