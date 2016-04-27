using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceLimits
    {
        internal Interop.PhysicalDeviceLimits* NativeHandle;
        
        public UInt32 MaxImageDimension1D
        {
            get { return NativeHandle->MaxImageDimension1D; }
            set { NativeHandle->MaxImageDimension1D = value; }
        }
        
        public UInt32 MaxImageDimension2D
        {
            get { return NativeHandle->MaxImageDimension2D; }
            set { NativeHandle->MaxImageDimension2D = value; }
        }
        
        public UInt32 MaxImageDimension3D
        {
            get { return NativeHandle->MaxImageDimension3D; }
            set { NativeHandle->MaxImageDimension3D = value; }
        }
        
        public UInt32 MaxImageDimensionCube
        {
            get { return NativeHandle->MaxImageDimensionCube; }
            set { NativeHandle->MaxImageDimensionCube = value; }
        }
        
        public UInt32 MaxImageArrayLayers
        {
            get { return NativeHandle->MaxImageArrayLayers; }
            set { NativeHandle->MaxImageArrayLayers = value; }
        }
        
        public UInt32 MaxTexelBufferElements
        {
            get { return NativeHandle->MaxTexelBufferElements; }
            set { NativeHandle->MaxTexelBufferElements = value; }
        }
        
        public UInt32 MaxUniformBufferRange
        {
            get { return NativeHandle->MaxUniformBufferRange; }
            set { NativeHandle->MaxUniformBufferRange = value; }
        }
        
        public UInt32 MaxStorageBufferRange
        {
            get { return NativeHandle->MaxStorageBufferRange; }
            set { NativeHandle->MaxStorageBufferRange = value; }
        }
        
        public UInt32 MaxPushConstantsSize
        {
            get { return NativeHandle->MaxPushConstantsSize; }
            set { NativeHandle->MaxPushConstantsSize = value; }
        }
        
        public UInt32 MaxMemoryAllocationCount
        {
            get { return NativeHandle->MaxMemoryAllocationCount; }
            set { NativeHandle->MaxMemoryAllocationCount = value; }
        }
        
        public UInt32 MaxSamplerAllocationCount
        {
            get { return NativeHandle->MaxSamplerAllocationCount; }
            set { NativeHandle->MaxSamplerAllocationCount = value; }
        }
        
        DeviceSize _BufferImageGranularity;
        public DeviceSize BufferImageGranularity
        {
            get { return _BufferImageGranularity; }
            set { _BufferImageGranularity = value; NativeHandle->BufferImageGranularity = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _SparseAddressSpaceSize;
        public DeviceSize SparseAddressSpaceSize
        {
            get { return _SparseAddressSpaceSize; }
            set { _SparseAddressSpaceSize = value; NativeHandle->SparseAddressSpaceSize = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 MaxBoundDescriptorSets
        {
            get { return NativeHandle->MaxBoundDescriptorSets; }
            set { NativeHandle->MaxBoundDescriptorSets = value; }
        }
        
        public UInt32 MaxPerStageDescriptorSamplers
        {
            get { return NativeHandle->MaxPerStageDescriptorSamplers; }
            set { NativeHandle->MaxPerStageDescriptorSamplers = value; }
        }
        
        public UInt32 MaxPerStageDescriptorUniformBuffers
        {
            get { return NativeHandle->MaxPerStageDescriptorUniformBuffers; }
            set { NativeHandle->MaxPerStageDescriptorUniformBuffers = value; }
        }
        
        public UInt32 MaxPerStageDescriptorStorageBuffers
        {
            get { return NativeHandle->MaxPerStageDescriptorStorageBuffers; }
            set { NativeHandle->MaxPerStageDescriptorStorageBuffers = value; }
        }
        
        public UInt32 MaxPerStageDescriptorSampledImages
        {
            get { return NativeHandle->MaxPerStageDescriptorSampledImages; }
            set { NativeHandle->MaxPerStageDescriptorSampledImages = value; }
        }
        
        public UInt32 MaxPerStageDescriptorStorageImages
        {
            get { return NativeHandle->MaxPerStageDescriptorStorageImages; }
            set { NativeHandle->MaxPerStageDescriptorStorageImages = value; }
        }
        
        public UInt32 MaxPerStageDescriptorInputAttachments
        {
            get { return NativeHandle->MaxPerStageDescriptorInputAttachments; }
            set { NativeHandle->MaxPerStageDescriptorInputAttachments = value; }
        }
        
        public UInt32 MaxPerStageResources
        {
            get { return NativeHandle->MaxPerStageResources; }
            set { NativeHandle->MaxPerStageResources = value; }
        }
        
        public UInt32 MaxDescriptorSetSamplers
        {
            get { return NativeHandle->MaxDescriptorSetSamplers; }
            set { NativeHandle->MaxDescriptorSetSamplers = value; }
        }
        
        public UInt32 MaxDescriptorSetUniformBuffers
        {
            get { return NativeHandle->MaxDescriptorSetUniformBuffers; }
            set { NativeHandle->MaxDescriptorSetUniformBuffers = value; }
        }
        
        public UInt32 MaxDescriptorSetUniformBuffersDynamic
        {
            get { return NativeHandle->MaxDescriptorSetUniformBuffersDynamic; }
            set { NativeHandle->MaxDescriptorSetUniformBuffersDynamic = value; }
        }
        
        public UInt32 MaxDescriptorSetStorageBuffers
        {
            get { return NativeHandle->MaxDescriptorSetStorageBuffers; }
            set { NativeHandle->MaxDescriptorSetStorageBuffers = value; }
        }
        
        public UInt32 MaxDescriptorSetStorageBuffersDynamic
        {
            get { return NativeHandle->MaxDescriptorSetStorageBuffersDynamic; }
            set { NativeHandle->MaxDescriptorSetStorageBuffersDynamic = value; }
        }
        
        public UInt32 MaxDescriptorSetSampledImages
        {
            get { return NativeHandle->MaxDescriptorSetSampledImages; }
            set { NativeHandle->MaxDescriptorSetSampledImages = value; }
        }
        
        public UInt32 MaxDescriptorSetStorageImages
        {
            get { return NativeHandle->MaxDescriptorSetStorageImages; }
            set { NativeHandle->MaxDescriptorSetStorageImages = value; }
        }
        
        public UInt32 MaxDescriptorSetInputAttachments
        {
            get { return NativeHandle->MaxDescriptorSetInputAttachments; }
            set { NativeHandle->MaxDescriptorSetInputAttachments = value; }
        }
        
        public UInt32 MaxVertexInputAttributes
        {
            get { return NativeHandle->MaxVertexInputAttributes; }
            set { NativeHandle->MaxVertexInputAttributes = value; }
        }
        
        public UInt32 MaxVertexInputBindings
        {
            get { return NativeHandle->MaxVertexInputBindings; }
            set { NativeHandle->MaxVertexInputBindings = value; }
        }
        
        public UInt32 MaxVertexInputAttributeOffset
        {
            get { return NativeHandle->MaxVertexInputAttributeOffset; }
            set { NativeHandle->MaxVertexInputAttributeOffset = value; }
        }
        
        public UInt32 MaxVertexInputBindingStride
        {
            get { return NativeHandle->MaxVertexInputBindingStride; }
            set { NativeHandle->MaxVertexInputBindingStride = value; }
        }
        
        public UInt32 MaxVertexOutputComponents
        {
            get { return NativeHandle->MaxVertexOutputComponents; }
            set { NativeHandle->MaxVertexOutputComponents = value; }
        }
        
        public UInt32 MaxTessellationGenerationLevel
        {
            get { return NativeHandle->MaxTessellationGenerationLevel; }
            set { NativeHandle->MaxTessellationGenerationLevel = value; }
        }
        
        public UInt32 MaxTessellationPatchSize
        {
            get { return NativeHandle->MaxTessellationPatchSize; }
            set { NativeHandle->MaxTessellationPatchSize = value; }
        }
        
        public UInt32 MaxTessellationControlPerVertexInputComponents
        {
            get { return NativeHandle->MaxTessellationControlPerVertexInputComponents; }
            set { NativeHandle->MaxTessellationControlPerVertexInputComponents = value; }
        }
        
        public UInt32 MaxTessellationControlPerVertexOutputComponents
        {
            get { return NativeHandle->MaxTessellationControlPerVertexOutputComponents; }
            set { NativeHandle->MaxTessellationControlPerVertexOutputComponents = value; }
        }
        
        public UInt32 MaxTessellationControlPerPatchOutputComponents
        {
            get { return NativeHandle->MaxTessellationControlPerPatchOutputComponents; }
            set { NativeHandle->MaxTessellationControlPerPatchOutputComponents = value; }
        }
        
        public UInt32 MaxTessellationControlTotalOutputComponents
        {
            get { return NativeHandle->MaxTessellationControlTotalOutputComponents; }
            set { NativeHandle->MaxTessellationControlTotalOutputComponents = value; }
        }
        
        public UInt32 MaxTessellationEvaluationInputComponents
        {
            get { return NativeHandle->MaxTessellationEvaluationInputComponents; }
            set { NativeHandle->MaxTessellationEvaluationInputComponents = value; }
        }
        
        public UInt32 MaxTessellationEvaluationOutputComponents
        {
            get { return NativeHandle->MaxTessellationEvaluationOutputComponents; }
            set { NativeHandle->MaxTessellationEvaluationOutputComponents = value; }
        }
        
        public UInt32 MaxGeometryShaderInvocations
        {
            get { return NativeHandle->MaxGeometryShaderInvocations; }
            set { NativeHandle->MaxGeometryShaderInvocations = value; }
        }
        
        public UInt32 MaxGeometryInputComponents
        {
            get { return NativeHandle->MaxGeometryInputComponents; }
            set { NativeHandle->MaxGeometryInputComponents = value; }
        }
        
        public UInt32 MaxGeometryOutputComponents
        {
            get { return NativeHandle->MaxGeometryOutputComponents; }
            set { NativeHandle->MaxGeometryOutputComponents = value; }
        }
        
        public UInt32 MaxGeometryOutputVertices
        {
            get { return NativeHandle->MaxGeometryOutputVertices; }
            set { NativeHandle->MaxGeometryOutputVertices = value; }
        }
        
        public UInt32 MaxGeometryTotalOutputComponents
        {
            get { return NativeHandle->MaxGeometryTotalOutputComponents; }
            set { NativeHandle->MaxGeometryTotalOutputComponents = value; }
        }
        
        public UInt32 MaxFragmentInputComponents
        {
            get { return NativeHandle->MaxFragmentInputComponents; }
            set { NativeHandle->MaxFragmentInputComponents = value; }
        }
        
        public UInt32 MaxFragmentOutputAttachments
        {
            get { return NativeHandle->MaxFragmentOutputAttachments; }
            set { NativeHandle->MaxFragmentOutputAttachments = value; }
        }
        
        public UInt32 MaxFragmentDualSrcAttachments
        {
            get { return NativeHandle->MaxFragmentDualSrcAttachments; }
            set { NativeHandle->MaxFragmentDualSrcAttachments = value; }
        }
        
        public UInt32 MaxFragmentCombinedOutputResources
        {
            get { return NativeHandle->MaxFragmentCombinedOutputResources; }
            set { NativeHandle->MaxFragmentCombinedOutputResources = value; }
        }
        
        public UInt32 MaxComputeSharedMemorySize
        {
            get { return NativeHandle->MaxComputeSharedMemorySize; }
            set { NativeHandle->MaxComputeSharedMemorySize = value; }
        }
        
        public UInt32 MaxComputeWorkGroupCount
        {
            get { return NativeHandle->MaxComputeWorkGroupCount; }
            set { NativeHandle->MaxComputeWorkGroupCount = value; }
        }
        
        public UInt32 MaxComputeWorkGroupInvocations
        {
            get { return NativeHandle->MaxComputeWorkGroupInvocations; }
            set { NativeHandle->MaxComputeWorkGroupInvocations = value; }
        }
        
        public UInt32 MaxComputeWorkGroupSize
        {
            get { return NativeHandle->MaxComputeWorkGroupSize; }
            set { NativeHandle->MaxComputeWorkGroupSize = value; }
        }
        
        public UInt32 SubPixelPrecisionBits
        {
            get { return NativeHandle->SubPixelPrecisionBits; }
            set { NativeHandle->SubPixelPrecisionBits = value; }
        }
        
        public UInt32 SubTexelPrecisionBits
        {
            get { return NativeHandle->SubTexelPrecisionBits; }
            set { NativeHandle->SubTexelPrecisionBits = value; }
        }
        
        public UInt32 MipmapPrecisionBits
        {
            get { return NativeHandle->MipmapPrecisionBits; }
            set { NativeHandle->MipmapPrecisionBits = value; }
        }
        
        public UInt32 MaxDrawIndexedIndexValue
        {
            get { return NativeHandle->MaxDrawIndexedIndexValue; }
            set { NativeHandle->MaxDrawIndexedIndexValue = value; }
        }
        
        public UInt32 MaxDrawIndirectCount
        {
            get { return NativeHandle->MaxDrawIndirectCount; }
            set { NativeHandle->MaxDrawIndirectCount = value; }
        }
        
        public Single MaxSamplerLodBias
        {
            get { return NativeHandle->MaxSamplerLodBias; }
            set { NativeHandle->MaxSamplerLodBias = value; }
        }
        
        public Single MaxSamplerAnisotropy
        {
            get { return NativeHandle->MaxSamplerAnisotropy; }
            set { NativeHandle->MaxSamplerAnisotropy = value; }
        }
        
        public UInt32 MaxViewports
        {
            get { return NativeHandle->MaxViewports; }
            set { NativeHandle->MaxViewports = value; }
        }
        
        public UInt32 MaxViewportDimensions
        {
            get { return NativeHandle->MaxViewportDimensions; }
            set { NativeHandle->MaxViewportDimensions = value; }
        }
        
        public Single ViewportBoundsRange
        {
            get { return NativeHandle->ViewportBoundsRange; }
            set { NativeHandle->ViewportBoundsRange = value; }
        }
        
        public UInt32 ViewportSubPixelBits
        {
            get { return NativeHandle->ViewportSubPixelBits; }
            set { NativeHandle->ViewportSubPixelBits = value; }
        }
        
        public UIntPtr MinMemoryMapAlignment
        {
            get { return NativeHandle->MinMemoryMapAlignment; }
            set { NativeHandle->MinMemoryMapAlignment = value; }
        }
        
        DeviceSize _MinTexelBufferOffsetAlignment;
        public DeviceSize MinTexelBufferOffsetAlignment
        {
            get { return _MinTexelBufferOffsetAlignment; }
            set { _MinTexelBufferOffsetAlignment = value; NativeHandle->MinTexelBufferOffsetAlignment = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _MinUniformBufferOffsetAlignment;
        public DeviceSize MinUniformBufferOffsetAlignment
        {
            get { return _MinUniformBufferOffsetAlignment; }
            set { _MinUniformBufferOffsetAlignment = value; NativeHandle->MinUniformBufferOffsetAlignment = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _MinStorageBufferOffsetAlignment;
        public DeviceSize MinStorageBufferOffsetAlignment
        {
            get { return _MinStorageBufferOffsetAlignment; }
            set { _MinStorageBufferOffsetAlignment = value; NativeHandle->MinStorageBufferOffsetAlignment = (IntPtr)value.NativeHandle; }
        }
        
        public Int32 MinTexelOffset
        {
            get { return NativeHandle->MinTexelOffset; }
            set { NativeHandle->MinTexelOffset = value; }
        }
        
        public UInt32 MaxTexelOffset
        {
            get { return NativeHandle->MaxTexelOffset; }
            set { NativeHandle->MaxTexelOffset = value; }
        }
        
        public Int32 MinTexelGatherOffset
        {
            get { return NativeHandle->MinTexelGatherOffset; }
            set { NativeHandle->MinTexelGatherOffset = value; }
        }
        
        public UInt32 MaxTexelGatherOffset
        {
            get { return NativeHandle->MaxTexelGatherOffset; }
            set { NativeHandle->MaxTexelGatherOffset = value; }
        }
        
        public Single MinInterpolationOffset
        {
            get { return NativeHandle->MinInterpolationOffset; }
            set { NativeHandle->MinInterpolationOffset = value; }
        }
        
        public Single MaxInterpolationOffset
        {
            get { return NativeHandle->MaxInterpolationOffset; }
            set { NativeHandle->MaxInterpolationOffset = value; }
        }
        
        public UInt32 SubPixelInterpolationOffsetBits
        {
            get { return NativeHandle->SubPixelInterpolationOffsetBits; }
            set { NativeHandle->SubPixelInterpolationOffsetBits = value; }
        }
        
        public UInt32 MaxFramebufferWidth
        {
            get { return NativeHandle->MaxFramebufferWidth; }
            set { NativeHandle->MaxFramebufferWidth = value; }
        }
        
        public UInt32 MaxFramebufferHeight
        {
            get { return NativeHandle->MaxFramebufferHeight; }
            set { NativeHandle->MaxFramebufferHeight = value; }
        }
        
        public UInt32 MaxFramebufferLayers
        {
            get { return NativeHandle->MaxFramebufferLayers; }
            set { NativeHandle->MaxFramebufferLayers = value; }
        }
        
        public SampleCountFlags FramebufferColorSampleCounts
        {
            get { return NativeHandle->FramebufferColorSampleCounts; }
            set { NativeHandle->FramebufferColorSampleCounts = value; }
        }
        
        public SampleCountFlags FramebufferDepthSampleCounts
        {
            get { return NativeHandle->FramebufferDepthSampleCounts; }
            set { NativeHandle->FramebufferDepthSampleCounts = value; }
        }
        
        public SampleCountFlags FramebufferStencilSampleCounts
        {
            get { return NativeHandle->FramebufferStencilSampleCounts; }
            set { NativeHandle->FramebufferStencilSampleCounts = value; }
        }
        
        public SampleCountFlags FramebufferNoAttachmentsSampleCounts
        {
            get { return NativeHandle->FramebufferNoAttachmentsSampleCounts; }
            set { NativeHandle->FramebufferNoAttachmentsSampleCounts = value; }
        }
        
        public UInt32 MaxColorAttachments
        {
            get { return NativeHandle->MaxColorAttachments; }
            set { NativeHandle->MaxColorAttachments = value; }
        }
        
        public SampleCountFlags SampledImageColorSampleCounts
        {
            get { return NativeHandle->SampledImageColorSampleCounts; }
            set { NativeHandle->SampledImageColorSampleCounts = value; }
        }
        
        public SampleCountFlags SampledImageIntegerSampleCounts
        {
            get { return NativeHandle->SampledImageIntegerSampleCounts; }
            set { NativeHandle->SampledImageIntegerSampleCounts = value; }
        }
        
        public SampleCountFlags SampledImageDepthSampleCounts
        {
            get { return NativeHandle->SampledImageDepthSampleCounts; }
            set { NativeHandle->SampledImageDepthSampleCounts = value; }
        }
        
        public SampleCountFlags SampledImageStencilSampleCounts
        {
            get { return NativeHandle->SampledImageStencilSampleCounts; }
            set { NativeHandle->SampledImageStencilSampleCounts = value; }
        }
        
        public SampleCountFlags StorageImageSampleCounts
        {
            get { return NativeHandle->StorageImageSampleCounts; }
            set { NativeHandle->StorageImageSampleCounts = value; }
        }
        
        public UInt32 MaxSampleMaskWords
        {
            get { return NativeHandle->MaxSampleMaskWords; }
            set { NativeHandle->MaxSampleMaskWords = value; }
        }
        
        public Boolean TimestampComputeAndGraphics
        {
            get { return NativeHandle->TimestampComputeAndGraphics; }
            set { NativeHandle->TimestampComputeAndGraphics = value; }
        }
        
        public Single TimestampPeriod
        {
            get { return NativeHandle->TimestampPeriod; }
            set { NativeHandle->TimestampPeriod = value; }
        }
        
        public UInt32 MaxClipDistances
        {
            get { return NativeHandle->MaxClipDistances; }
            set { NativeHandle->MaxClipDistances = value; }
        }
        
        public UInt32 MaxCullDistances
        {
            get { return NativeHandle->MaxCullDistances; }
            set { NativeHandle->MaxCullDistances = value; }
        }
        
        public UInt32 MaxCombinedClipAndCullDistances
        {
            get { return NativeHandle->MaxCombinedClipAndCullDistances; }
            set { NativeHandle->MaxCombinedClipAndCullDistances = value; }
        }
        
        public UInt32 DiscreteQueuePriorities
        {
            get { return NativeHandle->DiscreteQueuePriorities; }
            set { NativeHandle->DiscreteQueuePriorities = value; }
        }
        
        public Single PointSizeRange
        {
            get { return NativeHandle->PointSizeRange; }
            set { NativeHandle->PointSizeRange = value; }
        }
        
        public Single LineWidthRange
        {
            get { return NativeHandle->LineWidthRange; }
            set { NativeHandle->LineWidthRange = value; }
        }
        
        public Single PointSizeGranularity
        {
            get { return NativeHandle->PointSizeGranularity; }
            set { NativeHandle->PointSizeGranularity = value; }
        }
        
        public Single LineWidthGranularity
        {
            get { return NativeHandle->LineWidthGranularity; }
            set { NativeHandle->LineWidthGranularity = value; }
        }
        
        public Boolean StrictLines
        {
            get { return NativeHandle->StrictLines; }
            set { NativeHandle->StrictLines = value; }
        }
        
        public Boolean StandardSampleLocations
        {
            get { return NativeHandle->StandardSampleLocations; }
            set { NativeHandle->StandardSampleLocations = value; }
        }
        
        DeviceSize _OptimalBufferCopyOffsetAlignment;
        public DeviceSize OptimalBufferCopyOffsetAlignment
        {
            get { return _OptimalBufferCopyOffsetAlignment; }
            set { _OptimalBufferCopyOffsetAlignment = value; NativeHandle->OptimalBufferCopyOffsetAlignment = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _OptimalBufferCopyRowPitchAlignment;
        public DeviceSize OptimalBufferCopyRowPitchAlignment
        {
            get { return _OptimalBufferCopyRowPitchAlignment; }
            set { _OptimalBufferCopyRowPitchAlignment = value; NativeHandle->OptimalBufferCopyRowPitchAlignment = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _NonCoherentAtomSize;
        public DeviceSize NonCoherentAtomSize
        {
            get { return _NonCoherentAtomSize; }
            set { _NonCoherentAtomSize = value; NativeHandle->NonCoherentAtomSize = (IntPtr)value.NativeHandle; }
        }
        
        public PhysicalDeviceLimits()
        {
            NativeHandle = (Interop.PhysicalDeviceLimits*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceLimits));
        }
    }
}
