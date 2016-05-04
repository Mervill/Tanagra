using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class WriteDescriptorSet
    {
        internal Interop.WriteDescriptorSet* NativePointer;
        
        DescriptorSet _DstSet;
        public DescriptorSet DstSet
        {
            get { return _DstSet; }
            set { _DstSet = value; NativePointer->DstSet = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 DstBinding
        {
            get { return NativePointer->DstBinding; }
            set { NativePointer->DstBinding = value; }
        }
        
        public UInt32 DstArrayElement
        {
            get { return NativePointer->DstArrayElement; }
            set { NativePointer->DstArrayElement = value; }
        }
        
        public UInt32 DescriptorCount
        {
            get { return NativePointer->DescriptorCount; }
            set { NativePointer->DescriptorCount = value; }
        }
        
        public DescriptorType DescriptorType
        {
            get { return NativePointer->DescriptorType; }
            set { NativePointer->DescriptorType = value; }
        }
        
        public DescriptorImageInfo ImageInfo
        {
            get { return NativePointer->ImageInfo; }
            set { NativePointer->ImageInfo = value; }
        }
        
        public DescriptorBufferInfo BufferInfo
        {
            get { return NativePointer->BufferInfo; }
            set { NativePointer->BufferInfo = value; }
        }
        
        BufferView _TexelBufferView;
        public BufferView TexelBufferView
        {
            get { return _TexelBufferView; }
            set { _TexelBufferView = value; NativePointer->TexelBufferView = (IntPtr)value.NativePointer; }
        }
        
        public WriteDescriptorSet()
        {
            NativePointer = (Interop.WriteDescriptorSet*)Interop.Structure.Allocate(typeof(Interop.WriteDescriptorSet));
            NativePointer->SType = StructureType.WriteDescriptorSet;
        }
    }
}
