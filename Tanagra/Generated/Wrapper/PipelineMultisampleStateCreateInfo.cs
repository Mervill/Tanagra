using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineMultisampleStateCreateInfo
    {
        internal Interop.PipelineMultisampleStateCreateInfo* NativePointer;
        
        public PipelineMultisampleStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public SampleCountFlags RasterizationSamples
        {
            get { return NativePointer->RasterizationSamples; }
            set { NativePointer->RasterizationSamples = value; }
        }
        
        public Boolean SampleShadingEnable
        {
            get { return NativePointer->SampleShadingEnable; }
            set { NativePointer->SampleShadingEnable = value; }
        }
        
        public Single MinSampleShading
        {
            get { return NativePointer->MinSampleShading; }
            set { NativePointer->MinSampleShading = value; }
        }
        
        SampleMask _SampleMask;
        public SampleMask SampleMask
        {
            get { return _SampleMask; }
            set { _SampleMask = value; NativePointer->SampleMask = (IntPtr)value.NativePointer; }
        }
        
        public Boolean AlphaToCoverageEnable
        {
            get { return NativePointer->AlphaToCoverageEnable; }
            set { NativePointer->AlphaToCoverageEnable = value; }
        }
        
        public Boolean AlphaToOneEnable
        {
            get { return NativePointer->AlphaToOneEnable; }
            set { NativePointer->AlphaToOneEnable = value; }
        }
        
        public PipelineMultisampleStateCreateInfo()
        {
            NativePointer = (Interop.PipelineMultisampleStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineMultisampleStateCreateInfo));
            NativePointer->SType = StructureType.PipelineMultisampleStateCreateInfo;
        }
    }
}
