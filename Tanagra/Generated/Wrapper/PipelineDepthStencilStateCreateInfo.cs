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
        
        StencilOpState _Front;
        public StencilOpState Front
        {
            get { return _Front; }
            set { _Front = value; NativePointer->Front = (IntPtr)value.NativePointer; }
        }
        
        StencilOpState _Back;
        public StencilOpState Back
        {
            get { return _Back; }
            set { _Back = value; NativePointer->Back = (IntPtr)value.NativePointer; }
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
