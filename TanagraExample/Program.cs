using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using SharpDX.Windows;

using Tanagra;
using Vulkan;
using Vulkan.ObjectModel;

using ImageLayout = Vulkan.ImageLayout;
using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var tri = new VKTriangle();
            tri.Main(null);
        }
    }
}
