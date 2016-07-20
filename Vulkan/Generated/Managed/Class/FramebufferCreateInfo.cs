using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class FramebufferCreateInfo : IDisposable
    {
        internal Unmanaged.FramebufferCreateInfo* NativePointer { get; private set; }
        
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
                    valueArray[x] = new ImageView(ptr[x]);
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(UInt64)) * valueCount;
                    if(NativePointer->Attachments != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Attachments, (IntPtr)typeSize);
                    
                    if(NativePointer->Attachments == IntPtr.Zero)
                        NativePointer->Attachments = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->AttachmentCount = (UInt32)valueCount;
                    var ptr = (UInt64*)NativePointer->Attachments;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x].NativePointer;
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
            NativePointer = (Unmanaged.FramebufferCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.FramebufferCreateInfo));
            NativePointer->SType = StructureType.FramebufferCreateInfo;
        }
        
        internal FramebufferCreateInfo(Unmanaged.FramebufferCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.FramebufferCreateInfo));
        }
        
        public FramebufferCreateInfo(RenderPass RenderPass, ImageView[] Attachments, UInt32 Width, UInt32 Height, UInt32 Layers) : this()
        {
            this.RenderPass = RenderPass;
            this.Attachments = Attachments;
            this.Width = Width;
            this.Height = Height;
            this.Layers = Layers;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->Attachments);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~FramebufferCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->Attachments);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
