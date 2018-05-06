using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mutator.Mutator
{
    public enum MuOp
    {
        [EnumMember(Value = "NNN")]
        NNN = 0,
        [EnumMember(Value = "AOR")]
        AOR = 1,
        [EnumMember(Value = "LOR")]
        LOR = 2,
        [EnumMember(Value = "COR")]
        COR = 3,
        [EnumMember(Value = "ROR")]
        ROR = 4,
        [EnumMember(Value = "SOR")]
        SOR = 5,
        [EnumMember(Value = "ORU")]
        ORU = 6,
        [EnumMember(Value = "EVR")]
        EVR = 7,
        [EnumMember(Value = "LVR")]
        LVR = 8,
        [EnumMember(Value = "STD")]
        STD = 9,
        // -----------------------------
        [EnumMember(Value = "ABS")]
        ABS = 10,
        [EnumMember(Value = "UOI")]
        UOI = 11,
        [EnumMember(Value = "SVR")]
        SVR = 12,
        [EnumMember(Value = "UOD")]
        UOD = 13,
        [EnumMember(Value = "ASR")]
        ASR = 14
    }
}
