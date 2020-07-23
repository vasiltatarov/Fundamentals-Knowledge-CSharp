using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main()
        {
            var demons = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var demonsList = new List<Demon>();

            foreach (var demon in demons)
            {
                var health = FindDemonHealth(demon);
                var damage = FindDemonDamage(demon);

                var currDemon = new Demon(demon, health, damage);

                demonsList.Add(currDemon);
            }

            Demon.PrintDemons(demonsList);
        }

        private static double FindDemonDamage(string demon)
        {
            double damage = 0;
            var numbersAndSymbolsPattern = @"[-+]?\d+[.]?\d*|[*\/]";

            var matchNumbers = Regex.Matches(demon, numbersAndSymbolsPattern);

            var multiplyOrDevision = string.Empty;

            foreach (Match symbol in matchNumbers)
            {
                var currSymbol = symbol.Value;

                if (currSymbol == "*" || currSymbol == "/")
                {
                    multiplyOrDevision += currSymbol;
                }
                else
                {
                    damage += double.Parse(currSymbol);
                }
            }

            if (damage == 0)
            {
                return damage;
            }

            for (int i = 0; i < multiplyOrDevision.Length; i++)
            {
                if (multiplyOrDevision[i] == '*')
                {
                    damage *= 2;
                }
                else
                {
                    damage /= 2;
                }
            }

            return damage;
        }

        static int FindDemonHealth(string demon)
        {
            int sum = 0;
            var charactersPattern = @"[^0-9-+.\/*]";

            var matchChars = Regex.Matches(demon, charactersPattern);

            foreach (var symbol in matchChars)
            {
                sum += char.Parse(symbol.ToString());
            }

            return sum;
        }
    }
}
