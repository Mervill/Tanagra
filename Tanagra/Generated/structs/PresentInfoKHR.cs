using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PresentInfoKHR
    {
        internal Interop.PresentInfoKHR* NativeHandle;
        
        public UInt32 WaitSemaphoreCount
        {
            get { return NativeHandle->WaitSemaphoreCount; }
            set { NativeHandle->WaitSemaphoreCount = value; }
        }
        
        Semaphore _WaitSemaphores;
        public Semaphore WaitSemaphores
        {
            get { return _WaitSemaphores; }
            set { _WaitSemaphores = value; NativeHandle->WaitSemaphores = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 SwapchainCount
        {
            get { return NativeHandle->SwapchainCount; }
            set { NativeHandle->SwapchainCount = value; }
        }
        
        SwapchainKHR _Swapchains;
        public SwapchainKHR Swapchains
        {
            get { return _Swapchains; }
            set { _Swapchains = value; NativeHandle->Swapchains = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 ImageIndices
        {
            get { return NativeHandle->ImageIndices; }
            set { NativeHandle->ImageIndices = value; }
        }
        
        public Result Results
        {
            get { return NativeHandle->Results; }
            set { NativeHandle->Results = value; }
        }
        
        public PresentInfoKHR()
        {
            NativeHandle = (Interop.PresentInfoKHR*)Interop.Structure.Allocate(typeof(Interop.PresentInfoKHR));
            //NativeHandle->SType = StructureType.PresentInfoKHR;
        }
    }
}
