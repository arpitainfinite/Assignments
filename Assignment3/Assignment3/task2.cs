using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class task2
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a String : ");
            string originalString = Console.ReadLine();
            string reverseString = string.Empty;
            foreach (char c in originalString)
            {
                reverseString = c + reverseString;
            }
            Console.Write($"Reverse String is : {reverseString} ");
            Console.ReadLine();
        }
    }
}
