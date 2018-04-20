using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Mutator.Log.Major;
using Smart_Mutator.Mutator;

namespace Smart_Mutator
{
    class Program
    {
        static void Main(string[] args)
        {
            var logParser = new MajorLogParser(@"C:\Users\Babak\Downloads\Telegram Desktop\mutants.log");
            //List<MajorLogItem> result = logParser.ParseLogFile();
            logParser.SaveMutationLogList();

            //var nodes = new List<MutationSpyNode>
            //{
            //    new MutationSpyNode
            //    {
            //        LineNumber = 10,
            //        Id = 1,
            //        MutationList = new List<MutationRecord>()
            //    },
            //    new MutationSpyNode
            //    {
            //        LineNumber = 10,
            //        Id = 2,
            //        MutationList = new List<MutationRecord>()
            //    }
            //};

            //var mutator = new SmartMutator(nodes);

            Console.Write("Press any key to close ...");
            System.Console.ReadKey();
        }
    }
}
