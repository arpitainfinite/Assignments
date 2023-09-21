using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class task2
    {
        public static void Main()
        {
            int num;
            Console.Write("Check whether a number is positive or negative: ");
            Console.Write("----------------------------------------------");
            Console.Write("\n\n");
            Console.Write("Input an integer : ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num >= 0)

                Console.WriteLine("{0} is a positive number", num);
            else
                Console.WriteLine("{0} is a negative number", num);
            Console.ReadLine();
        }
    }
}
