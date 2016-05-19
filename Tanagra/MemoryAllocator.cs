using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class MemoryAllocator
    {
        //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate IntPtr AllocationFunctionDelegate(IntPtr userData, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope);

        //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate void FreeFunctionDelegate(IntPtr userData, IntPtr memory);

        //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate IntPtr ReallocationFunctionDelegate(IntPtr userData, IntPtr original, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope);

        //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate void InternalAllocationNotificationDelegate(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);

        //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate void InternalFreeNotificationDelegate(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);
        
        public AllocationCallbacks AllocationCallbacks { get; set; }
        public int CallCount => pointers.Count;

        HashSet<IntPtr> pointers;

        AllocationFunctionDelegate _allocationFunction;
        FreeFunctionDelegate _freeFunction;
        ReallocationFunctionDelegate _reallocationFunction;

        Dictionary<IntPtr, Int64> pointerMemory;
        public Int64 TrackedBytes { get; private set; }

        public MemoryAllocator()
        {
            pointers = new HashSet<IntPtr>();

            _allocationFunction   = AllocationFunction;
            _freeFunction         = FreeFunction;
            _reallocationFunction = ReallocationFunction;

            pointerMemory = new Dictionary<IntPtr, long>();

            AllocationCallbacks = new AllocationCallbacks 
            {
                Allocation   = Marshal.GetFunctionPointerForDelegate(_allocationFunction),
                Free         = Marshal.GetFunctionPointerForDelegate(_freeFunction),
                Reallocation = Marshal.GetFunctionPointerForDelegate(_reallocationFunction),
            };
        }

        IntPtr AllocationFunction(IntPtr userData, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope)
        {
            var rawptr = Marshal.AllocHGlobal((int)(size + 8));
            var longAlignment = (Int64)alignment;
            var aligned = new IntPtr(longAlignment * (((long)rawptr + (longAlignment - 1)) / longAlignment));
            pointers.Add(aligned);
            pointerMemory.Add(aligned, (long)rawptr);
            GC.AddMemoryPressure((long)rawptr);
            TrackedBytes += (long)rawptr;
            Console.WriteLine($"[MALLOC] {allocationScope} {size} ({CallCount})");
            return aligned;
        }

        void FreeFunction(IntPtr userData, IntPtr memory)
        {
            Console.WriteLine($"[MALLOC] Freed pointer {memory.ToString("X8")}");
            if(!pointers.Remove(memory)) throw new InvalidOperationException();
            Marshal.FreeHGlobal(memory);
            TrackedBytes -= pointerMemory[memory];
            GC.RemoveMemoryPressure(pointerMemory[memory]);
            pointerMemory.Remove(memory);
        }

        IntPtr ReallocationFunction(IntPtr userData, IntPtr original, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope)
        {
            return IntPtr.Zero;
        }

        void InternalAllocationNotification(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope)
        {
            Console.WriteLine($"{userData}, {size}, {allocationType}, {allocationScope}");
        }

        void InternalFreeNotification(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope)
        {
            Console.WriteLine($"{userData}, {size}, {allocationType}, {allocationScope}");
        }
    }
}
