using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    public class ShapeFactory
    {
        public static IShape GetShape(string shapeType, double[] parameters)
        {
            IShape shape = null;
            switch (shapeType)
            {
                case "Triangle":
                    if (parameters.Length == 2)
                    {
                        shape = new Triangle(parameters[0], parameters[1]);
                    }
                    break;

                case "Rectangle":
                    if (parameters.Length == 2)
                    {
                        shape = new Rectangle(parameters[0], parameters[1]);
                    }
                    break;

                case "Circle":
                    if (parameters.Length == 1)
                    {
                        shape = new Circle(parameters[0]);
                    }
                    break;

                default:
                    break;
            }
            return shape;
        }
    }
}
