using ThousandMonkeys.cs.Genetics;

namespace ThousandMonkeys.cs.Genetics
{
    public class Dna
    {
        #region Atributes and Constructor
        public List<string>? Genes { get; set; }
        public int Fitness { get; set; }
        public int Size { get; set; }

        public Dna(int size)
        {
            Size = size;
            Fitness = 0;
            Init();
        }
        #endregion


        #region Methods
        public List<string> Init()
        {
            Genes = new List<string>();
            for (int i = 0; i < Size; i++)
            {
                Genes.Add(Utils.GetRandomCharacter());
            }
            return Genes;
        }

        public void CalculateFitness(string Target)
        {
            int score = 0;
            for (int i = 0; i < Genes?.Count; i++)
            {
                if (Genes[i] == Target[i].ToString())
                {
                    score++;
                }
            }
            Fitness = score;
        }

        public Dna Crossover(Dna parent)
        {
            Dna child = new Dna(Size);
            int? midPoint = Utils.GetRandomNumber(0, Genes.Count - 1);
            for (int i = 0; i < Genes?.Count; i++)
            {
                if (midPoint > i)
                {
                    child.Genes[i] = Genes[i];
                }
                else
                {
                    child.Genes[i] = parent.Genes[i];
                }
            }
            return child;
        }

        public void Mutate(double mutationRate)
        {
            for (int i = 0; i < Genes?.Count; i++)
            {
                if (Utils.GetRandomNumber(0, 100) < mutationRate * 100)
                {
                    Genes[i] = Utils.GetRandomCharacter();
                }
            }
        }
        #endregion


        #region ShowMethods
        public string Show()
        {
            return $" GEN: [  {string.Join(" || ", Genes)}  ] , FITNESS: {Fitness} ";
        }
        #endregion
    }
}
