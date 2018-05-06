using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Smart_Mutator.Mutator
{
    public class SmartMutator
    {
        public Individual Fittest { get; set; }
        public Individual SecondFittest { get; set; }
        public int GenerationCount { get; protected set; }
        public Population Population { get; set; }

        private readonly List<MutationSpyNode> _nodes;
        /*
         * each gene is a mutation point in code.
         * value of each element of the array is the mutation id (zero if not mutated)
         */
        private readonly int _chromosomeLength;

        public SmartMutator(List<MutationSpyNode> nodes)
        {
            _nodes = nodes;
            _chromosomeLength = _nodes.Count;

            //Initialize population
            Population = new Population(14, _nodes);

            //Calculate fitness of each individual
            Population.CalculateFitness();

            EvolutionCycle();

            var finalResult = string.Join(", ", Population.GetFittest().Genes.Where(g => g != 0));
            Console.WriteLine($"Final Result Mutations: {finalResult}");
        }

        public void EvolutionCycle()
        {
            var random = new Random();

            Console.WriteLine($"#Generation: {GenerationCount}, Fittest: {Population.Fittest}\nGenes: {string.Join(", ", Population.GetFittest().Genes)}");
            //while (GenerationCount < 10000)
            while (GenerationCount < 100)
            //while (Population.Fittest < 4.2)
            {
                GenerationCount++;

                Selection();

                CrossOver();

                if (random.Next(100) <= 50)
                    Mutation();

                AddFittestOffspring();

                Population.CalculateFitness();
                Console.WriteLine($"#Generation: {GenerationCount}, Fittest: {Population.Fittest}\nGenes: {string.Join(", ", Population.GetFittest().Genes)}");
            }
        }

        public void Selection()
        {
            var fittest = Population.GetFittest();
            Fittest = Population.GetFittest();
            SecondFittest = Population.GetSecondFittest();
        }

        public void CrossOver()
        {
            var rnd = new Random();
            //select a random crossover point
            var crossOverPoint = rnd.Next(_chromosomeLength);
            var a = Population.PopSize;
            //Swap values among parents
            for (var i = 0; i < crossOverPoint; i++)
            {
                var temp = Fittest.Genes[i];
                Fittest.Genes[i] = SecondFittest.Genes[i];
                SecondFittest.Genes[i] = temp;
            }
        }

        public void Mutation()
        {
            var rnd = new Random();
            var mutationPoint = rnd.Next(_chromosomeLength);
            var currentMutationId = Fittest.Genes[mutationPoint];
            var possibleMutation = _nodes[mutationPoint].MutationList.Select(ml => ml.Id).ToList();
            possibleMutation.Add(0);

            int randomMutationId;
            do
            {
                randomMutationId = possibleMutation[rnd.Next(possibleMutation.Count)];
                Fittest.Genes[mutationPoint] = randomMutationId;
            } while (possibleMutation.Count > 1 && randomMutationId == currentMutationId);


            // reusing of variables: mutationPoint, currentMutationId, possibleMutation, randomMutationId
            mutationPoint = rnd.Next(_chromosomeLength);
            currentMutationId = SecondFittest.Genes[mutationPoint];
            possibleMutation = _nodes[mutationPoint].MutationList.Select(ml => ml.Id).ToList();
            possibleMutation.Add(0);

            do
            {
                randomMutationId = possibleMutation[rnd.Next(possibleMutation.Count)];
                SecondFittest.Genes[mutationPoint] = randomMutationId;
            } while (possibleMutation.Count > 1 && randomMutationId == currentMutationId);
        }

        public Individual GetFittestOffspring()
        {
            return Fittest.Fitness > SecondFittest.Fitness ? Fittest : SecondFittest;
        }

        //Replace least fittest individual from most fittest offspring
        public void AddFittestOffspring()
        {
            Fittest.CalcFitness();
            SecondFittest.CalcFitness();

            var leastFittestIndex = Population.GetLeastFittestIndex();
            Population.Individuals[leastFittestIndex] = GetFittestOffspring();
        }
    }

    public class Individual
    {
        public double Fitness { get; set; }
        public int[] Genes { get; set; }
        private readonly int _chromosomeLength;
        protected static IReadOnlyList<MutationSpyNode> Nodes;

        private static readonly Random Random = new Random();
        public Individual(IReadOnlyList<MutationSpyNode> nodes)
        {
            Nodes = nodes;
            _chromosomeLength = nodes.Count;
            //Genes = new int[_chromosomeLength];

            Genes = new int[_chromosomeLength];
            //var random = new Random();
            for (var i = 0; i < _chromosomeLength; i++)
                Genes[i] = nodes[i].GenerateRandomGene(Random);
        }

        public double CalcFitness()
        {
            double result = 0;
            var mutatedCount = 0;
            var operators = new List<MuOp>();
            var mutants = Genes.Where(g => g != 0).ToArray();

            foreach (var node in Nodes)
            {
                var mutant = node.MutationList.FirstOrDefault(m => mutants.Contains(m.Id));

                if (mutant != null) operators.Add(mutant.Operator);
            }

            for (var i = 0; i < _chromosomeLength; i++)
            {
                var gene = Genes[i];
                if (gene == 0)
                    continue;
                mutatedCount++;
                //result += 1 / ((1 + (double)Nodes[i].PriorScore) * (1 + (double)Nodes[i].DistinctPassScore));
                var node = Nodes[i];
                result += node.NIPS + node.NIMMS + node.NIBF + node.NIRBF + node.NIDS;
            }

            if (mutatedCount == 0)
                return Fitness = 0.0;

            // f2
            result /= mutatedCount;

            // f3
            result += 2 * Math.Min(0.0, (double) mutatedCount / _chromosomeLength - 0.5) + (double)operators.Distinct().Count() / mutatedCount;

            return Fitness = result;
        }
    }

    public class Population
    {
        private readonly List<MutationSpyNode> _nodes;
        public int PopSize { get; protected set; }
        public Individual[] Individuals;
        public double Fittest { get; set; }

        public Population(int size, List<MutationSpyNode> nodes)
        {
            _nodes = nodes;
            PopSize = size;

            // initialize population
            Individuals = new Individual[PopSize];
            for (var i = 0; i < PopSize; i++)
                Individuals[i] = new Individual(nodes);
        }

        public Individual GetFittest()
        {
            //var maxFit = double.NegativeInfinity;
            //var maxFitIndex = 0;
            //for (var i = 0; i < Individuals.Length; i++)
            //{
            //    if (maxFit <= Individuals[i].Fitness)
            //    {
            //        maxFit = Individuals[i].Fitness;
            //        maxFitIndex = i;
            //    }
            //}
            //Fittest = Individuals[maxFitIndex].Fitness;
            //Console.WriteLine($"max fit index: {maxFitIndex}");
            //return Individuals[maxFitIndex];
            var fittest = Individuals.OrderByDescending(i => i.Fitness).FirstOrDefault();
            Fittest = fittest.Fitness;
            return new Individual(_nodes)
            {
                Fitness = fittest.Fitness,
                Genes = fittest.Genes.ToArray()
            };
        }

        public Individual GetSecondFittest()
        {
            //var maxFitIndex1 = 0;
            //var maxFitIndex2 = 0;
            //for (var i = 0; i < Individuals.Length; i++)
            //{
            //    if (Individuals[i].Fitness > Individuals[maxFitIndex1].Fitness)
            //    {
            //        maxFitIndex2 = maxFitIndex1;
            //        maxFitIndex1 = i;
            //    }
            //    else if (Individuals[i].Fitness > Individuals[maxFitIndex2].Fitness)
            //    {
            //        maxFitIndex2 = i;
            //    }
            //}
            //Console.WriteLine($"second max fit index: {maxFitIndex2}");
            //return Individuals[maxFitIndex2];
            var secondFittest = Individuals.OrderByDescending(i => i.Fitness).Skip(1).FirstOrDefault();
            return new Individual(_nodes)
            {
                Fitness = secondFittest.Fitness,
                Genes = secondFittest.Genes.ToArray()
            };
        }

        public int GetLeastFittestIndex()
        {
            var minFitVal = double.PositiveInfinity;
            var minFitIndex = 0;
            for (var i = 0; i < Individuals.Length; i++)
            {
                if (minFitVal >= Individuals[i].Fitness)
                {
                    minFitVal = Individuals[i].Fitness;
                    minFitIndex = i;
                }
            }
            return minFitIndex;
        }

        public double CalculateFitness()
        {
            foreach (var individual in Individuals)
            {
                individual.CalcFitness();
            }

            return GetFittest().Fitness;
        }
    }

    /*
     * Possible Mutations
     * -node id
     * -list of operators
     * -mutation id for each operator
     */
}
