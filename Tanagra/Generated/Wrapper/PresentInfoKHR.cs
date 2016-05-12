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
        
        public Semaphore[] WaitSemaphores
        {
            get
            {
                var valueCount = NativePointer->WaitSemaphoreCount;
                var valueArray = new Semaphore[valueCount];
                var ptr = (UInt64*)NativePointer->WaitSemaphores;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new Semaphore { NativePointer = ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->WaitSemaphoreCount = (uint)valueCount;
                NativePointer->WaitSemaphores = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->WaitSemaphores;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
        }
        
        public UInt32 SwapchainCount
        {
            get { return NativePointer->SwapchainCount; }
            set { NativePointer->SwapchainCount = value; }
        }
        
        public SwapchainKHR[] Swapchains
        {
            get
            {
                var valueCount = NativePointer->SwapchainCount;
                var valueArray = new SwapchainKHR[valueCount];
                var ptr = (UInt64*)NativePointer->Swapchains;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SwapchainKHR { NativePointer = ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->SwapchainCount = (uint)valueCount;
                NativePointer->Swapchains = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->Swapchains;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
        }
        
        public UInt32[] ImageIndices
        {
            get
            {
                var valueCount = NativePointer->SwapchainCount;
                var valueArray = new UInt32[valueCount];
                var ptr = (UInt32*)NativePointer->ImageIndices;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->SwapchainCount = (uint)valueCount;
                NativePointer->ImageIndices = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * valueCount);
                var ptr = (UInt32*)NativePointer->ImageIndices;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public Result[] Results
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->SwapchainCount = (uint)valueCount;
                NativePointer->Results = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * valueCount);
                var ptr = (UInt32*)NativePointer->Results;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (UInt32)value[x];
            }
        }
        
        public PresentInfoKHR()
        {
            NativePointer = (Interop.PresentInfoKHR*)Interop.Structure.Allocate(typeof(Interop.PresentInfoKHR));
            NativePointer->SType = StructureType.PresentInfoKHR;
        }
    }
}
