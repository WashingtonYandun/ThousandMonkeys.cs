namespace ThousandMonkeys.cs.Genetics
{
    public class Utils
    {
        #region Atributes
        private static readonly Random rnd = new Random();
        #endregion

        #region Methods
        /// <summary>
        /// Return a random character from ASCII table
        /// </summary>
        /// <returns>string</returns>
        public static string GetRandomCharacter()
        {
            char character = (char)rnd.Next(32, 127);
            return character.ToString();
        }

        /// <summary>
        /// Return a random number between min and max
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>int</returns>
        public static int GetRandomNumber(int min, int max)
        {
            return rnd.Next(min, max);
        }
        #endregion
    }

}
