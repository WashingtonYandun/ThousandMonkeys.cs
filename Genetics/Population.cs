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
            CurrentPopulation = new List<Dna>();
            for (int i = 0; i < MaxPopulation; i++)
            {
                CurrentPopulation.Add(new Dna(Target.Length));
            }
            return CurrentPopulation;
        }

        #endregion

        #region Methods
        public void CalculateFitness()
        {
            CurrentPopulation?.ForEach(
                dna => dna.CalculateFitness(Target)
                );
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

        public int GetMaxFitness()
        {
            return CurrentPopulation.Max(dna => dna.Fitness);
        }

        public string ShowPool()
        {
            string data = $"";
            DarwinPool?.ForEach(dna =>
            {
                data = data + dna.Show();
            });
            return data;
        }

        public string Show()
        {
            string data = $"";
            CurrentPopulation?.ForEach(dna =>
            {
                data = data + dna.Show() + "\n";
            });
            return data;
        }

        #endregion

    }
}
