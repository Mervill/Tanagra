using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageCreateInfo
    {
        internal Interop.ImageCreateInfo* NativeHandle;
        
        public ImageCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public ImageType ImageType
        {
            get { return NativeHandle->ImageType; }
            set { NativeHandle->ImageType = value; }
        }
        
        public Format Format
        {
            get { return NativeHandle->Format; }
            set { NativeHandle->Format = value; }
        }
        
        Extent3D _Extent;
        public Extent3D Extent
        {
            get { return _Extent; }
            set { _Extent = value; NativeHandle->Extent = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 MipLevels
        {
            get { return NativeHandle->MipLevels; }
            set { NativeHandle->MipLevels = value; }
        }
        
        public UInt32 ArrayLayers
        {
            get { return NativeHandle->ArrayLayers; }
            set { NativeHandle->ArrayLayers = value; }
        }
        
        public SampleCountFlags Samples
        {
            get { return NativeHandle->Samples; }
            set { NativeHandle->Samples = value; }
        }
        
        public ImageTiling Tiling
        {
            get { return NativeHandle->Tiling; }
            set { NativeHandle->Tiling = value; }
        }
        
        public ImageUsageFlags Usage
        {
            get { return NativeHandle->Usage; }
            set { NativeHandle->Usage = value; }
        }
        
        public SharingMode SharingMode
        {
            get { return NativeHandle->SharingMode; }
            set { NativeHandle->SharingMode = value; }
        }
        
        public UInt32 QueueFamilyIndexCount
        {
            get { return NativeHandle->QueueFamilyIndexCount; }
            set { NativeHandle->QueueFamilyIndexCount = value; }
        }
        
        public UInt32 QueueFamilyIndices
        {
            get { return NativeHandle->QueueFamilyIndices; }
            set { NativeHandle->QueueFamilyIndices = value; }
        }
        
        public ImageLayout InitialLayout
        {
            get { return NativeHandle->InitialLayout; }
            set { NativeHandle->InitialLayout = value; }
        }
        
        public ImageCreateInfo()
        {
            NativeHandle = (Interop.ImageCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ImageCreateInfo));
            //NativeHandle->SType = StructureType.ImageCreateInfo;
        }
    }
}
