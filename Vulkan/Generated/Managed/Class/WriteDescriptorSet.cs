using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// IExtensible
    /// </summary>
    unsafe public class WriteDescriptorSet : IDisposable
    {
        internal Unmanaged.WriteDescriptorSet* NativePointer { get; private set; }
        
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
                var ptr = (Unmanaged.DescriptorImageInfo*)NativePointer->ImageInfo;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorImageInfo(&ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Unmanaged.DescriptorImageInfo)) * valueCount;
                    if(NativePointer->ImageInfo != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ImageInfo, (IntPtr)typeSize);
                    
                    if(NativePointer->ImageInfo == IntPtr.Zero)
                        NativePointer->ImageInfo = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DescriptorCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.DescriptorImageInfo*)NativePointer->ImageInfo;
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
                var ptr = (Unmanaged.DescriptorBufferInfo*)NativePointer->BufferInfo;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new DescriptorBufferInfo(&ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Unmanaged.DescriptorBufferInfo)) * valueCount;
                    if(NativePointer->BufferInfo != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->BufferInfo, (IntPtr)typeSize);
                    
                    if(NativePointer->BufferInfo == IntPtr.Zero)
                        NativePointer->BufferInfo = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DescriptorCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.DescriptorBufferInfo*)NativePointer->BufferInfo;
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
                    valueArray[x] = new BufferView(ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt64)) * valueCount;
                    if(NativePointer->TexelBufferView != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->TexelBufferView, (IntPtr)typeSize);
                    
                    if(NativePointer->TexelBufferView == IntPtr.Zero)
                        NativePointer->TexelBufferView = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DescriptorCount = (UInt32)valueCount;
                    var ptr = (UInt64*)NativePointer->TexelBufferView;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x].NativePointer;
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
            NativePointer = (Unmanaged.WriteDescriptorSet*)MemUtil.Alloc(typeof(Unmanaged.WriteDescriptorSet));
            NativePointer->SType = StructureType.WriteDescriptorSet;
        }
        
        internal WriteDescriptorSet(Unmanaged.WriteDescriptorSet* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.WriteDescriptorSet));
        }
        
        /// <param name="DstSet">Destination descriptor set</param>
        /// <param name="DstBinding">Binding within the destination descriptor set to write</param>
        /// <param name="DstArrayElement">Array element within the destination binding to write</param>
        /// <param name="DescriptorType">Descriptor type to write (determines which members of the array pointed by pDescriptors are going to be used)</param>
        /// <param name="ImageInfo">Sampler, image view, and layout for SAMPLER, COMBINED_IMAGE_SAMPLER, {SAMPLED,STORAGE}_IMAGE, and INPUT_ATTACHMENT descriptor types.</param>
        /// <param name="BufferInfo">Raw buffer, size, and offset for {UNIFORM,STORAGE}_BUFFER[_DYNAMIC] descriptor types.</param>
        /// <param name="TexelBufferView">Buffer view to write to the descriptor for {UNIFORM,STORAGE}_TEXEL_BUFFER descriptor types.</param>
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
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->ImageInfo);
            Marshal.FreeHGlobal(NativePointer->BufferInfo);
            Marshal.FreeHGlobal(NativePointer->TexelBufferView);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~WriteDescriptorSet()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->ImageInfo);
                Marshal.FreeHGlobal(NativePointer->BufferInfo);
                Marshal.FreeHGlobal(NativePointer->TexelBufferView);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
