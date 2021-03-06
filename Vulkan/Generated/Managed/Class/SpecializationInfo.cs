using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class SpecializationInfo : IDisposable
    {
        internal Unmanaged.SpecializationInfo* NativePointer { get; private set; }
        
        /// <summary>
        /// Array of map entries
        /// </summary>
        public SpecializationMapEntry[] MapEntries
        {
            get
            {
                if(NativePointer->MapEntries == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->MapEntryCount;
                var valueArray = new SpecializationMapEntry[valueCount];
                var ptr = (SpecializationMapEntry*)NativePointer->MapEntries;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(SpecializationMapEntry)) * valueCount;
                    if(NativePointer->MapEntries != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->MapEntries, (IntPtr)typeSize);
                    
                    if(NativePointer->MapEntries == IntPtr.Zero)
                        NativePointer->MapEntries = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->MapEntryCount = (UInt32)valueCount;
                    var ptr = (SpecializationMapEntry*)NativePointer->MapEntries;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->MapEntries != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->MapEntries);
                    
                    NativePointer->MapEntries = IntPtr.Zero;
                    NativePointer->MapEntryCount = 0;
                }
            }
        }
        
        /// <summary>
        /// Pointer to SpecConstant data
        /// </summary>
        public IntPtr[] Data
        {
            get
            {
                if(NativePointer->Data == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->DataSize;
                var valueArray = new IntPtr[valueCount];
                var ptr = (IntPtr*)NativePointer->Data;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf(typeof(IntPtr)) * valueCount;
                    if(NativePointer->Data != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Data, (IntPtr)typeSize);
                    
                    if(NativePointer->Data == IntPtr.Zero)
                        NativePointer->Data = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DataSize = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->Data;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->Data != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Data);
                    
                    NativePointer->Data = IntPtr.Zero;
                    NativePointer->DataSize = 0;
                }
            }
        }
        
        public SpecializationInfo()
        {
            NativePointer = (Unmanaged.SpecializationInfo*)MemUtil.Alloc(typeof(Unmanaged.SpecializationInfo));
        }
        
        internal SpecializationInfo(Unmanaged.SpecializationInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.SpecializationInfo));
        }
        
        /// <param name="MapEntries">Array of map entries</param>
        /// <param name="Data">Pointer to SpecConstant data</param>
        public SpecializationInfo(SpecializationMapEntry[] MapEntries, IntPtr[] Data) : this()
        {
            this.MapEntries = MapEntries;
            this.Data = Data;
        }
        
        public void Dispose()
        {
            Marshal.FreeHGlobal(NativePointer->MapEntries);
            Marshal.FreeHGlobal(NativePointer->Data);
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~SpecializationInfo()
        {
            if(NativePointer != null)
            {
                Marshal.FreeHGlobal(NativePointer->MapEntries);
                Marshal.FreeHGlobal(NativePointer->Data);
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
