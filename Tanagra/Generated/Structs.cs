// ReSharper disable BuiltInTypeReferenceStyle
// ReSharper disable InconsistentNaming
using System;

namespace Vulkan
{
    public struct SampleMask
    {
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
        /// <summary>
        /// Queue flags (Optional)
        /// </summary>
        public QueueFlags QueueFlags;
        public UInt32 QueueCount;
        public UInt32 TimestampValidBits;
        /// <summary>
        /// Minimum alignment requirement for image transfers
        /// </summary>
        public Extent3D MinImageTransferGranularity;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct MemoryRequirements
    {
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Alignment;
        /// <summary>
        /// Bitfield of the allowed memory type indices into memoryTypes[] for this object
        /// </summary>
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
        /// <summary>
        /// Specified in bytes, must be a multiple of sparse block size in bytes / alignment
        /// </summary>
        public DeviceSize ImageMipTailSize;
        /// <summary>
        /// Specified in bytes, must be a multiple of sparse block size in bytes / alignment
        /// </summary>
        public DeviceSize ImageMipTailOffset;
        /// <summary>
        /// Specified in bytes, must be a multiple of sparse block size in bytes / alignment
        /// </summary>
        public DeviceSize ImageMipTailStride;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct MemoryType
    {
        /// <summary>
        /// Memory properties of this memory type (Optional)
        /// </summary>
        public MemoryPropertyFlags PropertyFlags;
        /// <summary>
        /// Index of the memory heap allocations of this memory type are taken from
        /// </summary>
        public UInt32 HeapIndex;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct MemoryHeap
    {
        /// <summary>
        /// Available memory in the heap
        /// </summary>
        public DeviceSize Size;
        /// <summary>
        /// Flags for the heap (Optional)
        /// </summary>
        public MemoryHeapFlags Flags;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct FormatProperties
    {
        /// <summary>
        /// Format features in case of linear tiling (Optional)
        /// </summary>
        public FormatFeatureFlags LinearTilingFeatures;
        /// <summary>
        /// Format features in case of optimal tiling (Optional)
        /// </summary>
        public FormatFeatureFlags OptimalTilingFeatures;
        /// <summary>
        /// Format features supported by buffers (Optional)
        /// </summary>
        public FormatFeatureFlags BufferFeatures;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct ImageFormatProperties
    {
        /// <summary>
        /// Max image dimensions for this resource type
        /// </summary>
        public Extent3D MaxExtent;
        /// <summary>
        /// Max number of mipmap levels for this resource type
        /// </summary>
        public UInt32 MaxMipLevels;
        /// <summary>
        /// Max array size for this resource type
        /// </summary>
        public UInt32 MaxArrayLayers;
        /// <summary>
        /// Supported sample counts for this resource type (Optional)
        /// </summary>
        public SampleCountFlags SampleCounts;
        /// <summary>
        /// Max size (in bytes) of this resource type
        /// </summary>
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
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize RowPitch;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize ArrayPitch;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize DepthPitch;
    }

    public struct BufferCopy
    {
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize SrcOffset;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize DstOffset;
        /// <summary>
        /// Specified in bytes
        /// </summary>
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
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D SrcOffset;
        public ImageSubresourceLayers DstSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D DstOffset;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
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
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize BufferOffset;
        /// <summary>
        /// Specified in texels
        /// </summary>
        public UInt32 BufferRowLength;
        public UInt32 BufferImageHeight;
        public ImageSubresourceLayers ImageSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D ImageOffset;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
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
        /// <summary>
        /// The SpecConstant ID specified in the BIL
        /// </summary>
        public UInt32 ConstantID;
        /// <summary>
        /// Offset of the value in the data block
        /// </summary>
        public UInt32 Offset;
        /// <summary>
        /// Size in bytes of the SpecConstant
        /// </summary>
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
        /// <summary>
        /// Vertex buffer binding id
        /// </summary>
        public UInt32 Binding;
        /// <summary>
        /// Distance between vertices in bytes (0 = no advancement)
        /// </summary>
        public UInt32 Stride;
        /// <summary>
        /// The rate at which the vertex data is consumed
        /// </summary>
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
        /// <summary>
        /// Location of the shader vertex attrib
        /// </summary>
        public UInt32 Location;
        /// <summary>
        /// Vertex buffer binding id
        /// </summary>
        public UInt32 Binding;
        /// <summary>
        /// Format of source data
        /// </summary>
        public Format Format;
        /// <summary>
        /// Offset of first element in bytes from base of vertex
        /// </summary>
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
        /// <summary>
        /// Which stages use the range
        /// </summary>
        public ShaderStageFlags StageFlags;
        /// <summary>
        /// Start of the range, in bytes
        /// </summary>
        public UInt32 Offset;
        /// <summary>
        /// Size of the range, in bytes
        /// </summary>
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
        /// <summary>
        /// Load operation for color or depth data
        /// </summary>
        public AttachmentLoadOp LoadOp;
        /// <summary>
        /// Store operation for color or depth data
        /// </summary>
        public AttachmentStoreOp StoreOp;
        /// <summary>
        /// Load operation for stencil data
        /// </summary>
        public AttachmentLoadOp StencilLoadOp;
        /// <summary>
        /// Store operation for stencil data
        /// </summary>
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
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask;
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
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
        /// <summary>
        /// Out of bounds buffer accesses are well defined
        /// </summary>
        public Bool32 RobustBufferAccess;
        /// <summary>
        /// Full 32-bit range of indices for indexed draw calls
        /// </summary>
        public Bool32 FullDrawIndexUint32;
        /// <summary>
        /// Image views which are arrays of cube maps
        /// </summary>
        public Bool32 ImageCubeArray;
        /// <summary>
        /// Blending operations are controlled per-attachment
        /// </summary>
        public Bool32 IndependentBlend;
        /// <summary>
        /// Geometry stage
        /// </summary>
        public Bool32 GeometryShader;
        /// <summary>
        /// Tessellation control and evaluation stage
        /// </summary>
        public Bool32 TessellationShader;
        /// <summary>
        /// Per-sample shading and interpolation
        /// </summary>
        public Bool32 SampleRateShading;
        /// <summary>
        /// Blend operations which take two sources
        /// </summary>
        public Bool32 DualSrcBlend;
        /// <summary>
        /// Logic operations
        /// </summary>
        public Bool32 LogicOp;
        /// <summary>
        /// Multi draw indirect
        /// </summary>
        public Bool32 MultiDrawIndirect;
        /// <summary>
        /// Indirect draws can use non-zero firstInstance
        /// </summary>
        public Bool32 DrawIndirectFirstInstance;
        /// <summary>
        /// Depth clamping
        /// </summary>
        public Bool32 DepthClamp;
        /// <summary>
        /// Depth bias clamping
        /// </summary>
        public Bool32 DepthBiasClamp;
        /// <summary>
        /// Point and wireframe fill modes
        /// </summary>
        public Bool32 FillModeNonSolid;
        /// <summary>
        /// Depth bounds test
        /// </summary>
        public Bool32 DepthBounds;
        /// <summary>
        /// Lines with width greater than 1
        /// </summary>
        public Bool32 WideLines;
        /// <summary>
        /// Points with size greater than 1
        /// </summary>
        public Bool32 LargePoints;
        /// <summary>
        /// The fragment alpha component can be forced to maximum representable alpha value
        /// </summary>
        public Bool32 AlphaToOne;
        /// <summary>
        /// Viewport arrays
        /// </summary>
        public Bool32 MultiViewport;
        /// <summary>
        /// Anisotropic sampler filtering
        /// </summary>
        public Bool32 SamplerAnisotropy;
        /// <summary>
        /// ETC texture compression formats
        /// </summary>
        public Bool32 TextureCompressionETC2;
        /// <summary>
        /// ASTC LDR texture compression formats
        /// </summary>
        public Bool32 TextureCompressionASTC_LDR;
        /// <summary>
        /// BC1-7 texture compressed formats
        /// </summary>
        public Bool32 TextureCompressionBC;
        /// <summary>
        /// Precise occlusion queries returning actual sample counts
        /// </summary>
        public Bool32 OcclusionQueryPrecise;
        /// <summary>
        /// Pipeline statistics query
        /// </summary>
        public Bool32 PipelineStatisticsQuery;
        /// <summary>
        /// Stores and atomic ops on storage buffers and images are supported in vertex, tessellation, and geometry stages
        /// </summary>
        public Bool32 VertexPipelineStoresAndAtomics;
        /// <summary>
        /// Stores and atomic ops on storage buffers and images are supported in the fragment stage
        /// </summary>
        public Bool32 FragmentStoresAndAtomics;
        /// <summary>
        /// Tessellation and geometry stages can export point size
        /// </summary>
        public Bool32 ShaderTessellationAndGeometryPointSize;
        /// <summary>
        /// Image gather with run-time values and independent offsets
        /// </summary>
        public Bool32 ShaderImageGatherExtended;
        /// <summary>
        /// The extended set of formats can be used for storage images
        /// </summary>
        public Bool32 ShaderStorageImageExtendedFormats;
        /// <summary>
        /// Multisample images can be used for storage images
        /// </summary>
        public Bool32 ShaderStorageImageMultisample;
        /// <summary>
        /// Read from storage image does not require format qualifier
        /// </summary>
        public Bool32 ShaderStorageImageReadWithoutFormat;
        /// <summary>
        /// Write to storage image does not require format qualifier
        /// </summary>
        public Bool32 ShaderStorageImageWriteWithoutFormat;
        /// <summary>
        /// Arrays of uniform buffers can be accessed with dynamically uniform indices
        /// </summary>
        public Bool32 ShaderUniformBufferArrayDynamicIndexing;
        /// <summary>
        /// Arrays of sampled images can be accessed with dynamically uniform indices
        /// </summary>
        public Bool32 ShaderSampledImageArrayDynamicIndexing;
        /// <summary>
        /// Arrays of storage buffers can be accessed with dynamically uniform indices
        /// </summary>
        public Bool32 ShaderStorageBufferArrayDynamicIndexing;
        /// <summary>
        /// Arrays of storage images can be accessed with dynamically uniform indices
        /// </summary>
        public Bool32 ShaderStorageImageArrayDynamicIndexing;
        /// <summary>
        /// Clip distance in shaders
        /// </summary>
        public Bool32 ShaderClipDistance;
        /// <summary>
        /// Cull distance in shaders
        /// </summary>
        public Bool32 ShaderCullDistance;
        /// <summary>
        /// 64-bit floats (doubles) in shaders
        /// </summary>
        public Bool32 ShaderFloat64;
        /// <summary>
        /// 64-bit integers in shaders
        /// </summary>
        public Bool32 ShaderInt64;
        /// <summary>
        /// 16-bit integers in shaders
        /// </summary>
        public Bool32 ShaderInt16;
        /// <summary>
        /// Shader can use texture operations that return resource residency information (requires sparseNonResident support)
        /// </summary>
        public Bool32 ShaderResourceResidency;
        /// <summary>
        /// Shader can use texture operations that specify minimum resource level of detail
        /// </summary>
        public Bool32 ShaderResourceMinLod;
        /// <summary>
        /// Sparse resources support: Resource memory can be managed at opaque page level rather than object level
        /// </summary>
        public Bool32 SparseBinding;
        /// <summary>
        /// Sparse resources support: GPU can access partially resident buffers
        /// </summary>
        public Bool32 SparseResidencyBuffer;
        /// <summary>
        /// Sparse resources support: GPU can access partially resident 2D (non-MSAA non-depth/stencil) images
        /// </summary>
        public Bool32 SparseResidencyImage2D;
        /// <summary>
        /// Sparse resources support: GPU can access partially resident 3D images
        /// </summary>
        public Bool32 SparseResidencyImage3D;
        /// <summary>
        /// Sparse resources support: GPU can access partially resident MSAA 2D images with 2 samples
        /// </summary>
        public Bool32 SparseResidency2Samples;
        /// <summary>
        /// Sparse resources support: GPU can access partially resident MSAA 2D images with 4 samples
        /// </summary>
        public Bool32 SparseResidency4Samples;
        /// <summary>
        /// Sparse resources support: GPU can access partially resident MSAA 2D images with 8 samples
        /// </summary>
        public Bool32 SparseResidency8Samples;
        /// <summary>
        /// Sparse resources support: GPU can access partially resident MSAA 2D images with 16 samples
        /// </summary>
        public Bool32 SparseResidency16Samples;
        /// <summary>
        /// Sparse resources support: GPU can correctly access data aliased into multiple locations (opt-in)
        /// </summary>
        public Bool32 SparseResidencyAliased;
        /// <summary>
        /// Multisample rate must be the same for all pipelines in a subpass
        /// </summary>
        public Bool32 VariableMultisampleRate;
        /// <summary>
        /// Queries may be inherited from primary to secondary command buffers
        /// </summary>
        public Bool32 InheritedQueries;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct PhysicalDeviceSparseProperties
    {
        /// <summary>
        /// Sparse resources support: GPU will access all 2D (single sample) sparse resources using the standard sparse image block shapes (based on pixel format)
        /// </summary>
        public Bool32 ResidencyStandard2DBlockShape;
        /// <summary>
        /// Sparse resources support: GPU will access all 2D (multisample) sparse resources using the standard sparse image block shapes (based on pixel format)
        /// </summary>
        public Bool32 ResidencyStandard2DMultisampleBlockShape;
        /// <summary>
        /// Sparse resources support: GPU will access all 3D sparse resources using the standard sparse image block shapes (based on pixel format)
        /// </summary>
        public Bool32 ResidencyStandard3DBlockShape;
        /// <summary>
        /// Sparse resources support: Images with mip-level dimensions that are NOT a multiple of the sparse image block dimensions will be placed in the mip tail
        /// </summary>
        public Bool32 ResidencyAlignedMipSize;
        /// <summary>
        /// Sparse resources support: GPU can consistently access non-resident regions of a resource, all reads return as if data is 0, writes are discarded
        /// </summary>
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
        /// <summary>
        /// Visible scannout region.
        /// </summary>
        public Extent2D VisibleRegion;
        /// <summary>
        /// Number of times per second the display is updated.
        /// </summary>
        public UInt32 RefreshRate;
        
        public DisplayModeParametersKHR(Extent2D VisibleRegion, UInt32 RefreshRate)
        {
            this.VisibleRegion = VisibleRegion;
            this.RefreshRate = RefreshRate;
        }
    }

    public struct DisplayPlaneCapabilitiesKHR
    {
        /// <summary>
        /// Types of alpha blending supported, if any. (Optional)
        /// </summary>
        public DisplayPlaneAlphaFlagsKHR SupportedAlpha;
        /// <summary>
        /// Does the plane have any position and extent restrictions?
        /// </summary>
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
        /// <summary>
        /// Supported minimum number of images for the surface
        /// </summary>
        public UInt32 MinImageCount;
        /// <summary>
        /// Supported maximum number of images for the surface, 0 for unlimited
        /// </summary>
        public UInt32 MaxImageCount;
        /// <summary>
        /// Current image width and height for the surface, (0, 0) if undefined
        /// </summary>
        public Extent2D CurrentExtent;
        /// <summary>
        /// Supported minimum image width and height for the surface
        /// </summary>
        public Extent2D MinImageExtent;
        /// <summary>
        /// Supported maximum image width and height for the surface
        /// </summary>
        public Extent2D MaxImageExtent;
        /// <summary>
        /// Supported maximum number of image layers for the surface
        /// </summary>
        public UInt32 MaxImageArrayLayers;
        /// <summary>
        /// 1 or more bits representing the transforms supported (Optional)
        /// </summary>
        public SurfaceTransformFlagsKHR SupportedTransforms;
        /// <summary>
        /// The surface's current transform relative to the device's natural orientation
        /// </summary>
        public SurfaceTransformFlagsKHR CurrentTransform;
        /// <summary>
        /// 1 or more bits representing the alpha compositing modes supported (Optional)
        /// </summary>
        public CompositeAlphaFlagsKHR SupportedCompositeAlpha;
        /// <summary>
        /// Supported image usage flags for the surface (Optional)
        /// </summary>
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
        /// <summary>
        /// Supported pair of rendering format
        /// </summary>
        public Format Format;
        /// <summary>
        /// And colorspace for the surface
        /// </summary>
        public ColorSpaceKHR ColorSpace;
        
        public SurfaceFormatKHR(Format Format, ColorSpaceKHR ColorSpace)
        {
            this.Format = Format;
            this.ColorSpace = ColorSpace;
        }
    }

}
