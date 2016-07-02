using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class SparseImageMemoryBind : IDisposable
    {
        internal Unmanaged.SparseImageMemoryBind* NativePointer { get; private set; }
        
        public ImageSubresource Subresource
        {
            get { return NativePointer->Subresource; }
            set { NativePointer->Subresource = value; }
        }
        
        public Offset3D Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        public Extent3D Extent
        {
            get { return NativePointer->Extent; }
            set { NativePointer->Extent = value; }
        }
        
        DeviceMemory _Memory;
        public DeviceMemory Memory
        {
            get { return _Memory; }
            set { _Memory = value; NativePointer->Memory = value.NativePointer; }
        }
        
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize MemoryOffset
        {
            get { return NativePointer->MemoryOffset; }
            set { NativePointer->MemoryOffset = value; }
        }
        
        /// <summary>
        /// Reserved for future (Optional)
        /// </summary>
        public SparseMemoryBindFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public SparseImageMemoryBind()
        {
            NativePointer = (Unmanaged.SparseImageMemoryBind*)MemUtil.Alloc(typeof(Unmanaged.SparseImageMemoryBind));
        }
        
        internal SparseImageMemoryBind(Unmanaged.SparseImageMemoryBind* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.SparseImageMemoryBind));
        }
        
        /// <param name="MemoryOffset">Specified in bytes</param>
        public SparseImageMemoryBind(ImageSubresource Subresource, Offset3D Offset, Extent3D Extent, DeviceSize MemoryOffset) : this()
        {
            this.Subresource = Subresource;
            this.Offset = Offset;
            this.Extent = Extent;
            this.MemoryOffset = MemoryOffset;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~SparseImageMemoryBind()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
