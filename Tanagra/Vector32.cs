using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;

namespace Tanagra
{
    public struct Vecvtor2
    {
        public Int32 X;
        public Int32 Y;

        public Vecvtor2(Int32 X, Int32 Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static implicit operator Vecvtor2(Offset2D offset)
            => new Vecvtor2(offset.X, offset.Y);

        public static implicit operator Offset2D(Vecvtor2 vector)
            => new Offset2D(vector.X, vector.Y);
    }

    public struct Vecvtor3
    {
        public Int32 X;
        public Int32 Y;
        public Int32 Z;

        public Vecvtor3(Int32 X, Int32 Y, Int32 Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        
        public static implicit operator Vecvtor3(Offset3D offset)
            => new Vecvtor3(offset.X, offset.Y, offset.Z);

        public static implicit operator Offset3D(Vecvtor3 vector)
            => new Offset3D(vector.X, vector.Y, vector.Z);
    }
}
