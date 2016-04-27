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
    }

    public enum VkTypeCategory
    {
        None,
        Handle,
        Enum,
        Bitmask,
        Struct,
        FnPointer,
        Platform,
    }

    public class VkType
    {
        public string Name { get; set; }
        public VkTypeCategory Category { get; set; }

        public override string ToString() => Name;
    }
    
    public class VkHandle : VkType
    {
        public string HandleType { get; set; }
        public string Parent { get; set; }

        public VkHandle()
        {
            Category = VkTypeCategory.Handle;
        }

    }

    public class VkStruct : VkType
    {
        public bool IsImportedType { get; set; }

        public VkMember[] Members { get; set; }

        public bool ReturnedOnly { get; set; }
        public string[] Validity { get; set; }

        public string SpecName { get; set; }

        public VkStruct()
        {
            Category = VkTypeCategory.Struct;
            Members = new VkMember[0];
            Validity = new string[0];
        }

    }
    
    public class VkMember
    {
        public string Name { get; set; }
        public VkType Type { get; set; }
        public bool IsConst { get; set; }
        public int PointerRank { get; set; }

        public string[] Len { get; set; }
        //public bool ExternSync { get; set; }
        public bool NoAutoValidity { get; set; }
        public string Optional;

        public string SpecName { get; set; }

        public VkMember()
        {
            Len = new string[0];
        }

        public override string ToString() => $"{Type} {Name}";
    }
    
    public class VkEnum : VkType
    {
        //public string Name { get; set; }
        //public string EnumType { get; set; }
        public bool IsBitmask { get; set; }
        //public string Expand { get; set; }
        public string Comment { get; set; }
        //public string Namespace { get; set; }

        public VkEnumValue[] Values;

        public VkEnum()
        {
            Category = VkTypeCategory.Enum;
        }
    }

    public class VkEnumValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }

        public string SpecName { get; set; }

        public override string ToString() => Name;
    }

    public class VkCommand
    {
        public string Name;

        public VkType ReturnType;
        public int ReturnPointerRank;

        public VkParam[] Parameters;

        public string[] SuccessCodes;
        public string[] ErrorCodes;

        public string RenderPass;       // possibly only for queue functions?
        public string[] Queues;         //
        public string[] CmdBufferLevel; //

        public string[] Validity;
        public string[] ImplicitExternSyncParams;

        public string SpecName { get; set; }

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

        public string Len { get; set; }
        public bool ExternSync { get; set; }
        public bool NoAutoValidity { get; set; }
        public string[] Optional;

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
}
