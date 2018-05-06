using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Mutator.Log.Major;
using Smart_Mutator.Mutator;

namespace Smart_Mutator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ThesisTest();
        }

        public static void ThesisTest()
        {
            var spyNodes = new List<MutationSpyNode>
            {
                new MutationSpyNode
                {
                    Id = 1,
                    NIPS = 0.8747,
                    NIMMS = 0.2716,
                    NIBF = 0.3333,
                    NIRBF = 0.6667,
                    NIDS = 1.0000,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 1, Operator = MuOp.ROR},
                        new MutationRecord {Id = 2, Operator = MuOp.ROR},
                        new MutationRecord {Id = 3, Operator = MuOp.ROR},
                    }
                },
                new MutationSpyNode
                {
                    Id = 2,
                    NIPS = 1.0000,
                    NIMMS = 0.3333,
                    NIBF = 0.6667,
                    NIRBF = 0.6667,
                    NIDS = 0.6667,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 4, Operator = MuOp.STD}
                    }
                },
                new MutationSpyNode
                {
                    Id = 3,
                    NIPS = 0.08747,
                    NIMMS = 1.0000,
                    NIBF = 0.6667,
                    NIRBF = 0.6667,
                    NIDS = 0.2222,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 5, Operator = MuOp.AOR},
                        new MutationRecord {Id = 6, Operator = MuOp.AOR},
                        new MutationRecord {Id = 7, Operator = MuOp.AOR},
                        new MutationRecord {Id = 8, Operator = MuOp.AOR}
                    }
                },
                new MutationSpyNode
                {
                    Id = 4,
                    NIPS = 1.0000,
                    NIMMS = 1.0000,
                    NIBF = 0.6667,
                    NIRBF = 0.6667,
                    NIDS = 0.2222,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 9, Operator = MuOp.AOR},
                        new MutationRecord {Id = 10, Operator = MuOp.AOR},
                        new MutationRecord {Id = 11, Operator = MuOp.AOR},
                        new MutationRecord {Id = 12, Operator = MuOp.AOR}
                    }
                },
                new MutationSpyNode
                {
                    Id = 5,
                    NIPS = 1.0000,
                    NIMMS = 0.2500,
                    NIBF = 0.3333,
                    NIRBF = 0.6667,
                    NIDS = 0.1333,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 13, Operator = MuOp.ROR},
                        new MutationRecord {Id = 14, Operator = MuOp.ROR},
                        new MutationRecord {Id = 15, Operator = MuOp.ROR}
                    }
                },
                new MutationSpyNode
                {
                    Id = 6,
                    NIPS = 1.0000,
                    NIMMS = 0.3333,
                    NIBF = 0.6667,
                    NIRBF = 0.6667,
                    NIDS = 0.1333,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 16, Operator = MuOp.AOR},
                        new MutationRecord {Id = 17, Operator = MuOp.AOR},
                        new MutationRecord {Id = 18, Operator = MuOp.AOR},
                        new MutationRecord {Id = 19, Operator = MuOp.AOR},
                        new MutationRecord {Id = 20, Operator = MuOp.AOR},
                        new MutationRecord {Id = 21, Operator = MuOp.AOR},
                        new MutationRecord {Id = 22, Operator = MuOp.AOR},
                        new MutationRecord {Id = 23, Operator = MuOp.AOR},
                        new MutationRecord {Id = 24, Operator = MuOp.AOR},
                        new MutationRecord {Id = 25, Operator = MuOp.STD},
                    }
                },
                new MutationSpyNode
                {
                    Id = 7,
                    NIPS = 0.8747,
                    NIMMS = 1.0000,
                    NIBF = 1.0000,
                    NIRBF = 1.0000,
                    NIDS = 0.1111,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 26, Operator = MuOp.AOR},
                        new MutationRecord {Id = 27, Operator = MuOp.AOR},
                        new MutationRecord {Id = 28, Operator = MuOp.AOR},
                        new MutationRecord {Id = 29, Operator = MuOp.AOR},
                        new MutationRecord {Id = 30, Operator = MuOp.AOR},
                        new MutationRecord {Id = 31, Operator = MuOp.AOR},
                        new MutationRecord {Id = 32, Operator = MuOp.AOR},
                        new MutationRecord {Id = 33, Operator = MuOp.AOR}
                    }
                }
            };

            new SmartMutator(spyNodes);

            Console.Write("Press any key to close ...");
            System.Console.ReadKey();
        }

        public static void Test1()
        {
            var spyNodes = new List<MutationSpyNode>
            {
                new MutationSpyNode
                {
                    Id = 1,
                    PriorScore = 3,
                    DistinctPassScore = 0,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 1, Operator = MuOp.ABS},
                        new MutationRecord {Id = 2, Operator = MuOp.UOI},
                    }
                },
                new MutationSpyNode
                {
                    Id = 2,
                    PriorScore = 3,
                    DistinctPassScore = 1,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 3, Operator = MuOp.ABS},
                        new MutationRecord {Id = 4, Operator = MuOp.UOI},
                    }
                },
                new MutationSpyNode
                {
                    Id = 3,
                    PriorScore = 3,
                    DistinctPassScore = 2,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 5, Operator = MuOp.ABS},
                        new MutationRecord {Id = 6, Operator = MuOp.UOI},
                    }
                },
                new MutationSpyNode
                {
                    Id = 4,
                    PriorScore = 2,
                    DistinctPassScore = 5,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 7, Operator = MuOp.ROR}
                    }
                },
                new MutationSpyNode
                {
                    Id = 5,
                    PriorScore = 2,
                    DistinctPassScore = 5,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 8, Operator = MuOp.ABS},
                        new MutationRecord {Id = 9, Operator = MuOp.SVR},
                        new MutationRecord {Id = 10, Operator = MuOp.UOI},
                        new MutationRecord {Id = 11, Operator = MuOp.UOD},
                        new MutationRecord {Id = 12, Operator = MuOp.ASR},
                        new MutationRecord {Id = 13, Operator = MuOp.AOR},
                    }
                },
                new MutationSpyNode
                {
                    Id = 6,
                    PriorScore = 2,
                    DistinctPassScore = 5,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 14, Operator = MuOp.UOD}
                    }
                },
                new MutationSpyNode
                {
                    Id = 7,
                    PriorScore = 3,
                    DistinctPassScore = 6,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 15, Operator = MuOp.AOR},
                        new MutationRecord {Id = 16, Operator = MuOp.UOI},
                        new MutationRecord {Id = 17, Operator = MuOp.SVR},
                        new MutationRecord {Id = 18, Operator = MuOp.ABS}
                    }
                },
                new MutationSpyNode
                {
                    Id = 8,
                    PriorScore = 3,
                    DistinctPassScore = 7,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 19, Operator = MuOp.AOR},
                        new MutationRecord {Id = 20, Operator = MuOp.UOI},
                        new MutationRecord {Id = 21, Operator = MuOp.SVR},
                        new MutationRecord {Id = 22, Operator = MuOp.ABS}
                    }
                },
                new MutationSpyNode
                {
                    Id = 9,
                    PriorScore = 3,
                    DistinctPassScore = 8,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 23, Operator = MuOp.ABS},
                        new MutationRecord {Id = 24, Operator = MuOp.UOI}
                    }
                },
                new MutationSpyNode
                {
                    Id = 10,
                    PriorScore = 3,
                    DistinctPassScore = 9,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 25, Operator = MuOp.ABS},
                        new MutationRecord {Id = 26, Operator = MuOp.UOI}
                    }
                },
                new MutationSpyNode
                {
                    Id = 11,
                    PriorScore = 3,
                    DistinctPassScore = 13,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 27, Operator = MuOp.ROR}
                    }
                },
                new MutationSpyNode
                {
                    Id = 12,
                    PriorScore = 2,
                    DistinctPassScore = 13,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 28, Operator = MuOp.ABS},
                        new MutationRecord {Id = 29, Operator = MuOp.SVR},
                        new MutationRecord {Id = 30, Operator = MuOp.UOI},
                        new MutationRecord {Id = 31, Operator = MuOp.UOD},
                        new MutationRecord {Id = 32, Operator = MuOp.ASR},
                        new MutationRecord {Id = 33, Operator = MuOp.AOR}
                    }
                },
                new MutationSpyNode
                {
                    Id = 13,
                    PriorScore = 2,
                    DistinctPassScore = 13,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 34, Operator = MuOp.UOD}
                    }
                },
                new MutationSpyNode
                {
                    Id = 14,
                    PriorScore = 3,
                    DistinctPassScore = 13,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 35, Operator = MuOp.AOR},
                        new MutationRecord {Id = 36, Operator = MuOp.UOI},
                        new MutationRecord {Id = 37, Operator = MuOp.SVR},
                        new MutationRecord {Id = 38, Operator = MuOp.ABS}
                    }
                },
                new MutationSpyNode
                {
                    Id = 15,
                    PriorScore = 3,
                    DistinctPassScore = 14,
                    MutationList = new List<MutationRecord>
                    {
                        new MutationRecord {Id = 39, Operator = MuOp.UOI},
                        new MutationRecord {Id = 40, Operator = MuOp.SVR},
                        new MutationRecord {Id = 41, Operator = MuOp.ABS}
                    }
                }
            };
            
            new SmartMutator(spyNodes);

            Console.Write("Press any key to close ...");
            System.Console.ReadKey();
        }

        public static void LogParserTest()
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
        }
    }
}
