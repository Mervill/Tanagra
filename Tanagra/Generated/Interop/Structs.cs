// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable InconsistentNaming
using System;

namespace Vulkan.Interop
{
    internal struct SampleMask
    {
    }

    internal struct ClearValue
    {
    }

    internal struct ClearColorValue
    {
    }

    internal struct Offset2D
    {
        internal Int32 X;
        internal Int32 Y;
    }

    internal struct Offset3D
    {
        internal Int32 X;
        internal Int32 Y;
        internal Int32 Z;
    }

    internal struct Extent2D
    {
        internal UInt32 Width;
        internal UInt32 Height;
    }

    internal struct Extent3D
    {
        internal UInt32 Width;
        internal UInt32 Height;
        internal UInt32 Depth;
    }

    internal struct Viewport
    {
        internal Single X;
        internal Single Y;
        internal Single Width;
        internal Single Height;
        internal Single MinDepth;
        internal Single MaxDepth;
    }

    internal struct Rect2D
    {
        internal IntPtr Offset;
        internal IntPtr Extent;
    }

    internal struct Rect3D
    {
        internal IntPtr Offset;
        internal IntPtr Extent;
    }

    internal struct ClearRect
    {
        internal IntPtr Rect;
        internal UInt32 BaseArrayLayer;
        internal UInt32 LayerCount;
    }

    internal struct ComponentMapping
    {
        internal ComponentSwizzle R;
        internal ComponentSwizzle G;
        internal ComponentSwizzle B;
        internal ComponentSwizzle A;
    }

    internal struct PhysicalDeviceProperties
    {
        internal UInt32 ApiVersion;
        internal UInt32 DriverVersion;
        internal UInt32 VendorID;
        internal UInt32 DeviceID;
        internal PhysicalDeviceType DeviceType;
        internal IntPtr DeviceName;
        internal Byte PipelineCacheUUID;
        internal IntPtr Limits;
        internal IntPtr SparseProperties;
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
        internal Single QueuePriorities;
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

    internal struct QueueFamilyProperties
    {
        internal QueueFlags QueueFlags;
        internal UInt32 QueueCount;
        internal UInt32 TimestampValidBits;
        internal IntPtr MinImageTransferGranularity;
    }

    internal struct PhysicalDeviceMemoryProperties
    {
        internal UInt32 MemoryTypeCount;
        internal IntPtr MemoryTypes;
        internal UInt32 MemoryHeapCount;
        internal IntPtr MemoryHeaps;
    }

    internal struct MemoryAllocateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DeviceSize AllocationSize;
        internal UInt32 MemoryTypeIndex;
    }

    internal struct MemoryRequirements
    {
        internal DeviceSize Size;
        internal DeviceSize Alignment;
        internal UInt32 MemoryTypeBits;
    }

    internal struct SparseImageFormatProperties
    {
        internal ImageAspectFlags AspectMask;
        internal IntPtr ImageGranularity;
        internal SparseImageFormatFlags Flags;
    }

    internal struct SparseImageMemoryRequirements
    {
        internal IntPtr FormatProperties;
        internal UInt32 ImageMipTailFirstLod;
        internal DeviceSize ImageMipTailSize;
        internal DeviceSize ImageMipTailOffset;
        internal DeviceSize ImageMipTailStride;
    }

    internal struct MemoryType
    {
        internal MemoryPropertyFlags PropertyFlags;
        internal UInt32 HeapIndex;
    }

    internal struct MemoryHeap
    {
        internal DeviceSize Size;
        internal MemoryHeapFlags Flags;
    }

