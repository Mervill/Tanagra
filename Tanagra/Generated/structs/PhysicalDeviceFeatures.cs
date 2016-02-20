using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public class PhysicalDeviceFeatures
    {
        public Boolean robustBufferAccess;
        public Boolean fullDrawIndexUint32;
        public Boolean imageCubeArray;
        public Boolean independentBlend;
        public Boolean geometryShader;
        public Boolean tessellationShader;
        public Boolean sampleRateShading;
        public Boolean dualSrcBlend;
        public Boolean logicOp;
        public Boolean multiDrawIndirect;
        public Boolean drawIndirectFirstInstance;
        public Boolean depthClamp;
        public Boolean depthBiasClamp;
        public Boolean fillModeNonSolid;
        public Boolean depthBounds;
        public Boolean wideLines;
        public Boolean largePoints;
        public Boolean alphaToOne;
        public Boolean multiViewport;
        public Boolean samplerAnisotropy;
        public Boolean textureCompressionETC2;
        public Boolean textureCompressionASTC_LDR;
        public Boolean textureCompressionBC;
        public Boolean occlusionQueryPrecise;
        public Boolean pipelineStatisticsQuery;
        public Boolean vertexPipelineStoresAndAtomics;
        public Boolean fragmentStoresAndAtomics;
        public Boolean shaderTessellationAndGeometryPointSize;
        public Boolean shaderImageGatherExtended;
        public Boolean shaderStorageImageExtendedFormats;
        public Boolean shaderStorageImageMultisample;
        public Boolean shaderStorageImageReadWithoutFormat;
        public Boolean shaderStorageImageWriteWithoutFormat;
        public Boolean shaderUniformBufferArrayDynamicIndexing;
        public Boolean shaderSampledImageArrayDynamicIndexing;
        public Boolean shaderStorageBufferArrayDynamicIndexing;
        public Boolean shaderStorageImageArrayDynamicIndexing;
        public Boolean shaderClipDistance;
        public Boolean shaderCullDistance;
        public Boolean shaderFloat64;
        public Boolean shaderInt64;
        public Boolean shaderInt16;
        public Boolean shaderResourceResidency;
        public Boolean shaderResourceMinLod;
        public Boolean sparseBinding;
        public Boolean sparseResidencyBuffer;
        public Boolean sparseResidencyImage2D;
        public Boolean sparseResidencyImage3D;
        public Boolean sparseResidency2Samples;
        public Boolean sparseResidency4Samples;
        public Boolean sparseResidency8Samples;
        public Boolean sparseResidency16Samples;
        public Boolean sparseResidencyAliased;
        public Boolean variableMultisampleRate;
        public Boolean inheritedQueries;
    }
}
