using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// IExtensible
    /// </summary>
    unsafe public class DisplayModeCreateInfoKHR : IDisposable
    {
        internal Unmanaged.DisplayModeCreateInfoKHR* NativePointer { get; private set; }
        
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
        
        internal DisplayModeCreateInfoKHR(Unmanaged.DisplayModeCreateInfoKHR* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.DisplayModeCreateInfoKHR));
        }
        
        /// <param name="Parameters">The parameters this mode uses.</param>
        public DisplayModeCreateInfoKHR(DisplayModeParametersKHR Parameters) : this()
        {
            this.Parameters = Parameters;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DisplayModeCreateInfoKHR()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
