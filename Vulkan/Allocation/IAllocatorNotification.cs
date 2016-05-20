using System;

namespace Vulkan.Allocation
{
    /// <summary>
    /// Can be used to receive memory allocation/free notifications from Vulkan
    /// </summary>
    public interface IAllocatorNotification
    {
        /// <summary>
        /// Called when Vulkan has allocated memory. This is a purely informational callback
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="size"></param>
        /// <param name="allocationType"></param>
        /// <param name="allocationScope"></param>
        void InternalAllocationNotification(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);

        /// <summary>
        /// Called when Vulkan has freed memory. This is a purely informational callback
        /// </summary>
        /// <param name="userData"></param>
        /// <param name="size"></param>
        /// <param name="allocationType"></param>
        /// <param name="allocationScope"></param>
        void InternalFreeNotification(IntPtr userData, IntPtr size, InternalAllocationType allocationType, SystemAllocationScope allocationScope);
    }
}
