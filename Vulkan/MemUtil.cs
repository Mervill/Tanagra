using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
	public unsafe static class MemUtil
    {
        /*
        ## Marshal.AllocHGlobal
        ##
        ## This method exposes the Win32 LocalAlloc function from Kernel32.dll (on Windows).
        ##
        ## When AllocHGlobal calls LocalAlloc, it passes a LMEM_FIXED flag, which causes the 
        ## allocated memory to be locked in place. Also, the allocated memory is not zero-filled.
        ## 
        ## https://msdn.microsoft.com/en-us/library/s69bkh17(v=vs.100).aspx
        */

#if DEBUG
        static readonly Dictionary<IntPtr, Int64> PointerMemory;
        public static int AllocCount => PointerMemory.Count;

        static MemUtil()
	    {
            PointerMemory = new Dictionary<IntPtr, long>();
        }
#endif

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

        internal static IntPtr Alloc(Type type)
		{
			var size = Marshal.SizeOf(type);
			var ptr = Marshal.AllocHGlobal(size);
			var bptr = (byte*)ptr;
			for(var i = 0; i < size; i++)
				bptr[i] = 0;
#if DEBUG
            //Console.WriteLine($"[SALLOC] Allocated {size} bytes for {type.Name} ({AllocCount})");
            GC.AddMemoryPressure(size);
            PointerMemory.Add(ptr, size);
#endif
            return ptr;
		}

        internal static void Free(IntPtr ptr)
        {
#if DEBUG
            //Console.WriteLine($"[SALLOC] Deallocated structure bytes ({AllocCount})");
            GC.RemoveMemoryPressure(PointerMemory[ptr]);
            PointerMemory.Remove(ptr);
#endif
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

	    /*internal static void ClearMemory(IntPtr ptr, ulong size)
	    {
            var bptr = (byte*)ptr;
            for (ulong i = 0; i < size; i++)
                bptr[i] = 0;
        }*/
	}
}
