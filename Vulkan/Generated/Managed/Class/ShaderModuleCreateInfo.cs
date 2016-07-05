using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class ShaderModuleCreateInfo : IDisposable
    {
        internal Unmanaged.ShaderModuleCreateInfo* NativePointer { get; private set; }
        
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
                var valueCount = (Int32)NativePointer->CodeSize;
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
                    var typeSize = Marshal.SizeOf(typeof(Byte)) * valueCount;
                    if(NativePointer->Code != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Code, (IntPtr)typeSize);
                    
                    if(NativePointer->Code == IntPtr.Zero)
                        NativePointer->Code = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->CodeSize = new IntPtr(valueCount);
                    var ptr = (Byte*)NativePointer->Code;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->Code != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Code);
                    
                    NativePointer->Code = IntPtr.Zero;
                    NativePointer->CodeSize = IntPtr.Zero;
                }
            }
        }
        
        public ShaderModuleCreateInfo()
        {
            NativePointer = (Unmanaged.ShaderModuleCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.ShaderModuleCreateInfo));
            NativePointer->SType = StructureType.ShaderModuleCreateInfo;
        }
        
        internal ShaderModuleCreateInfo(Unmanaged.ShaderModuleCreateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.ShaderModuleCreateInfo));
        }
        
        /// <param name="Code">Binary code of size codeSize</param>
        public ShaderModuleCreateInfo(Byte[] Code) : this()
        {
            this.Code = Code;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->Code);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~ShaderModuleCreateInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->Code);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
