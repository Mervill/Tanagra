using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DescriptorSetLayoutCreateInfo : IDisposable
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
                    var typeSize = Marshal.SizeOf(typeof(Unmanaged.DescriptorSetLayoutBinding)) * valueCount;
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
            NativePointer = (Unmanaged.DescriptorSetLayoutCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.DescriptorSetLayoutCreateInfo));
            NativePointer->SType = StructureType.DescriptorSetLayoutCreateInfo;
        }
        
        /// <param name="Bindings">Array of descriptor set layout bindings</param>
        public DescriptorSetLayoutCreateInfo(DescriptorSetLayoutBinding[] Bindings) : this()
        {
            this.Bindings = Bindings;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->Bindings);
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DescriptorSetLayoutCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->Bindings);
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
