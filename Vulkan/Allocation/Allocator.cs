using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan.Allocation
{
    using Managed;

    public class Allocator : IAllocator//, IAllocatorNotification
    {
        AllocationDelegate _allocationFunction;
        FreeDelegate _freeFunction;
        ReallocationDelegate _reallocationFunction;

        HashSet<IntPtr> pointers;
        Dictionary<IntPtr, Int64> pointerMemory;

        public AllocationCallbacks AllocationCallbacks { get; set; }
        public int Count => pointers.Count;
        public Int64 TrackedBytes { get; private set; }
        public bool DebugLog { get; set; }

        public Allocator()
        {
            pointers = new HashSet<IntPtr>();
            pointerMemory = new Dictionary<IntPtr, long>();

            _allocationFunction = Allocation;
            _freeFunction = Free;
            _reallocationFunction = Reallocation;

            AllocationCallbacks = new AllocationCallbacks
            {
                Allocation = Marshal.GetFunctionPointerForDelegate(_allocationFunction),
                Free = Marshal.GetFunctionPointerForDelegate(_freeFunction),
                Reallocation = Marshal.GetFunctionPointerForDelegate(_reallocationFunction),
            };
        }

        public virtual IntPtr Allocation(IntPtr userData, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope)
        {
            var rawptr = Marshal.AllocHGlobal((int)(size + 8));
            var longAlignment = (Int64)alignment;
            var aligned = new IntPtr(longAlignment * (((long)rawptr + (longAlignment - 1)) / longAlignment));
            pointers.Add(aligned);
            pointerMemory.Add(aligned, (long)size);
            GC.AddMemoryPressure((long)size);
            TrackedBytes += (long)size;
            if(DebugLog) Console.WriteLine($"[MALLOC] Allocated {size,4} bytes [SystemAllocationScope.{allocationScope}] ({Count})");
            return aligned;
        }

        public virtual void Free(IntPtr userData, IntPtr memory)
        {
            if(!pointers.Remove(memory)) throw new InvalidOperationException();
            Marshal.FreeHGlobal(memory);
            if(DebugLog) Console.WriteLine($"[MALLOC] Freed {pointerMemory[memory],4} bytes ({memory.ToString("X8")})");
            TrackedBytes -= pointerMemory[memory];
            GC.RemoveMemoryPressure(pointerMemory[memory]);
            pointerMemory.Remove(memory);
        }

        public virtual IntPtr Reallocation(IntPtr userData, IntPtr original, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope)
        {
            throw new NotImplementedException();
        }

        /*public void InternalAllocationNotification(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope)
        {
            throw new NotImplementedException();
        }

        public void InternalFreeNotification(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope)
        {
            throw new NotImplementedException();
        }*/
    }
}
