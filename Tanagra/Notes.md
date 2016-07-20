todo: GetQueryPoolResults is not generated correctly
todo: Bug that occurs when 2 member arrays share the same count member, but one is set to null
todo: unions
todo: merge flag enums
todo: Managed classes still leak memory in some cases
todo: PipelineMultisampleStateCreateInfo.SampleMask

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

Command Recording
---

- individual command buffers allocated from the pool can be reset either explicitly, by calling vkResetCommandBuffer, or implicitly, by calling vkBeginCommandBuffer on an executable command buffer. (spec/5.1)

stackalloc
Here's what stackalloc looks like decompiled:

```
sizeof {objType}
mul.ovf.un
localloc
stloc.X // where X is the index of the local variable
```


"vulkan-1.dll";
"libvulkan.so.1"
"vulkan.so"

Winapi || StdCall ?

XlibSurfaceCreateInfoKHR
IntPtr Dpy    = (Display *dpy = XOpenDisplay(NIL);)
IntPtr Window = (Window w = XCreateSimpleWindow(dpy, DefaultRootWindow(dpy), 0, 0, 200, 100, 0, blackColor, blackColor);)

https://tronche.com/gui/x/xlib-tutorial/2nd-program-anatomy.html
https://www.opengl.org/wiki/Programming_OpenGL_in_Linux:_GLX_and_Xlib

How to present in the absense of a window system:
VK_KHR_display
VK_KHR_display_swapchain
https://devtalk.nvidia.com/default/topic/925605/linux/nvidia-364-12-release-vulkan-glvnd-drm-kms-and-eglstreams/