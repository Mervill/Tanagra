using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DescriptorSetLayoutBinding : IDisposable
    {
        internal Unmanaged.DescriptorSetLayoutBinding* NativePointer;
        
        /// <summary>
        /// Binding number for this entry
        /// </summary>
        public UInt32 Binding
        {
            get { return NativePointer->Binding; }
            set { NativePointer->Binding = value; }
        }
        
        /// <summary>
        /// Type of the descriptors in this binding
        /// </summary>
        public DescriptorType DescriptorType
        {
            get { return NativePointer->DescriptorType; }
            set { NativePointer->DescriptorType = value; }
        }
        
        /// <summary>
        /// Number of descriptors in this binding (Optional)
        /// </summary>
        public UInt32 DescriptorCount
        {
            get { return NativePointer->DescriptorCount; }
            set { NativePointer->DescriptorCount = value; }
        }
        
        /// <summary>
        /// Shader stages this binding is visible to
        /// </summary>
        public ShaderStageFlags StageFlags
        {
            get { return NativePointer->StageFlags; }
            set { NativePointer->StageFlags = value; }
        }
        
        /// <summary>
        /// Immutable samplers (used if descriptor type is SAMPLER or COMBINED_IMAGE_SAMPLER, is either NULL or contains count number of elements) (Optional)
        /// </summary>
        public Sampler[] ImmutableSamplers
        {
            get
            {
                if(NativePointer->ImmutableSamplers == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->DescriptorCount;
                var valueArray = new Sampler[valueCount];
                var ptr = (UInt64*)NativePointer->ImmutableSamplers;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new Sampler { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt64)) * valueCount;
                    if(NativePointer->ImmutableSamplers != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ImmutableSamplers, (IntPtr)typeSize);
                    
                    if(NativePointer->ImmutableSamplers == IntPtr.Zero)
                        NativePointer->ImmutableSamplers = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DescriptorCount = (UInt32)valueCount;
                    var ptr = (UInt64*)NativePointer->ImmutableSamplers;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->ImmutableSamplers != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->ImmutableSamplers);
                    
                    NativePointer->ImmutableSamplers = IntPtr.Zero;
                    NativePointer->DescriptorCount = 0;
                }
            }
        }
        
        public DescriptorSetLayoutBinding()
        {
            NativePointer = (Unmanaged.DescriptorSetLayoutBinding*)MemUtil.Alloc(typeof(Unmanaged.DescriptorSetLayoutBinding));
        }
        
        /// <param name="Binding">Binding number for this entry</param>
        /// <param name="DescriptorType">Type of the descriptors in this binding</param>
        /// <param name="StageFlags">Shader stages this binding is visible to</param>
        public DescriptorSetLayoutBinding(UInt32 Binding, DescriptorType DescriptorType, ShaderStageFlags StageFlags) : this()
        {
            this.Binding = Binding;
            this.DescriptorType = DescriptorType;
            this.StageFlags = StageFlags;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->ImmutableSamplers);
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DescriptorSetLayoutBinding()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->ImmutableSamplers);
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
