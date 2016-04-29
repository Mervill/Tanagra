using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PresentInfoKHR
    {
        internal Interop.PresentInfoKHR* NativePointer;
        
        public UInt32 WaitSemaphoreCount
        {
            get { return NativePointer->WaitSemaphoreCount; }
            set { NativePointer->WaitSemaphoreCount = value; }
        }
        
        Semaphore _WaitSemaphores;
        public Semaphore WaitSemaphores
        {
            get { return _WaitSemaphores; }
            set { _WaitSemaphores = value; NativePointer->WaitSemaphores = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 SwapchainCount
        {
            get { return NativePointer->SwapchainCount; }
            set { NativePointer->SwapchainCount = value; }
        }
        
        SwapchainKHR _Swapchains;
        public SwapchainKHR Swapchains
        {
            get { return _Swapchains; }
            set { _Swapchains = value; NativePointer->Swapchains = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 ImageIndices
        {
            get { return NativePointer->ImageIndices; }
            set { NativePointer->ImageIndices = value; }
        }
        
        public Result Results
        {
            get { return NativePointer->Results; }
            set { NativePointer->Results = value; }
        }
        
        public PresentInfoKHR()
        {
            NativePointer = (Interop.PresentInfoKHR*)Interop.Structure.Allocate(typeof(Interop.PresentInfoKHR));
            NativePointer->SType = StructureType.PresentInfoKHR;
        }
    }
}
