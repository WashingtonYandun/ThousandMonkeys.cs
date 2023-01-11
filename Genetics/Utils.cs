using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThousandMonkeys.cs.Genetics
{
    public class Utils
    {
        public static string GetRandomCharacter()
        {
            Random rnd = new Random();
            char character = (char)rnd.Next(32, 127);
            return character.ToString();
        }

        public static int GetRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
