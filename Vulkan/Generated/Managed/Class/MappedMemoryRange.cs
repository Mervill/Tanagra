using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class MappedMemoryRange : IDisposable
    {
        internal Unmanaged.MappedMemoryRange* NativePointer { get; private set; }
        
        DeviceMemory _Memory;
        /// <summary>
        /// Mapped memory object
        /// </summary>
        public DeviceMemory Memory
        {
            get { return _Memory; }
            set { _Memory = value; NativePointer->Memory = value.NativePointer; }
        }
        
        /// <summary>
        /// Offset within the memory object where the range starts
        /// </summary>
        public DeviceSize Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        /// <summary>
        /// Size of the range within the memory object
        /// </summary>
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public MappedMemoryRange()
        {
            NativePointer = (Unmanaged.MappedMemoryRange*)MemUtil.Alloc(typeof(Unmanaged.MappedMemoryRange));
            NativePointer->SType = StructureType.MappedMemoryRange;
        }
        
        internal MappedMemoryRange(Unmanaged.MappedMemoryRange* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.MappedMemoryRange));
        }
        
        /// <param name="Memory">Mapped memory object</param>
        /// <param name="Offset">Offset within the memory object where the range starts</param>
        /// <param name="Size">Size of the range within the memory object</param>
        public MappedMemoryRange(DeviceMemory Memory, DeviceSize Offset, DeviceSize Size) : this()
        {
            this.Memory = Memory;
            this.Offset = Offset;
            this.Size = Size;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~MappedMemoryRange()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
