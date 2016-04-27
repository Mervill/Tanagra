using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineRasterizationStateCreateInfo
    {
        internal Interop.PipelineRasterizationStateCreateInfo* NativeHandle;
        
        public PipelineRasterizationStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public Boolean DepthClampEnable
        {
            get { return NativeHandle->DepthClampEnable; }
            set { NativeHandle->DepthClampEnable = value; }
        }
        
        public Boolean RasterizerDiscardEnable
        {
            get { return NativeHandle->RasterizerDiscardEnable; }
            set { NativeHandle->RasterizerDiscardEnable = value; }
        }
        
        public PolygonMode PolygonMode
        {
            get { return NativeHandle->PolygonMode; }
            set { NativeHandle->PolygonMode = value; }
        }
        
        public CullModeFlags CullMode
        {
            get { return NativeHandle->CullMode; }
            set { NativeHandle->CullMode = value; }
        }
        
        public FrontFace FrontFace
        {
            get { return NativeHandle->FrontFace; }
            set { NativeHandle->FrontFace = value; }
        }
        
        public Boolean DepthBiasEnable
        {
            get { return NativeHandle->DepthBiasEnable; }
            set { NativeHandle->DepthBiasEnable = value; }
        }
        
        public Single DepthBiasConstantFactor
        {
            get { return NativeHandle->DepthBiasConstantFactor; }
            set { NativeHandle->DepthBiasConstantFactor = value; }
        }
        
        public Single DepthBiasClamp
        {
            get { return NativeHandle->DepthBiasClamp; }
            set { NativeHandle->DepthBiasClamp = value; }
        }
        
        public Single DepthBiasSlopeFactor
        {
            get { return NativeHandle->DepthBiasSlopeFactor; }
            set { NativeHandle->DepthBiasSlopeFactor = value; }
        }
        
        public Single LineWidth
        {
            get { return NativeHandle->LineWidth; }
            set { NativeHandle->LineWidth = value; }
        }
        
        public PipelineRasterizationStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineRasterizationStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineRasterizationStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineRasterizationStateCreateInfo;
        }
    }
}
