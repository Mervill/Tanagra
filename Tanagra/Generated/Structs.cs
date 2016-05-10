// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable InconsistentNaming
using System;

namespace Vulkan
{
    public struct SampleMask
    {
    }

    public struct ClearValue
    {
    }

    public struct ClearColorValue
    {
    }

    public struct Offset2D
    {
        public Int32 X;
        public Int32 Y;
    }

    public struct Offset3D
    {
        public Int32 X;
        public Int32 Y;
        public Int32 Z;
    }

    public struct Extent2D
    {
        public UInt32 Width;
        public UInt32 Height;
    }

    public struct Extent3D
    {
        public UInt32 Width;
        public UInt32 Height;
        public UInt32 Depth;
    }

    public struct Viewport
    {
        public Single X;
        public Single Y;
        public Single Width;
        public Single Height;
        public Single MinDepth;
        public Single MaxDepth;
    }

    public struct Rect2D
    {
        public Offset2D Offset;
        public Extent2D Extent;
    }

    public struct Rect3D
    {
        public Offset3D Offset;
        public Extent3D Extent;
    }

    public struct ClearRect
    {
        public Rect2D Rect;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
    }

    public struct ComponentMapping
    {
        public ComponentSwizzle R;
        public ComponentSwizzle G;
        public ComponentSwizzle B;
        public ComponentSwizzle A;
    }

    public struct QueueFamilyProperties
    {
        public QueueFlags QueueFlags;
        public UInt32 QueueCount;
        public UInt32 TimestampValidBits;
        public Extent3D MinImageTransferGranularity;
    }

    public struct PhysicalDeviceMemoryProperties
    {
        public UInt32 MemoryTypeCount;
        public MemoryType MemoryTypes;
        public UInt32 MemoryHeapCount;
        public MemoryHeap MemoryHeaps;
    }

    public struct MemoryRequirements
    {
        public DeviceSize Size;
        public DeviceSize Alignment;
        public UInt32 MemoryTypeBits;
    }

    public struct SparseImageFormatProperties
    {
        public ImageAspectFlags AspectMask;
        public Extent3D ImageGranularity;
        public SparseImageFormatFlags Flags;
    }

    public struct SparseImageMemoryRequirements
    {
        public SparseImageFormatProperties FormatProperties;
        public UInt32 ImageMipTailFirstLod;
        public DeviceSize ImageMipTailSize;
        public DeviceSize ImageMipTailOffset;
        public DeviceSize ImageMipTailStride;
    }

    public struct MemoryType
    {
        public MemoryPropertyFlags PropertyFlags;
        public UInt32 HeapIndex;
    }

    public struct MemoryHeap
    {
        public DeviceSize Size;
        public MemoryHeapFlags Flags;
    }

    public struct FormatProperties
    {
        public FormatFeatureFlags LinearTilingFeatures;
        public FormatFeatureFlags OptimalTilingFeatures;
        public FormatFeatureFlags BufferFeatures;
    }

    public struct ImageFormatProperties
    {
        public Extent3D MaxExtent;
        public UInt32 MaxMipLevels;
        public UInt32 MaxArrayLayers;
        public SampleCountFlags SampleCounts;
        public DeviceSize MaxResourceSize;
    }

    public struct DescriptorBufferInfo
    {
        public UInt64 Buffer;
        public DeviceSize Offset;
        public DeviceSize Range;
    }

    public struct DescriptorImageInfo
    {
        public UInt64 Sampler;
        public UInt64 ImageView;
        public ImageLayout ImageLayout;
    }

    public struct ImageSubresource
    {
        public ImageAspectFlags AspectMask;
        public UInt32 MipLevel;
        public UInt32 ArrayLayer;
    }

    public struct ImageSubresourceLayers
    {
        public ImageAspectFlags AspectMask;
        public UInt32 MipLevel;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
    }

    public struct ImageSubresourceRange
    {
        public ImageAspectFlags AspectMask;
        public UInt32 BaseMipLevel;
        public UInt32 LevelCount;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
    }

    public struct SubresourceLayout
    {
        public DeviceSize Offset;
        public DeviceSize Size;
        public DeviceSize RowPitch;
        public DeviceSize ArrayPitch;
        public DeviceSize DepthPitch;
    }

    public struct BufferCopy
    {
        public DeviceSize SrcOffset;
        public DeviceSize DstOffset;
        public DeviceSize Size;
    }

    public struct SparseMemoryBind
    {
        public DeviceSize ResourceOffset;
        public DeviceSize Size;
        public UInt64 Memory;
        public DeviceSize MemoryOffset;
        public SparseMemoryBindFlags Flags;
    }

    public struct SparseImageMemoryBind
    {
        public ImageSubresource Subresource;
        public Offset3D Offset;
        public Extent3D Extent;
        public UInt64 Memory;
        public DeviceSize MemoryOffset;
        public SparseMemoryBindFlags Flags;
    }

