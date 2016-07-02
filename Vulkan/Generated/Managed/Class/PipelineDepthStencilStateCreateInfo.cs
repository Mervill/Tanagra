using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PipelineDepthStencilStateCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineDepthStencilStateCreateInfo* NativePointer { get; private set; }
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineDepthStencilStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public Bool32 DepthTestEnable
        {
            get { return NativePointer->DepthTestEnable; }
            set { NativePointer->DepthTestEnable = value; }
        }
        
        public Bool32 DepthWriteEnable
        {
            get { return NativePointer->DepthWriteEnable; }
            set { NativePointer->DepthWriteEnable = value; }
        }
        
        public CompareOp DepthCompareOp
        {
            get { return NativePointer->DepthCompareOp; }
            set { NativePointer->DepthCompareOp = value; }
        }
        
        /// <summary>
        /// Optional (depth_bounds_test)
        /// </summary>
        public Bool32 DepthBoundsTestEnable
        {
            get { return NativePointer->DepthBoundsTestEnable; }
            set { NativePointer->DepthBoundsTestEnable = value; }
        }
        
        public Bool32 StencilTestEnable
        {
            get { return NativePointer->StencilTestEnable; }
            set { NativePointer->StencilTestEnable = value; }
        }
        
        public StencilOpState Front
        {
            get { return NativePointer->Front; }
            set { NativePointer->Front = value; }
        }
        
        public StencilOpState Back
        {
            get { return NativePointer->Back; }
            set { NativePointer->Back = value; }
        }
        
        public Single MinDepthBounds
        {
            get { return NativePointer->MinDepthBounds; }
            set { NativePointer->MinDepthBounds = value; }
        }
        
        public Single MaxDepthBounds
        {
            get { return NativePointer->MaxDepthBounds; }
            set { NativePointer->MaxDepthBounds = value; }
        }
        
        public PipelineDepthStencilStateCreateInfo()
        {
            NativePointer = (Unmanaged.PipelineDepthStencilStateCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.PipelineDepthStencilStateCreateInfo));
            NativePointer->SType = StructureType.PipelineDepthStencilStateCreateInfo;
        }
        
        internal PipelineDepthStencilStateCreateInfo(Unmanaged.PipelineDepthStencilStateCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.PipelineDepthStencilStateCreateInfo));
        }
        
        /// <param name="DepthBoundsTestEnable">Optional (depth_bounds_test)</param>
        public PipelineDepthStencilStateCreateInfo(Bool32 DepthTestEnable, Bool32 DepthWriteEnable, CompareOp DepthCompareOp, Bool32 DepthBoundsTestEnable, Bool32 StencilTestEnable, StencilOpState Front, StencilOpState Back, Single MinDepthBounds, Single MaxDepthBounds) : this()
        {
            this.DepthTestEnable = DepthTestEnable;
            this.DepthWriteEnable = DepthWriteEnable;
            this.DepthCompareOp = DepthCompareOp;
            this.DepthBoundsTestEnable = DepthBoundsTestEnable;
            this.StencilTestEnable = StencilTestEnable;
            this.Front = Front;
            this.Back = Back;
            this.MinDepthBounds = MinDepthBounds;
            this.MaxDepthBounds = MaxDepthBounds;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineDepthStencilStateCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
