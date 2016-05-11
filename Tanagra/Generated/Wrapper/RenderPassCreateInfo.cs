using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class RenderPassCreateInfo
    {
        internal Interop.RenderPassCreateInfo* NativePointer;
        
        public RenderPassCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 AttachmentCount
        {
            get { return NativePointer->AttachmentCount; }
            set { NativePointer->AttachmentCount = value; }
        }
        
        public AttachmentDescription[] Attachments
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public UInt32 SubpassCount
        {
            get { return NativePointer->SubpassCount; }
            set { NativePointer->SubpassCount = value; }
        }
        
        public SubpassDescription[] Subpasses
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public UInt32 DependencyCount
        {
            get { return NativePointer->DependencyCount; }
            set { NativePointer->DependencyCount = value; }
        }
        
        public SubpassDependency[] Dependencies
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public RenderPassCreateInfo()
        {
            NativePointer = (Interop.RenderPassCreateInfo*)Interop.Structure.Allocate(typeof(Interop.RenderPassCreateInfo));
            NativePointer->SType = StructureType.RenderPassCreateInfo;
        }
    }
}
