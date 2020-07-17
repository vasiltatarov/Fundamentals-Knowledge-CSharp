using System;
using System.Numerics;

namespace _05.Multiply_Big_Number
{
    class Program
    {
        static void Main()
        {
            var firstNumber = BigInteger.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());

            var result = MultiplyTwoNumbers(firstNumber, secondNumber);

            Console.WriteLine(result);
        }

        private static BigInteger MultiplyTwoNumbers(BigInteger firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}
