using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubpassDependency
    {
        internal Interop.SubpassDependency* NativeHandle;
        
        public UInt32 SrcSubpass
        {
            get { return NativeHandle->SrcSubpass; }
            set { NativeHandle->SrcSubpass = value; }
        }
        
        public UInt32 DstSubpass
        {
            get { return NativeHandle->DstSubpass; }
            set { NativeHandle->DstSubpass = value; }
        }
        
        public PipelineStageFlags SrcStageMask
        {
            get { return NativeHandle->SrcStageMask; }
            set { NativeHandle->SrcStageMask = value; }
        }
        
        public PipelineStageFlags DstStageMask
        {
            get { return NativeHandle->DstStageMask; }
            set { NativeHandle->DstStageMask = value; }
        }
        
        public AccessFlags SrcAccessMask
        {
            get { return NativeHandle->SrcAccessMask; }
            set { NativeHandle->SrcAccessMask = value; }
        }
        
        public AccessFlags DstAccessMask
        {
            get { return NativeHandle->DstAccessMask; }
            set { NativeHandle->DstAccessMask = value; }
        }
        
        public DependencyFlags DependencyFlags
        {
            get { return NativeHandle->DependencyFlags; }
            set { NativeHandle->DependencyFlags = value; }
        }
        
        public SubpassDependency()
        {
            NativeHandle = (Interop.SubpassDependency*)Interop.Structure.Allocate(typeof(Interop.SubpassDependency));
        }
    }
}
