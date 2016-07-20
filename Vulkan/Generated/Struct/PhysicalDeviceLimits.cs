using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDeviceLimits
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MaxComputeWorkGroupCountInfo
        {
            public UInt32 X;
            public UInt32 Y;
            public UInt32 Z;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MaxComputeWorkGroupSizeInfo
        {
            public UInt32 X;
            public UInt32 Y;
            public UInt32 Z;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MaxViewportDimensionsInfo
        {
            public UInt32 X;
            public UInt32 Y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct ViewportBoundsRangeInfo
        {
            public Single Min;
            public Single Max;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct PointSizeRangeInfo
        {
            public Single Min;
            public Single Max;
        }
        [StructLayout(LayoutKind.Sequential)]
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
        public Size MinMemoryMapAlignment;
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
}
