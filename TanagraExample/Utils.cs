using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

namespace TanagraExample
{
    public static class Utils
    {
        public static void setImageLayout(CommandBuffer cmdBuffer, Image image, ImageAspectFlags aspectMask, ImageLayout oldLayout, ImageLayout newLayout)
        {
            var subresourceRange = new ImageSubresourceRange(aspectMask, 0, 1, 0, 1);
            setImageLayout(cmdBuffer, image, aspectMask, oldLayout, newLayout, subresourceRange);
        }

        public static void setImageLayout(CommandBuffer cmdBuffer, Image image, ImageAspectFlags aspectMask, ImageLayout oldLayout, ImageLayout newLayout, ImageSubresourceRange subRange)
        {
            var imageMemoryBarrier = new ImageMemoryBarrier(oldLayout, newLayout, 0, 0, image, subRange);

            if(oldLayout == ImageLayout.Preinitialized)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.HostWrite | AccessFlags.TransferWrite;

            if(oldLayout == ImageLayout.ColorAttachmentOptimal)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.ColorAttachmentWrite;

            if(oldLayout == ImageLayout.DepthStencilAttachmentOptimal)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.DepthStencilAttachmentWrite;

            if(oldLayout == ImageLayout.TransferSrcOptimal)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.TransferRead;

            if(oldLayout == ImageLayout.ShaderReadOnlyOptimal)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.ShaderRead;

            if(newLayout == ImageLayout.TransferDstOptimal)
                imageMemoryBarrier.DstAccessMask = AccessFlags.TransferWrite;

            if(newLayout == ImageLayout.TransferSrcOptimal)
            {
                imageMemoryBarrier.SrcAccessMask |= AccessFlags.TransferRead;
                imageMemoryBarrier.DstAccessMask = AccessFlags.TransferRead;
            }

            if(newLayout == ImageLayout.DepthStencilAttachmentOptimal)
                imageMemoryBarrier.DstAccessMask |= AccessFlags.DepthStencilAttachmentWrite;

            if(newLayout == ImageLayout.ShaderReadOnlyOptimal)
            {
                imageMemoryBarrier.SrcAccessMask = AccessFlags.HostWrite | AccessFlags.TransferWrite;
                imageMemoryBarrier.DstAccessMask = AccessFlags.ShaderRead;
            }

            var srcStageFlags = PipelineStageFlags.TopOfPipe;
            var destStageFlags = PipelineStageFlags.TopOfPipe;

            var imageMemoryBarriers = new List<ImageMemoryBarrier> { imageMemoryBarrier };
            cmdBuffer.CmdPipelineBarrier(srcStageFlags, destStageFlags, DependencyFlags.None, null, null, imageMemoryBarriers);
        }

        public static Format getSupportedDepthFormat(PhysicalDevice physicalDevice)
        {
            var formats = new[]
            {
                Format.D32SfloatS8Uint,
                Format.D32Sfloat,
                Format.D24UnormS8Uint,
                Format.D16UnormS8Uint,
                Format.D16Unorm,
            };

            foreach(var fmt in formats)
            {
                var formatProps = physicalDevice.GetFormatProperties(fmt);
                if((formatProps.OptimalTilingFeatures & FormatFeatureFlags.DepthStencilAttachment) != 0)
                {
                    return fmt;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
