using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SamplerCreateInfo
    {
        internal Interop.SamplerCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public SamplerCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// Filter mode for magnification
        /// </summary>
        public Filter MagFilter
        {
            get { return NativePointer->MagFilter; }
            set { NativePointer->MagFilter = value; }
        }
        
        /// <summary>
        /// Filter mode for minifiation
        /// </summary>
        public Filter MinFilter
        {
            get { return NativePointer->MinFilter; }
            set { NativePointer->MinFilter = value; }
        }
        
        /// <summary>
        /// Mipmap selection mode
        /// </summary>
        public SamplerMipmapMode MipmapMode
        {
            get { return NativePointer->MipmapMode; }
            set { NativePointer->MipmapMode = value; }
        }
        
        public SamplerAddressMode AddressModeU
        {
            get { return NativePointer->AddressModeU; }
            set { NativePointer->AddressModeU = value; }
        }
        
        public SamplerAddressMode AddressModeV
        {
            get { return NativePointer->AddressModeV; }
            set { NativePointer->AddressModeV = value; }
        }
        
        public SamplerAddressMode AddressModeW
        {
            get { return NativePointer->AddressModeW; }
            set { NativePointer->AddressModeW = value; }
        }
        
        public Single MipLodBias
        {
            get { return NativePointer->MipLodBias; }
            set { NativePointer->MipLodBias = value; }
        }
        
        public Bool32 AnisotropyEnable
        {
            get { return NativePointer->AnisotropyEnable; }
            set { NativePointer->AnisotropyEnable = value; }
        }
        
        public Single MaxAnisotropy
        {
            get { return NativePointer->MaxAnisotropy; }
            set { NativePointer->MaxAnisotropy = value; }
        }
        
        public Bool32 CompareEnable
        {
            get { return NativePointer->CompareEnable; }
            set { NativePointer->CompareEnable = value; }
        }
        
        public CompareOp CompareOp
        {
            get { return NativePointer->CompareOp; }
            set { NativePointer->CompareOp = value; }
        }
        
        public Single MinLod
        {
            get { return NativePointer->MinLod; }
            set { NativePointer->MinLod = value; }
        }
        
        public Single MaxLod
        {
            get { return NativePointer->MaxLod; }
            set { NativePointer->MaxLod = value; }
        }
        
        public BorderColor BorderColor
        {
            get { return NativePointer->BorderColor; }
            set { NativePointer->BorderColor = value; }
        }
        
        public Bool32 UnnormalizedCoordinates
        {
            get { return NativePointer->UnnormalizedCoordinates; }
            set { NativePointer->UnnormalizedCoordinates = value; }
        }
        
        public SamplerCreateInfo()
        {
            NativePointer = (Interop.SamplerCreateInfo*)MemoryUtils.Allocate(typeof(Interop.SamplerCreateInfo));
            NativePointer->SType = StructureType.SamplerCreateInfo;
        }
        
        public SamplerCreateInfo(Filter MagFilter, Filter MinFilter, SamplerMipmapMode MipmapMode, SamplerAddressMode AddressModeU, SamplerAddressMode AddressModeV, SamplerAddressMode AddressModeW, Single MipLodBias, Bool32 AnisotropyEnable, Single MaxAnisotropy, Bool32 CompareEnable, CompareOp CompareOp, Single MinLod, Single MaxLod, BorderColor BorderColor, Bool32 UnnormalizedCoordinates) : this()
        {
            this.MagFilter = MagFilter;
            this.MinFilter = MinFilter;
            this.MipmapMode = MipmapMode;
            this.AddressModeU = AddressModeU;
            this.AddressModeV = AddressModeV;
            this.AddressModeW = AddressModeW;
            this.MipLodBias = MipLodBias;
            this.AnisotropyEnable = AnisotropyEnable;
            this.MaxAnisotropy = MaxAnisotropy;
            this.CompareEnable = CompareEnable;
            this.CompareOp = CompareOp;
            this.MinLod = MinLod;
            this.MaxLod = MaxLod;
            this.BorderColor = BorderColor;
            this.UnnormalizedCoordinates = UnnormalizedCoordinates;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.SamplerCreateInfo*)IntPtr.Zero;
        }
    }
}
