using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubpassDescription
    {
        internal Interop.SubpassDescription* NativePointer;
        
        public SubpassDescriptionFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Must be VK_PIPELINE_BIND_POINT_GRAPHICS for now
        /// </summary>
        public PipelineBindPoint PipelineBindPoint
        {
            get { return NativePointer->PipelineBindPoint; }
            set { NativePointer->PipelineBindPoint = value; }
        }
        
        public AttachmentReference[] InputAttachments
        {
            get
            {
                var valueCount = NativePointer->InputAttachmentCount;
                var valueArray = new AttachmentReference[valueCount];
                var ptr = (AttachmentReference*)NativePointer->InputAttachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->InputAttachmentCount = (UInt32)valueCount;
                NativePointer->InputAttachments = Marshal.AllocHGlobal(Marshal.SizeOf<AttachmentReference>() * valueCount);
                var ptr = (AttachmentReference*)NativePointer->InputAttachments;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public AttachmentReference[] ColorAttachments
        {
            get
            {
                var valueCount = NativePointer->ColorAttachmentCount;
                var valueArray = new AttachmentReference[valueCount];
                var ptr = (AttachmentReference*)NativePointer->ColorAttachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->ColorAttachmentCount = (UInt32)valueCount;
                NativePointer->ColorAttachments = Marshal.AllocHGlobal(Marshal.SizeOf<AttachmentReference>() * valueCount);
                var ptr = (AttachmentReference*)NativePointer->ColorAttachments;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public AttachmentReference[] ResolveAttachments
        {
            get
            {
                var valueCount = NativePointer->ColorAttachmentCount;
                var valueArray = new AttachmentReference[valueCount];
                var ptr = (AttachmentReference*)NativePointer->ResolveAttachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->ColorAttachmentCount = (UInt32)valueCount;
                NativePointer->ResolveAttachments = Marshal.AllocHGlobal(Marshal.SizeOf<AttachmentReference>() * valueCount);
                var ptr = (AttachmentReference*)NativePointer->ResolveAttachments;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        AttachmentReference _DepthStencilAttachment;
        public AttachmentReference DepthStencilAttachment
        {
            get { return _DepthStencilAttachment; }
            set { _DepthStencilAttachment = value; NativePointer->DepthStencilAttachment = (IntPtr)(&value); }
        }
        
        public UInt32[] PreserveAttachments
        {
            get
            {
                var valueCount = NativePointer->PreserveAttachmentCount;
                var valueArray = new UInt32[valueCount];
                var ptr = (UInt32*)NativePointer->PreserveAttachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->PreserveAttachmentCount = (UInt32)valueCount;
                NativePointer->PreserveAttachments = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * valueCount);
                var ptr = (UInt32*)NativePointer->PreserveAttachments;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public SubpassDescription()
        {
            NativePointer = (Interop.SubpassDescription*)Interop.Structure.Allocate(typeof(Interop.SubpassDescription));
        }
        
        public SubpassDescription(PipelineBindPoint PipelineBindPoint, AttachmentReference[] InputAttachments, AttachmentReference[] ColorAttachments, UInt32[] PreserveAttachments) : this()
        {
            this.PipelineBindPoint = PipelineBindPoint;
            this.InputAttachments = InputAttachments;
            this.ColorAttachments = ColorAttachments;
            this.PreserveAttachments = PreserveAttachments;
        }
    }
}
