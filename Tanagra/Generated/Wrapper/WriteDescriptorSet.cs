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
                if(NativePointer->ImageInfo == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->DescriptorCount;
                var valueArray = new DescriptorImageInfo[valueCount];
                var ptr = (Interop.DescriptorImageInfo*)NativePointer->ImageInfo;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorImageInfo { NativePointer = &ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Interop.DescriptorImageInfo>() * valueCount;
                    if(NativePointer->ImageInfo != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ImageInfo, (IntPtr)typeSize);
                    
                    if(NativePointer->ImageInfo == IntPtr.Zero)
                        NativePointer->ImageInfo = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DescriptorCount = (UInt32)valueCount;
                    var ptr = (Interop.DescriptorImageInfo*)NativePointer->ImageInfo;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->ImageInfo != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->ImageInfo);
                    
                    NativePointer->ImageInfo = IntPtr.Zero;
                    NativePointer->DescriptorCount = 0;
                }
            }
        }
        
        /// <summary>
        /// Raw buffer, size, and offset for {UNIFORM,STORAGE}_BUFFER[_DYNAMIC] descriptor types.
        /// </summary>
        public DescriptorBufferInfo[] BufferInfo
        {
            get
            {
                if(NativePointer->BufferInfo == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->DescriptorCount;
                var valueArray = new DescriptorBufferInfo[valueCount];
                var ptr = (Interop.DescriptorBufferInfo*)NativePointer->BufferInfo;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorBufferInfo { NativePointer = &ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Interop.DescriptorBufferInfo>() * valueCount;
                    if(NativePointer->BufferInfo != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->BufferInfo, (IntPtr)typeSize);
                    
                    if(NativePointer->BufferInfo == IntPtr.Zero)
                        NativePointer->BufferInfo = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DescriptorCount = (UInt32)valueCount;
                    var ptr = (Interop.DescriptorBufferInfo*)NativePointer->BufferInfo;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->BufferInfo != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->BufferInfo);
                    
                    NativePointer->BufferInfo = IntPtr.Zero;
                    NativePointer->DescriptorCount = 0;
                }
            }
        }
        
        /// <summary>
        /// Buffer view to write to the descriptor for {UNIFORM,STORAGE}_TEXEL_BUFFER descriptor types.
        /// </summary>
        public BufferView[] TexelBufferView
        {
            get
            {
                if(NativePointer->TexelBufferView == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->DescriptorCount;
                var valueArray = new BufferView[valueCount];
                var ptr = (UInt64*)NativePointer->TexelBufferView;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new BufferView { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->TexelBufferView != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->TexelBufferView, (IntPtr)typeSize);
                    
                    if(NativePointer->TexelBufferView == IntPtr.Zero)
                        NativePointer->TexelBufferView = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DescriptorCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->TexelBufferView;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->TexelBufferView != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->TexelBufferView);
                    
                    NativePointer->TexelBufferView = IntPtr.Zero;
                    NativePointer->DescriptorCount = 0;
                }
            }
        }
        
        public WriteDescriptorSet()
        {
            NativePointer = (Interop.WriteDescriptorSet*)MemoryUtils.Allocate(typeof(Interop.WriteDescriptorSet));
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
