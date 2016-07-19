using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    /// <summary>
    /// IExtensible
    /// </summary>
    unsafe public class PipelineShaderStageCreateInfo : IDisposable
    {
        internal Unmanaged.PipelineShaderStageCreateInfo* NativePointer { get; private set; }
        
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
        public String Name
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
            NativePointer = (Unmanaged.PipelineShaderStageCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.PipelineShaderStageCreateInfo));
            NativePointer->SType = StructureType.PipelineShaderStageCreateInfo;
        }
        
        internal PipelineShaderStageCreateInfo(Unmanaged.PipelineShaderStageCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.PipelineShaderStageCreateInfo));
        }
        
        /// <param name="Stage">Shader stage</param>
        /// <param name="Module">Module containing entry point</param>
        /// <param name="Name">Null-terminated entry point name</param>
        public PipelineShaderStageCreateInfo(ShaderStageFlags Stage, ShaderModule Module, String Name) : this()
        {
            this.Stage = Stage;
            this.Module = Module;
            this.Name = Name;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->Name);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~PipelineShaderStageCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->Name);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
