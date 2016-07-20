using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vulkan
{
    public interface IExtensible
    {
        StructureType SType { get; }
        IExtensible Next { get; }
    }

    /*public interface IExtensible<T> where T : IExtensible
    {
        StructureType SType { get; }
        T Next { get; }
    }*/
}
