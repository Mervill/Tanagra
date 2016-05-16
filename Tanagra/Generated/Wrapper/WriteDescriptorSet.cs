using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class WriteDescriptorSet
    {
        internal Interop.WriteDescriptorSet* NativePointer;
        
        DescriptorSet _DstSet;
        /// <summary>
        /// Destination descriptor set
        /// </summary>
        public DescriptorSet DstSet
        {
            get { return _DstSet; }
            set { _DstSet = value; NativePointer->DstSet = value.NativePointer; }
        }
        
        /// <summary>
        /// Binding within the destination descriptor set to write
        /// </summary>
        public UInt32 DstBinding
        {
            get { return NativePointer->DstBinding; }
            set { NativePointer->DstBinding = value; }
        }
        
        /// <summary>
        /// Array element within the destination binding to write
        /// </summary>
        public UInt32 DstArrayElement
        {
            get { return NativePointer->DstArrayElement; }
            set { NativePointer->DstArrayElement = value; }
        }
        
        /// <summary>
        /// Descriptor type to write (determines which members of the array pointed by pDescriptors are going to be used)
        /// </summary>
        public DescriptorType DescriptorType
        {
            get { return NativePointer->DescriptorType; }
            set { NativePointer->DescriptorType = value; }
        }
        
        /// <summary>
        /// Sampler, image view, and layout for SAMPLER, COMBINED_IMAGE_SAMPLER, {SAMPLED,STORAGE}_IMAGE, and INPUT_ATTACHMENT descriptor types.
        /// </summary>
        public DescriptorImageInfo[] ImageInfo
        {
            get
            {
                var valueCount = NativePointer->DescriptorCount;
                var valueArray = new DescriptorImageInfo[valueCount];
                var ptr = (Interop.DescriptorImageInfo*)NativePointer->ImageInfo;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorImageInfo { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->DescriptorCount = (UInt32)valueCount;
                NativePointer->ImageInfo = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.DescriptorImageInfo>() * valueCount);
                var ptr = (Interop.DescriptorImageInfo*)NativePointer->ImageInfo;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
        }
        
        /// <summary>
        /// Raw buffer, size, and offset for {UNIFORM,STORAGE}_BUFFER[_DYNAMIC] descriptor types.
        /// </summary>
        public DescriptorBufferInfo[] BufferInfo
        {
            get
            {
                var valueCount = NativePointer->DescriptorCount;
                var valueArray = new DescriptorBufferInfo[valueCount];
                var ptr = (Interop.DescriptorBufferInfo*)NativePointer->BufferInfo;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorBufferInfo { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->DescriptorCount = (UInt32)valueCount;
                NativePointer->BufferInfo = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.DescriptorBufferInfo>() * valueCount);
                var ptr = (Interop.DescriptorBufferInfo*)NativePointer->BufferInfo;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
        }
        
        /// <summary>
        /// Buffer view to write to the descriptor for {UNIFORM,STORAGE}_TEXEL_BUFFER descriptor types.
        /// </summary>
        public BufferView[] TexelBufferView
        {
            get
            {
                var valueCount = NativePointer->DescriptorCount;
                var valueArray = new BufferView[valueCount];
                var ptr = (UInt64*)NativePointer->TexelBufferView;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new BufferView { NativePointer = ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->DescriptorCount = (UInt32)valueCount;
                NativePointer->TexelBufferView = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);
                var ptr = (IntPtr*)NativePointer->TexelBufferView;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (IntPtr)value[x].NativePointer;
            }
        }
        
        public WriteDescriptorSet()
        {
            NativePointer = (Interop.WriteDescriptorSet*)Interop.Structure.Allocate(typeof(Interop.WriteDescriptorSet));
            NativePointer->SType = StructureType.WriteDescriptorSet;
        }
        
        public WriteDescriptorSet(DescriptorSet DstSet, UInt32 DstBinding, UInt32 DstArrayElement, DescriptorType DescriptorType, DescriptorImageInfo[] ImageInfo, DescriptorBufferInfo[] BufferInfo, BufferView[] TexelBufferView) : this()
        {
            this.DstSet = DstSet;
            this.DstBinding = DstBinding;
            this.DstArrayElement = DstArrayElement;
            this.DescriptorType = DescriptorType;
            this.ImageInfo = ImageInfo;
            this.BufferInfo = BufferInfo;
            this.TexelBufferView = TexelBufferView;
        }
    }
}
