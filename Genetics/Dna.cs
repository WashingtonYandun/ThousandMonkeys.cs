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
                Genes.Add(GetRandomCharacter());
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

        public string Show()
        {
            return $" GEN: [  {string.Join(" || ", Genes)}  ] , FITNESS: {Fitness} ";
        }
        #endregion

        #region Utils
        public string GetRandomCharacter()
        {
            Random rnd = new Random();
            char character = (char)rnd.Next(32, 127);
            return character.ToString();
        }
        #endregion
    }
}
