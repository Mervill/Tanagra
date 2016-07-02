using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class PipelineRasterizationStateRasterizationOrderAMD : IDisposable
    {
        internal Unmanaged.PipelineRasterizationStateRasterizationOrderAMD* NativePointer { get; private set; }
        
        /// <summary>
        /// Rasterization order to use for the pipeline
        /// </summary>
        public RasterizationOrderAMD RasterizationOrder
        {
            get { return NativePointer->RasterizationOrder; }
            set { NativePointer->RasterizationOrder = value; }
        }
        
        public PipelineRasterizationStateRasterizationOrderAMD()
        {
            NativePointer = (Unmanaged.PipelineRasterizationStateRasterizationOrderAMD*)MemUtil.Alloc(typeof(Unmanaged.PipelineRasterizationStateRasterizationOrderAMD));
            NativePointer->SType = StructureType.PipelineRasterizationStateRasterizationOrderAMD;
        }
        
        internal PipelineRasterizationStateRasterizationOrderAMD(Unmanaged.PipelineRasterizationStateRasterizationOrderAMD* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.PipelineRasterizationStateRasterizationOrderAMD));
        }
        
        /// <param name="RasterizationOrder">Rasterization order to use for the pipeline</param>
        public PipelineRasterizationStateRasterizationOrderAMD(RasterizationOrderAMD RasterizationOrder) : this()
        {
            this.RasterizationOrder = RasterizationOrder;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineRasterizationStateRasterizationOrderAMD()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
