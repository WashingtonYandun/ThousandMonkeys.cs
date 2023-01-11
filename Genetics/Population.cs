using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThousandMonkeys.cs.Genetics
{
    public class Population
    {
        #region Atributes and Constructor
        public string? Target { get; set; }
        public double MutationRate { get; set; }
        public long MaxPopulation { get; set; }

        public int Generations { get; set; }
        public int PerfectScore { get; set; }
        public List<Dna>? DarwinPool { get; set; }
        public List<Dna>? CurrentPopulation { get; set; }
        public string? Best { get; set; }

        public Population(string? target, double mutationRate, long maxPopulation)
        {
            Target = target;
            MutationRate = mutationRate;
            MaxPopulation = maxPopulation;
            CurrentPopulation = Init();
        }
        #endregion


        #region Methods
        public List<Dna> Init()
        {
            List<Dna> population = new List<Dna>();
            for (int i = 0; i < MaxPopulation; i++)
            {
                if (Target is not null)
                {
                    population.Add(new Dna(Target.Length));
                }
            }
            return population;
        }

        public void CalculateFitness()
        {
            CurrentPopulation?.ForEach(dna =>
            {
                if (Target is not null)
                {
                    dna.CalculateFitness(Target);
                }
            });
        }

        public void NaturalSelection()
        {
            //DarwinPool = new List<Dna>();
            //int maxFitness = GetMaxFitness();

            //CurrentPopulation?.ForEach(dna =>
            //{
            //    double fitness = dna.Fitness / 16;
            //    int length = dna.Fitness * 100;
            //    for (int i = 0; i < length; i++)
            //    {
            //        DarwinPool.Add(dna);
            //    }
            //});
        }

        public void Reproduction()
        {
            Random rnd = new Random();
            for (int i = 0; i < CurrentPopulation?.Count; i++)
            {
                int indexA = rnd.Next(0, DarwinPool.Count - 1);
                int indexB = rnd.Next(0, DarwinPool.Count - 1);
                Dna dnaA = DarwinPool[indexA];
                Dna dnaB = DarwinPool[indexB];

                Dna childDna = dnaA.Crossover(dnaB);
                childDna.Mutate(MutationRate);
                CurrentPopulation[i] = childDna;
            }
            Generations++;
        }

        public void Evaluate()
        {
            int maxFitness = 0;
            CurrentPopulation?.ForEach(dna =>
            {
                if (dna.Fitness > maxFitness)
                {
                    maxFitness = dna.Fitness;
                    Best = string.Join("", dna.Genes);
                }
            });
        }

        public int GetMaxFitness()
        {
            int maxFitness = 0;
            CurrentPopulation?.ForEach(dna =>
            {
                if (dna.Fitness > maxFitness)
                {
                    maxFitness = dna.Fitness;
                }
            });
            return maxFitness;
        }
        #endregion


        #region ShowMethods
        public string GetShowPool()
        {
            string data = "";
            DarwinPool?.ForEach(dna =>
            {
                data = data + $"{dna.Show()} \n";
            });
            return data;
        }

        public void ShowPool()
        {
            DarwinPool?.ForEach(dna =>
            {
                Console.WriteLine($"{dna.Show()} \n");
            });
        }
        public string GetShow()
        {
            string data = "";
            CurrentPopulation?.ForEach(dna =>
            {
                data = data + $"{dna.Show()} \n";
            });
            return data;
        }

        public void Show()
        {
            CurrentPopulation?.ForEach(dna =>
            {
                Console.WriteLine($"{dna.Show()} \n");
            });
        }

        #endregion
    }
}
