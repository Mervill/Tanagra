using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineShaderStageCreateInfo
    {
        internal Unmanaged.PipelineShaderStageCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineShaderStageCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Shader stage
        /// </summary>
        public ShaderStageFlags Stage
        {
            get { return NativePointer->Stage; }
            set { NativePointer->Stage = value; }
        }
        
        ShaderModule _Module;
        /// <summary>
        /// Module containing entry point
        /// </summary>
        public ShaderModule Module
        {
            get { return _Module; }
            set { _Module = value; NativePointer->Module = value.NativePointer; }
        }
        
        /// <summary>
        /// Null-terminated entry point name
        /// </summary>
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
            NativePointer = (Unmanaged.PipelineShaderStageCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.PipelineShaderStageCreateInfo));
            NativePointer->SType = StructureType.PipelineShaderStageCreateInfo;
        }
        
        public PipelineShaderStageCreateInfo(ShaderStageFlags Stage, ShaderModule Module, String Name) : this()
        {
            this.Stage = Stage;
            this.Module = Module;
            this.Name = Name;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.PipelineShaderStageCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
