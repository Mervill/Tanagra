// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable InconsistentNaming
using System;

namespace Vulkan.Interop
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    internal struct PhysicalDeviceProperties
    {
        public UInt32 ApiVersion;
        public UInt32 DriverVersion;
        public UInt32 VendorID;
        public UInt32 DeviceID;
        public PhysicalDeviceType DeviceType;
        public unsafe fixed byte DeviceName[256];
        public unsafe fixed Byte PipelineCacheUUID[16];
        public PhysicalDeviceLimits Limits;
        public PhysicalDeviceSparseProperties SparseProperties;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    internal struct ExtensionProperties
    {
        public unsafe fixed byte ExtensionName[256];
        public UInt32 SpecVersion;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    internal struct LayerProperties
    {
        public unsafe fixed byte LayerName[256];
        public UInt32 SpecVersion;
        public UInt32 ImplementationVersion;
        public unsafe fixed byte Description[256];
    }

    internal struct ApplicationInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public IntPtr ApplicationName;
        public UInt32 ApplicationVersion;
        public IntPtr EngineName;
        public UInt32 EngineVersion;
        public UInt32 ApiVersion;
    }

    internal struct AllocationCallbacks
    {
        public IntPtr UserData;
        public IntPtr PfnAllocation;
        public IntPtr PfnReallocation;
        public IntPtr PfnFree;
        public IntPtr PfnInternalAllocation;
        public IntPtr PfnInternalFree;
    }

    internal struct DeviceQueueCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public DeviceQueueCreateFlags Flags;
        public UInt32 QueueFamilyIndex;
        public UInt32 QueueCount;
        public IntPtr QueuePriorities;
    }

    internal struct DeviceCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public DeviceCreateFlags Flags;
        public UInt32 QueueCreateInfoCount;
        public IntPtr QueueCreateInfos;
        public UInt32 EnabledLayerCount;
        public IntPtr EnabledLayerNames;
        public UInt32 EnabledExtensionCount;
        public IntPtr EnabledExtensionNames;
        public IntPtr EnabledFeatures;
    }

    internal struct InstanceCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public InstanceCreateFlags Flags;
        public IntPtr ApplicationInfo;
        public UInt32 EnabledLayerCount;
        public IntPtr EnabledLayerNames;
        public UInt32 EnabledExtensionCount;
        public IntPtr EnabledExtensionNames;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    internal struct PhysicalDeviceMemoryProperties
    {
        public UInt32 MemoryTypeCount;
        public MemoryType MemoryTypes;
        public UInt32 MemoryHeapCount;
        public MemoryHeap MemoryHeaps;
    }

    internal struct MemoryAllocateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public DeviceSize AllocationSize;
        public UInt32 MemoryTypeIndex;
    }

    internal struct MappedMemoryRange
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt64 Memory;
        public DeviceSize Offset;
        public DeviceSize Size;
    }

    internal struct DescriptorBufferInfo
    {
        public UInt64 Buffer;
        public DeviceSize Offset;
        public DeviceSize Range;
    }

    internal struct DescriptorImageInfo
    {
        public UInt64 Sampler;
        public UInt64 ImageView;
        public ImageLayout ImageLayout;
    }

    internal struct WriteDescriptorSet
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt64 DstSet;
        public UInt32 DstBinding;
        public UInt32 DstArrayElement;
        public UInt32 DescriptorCount;
        public DescriptorType DescriptorType;
        public IntPtr ImageInfo;
        public IntPtr BufferInfo;
        public IntPtr TexelBufferView;
    }

    internal struct CopyDescriptorSet
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt64 SrcSet;
        public UInt32 SrcBinding;
        public UInt32 SrcArrayElement;
        public UInt64 DstSet;
        public UInt32 DstBinding;
        public UInt32 DstArrayElement;
        public UInt32 DescriptorCount;
    }

    internal struct BufferCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public BufferCreateFlags Flags;
        public DeviceSize Size;
        public BufferUsageFlags Usage;
        public SharingMode SharingMode;
        public UInt32 QueueFamilyIndexCount;
        public IntPtr QueueFamilyIndices;
    }

    internal struct BufferViewCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public BufferViewCreateFlags Flags;
        public UInt64 Buffer;
        public Format Format;
        public DeviceSize Offset;
        public DeviceSize Range;
    }

    internal struct MemoryBarrier
    {
        public StructureType SType;
        public IntPtr Next;
        public AccessFlags SrcAccessMask;
        public AccessFlags DstAccessMask;
    }

    internal struct BufferMemoryBarrier
    {
        public StructureType SType;
        public IntPtr Next;
        public AccessFlags SrcAccessMask;
        public AccessFlags DstAccessMask;
        public UInt32 SrcQueueFamilyIndex;
        public UInt32 DstQueueFamilyIndex;
        public UInt64 Buffer;
        public DeviceSize Offset;
        public DeviceSize Size;
    }

    internal struct ImageMemoryBarrier
    {
        public StructureType SType;
        public IntPtr Next;
        public AccessFlags SrcAccessMask;
        public AccessFlags DstAccessMask;
        public ImageLayout OldLayout;
        public ImageLayout NewLayout;
        public UInt32 SrcQueueFamilyIndex;
        public UInt32 DstQueueFamilyIndex;
        public UInt64 Image;
        public ImageSubresourceRange SubresourceRange;
    }

    internal struct ImageCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public ImageCreateFlags Flags;
        public ImageType ImageType;
        public Format Format;
        public Extent3D Extent;
        public UInt32 MipLevels;
        public UInt32 ArrayLayers;
        public SampleCountFlags Samples;
        public ImageTiling Tiling;
        public ImageUsageFlags Usage;
        public SharingMode SharingMode;
        public UInt32 QueueFamilyIndexCount;
        public IntPtr QueueFamilyIndices;
        public ImageLayout InitialLayout;
    }

    internal struct ImageViewCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public ImageViewCreateFlags Flags;
        public UInt64 Image;
        public ImageViewType ViewType;
        public Format Format;
        public ComponentMapping Components;
        public ImageSubresourceRange SubresourceRange;
    }

    internal struct SparseMemoryBind
    {
        public DeviceSize ResourceOffset;
        public DeviceSize Size;
        public UInt64 Memory;
        public DeviceSize MemoryOffset;
        public SparseMemoryBindFlags Flags;
    }

    internal struct SparseImageMemoryBind
    {
        public ImageSubresource Subresource;
        public Offset3D Offset;
        public Extent3D Extent;
        public UInt64 Memory;
        public DeviceSize MemoryOffset;
        public SparseMemoryBindFlags Flags;
    }

    internal struct SparseBufferMemoryBindInfo
    {
        public UInt64 Buffer;
        public UInt32 BindCount;
        public IntPtr Binds;
    }

    internal struct SparseImageOpaqueMemoryBindInfo
    {
        public UInt64 Image;
        public UInt32 BindCount;
        public IntPtr Binds;
    }

    internal struct SparseImageMemoryBindInfo
    {
        public UInt64 Image;
        public UInt32 BindCount;
        public IntPtr Binds;
    }

    internal struct BindSparseInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt32 WaitSemaphoreCount;
        public IntPtr WaitSemaphores;
        public UInt32 BufferBindCount;
        public IntPtr BufferBinds;
        public UInt32 ImageOpaqueBindCount;
        public IntPtr ImageOpaqueBinds;
        public UInt32 ImageBindCount;
        public IntPtr ImageBinds;
        public UInt32 SignalSemaphoreCount;
        public IntPtr SignalSemaphores;
    }

    internal struct ImageBlit
    {
        public ImageSubresourceLayers SrcSubresource;
        public Offset3D SrcOffsets;
        public ImageSubresourceLayers DstSubresource;
        public Offset3D DstOffsets;
    }

    internal struct ShaderModuleCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public ShaderModuleCreateFlags Flags;
        public UInt32 CodeSize;
        public IntPtr Code;
    }

    internal struct DescriptorSetLayoutBinding
    {
        public UInt32 Binding;
        public DescriptorType DescriptorType;
        public UInt32 DescriptorCount;
        public ShaderStageFlags StageFlags;
        public IntPtr ImmutableSamplers;
    }

    internal struct DescriptorSetLayoutCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public DescriptorSetLayoutCreateFlags Flags;
        public UInt32 BindingCount;
        public IntPtr Bindings;
    }

    internal struct DescriptorPoolCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public DescriptorPoolCreateFlags Flags;
        public UInt32 MaxSets;
        public UInt32 PoolSizeCount;
        public IntPtr PoolSizes;
    }

    internal struct DescriptorSetAllocateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt64 DescriptorPool;
        public UInt32 DescriptorSetCount;
        public IntPtr SetLayouts;
    }

    internal struct SpecializationInfo
    {
        public UInt32 MapEntryCount;
        public IntPtr MapEntries;
        public UInt32 DataSize;
        public IntPtr Data;
    }

    internal struct PipelineShaderStageCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineShaderStageCreateFlags Flags;
        public ShaderStageFlags Stage;
        public UInt64 Module;
        public IntPtr Name;
        public IntPtr SpecializationInfo;
    }

    internal struct ComputePipelineCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineCreateFlags Flags;
        public PipelineShaderStageCreateInfo Stage;
        public UInt64 Layout;
        public UInt64 BasePipelineHandle;
        public Int32 BasePipelineIndex;
    }

    internal struct PipelineVertexInputStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineVertexInputStateCreateFlags Flags;
        public UInt32 VertexBindingDescriptionCount;
        public IntPtr VertexBindingDescriptions;
        public UInt32 VertexAttributeDescriptionCount;
        public IntPtr VertexAttributeDescriptions;
    }

    internal struct PipelineInputAssemblyStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineInputAssemblyStateCreateFlags Flags;
        public PrimitiveTopology Topology;
        public Bool32 PrimitiveRestartEnable;
    }

    internal struct PipelineTessellationStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineTessellationStateCreateFlags Flags;
        public UInt32 PatchControlPoints;
    }

    internal struct PipelineViewportStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineViewportStateCreateFlags Flags;
        public UInt32 ViewportCount;
        public IntPtr Viewports;
        public UInt32 ScissorCount;
        public IntPtr Scissors;
    }

    internal struct PipelineRasterizationStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineRasterizationStateCreateFlags Flags;
        public Bool32 DepthClampEnable;
        public Bool32 RasterizerDiscardEnable;
        public PolygonMode PolygonMode;
        public CullModeFlags CullMode;
        public FrontFace FrontFace;
        public Bool32 DepthBiasEnable;
        public Single DepthBiasConstantFactor;
        public Single DepthBiasClamp;
        public Single DepthBiasSlopeFactor;
        public Single LineWidth;
    }

    internal struct PipelineMultisampleStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineMultisampleStateCreateFlags Flags;
        public SampleCountFlags RasterizationSamples;
        public Bool32 SampleShadingEnable;
        public Single MinSampleShading;
        public IntPtr SampleMask;
        public Bool32 AlphaToCoverageEnable;
        public Bool32 AlphaToOneEnable;
    }

    internal struct PipelineColorBlendStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineColorBlendStateCreateFlags Flags;
        public Bool32 LogicOpEnable;
        public LogicOp LogicOp;
        public UInt32 AttachmentCount;
        public IntPtr Attachments;
        public unsafe fixed Single BlendConstants[4];
    }

    internal struct PipelineDynamicStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineDynamicStateCreateFlags Flags;
        public UInt32 DynamicStateCount;
        public IntPtr DynamicStates;
    }

    internal struct PipelineDepthStencilStateCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineDepthStencilStateCreateFlags Flags;
        public Bool32 DepthTestEnable;
        public Bool32 DepthWriteEnable;
        public CompareOp DepthCompareOp;
        public Bool32 DepthBoundsTestEnable;
        public Bool32 StencilTestEnable;
        public StencilOpState Front;
        public StencilOpState Back;
        public Single MinDepthBounds;
        public Single MaxDepthBounds;
    }

    internal struct GraphicsPipelineCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineCreateFlags Flags;
        public UInt32 StageCount;
        public IntPtr Stages;
        public IntPtr VertexInputState;
        public IntPtr InputAssemblyState;
        public IntPtr TessellationState;
        public IntPtr ViewportState;
        public IntPtr RasterizationState;
        public IntPtr MultisampleState;
        public IntPtr DepthStencilState;
        public IntPtr ColorBlendState;
        public IntPtr DynamicState;
        public UInt64 Layout;
        public UInt64 RenderPass;
        public UInt32 Subpass;
        public UInt64 BasePipelineHandle;
        public Int32 BasePipelineIndex;
    }

    internal struct PipelineCacheCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineCacheCreateFlags Flags;
        public UInt32 InitialDataSize;
        public IntPtr InitialData;
    }

    internal struct PipelineLayoutCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public PipelineLayoutCreateFlags Flags;
        public UInt32 SetLayoutCount;
        public IntPtr SetLayouts;
        public UInt32 PushConstantRangeCount;
        public IntPtr PushConstantRanges;
    }

    internal struct SamplerCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public SamplerCreateFlags Flags;
        public Filter MagFilter;
        public Filter MinFilter;
        public SamplerMipmapMode MipmapMode;
        public SamplerAddressMode AddressModeU;
        public SamplerAddressMode AddressModeV;
        public SamplerAddressMode AddressModeW;
        public Single MipLodBias;
        public Bool32 AnisotropyEnable;
        public Single MaxAnisotropy;
        public Bool32 CompareEnable;
        public CompareOp CompareOp;
        public Single MinLod;
        public Single MaxLod;
        public BorderColor BorderColor;
        public Bool32 UnnormalizedCoordinates;
    }

    internal struct CommandPoolCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public CommandPoolCreateFlags Flags;
        public UInt32 QueueFamilyIndex;
    }

    internal struct CommandBufferAllocateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt64 CommandPool;
        public CommandBufferLevel Level;
        public UInt32 CommandBufferCount;
    }

    internal struct CommandBufferInheritanceInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt64 RenderPass;
        public UInt32 Subpass;
        public UInt64 Framebuffer;
        public Bool32 OcclusionQueryEnable;
        public QueryControlFlags QueryFlags;
        public QueryPipelineStatisticFlags PipelineStatistics;
    }

    internal struct CommandBufferBeginInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public CommandBufferUsageFlags Flags;
        public IntPtr InheritanceInfo;
    }

    internal struct RenderPassBeginInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt64 RenderPass;
        public UInt64 Framebuffer;
        public Rect2D RenderArea;
        public UInt32 ClearValueCount;
        public IntPtr ClearValues;
    }

    internal struct SubpassDescription
    {
        public SubpassDescriptionFlags Flags;
        public PipelineBindPoint PipelineBindPoint;
        public UInt32 InputAttachmentCount;
        public IntPtr InputAttachments;
        public UInt32 ColorAttachmentCount;
        public IntPtr ColorAttachments;
        public IntPtr ResolveAttachments;
        public IntPtr DepthStencilAttachment;
        public UInt32 PreserveAttachmentCount;
        public IntPtr PreserveAttachments;
    }

    internal struct RenderPassCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public RenderPassCreateFlags Flags;
        public UInt32 AttachmentCount;
        public IntPtr Attachments;
        public UInt32 SubpassCount;
        public IntPtr Subpasses;
        public UInt32 DependencyCount;
        public IntPtr Dependencies;
    }

    internal struct EventCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public EventCreateFlags Flags;
    }

    internal struct FenceCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public FenceCreateFlags Flags;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    internal struct PhysicalDeviceLimits
    {
        public UInt32 MaxImageDimension1D;
        public UInt32 MaxImageDimension2D;
        public UInt32 MaxImageDimension3D;
        public UInt32 MaxImageDimensionCube;
        public UInt32 MaxImageArrayLayers;
        public UInt32 MaxTexelBufferElements;
        public UInt32 MaxUniformBufferRange;
        public UInt32 MaxStorageBufferRange;
        public UInt32 MaxPushConstantsSize;
        public UInt32 MaxMemoryAllocationCount;
        public UInt32 MaxSamplerAllocationCount;
        public DeviceSize BufferImageGranularity;
        public DeviceSize SparseAddressSpaceSize;
        public UInt32 MaxBoundDescriptorSets;
        public UInt32 MaxPerStageDescriptorSamplers;
        public UInt32 MaxPerStageDescriptorUniformBuffers;
        public UInt32 MaxPerStageDescriptorStorageBuffers;
        public UInt32 MaxPerStageDescriptorSampledImages;
        public UInt32 MaxPerStageDescriptorStorageImages;
        public UInt32 MaxPerStageDescriptorInputAttachments;
        public UInt32 MaxPerStageResources;
        public UInt32 MaxDescriptorSetSamplers;
        public UInt32 MaxDescriptorSetUniformBuffers;
        public UInt32 MaxDescriptorSetUniformBuffersDynamic;
        public UInt32 MaxDescriptorSetStorageBuffers;
        public UInt32 MaxDescriptorSetStorageBuffersDynamic;
        public UInt32 MaxDescriptorSetSampledImages;
        public UInt32 MaxDescriptorSetStorageImages;
        public UInt32 MaxDescriptorSetInputAttachments;
        public UInt32 MaxVertexInputAttributes;
        public UInt32 MaxVertexInputBindings;
        public UInt32 MaxVertexInputAttributeOffset;
        public UInt32 MaxVertexInputBindingStride;
        public UInt32 MaxVertexOutputComponents;
        public UInt32 MaxTessellationGenerationLevel;
        public UInt32 MaxTessellationPatchSize;
        public UInt32 MaxTessellationControlPerVertexInputComponents;
        public UInt32 MaxTessellationControlPerVertexOutputComponents;
        public UInt32 MaxTessellationControlPerPatchOutputComponents;
        public UInt32 MaxTessellationControlTotalOutputComponents;
        public UInt32 MaxTessellationEvaluationInputComponents;
        public UInt32 MaxTessellationEvaluationOutputComponents;
        public UInt32 MaxGeometryShaderInvocations;
        public UInt32 MaxGeometryInputComponents;
        public UInt32 MaxGeometryOutputComponents;
        public UInt32 MaxGeometryOutputVertices;
        public UInt32 MaxGeometryTotalOutputComponents;
        public UInt32 MaxFragmentInputComponents;
        public UInt32 MaxFragmentOutputAttachments;
        public UInt32 MaxFragmentDualSrcAttachments;
        public UInt32 MaxFragmentCombinedOutputResources;
        public UInt32 MaxComputeSharedMemorySize;
        public unsafe fixed UInt32 MaxComputeWorkGroupCount[3];
        public UInt32 MaxComputeWorkGroupInvocations;
        public unsafe fixed UInt32 MaxComputeWorkGroupSize[3];
        public UInt32 SubPixelPrecisionBits;
        public UInt32 SubTexelPrecisionBits;
        public UInt32 MipmapPrecisionBits;
        public UInt32 MaxDrawIndexedIndexValue;
        public UInt32 MaxDrawIndirectCount;
        public Single MaxSamplerLodBias;
        public Single MaxSamplerAnisotropy;
        public UInt32 MaxViewports;
        public unsafe fixed UInt32 MaxViewportDimensions[2];
        public unsafe fixed Single ViewportBoundsRange[2];
        public UInt32 ViewportSubPixelBits;
        public UInt32 MinMemoryMapAlignment;
        public DeviceSize MinTexelBufferOffsetAlignment;
        public DeviceSize MinUniformBufferOffsetAlignment;
        public DeviceSize MinStorageBufferOffsetAlignment;
        public Int32 MinTexelOffset;
        public UInt32 MaxTexelOffset;
        public Int32 MinTexelGatherOffset;
        public UInt32 MaxTexelGatherOffset;
        public Single MinInterpolationOffset;
        public Single MaxInterpolationOffset;
        public UInt32 SubPixelInterpolationOffsetBits;
        public UInt32 MaxFramebufferWidth;
        public UInt32 MaxFramebufferHeight;
        public UInt32 MaxFramebufferLayers;
        public SampleCountFlags FramebufferColorSampleCounts;
        public SampleCountFlags FramebufferDepthSampleCounts;
        public SampleCountFlags FramebufferStencilSampleCounts;
        public SampleCountFlags FramebufferNoAttachmentsSampleCounts;
        public UInt32 MaxColorAttachments;
        public SampleCountFlags SampledImageColorSampleCounts;
        public SampleCountFlags SampledImageIntegerSampleCounts;
        public SampleCountFlags SampledImageDepthSampleCounts;
        public SampleCountFlags SampledImageStencilSampleCounts;
        public SampleCountFlags StorageImageSampleCounts;
        public UInt32 MaxSampleMaskWords;
        public Bool32 TimestampComputeAndGraphics;
        public Single TimestampPeriod;
        public UInt32 MaxClipDistances;
        public UInt32 MaxCullDistances;
        public UInt32 MaxCombinedClipAndCullDistances;
        public UInt32 DiscreteQueuePriorities;
        public unsafe fixed Single PointSizeRange[2];
        public unsafe fixed Single LineWidthRange[2];
        public Single PointSizeGranularity;
        public Single LineWidthGranularity;
        public Bool32 StrictLines;
        public Bool32 StandardSampleLocations;
        public DeviceSize OptimalBufferCopyOffsetAlignment;
        public DeviceSize OptimalBufferCopyRowPitchAlignment;
        public DeviceSize NonCoherentAtomSize;
    }

    internal struct SemaphoreCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public SemaphoreCreateFlags Flags;
    }

    internal struct QueryPoolCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public QueryPoolCreateFlags Flags;
        public QueryType QueryType;
        public UInt32 QueryCount;
        public QueryPipelineStatisticFlags PipelineStatistics;
    }

    internal struct FramebufferCreateInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public FramebufferCreateFlags Flags;
        public UInt64 RenderPass;
        public UInt32 AttachmentCount;
        public IntPtr Attachments;
        public UInt32 Width;
        public UInt32 Height;
        public UInt32 Layers;
    }

    internal struct SubmitInfo
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt32 WaitSemaphoreCount;
        public IntPtr WaitSemaphores;
        public IntPtr WaitDstStageMask;
        public UInt32 CommandBufferCount;
        public IntPtr CommandBuffers;
        public UInt32 SignalSemaphoreCount;
        public IntPtr SignalSemaphores;
    }

    internal struct DisplayPropertiesKHR
    {
        public UInt64 Display;
        public IntPtr DisplayName;
        public Extent2D PhysicalDimensions;
        public Extent2D PhysicalResolution;
        public SurfaceTransformFlagsKHR SupportedTransforms;
        public Bool32 PlaneReorderPossible;
        public Bool32 PersistentContent;
    }

    internal struct DisplayPlanePropertiesKHR
    {
        public UInt64 CurrentDisplay;
        public UInt32 CurrentStackIndex;
    }

    internal struct DisplayModePropertiesKHR
    {
        public UInt64 DisplayMode;
        public DisplayModeParametersKHR Parameters;
    }

    internal struct DisplayModeCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public DisplayModeCreateFlagsKHR Flags;
        public DisplayModeParametersKHR Parameters;
    }

    internal struct DisplaySurfaceCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public DisplaySurfaceCreateFlagsKHR Flags;
        public UInt64 DisplayMode;
        public UInt32 PlaneIndex;
        public UInt32 PlaneStackIndex;
        public SurfaceTransformFlagsKHR Transform;
        public Single GlobalAlpha;
        public DisplayPlaneAlphaFlagsKHR AlphaMode;
        public Extent2D ImageExtent;
    }

    internal struct DisplayPresentInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public Rect2D SrcRect;
        public Rect2D DstRect;
        public Bool32 Persistent;
    }

    internal struct AndroidSurfaceCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public AndroidSurfaceCreateFlagsKHR Flags;
        public IntPtr Window;
    }

    internal struct MirSurfaceCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public MirSurfaceCreateFlagsKHR Flags;
        public IntPtr Connection;
        public IntPtr MirSurface;
    }

    internal struct WaylandSurfaceCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public WaylandSurfaceCreateFlagsKHR Flags;
        public IntPtr Display;
        public IntPtr Surface;
    }

    internal struct Win32SurfaceCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public Win32SurfaceCreateFlagsKHR Flags;
        public IntPtr Hinstance;
        public IntPtr Hwnd;
    }

    internal struct XlibSurfaceCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public XlibSurfaceCreateFlagsKHR Flags;
        public IntPtr Dpy;
        public IntPtr Window;
    }

    internal struct XcbSurfaceCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public XcbSurfaceCreateFlagsKHR Flags;
        public IntPtr Connection;
        public IntPtr Window;
    }

    internal struct SwapchainCreateInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public SwapchainCreateFlagsKHR Flags;
        public UInt64 Surface;
        public UInt32 MinImageCount;
        public Format ImageFormat;
        public ColorSpaceKHR ImageColorSpace;
        public Extent2D ImageExtent;
        public UInt32 ImageArrayLayers;
        public ImageUsageFlags ImageUsage;
        public SharingMode ImageSharingMode;
        public UInt32 QueueFamilyIndexCount;
        public IntPtr QueueFamilyIndices;
        public SurfaceTransformFlagsKHR PreTransform;
        public CompositeAlphaFlagsKHR CompositeAlpha;
        public PresentModeKHR PresentMode;
        public Bool32 Clipped;
        public UInt64 OldSwapchain;
    }

    internal struct PresentInfoKHR
    {
        public StructureType SType;
        public IntPtr Next;
        public UInt32 WaitSemaphoreCount;
        public IntPtr WaitSemaphores;
        public UInt32 SwapchainCount;
        public IntPtr Swapchains;
        public IntPtr ImageIndices;
        public IntPtr Results;
    }

    internal struct DebugReportCallbackCreateInfoEXT
    {
        public StructureType SType;
        public IntPtr Next;
        public DebugReportFlagsEXT Flags;
        public IntPtr PfnCallback;
        public IntPtr UserData;
    }

    internal struct PipelineRasterizationStateRasterizationOrderAMD
    {
        public StructureType SType;
        public IntPtr Next;
        public RasterizationOrderAMD RasterizationOrder;
    }

    internal struct DebugMarkerObjectNameInfoEXT
    {
        public StructureType SType;
        public IntPtr Next;
        public DebugReportObjectTypeEXT ObjectType;
        public UInt64 Object;
        public IntPtr ObjectName;
    }

    internal struct DebugMarkerObjectTagInfoEXT
    {
        public StructureType SType;
        public IntPtr Next;
        public DebugReportObjectTypeEXT ObjectType;
        public UInt64 Object;
        public UInt64 TagName;
        public UInt32 TagSize;
        public IntPtr Tag;
    }

    internal struct DebugMarkerMarkerInfoEXT
    {
        public StructureType SType;
        public IntPtr Next;
        public IntPtr MarkerName;
        public unsafe fixed Single Color[4];
    }

}
