using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SamplerCreateInfo
    {
        internal Interop.SamplerCreateInfo* NativePointer;
        
        public SamplerCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public Filter MagFilter
        {
            get { return NativePointer->MagFilter; }
            set { NativePointer->MagFilter = value; }
        }
        
        public Filter MinFilter
        {
            get { return NativePointer->MinFilter; }
            set { NativePointer->MinFilter = value; }
        }
        
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
        
        public Boolean AnisotropyEnable
        {
            get { return NativePointer->AnisotropyEnable; }
            set { NativePointer->AnisotropyEnable = value; }
        }
        
        public Single MaxAnisotropy
        {
            get { return NativePointer->MaxAnisotropy; }
            set { NativePointer->MaxAnisotropy = value; }
        }
        
        public Boolean CompareEnable
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
        
        public Boolean UnnormalizedCoordinates
        {
            get { return NativePointer->UnnormalizedCoordinates; }
            set { NativePointer->UnnormalizedCoordinates = value; }
        }
        
        public SamplerCreateInfo()
        {
            NativePointer = (Interop.SamplerCreateInfo*)Interop.Structure.Allocate(typeof(Interop.SamplerCreateInfo));
            NativePointer->SType = StructureType.SamplerCreateInfo;
        }
    }
}
