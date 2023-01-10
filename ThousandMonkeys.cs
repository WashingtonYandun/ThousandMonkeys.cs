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
            Population population = new Population("Washington.Yandun", 0.2, 40);
            population.CalculateFitness();
            //population.NaturalSelection();
            Console.WriteLine(population.GetMaxFitness());

            Console.WriteLine(population.Show());
            Console.WriteLine("\n");
            Console.WriteLine(population.ShowPool());


            //population.Generate();
            //population.Evaluate();
        }
    }
}
