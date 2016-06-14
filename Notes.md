todo: Reallocating an array on a managed struct seems to be broken
todo: Unions! ClearValue and ClearColorValue are basically empty
todo: Merge extension flag enums
todo: CodeSize (on ShaderModuleCreateInfo) is preventing x64 from working because it should be an `IntPtr` rather then a `UInt32`
todo: Fix edge cases in VulkanConstant
todo: Managed classes still leak memory in some cases

Create overload for commands that return lists (ei: called twice) that allows you to manually provide the length?

Im not sure how I'd like to handle vendor suffixes. Most generators remove them, but the whole point of the suffix is to prevent name collision, which while unlikely is still a thing that can happen.

Calls to EnumeratePhysicalDevices invalidate previous `PhysicalDevice` objects?

There are lots of cases where a struct/command requires an array but we only provide a single object, leading to lots of unsightly `new[]{ obj }` cruft. How could this be mitigated?

Weird layout, check the spec:
VK_SAMPLER_ADDRESS_MODE_MIRROR_CLAMP_TO_EDGE
VK_STENCIL_FRONT_AND_BACK

In most destroy commands (ie DestroyFence) the handle to be destroyed is an optional param ... why?

Dispatchable handles use the platform word length so IntPtr is used to ensure that they are the correct size in structs on both platforms. Nondispatchable handles are always 64 bits in length. 

[StructLayout(LayoutKind.Sequential)]
C#, Visual Basic, and C++ compilers apply the Sequential layout value to structures by default
https://msdn.microsoft.com/en-us/library/system.runtime.interopservices.structlayoutattribute(v=vs.110).aspx

Command Recording:
- individual command buffers allocated from the pool can be reset either explicitly, by calling vkResetCommandBuffer, or implicitly, by calling vkBeginCommandBuffer on an executable command buffer. (spec/5.1)