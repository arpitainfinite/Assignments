using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Ticket Booking System!");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Assignment_6.TicketCalculator.CalculateConcession(age, name);
            }
            else
            {
                Console.WriteLine("Invalid age input.");
            }
        }
    }
}