    internal struct MappedMemoryRange
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal IntPtr Memory;
        internal DeviceSize Offset;
        internal DeviceSize Size;
    }

    internal struct FormatProperties
    {
        internal FormatFeatureFlags LinearTilingFeatures;
        internal FormatFeatureFlags OptimalTilingFeatures;
        internal FormatFeatureFlags BufferFeatures;
    }

    internal struct ImageFormatProperties
    {
        internal IntPtr MaxExtent;
        internal UInt32 MaxMipLevels;
        internal UInt32 MaxArrayLayers;
        internal SampleCountFlags SampleCounts;
        internal DeviceSize MaxResourceSize;
    }

    internal struct DescriptorBufferInfo
    {
        internal IntPtr Buffer;
        internal DeviceSize Offset;
        internal DeviceSize Range;
    }

    internal struct DescriptorImageInfo
    {
        internal IntPtr Sampler;
        internal IntPtr ImageView;
        internal ImageLayout ImageLayout;
    }

    internal struct WriteDescriptorSet
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal IntPtr DstSet;
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
        internal IntPtr SrcSet;
        internal UInt32 SrcBinding;
        internal UInt32 SrcArrayElement;
        internal IntPtr DstSet;
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
        internal UInt32 QueueFamilyIndices;
    }

    internal struct BufferViewCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal BufferViewCreateFlags Flags;
        internal IntPtr Buffer;
        internal Format Format;
        internal DeviceSize Offset;
        internal DeviceSize Range;
    }

    internal struct ImageSubresource
    {
        internal ImageAspectFlags AspectMask;
        internal UInt32 MipLevel;
        internal UInt32 ArrayLayer;
    }

    internal struct ImageSubresourceLayers
    {
        internal ImageAspectFlags AspectMask;
        internal UInt32 MipLevel;
        internal UInt32 BaseArrayLayer;
        internal UInt32 LayerCount;
    }

    internal struct ImageSubresourceRange
    {
        internal ImageAspectFlags AspectMask;
        internal UInt32 BaseMipLevel;
        internal UInt32 LevelCount;
        internal UInt32 BaseArrayLayer;
        internal UInt32 LayerCount;
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
        internal IntPtr Buffer;
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
        internal IntPtr Image;
        internal IntPtr SubresourceRange;
    }

    internal struct ImageCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal ImageCreateFlags Flags;
        internal ImageType ImageType;
        internal Format Format;
        internal IntPtr Extent;
        internal UInt32 MipLevels;
        internal UInt32 ArrayLayers;
        internal SampleCountFlags Samples;
        internal ImageTiling Tiling;
        internal ImageUsageFlags Usage;
        internal SharingMode SharingMode;
        internal UInt32 QueueFamilyIndexCount;
        internal UInt32 QueueFamilyIndices;
        internal ImageLayout InitialLayout;
    }

    internal struct SubresourceLayout
    {
        internal DeviceSize Offset;
        internal DeviceSize Size;
        internal DeviceSize RowPitch;
        internal DeviceSize ArrayPitch;
        internal DeviceSize DepthPitch;
    }

    internal struct ImageViewCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal ImageViewCreateFlags Flags;
        internal IntPtr Image;
        internal ImageViewType ViewType;
        internal Format Format;
        internal IntPtr Components;
        internal IntPtr SubresourceRange;
    }

    internal struct BufferCopy
    {
        internal DeviceSize SrcOffset;
        internal DeviceSize DstOffset;
        internal DeviceSize Size;
    }

    internal struct SparseMemoryBind
    {
        internal DeviceSize ResourceOffset;
        internal DeviceSize Size;
        internal IntPtr Memory;
        internal DeviceSize MemoryOffset;
        internal SparseMemoryBindFlags Flags;
    }

    internal struct SparseImageMemoryBind
    {
        internal IntPtr Subresource;
        internal IntPtr Offset;
        internal IntPtr Extent;
        internal IntPtr Memory;
        internal DeviceSize MemoryOffset;
        internal SparseMemoryBindFlags Flags;
    }

    internal struct SparseBufferMemoryBindInfo
    {
        internal IntPtr Buffer;
        internal UInt32 BindCount;
        internal IntPtr Binds;
    }

    internal struct SparseImageOpaqueMemoryBindInfo
    {
        internal IntPtr Image;
        internal UInt32 BindCount;
        internal IntPtr Binds;
    }

    internal struct SparseImageMemoryBindInfo
    {
        internal IntPtr Image;
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

    internal struct ImageCopy
    {
        internal IntPtr SrcSubresource;
        internal IntPtr SrcOffset;
        internal IntPtr DstSubresource;
        internal IntPtr DstOffset;
        internal IntPtr Extent;
    }

    internal struct ImageBlit
    {
        internal IntPtr SrcSubresource;
        internal IntPtr SrcOffsets;
        internal IntPtr DstSubresource;
        internal IntPtr DstOffsets;
    }

    internal struct BufferImageCopy
    {
        internal DeviceSize BufferOffset;
        internal UInt32 BufferRowLength;
        internal UInt32 BufferImageHeight;
        internal IntPtr ImageSubresource;
        internal IntPtr ImageOffset;
        internal IntPtr ImageExtent;
    }

    internal struct ImageResolve
    {
        internal IntPtr SrcSubresource;
        internal IntPtr SrcOffset;
        internal IntPtr DstSubresource;
        internal IntPtr DstOffset;
        internal IntPtr Extent;
    }

    internal struct ShaderModuleCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal ShaderModuleCreateFlags Flags;
        internal UIntPtr CodeSize;
        internal UInt32 Code;
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

    internal struct DescriptorPoolSize
    {
        internal DescriptorType Type;
        internal UInt32 DescriptorCount;
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
        internal IntPtr DescriptorPool;
        internal UInt32 DescriptorSetCount;
        internal IntPtr SetLayouts;
    }

    internal struct SpecializationMapEntry
    {
        internal UInt32 ConstantID;
        internal UInt32 Offset;
        internal UIntPtr Size;
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
        internal IntPtr Module;
        internal IntPtr Name;
        internal IntPtr SpecializationInfo;
    }

    internal struct ComputePipelineCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineCreateFlags Flags;
        internal IntPtr Stage;
        internal IntPtr Layout;
        internal IntPtr BasePipelineHandle;
        internal Int32 BasePipelineIndex;
    }

    internal struct VertexInputBindingDescription
    {
        internal UInt32 Binding;
        internal UInt32 Stride;
        internal VertexInputRate InputRate;
    }

    internal struct VertexInputAttributeDescription
    {
        internal UInt32 Location;
        internal UInt32 Binding;
        internal Format Format;
        internal UInt32 Offset;
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
        internal Boolean PrimitiveRestartEnable;
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
        internal Boolean DepthClampEnable;
        internal Boolean RasterizerDiscardEnable;
        internal PolygonMode PolygonMode;
        internal CullModeFlags CullMode;
        internal FrontFace FrontFace;
        internal Boolean DepthBiasEnable;
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
        internal Boolean SampleShadingEnable;
        internal Single MinSampleShading;
        internal IntPtr SampleMask;
        internal Boolean AlphaToCoverageEnable;
        internal Boolean AlphaToOneEnable;
    }

    internal struct PipelineColorBlendAttachmentState
    {
        internal Boolean BlendEnable;
        internal BlendFactor SrcColorBlendFactor;
        internal BlendFactor DstColorBlendFactor;
        internal BlendOp ColorBlendOp;
        internal BlendFactor SrcAlphaBlendFactor;
        internal BlendFactor DstAlphaBlendFactor;
        internal BlendOp AlphaBlendOp;
        internal ColorComponentFlags ColorWriteMask;
    }

    internal struct PipelineColorBlendStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineColorBlendStateCreateFlags Flags;
        internal Boolean LogicOpEnable;
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
        internal DynamicState DynamicStates;
    }

    internal struct StencilOpState
    {
        internal StencilOp FailOp;
        internal StencilOp PassOp;
        internal StencilOp DepthFailOp;
        internal CompareOp CompareOp;
        internal UInt32 CompareMask;
        internal UInt32 WriteMask;
        internal UInt32 Reference;
    }

    internal struct PipelineDepthStencilStateCreateInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal PipelineDepthStencilStateCreateFlags Flags;
        internal Boolean DepthTestEnable;
        internal Boolean DepthWriteEnable;
        internal CompareOp DepthCompareOp;
        internal Boolean DepthBoundsTestEnable;
        internal Boolean StencilTestEnable;
        internal IntPtr Front;
        internal IntPtr Back;
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
        internal IntPtr Layout;
        internal IntPtr RenderPass;
        internal UInt32 Subpass;
        internal IntPtr BasePipelineHandle;
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

    internal struct PushConstantRange
    {
        internal ShaderStageFlags StageFlags;
        internal UInt32 Offset;
        internal UInt32 Size;
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
        internal Boolean AnisotropyEnable;
        internal Single MaxAnisotropy;
        internal Boolean CompareEnable;
        internal CompareOp CompareOp;
        internal Single MinLod;
        internal Single MaxLod;
        internal BorderColor BorderColor;
        internal Boolean UnnormalizedCoordinates;
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
        internal IntPtr CommandPool;
        internal CommandBufferLevel Level;
        internal UInt32 CommandBufferCount;
    }

    internal struct CommandBufferInheritanceInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal IntPtr RenderPass;
        internal UInt32 Subpass;
        internal IntPtr Framebuffer;
        internal Boolean OcclusionQueryEnable;
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
        internal IntPtr RenderPass;
        internal IntPtr Framebuffer;
        internal IntPtr RenderArea;
        internal UInt32 ClearValueCount;
        internal IntPtr ClearValues;
    }

    internal struct ClearDepthStencilValue
    {
        internal Single Depth;
        internal UInt32 Stencil;
    }

    internal struct ClearAttachment
    {
        internal ImageAspectFlags AspectMask;
        internal UInt32 ColorAttachment;
        internal IntPtr ClearValue;
    }

    internal struct AttachmentDescription
    {
        internal AttachmentDescriptionFlags Flags;
        internal Format Format;
        internal SampleCountFlags Samples;
        internal AttachmentLoadOp LoadOp;
        internal AttachmentStoreOp StoreOp;
        internal AttachmentLoadOp StencilLoadOp;
        internal AttachmentStoreOp StencilStoreOp;
        internal ImageLayout InitialLayout;
        internal ImageLayout FinalLayout;
    }

    internal struct AttachmentReference
    {
        internal UInt32 Attachment;
        internal ImageLayout Layout;
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
        internal UInt32 PreserveAttachments;
    }

    internal struct SubpassDependency
    {
        internal UInt32 SrcSubpass;
        internal UInt32 DstSubpass;
        internal PipelineStageFlags SrcStageMask;
        internal PipelineStageFlags DstStageMask;
        internal AccessFlags SrcAccessMask;
        internal AccessFlags DstAccessMask;
        internal DependencyFlags DependencyFlags;
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

    internal struct PhysicalDeviceFeatures
    {
        internal Boolean RobustBufferAccess;
        internal Boolean FullDrawIndexUint32;
        internal Boolean ImageCubeArray;
        internal Boolean IndependentBlend;
        internal Boolean GeometryShader;
        internal Boolean TessellationShader;
        internal Boolean SampleRateShading;
        internal Boolean DualSrcBlend;
        internal Boolean LogicOp;
        internal Boolean MultiDrawIndirect;
        internal Boolean DrawIndirectFirstInstance;
        internal Boolean DepthClamp;
        internal Boolean DepthBiasClamp;
        internal Boolean FillModeNonSolid;
        internal Boolean DepthBounds;
        internal Boolean WideLines;
        internal Boolean LargePoints;
        internal Boolean AlphaToOne;
        internal Boolean MultiViewport;
        internal Boolean SamplerAnisotropy;
        internal Boolean TextureCompressionETC2;
        internal Boolean TextureCompressionASTC_LDR;
        internal Boolean TextureCompressionBC;
        internal Boolean OcclusionQueryPrecise;
        internal Boolean PipelineStatisticsQuery;
        internal Boolean VertexPipelineStoresAndAtomics;
        internal Boolean FragmentStoresAndAtomics;
        internal Boolean ShaderTessellationAndGeometryPointSize;
        internal Boolean ShaderImageGatherExtended;
        internal Boolean ShaderStorageImageExtendedFormats;
        internal Boolean ShaderStorageImageMultisample;
        internal Boolean ShaderStorageImageReadWithoutFormat;
        internal Boolean ShaderStorageImageWriteWithoutFormat;
        internal Boolean ShaderUniformBufferArrayDynamicIndexing;
        internal Boolean ShaderSampledImageArrayDynamicIndexing;
        internal Boolean ShaderStorageBufferArrayDynamicIndexing;
        internal Boolean ShaderStorageImageArrayDynamicIndexing;
        internal Boolean ShaderClipDistance;
        internal Boolean ShaderCullDistance;
        internal Boolean ShaderFloat64;
        internal Boolean ShaderInt64;
        internal Boolean ShaderInt16;
        internal Boolean ShaderResourceResidency;
        internal Boolean ShaderResourceMinLod;
        internal Boolean SparseBinding;
        internal Boolean SparseResidencyBuffer;
        internal Boolean SparseResidencyImage2D;
        internal Boolean SparseResidencyImage3D;
        internal Boolean SparseResidency2Samples;
        internal Boolean SparseResidency4Samples;
        internal Boolean SparseResidency8Samples;
        internal Boolean SparseResidency16Samples;
        internal Boolean SparseResidencyAliased;
        internal Boolean VariableMultisampleRate;
        internal Boolean InheritedQueries;
    }

    internal struct PhysicalDeviceSparseProperties
    {
        internal Boolean ResidencyStandard2DBlockShape;
        internal Boolean ResidencyStandard2DMultisampleBlockShape;
        internal Boolean ResidencyStandard3DBlockShape;
        internal Boolean ResidencyAlignedMipSize;
        internal Boolean ResidencyNonResidentStrict;
    }

    internal struct PhysicalDeviceLimits
    {
        internal UInt32 MaxImageDimension1D;
        internal UInt32 MaxImageDimension2D;
        internal UInt32 MaxImageDimension3D;
        internal UInt32 MaxImageDimensionCube;
        internal UInt32 MaxImageArrayLayers;
        internal UInt32 MaxTexelBufferElements;
        internal UInt32 MaxUniformBufferRange;
        internal UInt32 MaxStorageBufferRange;
        internal UInt32 MaxPushConstantsSize;
        internal UInt32 MaxMemoryAllocationCount;
        internal UInt32 MaxSamplerAllocationCount;
        internal DeviceSize BufferImageGranularity;
        internal DeviceSize SparseAddressSpaceSize;
        internal UInt32 MaxBoundDescriptorSets;
        internal UInt32 MaxPerStageDescriptorSamplers;
        internal UInt32 MaxPerStageDescriptorUniformBuffers;
        internal UInt32 MaxPerStageDescriptorStorageBuffers;
        internal UInt32 MaxPerStageDescriptorSampledImages;
        internal UInt32 MaxPerStageDescriptorStorageImages;
        internal UInt32 MaxPerStageDescriptorInputAttachments;
        internal UInt32 MaxPerStageResources;
        internal UInt32 MaxDescriptorSetSamplers;
        internal UInt32 MaxDescriptorSetUniformBuffers;
        internal UInt32 MaxDescriptorSetUniformBuffersDynamic;
        internal UInt32 MaxDescriptorSetStorageBuffers;
        internal UInt32 MaxDescriptorSetStorageBuffersDynamic;
        internal UInt32 MaxDescriptorSetSampledImages;
        internal UInt32 MaxDescriptorSetStorageImages;
        internal UInt32 MaxDescriptorSetInputAttachments;
        internal UInt32 MaxVertexInputAttributes;
        internal UInt32 MaxVertexInputBindings;
        internal UInt32 MaxVertexInputAttributeOffset;
        internal UInt32 MaxVertexInputBindingStride;
        internal UInt32 MaxVertexOutputComponents;
        internal UInt32 MaxTessellationGenerationLevel;
        internal UInt32 MaxTessellationPatchSize;
        internal UInt32 MaxTessellationControlPerVertexInputComponents;
        internal UInt32 MaxTessellationControlPerVertexOutputComponents;
        internal UInt32 MaxTessellationControlPerPatchOutputComponents;
        internal UInt32 MaxTessellationControlTotalOutputComponents;
        internal UInt32 MaxTessellationEvaluationInputComponents;
        internal UInt32 MaxTessellationEvaluationOutputComponents;
        internal UInt32 MaxGeometryShaderInvocations;
        internal UInt32 MaxGeometryInputComponents;
        internal UInt32 MaxGeometryOutputComponents;
        internal UInt32 MaxGeometryOutputVertices;
        internal UInt32 MaxGeometryTotalOutputComponents;
        internal UInt32 MaxFragmentInputComponents;
        internal UInt32 MaxFragmentOutputAttachments;
        internal UInt32 MaxFragmentDualSrcAttachments;
        internal UInt32 MaxFragmentCombinedOutputResources;
        internal UInt32 MaxComputeSharedMemorySize;
        internal UInt32 MaxComputeWorkGroupCount;
        internal UInt32 MaxComputeWorkGroupInvocations;
        internal UInt32 MaxComputeWorkGroupSize;
        internal UInt32 SubPixelPrecisionBits;
        internal UInt32 SubTexelPrecisionBits;
        internal UInt32 MipmapPrecisionBits;
        internal UInt32 MaxDrawIndexedIndexValue;
        internal UInt32 MaxDrawIndirectCount;
        internal Single MaxSamplerLodBias;
        internal Single MaxSamplerAnisotropy;
        internal UInt32 MaxViewports;
        internal UInt32 MaxViewportDimensions;
        internal Single ViewportBoundsRange;
        internal UInt32 ViewportSubPixelBits;
        internal UIntPtr MinMemoryMapAlignment;
        internal DeviceSize MinTexelBufferOffsetAlignment;
        internal DeviceSize MinUniformBufferOffsetAlignment;
        internal DeviceSize MinStorageBufferOffsetAlignment;
        internal Int32 MinTexelOffset;
        internal UInt32 MaxTexelOffset;
        internal Int32 MinTexelGatherOffset;
        internal UInt32 MaxTexelGatherOffset;
        internal Single MinInterpolationOffset;
        internal Single MaxInterpolationOffset;
        internal UInt32 SubPixelInterpolationOffsetBits;
        internal UInt32 MaxFramebufferWidth;
        internal UInt32 MaxFramebufferHeight;
        internal UInt32 MaxFramebufferLayers;
        internal SampleCountFlags FramebufferColorSampleCounts;
        internal SampleCountFlags FramebufferDepthSampleCounts;
        internal SampleCountFlags FramebufferStencilSampleCounts;
        internal SampleCountFlags FramebufferNoAttachmentsSampleCounts;
        internal UInt32 MaxColorAttachments;
        internal SampleCountFlags SampledImageColorSampleCounts;
        internal SampleCountFlags SampledImageIntegerSampleCounts;
        internal SampleCountFlags SampledImageDepthSampleCounts;
        internal SampleCountFlags SampledImageStencilSampleCounts;
        internal SampleCountFlags StorageImageSampleCounts;
        internal UInt32 MaxSampleMaskWords;
        internal Boolean TimestampComputeAndGraphics;
        internal Single TimestampPeriod;
        internal UInt32 MaxClipDistances;
        internal UInt32 MaxCullDistances;
        internal UInt32 MaxCombinedClipAndCullDistances;
        internal UInt32 DiscreteQueuePriorities;
        internal Single PointSizeRange;
        internal Single LineWidthRange;
        internal Single PointSizeGranularity;
        internal Single LineWidthGranularity;
        internal Boolean StrictLines;
        internal Boolean StandardSampleLocations;
        internal DeviceSize OptimalBufferCopyOffsetAlignment;
        internal DeviceSize OptimalBufferCopyRowPitchAlignment;
        internal DeviceSize NonCoherentAtomSize;
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
        internal IntPtr RenderPass;
        internal UInt32 AttachmentCount;
        internal IntPtr Attachments;
        internal UInt32 Width;
        internal UInt32 Height;
        internal UInt32 Layers;
    }

    internal struct DrawIndirectCommand
    {
        internal UInt32 VertexCount;
        internal UInt32 InstanceCount;
        internal UInt32 FirstVertex;
        internal UInt32 FirstInstance;
    }

    internal struct DrawIndexedIndirectCommand
    {
        internal UInt32 IndexCount;
        internal UInt32 InstanceCount;
        internal UInt32 FirstIndex;
        internal Int32 VertexOffset;
        internal UInt32 FirstInstance;
    }

    internal struct DispatchIndirectCommand
    {
        internal UInt32 X;
        internal UInt32 Y;
        internal UInt32 Z;
    }

    internal struct SubmitInfo
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt32 WaitSemaphoreCount;
        internal IntPtr WaitSemaphores;
        internal PipelineStageFlags WaitDstStageMask;
        internal UInt32 CommandBufferCount;
        internal IntPtr CommandBuffers;
        internal UInt32 SignalSemaphoreCount;
        internal IntPtr SignalSemaphores;
    }

    internal struct DisplayPropertiesKHR
    {
        internal IntPtr Display;
        internal IntPtr DisplayName;
        internal IntPtr PhysicalDimensions;
        internal IntPtr PhysicalResolution;
        internal SurfaceTransformFlags SupportedTransforms;
        internal Boolean PlaneReorderPossible;
        internal Boolean PersistentContent;
    }

    internal struct DisplayPlanePropertiesKHR
    {
        internal IntPtr CurrentDisplay;
        internal UInt32 CurrentStackIndex;
    }

    internal struct DisplayModeParametersKHR
    {
        internal IntPtr VisibleRegion;
        internal UInt32 RefreshRate;
    }

    internal struct DisplayModePropertiesKHR
    {
        internal IntPtr DisplayMode;
        internal IntPtr Parameters;
    }

    internal struct DisplayModeCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DisplayModeCreateFlags Flags;
        internal IntPtr Parameters;
    }

    internal struct DisplayPlaneCapabilitiesKHR
    {
        internal DisplayPlaneAlphaFlags SupportedAlpha;
        internal IntPtr MinSrcPosition;
        internal IntPtr MaxSrcPosition;
        internal IntPtr MinSrcExtent;
        internal IntPtr MaxSrcExtent;
        internal IntPtr MinDstPosition;
        internal IntPtr MaxDstPosition;
        internal IntPtr MinDstExtent;
        internal IntPtr MaxDstExtent;
    }

    internal struct DisplaySurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DisplaySurfaceCreateFlags Flags;
        internal IntPtr DisplayMode;
        internal UInt32 PlaneIndex;
        internal UInt32 PlaneStackIndex;
        internal SurfaceTransformFlags Transform;
        internal Single GlobalAlpha;
        internal DisplayPlaneAlphaFlags AlphaMode;
        internal IntPtr ImageExtent;
    }

    internal struct DisplayPresentInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal IntPtr SrcRect;
        internal IntPtr DstRect;
        internal Boolean Persistent;
    }

    internal struct SurfaceCapabilitiesKHR
    {
        internal UInt32 MinImageCount;
        internal UInt32 MaxImageCount;
        internal IntPtr CurrentExtent;
        internal IntPtr MinImageExtent;
        internal IntPtr MaxImageExtent;
        internal UInt32 MaxImageArrayLayers;
        internal SurfaceTransformFlags SupportedTransforms;
        internal SurfaceTransformFlags CurrentTransform;
        internal CompositeAlphaFlags SupportedCompositeAlpha;
        internal ImageUsageFlags SupportedUsageFlags;
    }

    internal struct AndroidSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal AndroidSurfaceCreateFlags Flags;
        internal IntPtr Window;
    }

    internal struct MirSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal MirSurfaceCreateFlags Flags;
        internal IntPtr Connection;
        internal IntPtr MirSurface;
    }

    internal struct WaylandSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal WaylandSurfaceCreateFlags Flags;
        internal IntPtr Display;
        internal IntPtr Surface;
    }

    internal struct Win32SurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal Win32SurfaceCreateFlags Flags;
        internal IntPtr Hinstance;
        internal IntPtr Hwnd;
    }

    internal struct XlibSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal XlibSurfaceCreateFlags Flags;
        internal IntPtr Dpy;
        internal IntPtr Window;
    }

    internal struct XcbSurfaceCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal XcbSurfaceCreateFlags Flags;
        internal IntPtr Connection;
        internal IntPtr Window;
    }

    internal struct SurfaceFormatKHR
    {
        internal Format Format;
        internal ColorSpace ColorSpace;
    }

    internal struct SwapchainCreateInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal SwapchainCreateFlags Flags;
        internal IntPtr Surface;
        internal UInt32 MinImageCount;
        internal Format ImageFormat;
        internal ColorSpace ImageColorSpace;
        internal IntPtr ImageExtent;
        internal UInt32 ImageArrayLayers;
        internal ImageUsageFlags ImageUsage;
        internal SharingMode ImageSharingMode;
        internal UInt32 QueueFamilyIndexCount;
        internal UInt32 QueueFamilyIndices;
        internal SurfaceTransformFlags PreTransform;
        internal CompositeAlphaFlags CompositeAlpha;
        internal PresentMode PresentMode;
        internal Boolean Clipped;
        internal IntPtr OldSwapchain;
    }

    internal struct PresentInfoKHR
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal UInt32 WaitSemaphoreCount;
        internal IntPtr WaitSemaphores;
        internal UInt32 SwapchainCount;
        internal IntPtr Swapchains;
        internal UInt32 ImageIndices;
        internal Result Results;
    }

    internal struct DebugReportCallbackCreateInfoEXT
    {
        internal StructureType SType;
        internal IntPtr Next;
        internal DebugReportFlagsEXT Flags;
        internal IntPtr PfnCallback;
        internal IntPtr UserData;
    }

}
