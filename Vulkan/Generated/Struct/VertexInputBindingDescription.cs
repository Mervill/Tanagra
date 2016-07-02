using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexInputBindingDescription
    {
        /// <summary>
        /// Vertex buffer binding id
        /// </summary>
        public UInt32 Binding;
        /// <summary>
        /// Distance between vertices in bytes (0 = no advancement)
        /// </summary>
        public UInt32 Stride;
        /// <summary>
        /// The rate at which the vertex data is consumed
        /// </summary>
        public VertexInputRate InputRate;
        
        /// <param name="Binding">Vertex buffer binding id</param>
        /// <param name="Stride">Distance between vertices in bytes (0 = no advancement)</param>
        /// <param name="InputRate">The rate at which the vertex data is consumed</param>
        public VertexInputBindingDescription(UInt32 Binding, UInt32 Stride, VertexInputRate InputRate)
        {
            this.Binding = Binding;
            this.Stride = Stride;
            this.InputRate = InputRate;
        }
    }
}
