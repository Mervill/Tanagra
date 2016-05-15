using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class PhysicalDeviceLimits
    {
        internal Interop.PhysicalDeviceLimits* NativePointer;
        
        public UInt32 MaxImageDimension1D
        {
            get { return NativePointer->MaxImageDimension1D; }
        }
        
        public UInt32 MaxImageDimension2D
        {
            get { return NativePointer->MaxImageDimension2D; }
        }
        
        public UInt32 MaxImageDimension3D
        {
            get { return NativePointer->MaxImageDimension3D; }
        }
        
        public UInt32 MaxImageDimensionCube
        {
            get { return NativePointer->MaxImageDimensionCube; }
        }
        
        public UInt32 MaxImageArrayLayers
        {
            get { return NativePointer->MaxImageArrayLayers; }
        }
        
        public UInt32 MaxTexelBufferElements
        {
            get { return NativePointer->MaxTexelBufferElements; }
        }
        
        public UInt32 MaxUniformBufferRange
        {
            get { return NativePointer->MaxUniformBufferRange; }
        }
        
        public UInt32 MaxStorageBufferRange
        {
            get { return NativePointer->MaxStorageBufferRange; }
        }
        
        public UInt32 MaxPushConstantsSize
        {
            get { return NativePointer->MaxPushConstantsSize; }
        }
        
        public UInt32 MaxMemoryAllocationCount
        {
            get { return NativePointer->MaxMemoryAllocationCount; }
        }
        
        public UInt32 MaxSamplerAllocationCount
        {
            get { return NativePointer->MaxSamplerAllocationCount; }
        }
        
        public DeviceSize BufferImageGranularity
        {
            get { return NativePointer->BufferImageGranularity; }
        }
        
        public DeviceSize SparseAddressSpaceSize
        {
            get { return NativePointer->SparseAddressSpaceSize; }
        }
        
        public UInt32 MaxBoundDescriptorSets
        {
            get { return NativePointer->MaxBoundDescriptorSets; }
        }
        
        public UInt32 MaxPerStageDescriptorSamplers
        {
            get { return NativePointer->MaxPerStageDescriptorSamplers; }
        }
        
        public UInt32 MaxPerStageDescriptorUniformBuffers
        {
            get { return NativePointer->MaxPerStageDescriptorUniformBuffers; }
        }
        
        public UInt32 MaxPerStageDescriptorStorageBuffers
        {
            get { return NativePointer->MaxPerStageDescriptorStorageBuffers; }
        }
        
        public UInt32 MaxPerStageDescriptorSampledImages
        {
            get { return NativePointer->MaxPerStageDescriptorSampledImages; }
        }
        
        public UInt32 MaxPerStageDescriptorStorageImages
        {
            get { return NativePointer->MaxPerStageDescriptorStorageImages; }
        }
        
        public UInt32 MaxPerStageDescriptorInputAttachments
        {
            get { return NativePointer->MaxPerStageDescriptorInputAttachments; }
        }
        
        public UInt32 MaxPerStageResources
        {
            get { return NativePointer->MaxPerStageResources; }
        }
        
        public UInt32 MaxDescriptorSetSamplers
        {
            get { return NativePointer->MaxDescriptorSetSamplers; }
        }
        
        public UInt32 MaxDescriptorSetUniformBuffers
        {
            get { return NativePointer->MaxDescriptorSetUniformBuffers; }
        }
        
        public UInt32 MaxDescriptorSetUniformBuffersDynamic
        {
            get { return NativePointer->MaxDescriptorSetUniformBuffersDynamic; }
        }
        
        public UInt32 MaxDescriptorSetStorageBuffers
        {
            get { return NativePointer->MaxDescriptorSetStorageBuffers; }
        }
        
        public UInt32 MaxDescriptorSetStorageBuffersDynamic
        {
            get { return NativePointer->MaxDescriptorSetStorageBuffersDynamic; }
        }
        
        public UInt32 MaxDescriptorSetSampledImages
        {
            get { return NativePointer->MaxDescriptorSetSampledImages; }
        }
        
        public UInt32 MaxDescriptorSetStorageImages
        {
            get { return NativePointer->MaxDescriptorSetStorageImages; }
        }
        
        public UInt32 MaxDescriptorSetInputAttachments
        {
            get { return NativePointer->MaxDescriptorSetInputAttachments; }
        }
        
        public UInt32 MaxVertexInputAttributes
        {
            get { return NativePointer->MaxVertexInputAttributes; }
        }
        
        public UInt32 MaxVertexInputBindings
        {
            get { return NativePointer->MaxVertexInputBindings; }
        }
        
        public UInt32 MaxVertexInputAttributeOffset
        {
            get { return NativePointer->MaxVertexInputAttributeOffset; }
        }
        
        public UInt32 MaxVertexInputBindingStride
        {
            get { return NativePointer->MaxVertexInputBindingStride; }
        }
        
        public UInt32 MaxVertexOutputComponents
        {
            get { return NativePointer->MaxVertexOutputComponents; }
        }
        
        public UInt32 MaxTessellationGenerationLevel
        {
            get { return NativePointer->MaxTessellationGenerationLevel; }
        }
        
        public UInt32 MaxTessellationPatchSize
        {
            get { return NativePointer->MaxTessellationPatchSize; }
        }
        
        public UInt32 MaxTessellationControlPerVertexInputComponents
        {
            get { return NativePointer->MaxTessellationControlPerVertexInputComponents; }
        }
        
        public UInt32 MaxTessellationControlPerVertexOutputComponents
        {
            get { return NativePointer->MaxTessellationControlPerVertexOutputComponents; }
        }
        
        public UInt32 MaxTessellationControlPerPatchOutputComponents
        {
            get { return NativePointer->MaxTessellationControlPerPatchOutputComponents; }
        }
        
        public UInt32 MaxTessellationControlTotalOutputComponents
        {
            get { return NativePointer->MaxTessellationControlTotalOutputComponents; }
        }
        
        public UInt32 MaxTessellationEvaluationInputComponents
        {
            get { return NativePointer->MaxTessellationEvaluationInputComponents; }
        }
        
        public UInt32 MaxTessellationEvaluationOutputComponents
        {
            get { return NativePointer->MaxTessellationEvaluationOutputComponents; }
        }
        
        public UInt32 MaxGeometryShaderInvocations
        {
            get { return NativePointer->MaxGeometryShaderInvocations; }
        }
        
        public UInt32 MaxGeometryInputComponents
        {
            get { return NativePointer->MaxGeometryInputComponents; }
        }
        
        public UInt32 MaxGeometryOutputComponents
        {
            get { return NativePointer->MaxGeometryOutputComponents; }
        }
        
        public UInt32 MaxGeometryOutputVertices
        {
            get { return NativePointer->MaxGeometryOutputVertices; }
        }
        
        public UInt32 MaxGeometryTotalOutputComponents
        {
            get { return NativePointer->MaxGeometryTotalOutputComponents; }
        }
        
        public UInt32 MaxFragmentInputComponents
        {
            get { return NativePointer->MaxFragmentInputComponents; }
        }
        
        public UInt32 MaxFragmentOutputAttachments
        {
            get { return NativePointer->MaxFragmentOutputAttachments; }
        }
        
        public UInt32 MaxFragmentDualSrcAttachments
        {
            get { return NativePointer->MaxFragmentDualSrcAttachments; }
        }
        
        public UInt32 MaxFragmentCombinedOutputResources
        {
            get { return NativePointer->MaxFragmentCombinedOutputResources; }
        }
        
        public UInt32 MaxComputeSharedMemorySize
        {
            get { return NativePointer->MaxComputeSharedMemorySize; }
        }
        
        public UInt32[] MaxComputeWorkGroupCount
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public UInt32 MaxComputeWorkGroupInvocations
        {
            get { return NativePointer->MaxComputeWorkGroupInvocations; }
        }
        
        public UInt32[] MaxComputeWorkGroupSize
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public UInt32 SubPixelPrecisionBits
        {
            get { return NativePointer->SubPixelPrecisionBits; }
        }
        
        public UInt32 SubTexelPrecisionBits
        {
            get { return NativePointer->SubTexelPrecisionBits; }
        }
        
        public UInt32 MipmapPrecisionBits
        {
            get { return NativePointer->MipmapPrecisionBits; }
        }
        
        public UInt32 MaxDrawIndexedIndexValue
        {
            get { return NativePointer->MaxDrawIndexedIndexValue; }
        }
        
        public UInt32 MaxDrawIndirectCount
        {
            get { return NativePointer->MaxDrawIndirectCount; }
        }
        
        public Single MaxSamplerLodBias
        {
            get { return NativePointer->MaxSamplerLodBias; }
        }
        
        public Single MaxSamplerAnisotropy
        {
            get { return NativePointer->MaxSamplerAnisotropy; }
        }
        
        public UInt32 MaxViewports
        {
            get { return NativePointer->MaxViewports; }
        }
        
        public UInt32[] MaxViewportDimensions
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public Single[] ViewportBoundsRange
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public UInt32 ViewportSubPixelBits
        {
            get { return NativePointer->ViewportSubPixelBits; }
        }
        
        public UInt32 MinMemoryMapAlignment
        {
            get { return NativePointer->MinMemoryMapAlignment; }
        }
        
        public DeviceSize MinTexelBufferOffsetAlignment
        {
            get { return NativePointer->MinTexelBufferOffsetAlignment; }
        }
        
        public DeviceSize MinUniformBufferOffsetAlignment
        {
            get { return NativePointer->MinUniformBufferOffsetAlignment; }
        }
        
        public DeviceSize MinStorageBufferOffsetAlignment
        {
            get { return NativePointer->MinStorageBufferOffsetAlignment; }
        }
        
        public Int32 MinTexelOffset
        {
            get { return NativePointer->MinTexelOffset; }
        }
        
        public UInt32 MaxTexelOffset
        {
            get { return NativePointer->MaxTexelOffset; }
        }
        
        public Int32 MinTexelGatherOffset
        {
            get { return NativePointer->MinTexelGatherOffset; }
        }
        
        public UInt32 MaxTexelGatherOffset
        {
            get { return NativePointer->MaxTexelGatherOffset; }
        }
        
        public Single MinInterpolationOffset
        {
            get { return NativePointer->MinInterpolationOffset; }
        }
        
        public Single MaxInterpolationOffset
        {
            get { return NativePointer->MaxInterpolationOffset; }
        }
        
        public UInt32 SubPixelInterpolationOffsetBits
        {
            get { return NativePointer->SubPixelInterpolationOffsetBits; }
        }
        
        public UInt32 MaxFramebufferWidth
        {
            get { return NativePointer->MaxFramebufferWidth; }
        }
        
        public UInt32 MaxFramebufferHeight
        {
            get { return NativePointer->MaxFramebufferHeight; }
        }
        
        public UInt32 MaxFramebufferLayers
        {
            get { return NativePointer->MaxFramebufferLayers; }
        }
        
        public SampleCountFlags FramebufferColorSampleCounts
        {
            get { return NativePointer->FramebufferColorSampleCounts; }
        }
        
        public SampleCountFlags FramebufferDepthSampleCounts
        {
            get { return NativePointer->FramebufferDepthSampleCounts; }
        }
        
        public SampleCountFlags FramebufferStencilSampleCounts
        {
            get { return NativePointer->FramebufferStencilSampleCounts; }
        }
        
        public SampleCountFlags FramebufferNoAttachmentsSampleCounts
        {
            get { return NativePointer->FramebufferNoAttachmentsSampleCounts; }
        }
        
        public UInt32 MaxColorAttachments
        {
            get { return NativePointer->MaxColorAttachments; }
        }
        
        public SampleCountFlags SampledImageColorSampleCounts
        {
            get { return NativePointer->SampledImageColorSampleCounts; }
        }
        
        public SampleCountFlags SampledImageIntegerSampleCounts
        {
            get { return NativePointer->SampledImageIntegerSampleCounts; }
        }
        
        public SampleCountFlags SampledImageDepthSampleCounts
        {
            get { return NativePointer->SampledImageDepthSampleCounts; }
        }
        
        public SampleCountFlags SampledImageStencilSampleCounts
        {
            get { return NativePointer->SampledImageStencilSampleCounts; }
        }
        
        public SampleCountFlags StorageImageSampleCounts
        {
            get { return NativePointer->StorageImageSampleCounts; }
        }
        
        public UInt32 MaxSampleMaskWords
        {
            get { return NativePointer->MaxSampleMaskWords; }
        }
        
        public Bool32 TimestampComputeAndGraphics
        {
            get { return NativePointer->TimestampComputeAndGraphics; }
        }
        
        public Single TimestampPeriod
        {
            get { return NativePointer->TimestampPeriod; }
        }
        
        public UInt32 MaxClipDistances
        {
            get { return NativePointer->MaxClipDistances; }
        }
        
        public UInt32 MaxCullDistances
        {
            get { return NativePointer->MaxCullDistances; }
        }
        
        public UInt32 MaxCombinedClipAndCullDistances
        {
            get { return NativePointer->MaxCombinedClipAndCullDistances; }
        }
        
        public UInt32 DiscreteQueuePriorities
        {
            get { return NativePointer->DiscreteQueuePriorities; }
        }
        
        public Single[] PointSizeRange
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public Single[] LineWidthRange
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public Single PointSizeGranularity
        {
            get { return NativePointer->PointSizeGranularity; }
        }
        
        public Single LineWidthGranularity
        {
            get { return NativePointer->LineWidthGranularity; }
        }
        
        public Bool32 StrictLines
        {
            get { return NativePointer->StrictLines; }
        }
        
        public Bool32 StandardSampleLocations
        {
            get { return NativePointer->StandardSampleLocations; }
        }
        
        public DeviceSize OptimalBufferCopyOffsetAlignment
        {
            get { return NativePointer->OptimalBufferCopyOffsetAlignment; }
        }
        
        public DeviceSize OptimalBufferCopyRowPitchAlignment
        {
            get { return NativePointer->OptimalBufferCopyRowPitchAlignment; }
        }
        
        public DeviceSize NonCoherentAtomSize
        {
            get { return NativePointer->NonCoherentAtomSize; }
        }
        
        internal PhysicalDeviceLimits()
        {
            NativePointer = (Interop.PhysicalDeviceLimits*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceLimits));
        }
    }
}
