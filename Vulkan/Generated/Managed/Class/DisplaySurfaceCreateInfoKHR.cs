using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DisplaySurfaceCreateInfoKHR : IDisposable
    {
        internal Unmanaged.DisplaySurfaceCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DisplaySurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        DisplayModeKHR _DisplayMode;
        /// <summary>
        /// The mode to use when displaying this surface
        /// </summary>
        public DisplayModeKHR DisplayMode
        {
            get { return _DisplayMode; }
            set { _DisplayMode = value; NativePointer->DisplayMode = value.NativePointer; }
        }
        
        /// <summary>
        /// The plane on which this surface appears. Must be between 0 and the value returned by vkGetPhysicalDeviceDisplayPlanePropertiesKHR() in pPropertyCount.
        /// </summary>
        public UInt32 PlaneIndex
        {
            get { return NativePointer->PlaneIndex; }
            set { NativePointer->PlaneIndex = value; }
        }
        
        /// <summary>
        /// The z-order of the plane.
        /// </summary>
        public UInt32 PlaneStackIndex
        {
            get { return NativePointer->PlaneStackIndex; }
            set { NativePointer->PlaneStackIndex = value; }
        }
        
        /// <summary>
        /// Transform to apply to the images as part of the scannout operation
        /// </summary>
        public SurfaceTransformFlagsKHR Transform
        {
            get { return NativePointer->Transform; }
            set { NativePointer->Transform = value; }
        }
        
        /// <summary>
        /// Global alpha value. Must be between 0 and 1, inclusive. Ignored if alphaMode is not VK_DISPLAY_PLANE_ALPHA_GLOBAL_BIT_KHR
        /// </summary>
        public Single GlobalAlpha
        {
            get { return NativePointer->GlobalAlpha; }
            set { NativePointer->GlobalAlpha = value; }
        }
        
        /// <summary>
        /// What type of alpha blending to use. Must be a bit from vkGetDisplayPlanePropertiesKHR::supportedAlpha.
        /// </summary>
        public DisplayPlaneAlphaFlagsKHR AlphaMode
        {
            get { return NativePointer->AlphaMode; }
            set { NativePointer->AlphaMode = value; }
        }
        
        /// <summary>
        /// Size of the images to use with this surface
        /// </summary>
        public Extent2D ImageExtent
        {
            get { return NativePointer->ImageExtent; }
            set { NativePointer->ImageExtent = value; }
        }
        
        public DisplaySurfaceCreateInfoKHR()
        {
            NativePointer = (Unmanaged.DisplaySurfaceCreateInfoKHR*)MemUtil.Alloc(typeof(Unmanaged.DisplaySurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.DisplaySurfaceCreateInfoKHR;
        }
        
        /// <param name="DisplayMode">The mode to use when displaying this surface</param>
        /// <param name="PlaneIndex">The plane on which this surface appears. Must be between 0 and the value returned by vkGetPhysicalDeviceDisplayPlanePropertiesKHR() in pPropertyCount.</param>
        /// <param name="PlaneStackIndex">The z-order of the plane.</param>
        /// <param name="Transform">Transform to apply to the images as part of the scannout operation</param>
        /// <param name="GlobalAlpha">Global alpha value. Must be between 0 and 1, inclusive. Ignored if alphaMode is not VK_DISPLAY_PLANE_ALPHA_GLOBAL_BIT_KHR</param>
        /// <param name="AlphaMode">What type of alpha blending to use. Must be a bit from vkGetDisplayPlanePropertiesKHR::supportedAlpha.</param>
        /// <param name="ImageExtent">Size of the images to use with this surface</param>
        public DisplaySurfaceCreateInfoKHR(DisplayModeKHR DisplayMode, UInt32 PlaneIndex, UInt32 PlaneStackIndex, SurfaceTransformFlagsKHR Transform, Single GlobalAlpha, DisplayPlaneAlphaFlagsKHR AlphaMode, Extent2D ImageExtent) : this()
        {
            this.DisplayMode = DisplayMode;
            this.PlaneIndex = PlaneIndex;
            this.PlaneStackIndex = PlaneStackIndex;
            this.Transform = Transform;
            this.GlobalAlpha = GlobalAlpha;
            this.AlphaMode = AlphaMode;
            this.ImageExtent = ImageExtent;
        }
        
        public void Dispose()
        {
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DisplaySurfaceCreateInfoKHR()
        {
            if(NativePointer != null)
            {
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
