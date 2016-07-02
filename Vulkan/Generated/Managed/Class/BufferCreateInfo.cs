using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class BufferCreateInfo : IDisposable
    {
        internal Unmanaged.BufferCreateInfo* NativePointer { get; private set; }
        
        /// <summary>
        /// Buffer creation flags (Optional)
        /// </summary>
        public BufferCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        /// <summary>
        /// Buffer usage flags
        /// </summary>
        public BufferUsageFlags Usage
        {
            get { return NativePointer->Usage; }
            set { NativePointer->Usage = value; }
        }
        
        public SharingMode SharingMode
        {
            get { return NativePointer->SharingMode; }
            set { NativePointer->SharingMode = value; }
        }
        
        public UInt32[] QueueFamilyIndices
        {
            get
            {
                if(NativePointer->QueueFamilyIndices == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->QueueFamilyIndexCount;
                var valueArray = new UInt32[valueCount];
                var ptr = (UInt32*)NativePointer->QueueFamilyIndices;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt32)) * valueCount;
                    if(NativePointer->QueueFamilyIndices != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->QueueFamilyIndices, (IntPtr)typeSize);
                    
                    if(NativePointer->QueueFamilyIndices == IntPtr.Zero)
                        NativePointer->QueueFamilyIndices = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->QueueFamilyIndexCount = (UInt32)valueCount;
                    var ptr = (UInt32*)NativePointer->QueueFamilyIndices;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->QueueFamilyIndices != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->QueueFamilyIndices);
                    
                    NativePointer->QueueFamilyIndices = IntPtr.Zero;
                    NativePointer->QueueFamilyIndexCount = 0;
                }
            }
        }
        
        public BufferCreateInfo()
        {
            NativePointer = (Unmanaged.BufferCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.BufferCreateInfo));
            NativePointer->SType = StructureType.BufferCreateInfo;
        }
        
        internal BufferCreateInfo(Unmanaged.BufferCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.BufferCreateInfo));
        }
        
        /// <param name="Size">Specified in bytes</param>
        /// <param name="Usage">Buffer usage flags</param>
        public BufferCreateInfo(DeviceSize Size, BufferUsageFlags Usage, SharingMode SharingMode, UInt32[] QueueFamilyIndices) : this()
        {
            this.Size = Size;
            this.Usage = Usage;
            this.SharingMode = SharingMode;
            this.QueueFamilyIndices = QueueFamilyIndices;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->QueueFamilyIndices);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~BufferCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->QueueFamilyIndices);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
