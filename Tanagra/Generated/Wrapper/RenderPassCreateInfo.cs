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
                var valueCount = NativePointer->AttachmentCount;
                var valueArray = new AttachmentDescription[valueCount];
                var ptr = (AttachmentDescription*)NativePointer->Attachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->AttachmentCount = (uint)valueCount;
                NativePointer->Attachments = Marshal.AllocHGlobal(Marshal.SizeOf<AttachmentDescription>() * valueCount);
                var ptr = (AttachmentDescription*)NativePointer->Attachments;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
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
                var valueCount = NativePointer->SubpassCount;
                var valueArray = new SubpassDescription[valueCount];
                var ptr = (Interop.SubpassDescription*)NativePointer->Subpasses;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SubpassDescription { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->SubpassCount = (uint)valueCount;
                NativePointer->Subpasses = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SubpassDescription>() * valueCount);
                var ptr = (Interop.SubpassDescription*)NativePointer->Subpasses;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
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
                var valueCount = NativePointer->DependencyCount;
                var valueArray = new SubpassDependency[valueCount];
                var ptr = (SubpassDependency*)NativePointer->Dependencies;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->DependencyCount = (uint)valueCount;
                NativePointer->Dependencies = Marshal.AllocHGlobal(Marshal.SizeOf<SubpassDependency>() * valueCount);
                var ptr = (SubpassDependency*)NativePointer->Dependencies;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public RenderPassCreateInfo()
        {
            NativePointer = (Interop.RenderPassCreateInfo*)Interop.Structure.Allocate(typeof(Interop.RenderPassCreateInfo));
            NativePointer->SType = StructureType.RenderPassCreateInfo;
        }
        
        public RenderPassCreateInfo(AttachmentDescription[] Attachments, UInt32 SubpassCount, SubpassDescription[] Subpasses, SubpassDependency[] Dependencies) : this()
        {
            this.Attachments = Attachments;
            this.SubpassCount = SubpassCount;
            this.Subpasses = Subpasses;
            this.Dependencies = Dependencies;
        }
    }
}
