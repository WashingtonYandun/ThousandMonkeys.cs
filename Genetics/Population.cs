namespace ThousandMonkeys.cs.Genetics
{
    public class Population
    {
        #region Atributes and Constructor
        public string Target { get; set; }
        public double MutationRate { get; set; }
        public long MaxPopulation { get; set; }

        public int Generations { get; set; }
        public int PerfectScore { get; set; }
        public List<Dna> DarwinPool { get; set; }
        public List<Dna> CurrentPopulation { get; set; }
        public string Best { get; set; }

        /// <summary>
        /// Constructor of the Population
        /// </summary>
        /// <param name="target"></param>
        /// <param name="mutationRate"></param>
        /// <param name="maxPopulation"></param>
        public Population(string? target, double mutationRate, long maxPopulation)
        {
            Target = target;
            MutationRate = mutationRate;
            MaxPopulation = maxPopulation;
            CurrentPopulation = Init();
        }
        #endregion


        #region Methods

        /// <summary>
        /// Initializates the population
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Calculate the fitness of the population
        /// </summary>
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

        /// <summary>
        /// Compute the natural selection of the population
        /// </summary>
        public void NaturalSelection()
        {
            DarwinPool = new List<Dna>();

            int fitnessSum = 0;
            CurrentPopulation?.ForEach(dna => fitnessSum += dna.Fitness);

            // selection pool
            CurrentPopulation?.ForEach(dna =>
            {
                double fitnessRatio = (double)dna.Fitness / fitnessSum;
                int poolSize = (int)(fitnessRatio * 100);
                for (int i = 0; i < poolSize; i++)
                {
                    DarwinPool.Add(dna);
                }
            });
        }

        /// <summary>
        ///  Reproduction of the population
        /// </summary>
        public void Reproduction()
        {
            Random rnd = new Random();
            for (int i = 0; i < CurrentPopulation?.Count; i++)
            {
                int indexA = Utils.GetRandomNumber(0, DarwinPool.Count - 1);
                int indexB = Utils.GetRandomNumber(0, DarwinPool.Count - 1);

                Dna dnaA = DarwinPool[indexA];
                Dna dnaB = DarwinPool[indexB];

                Dna childDna = dnaA.Crossover(dnaB);
                childDna.Mutate(MutationRate);

                CurrentPopulation.Insert(i, childDna);
            }
            Generations++;
        }

        /// <summary>
        /// Evaluate the population
        /// </summary>
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

        /// <summary>
        /// Check if the population has reached the target
        /// </summary>
        /// <returns>int</returns>
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

        /// <summary>
        /// Show the pool of the population
        /// </summary>
        /// <returns>string</returns>
        public string GetShowPool()
        {
            string data = "";
            DarwinPool?.ForEach(dna =>
            {
                data += $"{dna.Show()} \n";
            });
            return data;
        }

        /// <summary>
        /// Show the pool of the population
        /// </summary>
        public void ShowPool()
        {
            DarwinPool?.ForEach(dna =>
            {
                Console.WriteLine($"{dna.Show()} \n");
            });
        }

        /// <summary>
        /// Show the population and return it
        /// </summary>
        /// <returns>string</returns>
        public string GetShow()
        {
            string data = "";
            CurrentPopulation?.ForEach(dna =>
            {
                data = data + $"{dna.Show()} \n";
            });
            return data;
        }

        /// <summary>
        /// Show the population
        /// </summary>
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
