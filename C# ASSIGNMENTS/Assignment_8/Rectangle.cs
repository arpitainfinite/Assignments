using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    class Rectangle : IShape
    {
        public double Length { get; }
        public double Breadth { get; }

        public Rectangle(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public double GetShapeArea()
        {
            return Length * Breadth;
        }

        public string GetShapeType()
        {
            return "Rectangle Shape";
        }
    }
}
