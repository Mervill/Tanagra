using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;

namespace Tanagra
{
    public struct Vector2
    {
        public Int32 X;
        public Int32 Y;

        public Vector2(Int32 X, Int32 Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static implicit operator Vector2(Offset2D offset)
            => new Vector2(offset.X, offset.Y);

        public static implicit operator Offset2D(Vector2 vector)
            => new Offset2D(vector.X, vector.Y);
    }

    public struct Vector3
    {
        public Int32 X;
        public Int32 Y;
        public Int32 Z;

        public Vector3(Int32 X, Int32 Y, Int32 Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        
        public static implicit operator Vector3(Offset3D offset)
            => new Vector3(offset.X, offset.Y, offset.Z);

        public static implicit operator Offset3D(Vector3 vector)
            => new Offset3D(vector.X, vector.Y, vector.Z);
    }
}
