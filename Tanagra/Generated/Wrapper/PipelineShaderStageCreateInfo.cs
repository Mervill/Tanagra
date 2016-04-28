using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineShaderStageCreateInfo
    {
        internal Interop.PipelineShaderStageCreateInfo* NativePointer;
        
        public PipelineShaderStageCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public ShaderStageFlags Stage
        {
            get { return NativePointer->Stage; }
            set { NativePointer->Stage = value; }
        }
        
        ShaderModule _Module;
        public ShaderModule Module
        {
            get { return _Module; }
            set { _Module = value; NativePointer->Module = (IntPtr)value.NativePointer; }
        }
        
        public string Name
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->Name); }
            set { NativePointer->Name = Marshal.StringToHGlobalAnsi(value); }
        }
        
        SpecializationInfo _SpecializationInfo;
        public SpecializationInfo SpecializationInfo
        {
            get { return _SpecializationInfo; }
            set { _SpecializationInfo = value; NativePointer->SpecializationInfo = (IntPtr)value.NativePointer; }
        }
        
        public PipelineShaderStageCreateInfo()
        {
            NativePointer = (Interop.PipelineShaderStageCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineShaderStageCreateInfo));
            //NativePointer->SType = StructureType.PipelineShaderStageCreateInfo;
        }
    }
}
