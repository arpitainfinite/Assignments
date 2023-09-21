using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBaseTest_2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public Undergraduate(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public Graduate(string name, int studentId, double grade)
        {
            Name = name;
            StudentId = studentId;
            Grade = grade;
        }

        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of Undergraduate student: ");
            string undergradName = Console.ReadLine();

            Console.Write("Enter the student ID of Undergraduate student: ");
            int undergradId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the grade for Undergraduate student: ");
            double undergradGrade = Convert.ToDouble(Console.ReadLine());

            Undergraduate undergradStudent = new Undergraduate(undergradName, undergradId, undergradGrade);

            Console.Write("\nEnter the name of Graduate student: ");
            string gradName = Console.ReadLine();

            Console.Write("Enter the student ID of Graduate student: ");
            int gradId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the grade for Graduate student: ");
            double gradGrade = Convert.ToDouble(Console.ReadLine());

            Graduate gradStudent = new Graduate(gradName, gradId, gradGrade);

            Console.WriteLine("\nResults:");
            Console.WriteLine($"Undergraduate {undergradStudent.Name} (ID: {undergradStudent.StudentId}) Passed: {undergradStudent.IsPassed(undergradStudent.Grade)}");
            Console.WriteLine($"Graduate {gradStudent.Name} (ID: {gradStudent.StudentId}) Passed: {gradStudent.IsPassed(gradStudent.Grade)}");
            Console.ReadLine();
        }
    }

}
