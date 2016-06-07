using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DisplayModePropertiesKHR : IDisposable
    {
        internal Unmanaged.DisplayModePropertiesKHR* NativePointer;
        
        DisplayModeKHR _DisplayMode;
        /// <summary>
        /// Handle of this display mode.
        /// </summary>
        public DisplayModeKHR DisplayMode
        {
            get { return _DisplayMode; }
            set { _DisplayMode = value; NativePointer->DisplayMode = value.NativePointer; }
        }
        
        /// <summary>
        /// The parameters this mode uses.
        /// </summary>
        public DisplayModeParametersKHR Parameters
        {
            get { return NativePointer->Parameters; }
            set { NativePointer->Parameters = value; }
        }
        
        public DisplayModePropertiesKHR()
        {
            NativePointer = (Unmanaged.DisplayModePropertiesKHR*)MemUtil.Alloc(typeof(Unmanaged.DisplayModePropertiesKHR));
        }
        
        /// <param name="DisplayMode">Handle of this display mode.</param>
        /// <param name="Parameters">The parameters this mode uses.</param>
        public DisplayModePropertiesKHR(DisplayModeKHR DisplayMode, DisplayModeParametersKHR Parameters) : this()
        {
            this.DisplayMode = DisplayMode;
            this.Parameters = Parameters;
        }
        
        public void Dispose()
        {
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DisplayModePropertiesKHR()
        {
            if(NativePointer != null)
            {
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
