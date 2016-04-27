using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ApplicationInfo
    {
        internal Interop.ApplicationInfo* NativeHandle;
        
        public string ApplicationName
        {
            get { return Marshal.PtrToStringAnsi(NativeHandle->ApplicationName); }
            set { NativeHandle->ApplicationName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public UInt32 ApplicationVersion
        {
            get { return NativeHandle->ApplicationVersion; }
            set { NativeHandle->ApplicationVersion = value; }
        }
        
        public string EngineName
        {
            get { return Marshal.PtrToStringAnsi(NativeHandle->EngineName); }
            set { NativeHandle->EngineName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public UInt32 EngineVersion
        {
            get { return NativeHandle->EngineVersion; }
            set { NativeHandle->EngineVersion = value; }
        }
        
        public UInt32 ApiVersion
        {
            get { return NativeHandle->ApiVersion; }
            set { NativeHandle->ApiVersion = value; }
        }
        
        public ApplicationInfo()
        {
            NativeHandle = (Interop.ApplicationInfo*)Interop.Structure.Allocate(typeof(Interop.ApplicationInfo));
            //NativeHandle->SType = StructureType.ApplicationInfo;
        }
    }
}
