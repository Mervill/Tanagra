using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDeviceMemoryProperties
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryTypesInfo
        {
            public const UInt32 Length = 32;
            
            public MemoryType Value00;
            public MemoryType Value01;
            public MemoryType Value02;
            public MemoryType Value03;
            public MemoryType Value04;
            public MemoryType Value05;
            public MemoryType Value06;
            public MemoryType Value07;
            public MemoryType Value08;
            public MemoryType Value09;
            public MemoryType Value10;
            public MemoryType Value11;
            public MemoryType Value12;
            public MemoryType Value13;
            public MemoryType Value14;
            public MemoryType Value15;
            public MemoryType Value16;
            public MemoryType Value17;
            public MemoryType Value18;
            public MemoryType Value19;
            public MemoryType Value20;
            public MemoryType Value21;
            public MemoryType Value22;
            public MemoryType Value23;
            public MemoryType Value24;
            public MemoryType Value25;
            public MemoryType Value26;
            public MemoryType Value27;
            public MemoryType Value28;
            public MemoryType Value29;
            public MemoryType Value30;
            public MemoryType Value31;
            
            public MemoryType this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value00;
                        case 1: return Value01;
                        case 2: return Value02;
                        case 3: return Value03;
                        case 4: return Value04;
                        case 5: return Value05;
                        case 6: return Value06;
                        case 7: return Value07;
                        case 8: return Value08;
                        case 9: return Value09;
                        case 10: return Value10;
                        case 11: return Value11;
                        case 12: return Value12;
                        case 13: return Value13;
                        case 14: return Value14;
                        case 15: return Value15;
                        case 16: return Value16;
                        case 17: return Value17;
                        case 18: return Value18;
                        case 19: return Value19;
                        case 20: return Value20;
                        case 21: return Value21;
                        case 22: return Value22;
                        case 23: return Value23;
                        case 24: return Value24;
                        case 25: return Value25;
                        case 26: return Value26;
                        case 27: return Value27;
                        case 28: return Value28;
                        case 29: return Value29;
                        case 30: return Value30;
                        case 31: return Value31;
                    }
                }
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryHeapsInfo
        {
            public const UInt32 Length = 16;
            
            public MemoryHeap Value00;
            public MemoryHeap Value01;
            public MemoryHeap Value02;
            public MemoryHeap Value03;
            public MemoryHeap Value04;
            public MemoryHeap Value05;
            public MemoryHeap Value06;
            public MemoryHeap Value07;
            public MemoryHeap Value08;
            public MemoryHeap Value09;
            public MemoryHeap Value10;
            public MemoryHeap Value11;
            public MemoryHeap Value12;
            public MemoryHeap Value13;
            public MemoryHeap Value14;
            public MemoryHeap Value15;
            
            public MemoryHeap this[uint key]
            {
                get
                {
                    switch(key)
                    {
                        default: throw new IndexOutOfRangeException();
                        case 0: return Value00;
                        case 1: return Value01;
                        case 2: return Value02;
                        case 3: return Value03;
                        case 4: return Value04;
                        case 5: return Value05;
                        case 6: return Value06;
                        case 7: return Value07;
                        case 8: return Value08;
                        case 9: return Value09;
                        case 10: return Value10;
                        case 11: return Value11;
                        case 12: return Value12;
                        case 13: return Value13;
                        case 14: return Value14;
                        case 15: return Value15;
                    }
                }
            }
        }
        public UInt32 MemoryTypeCount;
        public MemoryTypesInfo MemoryTypes;
        public UInt32 MemoryHeapCount;
        public MemoryHeapsInfo MemoryHeaps;
    }
}
