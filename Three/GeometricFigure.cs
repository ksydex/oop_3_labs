using System;

namespace Three
{
    public abstract class GeometricFigure : IPrint, IComparable
    {
        public abstract double CalcArea();

        public void Print()
            => Console.WriteLine(ToString());

        public int CompareTo(object? other)
            => CalcArea().CompareTo((other as GeometricFigure)?.CalcArea());
    }
}