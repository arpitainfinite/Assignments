using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase
{
    class Assignment1
    {
        static void Main()
        {
            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();

            Console.Write("Enter the position to remove): ");
            int position = Convert.ToInt32(Console.ReadLine());

            if (position >= 0 && position < inputString.Length)
            {
                string result = inputString.Remove(position, 1);
                Console.WriteLine("Modified string: " + result);
            }
            else
            {
                Console.WriteLine("Invalid position. The string remains unchanged");
            }
            Console.ReadLine();
        }

    }
}
