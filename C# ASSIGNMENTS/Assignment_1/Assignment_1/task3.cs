using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class task3
    {
        public static void Main()
        {
            int x, y;
            char operation;
            Console.Write("Enter first number: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter operation to perform: ");
            operation = Convert.ToChar(Console.ReadLine());
            Console.Write("Enter second number: ");
            y = Convert.ToInt32(Console.ReadLine());

            if (operation == '+')
                Console.WriteLine("{0} + {1} = {2}", x, y, x + y);
            else if (operation == '-')
                Console.WriteLine("{0} - {1} = {2}", x, y, x - y);
            else if ((operation == 'x') || (operation == '*'))
                Console.WriteLine("{0} * {1} = {2}", x, y, x * y);
            else if (operation == '/')
                Console.WriteLine("{0} / {1} = {2}", x, y, x / y);
            else
                Console.WriteLine("Wrong Character");
            Console.ReadLine();
        }
    }
}
