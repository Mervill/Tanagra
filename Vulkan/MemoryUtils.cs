using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
	public unsafe static class MemoryUtils
	{
        public static int AllocCount { get; private set; }

        static Dictionary<IntPtr, Int64> pointerMemory;

	    static MemoryUtils()
	    {
            pointerMemory = new Dictionary<IntPtr, long>();
        }

        public static void Copy2DArray(float[,] source, IntPtr destination, ulong destinationSizeInBytes, ulong sourceBytesToCopy)
        {
            fixed (float* sourcePtr = &source[0, 0])
                System.Buffer.MemoryCopy(sourcePtr, (void*)destination, destinationSizeInBytes, sourceBytesToCopy);
        }

        internal static IntPtr Allocate(Type type)
		{
			var size = Marshal.SizeOf(type);
			var ptr = Marshal.AllocHGlobal(size);
			var bptr = (byte*)ptr;
			for(var i = 0; i < size; i++)
				bptr[i] = 0;
            
            AllocCount++;
            //Console.WriteLine($"[SALLOC] Allocated {size} bytes for {type.Name} ({AllocCount})");
            pointerMemory.Add(ptr, size);
            GC.AddMemoryPressure(size);
            return ptr;
		}

        internal static void Free(IntPtr ptr)
        {
            AllocCount--;
            //Console.WriteLine($"[SALLOC] Deallocated structure bytes ({AllocCount})");
            GC.RemoveMemoryPressure(pointerMemory[ptr]);
            pointerMemory.Remove(ptr);
            Marshal.FreeHGlobal(ptr);
        }

		internal static void MarshalFixedSizeString(byte* dst, string src, int size)
		{
			var bytes = System.Text.Encoding.UTF8.GetBytes(src);
			size = Math.Min(size - 1, bytes.Length);
			int i;
			for(i = 0; i < size; i++)
				dst[i] = bytes[i];
			dst[i] = 0;
		}
	}
}
