using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FramebufferCreateInfo
    {
        internal Interop.FramebufferCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public FramebufferCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativePointer->RenderPass = value.NativePointer; }
        }
        
        public ImageView[] Attachments
        {
            get
            {
                if(NativePointer->Attachments == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->AttachmentCount;
                var valueArray = new ImageView[valueCount];
                var ptr = (UInt64*)NativePointer->Attachments;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new ImageView { NativePointer = ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->Attachments != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Attachments, (IntPtr)typeSize);
                    
                    if(NativePointer->Attachments == IntPtr.Zero)
                        NativePointer->Attachments = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->AttachmentCount = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->Attachments;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (IntPtr)value[x].NativePointer;
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
        
        public UInt32 Width
        {
            get { return NativePointer->Width; }
            set { NativePointer->Width = value; }
        }
        
        public UInt32 Height
        {
            get { return NativePointer->Height; }
            set { NativePointer->Height = value; }
        }
        
        public UInt32 Layers
        {
            get { return NativePointer->Layers; }
            set { NativePointer->Layers = value; }
        }
        
        public FramebufferCreateInfo()
        {
            NativePointer = (Interop.FramebufferCreateInfo*)MemoryUtils.Allocate(typeof(Interop.FramebufferCreateInfo));
            NativePointer->SType = StructureType.FramebufferCreateInfo;
        }
        
        public FramebufferCreateInfo(RenderPass RenderPass, ImageView[] Attachments, UInt32 Width, UInt32 Height, UInt32 Layers) : this()
        {
            this.RenderPass = RenderPass;
            this.Attachments = Attachments;
            this.Width = Width;
            this.Height = Height;
            this.Layers = Layers;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.FramebufferCreateInfo*)IntPtr.Zero;
        }
    }
}
