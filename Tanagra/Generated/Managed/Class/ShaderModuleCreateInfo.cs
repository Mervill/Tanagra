using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ShaderModuleCreateInfo
    {
        internal Unmanaged.ShaderModuleCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public ShaderModuleCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Binary code of size codeSize
        /// </summary>
        public Byte[] Code
        {
            get
            {
                if(NativePointer->Code == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->CodeSize;
                var valueArray = new Byte[valueCount];
                var ptr = (Byte*)NativePointer->Code;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Byte>() * valueCount;
                    if(NativePointer->Code != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Code, (IntPtr)typeSize);
                    
                    if(NativePointer->Code == IntPtr.Zero)
                        NativePointer->Code = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->CodeSize = (UInt32)valueCount;
                    var ptr = (Byte*)NativePointer->Code;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->Code != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Code);
                    
                    NativePointer->Code = IntPtr.Zero;
                    NativePointer->CodeSize = 0;
                }
            }
        }
        
        public ShaderModuleCreateInfo()
        {
            NativePointer = (Unmanaged.ShaderModuleCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.ShaderModuleCreateInfo));
            NativePointer->SType = StructureType.ShaderModuleCreateInfo;
        }
        
        public ShaderModuleCreateInfo(Byte[] Code) : this()
        {
            this.Code = Code;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.ShaderModuleCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
