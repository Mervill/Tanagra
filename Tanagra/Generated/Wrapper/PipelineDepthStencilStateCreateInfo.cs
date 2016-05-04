using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineDepthStencilStateCreateInfo
    {
        internal Interop.PipelineDepthStencilStateCreateInfo* NativePointer;
        
        public PipelineDepthStencilStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public Boolean DepthTestEnable
        {
            get { return NativePointer->DepthTestEnable; }
            set { NativePointer->DepthTestEnable = value; }
        }
        
        public Boolean DepthWriteEnable
        {
            get { return NativePointer->DepthWriteEnable; }
            set { NativePointer->DepthWriteEnable = value; }
        }
        
        public CompareOp DepthCompareOp
        {
            get { return NativePointer->DepthCompareOp; }
            set { NativePointer->DepthCompareOp = value; }
        }
        
        public Boolean DepthBoundsTestEnable
        {
            get { return NativePointer->DepthBoundsTestEnable; }
            set { NativePointer->DepthBoundsTestEnable = value; }
        }
        
        public Boolean StencilTestEnable
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
            NativePointer = (Interop.PipelineDepthStencilStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineDepthStencilStateCreateInfo));
            NativePointer->SType = StructureType.PipelineDepthStencilStateCreateInfo;
        }
    }
}
