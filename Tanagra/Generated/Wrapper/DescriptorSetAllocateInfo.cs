using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetAllocateInfo
    {
        internal Interop.DescriptorSetAllocateInfo* NativePointer;
        
        DescriptorPool _DescriptorPool;
        public DescriptorPool DescriptorPool
        {
            get { return _DescriptorPool; }
            set { _DescriptorPool = value; NativePointer->DescriptorPool = value.NativePointer; }
        }
        
        public DescriptorSetLayout[] SetLayouts
        {
            get
            {
                if(NativePointer->SetLayouts == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->DescriptorSetCount;
                var valueArray = new DescriptorSetLayout[valueCount];
                var ptr = (UInt64*)NativePointer->SetLayouts;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorSetLayout { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->SetLayouts != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->SetLayouts, (IntPtr)typeSize);
                    
                    if(NativePointer->SetLayouts == IntPtr.Zero)
                        NativePointer->SetLayouts = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DescriptorSetCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->SetLayouts;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->SetLayouts != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->SetLayouts);
                    
                    NativePointer->SetLayouts = IntPtr.Zero;
                    NativePointer->DescriptorSetCount = 0;
                }
            }
        }
        
        public DescriptorSetAllocateInfo()
        {
            NativePointer = (Interop.DescriptorSetAllocateInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorSetAllocateInfo));
            NativePointer->SType = StructureType.DescriptorSetAllocateInfo;
        }
        
        public DescriptorSetAllocateInfo(DescriptorPool DescriptorPool, DescriptorSetLayout[] SetLayouts) : this()
        {
            this.DescriptorPool = DescriptorPool;
            this.SetLayouts = SetLayouts;
        }
    }
}
