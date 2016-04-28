using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceLimits
    {
        internal Interop.PhysicalDeviceLimits* NativePointer;
        
        public UInt32 MaxImageDimension1D
        {
            get { return NativePointer->MaxImageDimension1D; }
            set { NativePointer->MaxImageDimension1D = value; }
        }
        
        public UInt32 MaxImageDimension2D
        {
            get { return NativePointer->MaxImageDimension2D; }
            set { NativePointer->MaxImageDimension2D = value; }
        }
        
        public UInt32 MaxImageDimension3D
        {
            get { return NativePointer->MaxImageDimension3D; }
            set { NativePointer->MaxImageDimension3D = value; }
        }
        
        public UInt32 MaxImageDimensionCube
        {
            get { return NativePointer->MaxImageDimensionCube; }
            set { NativePointer->MaxImageDimensionCube = value; }
        }
        
        public UInt32 MaxImageArrayLayers
        {
            get { return NativePointer->MaxImageArrayLayers; }
            set { NativePointer->MaxImageArrayLayers = value; }
        }
        
        public UInt32 MaxTexelBufferElements
        {
            get { return NativePointer->MaxTexelBufferElements; }
            set { NativePointer->MaxTexelBufferElements = value; }
        }
        
        public UInt32 MaxUniformBufferRange
        {
            get { return NativePointer->MaxUniformBufferRange; }
            set { NativePointer->MaxUniformBufferRange = value; }
        }
        
        public UInt32 MaxStorageBufferRange
        {
            get { return NativePointer->MaxStorageBufferRange; }
            set { NativePointer->MaxStorageBufferRange = value; }
        }
        
        public UInt32 MaxPushConstantsSize
        {
            get { return NativePointer->MaxPushConstantsSize; }
            set { NativePointer->MaxPushConstantsSize = value; }
        }
        
        public UInt32 MaxMemoryAllocationCount
        {
            get { return NativePointer->MaxMemoryAllocationCount; }
            set { NativePointer->MaxMemoryAllocationCount = value; }
        }
        
        public UInt32 MaxSamplerAllocationCount
        {
            get { return NativePointer->MaxSamplerAllocationCount; }
            set { NativePointer->MaxSamplerAllocationCount = value; }
        }
        
        public DeviceSize BufferImageGranularity
        {
            get { return NativePointer->BufferImageGranularity; }
            set { NativePointer->BufferImageGranularity = value; }
        }
        
        public DeviceSize SparseAddressSpaceSize
        {
            get { return NativePointer->SparseAddressSpaceSize; }
            set { NativePointer->SparseAddressSpaceSize = value; }
        }
        
        public UInt32 MaxBoundDescriptorSets
        {
            get { return NativePointer->MaxBoundDescriptorSets; }
            set { NativePointer->MaxBoundDescriptorSets = value; }
        }
        
        public UInt32 MaxPerStageDescriptorSamplers
        {
            get { return NativePointer->MaxPerStageDescriptorSamplers; }
            set { NativePointer->MaxPerStageDescriptorSamplers = value; }
        }
        
        public UInt32 MaxPerStageDescriptorUniformBuffers
        {
            get { return NativePointer->MaxPerStageDescriptorUniformBuffers; }
            set { NativePointer->MaxPerStageDescriptorUniformBuffers = value; }
        }
        
        public UInt32 MaxPerStageDescriptorStorageBuffers
        {
            get { return NativePointer->MaxPerStageDescriptorStorageBuffers; }
            set { NativePointer->MaxPerStageDescriptorStorageBuffers = value; }
        }
        
        public UInt32 MaxPerStageDescriptorSampledImages
        {
            get { return NativePointer->MaxPerStageDescriptorSampledImages; }
            set { NativePointer->MaxPerStageDescriptorSampledImages = value; }
        }
        
        public UInt32 MaxPerStageDescriptorStorageImages
        {
            get { return NativePointer->MaxPerStageDescriptorStorageImages; }
            set { NativePointer->MaxPerStageDescriptorStorageImages = value; }
        }
        
        public UInt32 MaxPerStageDescriptorInputAttachments
        {
            get { return NativePointer->MaxPerStageDescriptorInputAttachments; }
            set { NativePointer->MaxPerStageDescriptorInputAttachments = value; }
        }
        
        public UInt32 MaxPerStageResources
        {
            get { return NativePointer->MaxPerStageResources; }
            set { NativePointer->MaxPerStageResources = value; }
        }
        
        public UInt32 MaxDescriptorSetSamplers
        {
            get { return NativePointer->MaxDescriptorSetSamplers; }
            set { NativePointer->MaxDescriptorSetSamplers = value; }
        }
        
        public UInt32 MaxDescriptorSetUniformBuffers
        {
            get { return NativePointer->MaxDescriptorSetUniformBuffers; }
            set { NativePointer->MaxDescriptorSetUniformBuffers = value; }
        }
        
        public UInt32 MaxDescriptorSetUniformBuffersDynamic
        {
            get { return NativePointer->MaxDescriptorSetUniformBuffersDynamic; }
            set { NativePointer->MaxDescriptorSetUniformBuffersDynamic = value; }
        }
        
        public UInt32 MaxDescriptorSetStorageBuffers
        {
            get { return NativePointer->MaxDescriptorSetStorageBuffers; }
            set { NativePointer->MaxDescriptorSetStorageBuffers = value; }
        }
        
        public UInt32 MaxDescriptorSetStorageBuffersDynamic
        {
            get { return NativePointer->MaxDescriptorSetStorageBuffersDynamic; }
            set { NativePointer->MaxDescriptorSetStorageBuffersDynamic = value; }
        }
        
        public UInt32 MaxDescriptorSetSampledImages
        {
            get { return NativePointer->MaxDescriptorSetSampledImages; }
            set { NativePointer->MaxDescriptorSetSampledImages = value; }
        }
        
        public UInt32 MaxDescriptorSetStorageImages
        {
            get { return NativePointer->MaxDescriptorSetStorageImages; }
            set { NativePointer->MaxDescriptorSetStorageImages = value; }
        }
        
        public UInt32 MaxDescriptorSetInputAttachments
        {
            get { return NativePointer->MaxDescriptorSetInputAttachments; }
            set { NativePointer->MaxDescriptorSetInputAttachments = value; }
        }
        
        public UInt32 MaxVertexInputAttributes
        {
            get { return NativePointer->MaxVertexInputAttributes; }
            set { NativePointer->MaxVertexInputAttributes = value; }
        }
        
        public UInt32 MaxVertexInputBindings
        {
            get { return NativePointer->MaxVertexInputBindings; }
            set { NativePointer->MaxVertexInputBindings = value; }
        }
        
        public UInt32 MaxVertexInputAttributeOffset
        {
            get { return NativePointer->MaxVertexInputAttributeOffset; }
            set { NativePointer->MaxVertexInputAttributeOffset = value; }
        }
        
        public UInt32 MaxVertexInputBindingStride
        {
            get { return NativePointer->MaxVertexInputBindingStride; }
            set { NativePointer->MaxVertexInputBindingStride = value; }
        }
        
        public UInt32 MaxVertexOutputComponents
        {
            get { return NativePointer->MaxVertexOutputComponents; }
            set { NativePointer->MaxVertexOutputComponents = value; }
        }
        
        public UInt32 MaxTessellationGenerationLevel
        {
            get { return NativePointer->MaxTessellationGenerationLevel; }
            set { NativePointer->MaxTessellationGenerationLevel = value; }
        }
        
        public UInt32 MaxTessellationPatchSize
        {
            get { return NativePointer->MaxTessellationPatchSize; }
            set { NativePointer->MaxTessellationPatchSize = value; }
        }
        
        public UInt32 MaxTessellationControlPerVertexInputComponents
        {
            get { return NativePointer->MaxTessellationControlPerVertexInputComponents; }
            set { NativePointer->MaxTessellationControlPerVertexInputComponents = value; }
        }
        
        public UInt32 MaxTessellationControlPerVertexOutputComponents
        {
            get { return NativePointer->MaxTessellationControlPerVertexOutputComponents; }
            set { NativePointer->MaxTessellationControlPerVertexOutputComponents = value; }
        }
        
        public UInt32 MaxTessellationControlPerPatchOutputComponents
        {
            get { return NativePointer->MaxTessellationControlPerPatchOutputComponents; }
            set { NativePointer->MaxTessellationControlPerPatchOutputComponents = value; }
        }
        
        public UInt32 MaxTessellationControlTotalOutputComponents
        {
            get { return NativePointer->MaxTessellationControlTotalOutputComponents; }
            set { NativePointer->MaxTessellationControlTotalOutputComponents = value; }
        }
        
        public UInt32 MaxTessellationEvaluationInputComponents
        {
            get { return NativePointer->MaxTessellationEvaluationInputComponents; }
            set { NativePointer->MaxTessellationEvaluationInputComponents = value; }
        }
        
        public UInt32 MaxTessellationEvaluationOutputComponents
        {
            get { return NativePointer->MaxTessellationEvaluationOutputComponents; }
            set { NativePointer->MaxTessellationEvaluationOutputComponents = value; }
        }
        
        public UInt32 MaxGeometryShaderInvocations
        {
            get { return NativePointer->MaxGeometryShaderInvocations; }
            set { NativePointer->MaxGeometryShaderInvocations = value; }
        }
        
        public UInt32 MaxGeometryInputComponents
        {
            get { return NativePointer->MaxGeometryInputComponents; }
            set { NativePointer->MaxGeometryInputComponents = value; }
        }
        
        public UInt32 MaxGeometryOutputComponents
        {
            get { return NativePointer->MaxGeometryOutputComponents; }
            set { NativePointer->MaxGeometryOutputComponents = value; }
        }
        
        public UInt32 MaxGeometryOutputVertices
        {
            get { return NativePointer->MaxGeometryOutputVertices; }
            set { NativePointer->MaxGeometryOutputVertices = value; }
        }
        
        public UInt32 MaxGeometryTotalOutputComponents
        {
            get { return NativePointer->MaxGeometryTotalOutputComponents; }
            set { NativePointer->MaxGeometryTotalOutputComponents = value; }
        }
        
        public UInt32 MaxFragmentInputComponents
        {
            get { return NativePointer->MaxFragmentInputComponents; }
            set { NativePointer->MaxFragmentInputComponents = value; }
        }
        
        public UInt32 MaxFragmentOutputAttachments
        {
            get { return NativePointer->MaxFragmentOutputAttachments; }
            set { NativePointer->MaxFragmentOutputAttachments = value; }
        }
        
        public UInt32 MaxFragmentDualSrcAttachments
        {
            get { return NativePointer->MaxFragmentDualSrcAttachments; }
            set { NativePointer->MaxFragmentDualSrcAttachments = value; }
        }
        
        public UInt32 MaxFragmentCombinedOutputResources
        {
            get { return NativePointer->MaxFragmentCombinedOutputResources; }
            set { NativePointer->MaxFragmentCombinedOutputResources = value; }
        }
        
        public UInt32 MaxComputeSharedMemorySize
        {
            get { return NativePointer->MaxComputeSharedMemorySize; }
            set { NativePointer->MaxComputeSharedMemorySize = value; }
        }
        
        public UInt32 MaxComputeWorkGroupCount
        {
            get { return NativePointer->MaxComputeWorkGroupCount; }
            set { NativePointer->MaxComputeWorkGroupCount = value; }
        }
        
        public UInt32 MaxComputeWorkGroupInvocations
        {
            get { return NativePointer->MaxComputeWorkGroupInvocations; }
            set { NativePointer->MaxComputeWorkGroupInvocations = value; }
        }
        
        public UInt32 MaxComputeWorkGroupSize
        {
            get { return NativePointer->MaxComputeWorkGroupSize; }
            set { NativePointer->MaxComputeWorkGroupSize = value; }
        }
        
        public UInt32 SubPixelPrecisionBits
        {
            get { return NativePointer->SubPixelPrecisionBits; }
            set { NativePointer->SubPixelPrecisionBits = value; }
        }
        
        public UInt32 SubTexelPrecisionBits
        {
            get { return NativePointer->SubTexelPrecisionBits; }
            set { NativePointer->SubTexelPrecisionBits = value; }
        }
        
        public UInt32 MipmapPrecisionBits
        {
            get { return NativePointer->MipmapPrecisionBits; }
            set { NativePointer->MipmapPrecisionBits = value; }
        }
        
        public UInt32 MaxDrawIndexedIndexValue
        {
            get { return NativePointer->MaxDrawIndexedIndexValue; }
            set { NativePointer->MaxDrawIndexedIndexValue = value; }
        }
        
        public UInt32 MaxDrawIndirectCount
        {
            get { return NativePointer->MaxDrawIndirectCount; }
            set { NativePointer->MaxDrawIndirectCount = value; }
        }
        
        public Single MaxSamplerLodBias
        {
            get { return NativePointer->MaxSamplerLodBias; }
            set { NativePointer->MaxSamplerLodBias = value; }
        }
        
        public Single MaxSamplerAnisotropy
        {
            get { return NativePointer->MaxSamplerAnisotropy; }
            set { NativePointer->MaxSamplerAnisotropy = value; }
        }
        
        public UInt32 MaxViewports
        {
            get { return NativePointer->MaxViewports; }
            set { NativePointer->MaxViewports = value; }
        }
        
        public UInt32 MaxViewportDimensions
        {
            get { return NativePointer->MaxViewportDimensions; }
            set { NativePointer->MaxViewportDimensions = value; }
        }
        
        public Single ViewportBoundsRange
        {
            get { return NativePointer->ViewportBoundsRange; }
            set { NativePointer->ViewportBoundsRange = value; }
        }
        
        public UInt32 ViewportSubPixelBits
        {
            get { return NativePointer->ViewportSubPixelBits; }
            set { NativePointer->ViewportSubPixelBits = value; }
        }
        
        public UIntPtr MinMemoryMapAlignment
        {
            get { return NativePointer->MinMemoryMapAlignment; }
            set { NativePointer->MinMemoryMapAlignment = value; }
        }
        
        public DeviceSize MinTexelBufferOffsetAlignment
        {
            get { return NativePointer->MinTexelBufferOffsetAlignment; }
            set { NativePointer->MinTexelBufferOffsetAlignment = value; }
        }
        
        public DeviceSize MinUniformBufferOffsetAlignment
        {
            get { return NativePointer->MinUniformBufferOffsetAlignment; }
            set { NativePointer->MinUniformBufferOffsetAlignment = value; }
        }
        
        public DeviceSize MinStorageBufferOffsetAlignment
        {
            get { return NativePointer->MinStorageBufferOffsetAlignment; }
            set { NativePointer->MinStorageBufferOffsetAlignment = value; }
        }
        
        public Int32 MinTexelOffset
        {
            get { return NativePointer->MinTexelOffset; }
            set { NativePointer->MinTexelOffset = value; }
        }
        
        public UInt32 MaxTexelOffset
        {
            get { return NativePointer->MaxTexelOffset; }
            set { NativePointer->MaxTexelOffset = value; }
        }
        
        public Int32 MinTexelGatherOffset
        {
            get { return NativePointer->MinTexelGatherOffset; }
            set { NativePointer->MinTexelGatherOffset = value; }
        }
        
        public UInt32 MaxTexelGatherOffset
        {
            get { return NativePointer->MaxTexelGatherOffset; }
            set { NativePointer->MaxTexelGatherOffset = value; }
        }
        
        public Single MinInterpolationOffset
        {
            get { return NativePointer->MinInterpolationOffset; }
            set { NativePointer->MinInterpolationOffset = value; }
        }
        
        public Single MaxInterpolationOffset
        {
            get { return NativePointer->MaxInterpolationOffset; }
            set { NativePointer->MaxInterpolationOffset = value; }
        }
        
        public UInt32 SubPixelInterpolationOffsetBits
        {
            get { return NativePointer->SubPixelInterpolationOffsetBits; }
            set { NativePointer->SubPixelInterpolationOffsetBits = value; }
        }
        
        public UInt32 MaxFramebufferWidth
        {
            get { return NativePointer->MaxFramebufferWidth; }
            set { NativePointer->MaxFramebufferWidth = value; }
        }
        
        public UInt32 MaxFramebufferHeight
        {
            get { return NativePointer->MaxFramebufferHeight; }
            set { NativePointer->MaxFramebufferHeight = value; }
        }
        
        public UInt32 MaxFramebufferLayers
        {
            get { return NativePointer->MaxFramebufferLayers; }
            set { NativePointer->MaxFramebufferLayers = value; }
        }
        
        public SampleCountFlags FramebufferColorSampleCounts
        {
            get { return NativePointer->FramebufferColorSampleCounts; }
            set { NativePointer->FramebufferColorSampleCounts = value; }
        }
        
        public SampleCountFlags FramebufferDepthSampleCounts
        {
            get { return NativePointer->FramebufferDepthSampleCounts; }
            set { NativePointer->FramebufferDepthSampleCounts = value; }
        }
        
        public SampleCountFlags FramebufferStencilSampleCounts
        {
            get { return NativePointer->FramebufferStencilSampleCounts; }
            set { NativePointer->FramebufferStencilSampleCounts = value; }
        }
        
        public SampleCountFlags FramebufferNoAttachmentsSampleCounts
        {
            get { return NativePointer->FramebufferNoAttachmentsSampleCounts; }
            set { NativePointer->FramebufferNoAttachmentsSampleCounts = value; }
        }
        
        public UInt32 MaxColorAttachments
        {
            get { return NativePointer->MaxColorAttachments; }
            set { NativePointer->MaxColorAttachments = value; }
        }
        
        public SampleCountFlags SampledImageColorSampleCounts
        {
            get { return NativePointer->SampledImageColorSampleCounts; }
            set { NativePointer->SampledImageColorSampleCounts = value; }
        }
        
        public SampleCountFlags SampledImageIntegerSampleCounts
        {
            get { return NativePointer->SampledImageIntegerSampleCounts; }
            set { NativePointer->SampledImageIntegerSampleCounts = value; }
        }
        
        public SampleCountFlags SampledImageDepthSampleCounts
        {
            get { return NativePointer->SampledImageDepthSampleCounts; }
            set { NativePointer->SampledImageDepthSampleCounts = value; }
        }
        
        public SampleCountFlags SampledImageStencilSampleCounts
        {
            get { return NativePointer->SampledImageStencilSampleCounts; }
            set { NativePointer->SampledImageStencilSampleCounts = value; }
        }
        
        public SampleCountFlags StorageImageSampleCounts
        {
            get { return NativePointer->StorageImageSampleCounts; }
            set { NativePointer->StorageImageSampleCounts = value; }
        }
        
        public UInt32 MaxSampleMaskWords
        {
            get { return NativePointer->MaxSampleMaskWords; }
            set { NativePointer->MaxSampleMaskWords = value; }
        }
        
        public Boolean TimestampComputeAndGraphics
        {
            get { return NativePointer->TimestampComputeAndGraphics; }
            set { NativePointer->TimestampComputeAndGraphics = value; }
        }
        
        public Single TimestampPeriod
        {
            get { return NativePointer->TimestampPeriod; }
            set { NativePointer->TimestampPeriod = value; }
        }
        
        public UInt32 MaxClipDistances
        {
            get { return NativePointer->MaxClipDistances; }
            set { NativePointer->MaxClipDistances = value; }
        }
        
        public UInt32 MaxCullDistances
        {
            get { return NativePointer->MaxCullDistances; }
            set { NativePointer->MaxCullDistances = value; }
        }
        
        public UInt32 MaxCombinedClipAndCullDistances
        {
            get { return NativePointer->MaxCombinedClipAndCullDistances; }
            set { NativePointer->MaxCombinedClipAndCullDistances = value; }
        }
        
        public UInt32 DiscreteQueuePriorities
        {
            get { return NativePointer->DiscreteQueuePriorities; }
            set { NativePointer->DiscreteQueuePriorities = value; }
        }
        
        public Single PointSizeRange
        {
            get { return NativePointer->PointSizeRange; }
            set { NativePointer->PointSizeRange = value; }
        }
        
        public Single LineWidthRange
        {
            get { return NativePointer->LineWidthRange; }
            set { NativePointer->LineWidthRange = value; }
        }
        
        public Single PointSizeGranularity
        {
            get { return NativePointer->PointSizeGranularity; }
            set { NativePointer->PointSizeGranularity = value; }
        }
        
        public Single LineWidthGranularity
        {
            get { return NativePointer->LineWidthGranularity; }
            set { NativePointer->LineWidthGranularity = value; }
        }
        
        public Boolean StrictLines
        {
            get { return NativePointer->StrictLines; }
            set { NativePointer->StrictLines = value; }
        }
        
        public Boolean StandardSampleLocations
        {
            get { return NativePointer->StandardSampleLocations; }
            set { NativePointer->StandardSampleLocations = value; }
        }
        
        public DeviceSize OptimalBufferCopyOffsetAlignment
        {
            get { return NativePointer->OptimalBufferCopyOffsetAlignment; }
            set { NativePointer->OptimalBufferCopyOffsetAlignment = value; }
        }
        
        public DeviceSize OptimalBufferCopyRowPitchAlignment
        {
            get { return NativePointer->OptimalBufferCopyRowPitchAlignment; }
            set { NativePointer->OptimalBufferCopyRowPitchAlignment = value; }
        }
        
        public DeviceSize NonCoherentAtomSize
        {
            get { return NativePointer->NonCoherentAtomSize; }
            set { NativePointer->NonCoherentAtomSize = value; }
        }
        
        public PhysicalDeviceLimits()
        {
            NativePointer = (Interop.PhysicalDeviceLimits*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceLimits));
        }
    }
}
