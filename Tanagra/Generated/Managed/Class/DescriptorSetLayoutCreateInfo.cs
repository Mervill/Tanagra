using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorSetLayoutCreateInfo
    {
        internal Unmanaged.DescriptorSetLayoutCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DescriptorSetLayoutCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Array of descriptor set layout bindings
        /// </summary>
        public DescriptorSetLayoutBinding[] Bindings
        {
            get
            {
                if(NativePointer->Bindings == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->BindingCount;
                var valueArray = new DescriptorSetLayoutBinding[valueCount];
                var ptr = (Unmanaged.DescriptorSetLayoutBinding*)NativePointer->Bindings;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorSetLayoutBinding { NativePointer = &ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Unmanaged.DescriptorSetLayoutBinding>() * valueCount;
                    if(NativePointer->Bindings != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Bindings, (IntPtr)typeSize);
                    
                    if(NativePointer->Bindings == IntPtr.Zero)
                        NativePointer->Bindings = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->BindingCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.DescriptorSetLayoutBinding*)NativePointer->Bindings;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->Bindings != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Bindings);
                    
                    NativePointer->Bindings = IntPtr.Zero;
                    NativePointer->BindingCount = 0;
                }
            }
        }
        
        public DescriptorSetLayoutCreateInfo()
        {
            NativePointer = (Unmanaged.DescriptorSetLayoutCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.DescriptorSetLayoutCreateInfo));
            NativePointer->SType = StructureType.DescriptorSetLayoutCreateInfo;
        }
        
        public DescriptorSetLayoutCreateInfo(DescriptorSetLayoutBinding[] Bindings) : this()
        {
            this.Bindings = Bindings;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.DescriptorSetLayoutCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
