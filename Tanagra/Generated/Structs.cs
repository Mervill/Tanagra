// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable InconsistentNaming
using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public struct SampleMask
    {
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ClearValue
    {
        [FieldOffset(0)] public IntPtr Color;
        [FieldOffset(0)] public ClearDepthStencilValue DepthStencil;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ClearColorValue
    {
        [FieldOffset(0)] public Single Float32;
        [FieldOffset(0)] public Int32 Int32;
        [FieldOffset(0)] public UInt32 Uint32;
    }

    public struct Offset2D
    {
        public Int32 X;
        public Int32 Y;
        
        public Offset2D(Int32 X, Int32 Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    public struct Offset3D
    {
        public Int32 X;
        public Int32 Y;
        public Int32 Z;
        
        public Offset3D(Int32 X, Int32 Y, Int32 Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }

    public struct Extent2D
    {
        public UInt32 Width;
        public UInt32 Height;
        
        public Extent2D(UInt32 Width, UInt32 Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
    }

    public struct Extent3D
    {
        public UInt32 Width;
        public UInt32 Height;
        public UInt32 Depth;
        
        public Extent3D(UInt32 Width, UInt32 Height, UInt32 Depth)
        {
            this.Width = Width;
            this.Height = Height;
            this.Depth = Depth;
        }
    }

    public struct Viewport
    {
        public Single X;
        public Single Y;
        public Single Width;
        public Single Height;
        public Single MinDepth;
        public Single MaxDepth;
        
        public Viewport(Single X, Single Y, Single Width, Single Height, Single MinDepth, Single MaxDepth)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.MinDepth = MinDepth;
            this.MaxDepth = MaxDepth;
        }
    }

    public struct Rect2D
    {
        public Offset2D Offset;
        public Extent2D Extent;
        
        public Rect2D(Offset2D Offset, Extent2D Extent)
        {
            this.Offset = Offset;
            this.Extent = Extent;
        }
    }

    public struct Rect3D
    {
        public Offset3D Offset;
        public Extent3D Extent;
        
        public Rect3D(Offset3D Offset, Extent3D Extent)
        {
            this.Offset = Offset;
            this.Extent = Extent;
        }
    }

    public struct ClearRect
    {
        public Rect2D Rect;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
        
        public ClearRect(Rect2D Rect, UInt32 BaseArrayLayer, UInt32 LayerCount)
        {
            this.Rect = Rect;
            this.BaseArrayLayer = BaseArrayLayer;
            this.LayerCount = LayerCount;
        }
    }

    public struct ComponentMapping
    {
        public ComponentSwizzle R;
        public ComponentSwizzle G;
        public ComponentSwizzle B;
        public ComponentSwizzle A;
        
        public ComponentMapping(ComponentSwizzle R, ComponentSwizzle G, ComponentSwizzle B, ComponentSwizzle A)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct QueueFamilyProperties
    {
        public QueueFlags QueueFlags;
        public UInt32 QueueCount;
        public UInt32 TimestampValidBits;
        public Extent3D MinImageTransferGranularity;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct MemoryRequirements
    {
        public DeviceSize Size;
        public DeviceSize Alignment;
        public UInt32 MemoryTypeBits;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct SparseImageFormatProperties
    {
        public ImageAspectFlags AspectMask;
        public Extent3D ImageGranularity;
        public SparseImageFormatFlags Flags;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct SparseImageMemoryRequirements
    {
        public SparseImageFormatProperties FormatProperties;
        public UInt32 ImageMipTailFirstLod;
        public DeviceSize ImageMipTailSize;
        public DeviceSize ImageMipTailOffset;
        public DeviceSize ImageMipTailStride;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct MemoryType
    {
        public MemoryPropertyFlags PropertyFlags;
        public UInt32 HeapIndex;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct MemoryHeap
    {
        public DeviceSize Size;
        public MemoryHeapFlags Flags;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct FormatProperties
    {
        public FormatFeatureFlags LinearTilingFeatures;
        public FormatFeatureFlags OptimalTilingFeatures;
        public FormatFeatureFlags BufferFeatures;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct ImageFormatProperties
    {
        public Extent3D MaxExtent;
        public UInt32 MaxMipLevels;
        public UInt32 MaxArrayLayers;
        public SampleCountFlags SampleCounts;
        public DeviceSize MaxResourceSize;
    }

    public struct ImageSubresource
    {
        public ImageAspectFlags AspectMask;
        public UInt32 MipLevel;
        public UInt32 ArrayLayer;
        
        public ImageSubresource(ImageAspectFlags AspectMask, UInt32 MipLevel, UInt32 ArrayLayer)
        {
            this.AspectMask = AspectMask;
            this.MipLevel = MipLevel;
            this.ArrayLayer = ArrayLayer;
        }
    }

    public struct ImageSubresourceLayers
    {
        public ImageAspectFlags AspectMask;
        public UInt32 MipLevel;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
        
        public ImageSubresourceLayers(ImageAspectFlags AspectMask, UInt32 MipLevel, UInt32 BaseArrayLayer, UInt32 LayerCount)
        {
            this.AspectMask = AspectMask;
            this.MipLevel = MipLevel;
            this.BaseArrayLayer = BaseArrayLayer;
            this.LayerCount = LayerCount;
        }
    }

    public struct ImageSubresourceRange
    {
        public ImageAspectFlags AspectMask;
        public UInt32 BaseMipLevel;
        public UInt32 LevelCount;
        public UInt32 BaseArrayLayer;
        public UInt32 LayerCount;
        
        public ImageSubresourceRange(ImageAspectFlags AspectMask, UInt32 BaseMipLevel, UInt32 LevelCount, UInt32 BaseArrayLayer, UInt32 LayerCount)
        {
            this.AspectMask = AspectMask;
            this.BaseMipLevel = BaseMipLevel;
            this.LevelCount = LevelCount;
            this.BaseArrayLayer = BaseArrayLayer;
            this.LayerCount = LayerCount;
        }
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
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
        
        public BufferCopy(DeviceSize SrcOffset, DeviceSize DstOffset, DeviceSize Size)
        {
            this.SrcOffset = SrcOffset;
            this.DstOffset = DstOffset;
            this.Size = Size;
        }
    }

    public struct ImageCopy
    {
        public ImageSubresourceLayers SrcSubresource;
        public Offset3D SrcOffset;
        public ImageSubresourceLayers DstSubresource;
        public Offset3D DstOffset;
        public Extent3D Extent;
        
        public ImageCopy(ImageSubresourceLayers SrcSubresource, Offset3D SrcOffset, ImageSubresourceLayers DstSubresource, Offset3D DstOffset, Extent3D Extent)
        {
            this.SrcSubresource = SrcSubresource;
            this.SrcOffset = SrcOffset;
            this.DstSubresource = DstSubresource;
            this.DstOffset = DstOffset;
            this.Extent = Extent;
        }
    }

    public struct BufferImageCopy
    {
        public DeviceSize BufferOffset;
        public UInt32 BufferRowLength;
        public UInt32 BufferImageHeight;
        public ImageSubresourceLayers ImageSubresource;
        public Offset3D ImageOffset;
        public Extent3D ImageExtent;
        
        public BufferImageCopy(DeviceSize BufferOffset, UInt32 BufferRowLength, UInt32 BufferImageHeight, ImageSubresourceLayers ImageSubresource, Offset3D ImageOffset, Extent3D ImageExtent)
        {
            this.BufferOffset = BufferOffset;
            this.BufferRowLength = BufferRowLength;
            this.BufferImageHeight = BufferImageHeight;
            this.ImageSubresource = ImageSubresource;
            this.ImageOffset = ImageOffset;
            this.ImageExtent = ImageExtent;
        }
    }

    public struct ImageResolve
    {
        public ImageSubresourceLayers SrcSubresource;
        public Offset3D SrcOffset;
        public ImageSubresourceLayers DstSubresource;
        public Offset3D DstOffset;
        public Extent3D Extent;
        
        public ImageResolve(ImageSubresourceLayers SrcSubresource, Offset3D SrcOffset, ImageSubresourceLayers DstSubresource, Offset3D DstOffset, Extent3D Extent)
        {
            this.SrcSubresource = SrcSubresource;
            this.SrcOffset = SrcOffset;
            this.DstSubresource = DstSubresource;
            this.DstOffset = DstOffset;
            this.Extent = Extent;
        }
    }

    public struct DescriptorPoolSize
    {
        public DescriptorType Type;
        public UInt32 DescriptorCount;
        
        public DescriptorPoolSize(DescriptorType Type, UInt32 DescriptorCount)
        {
            this.Type = Type;
            this.DescriptorCount = DescriptorCount;
        }
    }

    public struct SpecializationMapEntry
    {
        public UInt32 ConstantID;
        public UInt32 Offset;
        public UInt32 Size;
        
        public SpecializationMapEntry(UInt32 ConstantID, UInt32 Offset, UInt32 Size)
        {
            this.ConstantID = ConstantID;
            this.Offset = Offset;
            this.Size = Size;
        }
    }

    public struct VertexInputBindingDescription
    {
        public UInt32 Binding;
        public UInt32 Stride;
        public VertexInputRate InputRate;
        
        public VertexInputBindingDescription(UInt32 Binding, UInt32 Stride, VertexInputRate InputRate)
        {
            this.Binding = Binding;
            this.Stride = Stride;
            this.InputRate = InputRate;
        }
    }

    public struct VertexInputAttributeDescription
    {
        public UInt32 Location;
        public UInt32 Binding;
        public Format Format;
        public UInt32 Offset;
        
        public VertexInputAttributeDescription(UInt32 Location, UInt32 Binding, Format Format, UInt32 Offset)
        {
            this.Location = Location;
            this.Binding = Binding;
            this.Format = Format;
            this.Offset = Offset;
        }
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
        
        public PipelineColorBlendAttachmentState(Bool32 BlendEnable, BlendFactor SrcColorBlendFactor, BlendFactor DstColorBlendFactor, BlendOp ColorBlendOp, BlendFactor SrcAlphaBlendFactor, BlendFactor DstAlphaBlendFactor, BlendOp AlphaBlendOp)
        {
            this.BlendEnable = BlendEnable;
            this.SrcColorBlendFactor = SrcColorBlendFactor;
            this.DstColorBlendFactor = DstColorBlendFactor;
            this.ColorBlendOp = ColorBlendOp;
            this.SrcAlphaBlendFactor = SrcAlphaBlendFactor;
            this.DstAlphaBlendFactor = DstAlphaBlendFactor;
            this.AlphaBlendOp = AlphaBlendOp;
            ColorWriteMask = default(ColorComponentFlags);
        }
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
        
        public StencilOpState(StencilOp FailOp, StencilOp PassOp, StencilOp DepthFailOp, CompareOp CompareOp, UInt32 CompareMask, UInt32 WriteMask, UInt32 Reference)
        {
            this.FailOp = FailOp;
            this.PassOp = PassOp;
            this.DepthFailOp = DepthFailOp;
            this.CompareOp = CompareOp;
            this.CompareMask = CompareMask;
            this.WriteMask = WriteMask;
            this.Reference = Reference;
        }
    }

    public struct PushConstantRange
    {
        public ShaderStageFlags StageFlags;
        public UInt32 Offset;
        public UInt32 Size;
        
        public PushConstantRange(ShaderStageFlags StageFlags, UInt32 Offset, UInt32 Size)
        {
            this.StageFlags = StageFlags;
            this.Offset = Offset;
            this.Size = Size;
        }
    }

    public struct ClearDepthStencilValue
    {
        public Single Depth;
        public UInt32 Stencil;
        
        public ClearDepthStencilValue(Single Depth, UInt32 Stencil)
        {
            this.Depth = Depth;
            this.Stencil = Stencil;
        }
    }

    public struct ClearAttachment
    {
        public ImageAspectFlags AspectMask;
        public UInt32 ColorAttachment;
        public ClearValue ClearValue;
        
        public ClearAttachment(ImageAspectFlags AspectMask, UInt32 ColorAttachment, ClearValue ClearValue)
        {
            this.AspectMask = AspectMask;
            this.ColorAttachment = ColorAttachment;
            this.ClearValue = ClearValue;
        }
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
        
        public AttachmentDescription(Format Format, SampleCountFlags Samples, AttachmentLoadOp LoadOp, AttachmentStoreOp StoreOp, AttachmentLoadOp StencilLoadOp, AttachmentStoreOp StencilStoreOp, ImageLayout InitialLayout, ImageLayout FinalLayout)
        {
            this.Format = Format;
            this.Samples = Samples;
            this.LoadOp = LoadOp;
            this.StoreOp = StoreOp;
            this.StencilLoadOp = StencilLoadOp;
            this.StencilStoreOp = StencilStoreOp;
            this.InitialLayout = InitialLayout;
            this.FinalLayout = FinalLayout;
            Flags = default(AttachmentDescriptionFlags);
        }
    }

    public struct AttachmentReference
    {
        public UInt32 Attachment;
        public ImageLayout Layout;
        
        public AttachmentReference(UInt32 Attachment, ImageLayout Layout)
        {
            this.Attachment = Attachment;
            this.Layout = Layout;
        }
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
        
        public SubpassDependency(UInt32 SrcSubpass, UInt32 DstSubpass, PipelineStageFlags SrcStageMask, PipelineStageFlags DstStageMask)
        {
            this.SrcSubpass = SrcSubpass;
            this.DstSubpass = DstSubpass;
            this.SrcStageMask = SrcStageMask;
            this.DstStageMask = DstStageMask;
            SrcAccessMask = default(AccessFlags);
            DstAccessMask = default(AccessFlags);
            DependencyFlags = default(DependencyFlags);
        }
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

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct PhysicalDeviceSparseProperties
    {
        public Bool32 ResidencyStandard2DBlockShape;
        public Bool32 ResidencyStandard2DMultisampleBlockShape;
        public Bool32 ResidencyStandard3DBlockShape;
        public Bool32 ResidencyAlignedMipSize;
        public Bool32 ResidencyNonResidentStrict;
    }

    public struct DrawIndirectCommand
    {
        public UInt32 VertexCount;
        public UInt32 InstanceCount;
        public UInt32 FirstVertex;
        public UInt32 FirstInstance;
        
        public DrawIndirectCommand(UInt32 VertexCount, UInt32 InstanceCount, UInt32 FirstVertex, UInt32 FirstInstance)
        {
            this.VertexCount = VertexCount;
            this.InstanceCount = InstanceCount;
            this.FirstVertex = FirstVertex;
            this.FirstInstance = FirstInstance;
        }
    }

    public struct DrawIndexedIndirectCommand
    {
        public UInt32 IndexCount;
        public UInt32 InstanceCount;
        public UInt32 FirstIndex;
        public Int32 VertexOffset;
        public UInt32 FirstInstance;
        
        public DrawIndexedIndirectCommand(UInt32 IndexCount, UInt32 InstanceCount, UInt32 FirstIndex, Int32 VertexOffset, UInt32 FirstInstance)
        {
            this.IndexCount = IndexCount;
            this.InstanceCount = InstanceCount;
            this.FirstIndex = FirstIndex;
            this.VertexOffset = VertexOffset;
            this.FirstInstance = FirstInstance;
        }
    }

    public struct DispatchIndirectCommand
    {
        public UInt32 X;
        public UInt32 Y;
        public UInt32 Z;
        
        public DispatchIndirectCommand(UInt32 X, UInt32 Y, UInt32 Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }

    public struct DisplayModeParametersKHR
    {
        public Extent2D VisibleRegion;
        public UInt32 RefreshRate;
        
        public DisplayModeParametersKHR(Extent2D VisibleRegion, UInt32 RefreshRate)
        {
            this.VisibleRegion = VisibleRegion;
            this.RefreshRate = RefreshRate;
        }
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
        
        public DisplayPlaneCapabilitiesKHR(Offset2D MinSrcPosition, Offset2D MaxSrcPosition, Extent2D MinSrcExtent, Extent2D MaxSrcExtent, Offset2D MinDstPosition, Offset2D MaxDstPosition, Extent2D MinDstExtent, Extent2D MaxDstExtent)
        {
            this.MinSrcPosition = MinSrcPosition;
            this.MaxSrcPosition = MaxSrcPosition;
            this.MinSrcExtent = MinSrcExtent;
            this.MaxSrcExtent = MaxSrcExtent;
            this.MinDstPosition = MinDstPosition;
            this.MaxDstPosition = MaxDstPosition;
            this.MinDstExtent = MinDstExtent;
            this.MaxDstExtent = MaxDstExtent;
            SupportedAlpha = default(DisplayPlaneAlphaFlagsKHR);
        }
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
        
        public SurfaceCapabilitiesKHR(UInt32 MinImageCount, UInt32 MaxImageCount, Extent2D CurrentExtent, Extent2D MinImageExtent, Extent2D MaxImageExtent, UInt32 MaxImageArrayLayers, SurfaceTransformFlagsKHR CurrentTransform)
        {
            this.MinImageCount = MinImageCount;
            this.MaxImageCount = MaxImageCount;
            this.CurrentExtent = CurrentExtent;
            this.MinImageExtent = MinImageExtent;
            this.MaxImageExtent = MaxImageExtent;
            this.MaxImageArrayLayers = MaxImageArrayLayers;
            this.CurrentTransform = CurrentTransform;
            SupportedTransforms = default(SurfaceTransformFlagsKHR);
            SupportedCompositeAlpha = default(CompositeAlphaFlagsKHR);
            SupportedUsageFlags = default(ImageUsageFlags);
        }
    }

    public struct SurfaceFormatKHR
    {
        public Format Format;
        public ColorSpaceKHR ColorSpace;
        
        public SurfaceFormatKHR(Format Format, ColorSpaceKHR ColorSpace)
        {
            this.Format = Format;
            this.ColorSpace = ColorSpace;
        }
    }

}
