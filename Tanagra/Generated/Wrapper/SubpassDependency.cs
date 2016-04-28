using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubpassDependency
    {
        internal Interop.SubpassDependency* NativePointer;
        
        public UInt32 SrcSubpass
        {
            get { return NativePointer->SrcSubpass; }
            set { NativePointer->SrcSubpass = value; }
        }
        
        public UInt32 DstSubpass
        {
            get { return NativePointer->DstSubpass; }
            set { NativePointer->DstSubpass = value; }
        }
        
        public PipelineStageFlags SrcStageMask
        {
            get { return NativePointer->SrcStageMask; }
            set { NativePointer->SrcStageMask = value; }
        }
        
        public PipelineStageFlags DstStageMask
        {
            get { return NativePointer->DstStageMask; }
            set { NativePointer->DstStageMask = value; }
        }
        
        public AccessFlags SrcAccessMask
        {
            get { return NativePointer->SrcAccessMask; }
            set { NativePointer->SrcAccessMask = value; }
        }
        
        public AccessFlags DstAccessMask
        {
            get { return NativePointer->DstAccessMask; }
            set { NativePointer->DstAccessMask = value; }
        }
        
        public DependencyFlags DependencyFlags
        {
            get { return NativePointer->DependencyFlags; }
            set { NativePointer->DependencyFlags = value; }
        }
        
        public SubpassDependency()
        {
            NativePointer = (Interop.SubpassDependency*)Interop.Structure.Allocate(typeof(Interop.SubpassDependency));
        }
    }
}
