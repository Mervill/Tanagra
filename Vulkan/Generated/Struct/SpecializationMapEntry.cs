using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpecializationMapEntry
    {
        /// <summary>
        /// The SpecConstant ID specified in the BIL
        /// </summary>
        public UInt32 ConstantID;
        /// <summary>
        /// Offset of the value in the data block
        /// </summary>
        public UInt32 Offset;
        /// <summary>
        /// Size in bytes of the SpecConstant
        /// </summary>
        public UInt32 Size;
        
        /// <param name="ConstantID">The SpecConstant ID specified in the BIL</param>
        /// <param name="Offset">Offset of the value in the data block</param>
        /// <param name="Size">Size in bytes of the SpecConstant</param>
        public SpecializationMapEntry(UInt32 ConstantID, UInt32 Offset, UInt32 Size)
        {
            this.ConstantID = ConstantID;
            this.Offset = Offset;
            this.Size = Size;
        }
    }
}
