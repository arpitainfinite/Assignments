using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter shape type :");
            string shapeType = Console.ReadLine();

            if (shapeType == "Triangle" || shapeType == "Rectangle" || shapeType == "Circle")
            {
                double[] parameters;

                if (shapeType == "Triangle")
                {

                    Console.WriteLine("Enter base:");
                    double breadth = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter height:");
                    double height = double.Parse(Console.ReadLine());

                    parameters = new double[] { breadth, height };
                }
                else if (shapeType == "Rectangle")
                {
                    Console.WriteLine("Enter length:");
                    double length = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Breadth:");
                    double width = double.Parse(Console.ReadLine());

                    parameters = new double[] { length, width };
                }
                else if (shapeType == "Circle")
                {
                    Console.WriteLine("Enter Radius:");
                    double radius = double.Parse(Console.ReadLine());

                    parameters = new double[] { radius };
                }
                else
                {
                    parameters = new double[] { }; // Default empty array
                }

                IShape cc = ShapeFactory.GetShape(shapeType, parameters);

                if (cc != null)
                {
                    Console.WriteLine("\nShape Type: {0}", cc.GetShapeType());
                    Console.WriteLine("\nShape Area: {0}", cc.GetShapeArea());
                    Console.WriteLine("\nShape Perimeter: {0}", cc.GetShapePerimeter());
                }
                else
                {
                    Console.WriteLine("Invalid shape.. please give correct type");
                }
            }
            else
            {
                Console.WriteLine("Invalid shape.. please give correct type");
            }
            Console.Read();
        }
    }
}
