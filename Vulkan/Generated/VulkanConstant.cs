using System;

namespace Vulkan
{
    public static class VulkanConstant
    {
        public const Int32 MaxPhysicalDeviceNameSize = 256;
        public const Int32 UuidSize = 16;
        public const Int32 MaxExtensionNameSize = 256;
        public const Int32 MaxDescriptionSize = 256;
        public const Int32 MaxMemoryTypes = 32;
        public const Int32 MaxMemoryHeaps = 16;
        public const String LodClampNone = "1000.0f";
        public const String RemainingMipLevels = "(~0U)";
        public const String RemainingArrayLayers = "(~0U)";
        public const String WholeSize = "(~0ULL)";
        public const String AttachmentUnused = "(~0U)";
        public const String QueueFamilyIgnored = "(~0U)";
        public const String SubpassExternal = "(~0U)";
        public const Int32 KhrSurfaceSpecVersion = 25;
        public const String KhrSurfaceExtensionName = "VK_KHR_surface";
        public const String ColorspaceSrgbNonlinearKHR = "VK_COLOR_SPACE_SRGB_NONLINEAR_KHR";
        public const Int32 KhrSwapchainSpecVersion = 68;
        public const String KhrSwapchainExtensionName = "VK_KHR_swapchain";
        public const Int32 KhrDisplaySpecVersion = 21;
        public const String KhrDisplayExtensionName = "VK_KHR_display";
        public const Int32 KhrDisplaySwapchainSpecVersion = 9;
        public const String KhrDisplaySwapchainExtensionName = "VK_KHR_display_swapchain";
        public const Int32 KhrXlibSurfaceSpecVersion = 6;
        public const String KhrXlibSurfaceExtensionName = "VK_KHR_xlib_surface";
        public const Int32 KhrXcbSurfaceSpecVersion = 6;
        public const String KhrXcbSurfaceExtensionName = "VK_KHR_xcb_surface";
        public const Int32 KhrWaylandSurfaceSpecVersion = 5;
        public const String KhrWaylandSurfaceExtensionName = "VK_KHR_wayland_surface";
        public const Int32 KhrMirSurfaceSpecVersion = 4;
        public const String KhrMirSurfaceExtensionName = "VK_KHR_mir_surface";
        public const Int32 KhrAndroidSurfaceSpecVersion = 6;
        public const String KhrAndroidSurfaceExtensionName = "VK_KHR_android_surface";
        public const Int32 KhrWin32SurfaceSpecVersion = 5;
        public const String KhrWin32SurfaceExtensionName = "VK_KHR_win32_surface";
        public const Int32 AndroidNativeBufferSpecVersion = 4;
        public const Int32 AndroidNativeBufferNumber = 11;
        public const String AndroidNativeBufferName = "VK_ANDROID_native_buffer";
        public const Int32 ExtDebugReportSpecVersion = 2;
        public const String ExtDebugReportExtensionName = "VK_EXT_debug_report";
        public const String StructureTypeDebugReportCreateInfoEXT = "VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT";
        public const Int32 NvGlslShaderSpecVersion = 1;
        public const String NvGlslShaderExtensionName = "VK_NV_glsl_shader";
        public const Int32 NvExtension1SpecVersion = 0;
        public const String NvExtension1ExtensionName = "VK_NV_extension_1";
        public const Int32 KhrSamplerMirrorClampToEdgeSpecVersion = 1;
        public const String KhrSamplerMirrorClampToEdgeExtensionName = "VK_KHR_sampler_mirror_clamp_to_edge";
        public const Int32 ImgFilterCubicSpecVersion = 1;
        public const String ImgFilterCubicExtensionName = "VK_IMG_filter_cubic";
        public const Int32 AmdExtension1SpecVersion = 0;
        public const String AmdExtension1ExtensionName = "VK_AMD_extension_1";
        public const Int32 AmdExtension2SpecVersion = 0;
        public const String AmdExtension2ExtensionName = "VK_AMD_extension_2";
        public const Int32 AmdRasterizationOrderSpecVersion = 1;
        public const String AmdRasterizationOrderExtensionName = "VK_AMD_rasterization_order";
        public const Int32 AmdExtension4SpecVersion = 0;
        public const String AmdExtension4ExtensionName = "VK_AMD_extension_4";
        public const Int32 AmdExtension5SpecVersion = 0;
        public const String AmdExtension5ExtensionName = "VK_AMD_extension_5";
        public const Int32 AmdExtension6SpecVersion = 0;
        public const String AmdExtension6ExtensionName = "VK_AMD_extension_6";
        public const Int32 ExtDebugMarkerSpecVersion = 3;
        public const String ExtDebugMarkerExtensionName = "VK_EXT_debug_marker";
    }
}
