using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class RenderPassCreateInfo : IDisposable
    {
        internal Unmanaged.RenderPassCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
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
                if(NativePointer->Attachments == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->AttachmentCount;
                var valueArray = new AttachmentDescription[valueCount];
                var ptr = (AttachmentDescription*)NativePointer->Attachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(AttachmentDescription)) * valueCount;
                    if(NativePointer->Attachments != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Attachments, (IntPtr)typeSize);
                    
                    if(NativePointer->Attachments == IntPtr.Zero)
                        NativePointer->Attachments = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->AttachmentCount = (UInt32)valueCount;
                    var ptr = (AttachmentDescription*)NativePointer->Attachments;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->Attachments != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Attachments);
                    
                    NativePointer->Attachments = IntPtr.Zero;
                    NativePointer->AttachmentCount = 0;
                }
            }
        }
        
        public SubpassDescription[] Subpasses
        {
            get
            {
                if(NativePointer->Subpasses == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->SubpassCount;
                var valueArray = new SubpassDescription[valueCount];
                var ptr = (Unmanaged.SubpassDescription*)NativePointer->Subpasses;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SubpassDescription { NativePointer = &ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(Unmanaged.SubpassDescription)) * valueCount;
                    if(NativePointer->Subpasses != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Subpasses, (IntPtr)typeSize);
                    
                    if(NativePointer->Subpasses == IntPtr.Zero)
                        NativePointer->Subpasses = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->SubpassCount = (UInt32)valueCount;
                    var ptr = (Unmanaged.SubpassDescription*)NativePointer->Subpasses;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->Subpasses != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Subpasses);
                    
                    NativePointer->Subpasses = IntPtr.Zero;
                    NativePointer->SubpassCount = 0;
                }
            }
        }
        
        public SubpassDependency[] Dependencies
        {
            get
            {
                if(NativePointer->Dependencies == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->DependencyCount;
                var valueArray = new SubpassDependency[valueCount];
                var ptr = (SubpassDependency*)NativePointer->Dependencies;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(SubpassDependency)) * valueCount;
                    if(NativePointer->Dependencies != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Dependencies, (IntPtr)typeSize);
                    
                    if(NativePointer->Dependencies == IntPtr.Zero)
                        NativePointer->Dependencies = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DependencyCount = (UInt32)valueCount;
                    var ptr = (SubpassDependency*)NativePointer->Dependencies;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->Dependencies != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Dependencies);
                    
                    NativePointer->Dependencies = IntPtr.Zero;
                    NativePointer->DependencyCount = 0;
                }
            }
        }
        
        public RenderPassCreateInfo()
        {
            NativePointer = (Unmanaged.RenderPassCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.RenderPassCreateInfo));
            NativePointer->SType = StructureType.RenderPassCreateInfo;
        }
        
        public RenderPassCreateInfo(AttachmentDescription[] Attachments, SubpassDescription[] Subpasses, SubpassDependency[] Dependencies) : this()
        {
            this.Attachments = Attachments;
            this.Subpasses = Subpasses;
            this.Dependencies = Dependencies;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->Attachments);
            Marshal.FreeHGlobal(NativePointer->Subpasses);
            Marshal.FreeHGlobal(NativePointer->Dependencies);
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~RenderPassCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->Attachments);
                Marshal.FreeHGlobal(NativePointer->Subpasses);
                Marshal.FreeHGlobal(NativePointer->Dependencies);
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
