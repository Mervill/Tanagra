using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CopyDescriptorSet
    {
        internal Interop.CopyDescriptorSet* NativePointer;
        
        DescriptorSet _SrcSet;
        public DescriptorSet SrcSet
        {
            get { return _SrcSet; }
            set { _SrcSet = value; NativePointer->SrcSet = value.NativePointer; }
        }
        
        public UInt32 SrcBinding
        {
            get { return NativePointer->SrcBinding; }
            set { NativePointer->SrcBinding = value; }
        }
        
        public UInt32 SrcArrayElement
        {
            get { return NativePointer->SrcArrayElement; }
            set { NativePointer->SrcArrayElement = value; }
        }
        
        DescriptorSet _DstSet;
        public DescriptorSet DstSet
        {
            get { return _DstSet; }
            set { _DstSet = value; NativePointer->DstSet = value.NativePointer; }
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
        
        public CopyDescriptorSet()
        {
            NativePointer = (Interop.CopyDescriptorSet*)Interop.Structure.Allocate(typeof(Interop.CopyDescriptorSet));
            NativePointer->SType = StructureType.CopyDescriptorSet;
        }
    }
}
