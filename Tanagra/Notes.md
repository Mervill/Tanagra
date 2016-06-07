todo: realloc is broken
todo: unions
todo: merge flag enums
todo: CodeSize preventing x64 from working
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