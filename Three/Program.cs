using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Three
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayList = new ArrayList
            {
                new Circle(20),
                new Rectangle(30, 20),
                new Square(50)
            };
            
            arrayList.Sort();
            
            arrayList.Sort();
            foreach (var item in arrayList)
                (item as GeometricFigure)?.Print();
            
            Console.WriteLine("---------------------");
            
            var list = new List<GeometricFigure>
            {
                new Circle(10),
                new Rectangle(10, 20),
                new Square(40)
            };
            
            list.Sort();
            foreach (var item in list)
                item.Print();

            Console.WriteLine("---------------------");
            
            var matrix = new Matrix<GeometricFigure>(3, 2, 2, new Circle(1))
            {
                [0, 0, 0] = new Square(10), 
                [1, 1, 1] = new Rectangle(15, 20)
            };
            Console.WriteLine(matrix.ToString());
            
            Console.WriteLine("---------------------");

            var simpleStack = new SimpleStack<GeometricFigure>
            {
                new Circle(5),
                new Rectangle(5, 10),
                new Square(7)
            };

            Console.WriteLine(simpleStack.ToString());
            Console.WriteLine("------");
            Console.WriteLine("Popped item:" + simpleStack.Pop());
            simpleStack.Push(new Square(99));
            Console.WriteLine("------");
            Console.WriteLine(simpleStack.ToString());
        }
    }
}