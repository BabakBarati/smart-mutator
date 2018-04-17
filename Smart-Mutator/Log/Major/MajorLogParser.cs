using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mutator.Log.Major
{
    public class MajorLogParser
    {
        private readonly string _sourceFile;
        public MajorLogParser(string sourceFile)
        {
            _sourceFile = sourceFile;
        }

        public List<MajorLogItem> ParseLogFile()
        {
            var file = new System.IO.StreamReader(_sourceFile);
            var line = "";
            var result = new List<MajorLogItem>();
            while ((line = file.ReadLine()) != null)
            {
                if(string.IsNullOrWhiteSpace(line))
                    continue;
                result.Add(new MajorLogItem(line));
            }

            file.Close();

            return result;
        }
    }
}
