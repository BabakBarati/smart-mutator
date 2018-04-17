using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Operator { get; set; }
        public string MutateFrom  { get; set; }
        public string MutateTo { get; set; }
    }
}
