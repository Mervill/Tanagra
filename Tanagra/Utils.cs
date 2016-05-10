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

        public static unsafe string DumpBytes<T>(T targetStruct) where T : struct
        {
            bool displayHex = false;

            int size = Marshal.SizeOf(typeof(T));
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(targetStruct, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            var typeInfo = targetStruct.GetType();
            var fields = typeInfo
                .GetRuntimeFields()
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(typeInfo.Name);

            int byteIndex = 0;
            for(int x = 0; x < fields.Count; x++)
            {
                var field = fields[x];
                sb.Append($"  {field.Name}");
                var isEnum = field.FieldType.IsEnum;

                var fSize = (!isEnum) ? Marshal.SizeOf(field.FieldType) : 4;
                sb.Append($" [{field.FieldType.Name}] size:{fSize}");
                sb.AppendLine();
                sb.Append("    ");
                for(int y = 0; y < fSize; y++)
                {
                    sb.Append($"{arr[byteIndex].ToString((displayHex) ? "X" : string.Empty)} ");
                    byteIndex++;
                }
                sb.AppendLine();

                if(field.FieldType.Name == "IntPtr")
                    sb.AppendLine("    (IntPtr is likely to change)");
            }

            return sb.ToString();
        }
    }
}
