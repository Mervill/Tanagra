using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DisplayModeCreateInfoKHR : IDisposable
    {
        internal Unmanaged.DisplayModeCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DisplayModeCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// The parameters this mode uses.
        /// </summary>
        public DisplayModeParametersKHR Parameters
        {
            get { return NativePointer->Parameters; }
            set { NativePointer->Parameters = value; }
        }
        
        public DisplayModeCreateInfoKHR()
        {
            NativePointer = (Unmanaged.DisplayModeCreateInfoKHR*)MemoryUtils.Allocate(typeof(Unmanaged.DisplayModeCreateInfoKHR));
            NativePointer->SType = StructureType.DisplayModeCreateInfoKHR;
        }
        
        public DisplayModeCreateInfoKHR(DisplayModeParametersKHR Parameters) : this()
        {
            this.Parameters = Parameters;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.DisplayModeCreateInfoKHR*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~DisplayModeCreateInfoKHR()
        {
            if(NativePointer != (Unmanaged.DisplayModeCreateInfoKHR*)IntPtr.Zero)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.DisplayModeCreateInfoKHR*)IntPtr.Zero;
            }
        }
    }
}
