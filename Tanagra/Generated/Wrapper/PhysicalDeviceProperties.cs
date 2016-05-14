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
            get { return Marshal.PtrToStringAnsi((IntPtr)NativePointer->DeviceName); }
            set { Interop.Structure.MarshalFixedSizeString(NativePointer->DeviceName, value, 256); }
        }
        
        /*public Byte PipelineCacheUUID
        {
            get { return NativePointer->PipelineCacheUUID; }
            set { NativePointer->PipelineCacheUUID = value; }
        }*/
        
        public PhysicalDeviceLimits Limits
        {
            get { return NativePointer->Limits; }
            set { NativePointer->Limits = value; }
        }
        
        public PhysicalDeviceSparseProperties SparseProperties
        {
            get { return NativePointer->SparseProperties; }
            set { NativePointer->SparseProperties = value; }
        }
        
        internal PhysicalDeviceProperties()
        {
            NativePointer = (Interop.PhysicalDeviceProperties*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceProperties));
        }
    }
}
