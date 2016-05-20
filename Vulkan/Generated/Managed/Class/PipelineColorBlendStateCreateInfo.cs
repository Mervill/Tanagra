using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PipelineColorBlendStateCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineColorBlendStateCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineColorBlendStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public Bool32 LogicOpEnable
        {
            get { return NativePointer->LogicOpEnable; }
            set { NativePointer->LogicOpEnable = value; }
        }
        
        public LogicOp LogicOp
        {
            get { return NativePointer->LogicOp; }
            set { NativePointer->LogicOp = value; }
        }
        
        public PipelineColorBlendAttachmentState[] Attachments
        {
            get
            {
                if(NativePointer->Attachments == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->AttachmentCount;
                var valueArray = new PipelineColorBlendAttachmentState[valueCount];
                var ptr = (PipelineColorBlendAttachmentState*)NativePointer->Attachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<PipelineColorBlendAttachmentState>() * valueCount;
                    if(NativePointer->Attachments != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Attachments, (IntPtr)typeSize);
                    
                    if(NativePointer->Attachments == IntPtr.Zero)
                        NativePointer->Attachments = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->AttachmentCount = (UInt32)valueCount;
                    var ptr = (PipelineColorBlendAttachmentState*)NativePointer->Attachments;
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
        
        public Single[] BlendConstants
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
            set
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public PipelineColorBlendStateCreateInfo()
        {
            NativePointer = (Unmanaged.PipelineColorBlendStateCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.PipelineColorBlendStateCreateInfo));
            NativePointer->SType = StructureType.PipelineColorBlendStateCreateInfo;
        }
        
        public PipelineColorBlendStateCreateInfo(Bool32 LogicOpEnable, LogicOp LogicOp, PipelineColorBlendAttachmentState[] Attachments, Single[] BlendConstants) : this()
        {
            this.LogicOpEnable = LogicOpEnable;
            this.LogicOp = LogicOp;
            this.Attachments = Attachments;
            this.BlendConstants = BlendConstants;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->Attachments);
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.PipelineColorBlendStateCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineColorBlendStateCreateInfo()
        {
            if(NativePointer != (Unmanaged.PipelineColorBlendStateCreateInfo*)IntPtr.Zero)
            {
                Marshal.FreeHGlobal(NativePointer->Attachments);
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.PipelineColorBlendStateCreateInfo*)IntPtr.Zero;
            }
        }
    }
}
