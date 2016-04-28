using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceProperties
    {
        internal Interop.PhysicalDeviceProperties* NativePointer;
        
        public UInt32 ApiVersion
        {
            get { return NativePointer->ApiVersion; }
            set { NativePointer->ApiVersion = value; }
        }
        
        public UInt32 DriverVersion
        {
            get { return NativePointer->DriverVersion; }
            set { NativePointer->DriverVersion = value; }
        }
        
        public UInt32 VendorID
        {
            get { return NativePointer->VendorID; }
            set { NativePointer->VendorID = value; }
        }
        
        public UInt32 DeviceID
        {
            get { return NativePointer->DeviceID; }
            set { NativePointer->DeviceID = value; }
        }
        
        public PhysicalDeviceType DeviceType
        {
            get { return NativePointer->DeviceType; }
            set { NativePointer->DeviceType = value; }
        }
        
        public string DeviceName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->DeviceName); }
            set { NativePointer->DeviceName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public Byte PipelineCacheUUID
        {
            get { return NativePointer->PipelineCacheUUID; }
            set { NativePointer->PipelineCacheUUID = value; }
        }
        
        PhysicalDeviceLimits _Limits;
        public PhysicalDeviceLimits Limits
        {
            get { return _Limits; }
            set { _Limits = value; NativePointer->Limits = (IntPtr)value.NativePointer; }
        }
        
        PhysicalDeviceSparseProperties _SparseProperties;
        public PhysicalDeviceSparseProperties SparseProperties
        {
            get { return _SparseProperties; }
            set { _SparseProperties = value; NativePointer->SparseProperties = (IntPtr)value.NativePointer; }
        }
        
        public PhysicalDeviceProperties()
        {
            NativePointer = (Interop.PhysicalDeviceProperties*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceProperties));
        }
    }
}
