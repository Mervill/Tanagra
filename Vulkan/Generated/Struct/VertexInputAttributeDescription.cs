using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexInputAttributeDescription
    {
        /// <summary>
        /// Location of the shader vertex attrib
        /// </summary>
        public UInt32 Location;
        /// <summary>
        /// Vertex buffer binding id
        /// </summary>
        public UInt32 Binding;
        /// <summary>
        /// Format of source data
        /// </summary>
        public Format Format;
        /// <summary>
        /// Offset of first element in bytes from base of vertex
        /// </summary>
        public UInt32 Offset;
        
        /// <param name="Location">Location of the shader vertex attrib</param>
        /// <param name="Binding">Vertex buffer binding id</param>
        /// <param name="Format">Format of source data</param>
        /// <param name="Offset">Offset of first element in bytes from base of vertex</param>
        public VertexInputAttributeDescription(UInt32 Location, UInt32 Binding, Format Format, UInt32 Offset)
        {
            this.Location = Location;
            this.Binding = Binding;
            this.Format = Format;
            this.Offset = Offset;
        }
    }
}
