using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{ 
    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        // Constructor with no arguments
        public Customer()
        {
            CustomerId = 0;
            Name = "";
            Age = 0;
            Phone = "";
            City = "";
        }

        // Constructor with all information
        public Customer(int customerId, string name, int age, string phone, string city)
        {
            CustomerId = customerId;
            Name = name;
            Age = age;
            Phone = phone;
            City = city;
        }

        // Method to display customer information
        public void DisplayCustomer()
        {
            Console.WriteLine($"Customer ID: {CustomerId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Phone: {Phone}");
            Console.WriteLine($"City: {City}");
        }

        // Destructor
        ~Customer()
        {
            Console.WriteLine($"====Destructor Initialized====");
        }
    }

    class Program3
    {
        static void Main()
        {
            Console.WriteLine("Enter customer information: ");

            Console.Write("Customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Customer customer = new Customer(customerId, name, age, phone, city);

            Console.WriteLine("************** Customer Details: **************");
            customer.DisplayCustomer();
            Console.ReadLine();
        }
    }

}
