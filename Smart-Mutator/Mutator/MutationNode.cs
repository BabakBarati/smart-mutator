using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Converters;

namespace Smart_Mutator.Mutator
{
    public class MutationNode
    {
        public int Id { get; set; }
        public int LineNumber { get; set; }
        public List<MutationRecord> MutationList{ get; set; }

        public int GenerateRandomGene(Random random)
        {
            var possibleGenes = MutationList.Select(m => m.Id).ToList();
            possibleGenes.Add(0);
            var result = possibleGenes[random.Next(possibleGenes.Count)];
            return result;
        }
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
        public uint TotalPassScore { get; set; }
        public uint DistinctPassScore { get; set; }
        public uint PriorScore { get; set; }

        public int PresentScore { get; set; }
        public int MeanMeetScore { get; set; }
        public int BranchFactor { get; set; }
        public int RelativeBranchFactor { get; set; }
        public int DepthScore { get; set; }

        public double NIPS { get; set; }
        public double NIMMS { get; set; }
        public double NIBF { get; set; }
        public double NIRBF { get; set; }
        public double NIDS { get; set; }
    }
}
