using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class task3
    {
        static void Main()
        {
            Console.Write("Enter the first word: ");
            string word1 = Console.ReadLine();

            Console.Write("Enter the second word: ");
            string word2 = Console.ReadLine();

            if (string.Equals(word1, word2))
            {
                Console.WriteLine("Both the words are same.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Both the words are different.");
                Console.ReadLine();
            }
        }
    }
}
