using System;

namespace Vulkan
{
    public enum Result
    {
        /// <summary>
        /// Command completed successfully
        /// </summary>
        SUCCESS = 0,
        /// <summary>
        /// A fence or query has not yet completed
        /// </summary>
        NOT_READY = 1,
        /// <summary>
        /// A wait operation has not completed in the specified time
        /// </summary>
        TIMEOUT = 2,
        /// <summary>
        /// An event is signaled
        /// </summary>
        EVENT_SET = 3,
        /// <summary>
        /// An event is unsignalled
        /// </summary>
        EVENT_RESET = 4,
        /// <summary>
        /// A return array was too small for the resul
        /// </summary>
        INCOMPLETE = 5,
        /// <summary>
        /// A host memory allocation has failed
        /// </summary>
        ERROR_OUT_OF_HOST_MEMORY = -1,
        /// <summary>
        /// A device memory allocation has failed
        /// </summary>
        ERROR_OUT_OF_DEVICE_MEMORY = -2,
        /// <summary>
        /// The logical device has been lost. See <<devsandqueues-lost-device>>
        /// </summary>
        ERROR_INITIALIZATION_FAILED = -3,
        /// <summary>
        /// Initialization of a object has failed
        /// </summary>
        ERROR_DEVICE_LOST = -4,
        /// <summary>
        /// Mapping of a memory object has failed
        /// </summary>
        ERROR_MEMORY_MAP_FAILED = -5,
        /// <summary>
        /// Layer specified does not exist
        /// </summary>
        ERROR_LAYER_NOT_PRESENT = -6,
        /// <summary>
        /// Extension specified does not exist
        /// </summary>
        ERROR_EXTENSION_NOT_PRESENT = -7,
        /// <summary>
        /// Requested feature is not available on this device
        /// </summary>
        ERROR_FEATURE_NOT_PRESENT = -8,
        /// <summary>
        /// Unable to find a Vulkan driver
        /// </summary>
        ERROR_INCOMPATIBLE_DRIVER = -9,
        /// <summary>
        /// Too many objects of the type have already been created
        /// </summary>
        ERROR_TOO_MANY_OBJECTS = -10,
        /// <summary>
        /// Requested format is not supported on this device
        /// </summary>
        ERROR_FORMAT_NOT_SUPPORTED = -11,
    }
}
