using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineDepthStencilStateCreateInfo
    {
        internal Interop.PipelineDepthStencilStateCreateInfo* NativeHandle;
        
        public PipelineDepthStencilStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public Boolean DepthTestEnable
        {
            get { return NativeHandle->DepthTestEnable; }
            set { NativeHandle->DepthTestEnable = value; }
        }
        
        public Boolean DepthWriteEnable
        {
            get { return NativeHandle->DepthWriteEnable; }
            set { NativeHandle->DepthWriteEnable = value; }
        }
        
        public CompareOp DepthCompareOp
        {
            get { return NativeHandle->DepthCompareOp; }
            set { NativeHandle->DepthCompareOp = value; }
        }
        
        public Boolean DepthBoundsTestEnable
        {
            get { return NativeHandle->DepthBoundsTestEnable; }
            set { NativeHandle->DepthBoundsTestEnable = value; }
        }
        
        public Boolean StencilTestEnable
        {
            get { return NativeHandle->StencilTestEnable; }
            set { NativeHandle->StencilTestEnable = value; }
        }
        
        StencilOpState _Front;
        public StencilOpState Front
        {
            get { return _Front; }
            set { _Front = value; NativeHandle->Front = (IntPtr)value.NativeHandle; }
        }
        
        StencilOpState _Back;
        public StencilOpState Back
        {
            get { return _Back; }
            set { _Back = value; NativeHandle->Back = (IntPtr)value.NativeHandle; }
        }
        
        public Single MinDepthBounds
        {
            get { return NativeHandle->MinDepthBounds; }
            set { NativeHandle->MinDepthBounds = value; }
        }
        
        public Single MaxDepthBounds
        {
            get { return NativeHandle->MaxDepthBounds; }
            set { NativeHandle->MaxDepthBounds = value; }
        }
        
        public PipelineDepthStencilStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineDepthStencilStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineDepthStencilStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineDepthStencilStateCreateInfo;
        }
    }
}
