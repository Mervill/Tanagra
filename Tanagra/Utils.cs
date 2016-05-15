using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanagra
{
    public unsafe static class Utils
    {
        public static void Copy2DArray(float[,] source, IntPtr destination, ulong destinationSizeInBytes, ulong sourceBytesToCopy)
        {
            fixed (float* sourcePtr = &source[0,0])
                Buffer.MemoryCopy(sourcePtr, (void*)destination, destinationSizeInBytes, sourceBytesToCopy);
        }
    }
}
