using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PipelineVertexInputStateCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineVertexInputStateCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineVertexInputStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public VertexInputBindingDescription[] VertexBindingDescriptions
        {
            get
            {
                if(NativePointer->VertexBindingDescriptions == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->VertexBindingDescriptionCount;
                var valueArray = new VertexInputBindingDescription[valueCount];
                var ptr = (VertexInputBindingDescription*)NativePointer->VertexBindingDescriptions;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(VertexInputBindingDescription)) * valueCount;
                    if(NativePointer->VertexBindingDescriptions != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->VertexBindingDescriptions, (IntPtr)typeSize);
                    
                    if(NativePointer->VertexBindingDescriptions == IntPtr.Zero)
                        NativePointer->VertexBindingDescriptions = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->VertexBindingDescriptionCount = (UInt32)valueCount;
                    var ptr = (VertexInputBindingDescription*)NativePointer->VertexBindingDescriptions;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->VertexBindingDescriptions != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->VertexBindingDescriptions);
                    
                    NativePointer->VertexBindingDescriptions = IntPtr.Zero;
                    NativePointer->VertexBindingDescriptionCount = 0;
                }
            }
        }
        
        public VertexInputAttributeDescription[] VertexAttributeDescriptions
        {
            get
            {
                if(NativePointer->VertexAttributeDescriptions == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->VertexAttributeDescriptionCount;
                var valueArray = new VertexInputAttributeDescription[valueCount];
                var ptr = (VertexInputAttributeDescription*)NativePointer->VertexAttributeDescriptions;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(VertexInputAttributeDescription)) * valueCount;
                    if(NativePointer->VertexAttributeDescriptions != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->VertexAttributeDescriptions, (IntPtr)typeSize);
                    
                    if(NativePointer->VertexAttributeDescriptions == IntPtr.Zero)
                        NativePointer->VertexAttributeDescriptions = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->VertexAttributeDescriptionCount = (UInt32)valueCount;
                    var ptr = (VertexInputAttributeDescription*)NativePointer->VertexAttributeDescriptions;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->VertexAttributeDescriptions != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->VertexAttributeDescriptions);
                    
                    NativePointer->VertexAttributeDescriptions = IntPtr.Zero;
                    NativePointer->VertexAttributeDescriptionCount = 0;
                }
            }
        }
        
        public PipelineVertexInputStateCreateInfo()
        {
            NativePointer = (Unmanaged.PipelineVertexInputStateCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.PipelineVertexInputStateCreateInfo));
            NativePointer->SType = StructureType.PipelineVertexInputStateCreateInfo;
        }
        
        public PipelineVertexInputStateCreateInfo(VertexInputBindingDescription[] VertexBindingDescriptions, VertexInputAttributeDescription[] VertexAttributeDescriptions) : this()
        {
            this.VertexBindingDescriptions = VertexBindingDescriptions;
            this.VertexAttributeDescriptions = VertexAttributeDescriptions;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->VertexBindingDescriptions);
            Marshal.FreeHGlobal(NativePointer->VertexAttributeDescriptions);
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.PipelineVertexInputStateCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineVertexInputStateCreateInfo()
        {
            if(NativePointer != (Unmanaged.PipelineVertexInputStateCreateInfo*)IntPtr.Zero)
            {
                Marshal.FreeHGlobal(NativePointer->VertexBindingDescriptions);
                Marshal.FreeHGlobal(NativePointer->VertexAttributeDescriptions);
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.PipelineVertexInputStateCreateInfo*)IntPtr.Zero;
            }
        }
    }
}
