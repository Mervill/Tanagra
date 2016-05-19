using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPlanePropertiesKHR
    {
        internal Unmanaged.DisplayPlanePropertiesKHR* NativePointer;
        
        DisplayKHR _CurrentDisplay;
        /// <summary>
        /// Display the plane is currently associated with. Will be VK_NULL_HANDLE if the plane is not in use.
        /// </summary>
        public DisplayKHR CurrentDisplay
        {
            get { return _CurrentDisplay; }
            set { _CurrentDisplay = value; NativePointer->CurrentDisplay = value.NativePointer; }
        }
        
        /// <summary>
        /// Current z-order of the plane.
        /// </summary>
        public UInt32 CurrentStackIndex
        {
            get { return NativePointer->CurrentStackIndex; }
            set { NativePointer->CurrentStackIndex = value; }
        }
        
        public DisplayPlanePropertiesKHR()
        {
            NativePointer = (Unmanaged.DisplayPlanePropertiesKHR*)MemoryUtils.Allocate(typeof(Unmanaged.DisplayPlanePropertiesKHR));
        }
        
        public DisplayPlanePropertiesKHR(DisplayKHR CurrentDisplay, UInt32 CurrentStackIndex) : this()
        {
            this.CurrentDisplay = CurrentDisplay;
            this.CurrentStackIndex = CurrentStackIndex;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.DisplayPlanePropertiesKHR*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}