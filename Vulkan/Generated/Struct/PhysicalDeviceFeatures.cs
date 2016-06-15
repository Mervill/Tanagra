using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
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
}
