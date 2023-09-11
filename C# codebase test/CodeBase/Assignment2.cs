using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeBase
{

    class Assignment2
    {
        static void Main()
        {
            Console.WriteLine("Enter the number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= 10; i++)
                
            {
                Console.WriteLine(num + "*" + i + "=" + num * i);
            }
            Console.ReadLine();
        }
    }
}

