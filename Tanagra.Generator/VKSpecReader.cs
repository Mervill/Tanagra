using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Tanagra.Generator
{
    // todo: bitpos?
    public class VKSpecReader
    {
        public Dictionary<string, VkType> allTypes;

        public VKSpecReader()
        {
            allTypes = new Dictionary<string, VkType>
            {                
                // basetype
                { "VkSampleMask", CreateImportStruct("VkSampleMask") },
                { "VkBool32",     CreateImportStruct("VkBool32")     },
                { "VkDeviceSize", CreateImportStruct("VkDeviceSize") },
                
                // imports
                { "Display",          CreateImportStruct("Display")          },
                { "VisualID",         CreateImportStruct("VisualID")         },
                { "Window",           CreateImportStruct("Window")           },
                { "ANativeWindow",    CreateImportStruct("ANativeWindow")    },
                { "MirConnection",    CreateImportStruct("MirConnection")    },
                { "MirSurface",       CreateImportStruct("MirSurface")       },
                { "wl_display",       CreateImportStruct("wl_display")       },
                { "wl_surface",       CreateImportStruct("wl_surface")       },
                { "HINSTANCE",        CreateImportStruct("HINSTANCE")        }, // IntPtr - Process.GetCurrentProcess().Handle;
                { "HWND",             CreateImportStruct("HWND")             }, // IntPtr - Process.GetCurrentProcess().MainWindowHandle;
                { "xcb_connection_t", CreateImportStruct("xcb_connection_t") }, // IntPtr
                { "xcb_visualid_t",   CreateImportStruct("xcb_visualid_t")   },
                { "xcb_window_t",     CreateImportStruct("xcb_window_t")     }, // IntPtr

                // union
                { "VkClearValue",      CreatePlatformStruct("VkClearValue") },
                { "VkClearColorValue", CreatePlatformStruct("VkClearColorValue") },
            };

            // Basetype
            //allTypes.Add("VkSampleMask", CreateBasetypeStruct("VkSampleMask", "uint32_t"));
            //allTypes.Add("VkBool32",     CreateBasetypeStruct("VkBool32",     "uint32_t"));
            //allTypes.Add("VkDeviceSize", CreateBasetypeStruct("VkDeviceSize", "uint64_t"));
        }

        public VkSpec Read(string raw)
        {
            // Read the Vulkan spec into memory
            //
            // Besides simply reading the spec into classes, VKSpecReader links type information
            // across commands and structures via the `VkType` base class. So for example an enum
            // like `VkSomeNameFlags` will have a `VkEnum : VkType` class generated for it, and all
            // commands and structures that use `VkSomeNameFlags`  will reference this class. This
            // approach should make bulk-renaming and other transformations on the spec easier to accomplish.
            //
            // This class is concerned with reading the spec into memory _only_. Beyond
            // linking type data, it should preform no additional transformations on the
            // data (unless necessary, as in bitmasks).
            //

            var spec = new VkSpec();

            var xdoc = XDocument.Parse(raw);
            var registry = xdoc.Root;

            var xtypes = registry.Element("types").Elements("type");

            // 'Plaform' types //
            {
                // These are mainly primitives like void, uint32_t, size_t, etc. They are treated
                // specially by the pipeline.
                var plaformTypes = xtypes
                    .Where(TypePlatformFilter)
                    .Select(x => x.Attribute("name").Value)
                    .ToList();

                var platformStructs = plaformTypes.Select(CreatePlatformStruct).ToList();
                foreach(var vkStruct in platformStructs)
                    allTypes.Add(vkStruct.Name, vkStruct);
            }

            // Enums / Bitmask //
            {
                // Bitmask types are weirdly defined, if the 'requires'
                // attribute is present, the enum is defined somewhere in 
                // the file. If the 'requires' is missing, the enum is empty
                var bitmaskTypes = xtypes
                    .Where(TypeBitmaskFilter)
                    .ToList();

                var emptyBitmaskNames = bitmaskTypes
                    .Where(x => x.Attribute("requires") == null)
                    .Select(x => x.Element("name").Value)
                    .ToList();

                var emptyBitmasks = emptyBitmaskNames.Select(GenerateEmptyBitmask);

                var xenums = registry.Elements("enums");
                var enums = xenums.Select(ReadEnum);
                enums = enums.Concat(emptyBitmasks); // Add the empty bitmasks generated above
                foreach(var vkEnum in enums)
                    allTypes.Add(vkEnum.Name, vkEnum);
            }
            
            // Handles //
            {
                var handles = xtypes
                    .Where(TypeHandleFilter)
                    .Select(ReadHandle);

                foreach(var handle in handles)
                    allTypes.Add(handle.Name, handle);
            }

            // Structs //
            {
                var xstructs = xtypes.Where(TypeStructFilter);

                // Create a map of `struct name` -> `struct xml definition`
                var structDefMap = CreateStructureDictionary(xstructs);

                // Create a VkStruct object for each class before reading the xml definitions,
                // this is so the struct members can refrence other struct types
                var structs = structDefMap.Keys.Select(x => new VkStruct { Name = x }).ToArray();
                foreach(var vkStruct in structs)
                    allTypes.Add(vkStruct.Name, vkStruct);

                // Read the struct definitions
                for(int x = 0; x < structs.Length; x++)
                    ReadStruct(structDefMap[structs[x].Name], structs[x]);
            }
            
            spec.AllTypes = allTypes.Values.ToList();

            // Commands //
            var commandsRoot = registry.Element("commands");
            var commands = commandsRoot.Elements("command");
            spec.Commands = commands.Select(ReadCommand).ToArray();

            // Features //
            var features = registry.Elements("feature");
            spec.Features = features.Select(ReadFeature).ToArray();
            
            return spec;
        }

        VkEnum ReadEnum(XElement xenums)
        {
            if(xenums.Name != "enums")
                throw new ArgumentException("Not an enum colletion", nameof(xenums));

            var vkEnum = new VkEnum();

            var xattributes = xenums.Attributes();
            if(xattributes.Count() != 0)
            {
                foreach(var xattrib in xattributes)
                {
                    switch(xattrib.Name.ToString())
                    {
                        case "name":
                        vkEnum.Name = GetEnumName(xattrib.Value);
                        break;
                        case "type":
                        vkEnum.IsBitmask = xattrib.Value == "bitmask";
                        break;
                        case "expand":
                        vkEnum.Expand = xattrib.Value;
                        break;
                        case "namespace":
                        vkEnum.Namespace = xattrib.Value;
                        break;
                        case "comment":
                        vkEnum.Comment = xattrib.Value;
                        break;
                        default: throw new NotImplementedException(xattrib.Name.ToString());
                    }
                }
            }

            if(string.IsNullOrEmpty(vkEnum.Name))
                throw new InvalidOperationException("Enum collection does not have proper `<name>` element");

            // note: there are also `unused` blocks that are not currently used...
            vkEnum.Values = xenums.Elements("enum").Select(ReadEnumValue).ToArray();

            return vkEnum;
        }

        static string GetEnumName(string name)
        {
            // There's normally not supposed to be any transformations
            // happening in this class, but the way bitmasks are layed out
            // in the spec is weird. A bitmask named `VkNameFlagBits` is
            // actually refrenced as `VkNameFlags` (Except for when it isn't). 
            // I think this has something to do with `typedef` works in c
            if(name.EndsWith("FlagBits"))
            {
                name = name.Substring(0, name.Length - 4);
                name += "s";
            }
            return name;
        }

        VkEnumValue ReadEnumValue(XElement xenum)
        {
            if(xenum.Name != "enum")
                throw new ArgumentException("Not an enum", nameof(xenum));

            var vkEnum = new VkEnumValue();

            var xattributes = xenum.Attributes();
            if(xattributes.Count() != 0)
            {
                foreach(var xattrib in xattributes)
                {
                    switch(xattrib.Name.ToString())
                    {
                        case "name":
                        vkEnum.Name = vkEnum.SpecName = xattrib.Value;
                        break;
                        case "bitpos":
                        case "value":
                        vkEnum.Value = xattrib.Value;
                        break;
                        case "comment":
                        vkEnum.Comment = xattrib.Value;
                        break;
                        default: throw new NotImplementedException(xattrib.Name.ToString());
                    }
                }
            }

            if(string.IsNullOrEmpty(vkEnum.Name) || string.IsNullOrEmpty(vkEnum.Value))
                throw new InvalidOperationException("Enum collection does not have proper `<name>` or `<value>` or `<bitpos>` element");

            return vkEnum;
        }

        static VkEnum GenerateEmptyBitmask(string name)
        {
            var vkEnum = new VkEnum
            {
                Name = GetEnumName(name),
                IsBitmask = true,
                Comment = "Autogenerated by Tanaga"
            };

            var vkEnumValue = new VkEnumValue
            {
                Name = "VK_NONE",
                Value = "0",
                Comment = "Autogenerated by Tanaga"
            };

            vkEnum.Values = new[] { vkEnumValue };

            return vkEnum;
        }

        VkHandle ReadHandle(XElement xtype)
        {
            if(xtype.Name != "type")
                throw new ArgumentException("Not a type element", nameof(xtype));

            var xcategory = xtype.Attribute("category");
            if(xcategory == null || xcategory.Value != "handle")
                throw new ArgumentException("Invalid category", nameof(xtype));

            var xelements = xtype.Elements();
            if(xelements.Count() == 0)
                throw new ArgumentException("Contains no elements", nameof(xtype));

            var vkHandle = new VkHandle();

            foreach(var xelm in xelements)
            {
                switch(xelm.Name.ToString())
                {
                    case "type":
                    vkHandle.HandleType = xelm.Value;
                    break;
                    case "name":
                    vkHandle.Name = xelm.Value;
                    break;
                    default: throw new NotImplementedException(xelm.Name.ToString());
                }
            }

            var xattributes = xtype.Attributes();
            if(xattributes.Count() != 0)
            {
                foreach(var xattrib in xattributes)
                {
                    switch(xattrib.Name.ToString())
                    {
                        case "parent":
                        vkHandle.Parent = xattrib.Value;
                        break;
                        case "category": break;
                        default: throw new NotImplementedException(xattrib.Name.ToString());
                    }
                }
            }

            return vkHandle;
        }

        Dictionary<string, XElement> CreateStructureDictionary(IEnumerable<XElement> xstructs)
        {
            var dictionary = new Dictionary<string, XElement>();
            foreach(var xstruct in xstructs)
            {
                if(xstruct.Name != "type")
                    throw new ArgumentException("Not a type element", nameof(xstruct));

                var xcategory = xstruct.Attribute("category");
                if(xcategory == null || xcategory.Value != "struct")
                    throw new ArgumentException("Invalid category", nameof(xstruct));

                var xnameAttribute = xstruct.Attribute("name");
                if(xnameAttribute == null)
                    throw new ArgumentException("Struct does not have a `<name>` attribute!");

                dictionary.Add(xnameAttribute.Value, xstruct);
            }
            return dictionary;
        }

        VkStruct ReadStruct(XElement xstruct, VkStruct vkStruct)
        {
            if(xstruct.Name != "type")
                throw new ArgumentException("Not a type element", nameof(xstruct));

            var xcategory = xstruct.Attribute("category");
            if(xcategory == null || xcategory.Value != "struct")
                throw new ArgumentException("Invalid category", nameof(xstruct));
            
            var xattributes = xstruct.Attributes();
            if(xattributes.Count() != 0)
            {
                foreach(var xattrib in xattributes)
                {
                    switch(xattrib.Name.ToString())
                    {
                        case "name":
                            vkStruct.Name = vkStruct.SpecName = xattrib.Value;
                            break;
                        case "returnedonly":
                            vkStruct.ReturnedOnly = xattrib.Value == "true";
                            break;
                        case "category":
                            break;
                        default: throw new NotImplementedException(xattrib.Name.ToString());
                    }
                }
            }

            vkStruct.Members = xstruct.Elements("member").Select(ReadMember).ToArray();

            var xvalidity = xstruct.Element("validity");
            if(xvalidity != null)
            {
                vkStruct.Validity = xvalidity.Elements()
                    .Select(x => x.Value)
                    .ToArray();
            }
            
            return vkStruct;
        }

        VkMember ReadMember(XElement xmember)
        {
            // note: pretty much identical to <param>

            if(xmember.Name != "member")
                throw new ArgumentException("Not a member", nameof(xmember));

            var xelements = xmember.Elements();
            if(xelements.Count() == 0)
                throw new ArgumentException("Contains no elements", nameof(xmember));

            var vkMember = new VkMember();

            foreach(var elm in xelements)
            {
                switch(elm.Name.ToString())
                {
                    case "type":
                        vkMember.Type = GetOrAddType(elm.Value);
                        break;
                    case "name":
                        vkMember.Name = vkMember.SpecName = elm.Value;
                        break;
                    case "enum": // todo
                        break;
                    default: throw new NotImplementedException(elm.Name.ToString());
                }
            }

            if(string.IsNullOrEmpty(vkMember.Name) || vkMember.Type == null)
                throw new InvalidOperationException("Member does not have proper `<name>` or `<type>` element");

            // Gah! Why are these not encoded properly!
            var paramStr = xmember.Value;
            vkMember.PointerRank = paramStr.Count(x => x == '*');
            vkMember.IsConst = paramStr.Contains("const");

            // read member attributes
            var xattributes = xmember.Attributes();
            if(xattributes.Count() != 0)
            {
                foreach(var xattrib in xattributes)
                {
                    switch(xattrib.Name.ToString())
                    {
                        case "optional":
                            var value = xattrib.Value;
                            if(value != "true") throw new NotImplementedException(value);
                            vkMember.Optional = value;
                            break;
                        case "len":
                            vkMember.Len = xattrib.Value;
                            break;
                        /*case "externsync":
                        param.ExternSync = attrib.Value == "true";
                        break;*/
                        case "noautovalidity":
                            vkMember.NoAutoValidity = xattrib.Value == "true";
                            break;
                        default: throw new NotImplementedException(xattrib.Name.ToString());
                    }
                }
            }

            return vkMember;
        }
        
        VkCommand ReadCommand(XElement xcommand)
        {
            if(xcommand.Name != "command")
                throw new ArgumentException("Not a command", nameof(xcommand));

            var xproto = xcommand.Element("proto");
            if(xproto == null)
                throw new ArgumentException("No prototype", nameof(xcommand));

            var vkCommand = new VkCommand();
            vkCommand.Name = vkCommand.SpecName = xproto.Element("name").Value;
            vkCommand.ReturnType = GetOrAddType(xproto.Element("type").Value);
            vkCommand.ErrorCodes = new string[0];
            vkCommand.SuccessCodes = new string[0];
            vkCommand.Queues = new string[0];

            // todo: return is const
            // todo: return is pointer
            var xprotoStr = xproto.Value;
            if(xprotoStr.Contains("*") || xprotoStr.Contains("const"))
                throw new NotImplementedException();

            var xparams = xcommand.Elements("param");
            vkCommand.Parameters = xparams.Select(ReadParam).ToArray();

            var elements = xcommand.Elements();
            if(elements.Count() == 0)
                throw new ArgumentException("Contains no elements", nameof(xcommand));

            foreach(var xelm in elements)
            {
                switch(xelm.Name.ToString())
                {
                    case "proto":
                    case "param":
                        break;
                    case "validity":
                        vkCommand.Validity = xelm.Elements().Select(x => x.Value).ToArray();
                        break;
                    case "implicitexternsyncparams":
                        vkCommand.ImplicitExternSyncParams = xelm.Elements().Select(x => x.Value).ToArray();
                        break;
                    default: throw new NotImplementedException(xelm.Name.ToString());
                }
            }

            // note: queues / renderpass / cmdbufferlevel - If one is present all three must be

            // read command attributes
            var xattributes = xcommand.Attributes();
            if(xattributes.Count() != 0)
            {
                foreach(var xattrib in xattributes)
                {
                    switch(xattrib.Name.ToString())
                    {
                        case "successcodes":
                            vkCommand.SuccessCodes = xattrib.Value.Split(',');
                            break;
                        case "errorcodes":
                            vkCommand.ErrorCodes = xattrib.Value.Split(',');
                            break;
                        case "queues":
                            vkCommand.Queues = xattrib.Value.Split(',');
                            break;
                        case "renderpass":
                            vkCommand.RenderPass = xattrib.Value;
                            break;
                        case "cmdbufferlevel":
                            vkCommand.CmdBufferLevel = xattrib.Value.Split(',');
                            break;
                        default: throw new NotImplementedException(xattrib.Name.ToString());
                    }
                }
            }
            
            return vkCommand;
        }

        VkParam ReadParam(XElement xparam)
        {
            if(xparam.Name != "param")
                throw new ArgumentException("Not a parameter", nameof(xparam));

            var xelements = xparam.Elements();
            if(xelements.Count() == 0)
                throw new ArgumentException("Contains no elements", nameof(xparam));

            var vkParam = new VkParam();

            foreach(var xelm in xelements)
            {
                switch(xelm.Name.ToString())
                {
                    case "type":
                        vkParam.Type = GetOrAddType(xelm.Value);
                        break;
                    case "name":
                        vkParam.Name = xelm.Value;
                        break;
                    default: throw new NotImplementedException(xelm.Name.ToString());
                }
            }

            if(string.IsNullOrEmpty(vkParam.Name) || vkParam.Type == null)
                throw new InvalidOperationException("Param does not have proper `<name>` or `<type>` element");

            // Gah! Why are these not encoded properly!
            var paramStr = xparam.Value;
            vkParam.PointerRank = paramStr.Count(x => x == '*');
            vkParam.IsConst = paramStr.Contains("const");

            // read parameter attributes
            var xattributes = xparam.Attributes();
            if(xattributes.Count() != 0)
            {
                foreach(var xattrib in xattributes)
                {
                    switch(xattrib.Name.ToString())
                    {
                        case "optional":
                            vkParam.Optional = xattrib.Value.Split(',');
                            break;
                        case "len":
                            vkParam.Len = xattrib.Value;
                            break;
                        case "externsync":
                            vkParam.ExternSync = xattrib.Value == "true";
                            break;
                        case "noautovalidity":
                            vkParam.NoAutoValidity = xattrib.Value == "true";
                            break;
                        default: throw new NotImplementedException(xattrib.Name.ToString());
                    }
                }
            }

            return vkParam;
        }

        VkFeature ReadFeature(XElement xfeature)
        {
            if(xfeature.Name != "feature")
                throw new ArgumentException("Not a feature", nameof(xfeature));

            var vkFeature = new VkFeature();

            var xattributes = xfeature.Attributes();
            if(xattributes.Count() != 0)
            {
                foreach(var xattrib in xattributes)
                {
                    switch(xattrib.Name.ToString())
                    {
                        case "api":
                            vkFeature.Api = xattrib.Value;
                            break;
                        case "name":
                            vkFeature.Name = xattrib.Value;
                            break;
                        case "number":
                            vkFeature.Number = xattrib.Value;
                            break;
                        default: throw new NotImplementedException(xattrib.Name.ToString());
                    }
                }
            }

            vkFeature.Requirements = xfeature.Elements().Select(ReadRequirement).ToArray();

            return vkFeature;
        }

        VkFeatureRequirement ReadRequirement(XElement xrequire)
        {
            if(xrequire.Name != "require")
                throw new ArgumentException("Not a requirement", nameof(xrequire));

            var xelements = xrequire.Elements();
            if(xelements.Count() == 0)
                throw new ArgumentException("Contains no elements", nameof(xrequire));

            var vkRequire = new VkFeatureRequirement();

            var xcomment = xrequire.Attribute("comment");
            if(xcomment != null)
                vkRequire.Comment = xcomment.Value;

            var types = new List<string>();
            var enums = new List<string>();
            var commands = new List<string>();
            foreach(var elm in xelements)
            {
                switch(elm.Name.ToString())
                {
                    case "type":
                        types.Add(elm.Attribute("name").Value);
                        break;
                    case "enum":
                        enums.Add(elm.Attribute("name").Value);
                        break;
                    case "command":
                        commands.Add(elm.Attribute("name").Value);
                        break;
                    default: throw new NotImplementedException(elm.Name.ToString());
                }
            }

            vkRequire.Types = types.ToArray();
            vkRequire.Enums = enums.ToArray();
            vkRequire.Commands = commands.ToArray();

            return vkRequire;
        }
        
        VkType GetOrAddType(string name)
        {
            if(allTypes.ContainsKey(name))
                return allTypes[name];

            // Could be one of the poorly-named enums
            var enumName = GetEnumName(name);
            if(allTypes.ContainsKey(enumName))
                return allTypes[enumName];

            var newType = new VkType();
            newType.Name = name;

            allTypes.Add(name, newType);
            return newType;
        }

        VkStruct CreateBasetypeStruct(string name, string type)
        {
            var vkStruct = new VkStruct();
            vkStruct.Name = vkStruct.SpecName = name;

            var vkMember = new VkMember();
            vkMember.Name = vkMember.SpecName = "value";
            vkMember.Type = GetOrAddType(type);

            vkStruct.Members = new[] { vkMember };

            return vkStruct;
        }

        static bool TypePlatformFilter(XElement xtype)
        {
            var xreq = xtype.Attribute("requires");
            return xreq != null && xreq.Value == "vk_platform";
        }

        static bool TypeBitmaskFilter(XElement xtype)
        {
            var xcat = xtype.Attribute("category");
            return xcat != null && xcat.Value == "bitmask";
        }

        static bool TypeHandleFilter(XElement xtype)
        {
            var xcat = xtype.Attribute("category");
            return xcat != null && xcat.Value == "handle";
        }

        static bool TypeEnumFilter(XElement xtype)
        {
            var xcat = xtype.Attribute("category");
            return xcat != null && xcat.Value == "enum";
        }

        static bool TypeStructFilter(XElement xtype)
        {
            var xcat = xtype.Attribute("category");
            return xcat != null && xcat.Value == "struct";
        }
        
        static VkStruct CreatePlatformStruct(string name)
        {
            var vkStruct = new VkStruct();
            vkStruct.Name = vkStruct.SpecName = name;
            return vkStruct;
        }

        static VkStruct CreateImportStruct(string name)
        {
            var vkStruct = new VkStruct();
            vkStruct.Name = vkStruct.SpecName = name;
            return vkStruct;
        }
    }
}
