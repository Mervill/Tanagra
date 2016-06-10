
# Tanagra

Tanagra is a binding generator and (eventually) support library for Vulkan.

The generator produces a compiling library that should render the triangle example correctly (at least on a windows machine)

The example project contains (eventually) C#'ified versions of [Sascha Willems fantastic C example project](https://github.com/SaschaWillems/Vulkan). Be sure to check it out.

The example project has SharpDX as a dependency, this is just to gain access to a well-defined rending window that is then passed to Vulkan. No DirectX is involved

If you're looking for the LUNARG validation layer (`VK_LAYER_LUNARG_standard_validation`) you can downloaded it from lunarG [here](https://lunarg.com/vulkan-sdk/)

Approximately %40 of all commands have been tested

## How To Play

### Tanagra

Coming soon!

### Managed

```C#
using Vulkan;                     // Core Vulkan classes
using Vulkan.Managed;             // Interface to unmanaged interop
using Vulkan.Managed.ObjectModel; // Extensions to vulkan handle objects

// Create a Vulkan instance
var instanceCreateInfo = new InstanceCreateInfo();
Instance vulkanInstance = Vk.CreateInstance(instanceCreateInfo);

// Enumerate Physical Devices
var physicalDevices = instance.EnumeratePhysicalDevices();

// Create a Vulkan device
var deviceCreateInfo = new DeviceCreateInfo(...);
Device vulkanDevice = physicalDevices[0].CreateDevice(deviceCreateInfo);
```

### Unmanaged

The managed layer is reccomended in almost all cases. If you'd rather work with the interop layer directly (if you want total control over memory, for example) you can do that as well. You will need to compile with `unsafe` in order to work with memory directly.

```C#
using Vulkan;           // Core Vulkan classes
using Vulkan.Unmanaged; // Unmanaged structs and callbacks

// The vulkan functions are in the `VulkanBinding` class. It's designed to be used
// with C# 6.0's 'using static' feature to replicate the vulkan C api.
using static Unmanaged.VulkanBinding;

/* Allocate pointers to objects */

// `vkCreateInstance` is a member of `VulkanBinding`. We can call it like this
// because of the 'using static' statement above.
var result = vkCreateInstance(...)
if(result != Result.Success)
	throw new VulkanCommandException(nameof(vkCreateInstance), result);

// Commands that return an array use the C 'call twice' convention:

// First call determines the length of the array to be retrieved
UInt32 listLength;
vkEnumeratePhysicalDevices(instancePtr, &listLength, null);

// Second call actually retrives the array
var arrayPhysicalDevice = new IntPtr[listLength];
fixed(IntPtr* resultPtr = &arrayPhysicalDevice[0])
	vkEnumeratePhysicalDevices(instancePtr, &listLength, resultPtr);

vkCreateDevice(...);
```

## Project Directory

```
./Vulkan/            - Generated Vulkan API as a standalone DLL
./Tanagra.Generator/ - Generates the Vulkan API from vk.xml
./Tanagra/           - Extended managed support for Vulkan
./TanagraExample/    - Example code
```

## License
```
Boost Software License - Version 1.0 - August 17th, 2003

Permission is hereby granted, free of charge, to any person or organization
obtaining a copy of the software and accompanying documentation covered by
this license (the "Software") to use, reproduce, display, distribute,
execute, and transmit the Software, and to prepare derivative works of the
Software, and to permit third-parties to whom the Software is furnished to
do so, all subject to the following:

The copyright notices in the Software and this entire statement, including
the above license grant, this restriction and the following disclaimer,
must be included in all copies of the Software, in whole or in part, and
all derivative works of the Software, unless such copies or derivative
works are solely in the form of machine-executable object code generated by
a source language processor.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE, TITLE AND NON-INFRINGEMENT. IN NO EVENT
SHALL THE COPYRIGHT HOLDERS OR ANYONE DISTRIBUTING THE SOFTWARE BE LIABLE
FOR ANY DAMAGES OR OTHER LIABILITY, WHETHER IN CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
```

> You hoped that something like this would happen, didn't you? You knew there was a dangerous creature on this planet, and you knew from the tale of Darmok that a danger shared might sometimes bring two people together. Darmok and Jalad at Tanagra. You and me, here, at El-Adrel.
