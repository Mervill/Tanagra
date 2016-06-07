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
        public Device Parent { get; private set; }
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

        public uint Width  => Extent.Width;
        public uint Height => Extent.Height;
        public uint Depth  => Extent.Depth;

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

    public class SwapchainKHR
    {
        Device Device;
        public Vulkan.SwapchainKHR Handle { get; private set; }
        SwapchainCreateInfoKHR CreateInfo;

        public void InitializeImages(Queue queue, CommandPool cmdPool)
        {
            List<Image> imageList = new List<Image>();
            var images = Vk.GetSwapchainImagesKHR(Device, Handle);
            foreach(var img in images)
            {
                var extent = new Extent3D(CreateInfo.ImageExtent.Width, CreateInfo.ImageExtent.Height, 1);
                var imgCreateInfo = new ImageCreateInfo(ImageType.ImageType2d, CreateInfo.ImageFormat, extent, CreateInfo.MinImageCount, CreateInfo.ImageArrayLayers, SampleCountFlags.None, ImageTiling.Optimal, ImageUsageFlags.None, CreateInfo.ImageSharingMode, CreateInfo.QueueFamilyIndices, ImageLayout.Undefined);
                imageList.Add(new Image(img, imgCreateInfo));
            }


        }
    }

}
