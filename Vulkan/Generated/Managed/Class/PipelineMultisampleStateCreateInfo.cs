using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// [<see cref="IExtensible"/>: None]
    /// </summary>
    unsafe public class PipelineMultisampleStateCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineMultisampleStateCreateInfo* NativePointer { get; private set; }
        
        /// <summary>
        /// Reserved (Optional)
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
        /// Array of sampleMask words (Optional)
        /// </summary>
        public SampleMask[] SampleMask
        {
            get
            {
                throw new NotImplementedException("Latexmath");
            }
            set
            {
                throw new NotImplementedException("Latexmath");
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
            NativePointer = (Unmanaged.PipelineMultisampleStateCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.PipelineMultisampleStateCreateInfo));
            NativePointer->SType = StructureType.PipelineMultisampleStateCreateInfo;
        }
        
        internal PipelineMultisampleStateCreateInfo(Unmanaged.PipelineMultisampleStateCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.PipelineMultisampleStateCreateInfo));
        }
        
        /// <param name="RasterizationSamples">Number of samples used for rasterization</param>
        /// <param name="SampleShadingEnable">Optional (GL45)</param>
        /// <param name="MinSampleShading">Optional (GL45)</param>
        public PipelineMultisampleStateCreateInfo(SampleCountFlags RasterizationSamples, Bool32 SampleShadingEnable, Single MinSampleShading, Bool32 AlphaToCoverageEnable, Bool32 AlphaToOneEnable) : this()
        {
            this.RasterizationSamples = RasterizationSamples;
            this.SampleShadingEnable = SampleShadingEnable;
            this.MinSampleShading = MinSampleShading;
            this.AlphaToCoverageEnable = AlphaToCoverageEnable;
            this.AlphaToOneEnable = AlphaToOneEnable;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->SampleMask);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineMultisampleStateCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->SampleMask);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
