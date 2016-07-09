using System;

namespace Vulkan
{
    /// <summary>
    /// For sizes and offsets pertaining to host address space. Equivalent to `size_t` in C/C++
    /// </summary>
    public struct Size
    {
        // http://stackoverflow.com/questions/1089176/is-size-t-always-unsigned
        // http://stackoverflow.com/questions/13170801/difference-between-intptr-and-uintptr
        // http://stackoverflow.com/questions/1320296/intptr-vs-uintptr
        // http://stackoverflow.com/questions/1309509/correct-way-to-marshal-size-t

        // So need this class to behave like size_t from C/C++, which in C11 is defined as:
        //
        // typedef unsigned size_t;
        //
        // Because size_t isn't an actual pointer we can acceptably use UIntPtr here instead
        // of IntPtr, thus matching the properties of size_t. The conficting problem however
        // is that UIntPtr is not CLS Compliant, thus preventing the library from being
        // used from any CLR language other then C#.

        // The rationale for this struct is to avoid confusion with an actual pointer, since the
        // only reason IntPtr/UIntPtr is being used as the backing type is because it's the only buit-in 
        // struct that changes it's size based on the bit-type being targeted. Also, the online consensus
        // seems to be that using `UIntPtr` is the correct way to implement size_t

        readonly UIntPtr value;

        public Size(UInt32 value)
        {
            this.value = new UIntPtr(value);
        }

        public Size(UInt64 value)
        {
            this.value = new UIntPtr(value);
        }

        public static implicit operator Size(UInt32 value)
            => new Size(value);

        public static implicit operator UInt32(Size size)
            => size.value.ToUInt32();

        public static implicit operator Size(UInt64 value)
            => new Size(value);

        public static implicit operator UInt64(Size size)
            => size.value.ToUInt64();

        // Explicit operators. This lets Size initialize arrays ie: `new byte[(int)Size]`

        public static explicit operator Int32(Size size)
            => (Int32)size.value.ToUInt32();

        public static explicit operator Int64(Size size)
            => (Int64)size.value.ToUInt64();

        /*readonly IntPtr value;

        public Size(Int32 value)
        {
            this.value = new IntPtr(value);
        }

        public Size(Int64 value)
        {
            this.value = new IntPtr(value);
        }

        public static implicit operator Size(Int32 value)
            => new Size(value);

        public static implicit operator Int32(Size size)
            => size.value.ToInt32();

        public static implicit operator Size(Int64 value)
            => new Size(value);

        public static implicit operator Int64(Size size)
            => size.value.ToInt64();*/

        public override string ToString()
            => value.ToString();

    }
}