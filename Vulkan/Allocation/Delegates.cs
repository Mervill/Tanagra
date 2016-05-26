using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulkan.Allocation
{
    //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate IntPtr AllocationDelegate(IntPtr userData, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope);

    //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate void FreeDelegate(IntPtr userData, IntPtr memory);

    //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate IntPtr ReallocationDelegate(IntPtr userData, IntPtr original, IntPtr size, IntPtr alignment, SystemAllocationScope allocationScope);

    //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate void InternalAllocationNotificationDelegate(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);

    //[UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public unsafe delegate void InternalFreeNotificationDelegate(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);

}
