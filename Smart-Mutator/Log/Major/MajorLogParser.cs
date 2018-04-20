using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Smart_Mutator.Mutator;

namespace Smart_Mutator.Log.Major
{
    public class MajorLogParser
    {
        private readonly string _sourceFile;
        private readonly List<MajorLogItem> _majorLogItems;
        public MajorLogParser(string sourceFile)
        {
            _sourceFile = sourceFile;
            _majorLogItems = ParseLogFile();
        }

        public List<MajorLogItem> ParseLogFile()
        {
            var file = new System.IO.StreamReader(_sourceFile);
            string line;
            var result = new List<MajorLogItem>();
            while ((line = file.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                result.Add(new MajorLogItem(line));
            }

            file.Close();

            return result;
        }

        public List<MutationNode> CreateMutationNodeList()
        {
            var result = new List<MutationNode>();
            //var lineNumbers = from m in _majorLogItems group m.LineNumber by m.LineNumber into grp select grp.Key;
            var lineNumbers = _majorLogItems.GroupBy(m => m.LineNumber).Select(grp => grp.Key).OrderBy(l => l);

            var index = 1;
            foreach (var lineNumber in lineNumbers)
            {
                var mutations = _majorLogItems.Where(m => m.LineNumber == lineNumber);
                var mutationNode = new MutationNode
                {
                    Id = index++,
                    LineNumber = lineNumber,
                    MutationList = mutations.Select(m => new MutationRecord
                    {
                        Id = m.Index,
                        MutateFrom = m.MutateFrom,
                        MutateTo = m.MutateTo,
                        Operator = m.MutationOperator
                    }).ToList()
                };
                result.Add(mutationNode);
            }

            return result;
        }

        public void SaveMutationLogList()
        {
            var json = JsonConvert.SerializeObject(CreateMutationNodeList(), Formatting.Indented);
            System.IO.File.WriteAllText($@"Mutation_List_{DateTime.Now:yy-MM-dd_hh-mm-ss}.json", json);
        }
    }
}
