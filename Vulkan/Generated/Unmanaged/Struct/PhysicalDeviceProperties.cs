using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDeviceProperties
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct PipelineCacheUUIDInfo
        {
            public const UInt32 Length = 16;
            
            public Byte Value00;
            public Byte Value01;
            public Byte Value02;
            public Byte Value03;
            public Byte Value04;
            public Byte Value05;
            public Byte Value06;
            public Byte Value07;
            public Byte Value08;
            public Byte Value09;
            public Byte Value10;
            public Byte Value11;
            public Byte Value12;
            public Byte Value13;
            public Byte Value14;
            public Byte Value15;
            
            public Byte this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value00;
                        case 1: return Value01;
                        case 2: return Value02;
                        case 3: return Value03;
                        case 4: return Value04;
                        case 5: return Value05;
                        case 6: return Value06;
                        case 7: return Value07;
                        case 8: return Value08;
                        case 9: return Value09;
                        case 10: return Value10;
                        case 11: return Value11;
                        case 12: return Value12;
                        case 13: return Value13;
                        case 14: return Value14;
                        case 15: return Value15;
                    }
                }
            }
        }
        public UInt32 ApiVersion;
        public UInt32 DriverVersion;
        public UInt32 VendorID;
        public UInt32 DeviceID;
        public PhysicalDeviceType DeviceType;
        public unsafe fixed Byte DeviceName[256];
        public PipelineCacheUUIDInfo PipelineCacheUUID;
        public PhysicalDeviceLimits Limits;
        public PhysicalDeviceSparseProperties SparseProperties;
    }
}
