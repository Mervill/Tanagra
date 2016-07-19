using System;

namespace Vulkan
{
    public static class VulkanConstant
    {
        public const Int32  MaxPhysicalDeviceNameSize = 256;
        public const Int32  UuidSize = 16;
        public const Int32  MaxExtensionNameSize = 256;
        public const Int32  MaxDescriptionSize = 256;
        public const Int32  MaxMemoryTypes = 32;
        public const Int32  MaxMemoryHeaps = 16;
        public const Single LodClampNone = 1000f;
        public const UInt32 RemainingMipLevels = 0xFFFFFFFF;
        public const UInt32 RemainingArrayLayers = 0xFFFFFFFF;
        public const UInt64 WholeSize = 0xFFFFFFFFFFFFFFFF;
        public const UInt32 AttachmentUnused = 0xFFFFFFFF;
        public const UInt32 QueueFamilyIgnored = 0xFFFFFFFF;
        public const UInt32 SubpassExternal = 0xFFFFFFFF;
        public const Int32  KhrSurfaceSpecVersion = 25;
        public const String KhrSurfaceExtensionName = "VK_KHR_surface";
        public const String ColorspaceSrgbNonlinearKHR = "VK_COLOR_SPACE_SRGB_NONLINEAR_KHR";
        public const Int32  KhrSwapchainSpecVersion = 68;
        public const String KhrSwapchainExtensionName = "VK_KHR_swapchain";
        public const Int32  KhrDisplaySpecVersion = 21;
        public const String KhrDisplayExtensionName = "VK_KHR_display";
        public const Int32  KhrDisplaySwapchainSpecVersion = 9;
        public const String KhrDisplaySwapchainExtensionName = "VK_KHR_display_swapchain";
        public const Int32  KhrXlibSurfaceSpecVersion = 6;
        public const String KhrXlibSurfaceExtensionName = "VK_KHR_xlib_surface";
        public const Int32  KhrXcbSurfaceSpecVersion = 6;
        public const String KhrXcbSurfaceExtensionName = "VK_KHR_xcb_surface";
        public const Int32  KhrWaylandSurfaceSpecVersion = 5;
        public const String KhrWaylandSurfaceExtensionName = "VK_KHR_wayland_surface";
        public const Int32  KhrMirSurfaceSpecVersion = 4;
        public const String KhrMirSurfaceExtensionName = "VK_KHR_mir_surface";
        public const Int32  KhrAndroidSurfaceSpecVersion = 6;
        public const String KhrAndroidSurfaceExtensionName = "VK_KHR_android_surface";
        public const Int32  KhrWin32SurfaceSpecVersion = 5;
        public const String KhrWin32SurfaceExtensionName = "VK_KHR_win32_surface";
        public const Int32  ExtDebugReportSpecVersion = 3;
        public const String ExtDebugReportExtensionName = "VK_EXT_debug_report";
        public const String StructureTypeDebugReportCreateInfoEXT = "VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT";
        public const Int32  NvGlslShaderSpecVersion = 1;
        public const String NvGlslShaderExtensionName = "VK_NV_glsl_shader";
        public const Int32  KhrSamplerMirrorClampToEdgeSpecVersion = 1;
        public const String KhrSamplerMirrorClampToEdgeExtensionName = "VK_KHR_sampler_mirror_clamp_to_edge";
        public const Int32  ImgFilterCubicSpecVersion = 1;
        public const String ImgFilterCubicExtensionName = "VK_IMG_filter_cubic";
        public const Int32  AmdRasterizationOrderSpecVersion = 1;
        public const String AmdRasterizationOrderExtensionName = "VK_AMD_rasterization_order";
        public const Int32  AmdShaderTrinaryMinmaxSpecVersion = 1;
        public const String AmdShaderTrinaryMinmaxExtensionName = "VK_AMD_shader_trinary_minmax";
        public const Int32  AmdShaderExplicitVertexParameterSpecVersion = 1;
        public const String AmdShaderExplicitVertexParameterExtensionName = "VK_AMD_shader_explicit_vertex_parameter";
        public const Int32  ExtDebugMarkerSpecVersion = 3;
        public const String ExtDebugMarkerExtensionName = "VK_EXT_debug_marker";
        public const Int32  AmdGcnShaderSpecVersion = 1;
        public const String AmdGcnShaderExtensionName = "VK_AMD_gcn_shader";
        public const Int32  NvDedicatedAllocationSpecVersion = 1;
        public const String NvDedicatedAllocationExtensionName = "VK_NV_dedicated_allocation";
    }
}
