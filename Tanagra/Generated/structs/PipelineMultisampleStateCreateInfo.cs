using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineMultisampleStateCreateInfo
    {
        internal Interop.PipelineMultisampleStateCreateInfo* NativeHandle;
        
        public PipelineMultisampleStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public SampleCountFlags RasterizationSamples
        {
            get { return NativeHandle->RasterizationSamples; }
            set { NativeHandle->RasterizationSamples = value; }
        }
        
        public Boolean SampleShadingEnable
        {
            get { return NativeHandle->SampleShadingEnable; }
            set { NativeHandle->SampleShadingEnable = value; }
        }
        
        public Single MinSampleShading
        {
            get { return NativeHandle->MinSampleShading; }
            set { NativeHandle->MinSampleShading = value; }
        }
        
        SampleMask _SampleMask;
        public SampleMask SampleMask
        {
            get { return _SampleMask; }
            set { _SampleMask = value; NativeHandle->SampleMask = (IntPtr)value.NativeHandle; }
        }
        
        public Boolean AlphaToCoverageEnable
        {
            get { return NativeHandle->AlphaToCoverageEnable; }
            set { NativeHandle->AlphaToCoverageEnable = value; }
        }
        
        public Boolean AlphaToOneEnable
        {
            get { return NativeHandle->AlphaToOneEnable; }
            set { NativeHandle->AlphaToOneEnable = value; }
        }
        
        public PipelineMultisampleStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineMultisampleStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineMultisampleStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineMultisampleStateCreateInfo;
        }
    }
}
