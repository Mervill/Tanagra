using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class CopyDescriptorSet
    {
        internal Interop.CopyDescriptorSet* NativePointer;
        
        DescriptorSet _SrcSet;
        /// <summary>
        /// Source descriptor set
        /// </summary>
        public DescriptorSet SrcSet
        {
            get { return _SrcSet; }
            set { _SrcSet = value; NativePointer->SrcSet = value.NativePointer; }
        }
        
        /// <summary>
        /// Binding within the source descriptor set to copy from
        /// </summary>
        public UInt32 SrcBinding
        {
            get { return NativePointer->SrcBinding; }
            set { NativePointer->SrcBinding = value; }
        }
        
        /// <summary>
        /// Array element within the source binding to copy from
        /// </summary>
        public UInt32 SrcArrayElement
        {
            get { return NativePointer->SrcArrayElement; }
            set { NativePointer->SrcArrayElement = value; }
        }
        
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
        /// Binding within the destination descriptor set to copy to
        /// </summary>
        public UInt32 DstBinding
        {
            get { return NativePointer->DstBinding; }
            set { NativePointer->DstBinding = value; }
        }
        
        /// <summary>
        /// Array element within the destination binding to copy to
        /// </summary>
        public UInt32 DstArrayElement
        {
            get { return NativePointer->DstArrayElement; }
            set { NativePointer->DstArrayElement = value; }
        }
        
        /// <summary>
        /// Number of descriptors to write (determines the size of the array pointed by pDescriptors)
        /// </summary>
        public UInt32 DescriptorCount
        {
            get { return NativePointer->DescriptorCount; }
            set { NativePointer->DescriptorCount = value; }
        }
        
        public CopyDescriptorSet()
        {
            NativePointer = (Interop.CopyDescriptorSet*)MemoryUtils.Allocate(typeof(Interop.CopyDescriptorSet));
            NativePointer->SType = StructureType.CopyDescriptorSet;
        }
        
        public CopyDescriptorSet(DescriptorSet SrcSet, UInt32 SrcBinding, UInt32 SrcArrayElement, DescriptorSet DstSet, UInt32 DstBinding, UInt32 DstArrayElement, UInt32 DescriptorCount) : this()
        {
            this.SrcSet = SrcSet;
            this.SrcBinding = SrcBinding;
            this.SrcArrayElement = SrcArrayElement;
            this.DstSet = DstSet;
            this.DstBinding = DstBinding;
            this.DstArrayElement = DstArrayElement;
            this.DescriptorCount = DescriptorCount;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.CopyDescriptorSet*)IntPtr.Zero;
        }
    }
}
