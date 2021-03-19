using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random rnd = new Random();
            int size = rnd.Next(1, 4);
            string text = "";
            for (int i = 0; i < size; i++) {
                text = text + alphabet[rnd.Next(1, alphabet.Length)];
            }
            Console.WriteLine(text);
        }
    }
}
