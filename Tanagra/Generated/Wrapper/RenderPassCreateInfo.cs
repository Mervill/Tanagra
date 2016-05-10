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
        
        public AttachmentDescription Attachments
        {
            get { return Marshal.PtrToStructure<AttachmentDescription>(NativePointer->Attachments); }
            set
            {
                if(NativePointer->Attachments == IntPtr.Zero)
                    NativePointer->Attachments = Interop.Structure.Allocate(typeof(AttachmentDescription));

                Marshal.StructureToPtr(value, NativePointer->Attachments, false);
            }
        }
        
        public UInt32 SubpassCount
        {
            get { return NativePointer->SubpassCount; }
            set { NativePointer->SubpassCount = value; }
        }
        
        SubpassDescription _Subpasses;
        public SubpassDescription Subpasses
        {
            get { return _Subpasses; }
            set { _Subpasses = value; NativePointer->Subpasses = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 DependencyCount
        {
            get { return NativePointer->DependencyCount; }
            set { NativePointer->DependencyCount = value; }
        }
        
        public SubpassDependency Dependencies
        {
            get { return Marshal.PtrToStructure<SubpassDependency>(NativePointer->Dependencies); }
            set { NativePointer->Dependencies = (IntPtr)(&value); }
        }
        
        public RenderPassCreateInfo()
        {
            NativePointer = (Interop.RenderPassCreateInfo*)Interop.Structure.Allocate(typeof(Interop.RenderPassCreateInfo));
            NativePointer->SType = StructureType.RenderPassCreateInfo;
        }
    }
}
