using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Mutator.Log.Major;

namespace Smart_Mutator
{
    public class CodeInstrumentor
    {
        private readonly string _logFile;
        private readonly string _sourceFile;
        private readonly string _destinationFileName;
        private readonly MajorLogParser _logParser;
        public CodeInstrumentor(string logFile, string sourceFile, string destinationFile)
        {
            _logFile = logFile;
            _sourceFile = sourceFile;
            _destinationFileName = destinationFile;

            _logParser = new MajorLogParser(_logFile);
            var majorLogItems = _logParser.ParseLogFile();
        }

        public void InjectInstrumentation()
        {
            // inject initialization: create file and insert stubs

            // inject line by line

            // close the file
        }

        public void CreateMutationList()
        {

        }
    }
}
