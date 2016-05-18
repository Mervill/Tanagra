using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class MemoryAllocator
    {
        //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate IntPtr AllocationFunctionDelegate(IntPtr userData, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope);

        //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate void FreeFunctionDelegate(IntPtr userData, IntPtr memory);

        //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate IntPtr ReallocationFunctionDelegate(IntPtr userData, IntPtr original, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate void InternalAllocationNotificationDelegate(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate void InternalFreeNotificationDelegate(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);
        
        public AllocationCallbacks AllocationCallbacks { get; set; }
        public int CallCount => pointers.Count;

        HashSet<IntPtr> pointers;

        AllocationFunctionDelegate _allocationFunction;
        FreeFunctionDelegate _freeFunction;
        ReallocationFunctionDelegate _reallocationFunction;

        public MemoryAllocator()
        {
            pointers = new HashSet<IntPtr>();

            _allocationFunction   = new AllocationFunctionDelegate(AllocationFunction);
            _freeFunction         = new FreeFunctionDelegate(FreeFunction);
            _reallocationFunction = new ReallocationFunctionDelegate(ReallocationFunction);

            AllocationCallbacks = new AllocationCallbacks 
            {
                Allocation   = Marshal.GetFunctionPointerForDelegate(_allocationFunction),
                Free         = Marshal.GetFunctionPointerForDelegate(_freeFunction),
                Reallocation = Marshal.GetFunctionPointerForDelegate(_reallocationFunction),
            };
        }

        IntPtr AllocationFunction(IntPtr userData, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope)
        {
            var rawptr = Marshal.AllocHGlobal((int)(size + 8));
            var aligned = new IntPtr(alignment * (((long)rawptr + (alignment - 1)) / alignment));
            pointers.Add(aligned);
            Console.WriteLine($"[MALLOC] {allocationScope} {size} ({CallCount})");
            return aligned;
        }

        void FreeFunction(IntPtr userData, IntPtr memory)
        {
            Console.WriteLine($"[MALLOC] Freed pointer {memory.ToString("X8")}");
            if(!pointers.Remove(memory)) throw new InvalidOperationException();
            Marshal.FreeHGlobal(memory);
        }

        IntPtr ReallocationFunction(IntPtr userData, IntPtr original, UInt32 size, UInt32 alignment, SystemAllocationScope allocationScope)
        {
            return IntPtr.Zero;
        }

        void InternalAllocationNotification(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope)
        {
            Console.WriteLine($"{userData}, {size}, {allocationType}, {allocationScope}");
        }

        void InternalFreeNotification(IntPtr userData, UInt32 size, InternalAllocationType allocationType, SystemAllocationScope allocationScope)
        {
            Console.WriteLine($"{userData}, {size}, {allocationType}, {allocationScope}");
        }
    }
}
