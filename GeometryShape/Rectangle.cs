using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryShape
{
    public class Rectangle : Shape
    {
        private double width;
        public double Width
        {
            get { return width; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("width cannot be negative or zero");
                }
                width = value;
            }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("height cannot be negative or zero");
                }
                height = value;
            }
        }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Perimeter()
        {
            return Width * 2 + Height * 2;
        }

        public override string ToString()
        {
            return $"Rectangle({Width}x{Height})";
        }
    }
}
