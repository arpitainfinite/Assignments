using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public double GetShapeArea()
        {
            return Math.PI * Radius * Radius;
        }
        public string GetShapeType()
        {
            return "Circle Shape";
        }

        public double GetShapePerimeter()
        {
            return 2* Math.PI* Radius;
        }
        
    }
}
