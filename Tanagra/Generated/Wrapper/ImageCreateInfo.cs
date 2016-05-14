using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageCreateInfo
    {
        internal Interop.ImageCreateInfo* NativePointer;
        
        public ImageCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public ImageType ImageType
        {
            get { return NativePointer->ImageType; }
            set { NativePointer->ImageType = value; }
        }
        
        public Format Format
        {
            get { return NativePointer->Format; }
            set { NativePointer->Format = value; }
        }
        
        public Extent3D Extent
        {
            get { return NativePointer->Extent; }
            set { NativePointer->Extent = value; }
        }
        
        public UInt32 MipLevels
        {
            get { return NativePointer->MipLevels; }
            set { NativePointer->MipLevels = value; }
        }
        
        public UInt32 ArrayLayers
        {
            get { return NativePointer->ArrayLayers; }
            set { NativePointer->ArrayLayers = value; }
        }
        
        public SampleCountFlags Samples
        {
            get { return NativePointer->Samples; }
            set { NativePointer->Samples = value; }
        }
        
        public ImageTiling Tiling
        {
            get { return NativePointer->Tiling; }
            set { NativePointer->Tiling = value; }
        }
        
        public ImageUsageFlags Usage
        {
            get { return NativePointer->Usage; }
            set { NativePointer->Usage = value; }
        }
        
        public SharingMode SharingMode
        {
            get { return NativePointer->SharingMode; }
            set { NativePointer->SharingMode = value; }
        }
        
        public UInt32 QueueFamilyIndexCount
        {
            get { return NativePointer->QueueFamilyIndexCount; }
            set { NativePointer->QueueFamilyIndexCount = value; }
        }
        
        public UInt32[] QueueFamilyIndices
        {
            get
            {
                var valueCount = NativePointer->QueueFamilyIndexCount;
                var valueArray = new UInt32[valueCount];
                var ptr = (UInt32*)NativePointer->QueueFamilyIndices;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->QueueFamilyIndexCount = (uint)valueCount;
                NativePointer->QueueFamilyIndices = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * valueCount);
                var ptr = (UInt32*)NativePointer->QueueFamilyIndices;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public ImageLayout InitialLayout
        {
            get { return NativePointer->InitialLayout; }
            set { NativePointer->InitialLayout = value; }
        }
        
        public ImageCreateInfo()
        {
            NativePointer = (Interop.ImageCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ImageCreateInfo));
            NativePointer->SType = StructureType.ImageCreateInfo;
        }
        
        public ImageCreateInfo(ImageType ImageType, Format Format, Extent3D Extent, UInt32 MipLevels, UInt32 ArrayLayers, SampleCountFlags Samples, ImageTiling Tiling, ImageUsageFlags Usage, SharingMode SharingMode, UInt32[] QueueFamilyIndices, ImageLayout InitialLayout) : this()
        {
            this.ImageType = ImageType;
            this.Format = Format;
            this.Extent = Extent;
            this.MipLevels = MipLevels;
            this.ArrayLayers = ArrayLayers;
            this.Samples = Samples;
            this.Tiling = Tiling;
            this.Usage = Usage;
            this.SharingMode = SharingMode;
            this.QueueFamilyIndices = QueueFamilyIndices;
            this.InitialLayout = InitialLayout;
        }
    }
}
