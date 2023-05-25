namespace ThousandMonkeys.cs.Genetics
{
    public class Dna
    {
        #region Atributes and Constructor
        public List<string> Genes { get; set; }
        public int Fitness { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// Constructor of the Dna
        /// </summary>
        /// <param name="size"></param>
        public Dna(int size)
        {
            Size = size;
            Fitness = 0;
            Init();
        }
        #endregion


        #region Methods
        /// <summary>
        /// Initialize the genes of the Dna
        /// </summary>
        /// <returns>list<string></returns>
        public List<string> Init()
        {
            Genes = new List<string>();
            for (int i = 0; i < Size; i++)
            {
                Genes.Add(Utils.GetRandomCharacter());
            }
            return Genes;
        }

        /// <summary>
        /// Calculate the fitness of the Dna
        /// </summary>
        /// <param name="Target"></param>
        public void CalculateFitness(string Target)
        {
            int score = 0;
            for (int i = 0; i < Genes?.Count; i++)
            {
                if (Genes[i].Equals(Target[i].ToString()))
                {
                    score++;
                }
            }
            Fitness = score;
        }

        /// <summary>
        /// Return a new Dna with the genes of the parents, (the reproduction function)
        /// </summary>
        /// <param name="parent"></param>
        /// <returns>Dna</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Dna Crossover(Dna parent)
        {
            if(parent is null || parent.Genes is null)
            {
                throw new ArgumentNullException(nameof(parent));
            }

            Dna child = new Dna(Size);
            int midPoint = Utils.GetRandomNumber(0, Genes.Count - 1);

            for (int i = 0; i < Genes?.Count; i++)
            {
                if (midPoint > i)
                {
                    child.Genes?.Insert(i, Genes[i]);
                }
                else
                {
                    child.Genes?.Insert(i, parent.Genes[i]);
                }
            }
            return child;
        }

        /// <summary>
        /// Return a new Dna with the genes mutated
        /// </summary>
        /// <param name="mutationRate"></param>
        public void Mutate(double mutationRate)
        {
            for (int i = 0; i < Genes?.Count; i++)
            {
                if (Utils.GetRandomNumber(0, 100) < mutationRate * 100)
                {
                    Genes.Insert(i, Utils.GetRandomCharacter());
                }
            }
        }
        #endregion


        #region ShowMethods

        /// <summary>
        /// Return a string with the genes and the fitness
        /// </summary>
        /// <returns>string</returns>
        public string Show()
        {
            return $" GEN: [  {string.Join(" || ", Genes)}  ] , FITNESS: {Fitness} ";
        }
        #endregion
    }
}