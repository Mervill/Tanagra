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
        /// <summary>
        /// Extension name
        /// </summary>
        public unsafe fixed byte ExtensionName[256];
        /// <summary>
        /// Version of the extension specification implemented
        /// </summary>
        public UInt32 SpecVersion;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    internal struct LayerProperties
    {
        /// <summary>
        /// Layer name
        /// </summary>
        public unsafe fixed byte LayerName[256];
        /// <summary>
        /// Version of the layer specification implemented
        /// </summary>
        public UInt32 SpecVersion;
        /// <summary>
        /// Build or release version of the layer's library
        /// </summary>
        public UInt32 ImplementationVersion;
        /// <summary>
        /// Free-form description of the layer
        /// </summary>
        public unsafe fixed byte Description[256];
    }

    internal struct ApplicationInfo
    {
        /// <summary>
        /// Type of structure. Should be VK_STRUCTURE_TYPE_APPLICATION_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
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
        public IntPtr Allocation;
        public IntPtr Reallocation;
        public IntPtr Free;
        public IntPtr InternalAllocation;
        public IntPtr InternalFree;
    }

    internal struct DeviceQueueCreateInfo
    {
        /// <summary>
        /// Should be VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DeviceQueueCreateFlags Flags;
        public UInt32 QueueFamilyIndex;
        public UInt32 QueueCount;
        public IntPtr QueuePriorities;
    }

    internal struct DeviceCreateInfo
    {
        /// <summary>
        /// Should be VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DeviceCreateFlags Flags;
        public UInt32 QueueCreateInfoCount;
        public IntPtr QueueCreateInfos;
        public UInt32 EnabledLayerCount;
        /// <summary>
        /// Ordered list of layer names to be enabled
        /// </summary>
        public IntPtr EnabledLayerNames;
        public UInt32 EnabledExtensionCount;
        public IntPtr EnabledExtensionNames;
        public IntPtr EnabledFeatures;
    }

    internal struct InstanceCreateInfo
    {
        /// <summary>
        /// Should be VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public InstanceCreateFlags Flags;
        public IntPtr ApplicationInfo;
        public UInt32 EnabledLayerCount;
        /// <summary>
        /// Ordered list of layer names to be enabled
        /// </summary>
        public IntPtr EnabledLayerNames;
        public UInt32 EnabledExtensionCount;
        /// <summary>
        /// Extension names to be enabled
        /// </summary>
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
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Size of memory allocation
        /// </summary>
        public DeviceSize AllocationSize;
        /// <summary>
        /// Index of the of the memory type to allocate from
        /// </summary>
        public UInt32 MemoryTypeIndex;
    }

    internal struct MappedMemoryRange
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_MAPPED_MEMORY_RANGE
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Mapped memory object
        /// </summary>
        public UInt64 Memory;
        /// <summary>
        /// Offset within the memory object where the range starts
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// Size of the range within the memory object
        /// </summary>
        public DeviceSize Size;
    }

    internal struct DescriptorBufferInfo
    {
        /// <summary>
        /// Buffer used for this descriptor slot when the descriptor is UNIFORM_BUFFER[_DYNAMIC] or STORAGE_BUFFER[_DYNAMIC]. VK_NULL_HANDLE otherwise.
        /// </summary>
        public UInt64 Buffer;
        /// <summary>
        /// Base offset from buffer start in bytes to update in the descriptor set.
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// Size in bytes of the buffer resource for this descriptor update.
        /// </summary>
        public DeviceSize Range;
    }

    internal struct DescriptorImageInfo
    {
        /// <summary>
        /// Sampler to write to the descriptor in case it's a SAMPLER or COMBINED_IMAGE_SAMPLER descriptor. Ignored otherwise.
        /// </summary>
        public UInt64 Sampler;
        /// <summary>
        /// Image view to write to the descriptor in case it's a SAMPLED_IMAGE, STORAGE_IMAGE, COMBINED_IMAGE_SAMPLER, or INPUT_ATTACHMENT descriptor. Ignored otherwise.
        /// </summary>
        public UInt64 ImageView;
        /// <summary>
        /// Layout the image is expected to be in when accessed using this descriptor (only used if imageView is not VK_NULL_HANDLE).
        /// </summary>
        public ImageLayout ImageLayout;
    }

    internal struct WriteDescriptorSet
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Destination descriptor set
        /// </summary>
        public UInt64 DstSet;
        /// <summary>
        /// Binding within the destination descriptor set to write
        /// </summary>
        public UInt32 DstBinding;
        /// <summary>
        /// Array element within the destination binding to write
        /// </summary>
        public UInt32 DstArrayElement;
        /// <summary>
        /// Number of descriptors to write (determines the size of the array pointed by pDescriptors)
        /// </summary>
        public UInt32 DescriptorCount;
        /// <summary>
        /// Descriptor type to write (determines which members of the array pointed by pDescriptors are going to be used)
        /// </summary>
        public DescriptorType DescriptorType;
        /// <summary>
        /// Sampler, image view, and layout for SAMPLER, COMBINED_IMAGE_SAMPLER, {SAMPLED,STORAGE}_IMAGE, and INPUT_ATTACHMENT descriptor types.
        /// </summary>
        public IntPtr ImageInfo;
        /// <summary>
        /// Raw buffer, size, and offset for {UNIFORM,STORAGE}_BUFFER[_DYNAMIC] descriptor types.
        /// </summary>
        public IntPtr BufferInfo;
        /// <summary>
        /// Buffer view to write to the descriptor for {UNIFORM,STORAGE}_TEXEL_BUFFER descriptor types.
        /// </summary>
        public IntPtr TexelBufferView;
    }

    internal struct CopyDescriptorSet
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COPY_DESCRIPTOR_SET
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Source descriptor set
        /// </summary>
        public UInt64 SrcSet;
        /// <summary>
        /// Binding within the source descriptor set to copy from
        /// </summary>
        public UInt32 SrcBinding;
        /// <summary>
        /// Array element within the source binding to copy from
        /// </summary>
        public UInt32 SrcArrayElement;
        /// <summary>
        /// Destination descriptor set
        /// </summary>
        public UInt64 DstSet;
        /// <summary>
        /// Binding within the destination descriptor set to copy to
        /// </summary>
        public UInt32 DstBinding;
        /// <summary>
        /// Array element within the destination binding to copy to
        /// </summary>
        public UInt32 DstArrayElement;
        /// <summary>
        /// Number of descriptors to write (determines the size of the array pointed by pDescriptors)
        /// </summary>
        public UInt32 DescriptorCount;
    }

    internal struct BufferCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Buffer creation flags (Optional)
        /// </summary>
        public BufferCreateFlags Flags;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        /// <summary>
        /// Buffer usage flags
        /// </summary>
        public BufferUsageFlags Usage;
        public SharingMode SharingMode;
        public UInt32 QueueFamilyIndexCount;
        public IntPtr QueueFamilyIndices;
    }

    internal struct BufferViewCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_BUFFER_VIEW_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public BufferViewCreateFlags Flags;
        public UInt64 Buffer;
        /// <summary>
        /// Optionally specifies format of elements
        /// </summary>
        public Format Format;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// View size specified in bytes
        /// </summary>
        public DeviceSize Range;
    }

    internal struct MemoryBarrier
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_MEMORY_BARRIER
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask;
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags DstAccessMask;
    }

    internal struct BufferMemoryBarrier
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask;
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags DstAccessMask;
        /// <summary>
        /// Queue family to transition ownership from
        /// </summary>
        public UInt32 SrcQueueFamilyIndex;
        /// <summary>
        /// Queue family to transition ownership to
        /// </summary>
        public UInt32 DstQueueFamilyIndex;
        /// <summary>
        /// Buffer to sync
        /// </summary>
        public UInt64 Buffer;
        /// <summary>
        /// Offset within the buffer to sync
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// Amount of bytes to sync
        /// </summary>
        public DeviceSize Size;
    }

    internal struct ImageMemoryBarrier
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask;
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags DstAccessMask;
        /// <summary>
        /// Current layout of the image
        /// </summary>
        public ImageLayout OldLayout;
        /// <summary>
        /// New layout to transition the image to
        /// </summary>
        public ImageLayout NewLayout;
        /// <summary>
        /// Queue family to transition ownership from
        /// </summary>
        public UInt32 SrcQueueFamilyIndex;
        /// <summary>
        /// Queue family to transition ownership to
        /// </summary>
        public UInt32 DstQueueFamilyIndex;
        /// <summary>
        /// Image to sync
        /// </summary>
        public UInt64 Image;
        /// <summary>
        /// Subresource range to sync
        /// </summary>
        public ImageSubresourceRange SubresourceRange;
    }

    internal struct ImageCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Image creation flags (Optional)
        /// </summary>
        public ImageCreateFlags Flags;
        public ImageType ImageType;
        public Format Format;
        public Extent3D Extent;
        public UInt32 MipLevels;
        public UInt32 ArrayLayers;
        public SampleCountFlags Samples;
        public ImageTiling Tiling;
        /// <summary>
        /// Image usage flags
        /// </summary>
        public ImageUsageFlags Usage;
        /// <summary>
        /// Cross-queue-family sharing mode
        /// </summary>
        public SharingMode SharingMode;
        /// <summary>
        /// Number of queue families to share across (Optional)
        /// </summary>
        public UInt32 QueueFamilyIndexCount;
        /// <summary>
        /// Array of queue family indices to share across
        /// </summary>
        public IntPtr QueueFamilyIndices;
        /// <summary>
        /// Initial image layout for all subresources
        /// </summary>
        public ImageLayout InitialLayout;
    }

    internal struct ImageViewCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public ImageViewCreateFlags Flags;
        public UInt64 Image;
        public ImageViewType ViewType;
        public Format Format;
        public ComponentMapping Components;
        public ImageSubresourceRange SubresourceRange;
    }

    internal struct SparseMemoryBind
    {
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize ResourceOffset;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        public UInt64 Memory;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize MemoryOffset;
        /// <summary>
        /// Reserved for future (Optional)
        /// </summary>
        public SparseMemoryBindFlags Flags;
    }

    internal struct SparseImageMemoryBind
    {
        public ImageSubresource Subresource;
        public Offset3D Offset;
        public Extent3D Extent;
        public UInt64 Memory;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize MemoryOffset;
        /// <summary>
        /// Reserved for future (Optional)
        /// </summary>
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
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_BIND_SPARSE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
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
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D SrcOffsets;
        public ImageSubresourceLayers DstSubresource;
        /// <summary>
        /// Specified in pixels for both compressed and uncompressed images
        /// </summary>
        public Offset3D DstOffsets;
    }

    internal struct ShaderModuleCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public ShaderModuleCreateFlags Flags;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public UInt32 CodeSize;
        /// <summary>
        /// Binary code of size codeSize
        /// </summary>
        public IntPtr Code;
    }

    internal struct DescriptorSetLayoutBinding
    {
        /// <summary>
        /// Binding number for this entry
        /// </summary>
        public UInt32 Binding;
        /// <summary>
        /// Type of the descriptors in this binding
        /// </summary>
        public DescriptorType DescriptorType;
        /// <summary>
        /// Number of descriptors in this binding (Optional)
        /// </summary>
        public UInt32 DescriptorCount;
        /// <summary>
        /// Shader stages this binding is visible to
        /// </summary>
        public ShaderStageFlags StageFlags;
        /// <summary>
        /// Immutable samplers (used if descriptor type is SAMPLER or COMBINED_IMAGE_SAMPLER, is either NULL or contains count number of elements) (Optional)
        /// </summary>
        public IntPtr ImmutableSamplers;
    }

    internal struct DescriptorSetLayoutCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DescriptorSetLayoutCreateFlags Flags;
        /// <summary>
        /// Number of bindings in the descriptor set layout (Optional)
        /// </summary>
        public UInt32 BindingCount;
        /// <summary>
        /// Array of descriptor set layout bindings
        /// </summary>
        public IntPtr Bindings;
    }

    internal struct DescriptorPoolCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public DescriptorPoolCreateFlags Flags;
        public UInt32 MaxSets;
        public UInt32 PoolSizeCount;
        public IntPtr PoolSizes;
    }

    internal struct DescriptorSetAllocateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public UInt64 DescriptorPool;
        public UInt32 DescriptorSetCount;
        public IntPtr SetLayouts;
    }

    internal struct SpecializationInfo
    {
        /// <summary>
        /// Number of entries in the map (Optional)
        /// </summary>
        public UInt32 MapEntryCount;
        /// <summary>
        /// Array of map entries
        /// </summary>
        public IntPtr MapEntries;
        /// <summary>
        /// Size in bytes of pData (Optional)
        /// </summary>
        public UInt32 DataSize;
        /// <summary>
        /// Pointer to SpecConstant data
        /// </summary>
        public IntPtr Data;
    }

    internal struct PipelineShaderStageCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineShaderStageCreateFlags Flags;
        /// <summary>
        /// Shader stage
        /// </summary>
        public ShaderStageFlags Stage;
        /// <summary>
        /// Module containing entry point
        /// </summary>
        public UInt64 Module;
        /// <summary>
        /// Null-terminated entry point name
        /// </summary>
        public IntPtr Name;
        public IntPtr SpecializationInfo;
    }

    internal struct ComputePipelineCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMPUTE_PIPELINE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Pipeline creation flags (Optional)
        /// </summary>
        public PipelineCreateFlags Flags;
        public PipelineShaderStageCreateInfo Stage;
        /// <summary>
        /// Interface layout of the pipeline
        /// </summary>
        public UInt64 Layout;
        /// <summary>
        /// If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of (Optional)
        /// </summary>
        public UInt64 BasePipelineHandle;
        /// <summary>
        /// If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of
        /// </summary>
        public Int32 BasePipelineIndex;
    }

    internal struct PipelineVertexInputStateCreateInfo
    {
        /// <summary>
        /// Should be VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineVertexInputStateCreateFlags Flags;
        /// <summary>
        /// Number of bindings (Optional)
        /// </summary>
        public UInt32 VertexBindingDescriptionCount;
        public IntPtr VertexBindingDescriptions;
        /// <summary>
        /// Number of attributes (Optional)
        /// </summary>
        public UInt32 VertexAttributeDescriptionCount;
        public IntPtr VertexAttributeDescriptions;
    }

    internal struct PipelineInputAssemblyStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_IINPUT_ASSEMBLY_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineInputAssemblyStateCreateFlags Flags;
        public PrimitiveTopology Topology;
        public Bool32 PrimitiveRestartEnable;
    }

    internal struct PipelineTessellationStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineTessellationStateCreateFlags Flags;
        public UInt32 PatchControlPoints;
    }

    internal struct PipelineViewportStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineViewportStateCreateFlags Flags;
        public UInt32 ViewportCount;
        public IntPtr Viewports;
        public UInt32 ScissorCount;
        public IntPtr Scissors;
    }

    internal struct PipelineRasterizationStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineRasterizationStateCreateFlags Flags;
        public Bool32 DepthClampEnable;
        public Bool32 RasterizerDiscardEnable;
        /// <summary>
        /// Optional (GL45)
        /// </summary>
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
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineMultisampleStateCreateFlags Flags;
        /// <summary>
        /// Number of samples used for rasterization
        /// </summary>
        public SampleCountFlags RasterizationSamples;
        /// <summary>
        /// Optional (GL45)
        /// </summary>
        public Bool32 SampleShadingEnable;
        /// <summary>
        /// Optional (GL45)
        /// </summary>
        public Single MinSampleShading;
        /// <summary>
        /// Array of sampleMask words (Optional)
        /// </summary>
        public IntPtr SampleMask;
        public Bool32 AlphaToCoverageEnable;
        public Bool32 AlphaToOneEnable;
    }

    internal struct PipelineColorBlendStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineColorBlendStateCreateFlags Flags;
        public Bool32 LogicOpEnable;
        public LogicOp LogicOp;
        /// <summary>
        /// # of pAttachments (Optional)
        /// </summary>
        public UInt32 AttachmentCount;
        public IntPtr Attachments;
        public unsafe fixed Single BlendConstants[4];
    }

    internal struct PipelineDynamicStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineDynamicStateCreateFlags Flags;
        public UInt32 DynamicStateCount;
        public IntPtr DynamicStates;
    }

    internal struct PipelineDepthStencilStateCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineDepthStencilStateCreateFlags Flags;
        public Bool32 DepthTestEnable;
        public Bool32 DepthWriteEnable;
        public CompareOp DepthCompareOp;
        /// <summary>
        /// Optional (depth_bounds_test)
        /// </summary>
        public Bool32 DepthBoundsTestEnable;
        public Bool32 StencilTestEnable;
        public StencilOpState Front;
        public StencilOpState Back;
        public Single MinDepthBounds;
        public Single MaxDepthBounds;
    }

    internal struct GraphicsPipelineCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Pipeline creation flags (Optional)
        /// </summary>
        public PipelineCreateFlags Flags;
        public UInt32 StageCount;
        /// <summary>
        /// One entry for each active shader stage
        /// </summary>
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
        /// <summary>
        /// Interface layout of the pipeline
        /// </summary>
        public UInt64 Layout;
        public UInt64 RenderPass;
        public UInt32 Subpass;
        /// <summary>
        /// If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of (Optional)
        /// </summary>
        public UInt64 BasePipelineHandle;
        /// <summary>
        /// If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of
        /// </summary>
        public Int32 BasePipelineIndex;
    }

    internal struct PipelineCacheCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_CACHE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineCacheCreateFlags Flags;
        /// <summary>
        /// Size of initial data to populate cache, in bytes (Optional)
        /// </summary>
        public UInt32 InitialDataSize;
        /// <summary>
        /// Initial data to populate cache
        /// </summary>
        public IntPtr InitialData;
    }

    internal struct PipelineLayoutCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineLayoutCreateFlags Flags;
        /// <summary>
        /// Number of descriptor sets interfaced by the pipeline (Optional)
        /// </summary>
        public UInt32 SetLayoutCount;
        /// <summary>
        /// Array of setCount number of descriptor set layout objects defining the layout of the
        /// </summary>
        public IntPtr SetLayouts;
        /// <summary>
        /// Number of push-constant ranges used by the pipeline (Optional)
        /// </summary>
        public UInt32 PushConstantRangeCount;
        /// <summary>
        /// Array of pushConstantRangeCount number of ranges used by various shader stages
        /// </summary>
        public IntPtr PushConstantRanges;
    }

    internal struct SamplerCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public SamplerCreateFlags Flags;
        /// <summary>
        /// Filter mode for magnification
        /// </summary>
        public Filter MagFilter;
        /// <summary>
        /// Filter mode for minifiation
        /// </summary>
        public Filter MinFilter;
        /// <summary>
        /// Mipmap selection mode
        /// </summary>
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
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Command pool creation flags (Optional)
        /// </summary>
        public CommandPoolCreateFlags Flags;
        public UInt32 QueueFamilyIndex;
    }

    internal struct CommandBufferAllocateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public UInt64 CommandPool;
        public CommandBufferLevel Level;
        public UInt32 CommandBufferCount;
    }

    internal struct CommandBufferInheritanceInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Render pass for secondary command buffers (Optional)
        /// </summary>
        public UInt64 RenderPass;
        public UInt32 Subpass;
        /// <summary>
        /// Framebuffer for secondary command buffers (Optional)
        /// </summary>
        public UInt64 Framebuffer;
        /// <summary>
        /// Whether this secondary command buffer may be executed during an occlusion query
        /// </summary>
        public Bool32 OcclusionQueryEnable;
        /// <summary>
        /// Query flags used by this secondary command buffer, if executed during an occlusion query (Optional)
        /// </summary>
        public QueryControlFlags QueryFlags;
        /// <summary>
        /// Pipeline statistics that may be counted for this secondary command buffer (Optional)
        /// </summary>
        public QueryPipelineStatisticFlags PipelineStatistics;
    }

    internal struct CommandBufferBeginInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Command buffer usage flags (Optional)
        /// </summary>
        public CommandBufferUsageFlags Flags;
        /// <summary>
        /// Pointer to inheritance info for secondary command buffers (Optional)
        /// </summary>
        public IntPtr InheritanceInfo;
    }

    internal struct RenderPassBeginInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
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
        /// <summary>
        /// Must be VK_PIPELINE_BIND_POINT_GRAPHICS for now
        /// </summary>
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
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
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
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_EVENT_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Event creation flags (Optional)
        /// </summary>
        public EventCreateFlags Flags;
    }

    internal struct FenceCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_FENCE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Fence creation flags (Optional)
        /// </summary>
        public FenceCreateFlags Flags;
    }

    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    internal struct PhysicalDeviceLimits
    {
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
        public unsafe fixed UInt32 MaxComputeWorkGroupCount[3];
        /// <summary>
        /// Max total compute invocations in a single local work group
        /// </summary>
        public UInt32 MaxComputeWorkGroupInvocations;
        /// <summary>
        /// Max local size of a compute work group (x,y,z)
        /// </summary>
        public unsafe fixed UInt32 MaxComputeWorkGroupSize[3];
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
        public unsafe fixed UInt32 MaxViewportDimensions[2];
        /// <summary>
        /// Viewport bounds range (min,max)
        /// </summary>
        public unsafe fixed Single ViewportBoundsRange[2];
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
        public unsafe fixed Single PointSizeRange[2];
        /// <summary>
        /// Range (min,max) of supported line widths
        /// </summary>
        public unsafe fixed Single LineWidthRange[2];
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

    internal struct SemaphoreCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Semaphore creation flags (Optional)
        /// </summary>
        public SemaphoreCreateFlags Flags;
    }

    internal struct QueryPoolCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public QueryPoolCreateFlags Flags;
        public QueryType QueryType;
        public UInt32 QueryCount;
        /// <summary>
        /// Optional (Optional)
        /// </summary>
        public QueryPipelineStatisticFlags PipelineStatistics;
    }

    internal struct FramebufferCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
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
        /// <summary>
        /// Type of structure. Should be VK_STRUCTURE_TYPE_SUBMIT_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
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
        /// <summary>
        /// Handle of the display object
        /// </summary>
        public UInt64 Display;
        /// <summary>
        /// Name of the display
        /// </summary>
        public IntPtr DisplayName;
        /// <summary>
        /// In millimeters?
        /// </summary>
        public Extent2D PhysicalDimensions;
        /// <summary>
        /// Max resolution for CRT?
        /// </summary>
        public Extent2D PhysicalResolution;
        /// <summary>
        /// One or more bits from VkSurfaceTransformFlagsKHR (Optional)
        /// </summary>
        public SurfaceTransformFlagsKHR SupportedTransforms;
        /// <summary>
        /// VK_TRUE if the overlay plane's z-order can be changed on this display.
        /// </summary>
        public Bool32 PlaneReorderPossible;
        /// <summary>
        /// VK_TRUE if this is a "smart" display that supports self-refresh/internal buffering.
        /// </summary>
        public Bool32 PersistentContent;
    }

    internal struct DisplayPlanePropertiesKHR
    {
        /// <summary>
        /// Display the plane is currently associated with. Will be VK_NULL_HANDLE if the plane is not in use.
        /// </summary>
        public UInt64 CurrentDisplay;
        /// <summary>
        /// Current z-order of the plane.
        /// </summary>
        public UInt32 CurrentStackIndex;
    }

    internal struct DisplayModePropertiesKHR
    {
        /// <summary>
        /// Handle of this display mode.
        /// </summary>
        public UInt64 DisplayMode;
        /// <summary>
        /// The parameters this mode uses.
        /// </summary>
        public DisplayModeParametersKHR Parameters;
    }

    internal struct DisplayModeCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DISPLAY_MODE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DisplayModeCreateFlagsKHR Flags;
        /// <summary>
        /// The parameters this mode uses.
        /// </summary>
        public DisplayModeParametersKHR Parameters;
    }

    internal struct DisplaySurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DISPLAY_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DisplaySurfaceCreateFlagsKHR Flags;
        /// <summary>
        /// The mode to use when displaying this surface
        /// </summary>
        public UInt64 DisplayMode;
        /// <summary>
        /// The plane on which this surface appears. Must be between 0 and the value returned by vkGetPhysicalDeviceDisplayPlanePropertiesKHR() in pPropertyCount.
        /// </summary>
        public UInt32 PlaneIndex;
        /// <summary>
        /// The z-order of the plane.
        /// </summary>
        public UInt32 PlaneStackIndex;
        /// <summary>
        /// Transform to apply to the images as part of the scannout operation
        /// </summary>
        public SurfaceTransformFlagsKHR Transform;
        /// <summary>
        /// Global alpha value. Must be between 0 and 1, inclusive. Ignored if alphaMode is not VK_DISPLAY_PLANE_ALPHA_GLOBAL_BIT_KHR
        /// </summary>
        public Single GlobalAlpha;
        /// <summary>
        /// What type of alpha blending to use. Must be a bit from vkGetDisplayPlanePropertiesKHR::supportedAlpha.
        /// </summary>
        public DisplayPlaneAlphaFlagsKHR AlphaMode;
        /// <summary>
        /// Size of the images to use with this surface
        /// </summary>
        public Extent2D ImageExtent;
    }

    internal struct DisplayPresentInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DISPLAY_PRESENT_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Rectangle within the presentable image to read pixel data from when presenting to the display.
        /// </summary>
        public Rect2D SrcRect;
        /// <summary>
        /// Rectangle within the current display mode's visible region to display srcRectangle in.
        /// </summary>
        public Rect2D DstRect;
        /// <summary>
        /// For smart displays, use buffered mode. If the display properties member "persistentMode" is VK_FALSE, this member must always be VK_FALSE.
        /// </summary>
        public Bool32 Persistent;
    }

    internal struct AndroidSurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_ANDROID_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public AndroidSurfaceCreateFlagsKHR Flags;
        public IntPtr Window;
    }

    internal struct MirSurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_MIR_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public MirSurfaceCreateFlagsKHR Flags;
        public IntPtr Connection;
        public IntPtr MirSurface;
    }

    internal struct WaylandSurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public WaylandSurfaceCreateFlagsKHR Flags;
        public IntPtr Display;
        public IntPtr Surface;
    }

    internal struct Win32SurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public Win32SurfaceCreateFlagsKHR Flags;
        public IntPtr Hinstance;
        public IntPtr Hwnd;
    }

    internal struct XlibSurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public XlibSurfaceCreateFlagsKHR Flags;
        public IntPtr Dpy;
        public IntPtr Window;
    }

    internal struct XcbSurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_XCB_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public XcbSurfaceCreateFlagsKHR Flags;
        public IntPtr Connection;
        public IntPtr Window;
    }

    internal struct SwapchainCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public SwapchainCreateFlagsKHR Flags;
        /// <summary>
        /// The swapchain's target surface
        /// </summary>
        public UInt64 Surface;
        /// <summary>
        /// Minimum number of presentation images the application needs
        /// </summary>
        public UInt32 MinImageCount;
        /// <summary>
        /// Format of the presentation images
        /// </summary>
        public Format ImageFormat;
        /// <summary>
        /// Colorspace of the presentation images
        /// </summary>
        public ColorSpaceKHR ImageColorSpace;
        /// <summary>
        /// Dimensions of the presentation images
        /// </summary>
        public Extent2D ImageExtent;
        /// <summary>
        /// Determines the number of views for multiview/stereo presentation
        /// </summary>
        public UInt32 ImageArrayLayers;
        /// <summary>
        /// Bits indicating how the presentation images will be used
        /// </summary>
        public ImageUsageFlags ImageUsage;
        /// <summary>
        /// Sharing mode used for the presentation images
        /// </summary>
        public SharingMode ImageSharingMode;
        /// <summary>
        /// Number of queue families having access to the images in case of concurrent sharing mode (Optional)
        /// </summary>
        public UInt32 QueueFamilyIndexCount;
        /// <summary>
        /// Array of queue family indices having access to the images in case of concurrent sharing mode
        /// </summary>
        public IntPtr QueueFamilyIndices;
        /// <summary>
        /// The transform, relative to the device's natural orientation, applied to the image content prior to presentation
        /// </summary>
        public SurfaceTransformFlagsKHR PreTransform;
        /// <summary>
        /// The alpha blending mode used when compositing this surface with other surfaces in the window system
        /// </summary>
        public CompositeAlphaFlagsKHR CompositeAlpha;
        /// <summary>
        /// Which presentation mode to use for presents on this swap chain
        /// </summary>
        public PresentModeKHR PresentMode;
        /// <summary>
        /// Specifies whether presentable images may be affected by window clip regions
        /// </summary>
        public Bool32 Clipped;
        /// <summary>
        /// Existing swap chain to replace, if any (Optional)
        /// </summary>
        public UInt64 OldSwapchain;
    }

    internal struct PresentInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PRESENT_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Number of semaphores to wait for before presenting (Optional)
        /// </summary>
        public UInt32 WaitSemaphoreCount;
        /// <summary>
        /// Semaphores to wait for before presenting (Optional)
        /// </summary>
        public IntPtr WaitSemaphores;
        /// <summary>
        /// Number of swap chains to present in this call
        /// </summary>
        public UInt32 SwapchainCount;
        /// <summary>
        /// Swapchains to present an image from
        /// </summary>
        public IntPtr Swapchains;
        /// <summary>
        /// Indices of which swapchain images to present
        /// </summary>
        public IntPtr ImageIndices;
        /// <summary>
        /// Optional (i.e. if non-NULL) VkResult for each swapchain (Optional)
        /// </summary>
        public IntPtr Results;
    }

    internal struct DebugReportCallbackCreateInfoEXT
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Indicates which events call this callback
        /// </summary>
        public DebugReportFlagsEXT Flags;
        /// <summary>
        /// Function pointer of a callback function
        /// </summary>
        public IntPtr Callback;
        /// <summary>
        /// User data provided to callback function (Optional)
        /// </summary>
        public IntPtr UserData;
    }

    internal struct PipelineRasterizationStateRasterizationOrderAMD
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_RASTERIZATION_ORDER_AMD
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Rasterization order to use for the pipeline
        /// </summary>
        public RasterizationOrderAMD RasterizationOrder;
    }

    internal struct DebugMarkerObjectNameInfoEXT
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_NAME_INFO_EXT
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// The type of the object
        /// </summary>
        public DebugReportObjectTypeEXT ObjectType;
        /// <summary>
        /// The handle of the object, cast to uint64_t
        /// </summary>
        public UInt64 Object;
        /// <summary>
        /// Name to apply to the object
        /// </summary>
        public IntPtr ObjectName;
    }

    internal struct DebugMarkerObjectTagInfoEXT
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_TAG_INFO_EXT
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// The type of the object
        /// </summary>
        public DebugReportObjectTypeEXT ObjectType;
        /// <summary>
        /// The handle of the object, cast to uint64_t
        /// </summary>
        public UInt64 Object;
        /// <summary>
        /// The name of the tag to set on the object
        /// </summary>
        public UInt64 TagName;
        /// <summary>
        /// The length in bytes of the tag data
        /// </summary>
        public UInt32 TagSize;
        /// <summary>
        /// Tag data to attach to the object
        /// </summary>
        public IntPtr Tag;
    }

    internal struct DebugMarkerMarkerInfoEXT
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEBUG_MARKER_MARKER_INFO_EXT
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Name of the debug marker
        /// </summary>
        public IntPtr MarkerName;
        /// <summary>
        /// Optional color for debug marker (Optional)
        /// </summary>
        public unsafe fixed Single Color[4];
    }

}
