using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThousandMonkeys.cs.Genetics;

namespace ThousandMonkeys.cs
{
    public class ThousandMonkeys
    {
        static void Main(string[] args)
        {
            Population population = new Population("Washington.Yandun", 0.2, 10);
            population.CalculateFitness();
            population.NaturalSelection();
            Console.WriteLine(population.GetMaxFitness());
            population.Generate();
            //population.Evaluate();
        }
    }
}
