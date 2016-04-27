using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class RenderPassCreateInfo
    {
        internal Interop.RenderPassCreateInfo* NativeHandle;
        
        public RenderPassCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 AttachmentCount
        {
            get { return NativeHandle->AttachmentCount; }
            set { NativeHandle->AttachmentCount = value; }
        }
        
        AttachmentDescription _Attachments;
        public AttachmentDescription Attachments
        {
            get { return _Attachments; }
            set { _Attachments = value; NativeHandle->Attachments = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 SubpassCount
        {
            get { return NativeHandle->SubpassCount; }
            set { NativeHandle->SubpassCount = value; }
        }
        
        SubpassDescription _Subpasses;
        public SubpassDescription Subpasses
        {
            get { return _Subpasses; }
            set { _Subpasses = value; NativeHandle->Subpasses = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 DependencyCount
        {
            get { return NativeHandle->DependencyCount; }
            set { NativeHandle->DependencyCount = value; }
        }
        
        SubpassDependency _Dependencies;
        public SubpassDependency Dependencies
        {
            get { return _Dependencies; }
            set { _Dependencies = value; NativeHandle->Dependencies = (IntPtr)value.NativeHandle; }
        }
        
        public RenderPassCreateInfo()
        {
            NativeHandle = (Interop.RenderPassCreateInfo*)Interop.Structure.Allocate(typeof(Interop.RenderPassCreateInfo));
            //NativeHandle->SType = StructureType.RenderPassCreateInfo;
        }
    }
}
