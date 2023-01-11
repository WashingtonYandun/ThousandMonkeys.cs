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

        public List<Dna> Init()
        {
            List<Dna> population = new List<Dna>();
            for (int i = 0; i < MaxPopulation; i++)
            {
                if (Target is not null) population.Add(new Dna(Target.Length));
            }
            return population;
        }

        #endregion

        #region Methods
        public void CalculateFitness()
        {
            for (int i = 0; i < CurrentPopulation?.Count; i++)
            {
                if (Target is not null) CurrentPopulation[i].CalculateFitness(Target);
            }
        }

        public void NaturalSelection()
        {
            DarwinPool = new List<Dna>();
            int maxFitness = GetMaxFitness();
            for (int i = 0; i < CurrentPopulation?.Count; i++)
            {
                int fitnessNormal = (int)Math.Floor((double)(CurrentPopulation[i].Fitness / maxFitness) * 100);
                for (int j = 0; j < fitnessNormal; j++)
                {
                    DarwinPool.Add(CurrentPopulation[i]);
                }
            }
        }

        public int GetMaxFitness()
        {
            int max = 0;
            if (CurrentPopulation is not null)
            {
                CurrentPopulation.Max(dna => dna.Fitness);
            }
            return max;
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
