using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DebugMarkerObjectTagInfoEXT
    {
        internal Unmanaged.DebugMarkerObjectTagInfoEXT* NativePointer;
        
        /// <summary>
        /// The type of the object
        /// </summary>
        public DebugReportObjectTypeEXT ObjectType
        {
            get { return NativePointer->ObjectType; }
            set { NativePointer->ObjectType = value; }
        }
        
        /// <summary>
        /// The handle of the object, cast to uint64_t
        /// </summary>
        public UInt64 Object
        {
            get { return NativePointer->Object; }
            set { NativePointer->Object = value; }
        }
        
        /// <summary>
        /// The name of the tag to set on the object
        /// </summary>
        public UInt64 TagName
        {
            get { return NativePointer->TagName; }
            set { NativePointer->TagName = value; }
        }
        
        /// <summary>
        /// Tag data to attach to the object
        /// </summary>
        public IntPtr[] Tag
        {
            get
            {
                if(NativePointer->Tag == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->TagSize;
                var valueArray = new IntPtr[valueCount];
                var ptr = (IntPtr*)NativePointer->Tag;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<IntPtr>() * valueCount;
                    if(NativePointer->Tag != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Tag, (IntPtr)typeSize);
                    
                    if(NativePointer->Tag == IntPtr.Zero)
                        NativePointer->Tag = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->TagSize = (UInt32)valueCount;
                    var ptr = (IntPtr*)NativePointer->Tag;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = value[x];
                }
                else
                {
                    if(NativePointer->Tag != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Tag);
                    
                    NativePointer->Tag = IntPtr.Zero;
                    NativePointer->TagSize = 0;
                }
            }
        }
        
        public DebugMarkerObjectTagInfoEXT()
        {
            NativePointer = (Unmanaged.DebugMarkerObjectTagInfoEXT*)MemoryUtils.Allocate(typeof(Unmanaged.DebugMarkerObjectTagInfoEXT));
            NativePointer->SType = StructureType.DebugMarkerObjectTagInfoEXT;
        }
        
        public DebugMarkerObjectTagInfoEXT(DebugReportObjectTypeEXT ObjectType, UInt64 Object, UInt64 TagName, IntPtr[] Tag) : this()
        {
            this.ObjectType = ObjectType;
            this.Object = Object;
            this.TagName = TagName;
            this.Tag = Tag;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.DebugMarkerObjectTagInfoEXT*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
