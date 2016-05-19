using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SubpassDescription
    {
        internal Unmanaged.SubpassDescription* NativePointer;
        
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
                if(NativePointer->InputAttachments == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->InputAttachmentCount;
                var valueArray = new AttachmentReference[valueCount];
                var ptr = (AttachmentReference*)NativePointer->InputAttachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<AttachmentReference>() * valueCount;
                    if(NativePointer->InputAttachments != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->InputAttachments, (IntPtr)typeSize);
                    
                    if(NativePointer->InputAttachments == IntPtr.Zero)
                        NativePointer->InputAttachments = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->InputAttachmentCount = (UInt32)valueCount;
                    var ptr = (AttachmentReference*)NativePointer->InputAttachments;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->InputAttachments != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->InputAttachments);
                    
                    NativePointer->InputAttachments = IntPtr.Zero;
                    NativePointer->InputAttachmentCount = 0;
                }
            }
        }
        
        public AttachmentReference[] ColorAttachments
        {
            get
            {
                if(NativePointer->ColorAttachments == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->ColorAttachmentCount;
                var valueArray = new AttachmentReference[valueCount];
                var ptr = (AttachmentReference*)NativePointer->ColorAttachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<AttachmentReference>() * valueCount;
                    if(NativePointer->ColorAttachments != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ColorAttachments, (IntPtr)typeSize);
                    
                    if(NativePointer->ColorAttachments == IntPtr.Zero)
                        NativePointer->ColorAttachments = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->ColorAttachmentCount = (UInt32)valueCount;
                    var ptr = (AttachmentReference*)NativePointer->ColorAttachments;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->ColorAttachments != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->ColorAttachments);
                    
                    NativePointer->ColorAttachments = IntPtr.Zero;
                    NativePointer->ColorAttachmentCount = 0;
                }
            }
        }
        
        public AttachmentReference[] ResolveAttachments
        {
            get
            {
                if(NativePointer->ResolveAttachments == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->ColorAttachmentCount;
                var valueArray = new AttachmentReference[valueCount];
                var ptr = (AttachmentReference*)NativePointer->ResolveAttachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<AttachmentReference>() * valueCount;
                    if(NativePointer->ResolveAttachments != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->ResolveAttachments, (IntPtr)typeSize);
                    
                    if(NativePointer->ResolveAttachments == IntPtr.Zero)
                        NativePointer->ResolveAttachments = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->ColorAttachmentCount = (UInt32)valueCount;
                    var ptr = (AttachmentReference*)NativePointer->ResolveAttachments;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->ResolveAttachments != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->ResolveAttachments);
                    
                    NativePointer->ResolveAttachments = IntPtr.Zero;
                    NativePointer->ColorAttachmentCount = 0;
                }
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
                if(NativePointer->PreserveAttachments == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->PreserveAttachmentCount;
                var valueArray = new UInt32[valueCount];
                var ptr = (UInt32*)NativePointer->PreserveAttachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<UInt32>() * valueCount;
                    if(NativePointer->PreserveAttachments != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->PreserveAttachments, (IntPtr)typeSize);
                    
                    if(NativePointer->PreserveAttachments == IntPtr.Zero)
                        NativePointer->PreserveAttachments = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->PreserveAttachmentCount = (UInt32)valueCount;
                    var ptr = (UInt32*)NativePointer->PreserveAttachments;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->PreserveAttachments != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->PreserveAttachments);
                    
                    NativePointer->PreserveAttachments = IntPtr.Zero;
                    NativePointer->PreserveAttachmentCount = 0;
                }
            }
        }
        
        public SubpassDescription()
        {
            NativePointer = (Unmanaged.SubpassDescription*)MemoryUtils.Allocate(typeof(Unmanaged.SubpassDescription));
        }
        
        public SubpassDescription(PipelineBindPoint PipelineBindPoint, AttachmentReference[] InputAttachments, AttachmentReference[] ColorAttachments, UInt32[] PreserveAttachments) : this()
        {
            this.PipelineBindPoint = PipelineBindPoint;
            this.InputAttachments = InputAttachments;
            this.ColorAttachments = ColorAttachments;
            this.PreserveAttachments = PreserveAttachments;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.SubpassDescription*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
