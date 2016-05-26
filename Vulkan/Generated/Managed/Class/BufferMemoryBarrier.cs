using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class BufferMemoryBarrier : IDisposable
    {
        internal Unmanaged.BufferMemoryBarrier* NativePointer;
        
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask
        {
            get { return NativePointer->SrcAccessMask; }
            set { NativePointer->SrcAccessMask = value; }
        }
        
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags DstAccessMask
        {
            get { return NativePointer->DstAccessMask; }
            set { NativePointer->DstAccessMask = value; }
        }
        
        /// <summary>
        /// Queue family to transition ownership from
        /// </summary>
        public UInt32 SrcQueueFamilyIndex
        {
            get { return NativePointer->SrcQueueFamilyIndex; }
            set { NativePointer->SrcQueueFamilyIndex = value; }
        }
        
        /// <summary>
        /// Queue family to transition ownership to
        /// </summary>
        public UInt32 DstQueueFamilyIndex
        {
            get { return NativePointer->DstQueueFamilyIndex; }
            set { NativePointer->DstQueueFamilyIndex = value; }
        }
        
        Buffer _Buffer;
        /// <summary>
        /// Buffer to sync
        /// </summary>
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativePointer->Buffer = value.NativePointer; }
        }
        
        /// <summary>
        /// Offset within the buffer to sync
        /// </summary>
        public DeviceSize Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        /// <summary>
        /// Amount of bytes to sync
        /// </summary>
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public BufferMemoryBarrier()
        {
            NativePointer = (Unmanaged.BufferMemoryBarrier*)MemUtil.Alloc(typeof(Unmanaged.BufferMemoryBarrier));
            NativePointer->SType = StructureType.BufferMemoryBarrier;
        }
        
        public BufferMemoryBarrier(UInt32 SrcQueueFamilyIndex, UInt32 DstQueueFamilyIndex, Buffer Buffer, DeviceSize Offset, DeviceSize Size) : this()
        {
            this.SrcQueueFamilyIndex = SrcQueueFamilyIndex;
            this.DstQueueFamilyIndex = DstQueueFamilyIndex;
            this.Buffer = Buffer;
            this.Offset = Offset;
            this.Size = Size;
        }
        
        public void Dispose()
        {
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~BufferMemoryBarrier()
        {
            if(NativePointer != null)
            {
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
