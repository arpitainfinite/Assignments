using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    class Triangle : IShape
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(double base_, double height)
        {
            Base = base_;
            Height = height;
        }

        public double GetShapeArea()
        {
            return 0.5 * Base * Height;
        }
        public string GetShapeType()
        {
            return "Triangle Shape";
        }

        public double GetShapePerimeter()
        {
            return 3 * Base;
        }
    }
}
