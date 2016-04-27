using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CopyDescriptorSet
    {
        internal Interop.CopyDescriptorSet* NativeHandle;
        
        DescriptorSet _SrcSet;
        public DescriptorSet SrcSet
        {
            get { return _SrcSet; }
            set { _SrcSet = value; NativeHandle->SrcSet = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 SrcBinding
        {
            get { return NativeHandle->SrcBinding; }
            set { NativeHandle->SrcBinding = value; }
        }
        
        public UInt32 SrcArrayElement
        {
            get { return NativeHandle->SrcArrayElement; }
            set { NativeHandle->SrcArrayElement = value; }
        }
        
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
        
        public CopyDescriptorSet()
        {
            NativeHandle = (Interop.CopyDescriptorSet*)Interop.Structure.Allocate(typeof(Interop.CopyDescriptorSet));
            //NativeHandle->SType = StructureType.CopyDescriptorSet;
        }
    }
}
