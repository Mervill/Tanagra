using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineMultisampleStateCreateInfo
    {
        internal Interop.PipelineMultisampleStateCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved
        /// </summary>
        public PipelineMultisampleStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Number of samples used for rasterization
        /// </summary>
        public SampleCountFlags RasterizationSamples
        {
            get { return NativePointer->RasterizationSamples; }
            set { NativePointer->RasterizationSamples = value; }
        }
        
        /// <summary>
        /// Optional (GL45)
        /// </summary>
        public Bool32 SampleShadingEnable
        {
            get { return NativePointer->SampleShadingEnable; }
            set { NativePointer->SampleShadingEnable = value; }
        }
        
        /// <summary>
        /// Optional (GL45)
        /// </summary>
        public Single MinSampleShading
        {
            get { return NativePointer->MinSampleShading; }
            set { NativePointer->MinSampleShading = value; }
        }
        
        /// <summary>
        /// Array of sampleMask words
        /// </summary>
        public SampleMask[] SampleMask
        {
            get
            {
                throw new System.NotImplementedException("Latexmath");
            }
            set
            {
                throw new System.NotImplementedException("Latexmath");
            }
        }
        
        public Bool32 AlphaToCoverageEnable
        {
            get { return NativePointer->AlphaToCoverageEnable; }
            set { NativePointer->AlphaToCoverageEnable = value; }
        }
        
        public Bool32 AlphaToOneEnable
        {
            get { return NativePointer->AlphaToOneEnable; }
            set { NativePointer->AlphaToOneEnable = value; }
        }
        
        public PipelineMultisampleStateCreateInfo()
        {
            NativePointer = (Interop.PipelineMultisampleStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineMultisampleStateCreateInfo));
            NativePointer->SType = StructureType.PipelineMultisampleStateCreateInfo;
        }
        
        public PipelineMultisampleStateCreateInfo(SampleCountFlags RasterizationSamples, Bool32 SampleShadingEnable, Single MinSampleShading, Bool32 AlphaToCoverageEnable, Bool32 AlphaToOneEnable) : this()
        {
            this.RasterizationSamples = RasterizationSamples;
            this.SampleShadingEnable = SampleShadingEnable;
            this.MinSampleShading = MinSampleShading;
            this.AlphaToCoverageEnable = AlphaToCoverageEnable;
            this.AlphaToOneEnable = AlphaToOneEnable;
        }
    }
}
