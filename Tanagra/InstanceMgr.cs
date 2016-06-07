using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

namespace Tanagra
{
    public class InstanceMgr
    {
        public class InitializeOptions
        {
            public class QueueAlloc
            {
                public QueueFlags Type;
                public float Priority;
            }

            List<QueueAlloc> QueueAllocations;

            public void AddQueue(QueueFlags type, float priority = default(float))
            {
                QueueAllocations.Add(new QueueAlloc { Type = type, Priority = priority });
            }

            public void AddQueues(QueueFlags type, int count)
            {
                for(int x = 0; x < count; x++)
                    AddQueue(type, 0.0f);
            }

            public void AddQueues(QueueFlags type, params float[] priorities)
            {
                for(int x = 0; x < priorities.Length; x++)
                    AddQueue(type, priorities[x]);
            }

        }

        public class PhysicalDeviceMeta
        {
            public Dictionary<int, int> UnallocatedQueues;
        }

        InitializeOptions options;

        Instance instance;

        PhysicalDevice[] physicalDevices;
        PhysicalDeviceInfo[] physicalDeviceInfos;
        
        PhysicalDevice PhysicalDevice => physicalDevices[DeviceIndex];
        PhysicalDeviceInfo DeviceInfo => physicalDeviceInfos[DeviceIndex];
        
        Dictionary<PhysicalDevice, Device> deviceMap;

        public uint DeviceIndex { get; private set; }
        
        public InstanceMgr()
        {
            DeviceIndex = 0;
            deviceMap = new Dictionary<PhysicalDevice, Device>();
        }

        public void Initialize(InitializeOptions opt)
        {
            options = opt;
            uint    useDevice = 0;
            int     gfxQueues = 1;
            float[] gfxQueuePriorities;
            int     comQueues = 0;
            float[] comQueuePriorities;

            //

            instance = CreateInstance(null, null);

            //

            physicalDevices = EnumeratePhysicalDevices(instance).ToArray();
            physicalDeviceInfos = new PhysicalDeviceInfo[physicalDevices.Length];
            for(int x = 0; x < physicalDevices.Length; x++)
                physicalDeviceInfos[x] = new PhysicalDeviceInfo(physicalDevices[x]);

            //

            // The total number of queues to be used over the lifetime of the
            // device must be given before the device is created

            DeviceIndex = useDevice;

            if(DeviceInfo.GraphicsQFamilies.Count == 0)
                throw new InvalidOperationException("Default physical device has no graphics queue families.");

            var gfxQFamily = DeviceInfo.GraphicsQFamilies.First();

            // todo: Does the existence of a Queue family guarantee the existence of at least one queue?
            if(DeviceInfo.QueuesInFamily(gfxQFamily) == 0)
                throw new InvalidOperationException("Default graphics queue family.");
            
            var queuePriorities = new float[gfxQueues];
            var queueCreateInfo = new DeviceQueueCreateInfo((uint)gfxQFamily, queuePriorities);

            var device = CreateDevice(PhysicalDevice, queueCreateInfo);
            deviceMap.Add(PhysicalDevice, device);

            var deviceQueues = new Queue[gfxQueues];
            for(int x = 0; x < gfxQueues; x++)
                deviceQueues[x] = device.GetQueue((uint)gfxQFamily, (uint)x);

            // indicate that the queue family has some queues allocated
        }
        
        static Instance CreateInstance(string[] enabledLayerNames, string[] enabledExtensionNames, ApplicationInfo applicationInfo = default(ApplicationInfo), InstanceCreateFlags flags = default(InstanceCreateFlags))
        {
            var instanceCreateInfo = new InstanceCreateInfo(enabledLayerNames, enabledExtensionNames);
            var instance = Vk.CreateInstance(instanceCreateInfo);
            instanceCreateInfo.Dispose();
            return instance;
        }

        static PhysicalDevice[] EnumeratePhysicalDevices(Instance instance)
        {
            var physicalDevices = instance.EnumeratePhysicalDevices();

            if(physicalDevices.Length == 0)
                throw new InvalidOperationException("Didn't find any physical devices!");

            return physicalDevices;
        }
        
        static Device CreateDevice(PhysicalDevice physicalDevice, params DeviceQueueCreateInfo[] queueCreateInfos)
        {
            var createInfo = new DeviceCreateInfo(queueCreateInfos, null, null);
            var device = physicalDevice.CreateDevice(createInfo);
            createInfo.Dispose();
            return device;
        }
    }
}
