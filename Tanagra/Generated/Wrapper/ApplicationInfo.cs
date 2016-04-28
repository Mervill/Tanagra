using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ApplicationInfo
    {
        internal Interop.ApplicationInfo* NativePointer;
        
        public string ApplicationName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->ApplicationName); }
            set { NativePointer->ApplicationName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public UInt32 ApplicationVersion
        {
            get { return NativePointer->ApplicationVersion; }
            set { NativePointer->ApplicationVersion = value; }
        }
        
        public string EngineName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->EngineName); }
            set { NativePointer->EngineName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public UInt32 EngineVersion
        {
            get { return NativePointer->EngineVersion; }
            set { NativePointer->EngineVersion = value; }
        }
        
        public UInt32 ApiVersion
        {
            get { return NativePointer->ApiVersion; }
            set { NativePointer->ApiVersion = value; }
        }
        
        public ApplicationInfo()
        {
            NativePointer = (Interop.ApplicationInfo*)Interop.Structure.Allocate(typeof(Interop.ApplicationInfo));
            //NativePointer->SType = StructureType.ApplicationInfo;
        }
    }
}
