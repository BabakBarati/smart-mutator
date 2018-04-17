using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mutator.Log.Major
{
    public class MajorLogItem
    {
        public int Index { get; private set; }
        public string MutationOperator { get; private set; }
        public string OriginalOperatorSymbol { get; private set; }
        public string ReplacementOperatorSymbol { get; private set; }
        public string MutatedMethodSignature { get; private set; }
        public int LineNumber { get; private set; }
        public string MutateFrom { get; private set; }
        public string MutateTo { get; private set; }

        public MajorLogItem(string line)
        {
            var splitted = line.Split(':');

            Index = int.Parse(splitted[0]);
            MutationOperator = splitted[1];
            OriginalOperatorSymbol = splitted[2];
            ReplacementOperatorSymbol = splitted[3];
            MutatedMethodSignature = splitted[4];
            LineNumber = int.Parse(splitted[5]);

            var transformSummary = splitted[6].Split(new[] { " |==> " }, StringSplitOptions.RemoveEmptyEntries);

            MutateFrom = transformSummary[0];
            MutateTo = transformSummary[1];

        }
    }
}
