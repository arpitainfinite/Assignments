using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
        public class TicketCalculator
        {
            const int TotalFare = 500;
            public static void CalculateConcession(int age, string name)
            {
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Age: {age}");



            if (age <= 5)
            {
                Console.WriteLine("Little Champs- Free Ticket");
            }
            else if (age > 60)
            {
                int fare = (int)(0.7 * TotalFare); // 30% concession for senior citizens
                Console.WriteLine($"Senior Citizen: {fare}/-");
            }
            else
            {
                Console.WriteLine($"Ticket Booked: {TotalFare}/-");

            }
            Console.ReadLine();
        }
        }
    }
