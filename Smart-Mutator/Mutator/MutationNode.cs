using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace Smart_Mutator.Mutator
{
    public class MutationNode
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public List<MutationRecord> MutationList{ get; set; }
    }

    public class MutationRecord
    {
        public int Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MuOp Operator { get; set; }
        public string MutateFrom  { get; set; }
        public string MutateTo { get; set; }
    }

    public class MutationSpyNode : MutationNode
    {
        public int TotalPassScore { get; set; }
        public int DistinctPassScore { get; set; }
        public int PriorScore { get; set; }
    }
}
