using System;
using System.Diagnostics.Metrics;

namespace ShapeMeasurementSystem
{
    class ShapeMeasurementProgram
    {
        static void Main()
        {
            // Create instances of different shapes
            var circle = new GeometryUtility.Shape.Circle(5);
            var rectangle = new GeometryUtility.Shape.Rectangle(4, 6);
            var triangle = new GeometryUtility.Shape.Triangle(3, 8);

            // Display areas of the shapes
            Console.WriteLine($"Circle Area: {circle.CalculateArea()}");
            Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}");
            Console.WriteLine($"Triangle Area: {triangle.CalculateArea()}");

            Console.ReadKey();
        }
    }

    public class GeometryUtility
    {
        // Nested types for shapes
        public class Shape
        {
            // Nested class for representing a Circle
            public class Circle
            {
                private double _radius;

                public Circle(double radius)
                {
                    _radius = radius;
                }

                public double CalculateArea()
                {
                    return Math.PI * _radius * _radius;
                }
            }

            // Nested class for representing a Rectangle
            public class Rectangle
            {
                private double _length;
                private double _width;

                public Rectangle(double length, double width)
                {
                    _length = length;
                    _width = width;
                }

                public double CalculateArea()
                {
                    return _length * _width;
                }
            }

            // Nested class for representing a Triangle
            public class Triangle
            {
                private double _base;
                private double _height;

                public Triangle(double @base, double height)
                {
                    _base = @base;
                    _height = height;
                }

                public double CalculateArea()
                {
                    return 0.5 * _base * _height;
                }
            }
        }
    }
}
