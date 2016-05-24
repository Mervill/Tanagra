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
    public struct PhysicalDeviceMemoryProperties
    {
        public struct MemoryTypesInfo
        {
            public const UInt32 Length = 32;
            
            public MemoryType Value0;
            public MemoryType Value1;
            public MemoryType Value2;
            public MemoryType Value3;
            public MemoryType Value4;
            public MemoryType Value5;
            public MemoryType Value6;
            public MemoryType Value7;
            public MemoryType Value8;
            public MemoryType Value9;
            public MemoryType Value10;
            public MemoryType Value11;
            public MemoryType Value12;
            public MemoryType Value13;
            public MemoryType Value14;
            public MemoryType Value15;
            public MemoryType Value16;
            public MemoryType Value17;
            public MemoryType Value18;
            public MemoryType Value19;
            public MemoryType Value20;
            public MemoryType Value21;
            public MemoryType Value22;
            public MemoryType Value23;
            public MemoryType Value24;
            public MemoryType Value25;
            public MemoryType Value26;
            public MemoryType Value27;
            public MemoryType Value28;
            public MemoryType Value29;
            public MemoryType Value30;
            public MemoryType Value31;
            
            public MemoryType this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value0;
                        case 1: return Value1;
                        case 2: return Value2;
                        case 3: return Value3;
                        case 4: return Value4;
                        case 5: return Value5;
                        case 6: return Value6;
                        case 7: return Value7;
                        case 8: return Value8;
                        case 9: return Value9;
                        case 10: return Value10;
                        case 11: return Value11;
                        case 12: return Value12;
                        case 13: return Value13;
                        case 14: return Value14;
                        case 15: return Value15;
                        case 16: return Value16;
                        case 17: return Value17;
                        case 18: return Value18;
                        case 19: return Value19;
                        case 20: return Value20;
                        case 21: return Value21;
                        case 22: return Value22;
                        case 23: return Value23;
                        case 24: return Value24;
                        case 25: return Value25;
                        case 26: return Value26;
                        case 27: return Value27;
                        case 28: return Value28;
                        case 29: return Value29;
                        case 30: return Value30;
                        case 31: return Value31;
                    }
                }
            }
        }
        public struct MemoryHeapsInfo
        {
            public const UInt32 Length = 16;
            
            public MemoryHeap Value0;
            public MemoryHeap Value1;
            public MemoryHeap Value2;
            public MemoryHeap Value3;
            public MemoryHeap Value4;
            public MemoryHeap Value5;
            public MemoryHeap Value6;
            public MemoryHeap Value7;
            public MemoryHeap Value8;
            public MemoryHeap Value9;
            public MemoryHeap Value10;
            public MemoryHeap Value11;
            public MemoryHeap Value12;
            public MemoryHeap Value13;
            public MemoryHeap Value14;
            public MemoryHeap Value15;
            
            public MemoryHeap this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value0;
                        case 1: return Value1;
                        case 2: return Value2;
                        case 3: return Value3;
                        case 4: return Value4;
                        case 5: return Value5;
                        case 6: return Value6;
                        case 7: return Value7;
                        case 8: return Value8;
                        case 9: return Value9;
                        case 10: return Value10;
                        case 11: return Value11;
                        case 12: return Value12;
                        case 13: return Value13;
                        case 14: return Value14;
                        case 15: return Value15;
                    }
                }
            }
        }
        public UInt32 MemoryTypeCount;
        public MemoryTypesInfo MemoryTypes;
        public UInt32 MemoryHeapCount;
        public MemoryHeapsInfo MemoryHeaps;
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
    
    public struct ImageBlit
    {
        public struct SrcOffsetsInfo
        {
            public const UInt32 Length = 2;
            
            public Offset3D Value0;
            public Offset3D Value1;
            
            public Offset3D this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value0;
                        case 1: return Value1;
                    }
                }
            }
        }
        public struct DstOffsetsInfo
        {
            public const UInt32 Length = 2;
            
            public Offset3D Value0;
            public Offset3D Value1;
            
            public Offset3D this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value0;
                        case 1: return Value1;
                    }
                }
            }
        }
        public ImageSubresourceLayers SrcSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public SrcOffsetsInfo SrcOffsets;
        public ImageSubresourceLayers DstSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public DstOffsetsInfo DstOffsets;
        
        public ImageBlit(ImageSubresourceLayers SrcSubresource, SrcOffsetsInfo SrcOffsets, ImageSubresourceLayers DstSubresource, DstOffsetsInfo DstOffsets)
        {
            this.SrcSubresource = SrcSubresource;
            this.SrcOffsets = SrcOffsets;
            this.DstSubresource = DstSubresource;
            this.DstOffsets = DstOffsets;
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
    
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct PhysicalDeviceLimits
    {
        public struct MaxComputeWorkGroupCountInfo
        {
            public UInt32 X;
            public UInt32 Y;
            public UInt32 Z;
        }
        public struct MaxComputeWorkGroupSizeInfo
        {
            public UInt32 X;
            public UInt32 Y;
            public UInt32 Z;
        }
        public struct MaxViewportDimensionsInfo
        {
            public UInt32 X;
            public UInt32 Y;
        }
        public struct ViewportBoundsRangeInfo
        {
            public Single Min;
            public Single Max;
        }
        public struct PointSizeRangeInfo
        {
            public Single Min;
            public Single Max;
        }
        public struct LineWidthRangeInfo
        {
            public Single Min;
            public Single Max;
        }
        /// <summary>
        /// Max 1D image dimension
        /// </summary>
        public UInt32 MaxImageDimension1D;
        /// <summary>
        /// Max 2D image dimension
        /// </summary>
        public UInt32 MaxImageDimension2D;
        /// <summary>
        /// Max 3D image dimension
        /// </summary>
        public UInt32 MaxImageDimension3D;
        /// <summary>
        /// Max cubemap image dimension
        /// </summary>
        public UInt32 MaxImageDimensionCube;
        /// <summary>
        /// Max layers for image arrays
        /// </summary>
        public UInt32 MaxImageArrayLayers;
        /// <summary>
        /// Max texel buffer size (fstexels)
        /// </summary>
        public UInt32 MaxTexelBufferElements;
        /// <summary>
        /// Max uniform buffer range (bytes)
        /// </summary>
        public UInt32 MaxUniformBufferRange;
        /// <summary>
        /// Max storage buffer range (bytes)
        /// </summary>
        public UInt32 MaxStorageBufferRange;
        /// <summary>
        /// Max size of the push constants pool (bytes)
        /// </summary>
        public UInt32 MaxPushConstantsSize;
        /// <summary>
        /// Max number of device memory allocations supported
        /// </summary>
        public UInt32 MaxMemoryAllocationCount;
        /// <summary>
        /// Max number of samplers that can be allocated on a device
        /// </summary>
        public UInt32 MaxSamplerAllocationCount;
        /// <summary>
        /// Granularity (in bytes) at which buffers and images can be bound to adjacent memory for simultaneous usage
        /// </summary>
        public DeviceSize BufferImageGranularity;
        /// <summary>
        /// Total address space available for sparse allocations (bytes)
        /// </summary>
        public DeviceSize SparseAddressSpaceSize;
        /// <summary>
        /// Max number of descriptors sets that can be bound to a pipeline
        /// </summary>
        public UInt32 MaxBoundDescriptorSets;
        /// <summary>
        /// Max number of samplers allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorSamplers;
        /// <summary>
        /// Max number of uniform buffers allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorUniformBuffers;
        /// <summary>
        /// Max number of storage buffers allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorStorageBuffers;
        /// <summary>
        /// Max number of sampled images allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorSampledImages;
        /// <summary>
        /// Max number of storage images allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorStorageImages;
        /// <summary>
        /// Max number of input attachments allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorInputAttachments;
        /// <summary>
        /// Max number of resources allowed by a single stage
        /// </summary>
        public UInt32 MaxPerStageResources;
        /// <summary>
        /// Max number of samplers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetSamplers;
        /// <summary>
        /// Max number of uniform buffers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetUniformBuffers;
        /// <summary>
        /// Max number of dynamic uniform buffers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetUniformBuffersDynamic;
        /// <summary>
        /// Max number of storage buffers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetStorageBuffers;
        /// <summary>
        /// Max number of dynamic storage buffers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetStorageBuffersDynamic;
        /// <summary>
        /// Max number of sampled images allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetSampledImages;
        /// <summary>
        /// Max number of storage images allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetStorageImages;
        /// <summary>
        /// Max number of input attachments allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetInputAttachments;
        /// <summary>
        /// Max number of vertex input attribute slots
        /// </summary>
        public UInt32 MaxVertexInputAttributes;
        /// <summary>
        /// Max number of vertex input binding slots
        /// </summary>
        public UInt32 MaxVertexInputBindings;
        /// <summary>
        /// Max vertex input attribute offset added to vertex buffer offset
        /// </summary>
        public UInt32 MaxVertexInputAttributeOffset;
        /// <summary>
        /// Max vertex input binding stride
        /// </summary>
        public UInt32 MaxVertexInputBindingStride;
        /// <summary>
        /// Max number of output components written by vertex shader
        /// </summary>
        public UInt32 MaxVertexOutputComponents;
        /// <summary>
        /// Max level supported by tessellation primitive generator
        /// </summary>
        public UInt32 MaxTessellationGenerationLevel;
        /// <summary>
        /// Max patch size (vertices)
        /// </summary>
        public UInt32 MaxTessellationPatchSize;
        /// <summary>
        /// Max number of input components per-vertex in TCS
        /// </summary>
        public UInt32 MaxTessellationControlPerVertexInputComponents;
        /// <summary>
        /// Max number of output components per-vertex in TCS
        /// </summary>
        public UInt32 MaxTessellationControlPerVertexOutputComponents;
        /// <summary>
        /// Max number of output components per-patch in TCS
        /// </summary>
        public UInt32 MaxTessellationControlPerPatchOutputComponents;
        /// <summary>
        /// Max total number of per-vertex and per-patch output components in TCS
        /// </summary>
        public UInt32 MaxTessellationControlTotalOutputComponents;
        /// <summary>
        /// Max number of input components per vertex in TES
        /// </summary>
        public UInt32 MaxTessellationEvaluationInputComponents;
        /// <summary>
        /// Max number of output components per vertex in TES
        /// </summary>
        public UInt32 MaxTessellationEvaluationOutputComponents;
        /// <summary>
        /// Max invocation count supported in geometry shader
        /// </summary>
        public UInt32 MaxGeometryShaderInvocations;
        /// <summary>
        /// Max number of input components read in geometry stage
        /// </summary>
        public UInt32 MaxGeometryInputComponents;
        /// <summary>
        /// Max number of output components written in geometry stage
        /// </summary>
        public UInt32 MaxGeometryOutputComponents;
        /// <summary>
        /// Max number of vertices that can be emitted in geometry stage
        /// </summary>
        public UInt32 MaxGeometryOutputVertices;
        /// <summary>
        /// Max total number of components (all vertices) written in geometry stage
        /// </summary>
        public UInt32 MaxGeometryTotalOutputComponents;
        /// <summary>
        /// Max number of input compontents read in fragment stage
        /// </summary>
        public UInt32 MaxFragmentInputComponents;
        /// <summary>
        /// Max number of output attachments written in fragment stage
        /// </summary>
        public UInt32 MaxFragmentOutputAttachments;
        /// <summary>
        /// Max number of output attachments written when using dual source blending
        /// </summary>
        public UInt32 MaxFragmentDualSrcAttachments;
        /// <summary>
        /// Max total number of storage buffers, storage images and output buffers
        /// </summary>
        public UInt32 MaxFragmentCombinedOutputResources;
        /// <summary>
        /// Max total storage size of work group local storage (bytes)
        /// </summary>
        public UInt32 MaxComputeSharedMemorySize;
        /// <summary>
        /// Max num of compute work groups that may be dispatched by a single command (x,y,z)
        /// </summary>
        public MaxComputeWorkGroupCountInfo MaxComputeWorkGroupCount;
        /// <summary>
        /// Max total compute invocations in a single local work group
        /// </summary>
        public UInt32 MaxComputeWorkGroupInvocations;
        /// <summary>
        /// Max local size of a compute work group (x,y,z)
        /// </summary>
        public MaxComputeWorkGroupSizeInfo MaxComputeWorkGroupSize;
        /// <summary>
        /// Number bits of subpixel precision in screen x and y
        /// </summary>
        public UInt32 SubPixelPrecisionBits;
        /// <summary>
        /// Number bits of precision for selecting texel weights
        /// </summary>
        public UInt32 SubTexelPrecisionBits;
        /// <summary>
        /// Number bits of precision for selecting mipmap weights
        /// </summary>
        public UInt32 MipmapPrecisionBits;
        /// <summary>
        /// Max index value for indexed draw calls (for 32-bit indices)
        /// </summary>
        public UInt32 MaxDrawIndexedIndexValue;
        /// <summary>
        /// Max draw count for indirect draw calls
        /// </summary>
        public UInt32 MaxDrawIndirectCount;
        /// <summary>
        /// Max absolute sampler level of detail bias
        /// </summary>
        public Single MaxSamplerLodBias;
        /// <summary>
        /// Max degree of sampler anisotropy
        /// </summary>
        public Single MaxSamplerAnisotropy;
        /// <summary>
        /// Max number of active viewports
        /// </summary>
        public UInt32 MaxViewports;
        /// <summary>
        /// Max viewport dimensions (x,y)
        /// </summary>
        public MaxViewportDimensionsInfo MaxViewportDimensions;
        /// <summary>
        /// Viewport bounds range (min,max)
        /// </summary>
        public ViewportBoundsRangeInfo ViewportBoundsRange;
        /// <summary>
        /// Number bits of subpixel precision for viewport
        /// </summary>
        public UInt32 ViewportSubPixelBits;
        /// <summary>
        /// Min required alignment of pointers returned by MapMemory (bytes)
        /// </summary>
        public UInt32 MinMemoryMapAlignment;
        /// <summary>
        /// Min required alignment for texel buffer offsets (bytes)
        /// </summary>
        public DeviceSize MinTexelBufferOffsetAlignment;
        /// <summary>
        /// Min required alignment for uniform buffer sizes and offsets (bytes)
        /// </summary>
        public DeviceSize MinUniformBufferOffsetAlignment;
        /// <summary>
        /// Min required alignment for storage buffer offsets (bytes)
        /// </summary>
        public DeviceSize MinStorageBufferOffsetAlignment;
        /// <summary>
        /// Min texel offset for OpTextureSampleOffset
        /// </summary>
        public Int32 MinTexelOffset;
        /// <summary>
        /// Max texel offset for OpTextureSampleOffset
        /// </summary>
        public UInt32 MaxTexelOffset;
        /// <summary>
        /// Min texel offset for OpTextureGatherOffset
        /// </summary>
        public Int32 MinTexelGatherOffset;
        /// <summary>
        /// Max texel offset for OpTextureGatherOffset
        /// </summary>
        public UInt32 MaxTexelGatherOffset;
        /// <summary>
        /// Furthest negative offset for interpolateAtOffset
        /// </summary>
        public Single MinInterpolationOffset;
        /// <summary>
        /// Furthest positive offset for interpolateAtOffset
        /// </summary>
        public Single MaxInterpolationOffset;
        /// <summary>
        /// Number of subpixel bits for interpolateAtOffset
        /// </summary>
        public UInt32 SubPixelInterpolationOffsetBits;
        /// <summary>
        /// Max width for a framebuffer
        /// </summary>
        public UInt32 MaxFramebufferWidth;
        /// <summary>
        /// Max height for a framebuffer
        /// </summary>
        public UInt32 MaxFramebufferHeight;
        /// <summary>
        /// Max layer count for a layered framebuffer
        /// </summary>
        public UInt32 MaxFramebufferLayers;
        /// <summary>
        /// Supported color sample counts for a framebuffer (Optional)
        /// </summary>
        public SampleCountFlags FramebufferColorSampleCounts;
        /// <summary>
        /// Supported depth sample counts for a framebuffer (Optional)
        /// </summary>
        public SampleCountFlags FramebufferDepthSampleCounts;
        /// <summary>
        /// Supported stencil sample counts for a framebuffer (Optional)
        /// </summary>
        public SampleCountFlags FramebufferStencilSampleCounts;
        /// <summary>
        /// Supported sample counts for a framebuffer with no attachments (Optional)
        /// </summary>
        public SampleCountFlags FramebufferNoAttachmentsSampleCounts;
        /// <summary>
        /// Max number of color attachments per subpass
        /// </summary>
        public UInt32 MaxColorAttachments;
        /// <summary>
        /// Supported color sample counts for a non-integer sampled image (Optional)
        /// </summary>
        public SampleCountFlags SampledImageColorSampleCounts;
        /// <summary>
        /// Supported sample counts for an integer image (Optional)
        /// </summary>
        public SampleCountFlags SampledImageIntegerSampleCounts;
        /// <summary>
        /// Supported depth sample counts for a sampled image (Optional)
        /// </summary>
        public SampleCountFlags SampledImageDepthSampleCounts;
        /// <summary>
        /// Supported stencil sample counts for a sampled image (Optional)
        /// </summary>
        public SampleCountFlags SampledImageStencilSampleCounts;
        /// <summary>
        /// Supported sample counts for a storage image (Optional)
        /// </summary>
        public SampleCountFlags StorageImageSampleCounts;
        /// <summary>
        /// Max number of sample mask words
        /// </summary>
        public UInt32 MaxSampleMaskWords;
        /// <summary>
        /// Timestamps on graphics and compute queues
        /// </summary>
        public Bool32 TimestampComputeAndGraphics;
        /// <summary>
        /// Number of nanoseconds it takes for timestamp query value to increment by 1
        /// </summary>
        public Single TimestampPeriod;
        /// <summary>
        /// Max number of clip distances
        /// </summary>
        public UInt32 MaxClipDistances;
        /// <summary>
        /// Max number of cull distances
        /// </summary>
        public UInt32 MaxCullDistances;
        /// <summary>
        /// Max combined number of user clipping
        /// </summary>
        public UInt32 MaxCombinedClipAndCullDistances;
        /// <summary>
        /// Distinct queue priorities available
        /// </summary>
        public UInt32 DiscreteQueuePriorities;
        /// <summary>
        /// Range (min,max) of supported point sizes
        /// </summary>
        public PointSizeRangeInfo PointSizeRange;
        /// <summary>
        /// Range (min,max) of supported line widths
        /// </summary>
        public LineWidthRangeInfo LineWidthRange;
        /// <summary>
        /// Granularity of supported point sizes
        /// </summary>
        public Single PointSizeGranularity;
        /// <summary>
        /// Granularity of supported line widths
        /// </summary>
        public Single LineWidthGranularity;
        /// <summary>
        /// Line rasterization follows preferred rules
        /// </summary>
        public Bool32 StrictLines;
        /// <summary>
        /// Supports standard sample locations for all supported sample counts
        /// </summary>
        public Bool32 StandardSampleLocations;
        /// <summary>
        /// Optimal offset of buffer copies
        /// </summary>
        public DeviceSize OptimalBufferCopyOffsetAlignment;
        /// <summary>
        /// Optimal pitch of buffer copies
        /// </summary>
        public DeviceSize OptimalBufferCopyRowPitchAlignment;
        /// <summary>
        /// Minimum size and alignment for non-coherent host-mapped device memory access
        /// </summary>
        public DeviceSize NonCoherentAtomSize;
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
