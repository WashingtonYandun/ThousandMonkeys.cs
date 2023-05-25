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
            Console.WriteLine("Target reached!");
            string target = "HELLO"; // El objetivo es encontrar esta cadena
            double mutationRate = 0.01; // Tasa de mutación
            long maxPopulation = 10; // Tamaño máximo de la población

            Population population = new Population(target, mutationRate, maxPopulation);

            while (population.GetMaxFitness() < target.Length)
            {
                population.CalculateFitness();
                population.NaturalSelection();
                population.Reproduction();
                population.Evaluate();

                Console.WriteLine($"Generation: {population.Generations} - Best: {population.Best}");
            }

            Console.WriteLine("Target reached!");
        }
    }
}
