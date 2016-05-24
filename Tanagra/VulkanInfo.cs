using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

namespace Tanagra
{
    public class VulkanInfo
    {
        int _tabs;
        StringBuilder _sb;

        public VulkanInfo()
        {
            _sb = new StringBuilder();
        }

        public void Write(PhysicalDevice physicalDevice)
        {
            WriteLine("PhysicalDeviceProperties:");
            WriteLine("=========================");
            _tabs++;
            var properties = physicalDevice.GetProperties();
            PhysicalDeviceProperties(properties);

            WriteLine("PhysicalDeviceLimits:");
            WriteLine("---------------------");
            _tabs++;
            var limits = properties.Limits;
            PhysicalDeviceLimits(limits);

            _tabs--;
            WriteLine("PhysicalDeviceSparseProperties:");
            WriteLine("-------------------------------");
            _tabs++;
            var sparse = properties.SparseProperties;
            PhysicalDeviceSparseProperties(sparse);

            _tabs = 0;
            WriteLine("");
            var queueFamilyProperties = physicalDevice.GetQueueFamilyProperties();
            for (int x = 0; x < queueFamilyProperties.Count; x++)
            {
                WriteLine($"QueueFamilyProperties[{x}]:");
                WriteLine("==========================");
                _tabs++;
                QueueFamilyProperties(queueFamilyProperties[x]);
                _tabs--;
                WriteLine("");
            }

            _tabs = 0;
            WriteLine("PhysicalDeviceMemoryProperties");
            WriteLine("==============================");
            //var physicalDeviceMemoryProperties = physicalDevice.GetMemoryProperties();
            //PhysicalDeviceMemoryProperties(physicalDeviceMemoryProperties);
            WriteLine("");

            _tabs = 0;
            WriteLine("PhysicalDeviceFeatures:");
            WriteLine("=======================");
            _tabs++;
            var features = physicalDevice.GetFeatures();
            PhysicalDeviceFeatures(features);
            
            Console.WriteLine(_sb.ToString());
        }

        string Format(Extent3D extent3D)
            => $"({extent3D.Width}, {extent3D.Height}, {extent3D.Depth})";
        
        void PhysicalDeviceProperties(PhysicalDeviceProperties physicalDeviceProperties)
        {
            WriteLine($"ApiVersion     = {(Vulkan.Version)physicalDeviceProperties.ApiVersion}");
            WriteLine($"DriverVersion  = {physicalDeviceProperties.DriverVersion}");
            WriteLine($"VendorID       = {physicalDeviceProperties.VendorID.ToString("X4")}");
            WriteLine($"DeviceID       = {physicalDeviceProperties.DeviceID.ToString("X4")}");
            WriteLine($"DeviceType     = {physicalDeviceProperties.DeviceType}");
            WriteLine($"DeviceName     = {physicalDeviceProperties.DeviceName}");
            //PipelineCacheUUID
        }

