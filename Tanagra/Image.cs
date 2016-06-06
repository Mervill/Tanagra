using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.Managed;

namespace Tanagra
{
    public class Image
    {
        public Vulkan.Image Handle { get; private set; }
        ImageCreateInfo CreateInfo;

        public ImageCreateFlags Flags              => CreateInfo.Flags;
        public ImageType        ImageType          => CreateInfo.ImageType;
        public Format           Format             => CreateInfo.Format;
        public Extent3D         Extent             => CreateInfo.Extent;
        public UInt32           MipLevels          => CreateInfo.MipLevels;
        public UInt32           ArrayLayers        => CreateInfo.ArrayLayers;
        public SampleCountFlags Samples            => CreateInfo.Samples;
        public ImageTiling      Tiling             => CreateInfo.Tiling;
        public ImageUsageFlags  Usage              => CreateInfo.Usage;
        public SharingMode      SharingMode        => CreateInfo.SharingMode;
        public UInt32[]         QueueFamilyIndices => CreateInfo.QueueFamilyIndices;
        public ImageLayout      InitialLayout      => CreateInfo.InitialLayout;

        //public ImageLayout Layout { get; internal set; }
        //public AccessFlags AccessFlags { get; internal set; }

        public Image(Vulkan.Image handle, ImageCreateInfo createInfo)
        {
            Handle = handle;
            CreateInfo = createInfo;
        }

        public ImageSubresourceRange SubresourceRange(ImageAspectFlags aspect, uint baseMipLevel, uint baseArrayLayer)
            => new ImageSubresourceRange(aspect, baseMipLevel, MipLevels, baseArrayLayer, ArrayLayers);

        public static Image Create(Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator = null)
            => new Image(Vk.CreateImage(device, createInfo, allocator), createInfo);

    }
}
