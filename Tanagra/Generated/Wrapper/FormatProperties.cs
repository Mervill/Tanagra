using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FormatProperties
    {
        internal Interop.FormatProperties* NativePointer;
        
        public FormatFeatureFlags LinearTilingFeatures
        {
            get { return NativePointer->LinearTilingFeatures; }
            set { NativePointer->LinearTilingFeatures = value; }
        }
        
        public FormatFeatureFlags OptimalTilingFeatures
        {
            get { return NativePointer->OptimalTilingFeatures; }
            set { NativePointer->OptimalTilingFeatures = value; }
        }
        
        public FormatFeatureFlags BufferFeatures
        {
            get { return NativePointer->BufferFeatures; }
            set { NativePointer->BufferFeatures = value; }
        }
        
        public FormatProperties()
        {
            NativePointer = (Interop.FormatProperties*)Interop.Structure.Allocate(typeof(Interop.FormatProperties));
        }
    }
}
