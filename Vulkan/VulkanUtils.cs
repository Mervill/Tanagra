using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public unsafe static class VulkanUtils
    {
        public static void Copy2DArray(float[,] source, IntPtr destination, ulong destinationSizeInBytes, ulong sourceBytesToCopy)
        {
            /*fixed (float* sourcePtr = &source[0, 0])
                System.Buffer.MemoryCopy(sourcePtr, (void*)destination, destinationSizeInBytes, sourceBytesToCopy);*/
            fixed (float* sourcePtr = &source[0, 0])
            {
                byte[] data = new byte[destinationSizeInBytes];
                Marshal.Copy(new IntPtr(sourcePtr), data, 0, (int)destinationSizeInBytes);
                Marshal.Copy(data, 0, destination, (int)destinationSizeInBytes);
            }
        }
    }
}
