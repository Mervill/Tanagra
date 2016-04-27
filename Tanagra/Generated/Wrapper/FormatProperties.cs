using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FormatProperties
    {
        internal Interop.FormatProperties* NativeHandle;
        
        public FormatFeatureFlags LinearTilingFeatures
        {
            get { return NativeHandle->LinearTilingFeatures; }
            set { NativeHandle->LinearTilingFeatures = value; }
        }
        
        public FormatFeatureFlags OptimalTilingFeatures
        {
            get { return NativeHandle->OptimalTilingFeatures; }
            set { NativeHandle->OptimalTilingFeatures = value; }
        }
        
        public FormatFeatureFlags BufferFeatures
        {
            get { return NativeHandle->BufferFeatures; }
            set { NativeHandle->BufferFeatures = value; }
        }
        
        public FormatProperties()
        {
            NativeHandle = (Interop.FormatProperties*)Interop.Structure.Allocate(typeof(Interop.FormatProperties));
        }
    }
}
