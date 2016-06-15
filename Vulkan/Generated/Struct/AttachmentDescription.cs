using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AttachmentDescription
    {
        public AttachmentDescriptionFlags Flags;
        public Format Format;
        public SampleCountFlags Samples;
        /// <summary>
        /// Load operation for color or depth data
        /// </summary>
        public AttachmentLoadOp LoadOp;
        /// <summary>
        /// Store operation for color or depth data
        /// </summary>
        public AttachmentStoreOp StoreOp;
        /// <summary>
        /// Load operation for stencil data
        /// </summary>
        public AttachmentLoadOp StencilLoadOp;
        /// <summary>
        /// Store operation for stencil data
        /// </summary>
        public AttachmentStoreOp StencilStoreOp;
        public ImageLayout InitialLayout;
        public ImageLayout FinalLayout;
        
        /// <param name="LoadOp">Load operation for color or depth data</param>
        /// <param name="StoreOp">Store operation for color or depth data</param>
        /// <param name="StencilLoadOp">Load operation for stencil data</param>
        /// <param name="StencilStoreOp">Store operation for stencil data</param>
        public AttachmentDescription(Format Format, SampleCountFlags Samples, AttachmentLoadOp LoadOp, AttachmentStoreOp StoreOp, AttachmentLoadOp StencilLoadOp, AttachmentStoreOp StencilStoreOp, ImageLayout InitialLayout, ImageLayout FinalLayout)
        {
            this.Format = Format;
            this.Samples = Samples;
            this.LoadOp = LoadOp;
            this.StoreOp = StoreOp;
            this.StencilLoadOp = StencilLoadOp;
            this.StencilStoreOp = StencilStoreOp;
            this.InitialLayout = InitialLayout;
            this.FinalLayout = FinalLayout;
            Flags = default(AttachmentDescriptionFlags);
        }
    }
}
