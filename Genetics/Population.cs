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
                if (Target is not null) population.Add(new Dna(Target.Length));
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
            DarwinPool = new List<Dna>();
            int maxFitness = GetMaxFitness();

            CurrentPopulation?.ForEach(dna =>
            {
                double fitness = dna.Fitness / maxFitness;
                int length = dna.Fitness * 100;
                for (int i = 0; i < length; i++)
                {
                    DarwinPool.Add(dna);
                }
            });
        }

        public void Generate()
        {

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
