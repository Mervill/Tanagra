using System;
using System.Runtime.InteropServices;

namespace Vulkan.Interop
{
	internal class Structure
	{
        unsafe internal static IntPtr Allocate(Type type)
		{
			var size = Marshal.SizeOf(type);
			var ptr = Marshal.AllocHGlobal(size);
			var bptr = (byte*)ptr;
			for(var i = 0; i < size; i++)
				bptr[i] = 0;

			return ptr;
		}

		unsafe internal static void MarshalFixedSizeString(byte* dst, string src, int size)
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
