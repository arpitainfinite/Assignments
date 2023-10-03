using System;

namespace CaseStudy1
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }

    public class Info
    {
        public void Display(Student student)
        {
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Date of Birth: {student.DateOfBirth.ToShortDateString()}");
            Console.WriteLine();
        }
    }

    public class App
    {
        public static void Main(string[] args)
        {
            Scenario1();
            Scenario2();
        }
        public static void Scenario1()
        {
            Console.Write("Enter the number of students for Scenario 1: ");
            int numStudents = int.Parse(Console.ReadLine());
            Student[] students = new Student[numStudents];
            for (int i = 0; i < numStudents; i++)
            {
                Console.WriteLine($"\nEnter details for Student {i + 1}:");
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
                students[i] = new Student(id, name, dob);
            }
            Console.WriteLine("\nStudent Details for Scenario 1:");
            Info info = new Info();
            foreach (Student student in students)
            {
                info.Display(student);
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }
        public static void Scenario2()
        {
            Console.Write("\nEnter the number of students for Scenario 2: ");
            int numStudents = int.Parse(Console.ReadLine());
            Student[] studentsArray = new Student[numStudents];
            for (int i = 0; i < numStudents; i++)
            {
                Console.WriteLine($"\nEnter details for Student {i + 1}:");
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", null);
                studentsArray[i] = new Student(id, name, dob);
            }
            Console.WriteLine("\nStudent Details for Scenario 2:");
            Info info = new Info();
            foreach (Student student in studentsArray)
            {
                info.Display(student);
            }
            Console.ReadLine();
        }
    }
}