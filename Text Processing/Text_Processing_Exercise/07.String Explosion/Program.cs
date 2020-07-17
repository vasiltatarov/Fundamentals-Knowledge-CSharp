using System;
using System.Text;

namespace _07.String_Explosion
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();

            StringBuilder result = RemoveStringExplosion(text);

            Console.WriteLine(result);
        }

        private static StringBuilder RemoveStringExplosion(string text)
        {
            var result = new StringBuilder();

            int explosionPower = 0;

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == '>' && char.IsDigit(text[i + 1]))
                {
                    explosionPower += int.Parse(text[i + 1].ToString());
                    result.Append(text[i]);

                    continue;
                }

                if (explosionPower > 0)
                {
                    explosionPower--;
                    continue;
                }

                result.Append(text[i]);
            }

            if (explosionPower == 0)
            {
                result.Append(text[text.Length - 1]);
            }

            return result;
        }
    }
}
