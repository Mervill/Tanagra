
Originally this was going to be C#'ified versions of [Sascha Willems fantastic C example project](https://github.com/SaschaWillems/Vulkan). But I've decided to take a wholly C# approach to these examples.

`ExampleRenderToDisk` is the introductory example. When run it should create a file called `out.bmp` with an image of a triangle. This example uses the absolute minimum number of Vulkan features/concepts and does not rely on any other files. It should serve as a good introduction to Vulkan's core concepts.

```
/*
## Instance
## └─ PhysicalDevice
##    └─ Device
##       ├─ Buffer
##       ├─ BufferView
##       ├─ CommandPool
##       │  └─ CommandBuffer
##       ├─ DescriptorPool
##       │  └─ DescriptorSet
##       ├─ DescriptorSetLayout
##       ├─ DeviceMemory
##       ├─ Event
##       ├─ Fence
##       ├─ Framebuffer
##       ├─ Image
##       ├─ ImageView
##       ├─ Pipeline
##       ├─ PipelineCache
##       ├─ PipelineLayout
##       ├─ QueryPool
##       ├─ Queue
##       ├─ RenderPass
##       ├─ Sampler
##       ├─ Semaphore
##       └─ ShaderModule
*/
```