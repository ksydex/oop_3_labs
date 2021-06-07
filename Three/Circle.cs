using System;

namespace Three
{
    public class Circle : GeometricFigure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalcArea()
            => Math.PI * Radius * Radius;
        
        public override string ToString()
            => $"Круг: radius={Radius}, S={CalcArea()}";
    }
}