        void PhysicalDeviceLimits(PhysicalDeviceLimits physicalDeviceLimits)
        {
            var type = physicalDeviceLimits.GetType();
            var members = type.GetFields();
            foreach (var member in members)
            {
                if (!member.FieldType.IsArray)
                {
                    if (member.FieldType == typeof (UInt32))
                    {
                        var integerValue = (UInt32)member.GetValue(physicalDeviceLimits);
                        if (member.Name.Length < 39 && member.Name != "MaxTessellationPatchSize")
                        {
                            WriteLine($"{member.Name,-39} = 0x{integerValue.ToString("X")}");
                        }
                        else
                        {
                            WriteLine($"{member.Name,-47} = 0x{integerValue.ToString("X")}");
                        }
                    }
                    else if (member.FieldType == typeof(Int32))
                    {
                        var integerValue = (Int32)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = 0x{integerValue.ToString("X")}");
                    }
                    else if (member.FieldType == typeof(Single))
                    {
                        var singleValue = (Single)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = {singleValue.ToString("F6")}");
                    }
                    else if (member.FieldType == typeof(DeviceSize))
                    {
                        var integerValue = (DeviceSize)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = 0x{integerValue.ToString("X")}");
                    }
                    else if (member.FieldType == typeof(PhysicalDeviceLimits.MaxComputeWorkGroupCountInfo))
                    {
                        var info = (PhysicalDeviceLimits.MaxComputeWorkGroupCountInfo)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = ({info.X}, {info.Y}, {info.Z})");
                    }
                    else if (member.FieldType == typeof(PhysicalDeviceLimits.MaxComputeWorkGroupSizeInfo))
                    {
                        var info = (PhysicalDeviceLimits.MaxComputeWorkGroupSizeInfo)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = ({info.X}, {info.Y}, {info.Z})");
                    }
                    else if (member.FieldType == typeof(PhysicalDeviceLimits.MaxViewportDimensionsInfo))
                    {
                        var info = (PhysicalDeviceLimits.MaxViewportDimensionsInfo)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = ({info.X}, {info.Y})");
                    }
                    else if (member.FieldType == typeof(PhysicalDeviceLimits.ViewportBoundsRangeInfo))
                    {
                        var info = (PhysicalDeviceLimits.ViewportBoundsRangeInfo)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = Min:{info.Min}, Max:{info.Max}");
                    }
                    else if (member.FieldType == typeof(PhysicalDeviceLimits.PointSizeRangeInfo))
                    {
                        var info = (PhysicalDeviceLimits.PointSizeRangeInfo)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = Min:{info.Min}, Max:{info.Max}");
                    }
                    else if (member.FieldType == typeof(PhysicalDeviceLimits.LineWidthRangeInfo))
                    {
                        var info = (PhysicalDeviceLimits.LineWidthRangeInfo)member.GetValue(physicalDeviceLimits);
                        WriteLine($"{member.Name,-39} = Min:{info.Min}, Max:{info.Max}");
                    }
                }
            }
        }

        void PhysicalDeviceSparseProperties(PhysicalDeviceSparseProperties physicalDeviceSparseProperties)
        {
            var type = physicalDeviceSparseProperties.GetType();
            var members = type.GetFields();

            foreach (var member in members)
                WriteLine($"{member.Name,-40} = {member.GetValue(physicalDeviceSparseProperties)}");
        }

        void QueueFamilyProperties(QueueFamilyProperties queueFamilyProperties)
        {
            string flags = string.Empty;
            flags += queueFamilyProperties.QueueFlags.HasFlag(QueueFlags.Graphics) ? "G" : ".";
            flags += queueFamilyProperties.QueueFlags.HasFlag(QueueFlags.Compute) ? "C" : ".";
            flags += queueFamilyProperties.QueueFlags.HasFlag(QueueFlags.Transfer) ? "D" : ".";
            WriteLine($"QueueFlags         = {flags}");
            WriteLine($"QueueCount         = {queueFamilyProperties.QueueCount}");
            WriteLine($"TimestampValidBits = {queueFamilyProperties.TimestampValidBits}");
            WriteLine($"MinImageTransferGranularity = {Format(queueFamilyProperties.MinImageTransferGranularity)}");
        }

        void PhysicalDeviceMemoryProperties(PhysicalDeviceMemoryProperties physicalDeviceMemoryProperties)
        {
            WriteLine($"MemoryTypeCount       = {physicalDeviceMemoryProperties.MemoryTypeCount}");
        }

        void PhysicalDeviceFeatures(PhysicalDeviceFeatures physicalDeviceFeatures)
        {
            var type = physicalDeviceFeatures.GetType();
            var members = type.GetFields();

            foreach (var member in members)
                WriteLine($"{member.Name,-39} = {member.GetValue(physicalDeviceFeatures)}");
        }

        // FormatProperties

        // ImageFormatProperties

        // LayerProperties

        // ExtensionProperties

        // SparseImageFormatProperties

        void WriteLine(string str)
        {
            _sb.AppendLine($"{new string(' ', _tabs * 4)}{str}");
        }
    }
}
