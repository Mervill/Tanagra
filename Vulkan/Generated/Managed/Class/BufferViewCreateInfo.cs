using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class BufferViewCreateInfo : IDisposable
    {
        internal Unmanaged.BufferViewCreateInfo* NativePointer { get; private set; }
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public BufferViewCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        Buffer _Buffer;
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativePointer->Buffer = value.NativePointer; }
        }
        
        /// <summary>
        /// Optionally specifies format of elements
        /// </summary>
        public Format Format
        {
            get { return NativePointer->Format; }
            set { NativePointer->Format = value; }
        }
        
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        /// <summary>
        /// View size specified in bytes
        /// </summary>
        public DeviceSize Range
        {
            get { return NativePointer->Range; }
            set { NativePointer->Range = value; }
        }
        
        public BufferViewCreateInfo()
        {
            NativePointer = (Unmanaged.BufferViewCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.BufferViewCreateInfo));
            NativePointer->SType = StructureType.BufferViewCreateInfo;
        }
        
        internal BufferViewCreateInfo(Unmanaged.BufferViewCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.BufferViewCreateInfo));
        }
        
        /// <param name="Format">Optionally specifies format of elements</param>
        /// <param name="Offset">Specified in bytes</param>
        /// <param name="Range">View size specified in bytes</param>
        public BufferViewCreateInfo(Buffer Buffer, Format Format, DeviceSize Offset, DeviceSize Range) : this()
        {
            this.Buffer = Buffer;
            this.Format = Format;
            this.Offset = Offset;
            this.Range = Range;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~BufferViewCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
