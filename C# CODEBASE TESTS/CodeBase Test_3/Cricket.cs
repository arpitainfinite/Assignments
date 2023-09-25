using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase_Test_3
{
    class Cricket
    {
        public void Pointscalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.WriteLine($"Enter the scores for IPL match {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int score))
                {
                    scores[i] = score;
                    sum += score;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid score.");
                }
            }

            double average = (double)sum / no_of_matches;
            Console.WriteLine($"\nSum of scores of Match 1 and Match 2: {sum}");
            Console.WriteLine($"\nAverage score of Match 1 and Match 2: {average:F2}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter the number of IPL matches: ");
            if (int.TryParse(Console.ReadLine(), out int no_of_matches))
            {
                Cricket cricket = new Cricket();
                cricket.Pointscalculation(no_of_matches);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number of matches.");
            }
            Console.ReadLine();
        }
    }
}
