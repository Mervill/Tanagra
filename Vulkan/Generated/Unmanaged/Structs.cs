using System;

namespace Vulkan.Unmanaged
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct PhysicalDeviceProperties
    {
        public struct PipelineCacheUUIDInfo
        {
            public Byte Value0;
            public Byte Value1;
            public Byte Value2;
            public Byte Value3;
            public Byte Value4;
            public Byte Value5;
            public Byte Value6;
            public Byte Value7;
            public Byte Value8;
            public Byte Value9;
            public Byte Value10;
            public Byte Value11;
            public Byte Value12;
            public Byte Value13;
            public Byte Value14;
            public Byte Value15;
        }
        public UInt32 ApiVersion;
        public UInt32 DriverVersion;
        public UInt32 VendorID;
        public UInt32 DeviceID;
        public PhysicalDeviceType DeviceType;
        public unsafe fixed Byte DeviceName[256];
        public PipelineCacheUUIDInfo PipelineCacheUUID;
        public PhysicalDeviceLimits Limits;
        public PhysicalDeviceSparseProperties SparseProperties;
    }
    
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct ExtensionProperties
    {
        /// <summary>
        /// Extension name
        /// </summary>
        public unsafe fixed Byte ExtensionName[256];
        /// <summary>
        /// Version of the extension specification implemented
        /// </summary>
        public UInt32 SpecVersion;
    }
    
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    public struct LayerProperties
    {
        /// <summary>
        /// Layer name
        /// </summary>
        public unsafe fixed Byte LayerName[256];
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
        public unsafe fixed Byte Description[256];
    }
    
    public struct ApplicationInfo
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
    
    public struct AllocationCallbacks
    {
        public IntPtr UserData;
        public IntPtr Allocation;
        public IntPtr Reallocation;
        public IntPtr Free;
        public IntPtr InternalAllocation;
        public IntPtr InternalFree;
    }
    
    public struct DeviceQueueCreateInfo
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
    
    public struct DeviceCreateInfo
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
    
    public struct InstanceCreateInfo
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
    
    public struct MemoryAllocateInfo
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
    
    public struct MappedMemoryRange
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
    
    public struct DescriptorBufferInfo
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
    
    public struct DescriptorImageInfo
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
    
    public struct WriteDescriptorSet
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
    
    public struct CopyDescriptorSet
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
    
    public struct BufferCreateInfo
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
    
    public struct BufferViewCreateInfo
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
    
    public struct MemoryBarrier
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
    
    public struct BufferMemoryBarrier
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
    
    public struct ImageMemoryBarrier
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
    
    public struct ImageCreateInfo
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
    
    public struct ImageViewCreateInfo
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
    
    public struct SparseMemoryBind
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
    
    public struct SparseImageMemoryBind
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
    
    public struct SparseBufferMemoryBindInfo
    {
        public UInt64 Buffer;
        public UInt32 BindCount;
        public IntPtr Binds;
    }
    
    public struct SparseImageOpaqueMemoryBindInfo
    {
        public UInt64 Image;
        public UInt32 BindCount;
        public IntPtr Binds;
    }
    
    public struct SparseImageMemoryBindInfo
    {
        public UInt64 Image;
        public UInt32 BindCount;
        public IntPtr Binds;
    }
    
    public struct BindSparseInfo
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
    
    public struct ShaderModuleCreateInfo
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
    
    public struct DescriptorSetLayoutBinding
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
    
    public struct DescriptorSetLayoutCreateInfo
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
    
    public struct DescriptorPoolCreateInfo
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
    
    public struct DescriptorSetAllocateInfo
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
    
    public struct SpecializationInfo
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
    
    public struct PipelineShaderStageCreateInfo
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
    
    public struct ComputePipelineCreateInfo
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
    
    public struct PipelineVertexInputStateCreateInfo
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
    
    public struct PipelineInputAssemblyStateCreateInfo
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
    
    public struct PipelineTessellationStateCreateInfo
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
    
    public struct PipelineViewportStateCreateInfo
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
    
    public struct PipelineRasterizationStateCreateInfo
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
    
    public struct PipelineMultisampleStateCreateInfo
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
    
    public struct PipelineColorBlendStateCreateInfo
    {
        public struct BlendConstantsInfo
        {
            public Single R;
            public Single G;
            public Single B;
            public Single A;
        }
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
        public BlendConstantsInfo BlendConstants;
    }
    
    public struct PipelineDynamicStateCreateInfo
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
    
    public struct PipelineDepthStencilStateCreateInfo
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
    
    public struct GraphicsPipelineCreateInfo
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
    
    public struct PipelineCacheCreateInfo
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
    
    public struct PipelineLayoutCreateInfo
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
    
    public struct SamplerCreateInfo
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
    
    public struct CommandPoolCreateInfo
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
    
    public struct CommandBufferAllocateInfo
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
    
    public struct CommandBufferInheritanceInfo
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
    
    public struct CommandBufferBeginInfo
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
    
    public struct RenderPassBeginInfo
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
    
    public struct SubpassDescription
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
    
    public struct RenderPassCreateInfo
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
    
    public struct EventCreateInfo
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
    
    public struct FenceCreateInfo
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
    
    public struct SemaphoreCreateInfo
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
    
    public struct QueryPoolCreateInfo
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
    
    public struct FramebufferCreateInfo
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
    
    public struct SubmitInfo
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
    
    public struct DisplayPropertiesKHR
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
    
    public struct DisplayPlanePropertiesKHR
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
    
    public struct DisplayModePropertiesKHR
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
    
    public struct DisplayModeCreateInfoKHR
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
    
    public struct DisplaySurfaceCreateInfoKHR
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
    
    public struct DisplayPresentInfoKHR
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
    
    public struct AndroidSurfaceCreateInfoKHR
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
    
    public struct MirSurfaceCreateInfoKHR
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
    
    public struct WaylandSurfaceCreateInfoKHR
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
    
    public struct Win32SurfaceCreateInfoKHR
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
    
    public struct XlibSurfaceCreateInfoKHR
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
    
    public struct XcbSurfaceCreateInfoKHR
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
    
    public struct SwapchainCreateInfoKHR
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
    
    public struct PresentInfoKHR
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
    
    public struct DebugReportCallbackCreateInfoEXT
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
    
    public struct PipelineRasterizationStateRasterizationOrderAMD
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
    
    public struct DebugMarkerObjectNameInfoEXT
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
    
    public struct DebugMarkerObjectTagInfoEXT
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
    
    public struct DebugMarkerMarkerInfoEXT
    {
        public struct ColorInfo
        {
            public Single R;
            public Single G;
            public Single B;
            public Single A;
        }
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
        public ColorInfo Color;
    }
    
}
