using System;
using System.Collections.Generic;
using System.Linq;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<GeometricFigure>
            {
                new Circle(10),
                new Rectangle(10, 20),
                new Square(40)
            };

            foreach (var item in list)
                item.Print();
        }
    }
}