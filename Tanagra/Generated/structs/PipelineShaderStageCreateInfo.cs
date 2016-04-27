using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineShaderStageCreateInfo
    {
        internal Interop.PipelineShaderStageCreateInfo* NativeHandle;
        
        public PipelineShaderStageCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public ShaderStageFlags Stage
        {
            get { return NativeHandle->Stage; }
            set { NativeHandle->Stage = value; }
        }
        
        ShaderModule _Module;
        public ShaderModule Module
        {
            get { return _Module; }
            set { _Module = value; NativeHandle->Module = (IntPtr)value.NativeHandle; }
        }
        
        public string Name
        {
            get { return Marshal.PtrToStringAnsi(NativeHandle->Name); }
            set { NativeHandle->Name = Marshal.StringToHGlobalAnsi(value); }
        }
        
        SpecializationInfo _SpecializationInfo;
        public SpecializationInfo SpecializationInfo
        {
            get { return _SpecializationInfo; }
            set { _SpecializationInfo = value; NativeHandle->SpecializationInfo = (IntPtr)value.NativeHandle; }
        }
        
        public PipelineShaderStageCreateInfo()
        {
            NativeHandle = (Interop.PipelineShaderStageCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineShaderStageCreateInfo));
            //NativeHandle->SType = StructureType.PipelineShaderStageCreateInfo;
        }
    }
}
