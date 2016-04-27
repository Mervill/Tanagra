using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class WriteDescriptorSet
    {
        internal Interop.WriteDescriptorSet* NativeHandle;
        
        DescriptorSet _DstSet;
        public DescriptorSet DstSet
        {
            get { return _DstSet; }
            set { _DstSet = value; NativeHandle->DstSet = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 DstBinding
        {
            get { return NativeHandle->DstBinding; }
            set { NativeHandle->DstBinding = value; }
        }
        
        public UInt32 DstArrayElement
        {
            get { return NativeHandle->DstArrayElement; }
            set { NativeHandle->DstArrayElement = value; }
        }
        
        public UInt32 DescriptorCount
        {
            get { return NativeHandle->DescriptorCount; }
            set { NativeHandle->DescriptorCount = value; }
        }
        
        public DescriptorType DescriptorType
        {
            get { return NativeHandle->DescriptorType; }
            set { NativeHandle->DescriptorType = value; }
        }
        
        DescriptorImageInfo _ImageInfo;
        public DescriptorImageInfo ImageInfo
        {
            get { return _ImageInfo; }
            set { _ImageInfo = value; NativeHandle->ImageInfo = (IntPtr)value.NativeHandle; }
        }
        
        DescriptorBufferInfo _BufferInfo;
        public DescriptorBufferInfo BufferInfo
        {
            get { return _BufferInfo; }
            set { _BufferInfo = value; NativeHandle->BufferInfo = (IntPtr)value.NativeHandle; }
        }
        
        BufferView _TexelBufferView;
        public BufferView TexelBufferView
        {
            get { return _TexelBufferView; }
            set { _TexelBufferView = value; NativeHandle->TexelBufferView = (IntPtr)value.NativeHandle; }
        }
        
        public WriteDescriptorSet()
        {
            NativeHandle = (Interop.WriteDescriptorSet*)Interop.Structure.Allocate(typeof(Interop.WriteDescriptorSet));
            //NativeHandle->SType = StructureType.WriteDescriptorSet;
        }
    }
}
