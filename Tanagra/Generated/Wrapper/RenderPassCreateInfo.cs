using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class RenderPassCreateInfo
    {
        internal Interop.RenderPassCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved
        /// </summary>
        public RenderPassCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
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
                NativePointer->AttachmentCount = (UInt32)valueCount;
                NativePointer->Attachments = Marshal.AllocHGlobal(Marshal.SizeOf<AttachmentDescription>() * valueCount);
                var ptr = (AttachmentDescription*)NativePointer->Attachments;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
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
                NativePointer->SubpassCount = (UInt32)valueCount;
                NativePointer->Subpasses = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SubpassDescription>() * valueCount);
                var ptr = (Interop.SubpassDescription*)NativePointer->Subpasses;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
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
                NativePointer->DependencyCount = (UInt32)valueCount;
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
        
        public RenderPassCreateInfo(AttachmentDescription[] Attachments, SubpassDescription[] Subpasses, SubpassDependency[] Dependencies) : this()
        {
            this.Attachments = Attachments;
            this.Subpasses = Subpasses;
            this.Dependencies = Dependencies;
        }
    }
}
