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
            NativePointer = (Unmanaged.DisplayModeCreateInfoKHR*)MemUtil.Alloc(typeof(Unmanaged.DisplayModeCreateInfoKHR));
            NativePointer->SType = StructureType.DisplayModeCreateInfoKHR;
        }
        
        public DisplayModeCreateInfoKHR(DisplayModeParametersKHR Parameters) : this()
        {
            this.Parameters = Parameters;
        }
        
        public void Dispose()
        {
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DisplayModeCreateInfoKHR()
        {
            if(NativePointer != null)
            {
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
