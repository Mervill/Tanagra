// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable InconsistentNaming
using System;

namespace Vulkan.Interop
{
    internal struct PhysicalDeviceProperties
    {
        internal UInt32 ApiVersion;
        internal UInt32 DriverVersion;
        internal UInt32 VendorID;
        internal UInt32 DeviceID;
        internal PhysicalDeviceType DeviceType;
        internal IntPtr DeviceName;
        internal Byte PipelineCacheUUID;
        internal PhysicalDeviceLimits Limits;
        internal PhysicalDeviceSparseProperties SparseProperties;
    }

    internal struct ExtensionProperties
    {
        internal IntPtr ExtensionName;
        internal UInt32 SpecVersion;
    }

    internal struct LayerProperties
    {
        internal IntPtr LayerName;
        internal UInt32 SpecVersion;
        internal UInt32 ImplementationVersion;
        internal IntPtr Description;
    }

    internal struct ApplicationInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal IntPtr ApplicationName;
        internal UInt32 ApplicationVersion;
        internal IntPtr EngineName;
        internal UInt32 EngineVersion;
        internal UInt32 ApiVersion;
    }

    internal struct AllocationCallbacks
    {
        internal IntPtr UserData;
        internal IntPtr PfnAllocation;
        internal IntPtr PfnReallocation;
        internal IntPtr PfnFree;
        internal IntPtr PfnInternalAllocation;
        internal IntPtr PfnInternalFree;
    }

    internal struct DeviceQueueCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DeviceQueueCreateFlags Flags;
        internal UInt32 QueueFamilyIndex;
        internal UInt32 QueueCount;
        internal IntPtr QueuePriorities;
    }

    internal struct DeviceCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DeviceCreateFlags Flags;
        internal UInt32 QueueCreateInfoCount;
        internal IntPtr QueueCreateInfos;
        internal UInt32 EnabledLayerCount;
        internal IntPtr EnabledLayerNames;
        internal UInt32 EnabledExtensionCount;
        internal IntPtr EnabledExtensionNames;
        internal IntPtr EnabledFeatures;
    }

    internal struct InstanceCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal InstanceCreateFlags Flags;
        internal IntPtr ApplicationInfo;
        internal UInt32 EnabledLayerCount;
        internal IntPtr EnabledLayerNames;
        internal UInt32 EnabledExtensionCount;
        internal IntPtr EnabledExtensionNames;
    }

    internal struct MemoryAllocateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DeviceSize AllocationSize;
        internal UInt32 MemoryTypeIndex;
    }

    internal struct MappedMemoryRange
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt64 Memory;
        internal DeviceSize Offset;
        internal DeviceSize Size;
    }

    internal struct WriteDescriptorSet
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt64 DstSet;
        internal UInt32 DstBinding;
        internal UInt32 DstArrayElement;
        internal UInt32 DescriptorCount;
        internal DescriptorType DescriptorType;
        internal IntPtr ImageInfo;
        internal IntPtr BufferInfo;
        internal IntPtr TexelBufferView;
    }

    internal struct CopyDescriptorSet
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt64 SrcSet;
        internal UInt32 SrcBinding;
        internal UInt32 SrcArrayElement;
        internal UInt64 DstSet;
        internal UInt32 DstBinding;
        internal UInt32 DstArrayElement;
        internal UInt32 DescriptorCount;
    }

    internal struct BufferCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal BufferCreateFlags Flags;
        internal DeviceSize Size;
        internal BufferUsageFlags Usage;
        internal SharingMode SharingMode;
        internal UInt32 QueueFamilyIndexCount;
        internal IntPtr QueueFamilyIndices;
    }

    internal struct BufferViewCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal BufferViewCreateFlags Flags;
        internal UInt64 Buffer;
        internal Format Format;
        internal DeviceSize Offset;
        internal DeviceSize Range;
    }

    internal struct MemoryBarrier
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal AccessFlags SrcAccessMask;
        internal AccessFlags DstAccessMask;
    }

    internal struct BufferMemoryBarrier
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal AccessFlags SrcAccessMask;
        internal AccessFlags DstAccessMask;
        internal UInt32 SrcQueueFamilyIndex;
        internal UInt32 DstQueueFamilyIndex;
        internal UInt64 Buffer;
        internal DeviceSize Offset;
        internal DeviceSize Size;
    }

    internal struct ImageMemoryBarrier
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal AccessFlags SrcAccessMask;
        internal AccessFlags DstAccessMask;
        internal ImageLayout OldLayout;
        internal ImageLayout NewLayout;
        internal UInt32 SrcQueueFamilyIndex;
        internal UInt32 DstQueueFamilyIndex;
        internal UInt64 Image;
        internal ImageSubresourceRange SubresourceRange;
    }

    internal struct ImageCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal ImageCreateFlags Flags;
        internal ImageType ImageType;
        internal Format Format;
        internal Extent3D Extent;
        internal UInt32 MipLevels;
        internal UInt32 ArrayLayers;
        internal SampleCountFlags Samples;
        internal ImageTiling Tiling;
        internal ImageUsageFlags Usage;
        internal SharingMode SharingMode;
        internal UInt32 QueueFamilyIndexCount;
        internal IntPtr QueueFamilyIndices;
        internal ImageLayout InitialLayout;
    }

    internal struct ImageViewCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal ImageViewCreateFlags Flags;
        internal UInt64 Image;
        internal ImageViewType ViewType;
        internal Format Format;
        internal ComponentMapping Components;
        internal ImageSubresourceRange SubresourceRange;
    }

    internal struct SparseBufferMemoryBindInfo
    {
        internal UInt64 Buffer;
        internal UInt32 BindCount;
        internal IntPtr Binds;
    }

    internal struct SparseImageOpaqueMemoryBindInfo
    {
        internal UInt64 Image;
        internal UInt32 BindCount;
        internal IntPtr Binds;
    }

    internal struct SparseImageMemoryBindInfo
    {
        internal UInt64 Image;
        internal UInt32 BindCount;
        internal IntPtr Binds;
    }

    internal struct BindSparseInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt32 WaitSemaphoreCount;
        internal IntPtr WaitSemaphores;
        internal UInt32 BufferBindCount;
        internal IntPtr BufferBinds;
        internal UInt32 ImageOpaqueBindCount;
        internal IntPtr ImageOpaqueBinds;
        internal UInt32 ImageBindCount;
        internal IntPtr ImageBinds;
        internal UInt32 SignalSemaphoreCount;
        internal IntPtr SignalSemaphores;
    }

    internal struct ShaderModuleCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal ShaderModuleCreateFlags Flags;
        internal UIntPtr CodeSize;
        internal IntPtr Code;
    }

    internal struct DescriptorSetLayoutBinding
    {
        internal UInt32 Binding;
        internal DescriptorType DescriptorType;
        internal UInt32 DescriptorCount;
        internal ShaderStageFlags StageFlags;
        internal IntPtr ImmutableSamplers;
    }

    internal struct DescriptorSetLayoutCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DescriptorSetLayoutCreateFlags Flags;
        internal UInt32 BindingCount;
        internal IntPtr Bindings;
    }

    internal struct DescriptorPoolCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DescriptorPoolCreateFlags Flags;
        internal UInt32 MaxSets;
        internal UInt32 PoolSizeCount;
        internal IntPtr PoolSizes;
    }

    internal struct DescriptorSetAllocateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt64 DescriptorPool;
        internal UInt32 DescriptorSetCount;
        internal IntPtr SetLayouts;
    }

    internal struct SpecializationInfo
    {
        internal UInt32 MapEntryCount;
        internal IntPtr MapEntries;
        internal UIntPtr DataSize;
        internal IntPtr Data;
    }

    internal struct PipelineShaderStageCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineShaderStageCreateFlags Flags;
        internal ShaderStageFlags Stage;
        internal UInt64 Module;
        internal IntPtr Name;
        internal IntPtr SpecializationInfo;
    }

    internal struct ComputePipelineCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineCreateFlags Flags;
        internal IntPtr Stage;
        internal UInt64 Layout;
        internal UInt64 BasePipelineHandle;
        internal Int32 BasePipelineIndex;
    }

    internal struct PipelineVertexInputStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineVertexInputStateCreateFlags Flags;
        internal UInt32 VertexBindingDescriptionCount;
        internal IntPtr VertexBindingDescriptions;
        internal UInt32 VertexAttributeDescriptionCount;
        internal IntPtr VertexAttributeDescriptions;
    }

    internal struct PipelineInputAssemblyStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineInputAssemblyStateCreateFlags Flags;
        internal PrimitiveTopology Topology;
        internal Bool32 PrimitiveRestartEnable;
    }

    internal struct PipelineTessellationStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineTessellationStateCreateFlags Flags;
        internal UInt32 PatchControlPoints;
    }

    internal struct PipelineViewportStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineViewportStateCreateFlags Flags;
        internal UInt32 ViewportCount;
        internal IntPtr Viewports;
        internal UInt32 ScissorCount;
        internal IntPtr Scissors;
    }

    internal struct PipelineRasterizationStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineRasterizationStateCreateFlags Flags;
        internal Bool32 DepthClampEnable;
        internal Bool32 RasterizerDiscardEnable;
        internal PolygonMode PolygonMode;
        internal CullModeFlags CullMode;
        internal FrontFace FrontFace;
        internal Bool32 DepthBiasEnable;
        internal Single DepthBiasConstantFactor;
        internal Single DepthBiasClamp;
        internal Single DepthBiasSlopeFactor;
        internal Single LineWidth;
    }

    internal struct PipelineMultisampleStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineMultisampleStateCreateFlags Flags;
        internal SampleCountFlags RasterizationSamples;
        internal Bool32 SampleShadingEnable;
        internal Single MinSampleShading;
        internal IntPtr SampleMask;
        internal Bool32 AlphaToCoverageEnable;
        internal Bool32 AlphaToOneEnable;
    }

    internal struct PipelineColorBlendStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineColorBlendStateCreateFlags Flags;
        internal Bool32 LogicOpEnable;
        internal LogicOp LogicOp;
        internal UInt32 AttachmentCount;
        internal IntPtr Attachments;
        internal Single BlendConstants;
    }

    internal struct PipelineDynamicStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineDynamicStateCreateFlags Flags;
        internal UInt32 DynamicStateCount;
        internal IntPtr DynamicStates;
    }

    internal struct PipelineDepthStencilStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineDepthStencilStateCreateFlags Flags;
        internal Bool32 DepthTestEnable;
        internal Bool32 DepthWriteEnable;
        internal CompareOp DepthCompareOp;
        internal Bool32 DepthBoundsTestEnable;
        internal Bool32 StencilTestEnable;
        internal StencilOpState Front;
        internal StencilOpState Back;
        internal Single MinDepthBounds;
        internal Single MaxDepthBounds;
    }

    internal struct GraphicsPipelineCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineCreateFlags Flags;
        internal UInt32 StageCount;
        internal IntPtr Stages;
        internal IntPtr VertexInputState;
        internal IntPtr InputAssemblyState;
        internal IntPtr TessellationState;
        internal IntPtr ViewportState;
        internal IntPtr RasterizationState;
        internal IntPtr MultisampleState;
        internal IntPtr DepthStencilState;
        internal IntPtr ColorBlendState;
        internal IntPtr DynamicState;
        internal UInt64 Layout;
        internal UInt64 RenderPass;
        internal UInt32 Subpass;
        internal UInt64 BasePipelineHandle;
        internal Int32 BasePipelineIndex;
    }

    internal struct PipelineCacheCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineCacheCreateFlags Flags;
        internal UIntPtr InitialDataSize;
        internal IntPtr InitialData;
    }

    internal struct PipelineLayoutCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineLayoutCreateFlags Flags;
        internal UInt32 SetLayoutCount;
        internal IntPtr SetLayouts;
        internal UInt32 PushConstantRangeCount;
        internal IntPtr PushConstantRanges;
    }

    internal struct SamplerCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal SamplerCreateFlags Flags;
        internal Filter MagFilter;
        internal Filter MinFilter;
        internal SamplerMipmapMode MipmapMode;
        internal SamplerAddressMode AddressModeU;
        internal SamplerAddressMode AddressModeV;
        internal SamplerAddressMode AddressModeW;
        internal Single MipLodBias;
        internal Bool32 AnisotropyEnable;
        internal Single MaxAnisotropy;
        internal Bool32 CompareEnable;
        internal CompareOp CompareOp;
        internal Single MinLod;
        internal Single MaxLod;
        internal BorderColor BorderColor;
        internal Bool32 UnnormalizedCoordinates;
    }

    internal struct CommandPoolCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal CommandPoolCreateFlags Flags;
        internal UInt32 QueueFamilyIndex;
    }

    internal struct CommandBufferAllocateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt64 CommandPool;
        internal CommandBufferLevel Level;
        internal UInt32 CommandBufferCount;
    }

    internal struct CommandBufferInheritanceInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt64 RenderPass;
        internal UInt32 Subpass;
        internal UInt64 Framebuffer;
        internal Bool32 OcclusionQueryEnable;
        internal QueryControlFlags QueryFlags;
        internal QueryPipelineStatisticFlags PipelineStatistics;
    }

    internal struct CommandBufferBeginInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal CommandBufferUsageFlags Flags;
        internal IntPtr InheritanceInfo;
    }

    internal struct RenderPassBeginInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt64 RenderPass;
        internal UInt64 Framebuffer;
        internal Rect2D RenderArea;
        internal UInt32 ClearValueCount;
        internal IntPtr ClearValues;
    }

    internal struct SubpassDescription
    {
        internal SubpassDescriptionFlags Flags;
        internal PipelineBindPoint PipelineBindPoint;
        internal UInt32 InputAttachmentCount;
        internal IntPtr InputAttachments;
        internal UInt32 ColorAttachmentCount;
        internal IntPtr ColorAttachments;
        internal IntPtr ResolveAttachments;
        internal IntPtr DepthStencilAttachment;
        internal UInt32 PreserveAttachmentCount;
        internal IntPtr PreserveAttachments;
    }

    internal struct RenderPassCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal RenderPassCreateFlags Flags;
        internal UInt32 AttachmentCount;
        internal IntPtr Attachments;
        internal UInt32 SubpassCount;
        internal IntPtr Subpasses;
        internal UInt32 DependencyCount;
        internal IntPtr Dependencies;
    }

    internal struct EventCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal EventCreateFlags Flags;
    }

    internal struct FenceCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal FenceCreateFlags Flags;
    }

    internal struct SemaphoreCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal SemaphoreCreateFlags Flags;
    }

    internal struct QueryPoolCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal QueryPoolCreateFlags Flags;
        internal QueryType QueryType;
        internal UInt32 QueryCount;
        internal QueryPipelineStatisticFlags PipelineStatistics;
    }

    internal struct FramebufferCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal FramebufferCreateFlags Flags;
        internal UInt64 RenderPass;
        internal UInt32 AttachmentCount;
        internal IntPtr Attachments;
        internal UInt32 Width;
        internal UInt32 Height;
        internal UInt32 Layers;
    }

    internal struct SubmitInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt32 WaitSemaphoreCount;
        internal IntPtr WaitSemaphores;
        internal IntPtr WaitDstStageMask;
        internal UInt32 CommandBufferCount;
        internal IntPtr CommandBuffers;
        internal UInt32 SignalSemaphoreCount;
        internal IntPtr SignalSemaphores;
    }

    internal struct DisplayPropertiesKHR
    {
        internal UInt64 Display;
        internal IntPtr DisplayName;
        internal Extent2D PhysicalDimensions;
        internal Extent2D PhysicalResolution;
        internal SurfaceTransformFlagsKHR SupportedTransforms;
        internal Bool32 PlaneReorderPossible;
        internal Bool32 PersistentContent;
    }

    internal struct DisplayModeCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DisplayModeCreateFlagsKHR Flags;
        internal DisplayModeParametersKHR Parameters;
    }

    internal struct DisplaySurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DisplaySurfaceCreateFlagsKHR Flags;
        internal UInt64 DisplayMode;
        internal UInt32 PlaneIndex;
        internal UInt32 PlaneStackIndex;
        internal SurfaceTransformFlagsKHR Transform;
        internal Single GlobalAlpha;
        internal DisplayPlaneAlphaFlagsKHR AlphaMode;
        internal Extent2D ImageExtent;
    }

    internal struct DisplayPresentInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal Rect2D SrcRect;
        internal Rect2D DstRect;
        internal Bool32 Persistent;
    }

    internal struct AndroidSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal AndroidSurfaceCreateFlagsKHR Flags;
        internal IntPtr Window;
    }

    internal struct MirSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal MirSurfaceCreateFlagsKHR Flags;
        internal IntPtr Connection;
        internal IntPtr MirSurface;
    }

    internal struct WaylandSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal WaylandSurfaceCreateFlagsKHR Flags;
        internal IntPtr Display;
        internal IntPtr Surface;
    }

    internal struct Win32SurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal Win32SurfaceCreateFlagsKHR Flags;
        internal IntPtr Hinstance;
        internal IntPtr Hwnd;
    }

    internal struct XlibSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal XlibSurfaceCreateFlagsKHR Flags;
        internal IntPtr Dpy;
        internal IntPtr Window;
    }

    internal struct XcbSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal XcbSurfaceCreateFlagsKHR Flags;
        internal IntPtr Connection;
        internal IntPtr Window;
    }

    internal struct SwapchainCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal SwapchainCreateFlagsKHR Flags;
        internal UInt64 Surface;
        internal UInt32 MinImageCount;
        internal Format ImageFormat;
        internal ColorSpaceKHR ImageColorSpace;
        internal Extent2D ImageExtent;
        internal UInt32 ImageArrayLayers;
        internal ImageUsageFlags ImageUsage;
        internal SharingMode ImageSharingMode;
        internal UInt32 QueueFamilyIndexCount;
        internal IntPtr QueueFamilyIndices;
        internal SurfaceTransformFlagsKHR PreTransform;
        internal CompositeAlphaFlagsKHR CompositeAlpha;
        internal PresentModeKHR PresentMode;
        internal Bool32 Clipped;
        internal UInt64 OldSwapchain;
    }

    internal struct PresentInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt32 WaitSemaphoreCount;
        internal IntPtr WaitSemaphores;
        internal UInt32 SwapchainCount;
        internal IntPtr Swapchains;
        internal IntPtr ImageIndices;
        internal IntPtr Results;
    }

    internal struct DebugReportCallbackCreateInfoEXT
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DebugReportFlagsEXT Flags;
        internal IntPtr PfnCallback;
        internal IntPtr UserData;
    }

    internal struct PipelineRasterizationStateRasterizationOrderAMD
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal RasterizationOrderAMD RasterizationOrder;
    }

    internal struct DebugMarkerObjectNameInfoEXT
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DebugReportObjectTypeEXT ObjectType;
        internal UInt64 Object;
        internal IntPtr ObjectName;
    }

    internal struct DebugMarkerObjectTagInfoEXT
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DebugReportObjectTypeEXT ObjectType;
        internal UInt64 Object;
        internal UInt64 TagName;
        internal UIntPtr TagSize;
        internal IntPtr Tag;
    }

    internal struct DebugMarkerMarkerInfoEXT
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal IntPtr MarkerName;
        internal Single Color;
    }

}
