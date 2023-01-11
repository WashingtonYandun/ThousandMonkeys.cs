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
            Population population = new Population("Washington.Yandun", 0.5, 10);

            //while (population.Best != population.Target)
            //{
            //    population.CalculateFitness();
            //    population.NaturalSelection();
            //    population.Reproduction();
            //    population.Evaluate();
            //    Console.WriteLine(population.Best);
            //}
            
            

            //population.Evaluate();
        }
    }
}
