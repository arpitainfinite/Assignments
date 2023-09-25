using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase_Test_3
{
    class Box
    {
        private double length;
        private double breadth;

        public Box(double length, double breadth)
        {
            this.length = length;
            this.breadth = breadth;
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public double Breadth
        {
            get { return breadth; }
            set { breadth = value; }
        }

        public static Box AddBoxes(Box box1, Box box2)
        {
            double newLength = box1.Length + box2.Length;
            double newBreadth = box1.Breadth + box2.Breadth;
            return new Box(newLength, newBreadth);
        }

        public void DisplayBoxDetails()
        {
            Console.WriteLine("Box Length: " + length);
            Console.WriteLine("Box Breadth: " + breadth);
        }
    }

    class TestBox
    {
        static void Main()
        {
            Console.WriteLine("Enter dimensions for Box 1:");
            Console.Write("Length: ");
            double length1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nEnter dimensions for Box 2:");
            Console.Write("Length: ");
            double length2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Breadth: ");
            double breadth2 = Convert.ToDouble(Console.ReadLine());

            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);
            Box box3 = Box.AddBoxes(box1, box2);

            Console.WriteLine("\nDetails of Box 1:");
            box1.DisplayBoxDetails();

            Console.WriteLine("\nDetails of Box 2:");
            box2.DisplayBoxDetails();

            Console.WriteLine("\nDetails of Box 3 (Sum of Box 1 and Box 2):");
            box3.DisplayBoxDetails();
            Console.ReadLine();
        }
    }
}
