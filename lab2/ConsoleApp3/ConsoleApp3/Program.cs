using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] words = text.Split(' ');
            for (int i = words.Length - 1; i >= 0; i--) {
                Console.Write(words[i] + ' ');
            }
        }
    }
}
