using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PresentInfoKHR : IDisposable
    {
        internal Unmanaged.PresentInfoKHR* NativePointer;
        
        /// <summary>
        /// Semaphores to wait for before presenting (Optional)
        /// </summary>
        public Semaphore[] WaitSemaphores
        {
            get
            {
                if(NativePointer->WaitSemaphores == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->WaitSemaphoreCount;
                var valueArray = new Semaphore[valueCount];
                var ptr = (UInt64*)NativePointer->WaitSemaphores;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new Semaphore { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(IntPtr)) * valueCount;
                    if(NativePointer->WaitSemaphores != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->WaitSemaphores, (IntPtr)typeSize);
                    
                    if(NativePointer->WaitSemaphores == IntPtr.Zero)
                        NativePointer->WaitSemaphores = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->WaitSemaphoreCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->WaitSemaphores;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->WaitSemaphores != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->WaitSemaphores);
                    
                    NativePointer->WaitSemaphores = IntPtr.Zero;
                    NativePointer->WaitSemaphoreCount = 0;
                }
            }
        }
        
        /// <summary>
        /// Swapchains to present an image from
        /// </summary>
        public SwapchainKHR[] Swapchains
        {
            get
            {
                if(NativePointer->Swapchains == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->SwapchainCount;
                var valueArray = new SwapchainKHR[valueCount];
                var ptr = (UInt64*)NativePointer->Swapchains;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SwapchainKHR { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(IntPtr)) * valueCount;
                    if(NativePointer->Swapchains != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Swapchains, (IntPtr)typeSize);
                    
                    if(NativePointer->Swapchains == IntPtr.Zero)
                        NativePointer->Swapchains = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->SwapchainCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->Swapchains;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->Swapchains != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Swapchains);
                    
                    NativePointer->Swapchains = IntPtr.Zero;
                    NativePointer->SwapchainCount = 0;
                }
            }
        }
        
        /// <summary>
        /// Indices of which swapchain images to present
        /// </summary>
        public UInt32[] ImageIndices
        {
            get
            {
                if(NativePointer->ImageIndices == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->SwapchainCount;
                var valueArray = new UInt32[valueCount];
                var ptr = (UInt32*)NativePointer->ImageIndices;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt32)) * valueCount;
                    if(NativePointer->ImageIndices != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ImageIndices, (IntPtr)typeSize);
                    
                    if(NativePointer->ImageIndices == IntPtr.Zero)
                        NativePointer->ImageIndices = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->SwapchainCount = (UInt32)valueCount;
                    var ptr = (UInt32*)NativePointer->ImageIndices;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->ImageIndices != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->ImageIndices);
                    
                    NativePointer->ImageIndices = IntPtr.Zero;
                    NativePointer->SwapchainCount = 0;
                }
            }
        }
        
        /// <summary>
        /// Optional (i.e. if non-NULL) VkResult for each swapchain (Optional)
        /// </summary>
        public Result[] Results
        {
            get
            {
                if(NativePointer->Results == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->SwapchainCount;
                var valueArray = new Result[valueCount];
                var ptr = (UInt32*)NativePointer->Results;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = (Result)ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt32)) * valueCount;
                    if(NativePointer->Results != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Results, (IntPtr)typeSize);
                    
                    if(NativePointer->Results == IntPtr.Zero)
                        NativePointer->Results = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->SwapchainCount = (UInt32)valueCount;
                    var ptr = (UInt32*)NativePointer->Results;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (UInt32)value[x];
                }
                else
                {
                    if(NativePointer->Results != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Results);
                    
                    NativePointer->Results = IntPtr.Zero;
                    NativePointer->SwapchainCount = 0;
                }
            }
        }
        
        public PresentInfoKHR()
        {
            NativePointer = (Unmanaged.PresentInfoKHR*)MemoryUtils.Allocate(typeof(Unmanaged.PresentInfoKHR));
            NativePointer->SType = StructureType.PresentInfoKHR;
        }
        
        public PresentInfoKHR(SwapchainKHR[] Swapchains, UInt32[] ImageIndices) : this()
        {
            this.Swapchains = Swapchains;
            this.ImageIndices = ImageIndices;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->WaitSemaphores);
            Marshal.FreeHGlobal(NativePointer->Swapchains);
            Marshal.FreeHGlobal(NativePointer->ImageIndices);
            Marshal.FreeHGlobal(NativePointer->Results);
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PresentInfoKHR()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->WaitSemaphores);
                Marshal.FreeHGlobal(NativePointer->Swapchains);
                Marshal.FreeHGlobal(NativePointer->ImageIndices);
                Marshal.FreeHGlobal(NativePointer->Results);
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
