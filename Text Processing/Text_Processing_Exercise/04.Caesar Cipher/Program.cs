using System;
using System.Text;

namespace _04.Caesar_Cipher
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();

            StringBuilder encryptedText = EncryptedMessage(text);

            Console.WriteLine(encryptedText);
        }

        private static StringBuilder EncryptedMessage(string text)
        {
            var encryptedText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                var currentSymbol = text[i] + 3;

                encryptedText.Append((char)currentSymbol);
            }

            return encryptedText;
        }
    }
}
