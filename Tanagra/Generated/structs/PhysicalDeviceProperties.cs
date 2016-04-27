using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceProperties
    {
        internal Interop.PhysicalDeviceProperties* NativeHandle;
        
        public UInt32 ApiVersion
        {
            get { return NativeHandle->ApiVersion; }
            set { NativeHandle->ApiVersion = value; }
        }
        
        public UInt32 DriverVersion
        {
            get { return NativeHandle->DriverVersion; }
            set { NativeHandle->DriverVersion = value; }
        }
        
        public UInt32 VendorID
        {
            get { return NativeHandle->VendorID; }
            set { NativeHandle->VendorID = value; }
        }
        
        public UInt32 DeviceID
        {
            get { return NativeHandle->DeviceID; }
            set { NativeHandle->DeviceID = value; }
        }
        
        public PhysicalDeviceType DeviceType
        {
            get { return NativeHandle->DeviceType; }
            set { NativeHandle->DeviceType = value; }
        }
        
        public string DeviceName
        {
            get { return Marshal.PtrToStringAnsi(NativeHandle->DeviceName); }
            set { NativeHandle->DeviceName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public Byte PipelineCacheUUID
        {
            get { return NativeHandle->PipelineCacheUUID; }
            set { NativeHandle->PipelineCacheUUID = value; }
        }
        
        PhysicalDeviceLimits _Limits;
        public PhysicalDeviceLimits Limits
        {
            get { return _Limits; }
            set { _Limits = value; NativeHandle->Limits = (IntPtr)value.NativeHandle; }
        }
        
        PhysicalDeviceSparseProperties _SparseProperties;
        public PhysicalDeviceSparseProperties SparseProperties
        {
            get { return _SparseProperties; }
            set { _SparseProperties = value; NativeHandle->SparseProperties = (IntPtr)value.NativeHandle; }
        }
        
        public PhysicalDeviceProperties()
        {
            NativeHandle = (Interop.PhysicalDeviceProperties*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceProperties));
        }
    }
}
