using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineRasterizationStateRasterizationOrderAMD
    {
        internal Interop.PipelineRasterizationStateRasterizationOrderAMD* NativePointer;
        
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
            NativePointer = (Interop.PipelineRasterizationStateRasterizationOrderAMD*)MemoryUtils.Allocate(typeof(Interop.PipelineRasterizationStateRasterizationOrderAMD));
            NativePointer->SType = StructureType.PipelineRasterizationStateRasterizationOrderAMD;
        }
        
        public PipelineRasterizationStateRasterizationOrderAMD(RasterizationOrderAMD RasterizationOrder) : this()
        {
            this.RasterizationOrder = RasterizationOrder;
        }
    }
}
