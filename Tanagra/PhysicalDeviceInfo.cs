using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

namespace Tanagra
{
    /// <summary>
    /// Stores information about a <see cref="Vulkan.PhysicalDevice"/>
    /// </summary>
    public class PhysicalDeviceInfo
    {
        public readonly PhysicalDevice PhysicalDevice;

        PhysicalDeviceProperties Properties;
        //PhysicalDeviceLimits physicalDeviceLimits;
        //PhysicalDeviceSparseProperties SparseProperties;
        QueueFamilyProperties[] QueueFamilyProperties;
        PhysicalDeviceMemoryProperties MemoryProperties;
        public PhysicalDeviceFeatures Features { get; private set; }

        //public int[] GraphicsQueues => QueuesWithFlag(QueueFlags.Graphics);
        //public int[] ComputeQueues => QueuesWithFlag(QueueFlags.Compute);
        //public int[] TransferQueues => QueuesWithFlag(QueueFlags.Transfer);
        //public int[] SparseBindingQueues => QueuesWithFlag(QueueFlags.SparseBinding);

        // QueueFamilyProperties
        //     QueueFlags
        //     QueueCount
        //     TimestampValidBits
        //     MinImageTransferGranularity

        /// <summary>
        /// Queue families in this <see cref="Vulkan.PhysicalDevice"/> that support <see cref="QueueFlags.Graphics"/>
        /// </summary>
        public readonly ReadOnlyCollection<int> GraphicsQFamilies;

        /// <summary>
        /// Queue families in this <see cref="Vulkan.PhysicalDevice"/> that support <see cref="QueueFlags.Compute"/>
        /// </summary>
        public readonly ReadOnlyCollection<int> ComputeQFamilies;

        /// <summary>
        /// Queue families in this <see cref="Vulkan.PhysicalDevice"/> that support <see cref="QueueFlags.Transfer"/>
        /// </summary>
        public readonly ReadOnlyCollection<int> TransferQFamilies;

        /// <summary>
        /// Queue families in this <see cref="Vulkan.PhysicalDevice"/> that support <see cref="QueueFlags.SparseBinding"/>
        /// </summary>
        public readonly ReadOnlyCollection<int> SparseBindingQFamilies;

        public PhysicalDeviceInfo(PhysicalDevice physicalDevice)
        {
            PhysicalDevice = physicalDevice;
            Properties = PhysicalDevice.GetProperties();
            QueueFamilyProperties = PhysicalDevice.GetQueueFamilyProperties();
            MemoryProperties = PhysicalDevice.GetMemoryProperties();
            Features = PhysicalDevice.GetFeatures();

            GraphicsQFamilies = Array.AsReadOnly(QueueFamiliesWithFlag(QueueFlags.Graphics));
            ComputeQFamilies = Array.AsReadOnly(QueueFamiliesWithFlag(QueueFlags.Compute));
            TransferQFamilies = Array.AsReadOnly(QueueFamiliesWithFlag(QueueFlags.Transfer));
            SparseBindingQFamilies = Array.AsReadOnly(QueueFamiliesWithFlag(QueueFlags.SparseBinding));
        }

        public int[] QueueFamiliesWithFlag(QueueFlags flag)
        {
            return QueueFamilyProperties
                .Where(x => x.QueueFlags.HasFlag(flag))
                .Select((x, i) => i)
                .ToArray();
        }

        public uint QueuesInFamily(int index)
        {
            return QueueFamilyProperties[index].QueueCount;
        }

    }
}
