using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.Managed;

namespace Tanagra
{
    public static class FormatExtensions
    {
        public static string Format(this Extent3D extent3D)
            => $"({extent3D.Width}, {extent3D.Height}, {extent3D.Depth})";

        public static string Format(this QueueFamilyProperties queueFamilyProperties)
        {
            var sb = new StringBuilder();

            string flags = string.Empty;
            flags += queueFamilyProperties.QueueFlags.HasFlag(QueueFlags.Graphics) ? "G" : ".";
            flags += queueFamilyProperties.QueueFlags.HasFlag(QueueFlags.Compute) ? "C" : ".";
            flags += queueFamilyProperties.QueueFlags.HasFlag(QueueFlags.Transfer) ? "D" : ".";

            sb.AppendLine($"QueueFlags         = {flags}");
            sb.AppendLine($"QueueCount         = {queueFamilyProperties.QueueCount}");
            sb.AppendLine($"TimestampValidBits = {queueFamilyProperties.TimestampValidBits}");
            sb.AppendLine($"MinImageTransferGranularity = {queueFamilyProperties.MinImageTransferGranularity.Format()}");

            return sb.ToString();
        }
    }
}