    public struct ImageCopy
    {
        public ImageSubresourceLayers SrcSubresource;
        public Offset3D SrcOffset;
        public ImageSubresourceLayers DstSubresource;
        public Offset3D DstOffset;
        public Extent3D Extent;
    }

    public struct ImageBlit
    {
        public ImageSubresourceLayers SrcSubresource;
        public Offset3D SrcOffsets;
        public ImageSubresourceLayers DstSubresource;
        public Offset3D DstOffsets;
    }

    public struct BufferImageCopy
    {
        public DeviceSize BufferOffset;
        public UInt32 BufferRowLength;
        public UInt32 BufferImageHeight;
        public ImageSubresourceLayers ImageSubresource;
        public Offset3D ImageOffset;
        public Extent3D ImageExtent;
    }

    public struct ImageResolve
    {
        public ImageSubresourceLayers SrcSubresource;
        public Offset3D SrcOffset;
        public ImageSubresourceLayers DstSubresource;
        public Offset3D DstOffset;
        public Extent3D Extent;
    }

    public struct DescriptorPoolSize
    {
        public DescriptorType Type;
        public UInt32 DescriptorCount;
    }

    public struct SpecializationMapEntry
    {
        public UInt32 ConstantID;
        public UInt32 Offset;
        public UIntPtr Size;
    }

    public struct VertexInputBindingDescription
    {
        public UInt32 Binding;
        public UInt32 Stride;
        public VertexInputRate InputRate;
    }

    public struct VertexInputAttributeDescription
    {
        public UInt32 Location;
        public UInt32 Binding;
        public Format Format;
        public UInt32 Offset;
    }

    public struct PipelineColorBlendAttachmentState
    {
        public Bool32 BlendEnable;
        public BlendFactor SrcColorBlendFactor;
        public BlendFactor DstColorBlendFactor;
        public BlendOp ColorBlendOp;
        public BlendFactor SrcAlphaBlendFactor;
        public BlendFactor DstAlphaBlendFactor;
        public BlendOp AlphaBlendOp;
        public ColorComponentFlags ColorWriteMask;
    }

    public struct StencilOpState
    {
        public StencilOp FailOp;
        public StencilOp PassOp;
        public StencilOp DepthFailOp;
        public CompareOp CompareOp;
        public UInt32 CompareMask;
        public UInt32 WriteMask;
        public UInt32 Reference;
    }

    public struct PushConstantRange
    {
        public ShaderStageFlags StageFlags;
        public UInt32 Offset;
        public UInt32 Size;
    }

    public struct ClearDepthStencilValue
    {
        public Single Depth;
        public UInt32 Stencil;
    }

    public struct ClearAttachment
    {
        public ImageAspectFlags AspectMask;
        public UInt32 ColorAttachment;
        public ClearValue ClearValue;
    }

    public struct AttachmentDescription
    {
        public AttachmentDescriptionFlags Flags;
        public Format Format;
        public SampleCountFlags Samples;
        public AttachmentLoadOp LoadOp;
        public AttachmentStoreOp StoreOp;
        public AttachmentLoadOp StencilLoadOp;
        public AttachmentStoreOp StencilStoreOp;
        public ImageLayout InitialLayout;
        public ImageLayout FinalLayout;
    }

    public struct AttachmentReference
    {
        public UInt32 Attachment;
        public ImageLayout Layout;
    }

    public struct SubpassDependency
    {
        public UInt32 SrcSubpass;
        public UInt32 DstSubpass;
        public PipelineStageFlags SrcStageMask;
        public PipelineStageFlags DstStageMask;
        public AccessFlags SrcAccessMask;
        public AccessFlags DstAccessMask;
        public DependencyFlags DependencyFlags;
    }

