using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Boolean explicitly backed by <see cref="UInt32"/>
    /// </summary>
    public struct Bool32
    {
        UInt32 value;

        public Bool32(bool boolValue)
        {
            value = boolValue ? 1U : 0U;
        }

        public static implicit operator Bool32(bool boolValue)
            => new Bool32(boolValue);

        public static implicit operator bool(Bool32 bool32)
            => bool32.value == 0 ? false : true;

        public override string ToString()
            => value == 0 ? "False" : "True";
    }

    public struct DeviceSize
    {
        UInt64 value;

        public static implicit operator DeviceSize(UInt64 iValue)
            => new DeviceSize { value = iValue };

        public static implicit operator UInt64(DeviceSize size)
            => size.value;

        public override string ToString()
            => value.ToString();

        public string ToString(string format)
            => value.ToString(format);
    }

    public static class DebugUtils
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public unsafe delegate Bool32 DebugReportCallbackDelegate(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, ulong @object, IntPtr location, int messageCode, string layerPrefix, string message, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal unsafe delegate Result CreateDebugReportCallbackEXT_Delegate(IntPtr instance, Interop.DebugReportCallbackCreateInfoEXT* createInfo, Interop.AllocationCallbacks* allocator, UInt64* callback);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal unsafe delegate Result DestroyDebugReportCallbackDelegate(Instance instance, UInt64* debugReportCallback, Interop.AllocationCallbacks* allocator);

        public static unsafe DebugReportCallbackEXT CreateDebugReportCallback(Instance instance, DebugReportCallbackDelegate callback)
        {
            var name = "vkCreateDebugReportCallbackEXT";
            var nameBytes = Encoding.ASCII.GetBytes(name);
            fixed(byte* namePointer = &nameBytes[0])
            {
                var procAddr = VK.GetInstanceProcAddr(instance, namePointer);
                if(procAddr == IntPtr.Zero)
                    throw new NullReferenceException($"Didn't find InstanceProcAddr {nameBytes}");

                var createDelegate = Marshal.GetDelegateForFunctionPointer<CreateDebugReportCallbackEXT_Delegate>(procAddr);
                var createInfo = new DebugReportCallbackCreateInfoEXT
                {
                    Flags       = DebugReportFlagsEXT.DebugReportErrorBitExt | DebugReportFlagsEXT.DebugReportWarningBitExt | DebugReportFlagsEXT.DebugReportPerformanceWarningBitExt,
                    PfnCallback = Marshal.GetFunctionPointerForDelegate(callback),
                };

                var debugReportCallbackEXT = new DebugReportCallbackEXT();
                fixed(UInt64* ptr = &debugReportCallbackEXT.NativePointer)
                {
                    var result = createDelegate(instance.NativePointer, createInfo.NativePointer, null, ptr);
                    if(result != Result.Success)
                        throw new VulkanCommandException("vkCreateDebugReportCallbackEXT", result);
                }
                return debugReportCallbackEXT;
            }

        }
    }

}
