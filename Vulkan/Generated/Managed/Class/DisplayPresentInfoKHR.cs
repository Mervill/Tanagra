using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class DisplayPresentInfoKHR : IDisposable
    {
        internal Unmanaged.DisplayPresentInfoKHR* NativePointer { get; private set; }
        
        /// <summary>
        /// Rectangle within the presentable image to read pixel data from when presenting to the display.
        /// </summary>
        public Rect2D SrcRect
        {
            get { return NativePointer->SrcRect; }
            set { NativePointer->SrcRect = value; }
        }
        
        /// <summary>
        /// Rectangle within the current display mode's visible region to display srcRectangle in.
        /// </summary>
        public Rect2D DstRect
        {
            get { return NativePointer->DstRect; }
            set { NativePointer->DstRect = value; }
        }
        
        /// <summary>
        /// For smart displays, use buffered mode. If the display properties member "persistentMode" is VK_FALSE, this member must always be VK_FALSE.
        /// </summary>
        public Bool32 Persistent
        {
            get { return NativePointer->Persistent; }
            set { NativePointer->Persistent = value; }
        }
        
        public DisplayPresentInfoKHR()
        {
            NativePointer = (Unmanaged.DisplayPresentInfoKHR*)MemUtil.Alloc(typeof(Unmanaged.DisplayPresentInfoKHR));
            NativePointer->SType = StructureType.DisplayPresentInfoKHR;
        }
        
        internal DisplayPresentInfoKHR(Unmanaged.DisplayPresentInfoKHR* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.DisplayPresentInfoKHR));
        }
        
        /// <param name="SrcRect">Rectangle within the presentable image to read pixel data from when presenting to the display.</param>
        /// <param name="DstRect">Rectangle within the current display mode's visible region to display srcRectangle in.</param>
        /// <param name="Persistent">For smart displays, use buffered mode. If the display properties member "persistentMode" is VK_FALSE, this member must always be VK_FALSE.</param>
        public DisplayPresentInfoKHR(Rect2D SrcRect, Rect2D DstRect, Bool32 Persistent) : this()
        {
            this.SrcRect = SrcRect;
            this.DstRect = DstRect;
            this.Persistent = Persistent;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DisplayPresentInfoKHR()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
