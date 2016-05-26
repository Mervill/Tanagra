using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Windows.Forms;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

using ImageLayout = Vulkan.ImageLayout;
using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    public class Swapchain
    {
        public class SwapchainBuffer
        {
            public Image image;
            public ImageView view;
        }

        Instance instance;
        Device device;
        PhysicalDevice physicalDevice;
        SurfaceKHR surface;

        // public

        public Format colorFormat;
        public ColorSpaceKHR colorSpace;
        public SwapchainKHR swapchain;
        public List<Image> images;
        public List<SwapchainBuffer> buffers;
        // Index of the deteced graphics and presenting device queue
        public int queueNodeIndex = int.MaxValue;

        public Swapchain(Instance instance, PhysicalDevice physicalDevice, Device device)
        {
            this.instance = instance;
            this.physicalDevice = physicalDevice;
            this.device = device;
        }

        // Creates an os specific surface
        // Tries to find a graphics and a present queue
        public void initSurface(Form form)
        {
            // Win32
            var surfaceCreateInfo = new Win32SurfaceCreateInfoKHR(Process.GetCurrentProcess().Handle, form.Handle);
            surface = instance.CreateWin32SurfaceKHR(surfaceCreateInfo);
            surfaceCreateInfo.Dispose();
            //

            // Get available queue family properties
            var queueProps = physicalDevice.GetQueueFamilyProperties();

            // Iterate over each queue to learn whether it supports presenting:
            // Find a queue with present support
            // Will be used to present the swap chain images to the windowing system
            var supportsPresent = new List<bool>(queueProps.Count);
            for(uint x = 0; x < queueProps.Count; x++)
                supportsPresent.Add(physicalDevice.GetSurfaceSupportKHR(x, surface));

            // Search for a graphics and a present queue in the array of queue
            // families, try to find one that supports both
            int graphicsQueueNodeIndex = int.MaxValue;
            int presentQueueNodeIndex = int.MaxValue;
            for(int x = 0; x < queueProps.Count; x++)
            {
                if((queueProps[x].QueueFlags & QueueFlags.Graphics) != 0)
                {
                    if(graphicsQueueNodeIndex == int.MaxValue)
                        graphicsQueueNodeIndex = x;

                    if(supportsPresent[x])
                    {
                        graphicsQueueNodeIndex = x;
                        presentQueueNodeIndex = x;
                        break;
                    }
                }
            }

            if(presentQueueNodeIndex == int.MaxValue)
            {
                // If there's no queue that supports both present and graphics
                // try to find a separate present queue
                for(int x = 0; x < queueProps.Count; x++)
                {
                    if(supportsPresent[x])
                    {
                        presentQueueNodeIndex = x;
                        break;
                    }
                }
            }

            // Exit if either a graphics or a presenting queue hasn't been found
            if(graphicsQueueNodeIndex == int.MaxValue || presentQueueNodeIndex == int.MaxValue)
                throw new InvalidOperationException("Could not find a graphics and/or presenting queue!");

            // todo : Add support for separate graphics and presenting queue
            if(graphicsQueueNodeIndex != presentQueueNodeIndex)
                throw new InvalidOperationException("Separate graphics and presenting queues are not supported yet!");

            queueNodeIndex = graphicsQueueNodeIndex;

            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);

            // If the surface format list only includes one entry with VK_FORMAT_UNDEFINED,
            // there is no preferered format, so we assume VK_FORMAT_B8G8R8A8_UNORM
            if((surfaceFormats.Count == 1) && (surfaceFormats[0].Format == Format.Undefined))
            {
                colorFormat = Format.B8g8r8a8Unorm;
            }
            else
            {
                // Always select the first available color format
                // If you need a specific format (e.g. SRGB) you'd need to
                // iterate over the list of available surface format and
                // check for it's presence
                colorFormat = surfaceFormats[0].Format;
            }
            colorSpace = surfaceFormats[0].ColorSpace;
        }

        public void create(CommandBuffer cmdBuffer, uint width, uint height)
        {
            // Get physical device surface properties and formats
            SwapchainKHR oldSwapchain = swapchain;
            var surfCaps = physicalDevice.GetSurfaceCapabilitiesKHR(surface);

            // Get available present modes
            var presentModes = physicalDevice.GetSurfacePresentModesKHR(surface);

            Extent2D swapchainExtent;
            if(surfCaps.CurrentExtent.Width == uint.MaxValue)
            {
                // If the surface size is undefined, the size is set to
                // the size of the images requested.
                swapchainExtent.Width = width;
                swapchainExtent.Height = height;
            }
            else
            {
                // If the surface size is defined, the swap chain size must match
                swapchainExtent = surfCaps.CurrentExtent;
                width = surfCaps.CurrentExtent.Width;
                height = surfCaps.CurrentExtent.Height;
            }

            // Prefer mailbox mode if present, it's the lowest latency non-tearing present  mode
            var presentMode = PresentModeKHR.Fifo;
            for(int x = 0; x < presentModes.Count; x++)
            {
                if(presentModes[x] == PresentModeKHR.Mailbox)
                {
                    presentMode = PresentModeKHR.Mailbox;
                    break;
                }

                if((presentMode != PresentModeKHR.Mailbox) && (presentModes[x] == PresentModeKHR.Immediate))
                    presentMode = PresentModeKHR.Immediate;
            }

            // Determine the number of images
            uint desiredNumberOfSwapchainImages = surfCaps.MinImageCount + 1;
            if((surfCaps.MaxImageCount > 0) && (desiredNumberOfSwapchainImages > surfCaps.MaxImageCount))
                desiredNumberOfSwapchainImages = surfCaps.MaxImageCount;

            SurfaceTransformFlagsKHR preTransform;
            if((surfCaps.SupportedTransforms & SurfaceTransformFlagsKHR.Identity) == 0)
            {
                preTransform = SurfaceTransformFlagsKHR.Identity;
            }
            else
            {
                preTransform = surfCaps.CurrentTransform;
            }

            var swapchainCreateInfo = new SwapchainCreateInfoKHR();
            swapchainCreateInfo.Surface = surface;
            swapchainCreateInfo.MinImageCount = desiredNumberOfSwapchainImages;
            swapchainCreateInfo.ImageFormat = colorFormat;
            swapchainCreateInfo.ImageColorSpace = colorSpace;
            swapchainCreateInfo.ImageExtent = new Extent2D(width, height);
            swapchainCreateInfo.ImageUsage = ImageUsageFlags.ColorAttachment;
            swapchainCreateInfo.PreTransform = preTransform;
            swapchainCreateInfo.ImageArrayLayers = 1;
            swapchainCreateInfo.PresentMode = presentMode;
            if(oldSwapchain != null)
                swapchainCreateInfo.OldSwapchain = oldSwapchain;
            swapchainCreateInfo.Clipped = true;
            swapchainCreateInfo.CompositeAlpha = CompositeAlphaFlagsKHR.Opaque;
            swapchain = device.CreateSwapchainKHR(swapchainCreateInfo);
            swapchainCreateInfo.Dispose();

            // If an existing sawp chain is re-created, destroy the old swap chain
            // This also cleans up all the presentable images
            if(oldSwapchain != null)
            {
                for(int x = 0; x < images.Count; x++)
                {
                    device.DestroyImageView(buffers[x].view);
                }
                device.DestroySwapchainKHR(oldSwapchain);
            }

            // Get the swap chain images
            images = device.GetSwapchainImagesKHR(swapchain);

            // Get the swap chain buffers containing the image and imageview
            buffers = new List<SwapchainBuffer>();
            for(int x = 0; x < images.Count; x++)
            {
                var createInfo = new ImageViewCreateInfo();
                createInfo.Format = colorFormat;
                createInfo.Components = new ComponentMapping(ComponentSwizzle.R, ComponentSwizzle.G, ComponentSwizzle.B, ComponentSwizzle.A);
                createInfo.SubresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
                createInfo.ViewType = ImageViewType.ImageViewType2d;
                setImageLayout(cmdBuffer, images[x], ImageAspectFlags.Color, ImageLayout.Undefined, ImageLayout.PresentSrcKHR);
                createInfo.Image = images[x];
                var view = device.CreateImageView(createInfo);
                createInfo.Dispose();
                buffers.Add(new SwapchainBuffer { image = images[x], view = view });
            }
        }

        // Acquires the next image in the swap chain
        public uint acquireNextImage(Semaphore presentCompleteSemaphore)
            => device.AcquireNextImageKHR(swapchain, ulong.MaxValue, presentCompleteSemaphore);

        // Present the current image to the queue
        public void queuePresent(Queue queue, uint currentBuffer)
        {
            var presentInfo = new PresentInfoKHR();
            presentInfo.Swapchains = new[] { swapchain };
            presentInfo.ImageIndices = new[] { currentBuffer };
            queue.PresentKHR(presentInfo);
            presentInfo.Dispose();
        }

        // Present the current image to the queue
        public void queuePresent(Queue queue, uint currentBuffer, Semaphore waitSemaphore)
        {
            var presentInfo = new PresentInfoKHR();
            presentInfo.Swapchains = new[] { swapchain };
            presentInfo.ImageIndices = new[] { currentBuffer };
            queue.PresentKHR(presentInfo);
            if(waitSemaphore != null)
            {
                presentInfo.WaitSemaphores = new[] { waitSemaphore };
            }
            presentInfo.Dispose();
        }

        // Free all Vulkan resources used by the swap chain
        public void cleanup()
        {
            for(int x = 0; x < images.Count; x++)
                device.DestroyImage(images[x]);
            device.DestroySwapchainKHR(swapchain);
            instance.DestroySurfaceKHR(surface);
        }

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
    }
}
