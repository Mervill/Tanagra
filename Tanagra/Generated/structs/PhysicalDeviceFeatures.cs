using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceFeatures
    {
        internal Interop.PhysicalDeviceFeatures* NativeHandle;
        
        public Boolean RobustBufferAccess
        {
            get { return NativeHandle->RobustBufferAccess; }
            set { NativeHandle->RobustBufferAccess = value; }
        }
        
        public Boolean FullDrawIndexUint32
        {
            get { return NativeHandle->FullDrawIndexUint32; }
            set { NativeHandle->FullDrawIndexUint32 = value; }
        }
        
        public Boolean ImageCubeArray
        {
            get { return NativeHandle->ImageCubeArray; }
            set { NativeHandle->ImageCubeArray = value; }
        }
        
        public Boolean IndependentBlend
        {
            get { return NativeHandle->IndependentBlend; }
            set { NativeHandle->IndependentBlend = value; }
        }
        
        public Boolean GeometryShader
        {
            get { return NativeHandle->GeometryShader; }
            set { NativeHandle->GeometryShader = value; }
        }
        
        public Boolean TessellationShader
        {
            get { return NativeHandle->TessellationShader; }
            set { NativeHandle->TessellationShader = value; }
        }
        
        public Boolean SampleRateShading
        {
            get { return NativeHandle->SampleRateShading; }
            set { NativeHandle->SampleRateShading = value; }
        }
        
        public Boolean DualSrcBlend
        {
            get { return NativeHandle->DualSrcBlend; }
            set { NativeHandle->DualSrcBlend = value; }
        }
        
        public Boolean LogicOp
        {
            get { return NativeHandle->LogicOp; }
            set { NativeHandle->LogicOp = value; }
        }
        
        public Boolean MultiDrawIndirect
        {
            get { return NativeHandle->MultiDrawIndirect; }
            set { NativeHandle->MultiDrawIndirect = value; }
        }
        
        public Boolean DrawIndirectFirstInstance
        {
            get { return NativeHandle->DrawIndirectFirstInstance; }
            set { NativeHandle->DrawIndirectFirstInstance = value; }
        }
        
        public Boolean DepthClamp
        {
            get { return NativeHandle->DepthClamp; }
            set { NativeHandle->DepthClamp = value; }
        }
        
        public Boolean DepthBiasClamp
        {
            get { return NativeHandle->DepthBiasClamp; }
            set { NativeHandle->DepthBiasClamp = value; }
        }
        
        public Boolean FillModeNonSolid
        {
            get { return NativeHandle->FillModeNonSolid; }
            set { NativeHandle->FillModeNonSolid = value; }
        }
        
        public Boolean DepthBounds
        {
            get { return NativeHandle->DepthBounds; }
            set { NativeHandle->DepthBounds = value; }
        }
        
        public Boolean WideLines
        {
            get { return NativeHandle->WideLines; }
            set { NativeHandle->WideLines = value; }
        }
        
        public Boolean LargePoints
        {
            get { return NativeHandle->LargePoints; }
            set { NativeHandle->LargePoints = value; }
        }
        
        public Boolean AlphaToOne
        {
            get { return NativeHandle->AlphaToOne; }
            set { NativeHandle->AlphaToOne = value; }
        }
        
        public Boolean MultiViewport
        {
            get { return NativeHandle->MultiViewport; }
            set { NativeHandle->MultiViewport = value; }
        }
        
        public Boolean SamplerAnisotropy
        {
            get { return NativeHandle->SamplerAnisotropy; }
            set { NativeHandle->SamplerAnisotropy = value; }
        }
        
        public Boolean TextureCompressionETC2
        {
            get { return NativeHandle->TextureCompressionETC2; }
            set { NativeHandle->TextureCompressionETC2 = value; }
        }
        
        public Boolean TextureCompressionASTC_LDR
        {
            get { return NativeHandle->TextureCompressionASTC_LDR; }
            set { NativeHandle->TextureCompressionASTC_LDR = value; }
        }
        
        public Boolean TextureCompressionBC
        {
            get { return NativeHandle->TextureCompressionBC; }
            set { NativeHandle->TextureCompressionBC = value; }
        }
        
        public Boolean OcclusionQueryPrecise
        {
            get { return NativeHandle->OcclusionQueryPrecise; }
            set { NativeHandle->OcclusionQueryPrecise = value; }
        }
        
        public Boolean PipelineStatisticsQuery
        {
            get { return NativeHandle->PipelineStatisticsQuery; }
            set { NativeHandle->PipelineStatisticsQuery = value; }
        }
        
        public Boolean VertexPipelineStoresAndAtomics
        {
            get { return NativeHandle->VertexPipelineStoresAndAtomics; }
            set { NativeHandle->VertexPipelineStoresAndAtomics = value; }
        }
        
        public Boolean FragmentStoresAndAtomics
        {
            get { return NativeHandle->FragmentStoresAndAtomics; }
            set { NativeHandle->FragmentStoresAndAtomics = value; }
        }
        
        public Boolean ShaderTessellationAndGeometryPointSize
        {
            get { return NativeHandle->ShaderTessellationAndGeometryPointSize; }
            set { NativeHandle->ShaderTessellationAndGeometryPointSize = value; }
        }
        
        public Boolean ShaderImageGatherExtended
        {
            get { return NativeHandle->ShaderImageGatherExtended; }
            set { NativeHandle->ShaderImageGatherExtended = value; }
        }
        
        public Boolean ShaderStorageImageExtendedFormats
        {
            get { return NativeHandle->ShaderStorageImageExtendedFormats; }
            set { NativeHandle->ShaderStorageImageExtendedFormats = value; }
        }
        
        public Boolean ShaderStorageImageMultisample
        {
            get { return NativeHandle->ShaderStorageImageMultisample; }
            set { NativeHandle->ShaderStorageImageMultisample = value; }
        }
        
        public Boolean ShaderStorageImageReadWithoutFormat
        {
            get { return NativeHandle->ShaderStorageImageReadWithoutFormat; }
            set { NativeHandle->ShaderStorageImageReadWithoutFormat = value; }
        }
        
        public Boolean ShaderStorageImageWriteWithoutFormat
        {
            get { return NativeHandle->ShaderStorageImageWriteWithoutFormat; }
            set { NativeHandle->ShaderStorageImageWriteWithoutFormat = value; }
        }
        
        public Boolean ShaderUniformBufferArrayDynamicIndexing
        {
            get { return NativeHandle->ShaderUniformBufferArrayDynamicIndexing; }
            set { NativeHandle->ShaderUniformBufferArrayDynamicIndexing = value; }
        }
        
        public Boolean ShaderSampledImageArrayDynamicIndexing
        {
            get { return NativeHandle->ShaderSampledImageArrayDynamicIndexing; }
            set { NativeHandle->ShaderSampledImageArrayDynamicIndexing = value; }
        }
        
        public Boolean ShaderStorageBufferArrayDynamicIndexing
        {
            get { return NativeHandle->ShaderStorageBufferArrayDynamicIndexing; }
            set { NativeHandle->ShaderStorageBufferArrayDynamicIndexing = value; }
        }
        
        public Boolean ShaderStorageImageArrayDynamicIndexing
        {
            get { return NativeHandle->ShaderStorageImageArrayDynamicIndexing; }
            set { NativeHandle->ShaderStorageImageArrayDynamicIndexing = value; }
        }
        
        public Boolean ShaderClipDistance
        {
            get { return NativeHandle->ShaderClipDistance; }
            set { NativeHandle->ShaderClipDistance = value; }
        }
        
        public Boolean ShaderCullDistance
        {
            get { return NativeHandle->ShaderCullDistance; }
            set { NativeHandle->ShaderCullDistance = value; }
        }
        
        public Boolean ShaderFloat64
        {
            get { return NativeHandle->ShaderFloat64; }
            set { NativeHandle->ShaderFloat64 = value; }
        }
        
        public Boolean ShaderInt64
        {
            get { return NativeHandle->ShaderInt64; }
            set { NativeHandle->ShaderInt64 = value; }
        }
        
        public Boolean ShaderInt16
        {
            get { return NativeHandle->ShaderInt16; }
            set { NativeHandle->ShaderInt16 = value; }
        }
        
        public Boolean ShaderResourceResidency
        {
            get { return NativeHandle->ShaderResourceResidency; }
            set { NativeHandle->ShaderResourceResidency = value; }
        }
        
        public Boolean ShaderResourceMinLod
        {
            get { return NativeHandle->ShaderResourceMinLod; }
            set { NativeHandle->ShaderResourceMinLod = value; }
        }
        
        public Boolean SparseBinding
        {
            get { return NativeHandle->SparseBinding; }
            set { NativeHandle->SparseBinding = value; }
        }
        
        public Boolean SparseResidencyBuffer
        {
            get { return NativeHandle->SparseResidencyBuffer; }
            set { NativeHandle->SparseResidencyBuffer = value; }
        }
        
        public Boolean SparseResidencyImage2D
        {
            get { return NativeHandle->SparseResidencyImage2D; }
            set { NativeHandle->SparseResidencyImage2D = value; }
        }
        
        public Boolean SparseResidencyImage3D
        {
            get { return NativeHandle->SparseResidencyImage3D; }
            set { NativeHandle->SparseResidencyImage3D = value; }
        }
        
        public Boolean SparseResidency2Samples
        {
            get { return NativeHandle->SparseResidency2Samples; }
            set { NativeHandle->SparseResidency2Samples = value; }
        }
        
        public Boolean SparseResidency4Samples
        {
            get { return NativeHandle->SparseResidency4Samples; }
            set { NativeHandle->SparseResidency4Samples = value; }
        }
        
        public Boolean SparseResidency8Samples
        {
            get { return NativeHandle->SparseResidency8Samples; }
            set { NativeHandle->SparseResidency8Samples = value; }
        }
        
        public Boolean SparseResidency16Samples
        {
            get { return NativeHandle->SparseResidency16Samples; }
            set { NativeHandle->SparseResidency16Samples = value; }
        }
        
        public Boolean SparseResidencyAliased
        {
            get { return NativeHandle->SparseResidencyAliased; }
            set { NativeHandle->SparseResidencyAliased = value; }
        }
        
        public Boolean VariableMultisampleRate
        {
            get { return NativeHandle->VariableMultisampleRate; }
            set { NativeHandle->VariableMultisampleRate = value; }
        }
        
        public Boolean InheritedQueries
        {
            get { return NativeHandle->InheritedQueries; }
            set { NativeHandle->InheritedQueries = value; }
        }
        
        public PhysicalDeviceFeatures()
        {
            NativeHandle = (Interop.PhysicalDeviceFeatures*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceFeatures));
        }
    }
}