    public struct PhysicalDeviceFeatures
    {
        public Bool32 RobustBufferAccess;
        public Bool32 FullDrawIndexUint32;
        public Bool32 ImageCubeArray;
        public Bool32 IndependentBlend;
        public Bool32 GeometryShader;
        public Bool32 TessellationShader;
        public Bool32 SampleRateShading;
        public Bool32 DualSrcBlend;
        public Bool32 LogicOp;
        public Bool32 MultiDrawIndirect;
        public Bool32 DrawIndirectFirstInstance;
        public Bool32 DepthClamp;
        public Bool32 DepthBiasClamp;
        public Bool32 FillModeNonSolid;
        public Bool32 DepthBounds;
        public Bool32 WideLines;
        public Bool32 LargePoints;
        public Bool32 AlphaToOne;
        public Bool32 MultiViewport;
        public Bool32 SamplerAnisotropy;
        public Bool32 TextureCompressionETC2;
        public Bool32 TextureCompressionASTC_LDR;
        public Bool32 TextureCompressionBC;
        public Bool32 OcclusionQueryPrecise;
        public Bool32 PipelineStatisticsQuery;
        public Bool32 VertexPipelineStoresAndAtomics;
        public Bool32 FragmentStoresAndAtomics;
        public Bool32 ShaderTessellationAndGeometryPointSize;
        public Bool32 ShaderImageGatherExtended;
        public Bool32 ShaderStorageImageExtendedFormats;
        public Bool32 ShaderStorageImageMultisample;
        public Bool32 ShaderStorageImageReadWithoutFormat;
        public Bool32 ShaderStorageImageWriteWithoutFormat;
        public Bool32 ShaderUniformBufferArrayDynamicIndexing;
        public Bool32 ShaderSampledImageArrayDynamicIndexing;
        public Bool32 ShaderStorageBufferArrayDynamicIndexing;
        public Bool32 ShaderStorageImageArrayDynamicIndexing;
        public Bool32 ShaderClipDistance;
        public Bool32 ShaderCullDistance;
        public Bool32 ShaderFloat64;
        public Bool32 ShaderInt64;
        public Bool32 ShaderInt16;
        public Bool32 ShaderResourceResidency;
        public Bool32 ShaderResourceMinLod;
        public Bool32 SparseBinding;
        public Bool32 SparseResidencyBuffer;
        public Bool32 SparseResidencyImage2D;
        public Bool32 SparseResidencyImage3D;
        public Bool32 SparseResidency2Samples;
        public Bool32 SparseResidency4Samples;
        public Bool32 SparseResidency8Samples;
        public Bool32 SparseResidency16Samples;
        public Bool32 SparseResidencyAliased;
        public Bool32 VariableMultisampleRate;
        public Bool32 InheritedQueries;
    }

    public struct PhysicalDeviceSparseProperties
    {
        public Bool32 ResidencyStandard2DBlockShape;
        public Bool32 ResidencyStandard2DMultisampleBlockShape;
        public Bool32 ResidencyStandard3DBlockShape;
        public Bool32 ResidencyAlignedMipSize;
        public Bool32 ResidencyNonResidentStrict;
    }

    public struct PhysicalDeviceLimits
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
        public unsafe fixed uint MaxComputeWorkGroupCount[3];
        public UInt32 MaxComputeWorkGroupInvocations;
        public unsafe fixed uint MaxComputeWorkGroupSize[3];
        public UInt32 SubPixelPrecisionBits;
        public UInt32 SubTexelPrecisionBits;
        public UInt32 MipmapPrecisionBits;
        public UInt32 MaxDrawIndexedIndexValue;
        public UInt32 MaxDrawIndirectCount;
        public Single MaxSamplerLodBias;
        public Single MaxSamplerAnisotropy;
        public UInt32 MaxViewports;
        public unsafe fixed uint MaxViewportDimensions[2];
        public unsafe fixed float ViewportBoundsRange[2];
        public UInt32 ViewportSubPixelBits;
        public UIntPtr MinMemoryMapAlignment;
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

    public struct DrawIndirectCommand
    {
        public UInt32 VertexCount;
        public UInt32 InstanceCount;
        public UInt32 FirstVertex;
        public UInt32 FirstInstance;
    }

    public struct DrawIndexedIndirectCommand
    {
        public UInt32 IndexCount;
        public UInt32 InstanceCount;
        public UInt32 FirstIndex;
        public Int32 VertexOffset;
        public UInt32 FirstInstance;
    }

    public struct DispatchIndirectCommand
    {
        public UInt32 X;
        public UInt32 Y;
        public UInt32 Z;
    }

    public struct DisplayPlanePropertiesKHR
    {
        public UInt64 CurrentDisplay;
        public UInt32 CurrentStackIndex;
    }

    public struct DisplayModeParametersKHR
    {
        public Extent2D VisibleRegion;
        public UInt32 RefreshRate;
    }

    public struct DisplayModePropertiesKHR
    {
        public UInt64 DisplayMode;
        public DisplayModeParametersKHR Parameters;
    }

    public struct DisplayPlaneCapabilitiesKHR
    {
        public DisplayPlaneAlphaFlagsKHR SupportedAlpha;
        public Offset2D MinSrcPosition;
        public Offset2D MaxSrcPosition;
        public Extent2D MinSrcExtent;
        public Extent2D MaxSrcExtent;
        public Offset2D MinDstPosition;
        public Offset2D MaxDstPosition;
        public Extent2D MinDstExtent;
        public Extent2D MaxDstExtent;
    }

    public struct SurfaceCapabilitiesKHR
    {
        public UInt32 MinImageCount;
        public UInt32 MaxImageCount;
        public Extent2D CurrentExtent;
        public Extent2D MinImageExtent;
        public Extent2D MaxImageExtent;
        public UInt32 MaxImageArrayLayers;
        public SurfaceTransformFlagsKHR SupportedTransforms;
        public SurfaceTransformFlagsKHR CurrentTransform;
        public CompositeAlphaFlagsKHR SupportedCompositeAlpha;
        public ImageUsageFlags SupportedUsageFlags;
    }

    public struct SurfaceFormatKHR
    {
        public Format Format;
        public ColorSpaceKHR ColorSpace;
    }

}
