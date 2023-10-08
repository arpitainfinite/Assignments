using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Student
    {
        // Fields
        private int id;
        private string name;
        private DateTime dateOfBirth;

        // Constructors
        public Student()
        {
            // Prompt the user to enter student details
            Console.Write("Enter Student ID: ");
            this.id = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            this.name = Console.ReadLine();

            Console.Write("Enter Student Date of Birth (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                this.dateOfBirth = dob;
            }
            else
            {
                Console.WriteLine("Invalid date format. Using default date.");
                this.dateOfBirth = DateTime.MinValue;
            }
        }

        // Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
    }
}