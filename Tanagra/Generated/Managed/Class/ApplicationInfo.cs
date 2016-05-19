using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ApplicationInfo
    {
        internal Unmanaged.ApplicationInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.ApplicationInfo*)MemoryUtils.Allocate(typeof(Unmanaged.ApplicationInfo));
            NativePointer->SType = StructureType.ApplicationInfo;
        }
        
        public ApplicationInfo(UInt32 ApplicationVersion, UInt32 EngineVersion, UInt32 ApiVersion) : this()
        {
            this.ApplicationVersion = ApplicationVersion;
            this.EngineVersion = EngineVersion;
            this.ApiVersion = ApiVersion;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.ApplicationInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
