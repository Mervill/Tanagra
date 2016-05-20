using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class PhysicalDeviceLimits : IDisposable
    {
        internal Unmanaged.PhysicalDeviceLimits* NativePointer;
        
        /// <summary>
        /// Max 1D image dimension
        /// </summary>
        public UInt32 MaxImageDimension1D
        {
            get { return NativePointer->MaxImageDimension1D; }
        }
        
        /// <summary>
        /// Max 2D image dimension
        /// </summary>
        public UInt32 MaxImageDimension2D
        {
            get { return NativePointer->MaxImageDimension2D; }
        }
        
        /// <summary>
        /// Max 3D image dimension
        /// </summary>
        public UInt32 MaxImageDimension3D
        {
            get { return NativePointer->MaxImageDimension3D; }
        }
        
        /// <summary>
        /// Max cubemap image dimension
        /// </summary>
        public UInt32 MaxImageDimensionCube
        {
            get { return NativePointer->MaxImageDimensionCube; }
        }
        
        /// <summary>
        /// Max layers for image arrays
        /// </summary>
        public UInt32 MaxImageArrayLayers
        {
            get { return NativePointer->MaxImageArrayLayers; }
        }
        
        /// <summary>
        /// Max texel buffer size (fstexels)
        /// </summary>
        public UInt32 MaxTexelBufferElements
        {
            get { return NativePointer->MaxTexelBufferElements; }
        }
        
        /// <summary>
        /// Max uniform buffer range (bytes)
        /// </summary>
        public UInt32 MaxUniformBufferRange
        {
            get { return NativePointer->MaxUniformBufferRange; }
        }
        
        /// <summary>
        /// Max storage buffer range (bytes)
        /// </summary>
        public UInt32 MaxStorageBufferRange
        {
            get { return NativePointer->MaxStorageBufferRange; }
        }
        
        /// <summary>
        /// Max size of the push constants pool (bytes)
        /// </summary>
        public UInt32 MaxPushConstantsSize
        {
            get { return NativePointer->MaxPushConstantsSize; }
        }
        
        /// <summary>
        /// Max number of device memory allocations supported
        /// </summary>
        public UInt32 MaxMemoryAllocationCount
        {
            get { return NativePointer->MaxMemoryAllocationCount; }
        }
        
        /// <summary>
        /// Max number of samplers that can be allocated on a device
        /// </summary>
        public UInt32 MaxSamplerAllocationCount
        {
            get { return NativePointer->MaxSamplerAllocationCount; }
        }
        
        /// <summary>
        /// Granularity (in bytes) at which buffers and images can be bound to adjacent memory for simultaneous usage
        /// </summary>
        public DeviceSize BufferImageGranularity
        {
            get { return NativePointer->BufferImageGranularity; }
        }
        
        /// <summary>
        /// Total address space available for sparse allocations (bytes)
        /// </summary>
        public DeviceSize SparseAddressSpaceSize
        {
            get { return NativePointer->SparseAddressSpaceSize; }
        }
        
        /// <summary>
        /// Max number of descriptors sets that can be bound to a pipeline
        /// </summary>
        public UInt32 MaxBoundDescriptorSets
        {
            get { return NativePointer->MaxBoundDescriptorSets; }
        }
        
        /// <summary>
        /// Max number of samplers allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorSamplers
        {
            get { return NativePointer->MaxPerStageDescriptorSamplers; }
        }
        
        /// <summary>
        /// Max number of uniform buffers allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorUniformBuffers
        {
            get { return NativePointer->MaxPerStageDescriptorUniformBuffers; }
        }
        
        /// <summary>
        /// Max number of storage buffers allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorStorageBuffers
        {
            get { return NativePointer->MaxPerStageDescriptorStorageBuffers; }
        }
        
        /// <summary>
        /// Max number of sampled images allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorSampledImages
        {
            get { return NativePointer->MaxPerStageDescriptorSampledImages; }
        }
        
        /// <summary>
        /// Max number of storage images allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorStorageImages
        {
            get { return NativePointer->MaxPerStageDescriptorStorageImages; }
        }
        
        /// <summary>
        /// Max number of input attachments allowed per-stage in a descriptor set
        /// </summary>
        public UInt32 MaxPerStageDescriptorInputAttachments
        {
            get { return NativePointer->MaxPerStageDescriptorInputAttachments; }
        }
        
        /// <summary>
        /// Max number of resources allowed by a single stage
        /// </summary>
        public UInt32 MaxPerStageResources
        {
            get { return NativePointer->MaxPerStageResources; }
        }
        
        /// <summary>
        /// Max number of samplers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetSamplers
        {
            get { return NativePointer->MaxDescriptorSetSamplers; }
        }
        
        /// <summary>
        /// Max number of uniform buffers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetUniformBuffers
        {
            get { return NativePointer->MaxDescriptorSetUniformBuffers; }
        }
        
        /// <summary>
        /// Max number of dynamic uniform buffers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetUniformBuffersDynamic
        {
            get { return NativePointer->MaxDescriptorSetUniformBuffersDynamic; }
        }
        
        /// <summary>
        /// Max number of storage buffers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetStorageBuffers
        {
            get { return NativePointer->MaxDescriptorSetStorageBuffers; }
        }
        
        /// <summary>
        /// Max number of dynamic storage buffers allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetStorageBuffersDynamic
        {
            get { return NativePointer->MaxDescriptorSetStorageBuffersDynamic; }
        }
        
        /// <summary>
        /// Max number of sampled images allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetSampledImages
        {
            get { return NativePointer->MaxDescriptorSetSampledImages; }
        }
        
        /// <summary>
        /// Max number of storage images allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetStorageImages
        {
            get { return NativePointer->MaxDescriptorSetStorageImages; }
        }
        
        /// <summary>
        /// Max number of input attachments allowed in all stages in a descriptor set
        /// </summary>
        public UInt32 MaxDescriptorSetInputAttachments
        {
            get { return NativePointer->MaxDescriptorSetInputAttachments; }
        }
        
        /// <summary>
        /// Max number of vertex input attribute slots
        /// </summary>
        public UInt32 MaxVertexInputAttributes
        {
            get { return NativePointer->MaxVertexInputAttributes; }
        }
        
        /// <summary>
        /// Max number of vertex input binding slots
        /// </summary>
        public UInt32 MaxVertexInputBindings
        {
            get { return NativePointer->MaxVertexInputBindings; }
        }
        
        /// <summary>
        /// Max vertex input attribute offset added to vertex buffer offset
        /// </summary>
        public UInt32 MaxVertexInputAttributeOffset
        {
            get { return NativePointer->MaxVertexInputAttributeOffset; }
        }
        
        /// <summary>
        /// Max vertex input binding stride
        /// </summary>
        public UInt32 MaxVertexInputBindingStride
        {
            get { return NativePointer->MaxVertexInputBindingStride; }
        }
        
        /// <summary>
        /// Max number of output components written by vertex shader
        /// </summary>
        public UInt32 MaxVertexOutputComponents
        {
            get { return NativePointer->MaxVertexOutputComponents; }
        }
        
        /// <summary>
        /// Max level supported by tessellation primitive generator
        /// </summary>
        public UInt32 MaxTessellationGenerationLevel
        {
            get { return NativePointer->MaxTessellationGenerationLevel; }
        }
        
        /// <summary>
        /// Max patch size (vertices)
        /// </summary>
        public UInt32 MaxTessellationPatchSize
        {
            get { return NativePointer->MaxTessellationPatchSize; }
        }
        
        /// <summary>
        /// Max number of input components per-vertex in TCS
        /// </summary>
        public UInt32 MaxTessellationControlPerVertexInputComponents
        {
            get { return NativePointer->MaxTessellationControlPerVertexInputComponents; }
        }
        
        /// <summary>
        /// Max number of output components per-vertex in TCS
        /// </summary>
        public UInt32 MaxTessellationControlPerVertexOutputComponents
        {
            get { return NativePointer->MaxTessellationControlPerVertexOutputComponents; }
        }
        
        /// <summary>
        /// Max number of output components per-patch in TCS
        /// </summary>
        public UInt32 MaxTessellationControlPerPatchOutputComponents
        {
            get { return NativePointer->MaxTessellationControlPerPatchOutputComponents; }
        }
        
        /// <summary>
        /// Max total number of per-vertex and per-patch output components in TCS
        /// </summary>
        public UInt32 MaxTessellationControlTotalOutputComponents
        {
            get { return NativePointer->MaxTessellationControlTotalOutputComponents; }
        }
        
        /// <summary>
        /// Max number of input components per vertex in TES
        /// </summary>
        public UInt32 MaxTessellationEvaluationInputComponents
        {
            get { return NativePointer->MaxTessellationEvaluationInputComponents; }
        }
        
        /// <summary>
        /// Max number of output components per vertex in TES
        /// </summary>
        public UInt32 MaxTessellationEvaluationOutputComponents
        {
            get { return NativePointer->MaxTessellationEvaluationOutputComponents; }
        }
        
        /// <summary>
        /// Max invocation count supported in geometry shader
        /// </summary>
        public UInt32 MaxGeometryShaderInvocations
        {
            get { return NativePointer->MaxGeometryShaderInvocations; }
        }
        
        /// <summary>
        /// Max number of input components read in geometry stage
        /// </summary>
        public UInt32 MaxGeometryInputComponents
        {
            get { return NativePointer->MaxGeometryInputComponents; }
        }
        
        /// <summary>
        /// Max number of output components written in geometry stage
        /// </summary>
        public UInt32 MaxGeometryOutputComponents
        {
            get { return NativePointer->MaxGeometryOutputComponents; }
        }
        
        /// <summary>
        /// Max number of vertices that can be emitted in geometry stage
        /// </summary>
        public UInt32 MaxGeometryOutputVertices
        {
            get { return NativePointer->MaxGeometryOutputVertices; }
        }
        
        /// <summary>
        /// Max total number of components (all vertices) written in geometry stage
        /// </summary>
        public UInt32 MaxGeometryTotalOutputComponents
        {
            get { return NativePointer->MaxGeometryTotalOutputComponents; }
        }
        
        /// <summary>
        /// Max number of input compontents read in fragment stage
        /// </summary>
        public UInt32 MaxFragmentInputComponents
        {
            get { return NativePointer->MaxFragmentInputComponents; }
        }
        
        /// <summary>
        /// Max number of output attachments written in fragment stage
        /// </summary>
        public UInt32 MaxFragmentOutputAttachments
        {
            get { return NativePointer->MaxFragmentOutputAttachments; }
        }
        
        /// <summary>
        /// Max number of output attachments written when using dual source blending
        /// </summary>
        public UInt32 MaxFragmentDualSrcAttachments
        {
            get { return NativePointer->MaxFragmentDualSrcAttachments; }
        }
        
        /// <summary>
        /// Max total number of storage buffers, storage images and output buffers
        /// </summary>
        public UInt32 MaxFragmentCombinedOutputResources
        {
            get { return NativePointer->MaxFragmentCombinedOutputResources; }
        }
        
        /// <summary>
        /// Max total storage size of work group local storage (bytes)
        /// </summary>
        public UInt32 MaxComputeSharedMemorySize
        {
            get { return NativePointer->MaxComputeSharedMemorySize; }
        }
        
        /// <summary>
        /// Max num of compute work groups that may be dispatched by a single command (x,y,z)
        /// </summary>
        public UInt32[] MaxComputeWorkGroupCount
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        /// <summary>
        /// Max total compute invocations in a single local work group
        /// </summary>
        public UInt32 MaxComputeWorkGroupInvocations
        {
            get { return NativePointer->MaxComputeWorkGroupInvocations; }
        }
        
        /// <summary>
        /// Max local size of a compute work group (x,y,z)
        /// </summary>
        public UInt32[] MaxComputeWorkGroupSize
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        /// <summary>
        /// Number bits of subpixel precision in screen x and y
        /// </summary>
        public UInt32 SubPixelPrecisionBits
        {
            get { return NativePointer->SubPixelPrecisionBits; }
        }
        
        /// <summary>
        /// Number bits of precision for selecting texel weights
        /// </summary>
        public UInt32 SubTexelPrecisionBits
        {
            get { return NativePointer->SubTexelPrecisionBits; }
        }
        
        /// <summary>
        /// Number bits of precision for selecting mipmap weights
        /// </summary>
        public UInt32 MipmapPrecisionBits
        {
            get { return NativePointer->MipmapPrecisionBits; }
        }
        
        /// <summary>
        /// Max index value for indexed draw calls (for 32-bit indices)
        /// </summary>
        public UInt32 MaxDrawIndexedIndexValue
        {
            get { return NativePointer->MaxDrawIndexedIndexValue; }
        }
        
        /// <summary>
        /// Max draw count for indirect draw calls
        /// </summary>
        public UInt32 MaxDrawIndirectCount
        {
            get { return NativePointer->MaxDrawIndirectCount; }
        }
        
        /// <summary>
        /// Max absolute sampler level of detail bias
        /// </summary>
        public Single MaxSamplerLodBias
        {
            get { return NativePointer->MaxSamplerLodBias; }
        }
        
        /// <summary>
        /// Max degree of sampler anisotropy
        /// </summary>
        public Single MaxSamplerAnisotropy
        {
            get { return NativePointer->MaxSamplerAnisotropy; }
        }
        
        /// <summary>
        /// Max number of active viewports
        /// </summary>
        public UInt32 MaxViewports
        {
            get { return NativePointer->MaxViewports; }
        }
        
        /// <summary>
        /// Max viewport dimensions (x,y)
        /// </summary>
        public UInt32[] MaxViewportDimensions
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        /// <summary>
        /// Viewport bounds range (min,max)
        /// </summary>
        public Single[] ViewportBoundsRange
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        /// <summary>
        /// Number bits of subpixel precision for viewport
        /// </summary>
        public UInt32 ViewportSubPixelBits
        {
            get { return NativePointer->ViewportSubPixelBits; }
        }
        
        /// <summary>
        /// Min required alignment of pointers returned by MapMemory (bytes)
        /// </summary>
        public UInt32 MinMemoryMapAlignment
        {
            get { return NativePointer->MinMemoryMapAlignment; }
        }
        
        /// <summary>
        /// Min required alignment for texel buffer offsets (bytes)
        /// </summary>
        public DeviceSize MinTexelBufferOffsetAlignment
        {
            get { return NativePointer->MinTexelBufferOffsetAlignment; }
        }
        
        /// <summary>
        /// Min required alignment for uniform buffer sizes and offsets (bytes)
        /// </summary>
        public DeviceSize MinUniformBufferOffsetAlignment
        {
            get { return NativePointer->MinUniformBufferOffsetAlignment; }
        }
        
        /// <summary>
        /// Min required alignment for storage buffer offsets (bytes)
        /// </summary>
        public DeviceSize MinStorageBufferOffsetAlignment
        {
            get { return NativePointer->MinStorageBufferOffsetAlignment; }
        }
        
        /// <summary>
        /// Min texel offset for OpTextureSampleOffset
        /// </summary>
        public Int32 MinTexelOffset
        {
            get { return NativePointer->MinTexelOffset; }
        }
        
        /// <summary>
        /// Max texel offset for OpTextureSampleOffset
        /// </summary>
        public UInt32 MaxTexelOffset
        {
            get { return NativePointer->MaxTexelOffset; }
        }
        
        /// <summary>
        /// Min texel offset for OpTextureGatherOffset
        /// </summary>
        public Int32 MinTexelGatherOffset
        {
            get { return NativePointer->MinTexelGatherOffset; }
        }
        
        /// <summary>
        /// Max texel offset for OpTextureGatherOffset
        /// </summary>
        public UInt32 MaxTexelGatherOffset
        {
            get { return NativePointer->MaxTexelGatherOffset; }
        }
        
        /// <summary>
        /// Furthest negative offset for interpolateAtOffset
        /// </summary>
        public Single MinInterpolationOffset
        {
            get { return NativePointer->MinInterpolationOffset; }
        }
        
        /// <summary>
        /// Furthest positive offset for interpolateAtOffset
        /// </summary>
        public Single MaxInterpolationOffset
        {
            get { return NativePointer->MaxInterpolationOffset; }
        }
        
        /// <summary>
        /// Number of subpixel bits for interpolateAtOffset
        /// </summary>
        public UInt32 SubPixelInterpolationOffsetBits
        {
            get { return NativePointer->SubPixelInterpolationOffsetBits; }
        }
        
        /// <summary>
        /// Max width for a framebuffer
        /// </summary>
        public UInt32 MaxFramebufferWidth
        {
            get { return NativePointer->MaxFramebufferWidth; }
        }
        
        /// <summary>
        /// Max height for a framebuffer
        /// </summary>
        public UInt32 MaxFramebufferHeight
        {
            get { return NativePointer->MaxFramebufferHeight; }
        }
        
        /// <summary>
        /// Max layer count for a layered framebuffer
        /// </summary>
        public UInt32 MaxFramebufferLayers
        {
            get { return NativePointer->MaxFramebufferLayers; }
        }
        
        /// <summary>
        /// Supported color sample counts for a framebuffer (Optional)
        /// </summary>
        public SampleCountFlags FramebufferColorSampleCounts
        {
            get { return NativePointer->FramebufferColorSampleCounts; }
        }
        
        /// <summary>
        /// Supported depth sample counts for a framebuffer (Optional)
        /// </summary>
        public SampleCountFlags FramebufferDepthSampleCounts
        {
            get { return NativePointer->FramebufferDepthSampleCounts; }
        }
        
        /// <summary>
        /// Supported stencil sample counts for a framebuffer (Optional)
        /// </summary>
        public SampleCountFlags FramebufferStencilSampleCounts
        {
            get { return NativePointer->FramebufferStencilSampleCounts; }
        }
        
        /// <summary>
        /// Supported sample counts for a framebuffer with no attachments (Optional)
        /// </summary>
        public SampleCountFlags FramebufferNoAttachmentsSampleCounts
        {
            get { return NativePointer->FramebufferNoAttachmentsSampleCounts; }
        }
        
        /// <summary>
        /// Max number of color attachments per subpass
        /// </summary>
        public UInt32 MaxColorAttachments
        {
            get { return NativePointer->MaxColorAttachments; }
        }
        
        /// <summary>
        /// Supported color sample counts for a non-integer sampled image (Optional)
        /// </summary>
        public SampleCountFlags SampledImageColorSampleCounts
        {
            get { return NativePointer->SampledImageColorSampleCounts; }
        }
        
        /// <summary>
        /// Supported sample counts for an integer image (Optional)
        /// </summary>
        public SampleCountFlags SampledImageIntegerSampleCounts
        {
            get { return NativePointer->SampledImageIntegerSampleCounts; }
        }
        
        /// <summary>
        /// Supported depth sample counts for a sampled image (Optional)
        /// </summary>
        public SampleCountFlags SampledImageDepthSampleCounts
        {
            get { return NativePointer->SampledImageDepthSampleCounts; }
        }
        
        /// <summary>
        /// Supported stencil sample counts for a sampled image (Optional)
        /// </summary>
        public SampleCountFlags SampledImageStencilSampleCounts
        {
            get { return NativePointer->SampledImageStencilSampleCounts; }
        }
        
        /// <summary>
        /// Supported sample counts for a storage image (Optional)
        /// </summary>
        public SampleCountFlags StorageImageSampleCounts
        {
            get { return NativePointer->StorageImageSampleCounts; }
        }
        
        /// <summary>
        /// Max number of sample mask words
        /// </summary>
        public UInt32 MaxSampleMaskWords
        {
            get { return NativePointer->MaxSampleMaskWords; }
        }
        
        /// <summary>
        /// Timestamps on graphics and compute queues
        /// </summary>
        public Bool32 TimestampComputeAndGraphics
        {
            get { return NativePointer->TimestampComputeAndGraphics; }
        }
        
        /// <summary>
        /// Number of nanoseconds it takes for timestamp query value to increment by 1
        /// </summary>
        public Single TimestampPeriod
        {
            get { return NativePointer->TimestampPeriod; }
        }
        
        /// <summary>
        /// Max number of clip distances
        /// </summary>
        public UInt32 MaxClipDistances
        {
            get { return NativePointer->MaxClipDistances; }
        }
        
        /// <summary>
        /// Max number of cull distances
        /// </summary>
        public UInt32 MaxCullDistances
        {
            get { return NativePointer->MaxCullDistances; }
        }
        
        /// <summary>
        /// Max combined number of user clipping
        /// </summary>
        public UInt32 MaxCombinedClipAndCullDistances
        {
            get { return NativePointer->MaxCombinedClipAndCullDistances; }
        }
        
        /// <summary>
        /// Distinct queue priorities available
        /// </summary>
        public UInt32 DiscreteQueuePriorities
        {
            get { return NativePointer->DiscreteQueuePriorities; }
        }
        
        /// <summary>
        /// Range (min,max) of supported point sizes
        /// </summary>
        public Single[] PointSizeRange
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        /// <summary>
        /// Range (min,max) of supported line widths
        /// </summary>
        public Single[] LineWidthRange
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        /// <summary>
        /// Granularity of supported point sizes
        /// </summary>
        public Single PointSizeGranularity
        {
            get { return NativePointer->PointSizeGranularity; }
        }
        
        /// <summary>
        /// Granularity of supported line widths
        /// </summary>
        public Single LineWidthGranularity
        {
            get { return NativePointer->LineWidthGranularity; }
        }
        
        /// <summary>
        /// Line rasterization follows preferred rules
        /// </summary>
        public Bool32 StrictLines
        {
            get { return NativePointer->StrictLines; }
        }
        
        /// <summary>
        /// Supports standard sample locations for all supported sample counts
        /// </summary>
        public Bool32 StandardSampleLocations
        {
            get { return NativePointer->StandardSampleLocations; }
        }
        
        /// <summary>
        /// Optimal offset of buffer copies
        /// </summary>
        public DeviceSize OptimalBufferCopyOffsetAlignment
        {
            get { return NativePointer->OptimalBufferCopyOffsetAlignment; }
        }
        
        /// <summary>
        /// Optimal pitch of buffer copies
        /// </summary>
        public DeviceSize OptimalBufferCopyRowPitchAlignment
        {
            get { return NativePointer->OptimalBufferCopyRowPitchAlignment; }
        }
        
        /// <summary>
        /// Minimum size and alignment for non-coherent host-mapped device memory access
        /// </summary>
        public DeviceSize NonCoherentAtomSize
        {
            get { return NativePointer->NonCoherentAtomSize; }
        }
        
        internal PhysicalDeviceLimits()
        {
            NativePointer = (Unmanaged.PhysicalDeviceLimits*)MemoryUtils.Allocate(typeof(Unmanaged.PhysicalDeviceLimits));
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.PhysicalDeviceLimits*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~PhysicalDeviceLimits()
        {
            if(NativePointer != (Unmanaged.PhysicalDeviceLimits*)IntPtr.Zero)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.PhysicalDeviceLimits*)IntPtr.Zero;
            }
        }
    }
}
