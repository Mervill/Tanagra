using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanagra.Generator
{
    public class VkSpec
    {
        
        public IEnumerable<VkStruct> Structs { get { return AllTypes.Where(x => x is VkStruct).Cast<VkStruct>().ToArray(); } }
        public IEnumerable<VkHandle> Handles { get { return AllTypes.Where(x => x is VkHandle).Cast<VkHandle>().ToArray(); } }
        public IEnumerable<VkEnum> Enums { get { return AllTypes.Where(x => x is VkEnum).Cast<VkEnum>().ToArray(); } }

        public List<VkType> AllTypes;

        public VkCommand[] Commands;

        public VkFeature[] Features;

        public VkExtension[] Extensions;
    }

    // readme.tex:
    //   Defines vendor IDs for physical devices which do not have PCI vendor IDs.
    public class VkVendorId
    {
        // readme.tex:
        //   The author prefix, as registered with Khronos. This must match an author prefix in the 
        //   name field of a tag.
        public string Name { get; set; }
        
        // readme.tex:
        //   The reserved vendor ID, as a hexadecimal number.
        public string Id { get; set; }

        // readme.tex:
        //   Arbitrary string.
        public string Comment { get; set; }
    }

    // readme.tex:
    //   Defines each of the reserved author prefixes used by extension and layer authors.
    public class VkTag
    {
        // readme.tex:
        //   The author prefix, as registered with Khronos. A short, uppercase string, usually an 
        //   abbreviation of an author, project or company name.
        public string Name { get; set; }

        // readme.tex:
        //   The author name, such as a full company or project name.
        public string Author { get; set; }

        // readme.tex:
        //   The contact who registered or is currently responsible for extensions and layers 
        //   using the prefix, including sufficient contact information to reach the contact such 
        //   as individual name together with email address, Github username, or other contact 
        //   information.
        public string Contact { get; set; }
    }

    public class VkType
    {
        // readme.tex:
        //   Name of this type.
        public string Name { get; set; }

        public bool IsImportedType { get; set; }

        public override string ToString() => Name;
    }
    
    public class VkHandle : VkType
    {
        // readme.tex:
        //   Notes another type with the handle category that acts as a parent object for this type.
        public string Parent { get; set; }

        public string HandleType { get; set; }

        public bool IsDispatchable => HandleType != "VK_DEFINE_NON_DISPATCHABLE_HANDLE";
    }

    public class VkStruct : VkType
    {
        public string SpecName { get; set; }
        public VkMember[] Members { get; set; }

        // readme.tex:
        //   Notes that this struct/union is going to be filled in by the API, rather than an 
        //   application filling it out and passing it to the API.
        public bool ReturnedOnly { get; set; }

        // readme.tex:
        //   Each <validity> tag contains zero or more <usage> tags. Each <usage> tag is intended to 
        //   represent a specific validation requirement for the structure and include arbitrary 
        //   asciidoc text describing  that requirement.
        public string[] Validity { get; set; }
        
        public bool HasPointerMembers => Members.Any(x => x.IsPointer || x.Type.Name == "Char");

        /// <summary>
        /// https://www.khronos.org/registry/vulkan/specs/1.0/xhtml/vkspec.html#extensions-interactions
        /// </summary>
        public bool IsExtensible
            => Members.Any(x => x.SpecName == "sType") && Members.Any(x => x.SpecName == "pNext");

        public VkStruct()
        {
            Members = new VkMember[0];
            Validity = new string[0];
        }

    }
    
    public class VkMember
    {
        public string Name { get; set; }
        public string SpecName { get; set; }

        public VkType Type { get; set; }
        public bool IsFixedSize { get; set; }
        public string FixedSize { get; set; }
        public bool IsConst { get; set; }
        public int PointerRank { get; set; }

        // readme.tex:
        //   Only valid on the pNext member of a struct. This is a comma-separated list of structures 
        //   that may be accepted by pNext instead of NULL
        public string[] ValidExtensionStructs { get; set; }

        // readme.tex:
        //   If the member is an array, len may be one or more of the following things, separated by 
        //   commas (one for each array indirection): another member of that struct; “null-terminated” 
        //   for a string; “1” to indicate it’s just a pointer(used for nested pointers); or an 
        //   equation(a LaTeX math expression delimited by latexmath:[$ and $].
        public string[] Len { get; set; }

        // readme.tex:
        //   Denotes that the member should be externally synchronized when accessed by Vulkan
        //public bool ExternSync { get; set; }
        
        // readme.tex:
        //   A value of 'true' or 'false' determines whether this member can be omitted by providing
        //   `NULL` (for pointers), `VK_NULL_HANDLE` (for handles) or 0 (for bitmasks/values). If the
        //   member is a pointer to one of those types, multiple values may be provided, separated by 
        //   commas - one for each pointer indirection. Note that this only affects automatic validity 
        //   statements - explicit statements remain unchanged.
        public string Optional; // todo: make array

        // readme.tex:
        //   Prevents automatic validity language being generated for the tagged item. Only suppresses 
        //   item-specific validity - parenting issues etc. are still captured.
        public bool NoAutoValidity { get; set; }

        public string XMLComment;

        public bool IsPointer => PointerRank > 0;
        public bool IsArray => Len.Length != 0 || IsFixedSize;

        public VkMember()
        {
            Len = new string[0];
        }

        public override string ToString() => $"{Type} {Name}";
    }
    
    public class VkEnum : VkType
    {
        public bool IsBitmask { get; set; }
        public string Comment { get; set; }
        public VkEnumValue[] Values;
    }

    public class VkEnumValue
    {
        public string Name { get; set; }
        public string SpecName { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }

        public override string ToString() => Name;
    }

    public class VkCommand
    {
        public string Name;
        public string SpecName { get; set; }

        public VkType ReturnType;
        public int ReturnPointerRank;

        public VkParam[] Parameters;
        
        // readme.tex:
        //   A string identifying the command queues this command can be placed on. 
        //   The format of the string is one or more of the terms "compute", "dma", and 
        //   "graphics", with multiple terms separated by commas.
        public string[] Queues;

        // readme.tex:
        //   A string describing possible successful return codes from the command, as a 
        //   comma-separated list of Vulkan result code names.
        public string[] SuccessCodes;

        // readme.tex:
        //   A string describing possible error return codes from the command, as a comma-separated 
        //   list of Vulkan result code names.
        public string[] ErrorCodes;

        // readme.tex:
        //   A string identifying whether the command can be issued only inside a render pass ("inside"), 
        //   only outside a render pass ("outside"), or both ("both").
        public string RenderPass;

        // readme.tex:
        //   A string identifying the command buffer levels that this command can be called by.
        //   The format of the string is one or more of the terms "primary" and "secondary", with 
        //   multiple terms separated by commas.
        public string[] CmdBufferLevel;

        // readme.tex:
        //   Contains a list of <param> tags, each containing Asciidoc source text describing an object 
        //   which is not a parameter of the command, but is related to one, and which also requires 
        //   external synchronization as described in section 12.4.1. The text is intended to be 
        //   incorporated into the API specification.
        public string[] ImplicitExternSyncParams;

        public string[] Validity;

        public VkCommand()
        {
            Parameters = new VkParam[0];
            Queues = new string[0];
            SuccessCodes = new string[0];
            ErrorCodes = new string[0];
            CmdBufferLevel = new string[0];
            ImplicitExternSyncParams = new string[0];
            Validity = new string[0];
        }

        public string ToDeclaration()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ReturnType);
            sb.Append(new string('*', ReturnPointerRank));
            sb.Append(" ");
            sb.Append(SpecName);
            sb.Append("(");
            for(int x = 0; x < Parameters.Length; x++)
            {
                sb.Append(Parameters[x]);
                if(x + 1 < Parameters.Length)
                    sb.Append(", ");
            }
            sb.Append(")");
            return sb.ToString();
        }

        public override string ToString() => $"{ReturnType} {Name}(...)";
    }

    public class VkParam
    {
        public string Name { get; set; }
        public VkType Type { get; set; }
        public bool IsConst { get; set; }
        public int PointerRank { get; set; }

        // readme.tex:
        //   If the param is an array, len may be one or more of the following things, separated by 
        //   commas (one for each array indirection): another param of that command; “null-terminated” 
        //   for a string; “1” to indicate it’s just a pointer(used for nested pointers); or an         //   equation (a simple expression prefixed with “math:”)
        public string Len { get; set; }

        // readme.tex:
        //   A value of ’true’ or ’false’ determines whether this member can be omitted by providing 
        //   NULL (for pointers), VK_NULL_HANDLE (for handles) or 0 (for bitmasks/values). If the 
        //   member is a pointer to one of those types, multiple values may be provided, separated by 
        //   commas - one for each pointer indirection. Note that this only affects automatic validity 
        //   statements - explicit statements remain unchanged.
        public string[] Optional;

        // readme.tex:
        //   Prevents automatic validity language being generated for the tagged item. Only suppresses 
        //   item-specific validity - parenting issues etc. are still captured.
        public bool NoAutoValidity { get; set; }

        // readme.tex:
        //   A boolean string, which must have the value "true" if present, indicating that 
        //   this parameter (e.g.the object a handle refers to, or the contents of an array a pointer 
        //   refers to) is modified by the command, and is not protected against modification in 
        //   multiple app threads. Parameters which do not have this attribute are assumed to not 
        //   require external synchronization.
        public bool ExternSync { get; set; }
        
        public bool IsPointer => PointerRank > 0;
        public bool IsOut => IsPointer && !IsConst;
        public bool IsFixed => Type is VkHandle && !IsConst;

        public VkParam()
        {
            Optional = new string[0];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(IsConst) sb.Append("const ");
            sb.Append(Type);
            sb.Append(new string('*', PointerRank));
            sb.Append(" ");
            sb.Append(Name);
            return sb.ToString();
        }
    }

    public class VkFeature
    {
        public string Api;
        public string Name;
        public string Number;

        public VkFeatureRequirement[] Requirements;
    }

    public class VkFeatureRequirement
    {
        public string Comment;

        public string[] Types;
        public string[] Enums;
        public string[] Commands;
    }

    public class VkExtension
    {
        public string Name;

        // readme.tex:
        //   A decimal number which is the registered, unique extension number for name.
        public int Number;

        // readme.tex:
        //   A regular expression, with an implicit ˆ and $ bracketing it, which should match the api 
        //   tag of a set of <feature> tags.
        public string Supported;

        // readme.tex:
        //   An additional preprocessor token used to protect an extension definition. Usually another 
        //   feature or extension name. Rarely used, for odd circumstances where the definition of an 
        //   extension requires another extension or a header file to be defined first.
        public string Protect;

        // readme.tex:
        //   The author name, such as a full company name. If not present, this can be taken from the 
        //   corresponding<tag> attribute.However, EXT and other multi-vendor extensions may not have a 
        //   well-defined author or contact in the tag.
        public string Author;

        // readme.tex:
        //   The contact who registered or is currently responsible for extensions and layers using the 
        //   tag, including sufficient contact information to reach the contact such as individual name 
        //   together with email address, Github username, or other contact information. If not present, 
        //   this can be taken from the corresponding <tag> attribute just like author.
        public string Contact;

        public VkExtensionRequirement Requirement;

        public override string ToString() => Name;
    }

    public class VkExtensionRequirement
    {
        public string[] Commands;
        public string[] Types;
        public VkExtensionEnum[] Enums;
        public VkExtensionUsage[] Usages;
    }

    public class VkExtensionEnum
    {
        public string Name;
        public int? Offset;
        public string Dir;
        public string Extends;
        public string Value;
        public int? BitPos;
        public string Comment;

        public bool IsFlag => Offset == null && BitPos != null && !IsConstant;
        public bool IsConstant => string.IsNullOrEmpty(Extends) && !string.IsNullOrEmpty(Value) && !Offset.HasValue && !BitPos.HasValue;
    }

    public class VkExtensionUsage
    {
        public string Command;
        public string Struct;
        public string Content;
    }

}
