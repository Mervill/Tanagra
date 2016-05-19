using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageOpaqueMemoryBindInfo
    {
        internal Unmanaged.SparseImageOpaqueMemoryBindInfo* NativePointer;
        
        Image _Image;
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativePointer->Image = value.NativePointer; }
        }
        
        public SparseMemoryBind[] Binds
        {
            get
            {
                if(NativePointer->Binds == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->BindCount;
                var valueArray = new SparseMemoryBind[valueCount];
                var ptr = (Unmanaged.SparseMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseMemoryBind { NativePointer = &ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Unmanaged.SparseMemoryBind>() * valueCount;
                    if(NativePointer->Binds != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Binds, (IntPtr)typeSize);
                    
                    if(NativePointer->Binds == IntPtr.Zero)
                        NativePointer->Binds = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->BindCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.SparseMemoryBind*)NativePointer->Binds;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->Binds != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Binds);
                    
                    NativePointer->Binds = IntPtr.Zero;
                    NativePointer->BindCount = 0;
                }
            }
        }
        
        public SparseImageOpaqueMemoryBindInfo()
        {
            NativePointer = (Unmanaged.SparseImageOpaqueMemoryBindInfo*)MemoryUtils.Allocate(typeof(Unmanaged.SparseImageOpaqueMemoryBindInfo));
        }
        
        public SparseImageOpaqueMemoryBindInfo(Image Image, SparseMemoryBind[] Binds) : this()
        {
            this.Image = Image;
            this.Binds = Binds;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.SparseImageOpaqueMemoryBindInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}