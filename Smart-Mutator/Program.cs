using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Mutator.Log.Major;

namespace Smart_Mutator
{
    class Program
    {
        static void Main(string[] args)
        {
            var logParser = new MajorLogParser(@"C:\Users\Babak\Downloads\Telegram Desktop\mutants.log");
            //List<MajorLogItem> result = logParser.ParseLogFile();
            logParser.SaveMutationLogList();

            System.Console.ReadLine();
        }
    }
}
