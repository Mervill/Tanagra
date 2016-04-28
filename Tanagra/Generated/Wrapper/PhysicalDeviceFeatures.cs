using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceFeatures
    {
        internal Interop.PhysicalDeviceFeatures* NativePointer;
        
        public Boolean RobustBufferAccess
        {
            get { return NativePointer->RobustBufferAccess; }
            set { NativePointer->RobustBufferAccess = value; }
        }
        
        public Boolean FullDrawIndexUint32
        {
            get { return NativePointer->FullDrawIndexUint32; }
            set { NativePointer->FullDrawIndexUint32 = value; }
        }
        
        public Boolean ImageCubeArray
        {
            get { return NativePointer->ImageCubeArray; }
            set { NativePointer->ImageCubeArray = value; }
        }
        
        public Boolean IndependentBlend
        {
            get { return NativePointer->IndependentBlend; }
            set { NativePointer->IndependentBlend = value; }
        }
        
        public Boolean GeometryShader
        {
            get { return NativePointer->GeometryShader; }
            set { NativePointer->GeometryShader = value; }
        }
        
        public Boolean TessellationShader
        {
            get { return NativePointer->TessellationShader; }
            set { NativePointer->TessellationShader = value; }
        }
        
        public Boolean SampleRateShading
        {
            get { return NativePointer->SampleRateShading; }
            set { NativePointer->SampleRateShading = value; }
        }
        
        public Boolean DualSrcBlend
        {
            get { return NativePointer->DualSrcBlend; }
            set { NativePointer->DualSrcBlend = value; }
        }
        
        public Boolean LogicOp
        {
            get { return NativePointer->LogicOp; }
            set { NativePointer->LogicOp = value; }
        }
        
        public Boolean MultiDrawIndirect
        {
            get { return NativePointer->MultiDrawIndirect; }
            set { NativePointer->MultiDrawIndirect = value; }
        }
        
        public Boolean DrawIndirectFirstInstance
        {
            get { return NativePointer->DrawIndirectFirstInstance; }
            set { NativePointer->DrawIndirectFirstInstance = value; }
        }
        
        public Boolean DepthClamp
        {
            get { return NativePointer->DepthClamp; }
            set { NativePointer->DepthClamp = value; }
        }
        
        public Boolean DepthBiasClamp
        {
            get { return NativePointer->DepthBiasClamp; }
            set { NativePointer->DepthBiasClamp = value; }
        }
        
        public Boolean FillModeNonSolid
        {
            get { return NativePointer->FillModeNonSolid; }
            set { NativePointer->FillModeNonSolid = value; }
        }
        
        public Boolean DepthBounds
        {
            get { return NativePointer->DepthBounds; }
            set { NativePointer->DepthBounds = value; }
        }
        
        public Boolean WideLines
        {
            get { return NativePointer->WideLines; }
            set { NativePointer->WideLines = value; }
        }
        
        public Boolean LargePoints
        {
            get { return NativePointer->LargePoints; }
            set { NativePointer->LargePoints = value; }
        }
        
        public Boolean AlphaToOne
        {
            get { return NativePointer->AlphaToOne; }
            set { NativePointer->AlphaToOne = value; }
        }
        
        public Boolean MultiViewport
        {
            get { return NativePointer->MultiViewport; }
            set { NativePointer->MultiViewport = value; }
        }
        
        public Boolean SamplerAnisotropy
        {
            get { return NativePointer->SamplerAnisotropy; }
            set { NativePointer->SamplerAnisotropy = value; }
        }
        
        public Boolean TextureCompressionETC2
        {
            get { return NativePointer->TextureCompressionETC2; }
            set { NativePointer->TextureCompressionETC2 = value; }
        }
        
        public Boolean TextureCompressionASTC_LDR
        {
            get { return NativePointer->TextureCompressionASTC_LDR; }
            set { NativePointer->TextureCompressionASTC_LDR = value; }
        }
        
        public Boolean TextureCompressionBC
        {
            get { return NativePointer->TextureCompressionBC; }
            set { NativePointer->TextureCompressionBC = value; }
        }
        
        public Boolean OcclusionQueryPrecise
        {
            get { return NativePointer->OcclusionQueryPrecise; }
            set { NativePointer->OcclusionQueryPrecise = value; }
        }
        
        public Boolean PipelineStatisticsQuery
        {
            get { return NativePointer->PipelineStatisticsQuery; }
            set { NativePointer->PipelineStatisticsQuery = value; }
        }
        
        public Boolean VertexPipelineStoresAndAtomics
        {
            get { return NativePointer->VertexPipelineStoresAndAtomics; }
            set { NativePointer->VertexPipelineStoresAndAtomics = value; }
        }
        
        public Boolean FragmentStoresAndAtomics
        {
            get { return NativePointer->FragmentStoresAndAtomics; }
            set { NativePointer->FragmentStoresAndAtomics = value; }
        }
        
        public Boolean ShaderTessellationAndGeometryPointSize
        {
            get { return NativePointer->ShaderTessellationAndGeometryPointSize; }
            set { NativePointer->ShaderTessellationAndGeometryPointSize = value; }
        }
        
        public Boolean ShaderImageGatherExtended
        {
            get { return NativePointer->ShaderImageGatherExtended; }
            set { NativePointer->ShaderImageGatherExtended = value; }
        }
        
        public Boolean ShaderStorageImageExtendedFormats
        {
            get { return NativePointer->ShaderStorageImageExtendedFormats; }
            set { NativePointer->ShaderStorageImageExtendedFormats = value; }
        }
        
        public Boolean ShaderStorageImageMultisample
        {
            get { return NativePointer->ShaderStorageImageMultisample; }
            set { NativePointer->ShaderStorageImageMultisample = value; }
        }
        
        public Boolean ShaderStorageImageReadWithoutFormat
        {
            get { return NativePointer->ShaderStorageImageReadWithoutFormat; }
            set { NativePointer->ShaderStorageImageReadWithoutFormat = value; }
        }
        
        public Boolean ShaderStorageImageWriteWithoutFormat
        {
            get { return NativePointer->ShaderStorageImageWriteWithoutFormat; }
            set { NativePointer->ShaderStorageImageWriteWithoutFormat = value; }
        }
        
        public Boolean ShaderUniformBufferArrayDynamicIndexing
        {
            get { return NativePointer->ShaderUniformBufferArrayDynamicIndexing; }
            set { NativePointer->ShaderUniformBufferArrayDynamicIndexing = value; }
        }
        
        public Boolean ShaderSampledImageArrayDynamicIndexing
        {
            get { return NativePointer->ShaderSampledImageArrayDynamicIndexing; }
            set { NativePointer->ShaderSampledImageArrayDynamicIndexing = value; }
        }
        
        public Boolean ShaderStorageBufferArrayDynamicIndexing
        {
            get { return NativePointer->ShaderStorageBufferArrayDynamicIndexing; }
            set { NativePointer->ShaderStorageBufferArrayDynamicIndexing = value; }
        }
        
        public Boolean ShaderStorageImageArrayDynamicIndexing
        {
            get { return NativePointer->ShaderStorageImageArrayDynamicIndexing; }
            set { NativePointer->ShaderStorageImageArrayDynamicIndexing = value; }
        }
        
        public Boolean ShaderClipDistance
        {
            get { return NativePointer->ShaderClipDistance; }
            set { NativePointer->ShaderClipDistance = value; }
        }
        
        public Boolean ShaderCullDistance
        {
            get { return NativePointer->ShaderCullDistance; }
            set { NativePointer->ShaderCullDistance = value; }
        }
        
        public Boolean ShaderFloat64
        {
            get { return NativePointer->ShaderFloat64; }
            set { NativePointer->ShaderFloat64 = value; }
        }
        
        public Boolean ShaderInt64
        {
            get { return NativePointer->ShaderInt64; }
            set { NativePointer->ShaderInt64 = value; }
        }
        
        public Boolean ShaderInt16
        {
            get { return NativePointer->ShaderInt16; }
            set { NativePointer->ShaderInt16 = value; }
        }
        
        public Boolean ShaderResourceResidency
        {
            get { return NativePointer->ShaderResourceResidency; }
            set { NativePointer->ShaderResourceResidency = value; }
        }
        
        public Boolean ShaderResourceMinLod
        {
            get { return NativePointer->ShaderResourceMinLod; }
            set { NativePointer->ShaderResourceMinLod = value; }
        }
        
        public Boolean SparseBinding
        {
            get { return NativePointer->SparseBinding; }
            set { NativePointer->SparseBinding = value; }
        }
        
        public Boolean SparseResidencyBuffer
        {
            get { return NativePointer->SparseResidencyBuffer; }
            set { NativePointer->SparseResidencyBuffer = value; }
        }
        
        public Boolean SparseResidencyImage2D
        {
            get { return NativePointer->SparseResidencyImage2D; }
            set { NativePointer->SparseResidencyImage2D = value; }
        }
        
        public Boolean SparseResidencyImage3D
        {
            get { return NativePointer->SparseResidencyImage3D; }
            set { NativePointer->SparseResidencyImage3D = value; }
        }
        
        public Boolean SparseResidency2Samples
        {
            get { return NativePointer->SparseResidency2Samples; }
            set { NativePointer->SparseResidency2Samples = value; }
        }
        
        public Boolean SparseResidency4Samples
        {
            get { return NativePointer->SparseResidency4Samples; }
            set { NativePointer->SparseResidency4Samples = value; }
        }
        
        public Boolean SparseResidency8Samples
        {
            get { return NativePointer->SparseResidency8Samples; }
            set { NativePointer->SparseResidency8Samples = value; }
        }
        
        public Boolean SparseResidency16Samples
        {
            get { return NativePointer->SparseResidency16Samples; }
            set { NativePointer->SparseResidency16Samples = value; }
        }
        
        public Boolean SparseResidencyAliased
        {
            get { return NativePointer->SparseResidencyAliased; }
            set { NativePointer->SparseResidencyAliased = value; }
        }
        
        public Boolean VariableMultisampleRate
        {
            get { return NativePointer->VariableMultisampleRate; }
            set { NativePointer->VariableMultisampleRate = value; }
        }
        
        public Boolean InheritedQueries
        {
            get { return NativePointer->InheritedQueries; }
            set { NativePointer->InheritedQueries = value; }
        }
        
        public PhysicalDeviceFeatures()
        {
            NativePointer = (Interop.PhysicalDeviceFeatures*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceFeatures));
        }
    }
}
