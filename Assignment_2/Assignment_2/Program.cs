using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of integers you want to store in the array: ");
            int n = int.Parse(Console.ReadLine());
            int[] myArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter integer {i + 1}: ");
                myArray[i] = int.Parse(Console.ReadLine());
            }
            int sum = 0;
            int min = myArray[0];
            int max = myArray[0];

            foreach (int value in myArray)
            {
                sum += value;

                if (value < min)
                {
                    min = value;
                }

                if (value > max)
                {
                    max = value;
                }
            }
            double average = (double)sum / n;
            Console.WriteLine("Values in the array:");
            foreach (int value in myArray)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine($"Average: {average}");
            Console.WriteLine($"Minimum: {min}");
            Console.WriteLine($"Maximum: {max}");
            Console.ReadLine();
        }
    }
}
