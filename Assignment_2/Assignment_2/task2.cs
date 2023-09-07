using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class task2
    {
        public static void Main()
        {
            int[] marks = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter mark {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }
            int total = 0;
            foreach (int mark in marks)
            {
                total += mark;
            }
            double average = (double)total / 10;
            int min = marks[0];
            int max = marks[0];
            foreach (int mark in marks)
            {
                if (mark < min)
                {
                    min = mark;
                }
                if (mark > max)
                {
                    max = mark;
                }
            }
            Array.Sort(marks);
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Average: {average:F2}");
            Console.WriteLine($"Minimum marks: {min}");
            Console.WriteLine($"Maximum marks: {max}");
            Console.WriteLine("Marks in ascending order:");
            foreach (int mark in marks)
            {
                Console.Write($"{mark} ");
            }
            Array.Reverse(marks);
            Console.WriteLine("Marks in descending order:\n");
            foreach (int mark in marks)
            {
                Console.Write($"{mark} ");
                Console.ReadLine();
            }
        }
    }
}
