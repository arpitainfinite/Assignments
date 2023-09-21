using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            string userInput = Console.ReadLine();

            int wordLength = userInput.Length;

            Console.WriteLine($"The length of the word '{userInput}' is {wordLength}");
            Console.ReadLine();
        }
    }
}
