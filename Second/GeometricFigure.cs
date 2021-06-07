using System;

namespace Second
{
    public abstract class GeometricFigure : IPrint
    {
        public abstract double CalcArea();

        public void Print()
            => Console.WriteLine(ToString());
    }
}