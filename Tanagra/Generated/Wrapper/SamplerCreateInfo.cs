using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SamplerCreateInfo
    {
        internal Interop.SamplerCreateInfo* NativeHandle;
        
        public SamplerCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public Filter MagFilter
        {
            get { return NativeHandle->MagFilter; }
            set { NativeHandle->MagFilter = value; }
        }
        
        public Filter MinFilter
        {
            get { return NativeHandle->MinFilter; }
            set { NativeHandle->MinFilter = value; }
        }
        
        public SamplerMipmapMode MipmapMode
        {
            get { return NativeHandle->MipmapMode; }
            set { NativeHandle->MipmapMode = value; }
        }
        
        public SamplerAddressMode AddressModeU
        {
            get { return NativeHandle->AddressModeU; }
            set { NativeHandle->AddressModeU = value; }
        }
        
        public SamplerAddressMode AddressModeV
        {
            get { return NativeHandle->AddressModeV; }
            set { NativeHandle->AddressModeV = value; }
        }
        
        public SamplerAddressMode AddressModeW
        {
            get { return NativeHandle->AddressModeW; }
            set { NativeHandle->AddressModeW = value; }
        }
        
        public Single MipLodBias
        {
            get { return NativeHandle->MipLodBias; }
            set { NativeHandle->MipLodBias = value; }
        }
        
        public Boolean AnisotropyEnable
        {
            get { return NativeHandle->AnisotropyEnable; }
            set { NativeHandle->AnisotropyEnable = value; }
        }
        
        public Single MaxAnisotropy
        {
            get { return NativeHandle->MaxAnisotropy; }
            set { NativeHandle->MaxAnisotropy = value; }
        }
        
        public Boolean CompareEnable
        {
            get { return NativeHandle->CompareEnable; }
            set { NativeHandle->CompareEnable = value; }
        }
        
        public CompareOp CompareOp
        {
            get { return NativeHandle->CompareOp; }
            set { NativeHandle->CompareOp = value; }
        }
        
        public Single MinLod
        {
            get { return NativeHandle->MinLod; }
            set { NativeHandle->MinLod = value; }
        }
        
        public Single MaxLod
        {
            get { return NativeHandle->MaxLod; }
            set { NativeHandle->MaxLod = value; }
        }
        
        public BorderColor BorderColor
        {
            get { return NativeHandle->BorderColor; }
            set { NativeHandle->BorderColor = value; }
        }
        
        public Boolean UnnormalizedCoordinates
        {
            get { return NativeHandle->UnnormalizedCoordinates; }
            set { NativeHandle->UnnormalizedCoordinates = value; }
        }
        
        public SamplerCreateInfo()
        {
            NativeHandle = (Interop.SamplerCreateInfo*)Interop.Structure.Allocate(typeof(Interop.SamplerCreateInfo));
            //NativeHandle->SType = StructureType.SamplerCreateInfo;
        }
    }
}
