using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class Program1
    {
        static void Main()
        {
            Console.WriteLine("Enter a string:");
            string inputString = Console.ReadLine();

            Console.WriteLine("Enter the letter to be counted:");
            char letterToCount = Console.ReadLine()[0]; 

            int count = CountLetterOccurrences(inputString, letterToCount);

            Console.WriteLine($"The letter '{letterToCount}' appears {count} times in the string.");
            Console.ReadLine();
        }

        static int CountLetterOccurrences(string input, char letter)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (char.ToUpper(c) == char.ToUpper(letter))
                {
                    count++;
                }
            }
            return count;
            Console.ReadLine();
        }
    }

}
