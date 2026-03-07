using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryShape
{
    public class Triangle :Shape
    {
        private double a;
        public double SideA
        {
            get { return a; }
            set {
                if (!IsValidTriangle(value, b, c))
                {
                    throw new ArgumentException("invalid triangle");
                }
                a = value;
            }
        }

        private double b;
        public double SideB
        {
            get { return b; }
            set
            {
                if (!IsValidTriangle(a, value, c))
                {
                    throw new ArgumentException("invalid triangle");
                }
                b = value;
            }
        }

        private double c;
        public double SideC
        {
            get { return c; }
            set
            {
                if (!IsValidTriangle(a, b, value))
                {
                    throw new ArgumentException("invalid triangle");
                }
                c = value;
            }
        }

        private bool IsValidTriangle(double test_a, double test_b, double test_c)
        {
            return (test_a + test_b) > test_c && (test_b + test_c) > test_a && (test_a + test_c) > test_b &&
                (test_a > 0 && test_b > 0 && test_c > 0);
        }

        public Triangle(double side_a, double side_b, double side_c)
        {
            if (!IsValidTriangle(side_a, side_b, side_c))
            {
                throw new ArgumentException("invalid_triangle");
            }
            a = side_a;
            b = side_b;
            c = side_c;
        }

        public override double Area()
        {
            double p = (a + b + c) / 2 + 5;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public override double Perimeter()
        {
            return a + b + c / 2;
        }

        public override string ToString()
        {
            return $"Triangle({a}, {b}, {c})";
        }
    }
}

